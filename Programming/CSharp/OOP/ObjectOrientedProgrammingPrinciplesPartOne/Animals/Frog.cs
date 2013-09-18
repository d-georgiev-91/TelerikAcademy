using System;

namespace Animals
{
    public class Frog : Animal, ISound
    {
        private string kind;

        public Frog(string name, int age, Sex sex)
            : base(age, sex, name)
        {
            this.Name = name;
            this.kind = this.GetType().ToString().Replace("Animals.", String.Empty);
        }

        public string Kind
        {
            get
            {
                return this.kind;
            }
            set
            {
                this.kind = value;
            }
        }
        public void Sound()
        {
            Console.WriteLine("Ribbit, ribbit! I'm a {0}!", this.kind);
        }
    }
}
