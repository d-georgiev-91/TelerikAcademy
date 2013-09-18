using System;
using System.Collections.Generic;
using System.Linq;

namespace maze
{
    class Cell
    {
        public Cell(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }
    }

    class Maze
    {
        static char[,,]maze;
        static Random rand = new Random();

        static void Main()
        {
            var startLocation = Console.ReadLine().Split(' ');

            int x = int.Parse(startLocation[0]);
            int y = int.Parse(startLocation[1]);
            int z = int.Parse(startLocation[2]);

            Cell startCell = new Cell(x, y, z);

            var cubeDimensions = Console.ReadLine().Split(' ');

            int l = int.Parse(cubeDimensions[0]);
            int r = int.Parse(cubeDimensions[1]);
            int c = int.Parse(cubeDimensions[2]);

            maze = new char[l, r, c];

            for (int level = 0; level < l; level++)
            {
                for (int row = 0; row < r; row++)
                {
                    string matrixContent = Console.ReadLine(); 

                    for (int column = 0; column < c; column++)
                    {
                        maze[level, row, column] = matrixContent[column];    
                    }
                }
            }

            Console.WriteLine(CalcShortestPath(maze, startCell));
        }

        static int CalcShortestPath(char[,,]maze, Cell startCell)
        {
            int shortestPathLenght = 0;

            int[,,] levelMatrix = new int[maze.GetLength(0), maze.GetLength(1), maze.GetLength(2)];
            
            for (int level = 0; level < maze.GetLength(0); level++)
            {
                for (int row = 0; row < maze.GetLength(1); row++)
                {
                    for (int column = 0; column < maze.GetLength(2); column++)
                    {
                        if (maze[level, row, column] != '#')
                        {
                            levelMatrix[level, row, column] = -1;
                        }
                        else
                        {
                            levelMatrix[level, row, column] = 0;
                        }
                    }
                }
            }

            Queue<Cell> queue = new Queue<Cell>();

            queue.Enqueue(startCell);

            levelMatrix[startCell.X, startCell.Y, startCell.Z] = 1;

            while (queue.Count != 0)
            {
                Cell cell = queue.Dequeue();
                
                // izliza
                if (cell.X < 0 || maze.GetLength(0) > cell.X - 1)
                {
                    break;
                }

                int level = levelMatrix[cell.X, cell.Y, cell.Z];
                
                Cell[] nextCells = new Cell[6];

                nextCells[0] = new Cell(cell.X, cell.Y + 1, cell.Z);
                nextCells[1] = new Cell(cell.X, cell.Y, cell.Z + 1);
                nextCells[2] = new Cell(cell.X, cell.Y - 1, cell.Z);
                nextCells[3] = new Cell(cell.X, cell.Y, cell.Z - 1);
                nextCells[4] = new Cell(cell.X - 1, cell.Y, cell.Z);
                nextCells[5] = new Cell(cell.X + 1, cell.Y, cell.Z);

                foreach (Cell nextCell in nextCells)
                {
                    if (nextCell.X < 0 || nextCell.Y < 0 || nextCell.Z < 0)
                    {
                        continue;
                    }
                    if (nextCell.X == maze.GetLength(0) ||
                        nextCell.Y == maze.GetLength(1) ||
                        nextCell.Z == maze.GetLength(2))
                    {
                        continue;
                    }
                    if (levelMatrix[nextCell.X, nextCell.Y, nextCell.Z] == 0)
                    {
                        queue.Enqueue(nextCell);
                        levelMatrix[nextCell.X, nextCell.Y, nextCell.Z] = level + 1;
                    }
                }
            }

            while (startCell.X < 1 || )
	        {
	         
	        }

            return shortestPathLenght;
        }
    }