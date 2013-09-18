namespace ColorfullRabbits
{
    using System;
    using System.Collections.Generic;

    class ColorfullRabbits
    {
        static void Main()
        {
            int[] rabbitsAnswers = GetRabbitAnswers();
            Dictionary<int, int> rabbitsCountInGroup = new Dictionary<int, int>(rabbitsAnswers.Length);
            CountRabbitsInGroup(rabbitsAnswers, rabbitsCountInGroup);
            int minRabbitsCount = GetRabbitsMinCount(rabbitsCountInGroup);
            Console.WriteLine(minRabbitsCount);
        }

        private static int[] GetRabbitAnswers()
        {
            int askedRabbitsCount = int.Parse(Console.ReadLine());
            int[] rabbitsAnswers = new int[askedRabbitsCount];

            for (int i = 0; i < askedRabbitsCount; i++)
            {
                rabbitsAnswers[i] = int.Parse(Console.ReadLine());
            }

            return rabbitsAnswers;
        }
        
        private static void CountRabbitsInGroup(int[] rabbitsAnswers, Dictionary<int, int> rabbitsCountInGroup)
        {
            foreach (var rabbitAnswer in rabbitsAnswers)
            {
                int countInGroup = rabbitAnswer + 1;

                if (rabbitsCountInGroup.ContainsKey(countInGroup))
                {
                    rabbitsCountInGroup[countInGroup]++;
                }
                else
                {
                    rabbitsCountInGroup.Add(countInGroup, 1);
                }
            }
        }

        private static int GetRabbitsMinCount(Dictionary<int, int> rabbitsCountInGroup)
        {
            int minRabbitsCount = 0;

            foreach (var countInGroup in rabbitsCountInGroup)
            {
                int maxDifferentGroups = (int)Math.Ceiling((double)rabbitsCountInGroup[countInGroup.Key] / countInGroup.Key);
                minRabbitsCount += maxDifferentGroups * countInGroup.Key;
            }

            return minRabbitsCount;
        }
    }
}