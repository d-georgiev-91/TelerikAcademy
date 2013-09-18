using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;

namespace TestSchool
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNameNullValue()
        {
            string name = null;
            int uniqueNumber = 100002;
            Student student = new Student(name, uniqueNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNameEmptyValue()
        {
            string name = String.Empty;
            int uniqueNumber = 100002;
            Student student = new Student(name, uniqueNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUniqueNumberBellowRange()
        {
            string name = "Pesho";
            int uniqueNumber = 3002;
            Student student = new Student(name, uniqueNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUniqueNumberOverRange()
        {
            string name = "Pesho";
            int uniqueNumber = 5466540;
            Student student = new Student(name, uniqueNumber);
        }

        [TestMethod]
        public void TestUniqueNumberInRange()
        {
            string name = "Pesho";
            int uniqueNumber = 12345;
            Student student = new Student(name, uniqueNumber);
            Assert.AreEqual(uniqueNumber, student.UniqueNumber);
        }
    }
}
