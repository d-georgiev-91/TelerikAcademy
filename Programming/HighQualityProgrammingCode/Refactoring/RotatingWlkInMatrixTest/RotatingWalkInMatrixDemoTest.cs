using RotatingWalkinMatrix;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RotatingWlkInMatrixTest
{
    
    
    /// <summary>
    ///This is a test class for RotatingWalkInMatrixDemoTest and is intended
    ///to contain all RotatingWalkInMatrixDemoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RotatingWalkInMatrixDemoTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GenerateRotatingMatrix
        ///</summary>
        [TestMethod()]
        public void GenerateRotatingMatrixTest()
        {
            int MatrixSize = 0; // TODO: Initialize to an appropriate value
            int[,] expected = null; // TODO: Initialize to an appropriate value
            int[,] actual;
            actual = RotatingWalkInMatrixDemo.GenerateRotatingMatrix(MatrixSize);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
