using System;
using System.Linq;

namespace StudentsNames
{
    public static class FirstNameBeforeLastQuery
    {
        //3. Write a method that from a given array of students finds
        //   all students whose first name is before 
        //   its last name alphabetically. Use LINQ query operators.

        public static void FirstNameBeforeLast(Student[] students)
        {
            var firstNameBeforeLastStudent =
                from student in students
                where student.FirstName.CompareTo(student.LastName) == -1
                select student;

            foreach (var student in firstNameBeforeLastStudent)
            {
                Console.WriteLine(student);
            }
        }
    }
}
