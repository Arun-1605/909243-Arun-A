using CalculatorLib;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CalculatorTests
{
    [TestFixture]
    [Author("Arun")]
    [Category("Math")]
    public class CalculatorTests
    {
        Calculator calculator = new Calculator();
        // [SetUp]
        //public void Initialize()
        //{

        //    var calculator = new Calculator();

        //}


        [Test]
        [TestCase(10, 20, 30)]
        [Order(1)]
        public void Add_TrueTest(int num1, int num2, int expected)
        {
            // var calculator = new Calculator();

            int actual = calculator.Add(num1, num2);
            Assert.That(actual, Is.EqualTo(num1 + num2));
        }


        [Test]
        [TestCaseSource("TestCaseData")]
        [Order(1)]
        public void Add_FalseTest(int num1, int num2, int expected)
        {
            // var calculator = new Calculator();

            int actual = calculator.Add(num1, num2);
            Assert.AreEqual(expected, actual);


        }

        [Test]
        [TestCase(20, 10, 10)]
        [Order(4)]
        public void Subtract_TrueTest(int num1, int num2, int expected)
        {
            // var calculator = new Calculator();

            int actual = calculator.Subtract(num1, num2);
            Assert.That(actual, Is.EqualTo(num1 - num2));
        }




        [Test]
        [TestCaseSource("TestCaseData1")]
        [Order(4)]
        public void Subtract_FalseTest(int num1, int num2, int expected)
        {
            //   var calculator = new Calculator();

            int actual = calculator.Subtract(num1, num2);
            Assert.AreEqual(expected, actual);


        }

        [Test]
        [TestCase(20, 10, 200)]
        [Order(3)]
        public void Multiply_TrueTest(int num1, int num2, int expected)
        {
            //   var calculator = new Calculator();

            int actual = calculator.Mutiply(num1, num2);
            Assert.That(actual, Is.EqualTo(num1 * num2));
        }


        [Test]
        [TestCaseSource("TestCaseData2")]
        [Order(3)]
        public void Multiply_FalseTest(int num1, int num2, int expected)
        {
            //  var calculator = new Calculator();

            int actual = calculator.Mutiply(num1, num2);
            Assert.AreEqual(expected, actual);


        }

        [Test]
        [TestCase(20, 10, 2)]
        [TestCase(20, 40, 0.5)]
        [Order(2)]
        [Ignore("Divide method will be ignored")]
        public void Divide_TrueTest(int num1, int num2, int expected)
        {
            //   var calculator = new Calculator();

            int actual = calculator.Subtract(num1, num2);

            Assert.AreEqual(actual.ToString("N2"), expected.ToString("N2"));


        }


        [Test]
        [TestCaseSource("TestCaseData3")]
        [Category("Math")]
        [Ignore("Divide method will be ignored")]
        [Order(2)]
        public void Divide_FalseTest(int num1, int num2, int expected)
        {
            //  var calculator = new Calculator();

            double actual = calculator.Divide(num1, num2);

            Assert.AreEqual(actual.ToString("N2"), expected.ToString("N2"));


        }


        static object[] TestCaseData
        {
            get
            {
                return new object[]
                {
                    new object[]{0,10,0},
                    new object[]{10,0,0},
                    new object[]{10,-21,0}

                };


            }

        }



        static object[] TestCaseData1
        {
            get
            {
                return new object[]
                {
                    new object[]{5,10,0},
                    new object[]{10,0,0},
                    new object[]{10,-21,0}

                };


            }

        }

        static object[] TestCaseData2
        {
            get
            {
                return new object[]
                {
                    new object[]{0,10,0},
                    new object[]{10,0,0},
                    new object[]{10,-21,0}

                };


            }

        }

        static object[] TestCaseData3
        {
            get
            {
                return new object[]
                {
                    new object[]{0,10,0},
                    new object[]{10,0,0},
                    new object[]{10,-21,0}

                };


            }

        }

        [Test]
        [TestCase(12, 0)]
        public void dividebyzeroException_test(int number1, int number2)
        {
            Assert.Throws<System.DivideByZeroException>(() =>
            {
                var actual = calculator.div(number1, number2);
            });
        }

    }

}



    

