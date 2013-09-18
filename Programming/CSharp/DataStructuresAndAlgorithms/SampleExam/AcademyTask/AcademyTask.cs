namespace AcademyTask
{
    using System;
    using System.Collections.Generic;
 
    class AcademyTask
    {
        static List<int> tasks = new List<int>();
        static int variety;

        static void Main()
        {
            ReadInput();
            Console.WriteLine(Solve());
        }
  
        private static void ReadInput()
        {
            var tasksAsString = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var taskAsString in tasksAsString)
            {
                tasks.Add(int.Parse(taskAsString));
            }

            variety = int.Parse(Console.ReadLine());
        }

        private static int Solve()
        {
            int minCount = tasks.Count;
            
            for (int i = 0; i < tasks.Count - 1; i++)
            {
                for (int j = i + 1; j < tasks.Count; j++)
                {
                    if (Math.Abs(tasks[i] - tasks[j]) >= variety)
                    {
                        int count = 0;
                        count += (i + 1) / 2;
                        count += (j - i + 1) / 2 + 1;
                        minCount = Math.Min(minCount, count);
                    }
                }
            }

            return minCount;
        }
    }
}