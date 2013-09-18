using System;
using System.Numerics;

class FibunaciSequence
{
    static void Main()
    {
        BigInteger firstMember = new BigInteger(0);
        BigInteger desiredMember = new BigInteger(0);
        BigInteger secondMember = new BigInteger(1);
        Console.Write("Input N: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 2; i < n + 2; i++)
        {
                desiredMember = firstMember + secondMember;
                firstMember = secondMember;
                secondMember = desiredMember;
        }
        if (n == 2)
        {
            desiredMember = 1;
        }
        Console.WriteLine("The sum if first {0} members is: {1}", n, desiredMember - 1);
    }
}