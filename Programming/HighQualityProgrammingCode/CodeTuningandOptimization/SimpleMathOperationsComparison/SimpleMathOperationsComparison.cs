using System;

namespace SimpleMathOperationsComparison
{
    class SimpleMathOperationsComparison
    {
        static void Main()
        {
            AddComparsion();
            //SubstractComparsion();
            //IncrementComparsion();
            //MultiplyComparsion();
            //DivisionComparsion();
            //ModuleDivisionComparsion();
        }
  
        public static void AddComparsion()
        {
            Console.WriteLine("Add for... ");
            Console.WriteLine("----------------");

            Console.WriteLine("Integer");
            int aAsInt = 20000, bAsInt = 53230;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                int result = aAsInt + bAsInt;
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Long");
            long aAsLong = 20000l, bAsLong = 53230l;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                long result = aAsLong + bAsLong;
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Float");
            float aAsFloat = 20000f, bAsFloat = 53230f;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                float result = aAsFloat + bAsFloat;
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Double");
            double aAsDouble = 20000.0, bAsDouble = 53230.0;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                double result = aAsDouble + bAsDouble;
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Decimal");
            decimal aAsDecimal = 20000.0m, bAsDecimal = 53230.0m;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                decimal result = aAsDecimal + bAsDecimal;
            });
            Console.WriteLine("----------------");
            Console.WriteLine();
        }

        public static void SubstractComparsion()
        {
            Console.WriteLine("Substract for... ");
            Console.WriteLine("----------------");

            Console.WriteLine("Integer");
            int aAsInt = 20000, bAsInt = 53230;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                int result = aAsInt - bAsInt;
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Long");
            long aAsLong = 20000l, bAsLong = 53230l;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                long result = aAsLong - bAsLong;
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Float");
            float aAsFloat = 20000f, bAsFloat = 53230f;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                float result = aAsFloat - bAsFloat;
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Double");
            double aAsDouble = 20000.0, bAsDouble = 53230.0;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                double result = aAsDouble - bAsDouble;
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Decimal");
            decimal aAsDecimal = 20000.0m, bAsDecimal = 53230.0m;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                decimal result = aAsDecimal - bAsDecimal;
            });
            Console.WriteLine("----------------");
            Console.WriteLine();
        }

        public static void IncrementComparsion()
        {
            Console.WriteLine("Increment for... ");
            Console.WriteLine("----------------");

            Console.WriteLine("Integer");
            int aAsInt = 20000;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                aAsInt++;
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Long");
            long aAsLong = 20000l;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                aAsLong++;
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Float");
            float aAsFloat = 20000f;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                aAsFloat++;
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Double");
            double aAsDouble = 20000.0;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                aAsDouble++;
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Decimal");
            decimal aAsDecimal = 20000.0m;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                aAsDecimal++;
            });
            Console.WriteLine("----------------");
            Console.WriteLine();
        }

        public static void MultiplyComparsion()
        {
            Console.WriteLine("Multiply for... ");
            Console.WriteLine("----------------");

            Console.WriteLine("Integer");
            int aAsInt = 20000, bAsInt = 53230;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                int result = aAsInt * bAsInt;
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Long");
            long aAsLong = 20000l, bAsLong = 53230l;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                long result = aAsLong * bAsLong;
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Float");
            float aAsFloat = 20000f, bAsFloat = 53230f;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                float result = aAsFloat * bAsFloat;
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Double");
            double aAsDouble = 20000.0, bAsDouble = 53230.0;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                double result = aAsDouble * bAsDouble;
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Decimal");
            decimal aAsDecimal = 20000.0m, bAsDecimal = 53230.0m;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                decimal result = aAsDecimal * bAsDecimal;
            });
            Console.WriteLine("----------------");
            Console.WriteLine();
        }

        public static void DivisionComparsion()
        {
            Console.WriteLine("Division for... ");
            Console.WriteLine("----------------");

            Console.WriteLine("Integer");
            int aAsInt = 20000, bAsInt = 53230;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                int result = aAsInt / bAsInt;
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Long");
            long aAsLong = 20000l, bAsLong = 53230l;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                long result = aAsLong / bAsLong;
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Float");
            float aAsFloat = 20000f, bAsFloat = 53230f;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                float result = aAsFloat / bAsFloat;
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Double");
            double aAsDouble = 20000.0, bAsDouble = 53230.0;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                double result = aAsDouble / bAsDouble;
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Decimal");
            decimal aAsDecimal = 20000.0m, bAsDecimal = 53230.0m;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                decimal result = aAsDecimal / bAsDecimal;
            });
            Console.WriteLine("----------------");
            Console.WriteLine();
        }

        public static void ModuleDivisionComparsion()
        {
            Console.WriteLine("Module division for... ");
            Console.WriteLine("----------------");

            Console.WriteLine("Integer");
            int aAsInt = 20000, bAsInt = 53230;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                int result = aAsInt % bAsInt;
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Long");
            long aAsLong = 20000l, bAsLong = 53230l;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                long result = aAsLong % bAsLong;
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Float");
            float aAsFloat = 20000f, bAsFloat = 53230f;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                float result = aAsFloat % bAsFloat;
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Double");
            double aAsDouble = 20000.0, bAsDouble = 53230.0;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                double result = aAsDouble % bAsDouble;
            });
            Console.WriteLine("----------------");

            Console.WriteLine("Decimal");
            decimal aAsDecimal = 20000.0m, bAsDecimal = 53230.0m;
            Timer.Timer.DisplayExecutionTime(() =>
            {
                decimal result = aAsDecimal % bAsDecimal;
            });
            Console.WriteLine("----------------");
            Console.WriteLine();
        }
    }
}