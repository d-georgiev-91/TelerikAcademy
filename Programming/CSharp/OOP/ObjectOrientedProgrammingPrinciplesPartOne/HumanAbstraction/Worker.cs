using System;

namespace HumanAbstraction
{
    public class Worker : Human
    {
        private double weekSalary;
        private int workHoursPerDay;

        public Worker(string firstName, string lastName, double weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public double WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                if (value > 0 || value < 24)
                {
                    this.workHoursPerDay = value;
                }
                else
                {
                    throw new ArgumentException("Invalid hours.");
                }
            }
        }

        public double MoneyPerHour()
        {
            return this.WeekSalary / 7 / this.WorkHoursPerDay;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2:C2} per week, {3} hours workday", this.FirstName, this.LastName, this.WeekSalary, this.WorkHoursPerDay);
        }
    }
}
