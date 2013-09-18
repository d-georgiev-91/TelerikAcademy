namespace StackTests
{
    using Stack;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public void PushInEmptyStackTest()
        {
            var stack = new Stack<int>();
            stack.Push(5);
            var actual = stack.Top.Value;
            var expected = 5;
            Assert.AreEqual(expected, actual);
        }
  
        [TestMethod]
        public void PushInNonEmptyTwoItemsStackTest()
        {
            var stack = new Stack<int>();
            stack.Push(5);
            stack.Push(15);
            var actual = stack.Top.Value;
            var expected = 15;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PushInNonEmptyMoreThanTwoItemsStackTest()
        {
            var stack = new Stack<int>();
            stack.Push(5);
            stack.Push(15);
            stack.Push(165);
            stack.Push(13);
            stack.Push(1152);
            stack.Push(15412);
            var actual = stack.Top.Value;
            var expected = 15412;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopEmptyStackTest()
        {
            var stack = new Stack<int>();
            int item = stack.Pop();
        }

        [TestMethod]
        public void PopNonEmptyStackTest()
        {
            var stack = new Stack<int>();
            int expected = 3;
            stack.Push(expected);
            int actual = stack.Pop();
            Assert.AreEqual(expected, actual);
            Assert.IsNull(stack.Top);
        }

        [TestMethod]
        public void PopNonEmptyMoreThanOneItemStackTest()
        {
            var stack = new Stack<int>();
            stack.Push(5);
            stack.Push(10);
            stack.Push(15);
            var thirdItem = stack.Top;
            stack.Push(20);
            int expected = 3;
            stack.Push(expected);
            int actual = stack.Pop();
            Assert.AreEqual(expected, actual);
            Assert.AreSame(thirdItem, stack.Top.Next);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekEmptyStackTest()
        {
            var stack = new Stack<int>();
            var peek = stack.Peek();
        }

        [TestMethod]
        public void PeekNonEmptyIsCorrectValueReturnedStackTest()
        {
            var stack = new Stack<int>();
            stack.Push(5);
            stack.Push(10);
            stack.Push(15);
            stack.Push(20);
            var actual = stack.Peek();
            var expected = stack.Top.Value;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PeekNonEmptyIsTopInStackTest()
        {
            var stack = new Stack<int>();
            stack.Push(5);
            stack.Push(10);
            stack.Push(15);
            stack.Push(20);
            var expected = stack.Top;
            var peekValue = stack.Peek();
            var actual = stack.Top;
            Assert.AreSame(expected, actual);
        }

        [TestMethod]
        public void ClearTest()
        {
            var stack = new Stack<int>();
            stack.Push(5);
            stack.Push(5);
            stack.Push(5);
            stack.Push(5);
            stack.Push(5);
            stack.Clear();
            Assert.AreEqual(0, stack.Count);
            Assert.IsNull(stack.Top);
        }

        [TestMethod]
        public void ContainsValidItemTest()
        {
            var stack = new Stack<int>();
            stack.Push(5);
            stack.Push(25);
            stack.Push(415);
            stack.Push(5412);
            stack.Push(54);
            bool contains = stack.Contains(5);
            Assert.IsTrue(contains);
        }

        [TestMethod]
        public void ContainsNoSuchItemTest()
        {
            var stack = new Stack<int>();
            stack.Push(5);
            stack.Push(25);
            stack.Push(415);
            stack.Push(5412);
            stack.Push(54);
            bool contains = stack.Contains(42);
            Assert.IsFalse(contains);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ToArrayEmptyStackTest()
        {
            var stack = new Stack<int>();
            var array = stack.ToArray();
        }

        [TestMethod]
        public void ToArrayNonEmptyStackTest()
        {
            var stack = new Stack<int>();
            stack.Push(14);
            stack.Push(25);
            stack.Push(415);
            stack.Push(5412);
            stack.Push(54);
            var expected = new int[] { 14, 25, 415, 5412, 54 };
            var actual = stack.ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}