using NUnit.Framework;
using StringCalculatorKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKataTests
{

    [TestFixture]
    public class StringCalculatorKataTests
    {
        private StringCalculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new StringCalculator();
        }

        [Test]
        public void EmptyString_ShouldReturnZero()
        {
           
            int sum = calculator.Add(String.Empty);

            Assert.That(sum, Is.EqualTo(0));
        }

        [TestCase("0", 0)]
        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("3", 3)]
        [TestCase("4", 4)]
        [TestCase("5", 5)]
        [TestCase("6", 6)]
        [TestCase("7", 7)]
        [TestCase("8", 8)]
        [TestCase("9", 9)]
        public void One_ShouldReturnOne(string numbers, int expected )
        {
            
            int sum = calculator.Add(numbers);

            Assert.That(sum, Is.EqualTo(expected));
        }
    

    }
}
