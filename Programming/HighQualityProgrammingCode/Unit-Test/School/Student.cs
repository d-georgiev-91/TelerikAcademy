using System;

namespace School
{
    public class Student
    {
        private int uniqueNumber;

        private string name;

        public int UniqueNumber
        {
            get
            {
                return uniqueNumber;
            }
            set
            {
                if (10000 <= value && value <= 99999)
                {
                    uniqueNumber = value;
                }
                else
                {
                    throw new ArgumentException("Invalid unique number! Unieque number must be in range [10 000, 99 999].");
                }
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException("Name cannot be empty!");
                }
            }
        }

        public Student(string name, int uniqueNumber)
        {
            this.Name = name;
            this.UniqueNumber = uniqueNumber;
        }
    }
}