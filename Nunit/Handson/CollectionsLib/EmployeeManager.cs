using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsLib
{
    public class Employee : IComparable<Employee>, IEqualityComparer<Employee>
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public double Salary { get; set; }
        public DateTime DOJ { get; set; }


        int IComparable<Employee>.CompareTo(Employee other)
        {
            return this.EmpId.CompareTo(other.EmpId);
        }
        public bool Equals(Employee x, Employee y)
        {
            var employee1 = x as Employee;
            var employee2 = y as Employee;
            return employee1.EmpId.Equals(employee2.EmpId);
        }

        public int GetHashCode(Employee obj)
        {
            return Convert.ToInt32(EmpId);
        }

    }

    public class EmployeeManager
    {
        private static readonly List<Employee> employees;

        static EmployeeManager()
        {
            employees = new List<Employee>
            {
                new Employee { EmpId=100, EmpName="Arun",DOJ=DateTime.Now.AddYears(-5),Salary=30000},
                new Employee { EmpId=101, EmpName="Arthur",DOJ=DateTime.Now.AddYears(-2),Salary=10000},
                new Employee { EmpId=102, EmpName="Thomas",DOJ=DateTime.Now.AddYears(-2),Salary=10000},
                new Employee { EmpId=103, EmpName="Grace",DOJ=DateTime.Now.AddYears(-7),Salary=50000},
            };
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public List<Employee> GetEmployeeByID(int empID)
        {
            return employees.Where(e => e.EmpId == empID).ToList();
        }

        public List<Employee> GetEmployeesWhoJoinedInPreviousYears()
        {
            return employees.FindAll(x => x.DOJ < DateTime.Now);
        }
    }
}