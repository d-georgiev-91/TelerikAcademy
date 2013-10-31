namespace GenericList
{
    using System;
    using System.Collections.Generic;

    class TestList
    {
        static void Main()
        {
            Console.WriteLine("intList: ");
            GenericList<int> intList = new GenericList<int>(1);
            intList.Add(5);
            intList.Add(315);
            intList.Add(515);
            intList.Add(4);
            intList[0] = 1;
            Console.WriteLine(intList);
            intList.RemoveItemAtIndex(3);
            Console.WriteLine(intList);
            intList.InsertItemAtIndex(15, 3);
            Console.WriteLine(intList);
            Console.WriteLine(intList);
            Console.WriteLine(intList);
            Console.WriteLine(intList.FindItemByValue(5));
            Console.WriteLine();

            Console.WriteLine("\ndoubleList: ");
            GenericList<double> doubleList = new GenericList<double>(0);
            doubleList.Add(5);
            doubleList.Add(315);
            doubleList.Add(515);
            doubleList.Add(4);
            doubleList[0] = 1;
            Console.WriteLine(doubleList.ToString());
            doubleList.RemoveItemAtIndex(3);
            Console.WriteLine(doubleList.ToString());
            doubleList.InsertItemAtIndex(15, 3);
            Console.WriteLine(doubleList.ToString());
            Console.WriteLine(doubleList.Max());
            Console.WriteLine(doubleList.Min());

            Console.WriteLine("\npeople list: ");
            GenericList<Person> people = new GenericList<Person>();

            for (int i = 0; i < 10; i++)
            {
                people.Add(new Person("Person #" + (i + 1)));
            }

            people[0] = new Person("Pesho");
            Console.WriteLine(people);

            Console.WriteLine(people.FindItemByValue(new Person("Pesho")));
        }
    }
}