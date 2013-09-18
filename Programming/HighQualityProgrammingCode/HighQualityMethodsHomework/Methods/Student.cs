using System;

namespace Methods
{
    class Student
    {
        public enum Results
        {
            None,
            Low,
            Average,
            High
        };
        
        private string firstName;
        private string lastName;
        private string birthCity;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (value == null || value == String.Empty)
                {
                    throw new ArgumentException("First name cannot be empty!");
                }
                else
                {
                    this.firstName = value;
                }
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (value == null || value == String.Empty)
                {
                    throw new ArgumentException("Last name cannot be empty!");
                }
                else
                {
                    this.lastName = value;
                }
            }
        }

        public DateTime BirthDate { get; private set; }

        public string BirthCity
        {
            get
            {
                return this.birthCity;
            }
            private set
            {
                if (value == null || value == String.Empty)
                {
                    throw new ArgumentException("The name of the birth city cannot be empty!");
                }
                else
                {
                    this.birthCity = value;
                }
            }
        }

        public string Ocuppation { get; set; }

        public Results StudentResults { get; private set; }

        public Student(string firstName, string lastName, DateTime birthDate, string birthCity,
            string ocuppation = null, Results results = Results.None)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.BirthCity = birthCity;
            this.Ocuppation = ocuppation;
            this.StudentResults = results;
        }

        public bool IsOlderThan(Student other)
        {
            if (other == null)
            {
                throw new InvalidOperationException("Student cannot be compared with nullable student!");
            }
            else
            {
                DateTime firstDate = this.BirthDate;
                DateTime secondDate = other.BirthDate;

                return firstDate > secondDate;
            }
        }
    }
}