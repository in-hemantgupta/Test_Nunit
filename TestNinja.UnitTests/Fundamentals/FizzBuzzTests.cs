using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        public void GetOutput_WhenInputIsDivisableBy3And5_ReturnsFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(15);
            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutput_WhenInputIsDivisableBy3_ReturnsFizz()
        {
            var result = FizzBuzz.GetOutput(9);
            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        public void GetOutput_WhenInputIsDivisableBy5_ReturnsBuzz()
        {
            var result = FizzBuzz.GetOutput(10);
            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOutput_WhenInputAreNotDivisableBy3And5_ReturnsSameNumber()
        {
            var result = FizzBuzz.GetOutput(19);
            Assert.That(result, Is.EqualTo("19"));
        }
    }
}
