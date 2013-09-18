using System;

namespace ConsolePrinter
{
    // Task 1
    class ConsolePrinter
    {
        const int MaxCount = 6;

        public static void Input()
        {
            ConsolePrinter.BoolPrinter boolPrinter = new ConsolePrinter.BoolPrinter();
            boolPrinter.PrintValue(true);
        }

        class BoolPrinter
        {
            public void PrintValue(bool expression)
            {
                string expressionValue = expression.ToString();
                Console.WriteLine(expressionValue);
            }
        }
    }
}
