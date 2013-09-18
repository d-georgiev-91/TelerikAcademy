namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Node<T>
    {
        public Node(T value, bool hasParent) : this()
        {
            this.Value = value;
            this.HasParent = hasParent;
        }

        public Node()
        {
            this.Children = new List<Node<T>>();
        }

        public T Value { get; set; }

        public List<Node<T>> Children { get; set; }

        public bool HasParent { get; set; }
    }
}