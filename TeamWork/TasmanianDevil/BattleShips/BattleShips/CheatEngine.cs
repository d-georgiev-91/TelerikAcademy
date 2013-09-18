using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace BattleShips
{
    public class CheatEngine
    {
        private static CheatEngine instance = null;

        private CheatEngine() { }

        public static CheatEngine GetInstance()
        {
            if (instance==null)
            {
                return new CheatEngine();
            }

            return instance;

        }
        public void ExtractEnemyShipsPosition(List<Ship> enemyShips)
        {
            StreamWriter file = new StreamWriter("EnemyShips.txt");
            int i = 1;
            foreach (var ship in enemyShips)
            {
                file.WriteLine("ship {0}", i++);
                file.WriteLine("Row: " + ship.GetTopLeftPosition().Row);
                file.WriteLine("Col: " + ship.GetTopLeftPosition().Col);
                file.WriteLine("L: " + ship.GetShipLength());
                file.WriteLine("Orientation {0}", ship.GetOrientation());
                file.WriteLine("----------------------");
            }
            file.Close();
            Process.Start("EnemyShips.txt");
        }
    }
}
