namespace LongestSubSequenceOfEqualElementsTests
{
    using System;
    using System.Collections.Generic;
    using LongestSubSequenceOfEqualElements;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LongestSubSequenceOfEqualElementsTests
    {
        [TestMethod]
        public void GetLongestSubSequenceOfEqualElementsTest1()
        {
            List<int> sequence = new List<int>(new int[] { 1, 3, 3, 5, 0, 5, 6, 12, 1, 1, 1, 1, 4 });
            List<int> expected = new List<int>(new int[] { 1, 1, 1, 1 });
            var actual = LongestSubSequenceOfEqualElements.GetLongestSubSequenceOfEqualElements(sequence);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetLongestSubSequenceOfEqualElementsTest2()
        {
            List<int> sequence = new List<int>(new int[] { 1, 2, 3, 4 });
            List<int> expected = null;
            var actual = LongestSubSequenceOfEqualElements.GetLongestSubSequenceOfEqualElements(sequence);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetLongestSubSequenceOfEqualElementsTest3()
        {
            List<int> sequence = new List<int>(new int[] { -1, 2, 3, 4, -1 });
            List<int> expected = null;
            var actual = LongestSubSequenceOfEqualElements.GetLongestSubSequenceOfEqualElements(sequence);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetLongestSubSequenceOfEqualElementsTest4()
        {
            List<int> sequence = new List<int>(new int[] { -1, 2, 3, 2, 2, 5, 2, 2, 2, 5, 2, 2, 2, 2, -1 });
            List<int> expected = new List<int>(new int[] { 2, 2, 2, 2 });
            var actual = LongestSubSequenceOfEqualElements.GetLongestSubSequenceOfEqualElements(sequence);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetLongestSubSequenceOfEqualElementsTest5()
        {
            List<int> sequence = new List<int>(new int[] { 2, 2, 2, 1, 4, 4, 4 });
            List<int> expected = new List<int>(new int[] { 2, 2, 2 });
            var actual = LongestSubSequenceOfEqualElements.GetLongestSubSequenceOfEqualElements(sequence);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}