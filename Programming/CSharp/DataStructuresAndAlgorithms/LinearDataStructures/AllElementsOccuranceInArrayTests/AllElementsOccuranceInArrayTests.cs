namespace AllElementsOccuranceInArrayTests
{
    using System;
    using System.Collections.Generic;
    using AllElementsOccuranceInArray;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AllElementsOccuranceInArrayTests
    { 
        [TestMethod]
        public void CountElementsOccuranceTest1()
        {
            List<int> array = new List<int>() { 1, 3, 5, 3, 3, 5, 5, 6, 2, 5, 6, 3 };
            var actual = AllElementsOccuranceInArray.CountElementsOccurance(array);
            var expected = new Dictionary<int, int>()
            {
                { 1, 1 },
                { 3, 4 },
                { 5, 4 },
                { 6, 2 },
                { 2, 1 },
            };

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void CountElementsOccuranceTest2()
        {
            List<int> array = new List<int>() { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
            var actual = AllElementsOccuranceInArray.CountElementsOccurance(array);
            var expected = new Dictionary<int, int>()
            {
                { 2, 16 },
            };

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void CountElementsOccuranceTest3()
        {
            List<int> array = new List<int>() { 1, 2, 3, 4, 5, 6 };
            var actual = AllElementsOccuranceInArray.CountElementsOccurance(array);
            var expected = new Dictionary<int, int>()
            {
                { 1, 1 },
                { 2, 1 },
                { 3, 1 },
                { 4, 1 },
                { 5, 1 },
                { 6, 1 },
            };

            CollectionAssert.AreEqual(actual, expected);
        }
    }
}