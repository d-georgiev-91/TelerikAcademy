using System;

class StringToObjectToString
{
    static void Main(string[] args)
    {
        string firstString = "Hello";
        string secondString = "World";
        object stringConcatenationInObject = (object)(firstString + " " + secondString);
        string thirdString = (string)stringConcatenationInObject;
    }
}

