using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BattleShips
{
    public class GameEngine
    {
        private int fieldRowMin;
        private int fieldRowMax;
        private int fieldColMin;
        private int fieldColMax;
        private Field playerField;
        private Field gameField;
        private List<Ship> playerShips;
        private List<Ship> computerShips;
        IUserInterface keyboard;
        IRenderer renderer;

        private void RenderTheWorld()
        {
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = true;
            this.renderer.AddForRendering(this.playerField);
            this.renderer.AddForRendering(this.gameField);
            renderer.RenderAll();
            renderer.ClearQueue();
        }

        public GameEngine(Field playerField, List<Ship> playerShips, Field gameField, List<Ship> computerShips, IUserInterface keyboard, IRenderer renderer, int minRow, int maxRow, int minCol, int maxCol)
        {
            this.playerField = playerField;
            this.gameField = gameField;
            this.playerShips = playerShips;
            this.computerShips = computerShips;
            //Uncomment to cheat
          
            //CheatEngine cheatengine = CheatEngine.GetInstance();
            //cheatengine.ExtractEnemyShipsPosition(computerShips);
            this.keyboard = keyboard;
            this.renderer = renderer;
            this.fieldRowMin = minRow;
            this.fieldRowMax = maxRow;
            this.fieldColMin = minCol;
            this.fieldColMax = maxCol;
        }

        private bool IsInRange(MatrixCoordinates shot)
        {
            if (shot.Row > fieldRowMax || shot.Row < fieldRowMin || shot.Col > fieldColMax || shot.Col < fieldColMin)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(Console.WindowWidth / 2 - "ROWS SHOULD BE IN THE RANGE[{0},{1}]".Length / 2, Console.WindowHeight / 2 - 2);
                Console.WriteLine("ROWS SHOULD BE IN THE RANGE[{0},{1}]", fieldRowMin, fieldRowMax);
                Console.SetCursorPosition(Console.WindowWidth / 2 - "AND COLS IN THE RANGE [{0},{1}]".Length / 2, Console.WindowHeight / 2 - 1);
                Console.WriteLine("AND COLS IN THE RANGE [{0},{1}]", fieldColMin, fieldColMax);
                Thread.Sleep(1000);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(false);
                }
                Console.CursorVisible = false;
                Console.Clear();
                this.RenderTheWorld();
                return false;
            }

            return true;
        }

        private bool isAlreadyHit(MatrixCoordinates shot)
            {
            if (this.playerField.HitCoords.Contains(shot))
                {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(Console.WindowWidth / 2 - "POINT IS ALREADY HIT!".Length / 2, Console.WindowHeight / 2 - 1);
                Console.WriteLine("POINT IS ALREADY HIT!");
                Thread.Sleep(1000);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(false);
                }
                Console.CursorVisible = false;
                Console.Clear();
                this.RenderTheWorld();
                return false;
            }

            return true;
        }

        private void ValidateHit(ref MatrixCoordinates shot, ref MatrixCoordinates robotShot)
        {
            int counter = 0;
            bool isInRange = true;
            bool isHitted = true;

            do
            {
                isInRange = true;
                isHitted = true;
                
                if (counter == 5)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    throw new DummyException("You simply don't want to play or you can't read!");
                }
                isInRange = IsInRange(shot);
                isHitted = isAlreadyHit(shot);
                if (!(isInRange && isHitted))
                {
                shot = keyboard.ReadUserInput();
            }
                counter++;
            }
            while (!(isInRange && isHitted));
           
            // check is already hit player shot

            // check is already hit robot shot
            while (this.gameField.HitCoords.Contains(robotShot))
            {
                robotShot = Robot.GenerateShot(fieldRowMin, fieldRowMax, fieldColMin, fieldColMax);
            }

            this.playerField.AddHitCoords(shot);
            this.gameField.AddHitCoords(robotShot);
        }

        public void Run()
        {
            // add  playership in player field
            foreach (var item in playerShips)
            {
                playerField.AddShip(item);
            }

            this.RenderTheWorld();

            while (playerShips.Count != 0 && computerShips.Count != 0)
            {
                // read player coordinates
                MatrixCoordinates shot = keyboard.ReadUserInput();
                MatrixCoordinates robotShot = Robot.GenerateShot(fieldRowMin, fieldRowMax, fieldColMin, fieldColMax);
                ValidateHit(ref shot, ref robotShot);                
               
                Console.Clear();
                // add shot as unsuccessful
                gameField.AddUnSuccessfulShot(shot);
                playerField.AddUnSuccessfulShot(robotShot);

                // check if computer ship is Hit

                foreach (var item in computerShips)
                {
                    if (item.IsHit(shot))
                    {
                        PlayExplosion();
                        gameField.AddSuccessfulShot(shot);
                        break;
                    } 
                }

                // check if player ship is Hit
                foreach (var item in playerShips)
                {
                    if (item.IsHit(robotShot))
                    {
                        PlayExplosion();
                        playerField.AddSuccessfulShot(robotShot);
                        break;
                    }
                }
                this.RenderTheWorld();
                computerShips.RemoveAll(ship => ship.IsDestroyed);
                playerShips.RemoveAll(ship => ship.IsDestroyed);
            }

            if (computerShips.Count == 0)
            {
                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth / 2 - "Congratssss You Win!".Length / 2, Console.WindowHeight / 2 - 2);
                Console.WriteLine("Congratssss You Win!");
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth / 2 - "ROWS SHOULD BE IN THE RANGE[{0},{1}]".Length / 2, Console.WindowHeight / 2 - 2);
                Console.WriteLine("You LOST!");
            }
        }
  
        private void PlayExplosion()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"..\..\Media\bomb-02.wav");
            player.Play();
        }
    }
}