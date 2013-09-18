using System;

namespace ComplexMathOperationsComparsion
{
    class ComplexMathOperationsComparsion
    {
        static void Main()
        {
            //SquareRootComparsion();
            //NaturalLogarithmComparsion();
            SinComparsion();
        }

        public static void SquareRootComparsion()
        {
            Console.WriteLine("Square root\ncomaprsion for...");
            Console.WriteLine("----------------");

            Console.WriteLine("Float");
            float numberAsFloat = 20000f;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                double result = Math.Sqrt(numberAsFloat);
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Double");
            double numberAsDouble = 20000.0;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                double result = Math.Sqrt(numberAsDouble);
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Decimal");
            decimal numberAsDecimal = 20000.0m;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                double result = Math.Sqrt((double)numberAsDecimal);
            });
            Console.WriteLine("----------------");
            Console.WriteLine();
        }

        public static void NaturalLogarithmComparsion()
        {
            Console.WriteLine("Natural logarithm\ncomaprsion for...");
            Console.WriteLine("----------------");

            Console.WriteLine("Float");
            float numberAsFloat = 20000f;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                double result = Math.Log(numberAsFloat);
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Double");
            double numberAsDouble = 20000.0;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                double result = Math.Log(numberAsDouble);
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Decimal");
            decimal numberAsDecimal = 20000.0m;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                double result = Math.Log((double)numberAsDecimal);
            });
            Console.WriteLine("----------------");
            Console.WriteLine();
        }

        public static void SinComparsion()
        {
            Console.WriteLine("Sin comaprsion for...");
            Console.WriteLine("----------------");

            Console.WriteLine("Float");
            float numberAsFloat = 20000f;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                double result = Math.Sin(numberAsFloat);
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Double");
            double numberAsDouble = 20000.0;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                double result = Math.Sin(numberAsDouble);
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Decimal");
            decimal numberAsDecimal = 20000.0m;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                double result = Math.Sin((double)numberAsDecimal);
            });
            Console.WriteLine("----------------");
            Console.WriteLine();
        }
    }
}
