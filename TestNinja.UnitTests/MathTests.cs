using NUnit.Framework;
using System.Linq;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        Math _math;
        //Setup => before test method
        [SetUp]
        public void Setup()
        {
            _math = new Math();
        }
        //Teardown => after test method

        [Test]
        public void Add_WhenCalled_ReturnsSumOfArgs()
        {
            //Arrange
            //Act
            var result = _math.Add(1, 2);
            //Assert
            Assert.That(result, Is.EqualTo(3));
        }

        //[Test]
        //public void Max_WhenFirstArgIsGreater_ReturnsFirstArg()
        //{
        //    //Arrange
        //    //Act
        //    var result = _math.Max(3, 2);
        //    //Assert
        //    Assert.That(result, Is.EqualTo(3));
        //}

        //[Test]
        //public void Max_WhenSecondArgIsGreater_ReturnsSecondArg()
        //{
        //    //Arrange
        //    //Act
        //    var result = _math.Max(1, 2);
        //    //Assert
        //    Assert.That(result, Is.EqualTo(2));
        //}

        //[Test]
        //public void Max_WhenBothArgsAreEqual_ReturnsSameArgs()
        //{
        //    //Arrange
        //    //Act
        //    var result = _math.Max(1, 2);
        //    //Assert
        //    Assert.That(result, Is.EqualTo(2));
        //}

        [Ignore("Will setup later")]
        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnsGreaterArg(int a, int b, int expectedResult)
        {
            //Act
            var result = _math.Max(a, b);
            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetOddNumbers_LimitsGreaterThanZero_ShouldReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);
        }

    }
}
