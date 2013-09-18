using System;

class TwoIntVariblesSwap
{
    static void Main()
    {
        int firstVarible = 5;
        int secondVarible = 10;
        firstVarible = firstVarible + secondVarible;
        secondVarible = firstVarible - secondVarible;
        firstVarible = firstVarible - secondVarible;
    }
}
