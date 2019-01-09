using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        DemeritPointsCalculator _demaritPointCalc;

        [SetUp]
        public void Setup() {
            _demaritPointCalc = new DemeritPointsCalculator();
        }

        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_WhenSpeedLessThanZero_ReturnsArgumentOutOfRangeException(int speed)
        {
            //var result = _demaritPointCalc.CalculateDemeritPoints(10)

            Assert.That(() => _demaritPointCalc.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());

        }

        [Test]
        [TestCase(64,0)]
        [TestCase(65,0)]
        [TestCase(66,0)]
        [TestCase(70,1)]
        [TestCase(75,2)]
        public void CalculateDemeritPoints_WhenSpeedIsGreaterThanSpeedLimit_ReturnsDemiritPointsGreaterThanOne(int speed, int expectedResult)
        {
            var result = _demaritPointCalc.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(expectedResult));

        }
    }
}
