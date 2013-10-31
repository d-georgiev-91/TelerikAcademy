namespace Animals
{
    using System;
   
    public class Tomcat : Cat, ISound
    {
        string kind;

        public Tomcat(string name, int age) : base(name, age, Sex.Male)
        {
            {
                this.kind = this.GetType().ToString().Replace("Animals.", String.Empty);
            }
        }
        
        public string Kind
        {
            get
            {
                return this.kind;
            }
        }

        public void Sound()
        {
            Console.WriteLine("Meow, Meow! I'm a {0}!", this.kind);
        }
    }
}