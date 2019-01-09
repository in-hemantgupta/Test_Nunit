using Moq;
using NUnit.Framework;
using System;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class OrderServiceTests
    {
        OrderService service;
        Mock<IStorage> storage;
        [SetUp]
        public void SetUp()
        {
            storage = new Mock<IStorage>();
            service = new OrderService(storage.Object);
        }
        [Test]
        public void PlaceOrder_WhenCalled_ShouldReturnOrderId()
        {
            //storage.Setup(s => s.Store(new Order())).Returns(1);
            Order order = new Order();
            service.PlaceOrder(order);
            storage.Verify(s => s.Store(order));
        }
    }
}
