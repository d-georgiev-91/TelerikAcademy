using System;
using System.Numerics;

class FibunaciSequence
{
    static void Main()
    {
        BigInteger nextMember = new BigInteger();
        BigInteger firstMember = new BigInteger(0);
        BigInteger secondMember = new BigInteger(1);
        string space;
        Console.WriteLine("Index" + "\t" + "Sequence number");
        for (int i = 0; i < 100; i++)
        {
            if (i <= 1)
                nextMember = i;
            else
            {
                nextMember = firstMember + secondMember;
                firstMember = secondMember;
                secondMember = nextMember;
            }
            Console.WriteLine(i+1 + "\t" + nextMember);
        }
    }
}