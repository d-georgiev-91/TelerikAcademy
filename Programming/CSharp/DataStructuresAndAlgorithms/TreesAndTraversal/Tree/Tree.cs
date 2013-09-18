namespace Tree
{
    using System;
    using System.Collections.Generic;

    class Tree
    {
        static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            Node<int>[] nodes = ReadNodes(nodesCount);
            Node<int> root = GetRoot(nodes);
            Console.WriteLine("The root value is {0}", root.Value);
            List<Node<int>> leafs = GetLeafs(root);
            PrintNodes(leafs);
            List<Node<int>> middleNodes = GetMiddleNodes(root);
            PrintNodes(middleNodes);
            int longestPath = GetLongestPath(root);
            Console.WriteLine("Longest path is {0}", longestPath);
        }

        private static Node<int>[] ReadNodes(int nodesCount)
        {
            Node<int>[] nodes = new Node<int>[nodesCount];

            for (int i = 0; i < nodesCount; i++)
            {
                nodes[i] = new Node<int>(i, false);
            }

            for (int i = 0; i < nodesCount - 1; i++)
            {
                string edge = Console.ReadLine();
                var edgeAndChild = edge.Split(' ');

                int parentId = int.Parse(edgeAndChild[0]);
                int childId = int.Parse(edgeAndChild[1]);

                nodes[parentId].Children.Add(nodes[childId]);
                nodes[childId].HasParent = true;
            }

            return nodes;
        }

        private static Node<int> GetRoot(Node<int>[] nodes)
        {
            bool[] hasParrent = new bool[nodes.Length];

            foreach (var node in nodes)
            {
                foreach (var child in node.Children)
                {
                    hasParrent[child.Value] = true;
                }
            }

            for (int i = 0; i < hasParrent.Length; i++)
            {
                if (!hasParrent[i])
                {
                    var root = nodes[i];

                    return root;
                }
            }

            throw new ArgumentException("The tree has no root");
        }

        private static List<Node<int>> GetLeafs(Node<int> root)
        {
            List<Node<int>> leafs = new List<Node<int>>();
            var stack = new Stack<Node<int>>();
            stack.Push(root);

            while (stack.Count != 0)
            {
                var currentNode = stack.Pop();

                if (currentNode.Children.Count == 0)
                {
                    leafs.Add(currentNode);
                }

                foreach (var child in currentNode.Children)
                {
                    stack.Push(child);
                }
            }

            return leafs;
        }

        private static List<Node<int>> GetMiddleNodes(Node<int> root)
        {
            List<Node<int>> middleNodes = new List<Node<int>>();
            Queue<Node<int>> queue = new Queue<Node<int>>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                if (currentNode.HasParent && currentNode.Children.Count != 0)
                {
                    middleNodes.Add(currentNode);
                }

                foreach (var child in currentNode.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return middleNodes;
        }

        private static int GetLongestPath(Node<int> root)
        {
            var longestPath = 1;
            Stack<Node<int>> stack = new Stack<Node<int>>();
            stack.Push(root);

            while (stack.Count != 0)
            {
                var currentNode = stack.Pop();
                var currentPathLength = 1;

                foreach (var child in currentNode.Children)
                {
                    stack.Push(child);
                    currentPathLength++;
                }

                longestPath = Math.Max(currentPathLength, longestPath);
            }

            return longestPath;
        }

        private static void PrintNodes(List<Node<int>> leafs)
        {
            Console.Write("The leafs values are ");

            for (int i = 0; i < leafs.Count; i++)
            {
                if (i < leafs.Count - 1)
                {
                    Console.Write("{0}, ", leafs[i].Value);
                }
                else
                {
                    Console.WriteLine("{0}", leafs[i].Value);
                }
            }
        }
    }
}