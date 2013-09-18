using System;
using System.Linq;

namespace BattleShips
{
    class PlayerField : Field
    {
        public PlayerField(int maxRow, int maxCol) : base(maxRow ,maxCol)
        {
        }

        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nPLAYER FIELD:");
            Console.WriteLine();
            Console.ResetColor();
            for (int i = 0; i < this.field.GetLength(1) / 2; i++)
            {
                Console.Write(" " + (i + 1));
            }
            Console.WriteLine();
            for (int row = 0; row < this.field.GetLength(0); row++)
            {
                for (int col = 0; col < this.field.GetLength(1); col++)
                {
                    if (field[row,col] == 'o')
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (field[row,col] == 'x')
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (field[row,col] != '_' && field[row,col] != '|' && field[row,col] != ' ')
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black; // cosmetic change
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(field[row,col]);
                    if (col == this.field.GetLength(1) - 1 && row != 0)
                    {
                        Console.ResetColor();
                        Console.Write(" " + row);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}