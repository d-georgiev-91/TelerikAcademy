using System;

namespace Methods
{
    class Methods
    {
        static double CalcTriangleArea(double a, double b, double c)
        {
            if (!AreValidTriangleLengths(a, b, c))
            {
                throw new ArgumentException("Invalid arguments. Triangle sides length must be greater than 0.");
            }
            else if (!FormAValidTraingle(a, b, c))
            {
                throw new ArgumentException("No triangle exits with those lengths.");
            }
            else
            {
                double s = (a + b + c) / 2;

                double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
                return area;
            }
        }

        private static bool FormAValidTraingle(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

        private static bool AreValidTriangleLengths(double a, double b, double c) 
        {
            return a > 0 && b > 0 && c > 0;
        }

        static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    throw new ArgumentException("There is no such digit!");
            }
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new NullReferenceException("There isn't any max element of emtpy sequence.");
            }
            else
            {
                int maxElement = elements[0];
                for (int i = 1; i < elements.Length; i++)
                {
                    if (elements[i] > maxElement)
                    {
                        maxElement = elements[i];
                    }
                }
                return maxElement;
            }
        }

        public static void PrintAlinged(object value, int aligment)
        {
            Console.WriteLine("{0," + aligment + "}", value);
        }

        public static void PrintAsPercent(object value)
        {
            Console.WriteLine("{0:p0}", value);
        }

        private static void PrintFloatWithPresion(object value, uint precision)
        {
            Console.WriteLine("{0:f" + precision + "}", value);
        }

        static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        static bool IsDistanceVerticalLine(double x1, double y1, double x2, double y2)
        {
            if (ArePointsMatching(x1, y1, x2, y2))
            {
                throw new InvalidOperationException("Points match and cant form line.");
            }
            else
            {
                bool isVertical = (x1 == x2);
                return isVertical;
            }
        }

        static bool IsDistanceHorizontalLine(double x1, double y1, double x2, double y2)
        {
            if (ArePointsMatching(x1, y1, x2, y2))
            {
                throw new InvalidOperationException("Points match and cant form line");
            }
            else
            {
                bool isHorizontal = (y1 == y2);
                return isHorizontal;
            }
        }

        private static bool ArePointsMatching(double x1, double y1, double x2, double y2)
        {
            return x1 == x2 && y1 == y2;
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));
            
            Console.WriteLine(NumberToDigit(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));
            
            PrintFloatWithPresion(1.3, 2);
            PrintAsPercent(0.75);
            PrintAlinged(2.30, 8);

            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + IsDistanceHorizontalLine(3, -1, 3, 2.5));
            Console.WriteLine("Vertical? " + IsDistanceVerticalLine(3, -1, 3, 2.5));

            Student peter = new Student("Peter", "Ivanov", new DateTime(1992, 03, 17), "Sofia");
            Student stella = new Student("Stella", "Markova", new DateTime(1993, 11, 03), "Vidin", "gamer", Student.Results.High);
            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}