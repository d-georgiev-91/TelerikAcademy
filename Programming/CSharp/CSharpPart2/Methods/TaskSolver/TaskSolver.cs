using System;

namespace TaskSolver
{
    class TaskSolver
    {
        /* 13. Write methods to calculate minimum, maximum, average, sum and 
         * product of given set of integer numbers. Use variable number of arguments. */
        static void DigitReverser()
        {
            int number = -1;
            while (number < 0)
            {
                Console.Write("Input a non-negative number: ");
                number = int.Parse(Console.ReadLine());
            }
            int reversedNumber = 0;
            int reminder;
            while (number != 0)
            {
                reminder = number % 10;
                reversedNumber = reversedNumber * 10 + reminder;
                number = number / 10;
            }
            Console.WriteLine("The number reversed is {0}.",reversedNumber);
        }
        static int [] InputSequnece()
        {
            int length = 0;
            while (length <= 0)
            {   
                Console.Write("Input the sequnece legnth (the sequence must cointain at least 1 element): ");
                length = int.Parse(Console.ReadLine());
            }
            int [] sequence = new int [length];
            for (int i = 0; i < length; i++)
			{
                Console.Write("Input element for sequence: ");
                sequence[i] = int.Parse(Console.ReadLine());
			}
            return sequence;
        }
        static void AverageOfSequence()
        {
            int [] sequence = InputSequnece();
            double average = 0;
            for (int i = 0; i < sequence.Length; i++)
            {
                average += sequence[i];
            }
            average /= (double)(sequence.Length);
            Console.WriteLine("The average of the sequence is {0:0.##}.", average);
        }
        static void LinearEquasion()
        {
            double a = 0;
            while (a == 0)
            {
                Console.Write("Input non-zero a: ");
                a = double.Parse(Console.ReadLine());
            }
            Console.Write("Input b: ");
            double b = double.Parse(Console.ReadLine());
            double result = -b/a;
            Console.WriteLine("The result of the equation is {0}x + {1} = 0 is {2:0.##}", a, b, result);
        }
        static void Main()
        {
            int choice = 0;
            while (choice != 1 && choice != 2 && choice != 3)
            {
                Console.WriteLine("Choose your option");
                Console.WriteLine("(1). Reverse a number.");
                Console.WriteLine("(2). Calculate the average of sequence.");
                Console.WriteLine("(3). Solve linear equation.");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        DigitReverser();
                        break;
                    case 2:
                        AverageOfSequence();
                        break;
                    case 3:
                        LinearEquasion();
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
