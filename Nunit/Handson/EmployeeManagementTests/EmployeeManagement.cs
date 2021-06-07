using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement;
using NUnit.Framework;
using System.Collections;

namespace EmployeeManagementTests
{
    [TestFixture]
    public class EmployeeManagement
    {
        [Test]
        public void Should_AddEmployee()
        {
            var employeemanager = new EmployeeManager();

            var employee = new Employee() { Id=1, Name = "Arun" };

            
            employeemanager.AddEmployee(employee);


            var actual = employeemanager;

            Assert.That(actual.HeadCount == employeemanager.HeadCount);

          
        }
     
    }
}
