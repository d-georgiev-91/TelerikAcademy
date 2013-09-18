using System;

namespace PolynomialsSum
{
    class PolynomialsSum
    {
        /* 11. Write a method that adds two polynomials. 
         * Represent them as arrays of their coefficients */
        static void FillTheRest(int [] toFill, int [] content, int startIndex, int endIndex)
        {
            for (int i = startIndex; i < endIndex; i++)
                {
                    toFill[i] = content[i];
                }
        }
        static int[] Sum(int [] firstPolynomial, int [] secondPolynomial)
        {
            int maxDegree = Math.Max(firstPolynomial.Length, secondPolynomial.Length);
            int minDegree = Math.Min(firstPolynomial.Length, secondPolynomial.Length);
            int[] sum = new int[Math.Max(firstPolynomial.Length, secondPolynomial.Length)];
            for (int i = 0; i < minDegree; i++)
            {
                sum[i] = firstPolynomial[i] + secondPolynomial[i];
            }
            if (minDegree!= maxDegree)
            {
                if (maxDegree == secondPolynomial.Length)
                {
                    FillTheRest(sum, secondPolynomial, minDegree, maxDegree);
                }
                else
                {
                    FillTheRest(sum, firstPolynomial, minDegree, maxDegree);
                }
            }
            return sum;
        }
        static void PrintPolinomail(int [] polinomial)
        {
            for (int i = polinomial.Length - 1; i > 0; i--)
            {
                if (polinomial[i] > 0 || polinomial.Length - 1 == i)
                {
                    if (polinomial[i] != 1)
                    {
                        Console.Write("{0}x^{1} + ", polinomial[i], i);
                    }
                    else
                    {
                        Console.Write("x^{0} + ", i);
                    }
                }
                else if (polinomial[i] < 0 && i != polinomial.Length - 1)
                {
                    if (polinomial[i] != 1)
                    {
                        Console.Write("({0}x^{1}) + ", polinomial[i], i);
                    }
                    else
                    {
                        Console.Write("(x^{0}) + ", i);
                    }
                }
            }
            if (polinomial[0] > 0)
            {
                Console.WriteLine(polinomial[0]);
            }
            else if (polinomial[0] < 0)
            {
                Console.WriteLine("({0})", polinomial[0]);
            }
        }
        static void InputPolynomial(int [] polynomial)
        {
            for (int i = 0; i < polynomial.Length; i++)
            {
                Console.Write("Input coefficient of x^{0}: ", i);
                polynomial[i] = int.Parse(Console.ReadLine());
            }
        }
        static void Main()
        {
            Console.Write("Input the degree of the first Polynomial: ");
            int n = int.Parse(Console.ReadLine());
            int[] firstPolynomial = new int[n + 1];
            InputPolynomial(firstPolynomial);
            Console.Write("Input the degree of the second Polynomial: ");
            n = int.Parse(Console.ReadLine());
            int[] secondPolynomial = new int[n + 1];
            InputPolynomial(secondPolynomial);
            int [] sum = Sum(firstPolynomial, secondPolynomial);
            PrintPolinomail(sum);
        }
    }
}
