using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShips
{
    public static class ShipGenerator
    {
                   
        private static Orientation GetRandomOrientation()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 3) - 1;
            Array orientations = Enum.GetValues(typeof(Orientation));
            return (Orientation)orientations.GetValue(number);
        }

        private static MatrixCoordinates GetRandomMatrix(int maxRow, int maxCol)
        {
            Random rnd = new Random();
            int col = rnd.Next(1, maxCol);
            int row = rnd.Next(1, maxRow);
            return new MatrixCoordinates(row, col);
        }

        private static Ship GetNewShip(Orientation orn, MatrixCoordinates cordinates)
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 6);
            switch (number)
            {
                case 1:
                    return new AircraftCarrier(orn, cordinates);
                case 2:
                    return new Destroyer(orn, cordinates);
                case 3:
                    return new PatrolBoat(orn, cordinates);
                case 4:
                    return new Submarine(orn, cordinates);
                case 5:
                    return new Battleship(orn, cordinates);

                default:
                    throw new ArgumentException();
            }
        }

        private static bool CheckIsValid(Ship ship, List<Ship> ships, int maxRow, int maxCol)
        {
            if (ship.Orientation == Orientation.Horizontal)
            {
                if (ship.GetShipLength() + ship.TopLeft.Col > maxCol)
                {
                    return false;
                }

                foreach (var item in ships)
                {
                    if (item.GetOrientation() == Orientation.Vertical)
                    {
                        for (int i = 0; i < item.GetShipLength(); i++)
                        {
                            if (ship.TopLeft.Row + i >= item.TopLeft.Row && ship.TopLeft.Row + i <= item.TopLeft.Row + item.GetShipLength())
                            {
                                if (ship.TopLeft.Col + ship.GetShipLength() >= item.TopLeft.Col)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (ship.TopLeft.Row == item.TopLeft.Row && ship.TopLeft.Col + ship.GetShipLength() >= item.TopLeft.Col)
                        {
                            return false;
                        }
                    }
                }
            }
            else if (ship.Orientation == Orientation.Vertical)
            {
                if (ship.GetShipLength() + ship.TopLeft.Row > maxRow)
                {
                    return false;
                }

                foreach (var item in ships)
                {
                    if (item.GetOrientation() == Orientation.Horizontal)
                    {
                        for (int i = 0; i < item.GetShipLength(); i++)
                        {
                            if (item.TopLeft.Row + i >= ship.TopLeft.Row && item.TopLeft.Row + i <= ship.TopLeft.Row + ship.GetShipLength())
                            {
                                if (item.TopLeft.Col + item.GetShipLength() >= ship.TopLeft.Col)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (ship.TopLeft.Col == item.TopLeft.Col && ship.TopLeft.Row + ship.GetShipLength() >= item.TopLeft.Row)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public static List<Ship> Generate(int numberOfShips,List<Ship> ships, int maxRow, int maxCol)
        {

            for (int i = 0; i < numberOfShips; )
            {
                Orientation rndOrientation = GetRandomOrientation();
                MatrixCoordinates newCordinates = GetRandomMatrix(maxRow,maxCol);
                Ship newShip = GetNewShip(rndOrientation, newCordinates);
                bool isValidShip = CheckIsValid(newShip,ships,maxRow,maxCol);
                if (isValidShip)
                {
                    ships.Add(newShip);
                    i++;
                }
            }
            
            return ships;
        }
    }
}