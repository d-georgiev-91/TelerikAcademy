namespace RemoveOddOccuranceOfNumberTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RemoveOddOccuranceOfNumber;

    [TestClass]
    public class RemoveOddOccuranceOfNumberTests
    {
        [TestMethod]
        public void RemoveOddElementsTest1()
        {
            LinkedList<int> sequence = new LinkedList<int>(new int[] { 1, 3, 5, 3, 3, 5, 5, 6, 2, 5, 6, 3 });
            RemoveOddOccuranceOfNumber.RemoveOddElements(sequence);
            var actual = sequence;
            LinkedList<int> expected = new LinkedList<int>(new int[] { 3, 5, 3, 3, 5, 5, 6, 5, 6, 3 });
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveOddElementsTest2()
        {
            LinkedList<int> sequence = new LinkedList<int>(new int[] { 1, 1, 1, 1, 1 });
            RemoveOddOccuranceOfNumber.RemoveOddElements(sequence);
            var actual = sequence;
            LinkedList<int> expected = new LinkedList<int>();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveOddElementsTest3()
        {
            LinkedList<int> sequence = new LinkedList<int>(new int[] { 1, 1, 2, 2 });
            RemoveOddOccuranceOfNumber.RemoveOddElements(sequence);
            var actual = sequence;
            LinkedList<int> expected = new LinkedList<int>(new int[] { 1, 1, 2, 2 });
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}