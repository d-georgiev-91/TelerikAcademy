using System;
using System.Linq;

namespace StudentsNames
{
    public static class AgeQuery
    {
        //4. Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.

        public static void AgeBetween(Student[] students, byte lowerAgeBound, byte upperAgeBound)
        {
            var firstNameBeforeLastStudent =
                from student in students
                where student.Age > lowerAgeBound && student.Age < upperAgeBound
                select student;
            foreach (var student in firstNameBeforeLastStudent)
            {
                Console.WriteLine(student);
            }
        }
    }
}
