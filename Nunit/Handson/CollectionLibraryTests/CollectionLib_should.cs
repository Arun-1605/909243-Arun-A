using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionsLib;
using NUnit.Framework;
namespace CollectionLibTests
{
    [TestFixture]
    public class CollectionLib_should
    {
        [Test]
        public void check_notNull()
        {
            var employeemanager = new EmployeeManager();
            var actual = employeemanager.GetEmployees();
            CollectionAssert.IsNotEmpty(actual);
        }
        [Test]
        public void check_ById()
        {
            var employeemanager = new EmployeeManager();
            var actual = employeemanager.GetEmployeeByID(100);
            CollectionAssert.IsNotEmpty(actual);
        }

        [Test]
        public void check_getEmployees()
        {
            var employeemanager = new EmployeeManager();
            var actual = employeemanager.GetEmployees();
            var expected = new List<Employee>
            {
                new Employee { EmpId=100, EmpName="Arun",DOJ=DateTime.Now.AddYears(-5),Salary=30000},
                new Employee { EmpId=101, EmpName="Arthur",DOJ=DateTime.Now.AddYears(-2),Salary=10000},
                new Employee { EmpId=102, EmpName="Thomas",DOJ=DateTime.Now.AddYears(-2),Salary=10000},
                new Employee { EmpId=103, EmpName="Grace",DOJ=DateTime.Now.AddYears(-7),Salary=50000},
            };
            CollectionAssert.IsNotEmpty(actual);
            CollectionAssert.AreEqual(actual, expected, new EmployeeComparer());
        }
        [Test]
        public void getEmployeesfrompreviousyear()
        {
            var employeemanager = new EmployeeManager();
            var employee = new Employee();
            var expected = employeemanager.GetEmployees();
            var actual = employeemanager.GetEmployeesWhoJoinedInPreviousYears();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}