namespace Queue
{
    public class QueueNode<T>
    {
        internal QueueNode(T value)
        {
            this.Value = value;
        }

        internal QueueNode(T value, QueueNode<T> next)
            : this(value)
        {
            this.Next = next;
        }

        public override string ToString()
        {
            var value = this.Value.ToString();

            return value;
        }

        public T Value { get; internal set; }

        public QueueNode<T> Next { get; internal set; }
    }
}