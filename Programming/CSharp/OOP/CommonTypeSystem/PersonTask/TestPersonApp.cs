using System;

namespace PersonTask
{
    class TestPersonApp
    {
        static void Main()
        {
            Person ivan = new Person("Ivan");
            Person pesho = new Person("Pesho", 15);
            Console.WriteLine(ivan);
            Console.WriteLine(pesho);
        }
    }
}
