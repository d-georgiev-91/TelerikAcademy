namespace ReadStudents
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Wintellect.PowerCollections;
    
    public class ReadStudents
    {
        static void Main()
        {
            var students = File.ReadAllLines("..\\..\\students.txt");

            var courseStudents = new SortedDictionary<string, OrderedBag<Student>>();

            foreach (var student in students)
            {
                AddToCourse(student, courseStudents);
            }

            foreach (var course in courseStudents.Keys)
            {
                Console.WriteLine("{0} -> {1}", course, string.Join(", ", courseStudents[course]));
            }
        }

        private static void AddToCourse(string student, SortedDictionary<string, OrderedBag<Student>> courseStudents)
        {
            int indexOfFirstDelimiter = student.IndexOf("|");
            int indexOfLastDelimiter = student.LastIndexOf("|");
            string firstName = student.Substring(0, indexOfFirstDelimiter).Trim();
            string lastName = student.Substring(indexOfFirstDelimiter + 1, indexOfLastDelimiter - indexOfFirstDelimiter - 1).Trim();
            string course = student.Substring(indexOfLastDelimiter + 1).Trim();
                  
            if (courseStudents.ContainsKey(course))
            {
                courseStudents[course].Add(new Student(firstName, lastName));
            }
            else
            {
                courseStudents.Add(course, new OrderedBag<Student>() { new Student(firstName, lastName) });
            }
        }
    }
}