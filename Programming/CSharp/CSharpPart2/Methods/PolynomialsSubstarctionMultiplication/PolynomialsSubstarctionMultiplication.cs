using System;

namespace PolynomialsSubstarctionMultiplication
{
    class PolynomialsSubstarctionMultiplication
    {   
        /* 12. Extend the program to support also subtraction and multiplication of polynomials. */
       
        static void FillTheRest(int[] toFill, int[] content, int startIndex, int endIndex)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                toFill[i] = content[i];
            }
        }


        static int[] Sum(int[] firstPolynomial, int[] secondPolynomial)
        {
            int maxDegree = Math.Max(firstPolynomial.Length, secondPolynomial.Length);
            int minDegree = Math.Min(firstPolynomial.Length, secondPolynomial.Length);
            int[] sum = new int[Math.Max(firstPolynomial.Length, secondPolynomial.Length)];
            for (int i = 0; i < minDegree; i++)
            {
                sum[i] = firstPolynomial[i] + secondPolynomial[i];
            }
            if (minDegree != maxDegree)
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

        static  int [] Substract(int [] firstPolynomail, int [] secondPolynomail)
        {
            int[] copyOfSecondPolynomail = new int[secondPolynomail.Length];
            Array.Copy(secondPolynomail, copyOfSecondPolynomail, secondPolynomail.Length);
            for (int i = 0; i < copyOfSecondPolynomail.Length; i++)
            {
                copyOfSecondPolynomail[i] *= (-1);
            }
            int[] substract = Sum(firstPolynomail, copyOfSecondPolynomail);
            return substract;
        }

        static void PrintPolynomial(int[] polynomial)
        {
            for (int i = polynomial.Length - 1; i > 0; i--)
            {
                if (polynomial[i] > 0 || (polynomial.Length - 1 == i && polynomial[i]!=0))
                {
                    if (polynomial[i] != 1)
                    {
                        Console.Write("{0}x^{1} + ", polynomial[i], i);
                    }
                    else
                    {
                        Console.Write("x^{0} + ", i);
                    }
                }
                else if (polynomial[i] < 0 && i != polynomial.Length - 1)
                {
                    if (polynomial[i] != 1)
                    {
                        Console.Write("({0}x^{1}) + ", polynomial[i], i);
                    }
                    else
                    {
                        Console.Write("(x^{0}) + ", i);
                    }
                }
            }
            if (polynomial[0] > 0)
            {
                Console.WriteLine(polynomial[0]);
            }
            else if (polynomial[0] < 0)
            {
                Console.WriteLine("({0})", polynomial[0]);
            }
        }

        static void InputPolynomial(int[] polynomial)
        {
            for (int i = 0; i < polynomial.Length; i++)
            {
                Console.Write("Input coefficient of x^{0}: ", i);
                polynomial[i] = int.Parse(Console.ReadLine());
            }
        }

        static int[] Multiplication(int[] firstPolynomail, int[] secondPolynomail)
        {
            int [] multiplication = new int[firstPolynomail.Length+secondPolynomail.Length];
            for (int i = 0; i < firstPolynomail.Length; i++)
            {
                for (int j = 0; j < secondPolynomail.Length; j++)
                {
                    int k = i + j;
                    multiplication[k] += (firstPolynomail[i] * secondPolynomail[i]);
                }
            }
            return multiplication;
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
            Console.WriteLine();
            Console.WriteLine("The first polynomial");
            PrintPolynomial(firstPolynomial);
            Console.WriteLine("The second polynomial");
            PrintPolynomial(secondPolynomial);
            Console.WriteLine();
            Console.WriteLine("Choose which polynomails you want to substarct: ");
            Console.WriteLine("(1). First - Second");
            Console.WriteLine("(2). Second - First");
            int choice = 0;
            int[] substact = null;
            while (choice != 1 && choice != 2)
            {
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        substact = Substract(firstPolynomial, secondPolynomial);
                        break;
                    case 2:
                        substact = Substract(secondPolynomial, firstPolynomial);
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
            Console.WriteLine();
            Console.WriteLine("The substaction");
            PrintPolynomial(substact);
            Console.WriteLine();
            Console.WriteLine("The multiplicaton");
            PrintPolynomial(Multiplication(firstPolynomial, secondPolynomial));
        }
    }
}
