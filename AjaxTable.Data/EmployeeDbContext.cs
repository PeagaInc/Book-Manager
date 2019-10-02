using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AjaxTable.Data.Models;

namespace AjaxTable.Data
{
    public class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext() : base("EmployeeConnectionString")
        {
        
        }
        public DbSet<Employee> Employees { get; set; }
        
    }
}
 