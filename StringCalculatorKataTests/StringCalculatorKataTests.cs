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
        public void SingleDigit_ShouldReturnSingleDigit(string numbers, int expected )
        {
            
            int sum = calculator.Add(numbers);

            Assert.That(sum, Is.EqualTo(expected));
        }

        [TestCase("0,1", 1)]
        [TestCase("1,2", 3)]
        [TestCase("2,3", 5)]
        [TestCase("3,4", 7)]
        [TestCase("4,5", 9)]
        [TestCase("5,6", 11)]
        [TestCase("6,7", 13)]
        [TestCase("7,8", 15)]
        [TestCase("8,9", 17)]
        public void TwoNumberString_ShouldReturnSumOfNumber(string numbers, int expected )
        {

            int sum = calculator.Add(numbers);

            Assert.That(sum, Is.EqualTo(expected));
        }

        [Test]
        public void UnknownNumberString_ShouldProduceSumOfNumbers()
        {
            int sum = calculator.Add("2,3,4");

            Assert.That(sum, Is.EqualTo(9));

        }

       [Test]
       public void Add_ShouldAcceptNewLineAsADelimeter()
        {

            int sum = calculator.Add("1\n2,3");

            Assert.That(sum, Is.EqualTo(6));
        }

       [Test]
       public void Add_ShouldAcceptCustomDelimeters()
       {

           int sum = calculator.Add("//;\n1;2");

           Assert.That(sum, Is.EqualTo(3));
       }

       [Test]
       public void AddWithNegitive_ShouldThrowInvalidArgumentException()
       {

           var exception = Assert.Throws<NegitiveNotAllowedExcetption>(() => calculator.Add("1,-1"));
           Assert.That(exception.Message, Is.EqualTo("Negitives not allowed: -1"));
       
       }

       [Test]
       public void AddWithMultipleNegitives_ShouldThrowInvalidArgumentExceptionWithAllNumbersInMessage()
       {

           var exception = Assert.Throws<NegitiveNotAllowedExcetption>(() => calculator.Add("1,-1,-2"));
           Assert.That(exception.Message, Is.EqualTo("Negitives not allowed: -1 | -2"));

       }

       [Test]
       public void AddWithNumberHigherThen1000_ShouldBeIgnored()
       {

           int sum = calculator.Add("2,1001");

           Assert.That(sum, Is.EqualTo(2));
           
       }

       [Test]
       public void DelimetersOfAnyLengthCanBeUsed()
       {
           int sum = calculator.Add("//[***]\n1***2***3");

           Assert.That(sum, Is.EqualTo(6));

       }

       [Test]
        public void MultipleCustomDelimetersCanBeUsed_ShouldResultInSum()
       {
           int sum = calculator.Add("//[*][%]\n1*2%3");

           Assert.That(sum, Is.EqualTo(6));

       }

       [Test]
       public void MultipleCustomDelimetersOfAnyLengthCanBeUsed_ShouldResultInSum()
       {
           int sum = calculator.Add("//[****][%%]\n1****2%%3");

           Assert.That(sum, Is.EqualTo(6));

       }




    }
}
