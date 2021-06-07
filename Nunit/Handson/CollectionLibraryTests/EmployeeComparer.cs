using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CollectionsLib
    {
        class EmployeeComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                var employee1 = x as Employee;
                var employee2 = y as Employee;
                return employee1.EmpId.CompareTo(employee2.EmpId);
            }
        }
    }



