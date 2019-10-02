using AjaxTable.Data;
using AjaxTable.Data.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Book_Hutech_Lab.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeDbContext _context;
        public HomeController()
        {
            _context = new EmployeeDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult LoadData(int page, int pageSize =12)
        {
            var model = _context.Employees.OrderByDescending(x=>x.ID).Skip((page - 1) * pageSize).Take(pageSize);
            int totalRow = _context.Employees.Count();

            return Json(new
            {
                data = model,
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(String model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Employee employee = serializer.Deserialize<Employee>(model);
            // save database.
            var entity = _context.Employees.Find(employee.ID);
            entity.Salary = employee.Salary;

            return Json(new
            {
                status = true
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult SaveData(string strEmployee)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Employee employee = serializer.Deserialize<Employee>(strEmployee);
            bool status = false;
            string message = string.Empty;
            if (employee.ID == 0)
            {
                employee.CreateDate = DateTime.Now;
                _context.Employees.Add(employee);
                try
                {
                    _context.SaveChanges();
                    status = true;
                }
                catch (Exception ex)
                {
                    status = false; message = ex.Message;
                }
            }
            else {
                var entity = _context.Employees.Find(employee.ID);
                entity.Salary = employee.Salary;
                entity.Name = employee.Name;
                entity.Status = employee.Status;
                _context.SaveChanges();
                status = true;
            }
            return Json(new
            {
                status = status,
                message=message
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetDetail(int id)
        {
            var employee = _context.Employees.Find(id);

            return Json(new
            {
                data = employee,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return Json(new
            {
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}