using System;
using System.Collections.Generic;

namespace Minesweeper
{
    class Minesweeper
    {
        static void Main()
        {
            string command = string.Empty;
            char[,] gameField = CreateGameField();
            char[,] mines = InitializeMines();
            int currentPlayerScores = 0;
            bool steppedOnMine = false;
            List<PlayerScore> champions = new List<PlayerScore>(6);
            int row = 0;
            int column = 0;
            bool isNewGame = true;
            const int MaxGameCellsToReveal = 35;
            bool isGameOver = false;

            do
            {
                if (isNewGame)
                {
                    Console.WriteLine("Welcome to minesweeper game! Try your luck and try to reaveal" + 
                        "all\nquestion marks without hitting mine.");
                    Console.WriteLine("You can use the following commands: ");
                    Console.WriteLine("'top': to see te top scores");
                    Console.WriteLine("'restart' to restart the game");
                    Console.WriteLine("'exit' to exit the game");
                    RenderGameField(gameField);
                    isNewGame = false;
                }

                do
                {
                    Console.Write("Input row and column in fomrat '<row> <column>': ");
                    command = Console.ReadLine().Trim();

                    if (command == "turn")
                    {
                        Console.WriteLine("\nError! Invalid command!\n");
                    }
                }
                while (command == "turn");                

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out column) &&
                        row <= gameField.GetLength(0) && column <= gameField.GetLength(1))
                    {
                        command = "turn";
                    }
                }
                switch (command)
                {
                    case "top":
                        GetTopScores(champions);
                        break;
                    case "restart":
                        gameField = CreateGameField();
                        mines = InitializeMines();
                        RenderGameField(gameField);
                        steppedOnMine = false;
                        isNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Thank for playing our Minesweeper!");
                        break;
                    case "turn":
                        if (mines[row - 1, column] != '*')
                        {
                            if (mines[row, column] == '-')
                            {
                                NextTurn(gameField, mines, row, column);
                                currentPlayerScores++;
                            }
                            if (MaxGameCellsToReveal == currentPlayerScores)
                            {
                                isGameOver = true;
                            }
                            else
                            {
                                RenderGameField(gameField);
                            }
                        }
                        else
                        {
                            steppedOnMine = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nError! Invalid command!\n");
                        break;
                }
                if (steppedOnMine)
                {
                    RenderGameField(mines);
                    Console.Write("\nGameOver! Your scores are {0}. " +
                                  "Enter your name: ", currentPlayerScores);
                    string currentPlayerName = Console.ReadLine();
                    PlayerScore scores = new PlayerScore(currentPlayerName, currentPlayerScores);
                    if (champions.Count < 5)
                    {
                        champions.Add(scores);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].PlayerScores < scores.PlayerScores)
                            {
                                champions.Insert(i, scores);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }
                    champions.Sort((PlayerScore firstPlayer, PlayerScore secondPlayer) => 
                        secondPlayer.PlayerName.CompareTo(firstPlayer.PlayerName));
                    champions.Sort((PlayerScore firstPlayer, PlayerScore secondPlayer) => 
                        secondPlayer.PlayerScores.CompareTo(firstPlayer.PlayerScores));
                    GetTopScores(champions);

                    gameField = CreateGameField();
                    mines = InitializeMines();
                    currentPlayerScores = 0;
                    steppedOnMine = false;
                    isNewGame = true;
                }
                if (isGameOver)
                {
                    Console.WriteLine("Congratulations! You've revelad all {0} cells.", MaxGameCellsToReveal);
                    RenderGameField(mines);
                    Console.WriteLine("Enter your name: ");
                    string currentPlayerName = Console.ReadLine();
                    PlayerScore currentPlayer = new PlayerScore(currentPlayerName, currentPlayerScores);
                    champions.Add(currentPlayer);
                    GetTopScores(champions);
                    gameField = CreateGameField();
                    mines = InitializeMines();
                    currentPlayerScores = 0;
                    isGameOver = false;
                    isNewGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Thank for using our playing our game!");
            Console.Read();
        }

        private static void GetTopScores(List<PlayerScore> scores)
        {
            Console.WriteLine("\nScores:");
            if (scores.Count > 0)
            {
                for (int i = 0; i < scores.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} oppened cells",
                        i + 1, scores[i].PlayerName, scores[i].PlayerScores);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty score list!\n");
            }
        }

        private static void NextTurn(char[,] gameField, char[,] mines, int rows, int columns)
        {
            char minesAroundCellCount = GetMinesCountAroundCell(mines, rows, columns);
            mines[rows, columns] = minesAroundCellCount;
            gameField[rows, columns] = minesAroundCellCount;
        }

        private static void RenderGameField(char[,] gameField)
        {
            int rows = gameField.GetLength(0);
            int columns = gameField.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(string.Format("{0} ", gameField[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int rows = 5;
            int columns = 10;
            char[,] gameField = new char[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    gameField[i, j] = '?';
                }
            }

            return gameField;
        }

        private static char[,] InitializeMines()
        {
            int rows = 5;
            int columns = 10;
            char[,] gameField = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    gameField[i, j] = '-';
                }
            }

            List<int> minesPosition = new List<int>();
            while (minesPosition.Count < 15)
            {
                Random randomNumber = new Random();
                int randoPosition = randomNumber.Next(50);
                if (!minesPosition.Contains(randoPosition))
                {
                    minesPosition.Add(randoPosition);
                }
            }

            foreach (int position in minesPosition)
            {
                int column = (position / columns);
                int row = (position % columns);
                if (row == 0 && position != 0)
                {
                    column--;
                    row = columns;
                }
                else
                {
                    row++;
                }
                gameField[column, row - 1] = '*';
            }

            return gameField;
        }

        private static char GetMinesCountAroundCell(char[,] mines, int column, int row)
        {
            int minesCountAroundCell = 0;
            int rows = mines.GetLength(0);
            int columns = mines.GetLength(1);

            if (column - 1 >= 0)
            {
                if (mines[column - 1, row] == '*')
                {
                    minesCountAroundCell++;
                }
            }
            if (column + 1 < rows)
            {
                if (mines[column + 1, row] == '*')
                {
                    minesCountAroundCell++;
                }
            }
            if (row - 1 >= 0)
            {
                if (mines[column, row - 1] == '*')
                {
                    minesCountAroundCell++;
                }
            }
            if (row + 1 < columns)
            {
                if (mines[column, row + 1] == '*')
                {
                    minesCountAroundCell++;
                }
            }
            if ((column - 1 >= 0) && (row - 1 >= 0))
            {
                if (mines[column - 1, row - 1] == '*')
                {
                    minesCountAroundCell++;
                }
            }
            if ((column - 1 >= 0) && (row + 1 < columns))
            {
                if (mines[column - 1, row + 1] == '*')
                {
                    minesCountAroundCell++;
                }
            }
            if ((column + 1 < rows) && (row - 1 >= 0))
            {
                if (mines[column + 1, row - 1] == '*')
                {
                    minesCountAroundCell++;
                }
            }
            if ((column + 1 < rows) && (row + 1 < columns))
            {
                if (mines[column + 1, row + 1] == '*')
                {
                    minesCountAroundCell++;
                }
            }
            return char.Parse(minesCountAroundCell.ToString());
        }
    }
}