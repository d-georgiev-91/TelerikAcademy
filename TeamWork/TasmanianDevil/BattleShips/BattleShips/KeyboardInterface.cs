using System;

namespace BattleShips
{
    public class KeyboardInterface : IUserInterface
    {
        private int x = 0;
        private int y = 0;

        public MatrixCoordinates ReadUserInput()
        {
            bool isValidX = false;
            bool isValidY = false;
            this.x = 0;
            this.y = 0;

            Console.Write("\nEnter Row: ");
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey();
                if (keyInfo.Key.Equals(ConsoleKey.Q))
                {
                    if (this.OnQPressed != null)
                    {
                        this.OnQPressed(this, new EventArgs());
                    }
                }
            }
            isValidX = int.TryParse(Console.ReadLine(), out x);
            if (isValidX)
            {
                Console.Write("Enter Col: ");
                isValidY = int.TryParse(Console.ReadLine(), out y);
            }
            
               
            return new MatrixCoordinates(this.x, this.y);
        }

        public event EventHandler OnQPressed;
    }
}