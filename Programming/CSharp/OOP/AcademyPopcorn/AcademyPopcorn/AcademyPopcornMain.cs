using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 1;
            int endCol = WorldCols - 2;

            for (int row = startRow; row < startRow + 3; row++)
            {
                for (int col = startCol; col < endCol; col++)
                {
                    Block currBlock = new Block(new MatrixCoords(row, col));
                    engine.AddObject(currBlock);
                }
            }

            for (int col = startCol; col < endCol; col++)
            {
                Block currBlock;
                if (col % 2 == 0 || col % 3 != 0)
                {
                    currBlock = new ExplodingBlock(new MatrixCoords(startRow + 3, col));
                }
                else if (col % 4 ==0 || col % 5 == 0)
                {
                    currBlock = new GiftBlock(new MatrixCoords(startRow + 3, col));
                }
                else
                {
                    currBlock = new UnpassableBlock(new MatrixCoords(startRow + 3, col));
                }
                engine.AddObject(currBlock);
            }

            for (int i = startRow; i < WorldRows; i++) //left bound
            {
                IndestructibleBlock currBlock = new IndestructibleBlock(new MatrixCoords(i, 0));
                engine.AddObject(currBlock);
            }

            for (int i = startRow; i < WorldRows; i++) //right bound
            {
                IndestructibleBlock currBlock = new IndestructibleBlock(new MatrixCoords(i, endCol));
                engine.AddObject(currBlock);
            }

            for (int i = startCol; i < endCol; i++) //up bound
            {
                IndestructibleBlock currBlock = new IndestructibleBlock(new MatrixCoords(startRow - 1, i));
                engine.AddObject(currBlock);
            }

            //for (int i = startCol + 5; i < endCol - 5; i++) //adding some trial object
            //{
            //    TrailObject currBlock = new TrailObject(new MatrixCoords(startRow + 3, i), new char[,] { { '@' } }, 15);
            //    engine.AddObject(currBlock);
            //}

            //Uncomment for standart ball
            //Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));

            //Uncomment for meteorite ball
            //Ball theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));

            //Unstoppable ball oh yeaaaaaaah feel the power :X
            UnstoppableBall theBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            //Engine ga meEngine = new Engine(renderer, keyboard, 100);

            EngineForShooting gameEngine = new EngineForShooting(renderer, keyboard, 100);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.ShootPlayerRacket();
            };

            Initialize(gameEngine);

            gameEngine.Run();
        }
    }
}