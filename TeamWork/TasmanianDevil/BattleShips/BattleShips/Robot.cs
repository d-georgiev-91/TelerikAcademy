using System;
using System.Linq;

namespace BattleShips
{
    public static class Robot
    {
        public static MatrixCoordinates GenerateShot(int minRow, int maxRow, int minCol, int maxCol)
        {
            Random rnd = new Random();
            return new MatrixCoordinates(rnd.Next(minRow, maxRow + 1), rnd.Next(minCol, maxCol + 1)); //old values -1,11   1,21
        }
    }
}