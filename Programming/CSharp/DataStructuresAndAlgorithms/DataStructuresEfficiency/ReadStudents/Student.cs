namespace ReadStudents
{
    using System;

    public class Student : IComparable
    {
        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int CompareTo(object obj)
        {
            Student student = obj as Student;

            if (this.LastName.CompareTo(student.LastName) != 0)
            {
                return this.LastName.CompareTo(student.LastName);
            }

            return this.FirstName.CompareTo(student.FirstName);

        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
    }
}