using System;

namespace IsCellVisited
{
    class IsCellVisited
    {
        public const int MinX = 5;
        public const int MaxX = 20;

        public const int MinY = 5;
        public const int MaxY = 20;

        static void Main()
        {
            int x = 535;
            int y = 5;

            bool isXinRange = MinX <= x && x <= MaxX;
            bool isYinRange = MinY <= y && y <= MaxY;

            bool isCellVisited = false;

            if (isXinRange && isYinRange && !isCellVisited)
            {
                VisitCell();
            }
        }

        public static void VisitCell()
        {
            Console.WriteLine("Visiting cell!");
        }
    }
}