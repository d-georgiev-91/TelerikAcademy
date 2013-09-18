using System;
using System.Linq;

namespace BattleShips
{
    class EnemyField : Field
    {
        public EnemyField(int maxRow, int maxCol)
            : base(maxRow, maxCol)
        {

        }
        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("\nENEMY FIELD:\n");
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
                    if (field[row, col] == 'o')
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (field[row, col] == 'x')
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(field[row, col]);
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