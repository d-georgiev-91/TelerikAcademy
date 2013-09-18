using System;
using System.Text;

namespace StudentsNames
{
    public struct Student
    {
        private string firstName;
        private string lastName;
        private byte age;

        public Student(string firstName, string lastName, byte age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public byte Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("First name: {0}\nLast name: {1}\nAge: {2}\n", FirstName, LastName, Age);
            return result.ToString();
        }
    }
}
