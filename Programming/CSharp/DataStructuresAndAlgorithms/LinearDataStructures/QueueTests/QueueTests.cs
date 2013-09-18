namespace QueueTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Queue;

    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void EnqueueInEmptyQueueTest()
        {
            var queue = new Queue<int>();
            int value = 5;
            queue.Enqueue(value);
            Assert.AreEqual(value, queue.Tail.Value);
            Assert.AreEqual(value, queue.Head.Value);
        }

        [TestMethod]
        public void EnqueueInNonEmptyValidHeadAndTailQueueTest()
        {
            var queue = new Queue<int>();
            var headValue = 5;
            queue.Enqueue(headValue);
            queue.Enqueue(10);
            queue.Enqueue(15);
            var tailValue = 20;
            queue.Enqueue(tailValue);
            Assert.AreEqual(tailValue, queue.Tail.Value);
            Assert.AreEqual(headValue, queue.Head.Value);
        }

        [TestMethod]
        public void EnqueueInNonEmptyValidSecondItemTest()
        {
            var queue = new Queue<int>();
            queue.Enqueue(5);
            int secondItemValue = 10;
            queue.Enqueue(secondItemValue);
            queue.Enqueue(15);
            queue.Enqueue(20);
            Assert.AreEqual(secondItemValue, queue.Head.Next.Value);
        }

        [TestMethod]
        public void EnqueueInNonEmptyValidThirdItemTailTest()
        {
            var queue = new Queue<int>();
            queue.Enqueue(5);
            queue.Enqueue(10);
            var secondItem = queue.Head.Next;
            var thirdItemValue = 15;
            queue.Enqueue(thirdItemValue);
            queue.Enqueue(20);
            Assert.AreEqual(thirdItemValue, secondItem.Next.Value);
        }

        [TestMethod]
        public void EnqueueInNonEmptyValidTailTest()
        {
            var queue = new Queue<int>();
            queue.Enqueue(5);
            queue.Enqueue(10);
            var secondItem = queue.Head.Next;
            queue.Enqueue(15);
            var thirdItem = secondItem.Next;
            int tailValue = 20;
            queue.Enqueue(tailValue);
            Assert.AreEqual(tailValue, thirdItem.Next.Value);
        }

        [TestMethod]
        public void EnqueueInNonEmptyValidTailNextItemTest()
        {
            var queue = new Queue<int>();
            queue.Enqueue(5);
            queue.Enqueue(10);
            queue.Enqueue(15);
            queue.Enqueue(20);
            Assert.IsNull(queue.Tail.Next);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DequeueEmptyQueueTest()
        {
            var queue = new Queue<int>();
            var value = queue.Dequeue();
        }

        [TestMethod]
        public void DequeueNonEmptyQueueOneItemTest()
        {
            var queue = new Queue<int>();
            var actual = 5;
            queue.Enqueue(actual);
            var expected = queue.Dequeue();
            Assert.AreEqual(expected, actual);
            Assert.IsNull(queue.Head);
            Assert.IsNull(queue.Tail);
        }

        [TestMethod]
        public void DequeueNonEmptyQueueTwoItemsTest()
        {
            var queue = new Queue<int>();
            var dequeuedActual = 5;
            queue.Enqueue(5);
            var tailExpected = 10;
            queue.Enqueue(tailExpected);
            var dequeuedExpected = queue.Dequeue();
            Assert.AreEqual(dequeuedExpected, dequeuedActual);
            var headExpected = tailExpected;
            Assert.AreEqual(headExpected, queue.Head.Value);
            var tailActual = queue.Tail.Value;
            Assert.AreEqual(tailExpected, tailActual);
        }

        [TestMethod]
        public void DequeueNonEmptyQueueThreeItemsTest()
        {
            var queue = new Queue<int>();
            var dequeuedActual = 5;
            queue.Enqueue(5);
            var headExpected = 10;
            queue.Enqueue(headExpected);
            var tailExpected = 15;
            queue.Enqueue(tailExpected);
            var dequeuedExpected = queue.Dequeue();
            Assert.AreEqual(dequeuedExpected, dequeuedActual);
            Assert.AreEqual(headExpected, queue.Head.Value);
            var tailActual = queue.Tail.Value;
            Assert.AreEqual(tailExpected, tailActual);
        }

        [TestMethod]
        public void CountTest()
        {
            var queue = new Queue<int>();
            queue.Enqueue(5);
            queue.Enqueue(5);
            queue.Enqueue(5);
            queue.Enqueue(5);
            queue.Enqueue(5);
            var value = queue.Dequeue();
            value = queue.Dequeue();
            queue.Enqueue(5);
            value = queue.Dequeue();
            value = queue.Dequeue();
            int actual = queue.Count;
            int expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClearTest()
        {
            var queue = new Queue<int>();
            queue.Enqueue(5);
            queue.Enqueue(5);
            queue.Enqueue(5);
            queue.Enqueue(5);
            queue.Enqueue(5);
            queue.Clear();
            Assert.AreEqual(0, queue.Count);
            Assert.IsNull(queue.Head);
            Assert.IsNull(queue.Tail);
        }

        [TestMethod]
        public void ContainsValidItemTest()
        {
            var queue = new Queue<int>();
            queue.Enqueue(5);
            queue.Enqueue(25);
            queue.Enqueue(415);
            queue.Enqueue(5412);
            queue.Enqueue(54);
            bool contains = queue.Contains(5);
            Assert.IsTrue(contains);
        }

        [TestMethod]
        public void ContainsNoSuchItemTest()
        {
            var queue = new Queue<int>();
            queue.Enqueue(5);
            queue.Enqueue(25);
            queue.Enqueue(415);
            queue.Enqueue(5412);
            queue.Enqueue(54);
            bool contains = queue.Contains(42);
            Assert.IsFalse(contains);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekEmptyQueueTest()
        {
            var queue = new Queue<int>();
            int value = queue.Peek();
        }

        [TestMethod]
        public void PeekNonEmptyQueueTest()
        {
            var queue = new Queue<int>();
            int expected = 5;
            queue.Enqueue(expected);
            queue.Enqueue(25);
            queue.Enqueue(415);
            queue.Enqueue(5412);
            queue.Enqueue(54);
            int actual = queue.Peek();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ToArrayEmptyQueueTest()
        {
            var queue = new Queue<int>();
            var array = queue.ToArray();
        }

        [TestMethod]
        public void ToArrayNonEmptyQueueTest()
        {
            var queue = new Queue<int>();
            queue.Enqueue(14);
            queue.Enqueue(25);
            queue.Enqueue(415);
            queue.Enqueue(5412);
            queue.Enqueue(54);
            var expected = new int[] { 14, 25, 415, 5412, 54 };
            var actual = queue.ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}