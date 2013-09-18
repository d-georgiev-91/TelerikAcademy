using System;

namespace NumberInRange
{
    class NumberInRange
    {
        static int ReadNumber(int start, int end)
        {
            Console.Write("Input a number in range [{0}, {1}]: ", start, end);
            int number;

            number = int.Parse(Console.ReadLine());
            if (number < start  || number > end)
            {
                throw new ArgumentOutOfRangeException();
            }
            return number;
        }
        static void Main()
        {
            int min = 1;
            int max = 100;
            Console.WriteLine("You have to input 10 integers.");
            for (int i = 1; i <= 10; i++)
            {
                try
                {
                    min = ReadNumber(min, max);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.Error.WriteLine("Number not in range!");
                }
                catch (FormatException)
                {
                    Console.Error.WriteLine("Invalid number!");
                }
                catch (OverflowException)
                {
                    Console.Error.WriteLine("Invalid signed 32-bit number");
                }
            }
        }
    }
}
