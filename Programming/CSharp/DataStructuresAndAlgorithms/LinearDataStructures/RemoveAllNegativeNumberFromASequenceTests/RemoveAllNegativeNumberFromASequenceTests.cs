namespace RemoveAllNegativeNumberFromASequenceTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RemoveAllNegativeNumberFromASequence;

    [TestClass]
    public class RemoveAllNegativeNumberFromASequenceTests
    {
        [TestMethod]
        public void RemoveNegativeElementsTest1()
        {
            LinkedList<int> sequence = new LinkedList<int>(new int[] { 2, -4, 5, 5, 6, -2, -5, -6 });
            RemoveAllNegativeNumberFromASequence.RemoveNegativeElements(sequence);
            bool containsNegativeElements = ContainsNegativeElements(sequence);
            Assert.IsFalse(containsNegativeElements);
        }

        [TestMethod]
        public void RemoveNegativeElementsTest2()
        {
            LinkedList<int> sequence = new LinkedList<int>(new int[] { 2, 5, 5, 6, 7 });
            bool containsNegativeElements = ContainsNegativeElements(sequence);
            Assert.IsFalse(containsNegativeElements);
        }

        [TestMethod]
        public void RemoveNegativeElementsTest3()
        {
            LinkedList<int> sequence = new LinkedList<int>(new int[] { 2, -4, 5, 5, 6, -2, -5, -6 });
            RemoveAllNegativeNumberFromASequence.RemoveNegativeElements(sequence);
            var actual = sequence;
            var expected = new LinkedList<int>(new int[] { 2, 5, 5, 6});
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveNegativeElementsTest4()
        {
            LinkedList<int> sequence = new LinkedList<int>(new int[] { 2, 2, 3, 5, 6 });
            RemoveAllNegativeNumberFromASequence.RemoveNegativeElements(sequence);
            var actual = sequence;
            var expected = new LinkedList<int>(new int[] { 2, 2, 3, 5, 6 });
            CollectionAssert.AreEqual(expected, actual);
        }

        private bool ContainsNegativeElements(LinkedList<int> sequence)
        {
            foreach (var item in sequence)
            {
                if (item < 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}