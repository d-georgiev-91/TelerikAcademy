using System;

namespace SchoolSimulation
{
    public abstract class Person
    {
        private string name;
    
        protected Person(string name)
        {
            this.name = name;
        }

        public string Name
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
