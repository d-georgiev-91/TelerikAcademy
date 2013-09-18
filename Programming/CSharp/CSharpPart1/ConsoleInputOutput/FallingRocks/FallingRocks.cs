using System;
using System.Collections.Generic;
using System.Threading;

public struct Rock
{
    public int X, Y, size;
    public char ch;
    public ConsoleColor color;
    public Rock(int x , int y, int size, char ch, ConsoleColor color)
    {
        Random randomGenerator = new Random();
        this.X = x;
        this.Y = y;
        this.size = size;
        this.ch = ch;
        this.color = color;
        this.size = randomGenerator.Next(0, 4);
    }
}
public struct Dwarf
{
    public int X, Y;
    public ConsoleColor color;
    public Dwarf(int x, int y)
    {
        this.X = x;
        this.Y = y;
        this.color = ConsoleColor.DarkRed;
    }
}
class FallingRocks
{
    static Dwarf dwarf = new Dwarf(Console.WindowWidth / 2 - 9, Console.WindowHeight - 1);
    public static void PrintAtPosition(int x, int y, char ch, ConsoleColor color = ConsoleColor.Green, int size = 1)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        for (int i = 1; i <= size; i++)
        {
            Console.Write(ch);
        }
    }
    public static void MoveDwarfLeft()
    {
        if (dwarf.X - 2 >= 0)
        {
            dwarf.X--;
        }
    }
    public static void MoveDwarfRight()
    {
        if (dwarf.X + 2 <= Console.WindowWidth - 10)
        {
            dwarf.X++;
        }
    }
    public static void SetField()
    {
        Console.CursorVisible = false;
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.BufferWidth;
    }
    public static void DrawDwarf()
    {
        PrintAtPosition(dwarf.X - 1, dwarf.Y, '(', dwarf.color);
        PrintAtPosition(dwarf.X, dwarf.Y, '0', dwarf.color);
        PrintAtPosition(dwarf.X + 1, dwarf.Y, ')', dwarf.color);

    }
    public static void PrintStringAtPosition(int x, int y, string str, ConsoleColor color = ConsoleColor.Blue)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(str);
    }
    static void Main()
    {
        Random randomGenerator = new Random();
        List<Rock> rocks = new List<Rock>();
        int lives = 5;
        SetField();
        DrawDwarf();
        
        while (true)
        {   bool hitted = false;
            {
                Rock newRock = new Rock();
                newRock.color = ConsoleColor.White;
                newRock.X = randomGenerator.Next(0, Console.WindowWidth - 10);
                newRock.Y = 0;
                newRock.ch = '&';
                rocks.Add(newRock);
            }
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey();
                }
                if (keyPressed.Key == ConsoleKey.LeftArrow)
                {
                    MoveDwarfLeft();
                }
                if (keyPressed.Key == ConsoleKey.RightArrow)
                {
                    MoveDwarfRight();
                }
            }
            List<Rock> newList = new List<Rock>();
            for (int i = 0; i < rocks.Count; i++)
            {
                Rock oldRock = rocks[i];
                Rock newRock = new Rock();
                newRock.X = oldRock.X;
                newRock.Y = oldRock.Y + 1;
                newRock.ch = oldRock.ch;
                newRock.color = oldRock.color;
                if(newRock.Y == dwarf.Y && (newRock.X >= dwarf.X - 1 && newRock.X <= dwarf.X + 1))
                {
                    lives--;
                    hitted = true;
                    if (lives <= 0)
                    {
                        PrintStringAtPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2, "Game over!", ConsoleColor.Red);
                        PrintStringAtPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2, "Press [enter] to exit...", ConsoleColor.Red);
                        Console.ReadLine();
                        Environment.Exit(0);
                    }

                }
                if(newRock.Y < Console.WindowHeight)
                {
                    newList.Add(newRock);
                }
            }
            rocks = newList;
            Console.Clear();
            if (hitted)
            {
                rocks.Clear();
                PrintAtPosition(dwarf.X, dwarf.Y, 'X', ConsoleColor.Red);
                
            }
            else
            {
                PrintStringAtPosition(Console.WindowWidth - 9, 5, "Lives: " + lives, ConsoleColor.DarkBlue);
            }
            DrawDwarf();
            foreach (Rock rock in rocks)
            {
                PrintAtPosition(rock.X, rock.Y, rock.ch, rock.color, rock.size);
            }
            Thread.Sleep(150);
        }
    }
}

