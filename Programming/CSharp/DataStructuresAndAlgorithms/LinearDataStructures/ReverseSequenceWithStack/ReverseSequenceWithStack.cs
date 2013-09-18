// 2. Write a program that reads N integers from the console 
// and reverses them using a stack. Use the Stack<int> class.

namespace ReverseSequenceWithStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ReverseSequenceWithStack
    {
        static void Main()
        {
            Console.Write("Input a nubmers count: ");
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();
            int number = 0;

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter a number: ");
                number = int.Parse(Console.ReadLine());
                stack.Push(number);    
            }
            var output = string.Join(", ", stack);

            Console.WriteLine("The numbers in reverse are: {0}", output);
        }
    }
}
