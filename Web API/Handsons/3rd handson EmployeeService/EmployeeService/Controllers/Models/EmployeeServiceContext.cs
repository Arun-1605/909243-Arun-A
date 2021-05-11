namespace EmployeeService.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;

    public class EmployeeServiceContext : DbContext
    {
    
        public EmployeeServiceContext()
            : base("name=Employee1")
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Department> Department { get; set; } 

    }

   
}