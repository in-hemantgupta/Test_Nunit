using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        Stack<int> _stack;

        [SetUp]
        public void Setup()
        {
            _stack = new Stack<int>();
        }

        [Test]
        public void Push_WhenCalled_ShouldInsertOneItemAndIncreaseCountByOne()
        {
            _stack.Push(1);
            Assert.That(_stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Pop_WhenCalled_ShouldRemoveOneItemAndDecreaseCountByOne()
        {
            _stack.Push(1);
            int item = _stack.Pop();
            Assert.That(_stack.Count, Is.EqualTo(0));
            Assert.That(item, Is.EqualTo(1));
        }

        [Test]
        public void Peek_WhenCalled_ShouldReturnOneItem()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);
            var item = _stack.Peek();
            Assert.That(_stack.Count, Is.EqualTo(3));
            Assert.That(item, Is.EqualTo(3));
        }

        [Test]
        public void Pop_WhenCalledIfNoItemsRemain_ShouldReturnArgumentNull()
        {
            Assert.That(() => _stack.Peek(), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Peek_WhenCalledIfNoItemsRemain_ShouldReturnArgumentNull()
        {
            Assert.That(() => _stack.Peek(), Throws.Exception.TypeOf<InvalidOperationException>());
        }
    }
}
