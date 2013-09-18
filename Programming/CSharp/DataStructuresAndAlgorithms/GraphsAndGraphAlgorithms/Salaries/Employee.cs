namespace Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Employee
    {
        public Employee(int id)
        {
            this.Id = id;
            //this.Salarie = 1;
            this.Employers = new List<Employee>();
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public int Id { get; set; }

        public long Salarie { get; set; }

        public List<Employee> Employers { get; set; }
    }
}