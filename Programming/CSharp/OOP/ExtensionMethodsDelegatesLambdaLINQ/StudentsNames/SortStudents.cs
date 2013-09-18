using System;
using System.Linq;

namespace StudentsNames
{
    //5. Using the extension methods OrderBy() and ThenBy() with 
    //   lambda expressions sort the students by first 
    //   name and last name in descending order. Rewrite 
    //   the same with LINQ.

    public static class SortStudents
    {
        public static void SortStudentsWithOrderByAndThenBy(Student[] students)
        {
            var sorted = students.OrderByDescending(student => student.FirstName).ThenByDescending(student => student.LastName);
            foreach (var student in sorted)
            {
                Console.WriteLine(student);
            }
        }

        public static void SortStudentsWithLINQ(Student[] students)
        {
            var sorted =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;
            foreach (var student in sorted)
            {
                Console.WriteLine(student);
            }
        }
    }
}
