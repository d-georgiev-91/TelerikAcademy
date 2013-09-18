using System;

namespace SchoolSimulation
{
    public class Person
    {
        private string name;
    
        protected Person(string name)
        {
            this.name = name;
        }

        protected string Name
        {
            get
            {
                return this.name;
            }
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
