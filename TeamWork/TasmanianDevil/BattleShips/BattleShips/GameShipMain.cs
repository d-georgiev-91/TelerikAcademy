using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShips
{
    class GameShipMain
    {
        
        const int MinRow = 1;
        const int MaxRow = 10;
        const int MinCol = 1;
        const int MaxCol = 10;

        static GameEngine Initialize()
        {
            Field playerField = new PlayerField(MaxRow, MaxCol);
            Field enemyField = new EnemyField(MaxRow, MaxCol);
            List<Ship> playerShips = new List<Ship>();
            List<Ship> computerShips = new List<Ship>();
            IUserInterface keyboard = new KeyboardInterface();
            IRenderer renderer = new ConsoleRenderer();
            ShipGenerator.Generate(5, playerShips, MaxRow, MaxCol);
            ShipGenerator.Generate(5, computerShips, MaxRow, MaxCol);
            GameEngine engine = new GameEngine(playerField, playerShips, enemyField, computerShips, keyboard, renderer,MinRow,MaxRow,MinCol,MaxCol);
            return engine;
        }

        static void SetAppWindowSizeDimensions()
        {
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(80, 35);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.Title = "Battleships";
        }

        static void Main(string[] args)
        {
            //IUserInterface keyboard = new KeyboardInterface();
            GameEngine engine = Initialize();
            SetAppWindowSizeDimensions();
            try
            {
                engine.Run();
            }
            catch (DummyException ex)
            {
                Console.WriteLine(ex.Message);
            }
              
        }
    }
}
