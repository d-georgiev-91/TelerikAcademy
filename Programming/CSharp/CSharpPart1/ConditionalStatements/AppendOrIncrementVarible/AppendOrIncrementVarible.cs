using System;

class AppendOrIncrementVarible
{
    static void Main()
    {
        Console.WriteLine("Input a varible tipe which you would like to input:\n(1).Int\n(2).Double\n(3).String");
        byte choice = byte.Parse(Console.ReadLine());
        switch (choice)
	    {
            case 1:
                Console.Write("Input integer: ");
                int myInt = int.Parse(Console.ReadLine());
                myInt++;
                Console.WriteLine(myInt);
                break;
            case 2:
                Console.Write("Input double: ");
                double myDouble = double.Parse(Console.ReadLine());
                myDouble++;
                Console.WriteLine(myDouble);
                break;
            case 3:
                Console.Write("Input string: ");
                string myString = Console.ReadLine();
                myString += '*';
                Console.WriteLine(myString);
                break;
            default:
                Console.WriteLine("Invalid input.");
                break;
	    }
    }
}