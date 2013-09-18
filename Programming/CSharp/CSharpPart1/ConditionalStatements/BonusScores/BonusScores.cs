using System;

class BonusScores
{
    static void Main()
    {
        string stringScores;
        Console.Write("Input scores in range [1..9]: ");
        stringScores = Console.ReadLine();
        uint uintScores;
        bool isADigit = UInt32.TryParse(stringScores, out uintScores);
        isADigit &= uintScores < 10;
        switch (isADigit)
        {
            case true:
                {
                    switch (uintScores)
                    {
                        case 1:
                        case 2:
                        case 3:
                            uintScores *= 10;
                            Console.WriteLine(uintScores);
                            break;
                        case 4:
                        case 5:
                        case 6:
                            uintScores *= 100;
                            Console.WriteLine(uintScores);
                            break;
                        case 7:
                        case 8:
                        case 9:
                            uintScores *= 1000;
                            Console.WriteLine(uintScores);
                            break;
                        case 0:
                            Console.WriteLine("Error.");
                            break;
                    }
                    break;
                }
            case false:
                Console.WriteLine("Error.");
                break;
        }
    }
}