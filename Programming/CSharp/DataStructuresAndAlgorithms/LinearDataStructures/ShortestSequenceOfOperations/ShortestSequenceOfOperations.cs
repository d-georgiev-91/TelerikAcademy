/** 
* 10.* We are given numbers N and M and the following operations:
* a) N = N+1
* b) N = N+2
* c) N = N*2
* Write a program that finds the shortest sequence of operations from the 
* list above that starts from N and finishes in M. Hint: use a queue.
* Example: N = 5, M = 16
* Sequence: 5 -> 7 -> 8 -> 16
*/

namespace ShortestSequenceOfOperations
{
    using System;
    using System.Collections.Generic;

    public static class ShortestSequenceOfOperations
    {
        static void Main()
        {
            Console.Write("Input N: ");
            int beginning = int.Parse(Console.ReadLine());
            Console.Write("Input M: ");
            int end = int.Parse(Console.ReadLine());
            Console.WriteLine(SequenceAsString(beginning, end));
        }

        public static string SequenceAsString(int beginning, int end)
        {
            Stack<int> sequence = new Stack<int>();
            sequence.Push(end);
            int currentSquenceMember = end;

            while (currentSquenceMember != beginning)
            {
                if (currentSquenceMember > 0 && currentSquenceMember / 2 >= beginning)
                {
                    sequence.Push(currentSquenceMember / 2);
                }
                else if (currentSquenceMember - 2 >= beginning)
                {
                    sequence.Push(currentSquenceMember - 2);
                }
                else
                {
                    sequence.Push(currentSquenceMember - 1);
                }
                currentSquenceMember = sequence.Peek();
            }

            string sequenceAsString = string.Join(" -> ", sequence);

            return sequenceAsString;
        }
    }
}