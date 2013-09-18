using System;

class AssingValue
{
    static void Main()
    {
        int? myInt = null;
        double? myDouble = null;
        Console.WriteLine("This is an integer with null value: " + myInt);
        Console.WriteLine("This is a double with null value: " + myDouble);
        myInt = 12;
        Console.WriteLine("This is the integer with 12 value: " + myInt);
        myDouble = 3.14;
        Console.WriteLine("This is the double with 3,14 value: " + myDouble);
    }
}
