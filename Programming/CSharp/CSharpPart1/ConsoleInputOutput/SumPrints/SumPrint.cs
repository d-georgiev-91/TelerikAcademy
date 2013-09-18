using System;

class SumPrint
{
    static void Main()
    {   
        Console.Write("Input n: ");
        int n = int.Parse(Console.ReadLine());
        int sum = 0;
        for (int i = 1; i <= n; i++)
        {
            Console.Write("Input a integer number: ");
            sum += int.Parse(Console.ReadLine());
        }
        Console.WriteLine("The sum of all integers you've input is {0}.",sum);
    }
}

