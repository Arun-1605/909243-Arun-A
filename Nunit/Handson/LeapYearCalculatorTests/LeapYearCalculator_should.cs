using LeapYearCalculatorLib;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapYearCalculatorTests
{

    [TestFixture]
    public class LeapYearCalculator_should
    {
        LeapYearCalculator leapYearCalculator = new LeapYearCalculator();
        [Test]
        [TestCaseSource(typeof(CheckLeapYear_Cases))]
        public void check_year_InRange(int year, int expected)
        {
            var actual = leapYearCalculator.IsLeapYear(year);

            Assert.That(actual, Is.EqualTo(expected));
        }

    }

    

    class CheckLeapYear_Cases  : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new Object[] {2000,1};


                yield return new Object[] {1999,0};


                yield return new Object[] {2012,1};


                yield return new Object[] {1000,-1};


                yield return new Object[] {10000, -1};
            }
        }



    
}
