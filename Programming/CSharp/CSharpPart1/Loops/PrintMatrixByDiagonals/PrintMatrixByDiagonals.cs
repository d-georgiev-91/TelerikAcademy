using System;

class PrintMatrixByDiagonals
{
    static void Main()
    {
        byte n = 0;
        byte value = 1;
        while (n < 1 || n > 20)
        {
            Console.Write("Input positive N less than 20: ");
            n = byte.Parse(Console.ReadLine());
        }
        for (byte rows = 1; rows <= n; rows++)
        {
            value = rows;
            for (byte colums = 1; colums <= n; colums++)
            {
                if (value < 10)
                {
                    Console.Write(value + "  ");
                }
                else
                {
                    Console.Write(value + " ");
                }
                value++;
            }
            Console.WriteLine();
        }
    }
}