using System;

class PrintSequenceMembers
{
    static void Main()
    {
        int sing = 1;
        Console.WriteLine("The first 10 members of the sequence:\n\"2, -3, 4, -5, 6, -7, ...\" are: ");
        for (int i = 2; i < 12; i++)
        {
            if(i==11)
                Console.WriteLine(i*sing + ".");
            else
                Console.Write(i*sing + ", ");
            sing *= -1;
        }
    }
}
