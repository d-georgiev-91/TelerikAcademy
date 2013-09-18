namespace FriendsInNeed
{
    using System;

    public class Node : IComparable
    {
        public Node(int id)
        {
            this.Id = id;
            this.IsHospital = false;
        }

        public int Id { get; set; }

        public int DijkstraDistance { get; set; }

        public bool IsHospital { get; set; }

        public int CompareTo(object obj)
        {
            Node node = obj as Node;
            if (node == null)
            {
                throw new InvalidOperationException("Cannot compare" + this + " with null");
            }
            var result = this.DijkstraDistance.CompareTo(node.DijkstraDistance);

            return result;
        }
    }
}