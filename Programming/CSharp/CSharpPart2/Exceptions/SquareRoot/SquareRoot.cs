using System;

namespace SquareRoot
{
    class SquareRoot
    {
        /* 1. Write a program that reads an integer number and calculates and 
         * prints its square root. If the number is invalid or negative, print 
         * "Invalid number". In all cases finally print "Good bye". Use try-catch-finally. */
        static void Main()
        {
            int number;
            try
            {
                Console.Write("Input a number: ");
                number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                Console.WriteLine("The square root of {0} is {1:0.##}.", number, Math.Sqrt(number));
            }
            catch (FormatException)
            {
                Console.Error.WriteLine("Invalid number!");
            }
            catch (OverflowException)
            {
                Console.Error.WriteLine("The number is too big!");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.Error.WriteLine("Invalid number!");
            }
            finally
            {
                Console.WriteLine("Good bye!");
            }
        }
    }
}
