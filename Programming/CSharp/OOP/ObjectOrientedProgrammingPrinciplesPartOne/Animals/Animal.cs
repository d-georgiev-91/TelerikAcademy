using System;
using System.Text;
namespace Animals
{
    public abstract class Animal
    {
        private Sex sex;
        private int age;
        private string name;

        public Animal(int age, Sex sex, string name)
        {
            this.Sex = sex;
            this.Age = age;
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public Sex Sex
        {
            get
            {
                return this.sex;
            }
            set
            {
                this.sex = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (age >= 0)
                {
                    this.age = value;
                }
                else
                {
                    throw new ArgumentException("Age cannot be negative");
                }
            }
        }

        public override string ToString()
        {
            StringBuilder printableAnimal = new StringBuilder();
            printableAnimal.AppendFormat("{0} {1} {2}", this.Name, this.age, this.sex);
            return printableAnimal.ToString();
        }
    }
}
