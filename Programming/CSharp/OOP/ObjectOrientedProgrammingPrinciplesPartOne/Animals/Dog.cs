using System;

namespace Animals
{
    public class Dog : Animal, ISound
    {
        private string kind;
        
        public Dog(string name, int age, Sex sex)
            :base(age, sex, name)
        {
            {
                this.Name = name;
                this.kind = this.GetType().ToString().Replace("Animals.", String.Empty);
            }
        }

        public void Sound()
        {
            Console.WriteLine("Waf, Waf! I'm a {0}!", this.kind);
        }
    }
}
