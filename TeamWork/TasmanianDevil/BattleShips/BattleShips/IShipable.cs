namespace BattleShips
{
    public interface IShipable
    {
        bool IsHit(MatrixCoordinates hitPoint);

        int GetShipLength();

        Orientation GetOrientation();

        MatrixCoordinates GetTopLeftPosition();

        char GetSymbol();
    }
}