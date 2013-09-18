using System;

namespace Animals
{
    public class Kitten : Cat, ISound
    {
        private string kind;
        public Kitten(string name, int age)
            : base(name, age, Sex.Female)
        {
            {
                this.kind = this.GetType().ToString().Replace("Animals.", String.Empty);
            }
        }
        
        public void Sound()
        {
            Console.WriteLine("Meow, Meow! I'm a {0}!", this.kind);
        }
    }
}
