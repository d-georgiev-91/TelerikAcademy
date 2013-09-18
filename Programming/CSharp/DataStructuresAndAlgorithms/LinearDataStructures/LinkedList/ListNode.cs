namespace LinkedList
{
    using System;

    public class ListNode<T>
    {
        public ListNode(T value)
        {
            this.Value = value;
        }

        public ListNode(T value, ListNode<T> next)
            : this(value)
        {
            this.Next = next;
        }

        public ListNode(T value, ListNode<T> next, ListNode<T> previous)
            : this(value, next)
        {
            this.Previous = previous;
        }

        public override string ToString()
        {
            var value = this.Value.ToString();

            return value;
        }

        public T Value { get; internal set; }

        public ListNode<T> Previous { get; internal set; }

        public ListNode<T> Next { get; internal set; }
    }
}