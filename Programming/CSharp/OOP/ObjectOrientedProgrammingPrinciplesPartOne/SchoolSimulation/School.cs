using System;
using System.Collections.Generic;

namespace SchoolSimulation
{
    public class School
    {
        private List<Class> classes;
        private int numberOfClasses;

        public School()
        {
            this.Classes = new List<Class>();
            this.NumberOfClasses = 0;
        }

        public School(int numberOfClasses)
        {
            this.classes = new List<Class>(numberOfClasses);
            this.NumberOfClasses = 0;
        }

        public List<Class> Classes
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

        public int NumberOfClasses
        {
            get
            {
                return this.numberOfClasses;
            }
            set
            {
                this.numberOfClasses = value;
            }
        }

        public void AddClass(Class classToAdd)
        {
            this.NumberOfClasses++;
            this.Classes.Add(classToAdd);
        }

        public void SchoolInfo()
        {
            foreach (var c in Classes)
            {
                Console.WriteLine(c.ToString());
            }
        }
    }
}