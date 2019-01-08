using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        CustomerController _controller;

        [SetUp]
        public void Setup() {
            _controller = new CustomerController();
        }

        [Test]
        public void GetCustomer_IdIsZero_ReturnsNotFound()
        {
            var result = _controller.GetCustomer(0);
            Assert.That(result, Is.TypeOf<NotFound>());
            Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IdIsNotZero_ReturnsOk()
        {
        }
    }
}
