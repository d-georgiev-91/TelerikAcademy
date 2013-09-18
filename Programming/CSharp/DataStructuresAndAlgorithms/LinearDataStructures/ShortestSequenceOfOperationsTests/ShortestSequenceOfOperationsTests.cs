namespace ShortestSequenceOfOperationsTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ShortestSequenceOfOperations;

    [TestClass]
    public class ShortestSequenceOfOperationsTests
    {
        [TestMethod]
        public void SequenceAsStringTest1()
        {
            int beginning = 5;
            int end = 16;
            string actual = ShortestSequenceOfOperations.SequenceAsString(beginning, end);
            string expected = "5 -> 6 -> 8 -> 16";
            Assert.AreEqual(expected, actual);
        }
    
        [TestMethod]
        public void SequenceAsStringTest2()
        {
            int beginning = -10;
            int end = -4;
            string actual = ShortestSequenceOfOperations.SequenceAsString(beginning, end);
            string expected = "-10 -> -8 -> -6 -> -4";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SequenceAsStringTest3()
        {
            int beginning = -5;
            int end = 0;
            string actual = ShortestSequenceOfOperations.SequenceAsString(beginning, end);
            string expected = "-5 -> -4 -> -2 -> 0";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SequenceAsStringTest4()
        {
            int beginning = -5;
            int end = 2;
            string actual = ShortestSequenceOfOperations.SequenceAsString(beginning, end);
            string expected = "-5 -> -4 -> -2 -> 0 -> 1 -> 2";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SequenceAsStringTest5()
        {
            int beginning = -16;
            int end = -5;
            string actual = ShortestSequenceOfOperations.SequenceAsString(beginning, end);
            string expected = "-16 -> -15 -> -13 -> -11 -> -9 -> -7 -> -5";
            Assert.AreEqual(expected, actual);
        }
    }
}
