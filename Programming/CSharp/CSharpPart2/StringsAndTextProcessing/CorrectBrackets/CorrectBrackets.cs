using System;

namespace CorrectBrackets
{
    class CorrectBrackets
    {
        /*
         *  3. Write a program to check if in a given expression the brackets are put correctly.
            Example of correct expression: ((a+b)/5-d).
            Example of incorrect expression: )(a+b)).
         */
        static void Main()
        {
            Console.Write("Input expression: ");
            string expression = Console.ReadLine();
            int bracketsState = 0;
            foreach (var character in  expression)
            {
                if (character == '(')
                {
                    bracketsState++;
                }
                else if (character == ')')
                {
                    bracketsState--;
                }
                if (bracketsState<0)
                {
                    break;
                }
            }
            if (bracketsState == 0)
            {
                Console.WriteLine("All brackets are correct!");   
            }
            else
            {
                Console.WriteLine("Incorrect expression!");   
            }
        }
    }
}
