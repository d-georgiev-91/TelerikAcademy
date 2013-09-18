
using System;
using System.Windows;
using System.Windows.Media;
namespace TetrisWpF
{
    public class Tetramino
    {
        private Point currentPosition;
        private Point[] currentShape;
        private Brush currentColor;
        private bool rotate;

        public Tetramino()
        {
            this.currentPosition = new Point(0, 0);
            this.currentColor = Brushes.Transparent;
            currentShape = SetRandomShape();
        }

        public Brush CurrentColor
        {
            get
            {
                return this.currentColor;
            }
            set
            {
                this.currentColor = value;
            }
        }

        public Point[] CurrentShape
        {
            get
            {
                return this.currentShape;
            }
            set
            {
                this.currentShape = value;
            }
        }

        public Point CurrentPosition
        {
            get
            {
                return this.currentPosition;
            }
            set
            {
                this.currentPosition = value;
            }
        }

        private Point[] SetRandomShape()
        {
            Random randomGenerator = new Random();
            switch (randomGenerator.Next() % 7)
            {
                case 0:
                    rotate = true; // I
                    currentColor = Brushes.Cyan;
                    return new Point[] {
                        new Point(0,0),
                        new Point(-1,0),
                        new Point(1,0),
                        new Point(2,0),
                    };
                case 1:
                    rotate = false; // O
                    currentColor = Brushes.Yellow;
                    return new Point[] {
                        new Point(0,0),
                        new Point(0,1),
                        new Point(1,0),
                        new Point(1,1),
                    };
                case 2:
                    rotate = true; // T
                    currentColor = Brushes.Purple;
                    return new Point[] {
                        new Point(0,0),
                        new Point(-1,0),
                        new Point(0,-1),
                        new Point(1,1),
                    };
                case 3:
                    rotate = true; //  J
                    currentColor = Brushes.Blue;
                    return new Point[] {
                        new Point(1,-1),
                        new Point(-1,0),
                        new Point(0,0),
                        new Point(1,0),
                    };
                case 4:
                    rotate = true; // L
                    currentColor = Brushes.OrangeRed;
                    return new Point[] {
                        new Point(0,0),
                        new Point(-1,0),
                        new Point(1,0),
                        new Point(1,-1),
                    };
                case 5:
                    rotate = true; // S
                    currentColor = Brushes.LawnGreen;
                    return new Point[] {
                        new Point(0,0),
                        new Point(-1,0),
                        new Point(0,-1),
                        new Point(1,0),
                    };
                case 6:
                    rotate = true; // Z
                    currentColor = Brushes.Red;
                    return new Point[] {
                        new Point(0,0),
                        new Point(-1,0),
                        new Point(0,1),
                        new Point(1,1),
                    };
                default:
                    return null;
            }
        }

        public void MoveLeft()
        {
            this.currentPosition.X--; 
        }

        public void MoveRight()
        {
            this.currentPosition.X++; 
        }

        public void MoveDown()
        {
            this.currentPosition.Y--; 
        }

        public void Rotate()
        {
            this.currentPosition.Y++;
            if (rotate)
            {
                for (int i = 0; i < this.currentShape.Length; i++)
                {
                    double x = this.currentShape[i].X;
                    this.currentShape[i].X = -this.currentShape[i].Y;
                    this.currentShape[i].Y = x;
                }
            }
        }
    }
}
