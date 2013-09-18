using System;

namespace PersonGenerator
{
    //Task 2
    class PersonGenerator
    {
        enum Sex { Male, Female };

        class Person
        {
            public Sex Sex { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public void CreatePersonWithSexDeterminantByAge(int age)
        {
            Person person = new Person();
            person.Age = age;
            if (age % 2 == 0)
            {
                person.Name = "Ivan";
                person.Sex = Sex.Male;
            }
            else
            {
                person.Name = "Maria";
                person.Sex = Sex.Female;
            }
        }
    }
}
