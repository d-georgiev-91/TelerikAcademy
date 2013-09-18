namespace FriendsInNeed
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;
    
    class FriendsInNeed
    {
        const int Infinity = int.MaxValue;

        static void Main()
        {
            var counts = Console.ReadLine().Split(' ');

            int pointsCount = int.Parse(counts[0].Trim());
            int streetsCount = int.Parse(counts[1].Trim());
            int hospitalsCount = int.Parse(counts[2].Trim());

            var hospitals = Console.ReadLine().Split(' ');

            Dictionary<Node, List<Edge>> map = new Dictionary<Node, List<Edge>>();
            Dictionary<int, Node> allNodes = new Dictionary<int, Node>();

            IntializeConnections(streetsCount, allNodes, map);

            IntializeHospitals(hospitalsCount, hospitals, allNodes);

            int distanceToNearestHospital = GetDistanceToNearestHospital(hospitalsCount, hospitals, map, allNodes);

            Console.WriteLine(distanceToNearestHospital);
        }

        private static int GetDistanceToNearestHospital(int hospitalsCount, string[] hospitals,
            Dictionary<Node, List<Edge>> map, Dictionary<int, Node> allNodes)
        {
            int distanceToNearestHospital = Infinity;

            for (int i = 0; i < hospitalsCount; i++)
            {
                int currentHospital = int.Parse(hospitals[i]);
                DijkstraAlgorithm(map, allNodes[currentHospital]);

                int currentSum = 0;

                foreach (var node in allNodes)
                {
                    if (!node.Value.IsHospital)
                    {
                        currentSum += node.Value.DijkstraDistance;
                    }
                }

                if (currentSum < distanceToNearestHospital)
                {
                    distanceToNearestHospital = currentSum;
                }
            }
            return distanceToNearestHospital;
        }

        private static void IntializeHospitals(int hospitalsCount, string[] hospitals, Dictionary<int, Node> allNodes)
        {
            for (int i = 0; i < hospitalsCount; i++)
            {
                int currentHospital = int.Parse(hospitals[i]);

                allNodes[currentHospital].IsHospital = true;
            }
        }

        private static void IntializeConnections(int streetsCount, Dictionary<int, Node> allNodes,
            Dictionary<Node, List<Edge>> map)
        {
            for (int i = 0; i < streetsCount; i++)
            {
                var currentStreet = Console.ReadLine().Split(' ');

                int firstNode = int.Parse(currentStreet[0]);
                int secondNode = int.Parse(currentStreet[1]);
                int distance = int.Parse(currentStreet[2]);

                if (!allNodes.ContainsKey(firstNode))
                {
                    allNodes.Add(firstNode, new Node(firstNode));
                }

                if (!allNodes.ContainsKey(secondNode))
                {
                    allNodes.Add(secondNode, new Node(secondNode));
                }

                if (!map.ContainsKey(allNodes[firstNode]))
                {
                    map.Add(allNodes[firstNode], new List<Edge>());
                }

                if (!map.ContainsKey(allNodes[secondNode]))
                {
                    map.Add(allNodes[secondNode], new List<Edge>());
                }

                map[allNodes[firstNode]].Add(new Edge(allNodes[secondNode], distance));
                map[allNodes[secondNode]].Add(new Edge(allNodes[firstNode], distance));
            }
        }

        public static void DijkstraAlgorithm(Dictionary<Node, List<Edge>> map, Node source)
        {
            OrderedBag<Node> queue = new OrderedBag<Node>();

            foreach (var node in map)
            {
                node.Key.DijkstraDistance = Infinity;
            }

            queue.Add(source);
            source.DijkstraDistance = 0;

            while (queue.Count != 0)
            {
                var currentNode = queue.GetFirst();
                queue.RemoveFirst();

                foreach (var edge in map[currentNode])
                {
                    var potencialDistance = edge.Distance + currentNode.DijkstraDistance;

                    if (potencialDistance < edge.ToNode.DijkstraDistance)
                    {
                        edge.ToNode.DijkstraDistance = potencialDistance;
                        queue.Add(edge.ToNode);
                    }
                }
            }
        }
    }
}