using System;
using System.Collections.Generic;
using System.Linq;

namespace HumanAbstraction
{
    class HumanAbstractionTest
    {
        public static void SortingStudentsByGrade(List<Student> students)
        {
            var sortedByGrade =
                from student in students
                orderby student.Grade ascending
                select student;

            foreach (var student in sortedByGrade)
            {
                Console.WriteLine(student);
            }
        }

        public static void SortingWorkersByMoneyPerHour(List<Worker> workers)
        {
            var sortedByMoneyPerHour = workers.OrderByDescending(worker => worker.MoneyPerHour());

            foreach (var worker in sortedByMoneyPerHour)
            {
                Console.WriteLine(worker);
            }
        }

        public static void SortHumansByName(List<Human> humans)
        {
            var sortedByName = humans.OrderBy(human => human.FirstName).ThenBy(human => human.LastName);
            foreach (var human in sortedByName)
            {
                Console.WriteLine(human);
            }
        }

        static void Main()
        {
            List<Student> students = new List<Student>(new[] 
            {
                new Student("Ivan", "Georgiev", 5.6),
                new Student("Petyr", "Popov", 2.6),
                new Student("Ivan", "Popiordanov", 3),
                new Student("Jivka", "Trendafilova", 4.52),
                new Student("Stoyan", "Lesev", 5.2),
                new Student("Stefan", "Bonchev", 4.4),
                new Student("Mariya", "Ivanova", 5),
                new Student("Lili", "Mihailova", 6),
                new Student("Stefan", "Georgiev", 2.53),
                new Student("Nedelina", "Shopova", 3.33),
                new Student("Spirdon", "Stamatov", 3.59)
            });

            List<Worker> workers = new List<Worker>(new[] 
            {
                new Worker("Stoqn", "Dimitrov", 45.32, 4),
                new Worker("Stefan", "Dinchev", 60.4, 12),
                new Worker("Liubomir", "Georgiev", 42.5, 3),
                new Worker("Preslava", "Milkova", 55.14, 2),
                new Worker("Mila", "Yaneva", 53.32, 6),
                new Worker("Petyr", "Dimitrov", 64.864, 7),
                new Worker("Aneliya", "Grueva", 56.54, 8),
                new Worker("Nikolai", "Canev", 65.13, 5),
                new Worker("Ivan", "Dimitrov", 63.58, 2),
                new Worker("Miroslava", "Peicheva", 68.85, 5),
                new Worker("Stamat", "Spiridonov", 45.05, 5)
            });

            List<Human> studentsToHumans = new List<Human>(students);
            List<Human> workesToHumans = new List<Human>(workers);
            List<Human> humans = new List<Human>(studentsToHumans.Concat(workesToHumans));

            SortingStudentsByGrade(students);
            Console.WriteLine();
            SortingWorkersByMoneyPerHour(workers);
            Console.WriteLine();
            SortHumansByName(humans);
        }
    }
}
