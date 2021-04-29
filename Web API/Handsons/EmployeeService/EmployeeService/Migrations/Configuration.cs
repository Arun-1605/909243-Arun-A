namespace EmployeeService.Migrations
{
    using EmployeeService.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeService.Models.EmployeeServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmployeeService.Models.EmployeeServiceContext context)
        {
            context.Department.AddOrUpdate(x => x.Id,
                new Department() { Id = 100, Name = "HR" },
                new Department() { Id = 101, Name = "Technical" }
                );
            context.Employee.AddOrUpdate(x => x.Id,
                new Employee()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Smith",
                    DepartmentId = 101,
                    Salary = 30000
                },
             new Employee()
             {
                 Id = 2,
                 FirstName = "Mary",
                 LastName = "Jane",
                 DepartmentId = 100,
                 Salary = 20000
             },
             new Employee()
             {
                 Id = 3,
                 FirstName = "Steve",
                 LastName = "Lopez",
                 DepartmentId = 101,
                 Salary = 50000
             });




        }
    }
}
