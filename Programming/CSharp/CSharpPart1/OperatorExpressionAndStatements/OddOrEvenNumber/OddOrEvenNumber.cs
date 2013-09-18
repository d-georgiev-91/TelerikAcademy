using System;
class OddOrEvenNumber
{
    static void Main()
    {
        Console.Write("Please input your integer: ");
        int myInt = int.Parse(Console.ReadLine());
        if(myInt%2!=0) 
            Console.WriteLine("The given number is odd."); 
        else
            Console.WriteLine("The given number is even.");
    }
}

