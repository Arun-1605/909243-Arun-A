using MathLibrary;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibraryTests
{
    [TestFixture]
    public class MathLibraryTests
    {
       [Test]
       [TestCaseSource("TestCaseData")]
       public void CompareToNumbersTest(int num1, int num2,int expected)
        {
              
            var mathlib = new MathLib();

           

            //var actual = mathlib.CompareTwoNumbers(num1, num2);

            //assert

            Assert.That(expected, Is.EqualTo(mathlib.CompareTwoNumbers(num1, num2)));
        }

        static object[] TestCaseData
        {
            get
            {
                return new object[]
                {
                    new object[]{-5,-10,0},
                    new object[]{10,5,1},
                    new object[]{-10,21,-1}

                };


            }

        }

    }
}
