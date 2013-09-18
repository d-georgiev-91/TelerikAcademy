namespace MajorantOfArrayTests
{
    using System;
    using System.Collections.Generic;
    using MajorantOfArray;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MajorantOfArrayTests
    {
        [TestMethod]
        public void GetArrayMajorantTest1()
        {
            List<int> array = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            var actual = MajorantOfArray.GetArrayMajorant(array);
            var excpeted = 3;
            Assert.AreEqual(excpeted, actual);
        }

        [TestMethod]
        public void GetArrayMajorantTest2()
        {
            List<int> array = new List<int>() { 1, 2, 3, 4, 5 };
            var actual = MajorantOfArray.GetArrayMajorant(array);
            int? excpeted = null;
            Assert.AreEqual(excpeted, actual);
        }

        [TestMethod]
        public void GetArrayMajorantTest3()
        {
            List<int> array = new List<int>() { 1, 5, 2, 2, 4, 2, 7, 2, 2, 2 };
            var actual = MajorantOfArray.GetArrayMajorant(array);
            var excpeted = 2;
            Assert.AreEqual(excpeted, actual);
        }

        [TestMethod]
        public void GetArrayMajorantTest4()
        {
            List<int> array = new List<int>() { 1, 5, 53, 2, 4, 2, 7, 2, 2, 2 };
            var actual = MajorantOfArray.GetArrayMajorant(array);
            int? excpeted = null;
            Assert.AreEqual(excpeted, actual);
        }
    }
}