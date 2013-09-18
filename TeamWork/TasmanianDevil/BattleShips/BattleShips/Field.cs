using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShips
{
    public abstract class Field : IRendable
    { //[10,20];

        private int maxCol;
        private int maxRow;

        private List<MatrixCoordinates> hitCoords;

        protected char[,] field; /*{
            {' ','_',' ','_',' ','_',' ','_',' ','_',' ','_',' ','_',' ','_',' ','_',' ','_',' ','_',' '},
            {'|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|'},
            {'|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|'},
            {'|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|'},
            {'|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|'},
            {'|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|'},
            {'|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|'},
            {'|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|'},
            {'|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|'},
            {'|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|'},
            {'|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|','_','|'}
        };*/

        public Field(int maxRow, int maxCol)
        {

            this.hitCoords = new List<MatrixCoordinates>();
            this.maxCol = maxCol *2 + 1;
            this.maxRow = maxRow  + 1;

            field = new char[this.maxRow, this.maxCol];

            for (int row = 0; row < this.maxRow; row++)
            {
                for (int col = 0; col < this.maxCol; col++)
                {
                    if (row == 0)
                    {
                        if (col % 2 == 0)
                        {
                            this.field[row, col] = ' ';
                        }
                        else
                        {
                            this.field[row, col] = '_';
                        }
                    }
                    else
                    {
                        if (col % 2 == 0)
                        {
                            this.field[row, col] = '|';
                        }
                        else
                        {
                            this.field[row, col] = '_';
                        }
                    }
                }
            }
        }

        public List<MatrixCoordinates> HitCoords
        {
            get
            {
                return hitCoords;
            }
            set
            {
                hitCoords = value;
            }
        }

        public int MaxRow
        {
            get
            {
                return this.maxRow;
            }
        }

        public int MaxCol
        {
            get
            {
                return this.maxCol;
            }
        }

        public abstract void Draw();

        private void InsertHorizontalShip(int length, MatrixCoordinates topLeft, char symbol)
        {
            int row = topLeft.Row;
            int col = topLeft.Col * 2 - 1;

            for (int i = 0; i < length; i++)
            {
                this.field[row, col] = symbol;
                while (field[row, col] != '_') 
                {
                    col++;
                }
            }
       }

        private void InsertVerticalShip(int length, MatrixCoordinates topLeft, char symbol)
        {
            int row = topLeft.Row;
            int col = topLeft.Col * 2 - 1;

            for (int i = 0; i < length; i++)
            {
                this.field[row, col] = symbol;
                while (field[row, col] != '_')
                {
                    row++;
                }
            }
        }

        public void AddShip(IShipable ship)
        {
            switch (ship.GetOrientation())
            {
                case Orientation.Horizontal:
                    InsertHorizontalShip(ship.GetShipLength(), ship.GetTopLeftPosition(), ship.GetSymbol());
                    break;
                case Orientation.Vertical:
                    InsertVerticalShip(ship.GetShipLength(), ship.GetTopLeftPosition(), ship.GetSymbol());
                    break;
                default:
                    break;
            }
        }

        public void AddSuccessfulShot(MatrixCoordinates shot)
        {
            int row = shot.Row;
            int col = shot.Col * 2 - 1;
            field[row, col] = 'o';
        }

        public void AddUnSuccessfulShot(MatrixCoordinates shot)
        {
            int row = shot.Row;
            int col = shot.Col * 2 - 1;
            field[row, col] = 'x'; 
        }

        protected void PrintFieldCoordinates(int coordinate)
        {
            coordinate++;
            return;
        }

        public void AddHitCoords(MatrixCoordinates shot)
        {
            this.hitCoords.Add(shot);
        }
    }
}