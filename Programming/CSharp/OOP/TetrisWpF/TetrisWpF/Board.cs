using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TetrisWpF
{
    public class Board
    {
        private int rows;
        private int cols;
        private int score;
        private int linesFilled;
        private Tetramino currentTeramino;
        private Label[,] blockControls;

        private Brush noBrush = Brushes.Transparent;
        private Brush sivlerBrush = Brushes.Gray;

        public Board(Grid tetrisGrid)
        {
            this.rows = tetrisGrid.RowDefinitions.Count;
            this.cols = tetrisGrid.ColumnDefinitions.Count;
            this.score = 0;
            this.linesFilled = 0;
            this.blockControls = new Label[this.rows, this.cols];
            for (int rows = 0; rows < this.rows; rows++)
            {
                for (int cols = 0; cols < this.cols; cols++)
                {
                    blockControls[rows, cols] = new Label();
                    blockControls[rows, cols].Background = noBrush;
                    blockControls[rows, cols].BorderBrush = sivlerBrush;
                    blockControls[rows, cols].BorderThickness = new Thickness(1, 1, 1, 1);
                    Grid.SetColumn(blockControls[rows, cols], cols);
                    Grid.SetRow(blockControls[rows, cols], rows);
                    tetrisGrid.Children.Add(blockControls[rows, cols]);
                }
            }
            this.currentTeramino = new Tetramino();
            CurrentTeraminoDraw();
        }

        public int LinesFilled
        {
            get
            {
                return this.linesFilled;
            }
            set
            {
                this.linesFilled = value;
            }
        }

        public int Score
        {
            get
            {
                return this.score;
            }
            set
            {
                this.score = value;
            }
        }

        private void CurrentTeraminoDraw()
        {
            Point position = this.currentTeramino.CurrentPosition;
            Point[] shape = this.currentTeramino.CurrentShape;
            Brush color = this.currentTeramino.CurrentColor;
            foreach (Point s in shape)
            {
                blockControls[(int)(s.X + position.X) + ((this.cols/2) -1),
                              (int)(s.Y + position.Y) + 2].Background = color;
            }
        }

        private void CurrentTeraminoErase()
        {
            Point position = this.currentTeramino.CurrentPosition;
            Point[] shape = this.currentTeramino.CurrentShape;
            foreach (Point s in shape)
            {
                blockControls[(int)(s.X + position.X) + ((this.cols / 2) - 1),
                              (int)(s.Y + position.Y) + 2].Background = this.noBrush;
            }
        }
    }
}
