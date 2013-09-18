using System;

namespace HelloUser
{
    class HelloUser
    {
        /*
         * 1. Write a method that asks the user for his name and prints “Hello, <name>” 
         * (for example, “Hello, Peter!”). Write a program to test this method.
         */
        static void Hello()
        {
            Console.Write("Write your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Hello, {0}!", name);
        }
        static void Main()
        {
            Hello();            
        }
    }
}
