namespace HumanAbstraction
{
    using System;
    using System.Linq;

    public class Student : Human
    {
        private double grade;

        public Student(string firstName, string lastName, double grade) : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public double Grade
        {
            get
            {
                return this.grade;
            }
            set
            {
                if (value < 0 || value > 6)
                {
                    throw new ArgumentException("Invalid grade");
                }
                else
                {
                    this.grade = value;
                }
            }
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", this.FirstName, this.LastName, this.Grade);
        }
    }
}