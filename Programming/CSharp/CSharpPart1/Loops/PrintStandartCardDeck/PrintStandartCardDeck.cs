using System;

class PrintStandartCardDeck
{
    public static string CardSymbol(string symbol)
    {
        string text = null;
        switch (symbol)
        {
            case "A":
                text = "Ace";
                break;
            case "2":
                text = "Two";
                break;
            case "3":
                text = "Three";
                break;
            case "4":
                text = "Four";
                break;
            case "5":
                text = "Five";
                break;
            case "6":
                text = "Six";
                break;
            case "7":
                text = "Seven";
                break;
            case "8":
                text = "Eight";
                break;
            case "9":
                text = "Nine";
                break;
            case "10":
                text = "Ten";
                break;
            case "J":
                text = "Jack";
                break;
            case "Q":
                text = "Queen";
                break;
            case "K":
                text = "King";
                break;
        }
        return text;
    }
    public static string CardType(int n)
    {
        string cardType = null;
        switch (n)
        {
            case 1:
                cardType = "clubs";
                Console.ForegroundColor = ConsoleColor.Black;
                break;
            case 2:
                cardType = "diamonds";
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case 3:
                cardType = "spades";
                Console.ForegroundColor = ConsoleColor.Black;
                break;
            case 4:
                cardType = "hearts";
                Console.ForegroundColor = ConsoleColor.Red;
                break;
        }
        return cardType;
    }
    static void Main()
    {
        Console.BackgroundColor = ConsoleColor.White;
        for (int i = 1; i <= 4; i++)
        {
                Console.WriteLine(CardSymbol("A") + " of " + CardType(i));
                for (int j = 2; j <= 10; j++)
                {
                    Console.WriteLine(CardSymbol(j.ToString())+ " of " + CardType(i));
                }
                Console.WriteLine(CardSymbol("J") + " of " + CardType(i));
                Console.WriteLine(CardSymbol("Q") + " of " + CardType(i));
                Console.WriteLine(CardSymbol("K") + " of " + CardType(i));
        }
    }
}