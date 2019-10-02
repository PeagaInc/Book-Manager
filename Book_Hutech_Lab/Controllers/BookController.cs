using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Hutech_Lab.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult BookManager()
        {
            return View();
        }
    }
}