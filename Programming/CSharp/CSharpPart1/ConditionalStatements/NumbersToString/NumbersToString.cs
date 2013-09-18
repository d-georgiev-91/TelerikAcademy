using System;

class NumbersToString
{
    static void Main()
    {
        int number = -1;
        while(number < 0 || number > 999)
        {
            Console.Write("Input a number in range [0...999] : ");
            number = int.Parse(Console.ReadLine());
        }
        int hundreds = number / 100;
        int tens = number / 10 % 10;
        int units = number % 10;
        string numberInText = "";
        switch (hundreds)
        {
            case 0:
                numberInText = "";
                break;
            case 1:
                numberInText = "one hundred ";
                break;
            case 2:
                numberInText = "two hundred ";
                break;
            case 3:
                numberInText = "three hundred ";
                break;
            case 4:
                numberInText = "four hundred ";
                break;
            case 5:
                numberInText = "five hundred ";
                break;
            case 6:
                numberInText = "six hundred ";
                break;
            case 7:
                numberInText = "seven hundred ";
                break;
            case 8:
                numberInText = "eight hundred ";
                break;
            case 9:
                numberInText = "nine hundred ";
                break;
        }
        if (hundreds != 0 && tens !=0 && units == 0)
        {
            numberInText += "and ";
        }
        switch (tens)
        {
            case 0:
                if (hundreds != 0 && units != 0 )
                {
                    numberInText += "and ";
                }
                else
                {
                    numberInText += "";
                }
                break;
            case 1:
                if (hundreds != 0)
                {
                    numberInText += "and ";
                }
                switch(units)
                {
                    case 0:
                        numberInText += "ten";
                        break;
                    case 1:
                        numberInText += "eleven";
                        break;
                    case 2:
                        numberInText += "twelve";
                        break;
                    case 3:
                        numberInText += "thirteen";
                        break;
                    case 4:
                        numberInText += "fourteen";
                        break;
                    case 5:
                        numberInText += "fifteen";
                        break;
                    case 6:
                        numberInText += "sixteen";
                        break;
                    case 7:
                        numberInText += "seventen";
                        break;
                    case 8:
                        numberInText += "eighteen";
                        break;
                    case 9:
                        numberInText += "nineteen";
                        break;
                }
                break;
            case 2:
                numberInText += "twenty ";
                break;
            case 3:
                numberInText += "thirty ";
                break;
            case 4:
                numberInText += "fourty ";
                break;
            case 5:
                numberInText += "fifty ";
                break;
            case 6:
                numberInText += "sixty ";
                break;
            case 7:
                numberInText += "seventy ";
                break;
            case 8:
                numberInText += "eighty ";
                break;
            case 9:
                numberInText += "ninety ";
                break;
        }
        if (tens != 1)
        {
            switch (units)
            {
                case 0:
                    if (hundreds == 0 && tens == 0)
                    {
                        numberInText = "Zero";
                    }
                    break;
                case 1:
                    numberInText += "one";
                    break;
                case 2:
                    numberInText += "two";
                    break;
                case 3:
                    numberInText += "three";
                    break;
                case 4:
                    numberInText += "four";
                    break;
                case 5:
                    numberInText += "five";
                    break;
                case 6:
                    numberInText += "six";
                    break;
                case 7:
                    numberInText += "seven";
                    break;
                case 8:
                    numberInText += "eight";
                    break;
                case 9:
                    numberInText += "nine";
                    break;
            }
        }
        numberInText = char.ToUpper(numberInText[0]) + numberInText.Substring(1);
        Console.WriteLine(numberInText);
    }
}