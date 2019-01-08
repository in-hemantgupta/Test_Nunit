using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        [Test]
        [TestCase("hello")]
        [TestCase("abc")]
        [TestCase("123")]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement(string input)
        {
            //arrange
            var formatter = new HtmlFormatter();
            string result = formatter.FormatAsBold(input);
            //Assert.AreEqual("<strong>hello</strong>", result);

            //Assert.That(result, Is.EqualTo("<strong>hello</strong>"));

            //more general
            Assert.That(result, Does.StartWith("<strong>").IgnoreCase);
            Assert.That(result, Does.EndWith("</strong>").IgnoreCase);
            Assert.That(result, Does.Contain(input).IgnoreCase);
        }
    }
}
