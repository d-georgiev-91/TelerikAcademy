using System;

class BiggestIntegerOfThree
{
    static void Main()
    {
        int firstInteger, secondInteger, thirdInteger;
        Console.Write("Input the first integer: ");
        firstInteger = int.Parse(Console.ReadLine());
        Console.Write("Input the second integer: ");
        secondInteger = int.Parse(Console.ReadLine());
        Console.Write("Input the third integer: ");
        thirdInteger = int.Parse(Console.ReadLine());
        if (firstInteger > secondInteger)
        {
            if (firstInteger > thirdInteger)
            {
                Console.WriteLine("{0} is the biggest integer", firstInteger);
            }
            else
            {
                Console.WriteLine("{0} is the biggest integer", thirdInteger);
            }
        }
        else
        {
            if (secondInteger > thirdInteger)
            {
                Console.WriteLine("{0} is the biggest integer", secondInteger);
            }
            else
            {
                Console.WriteLine("{0} is the biggest integer", thirdInteger);
            }
        }
    }
}
