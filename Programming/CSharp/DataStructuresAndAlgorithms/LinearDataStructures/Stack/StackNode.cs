namespace Stack
{
    public class StackNode<T>
    {
        internal StackNode(T value)
        {
            this.Value = value;
        }

        internal StackNode(T value, StackNode<T> next) : this(value)
        {
            this.Next = next;
        }

        public override string ToString()
        {
            var value = this.Value.ToString();
            
            return value;
        }
        
        public T Value { get; internal set; }

        public StackNode<T> Next { get; internal set; }
    }
}