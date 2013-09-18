namespace LinkedListTests
{
    using System;
    using LinkedList;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LinkedListTests
    {
        #region AddFirstTests

        [TestMethod]
        public void AddFirstEmptyListIsValueValidTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            int expected = 5;
            list.AddFirst(expected);
            int actual = list.FirstElement.Value;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddFirstEmptyListIsNextValidTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(5);
            var actual = list.FirstElement.Next;
            object expected = null;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddFirstTwoElementsListIsValueValidTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(5);
            int expected = 10;
            list.AddFirst(expected);
            int actual = list.FirstElement.Value;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddFirstThreeElementsListIsValueValidTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(5);
            list.AddFirst(10);
            int expected = 15;
            list.AddFirst(expected);
            int actual = list.FirstElement.Value;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddFirstTwoElementsListIsNextValidTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(5);
            list.AddFirst(10);
            int expected = 5;
            int actual = list.FirstElement.Next.Value;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddFirstThreeElementsListIsLastValidTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(5);
            list.AddFirst(10);
            list.AddFirst(15);
            int expected = 5;
            var secondElement = list.FirstElement.Next;
            var lastElement = secondElement.Next;
            int actual = lastElement.Value;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddFirstThreeElementsListIsSecondValidTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(5);
            list.AddFirst(10);
            list.AddFirst(15);
            int expected = 10;
            var secondElement = list.FirstElement.Next;
            int actual = secondElement.Value;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddFirstIsCorrectPrevElementTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(5);
            list.AddFirst(10);
            list.AddFirst(15);
            var secondElement = list.FirstElement.Next;
            int actual = secondElement.Previous.Value;
            int expected = list.FirstElement.Value;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddFirstIsCorrectPrevForLastElementTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(5);
            list.AddFirst(10);
            list.AddFirst(15);
            var secondElement = list.FirstElement.Next;
            int actual = secondElement.Value;
            int expected = list.LastElement.Previous.Value;
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region AddLastTests

        [TestMethod]
        public void AddLastEmptyListIsValueValidTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            int expected = 5;
            list.AddLast(expected);
            int actual = list.FirstElement.Value;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddLastEmptyListIsNextValidTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(5);
            var actual = list.FirstElement.Next;
            object expected = null;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddLastTwoElementsListIsValueValidTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(5);
            int expected = 10;
            list.AddLast(expected);
            int actual = list.FirstElement.Next.Value;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddLastThreeElementsListIsValueValidTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(5);
            list.AddLast(10);
            int expected = 15;
            list.AddLast(expected);
            int actual = list.LastElement.Value;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddLastTwoElementsListIsNextValidTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(5);
            list.AddLast(10);
            int expected = 10;
            int actual = list.FirstElement.Next.Value;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddLastThreeElementsListIsLastValidTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(5);
            list.AddLast(10);
            list.AddLast(15);
            int expected = 15;
            var secondElement = list.FirstElement.Next;
            var lastElement = secondElement.Next;
            int actual = lastElement.Value;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddLastThreeElementsListIsSecondValidTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(5);
            list.AddLast(10);
            list.AddLast(15);
            int expected = 10;
            var secondElement = list.FirstElement.Next;
            int actual = secondElement.Value;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddLastIsCorrectPrevElementTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(5);
            list.AddLast(10);
            list.AddLast(15);
            var secondElement = list.FirstElement.Next;
            int actual = secondElement.Previous.Value;
            int expected = list.FirstElement.Value;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddLastIsCorrectPrevForLastElementTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(5);
            list.AddLast(10);
            list.AddLast(15);
            var secondElement = list.FirstElement.Next;
            int actual = secondElement.Value;
            int expected = list.LastElement.Previous.Value;
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region AddBeforeTests

        [TestMethod]
        public void AddBeforeFirstTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(5);
            list.AddLast(10);
            list.AddLast(15);
            var element = list.FirstElement;
            var swapedElement = new ListNode<int>(element.Value, element.Next, element.Previous);
            var newElement = new ListNode<int>(15);
            list.AddBefore(element, newElement);
            Assert.IsNull(newElement.Previous);
            var actual = newElement.Next.Value;
            var expected = swapedElement.Value;
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region AddAfterTests

        [TestMethod]
        public void AddAfterFirstTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(5);
            list.AddLast(10);
            list.AddLast(15);
            var element = list.LastElement;
            var swapedElement = new ListNode<int>(element.Value, element.Next, element.Previous);
            var newElement = new ListNode<int>(15);
            list.AddAfter(element, newElement);
            Assert.IsNull(newElement.Next);
            var actual = newElement.Previous.Value;
            var expected = swapedElement.Value;
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region RemoveFirstTests
        
        [TestMethod]
        public void RemoveFirstTest1()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(5);
            list.AddLast(10);
            var second = list.LastElement;
            list.AddLast(15);
            list.RemoveFirst();
            var expected = second;
            var actual = list.FirstElement;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveFirstTest2()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(5);
            list.AddLast(10);
            var second = list.LastElement;
            list.AddLast(15);
            list.RemoveFirst();
            Assert.IsNull(list.FirstElement.Previous);
        }

        #endregion

        #region RemoveLastTests
        
        [TestMethod]
        public void RemoveLastTest1()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(5);
            list.AddLast(10);
            var second = list.LastElement;
            list.AddLast(15);
            list.RemoveLast();
            var expected = second;
            var actual = list.LastElement;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveLastTest2()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(5);
            list.AddLast(10);
            var second = list.LastElement;
            list.AddLast(15);
            list.RemoveLast();
            Assert.IsNull(list.LastElement.Next);
        }

        #endregion

        #region CountTests

        [TestMethod]
        public void TestCount()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(5);
            list.AddLast(10);
            list.AddLast(15);
            list.RemoveLast();
            list.AddFirst(151);
            list.AddFirst(15134);
            list.AddAfter(list.LastElement, new ListNode<int>(53));
            list.AddBefore(list.LastElement, new ListNode<int>(553));
            list.RemoveFirst();
            list.RemoveFirst();
            list.AddFirst(151);
            int actual = list.Count;
            int expected = 5;
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
