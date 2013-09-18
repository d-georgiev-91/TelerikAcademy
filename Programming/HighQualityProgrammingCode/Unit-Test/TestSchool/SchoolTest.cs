using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;

namespace TestSchool
{
    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAddDuplicateCourse()
        {
            Course course = new Course("CSS");
            School.School school = new School.School();
            school.AddCourse(course);
            school.AddCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDuplicateStudentUniqueNumber()
        {
            Course course = new Course("CSS");
            
            Student ivan = new Student("Ivan", 10006);
            Student pesho = new Student("Pesho", 10006);

            School.School school = new School.School();
            school.AddStudent(ivan);
            school.AddStudent(pesho);
        }
    }
}
