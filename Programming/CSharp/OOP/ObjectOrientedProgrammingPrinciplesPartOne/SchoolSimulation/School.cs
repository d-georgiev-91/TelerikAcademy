using System;
using System.Collections.Generic;

namespace SchoolSimulation
{
    public class School
    {
        private ICollection<Class> classes;

        public School()
        {
            this.Classes = new List<Class>();
        }

        public School(int numberOfClasses)
        {
            this.classes = new List<Class>(numberOfClasses);
        }

        public ICollection<Class> Classes
        {
            get
            {
                return this.classes;
            }
            set
            {
                this.classes = value;
            }
        }

        public void SchoolInfo()
        {
            foreach (var @class in Classes)
            {
                Console.WriteLine(@class.ToString());
            }
        }
    }
}