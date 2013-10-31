namespace GenericList
{
    using System;
    
    public class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public override bool Equals(object obj)
        {
            var person = obj as Person;
            
            if (person == null)
            {
                throw new ArgumentException("Object must be Person");
            }
            
            return this.Name == person.Name;
        }
    }
}