namespace AjaxTable.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AjaxTable.Data.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<AjaxTable.Data.EmployeeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AjaxTable.Data.EmployeeDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Employees.AddOrUpdate(
                new Employee { Name = "Andrew Peters A", Salary= 2000, CreateDate=DateTime.Now,Status=true},
                new Employee { Name = "Brice Lambson A", Salary = 3000, CreateDate = DateTime.Now, Status = true },
                new Employee { Name = "Rowan Miller A", Salary = 2500, CreateDate = DateTime.Now, Status = true },
                new Employee { Name = "Andrew Peters B", Salary = 2000, CreateDate = DateTime.Now, Status = true },
                new Employee { Name = "Brice Lambson B", Salary = 3000, CreateDate = DateTime.Now, Status = true },
                new Employee { Name = "Rowan Miller B", Salary = 2500, CreateDate = DateTime.Now, Status = true },
                new Employee { Name = "Andrew Peters C", Salary = 2000, CreateDate = DateTime.Now, Status = true },
                new Employee { Name = "Brice Lambson C", Salary = 3000, CreateDate = DateTime.Now, Status = true },
                new Employee { Name = "Rowan Miller C", Salary = 2500, CreateDate = DateTime.Now, Status = true },
                new Employee { Name = "Andrew Peters D", Salary = 2000, CreateDate = DateTime.Now, Status = true },
                new Employee { Name = "Brice Lambson D", Salary = 3000, CreateDate = DateTime.Now, Status = true },
                new Employee { Name = "Rowan Miller D", Salary = 2500, CreateDate = DateTime.Now, Status = true }
            );
            context.SaveChanges();
        }
    }
}
