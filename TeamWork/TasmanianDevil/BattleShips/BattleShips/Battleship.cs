using System;

namespace BattleShips
{
    public class Battleship : Ship
    {
        public new const int Length = 4;
        public new const char Symbol = 'B';
        public Battleship(Orientation orientation, MatrixCoordinates topLeft) : base(orientation, topLeft)
        {
        }

        public override int GetShipLength()
        {
            return Battleship.Length;
        }

        public override char GetSymbol()
        {
            return Battleship.Symbol;
        }
    }
}
