namespace HashedSetDemo
{
    using System;
    using System.Linq;
    using HashedSet;

    class HashedSetDemo
    {
        static void Main()
        {
            HashedSet<int> firstSet = new HashedSet<int>();
            firstSet.Add(5);
            firstSet.Add(5);
            firstSet.Add(3);
            firstSet.Add(4);
            firstSet.Remove(4);
            Console.WriteLine(firstSet.Count);
            Console.WriteLine(firstSet.Find(5));
            firstSet.Clear();
            
            firstSet.Add(1);
            firstSet.Add(2);
            firstSet.Add(5);

            HashedSet<int> secondSet = new HashedSet<int>();

            secondSet.Add(1);
            secondSet.Add(3);
            secondSet.Add(15);

            var union = firstSet.Union(secondSet);
            Console.WriteLine("Union");

            foreach (var item in union)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            var intesecton = firstSet.Intersect(secondSet);
            Console.WriteLine("Intesecton");

            foreach (var item in intesecton)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}
