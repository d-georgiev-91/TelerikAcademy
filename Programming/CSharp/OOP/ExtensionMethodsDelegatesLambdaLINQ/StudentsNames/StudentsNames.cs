using System;
using System.Linq;

namespace StudentsNames
{
    class StudentsNames
    {
        static void Main()
        {
            Student[] students = {
               new Student("Pesho", "Ivanov", 23),  
               new Student("Ivan", "Popov", 25),
               new Student("Stoqn", "Petrov", 34),
               new Student("Galina", "Stefanova", 19),
               new Student("Petq", "Naidenova" , 52)
            };
            Console.WriteLine("3.----------------------------");
            FirstNameBeforeLastQuery.FirstNameBeforeLast(students);
            Console.WriteLine("4.----------------------------");
            AgeQuery.AgeBetween(students, 18, 24);
            Console.WriteLine("5.----------------------------");
            SortStudents.SortStudentsWithOrderByAndThenBy(students);
            Console.WriteLine("------------------------------");
            SortStudents.SortStudentsWithLINQ(students);
        }
    }
}
