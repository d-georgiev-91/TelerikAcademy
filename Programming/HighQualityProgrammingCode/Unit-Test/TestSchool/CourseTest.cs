using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;

namespace TestSchool
{
    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void TestCourseName()
        {
            string name = "css";
            Course course = new Course(name);
            Assert.AreEqual(name, course.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseNullStringName()
        {
            string name = null;
            Course course = new Course(name);
            Assert.AreEqual(name, course.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseEmptyStringName()
        {
            string name = String.Empty;
            Course course = new Course(name);
            Assert.AreEqual(name, course.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestCourseAddForNullStudent()
        {
            Student ivan = null;
            Course course = new Course("CSS");
            course.AddStudent(ivan);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestCourseDuplicationStudentAdd()
        {
            Student ivan = new Student("Ivan", 77777);
            Course course = new Course("CSS");
            course.AddStudent(ivan);
            course.AddStudent(ivan);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestCourseAddStudentOutOfCapacity()
        {
            Course course = new Course("CSS");
            for (int i = 1; i <= 31; i++)
            {
                Student student = new Student("Student #" + i, 10000 + i);
                course.AddStudent(student);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestCourseRemoveStudentFromEmptyCourse()
        {
            Course course = new Course("CSS");
            Student pesho = new Student("Pesho", 12415);
            course.RemoveStudent(pesho);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestCourseRemoveStudentOfNonExsistingStudent()
        {
            Course course = new Course("CSS");
            for (int i = 1; i <= 30; i++)
            {
                Student student = new Student("Student #" + i, 10000 + i);
                course.AddStudent(student);
            }

            Student pesho = new Student("Pesho", 12415);
            course.RemoveStudent(pesho);
        }
    }
}
