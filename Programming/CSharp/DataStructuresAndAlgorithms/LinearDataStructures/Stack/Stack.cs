namespace Stack
{
    using System;
    
    public class Stack<T>
    {
        public Stack()
        {
            this.Top = null;
            this.Count = 0;
        }

        public void Push(T value)
        {
            if (Top == null)
            {
                this.Top = new StackNode<T>(value);
            }
            else
            {
                var newTop = new StackNode<T>(value, this.Top);
                this.Top = newTop;
            }

            this.Count++;
        }

        public T Pop()
        {
            if (this.Top == null)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            var value = this.Top.Value;

            if (this.Top.Next == null)
            {
                this.Top = null;
            }
            else
            {
                this.Top = this.Top.Next;
            }

            this.Count--;

            return value;
        }

        public T Peek()
        {
            if (this.Top == null)
            {
                throw new InvalidOperationException("The stack is empty!");
            }

            var value = this.Top.Value;

            return value;
        }

        public StackNode<T> Top { get; private set; }

        public int Count { get; private set; }

        public void Clear()
        {
            this.Top = null;
            this.Count = 0;
        }

        public T[] ToArray()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            var array = new T[Count];
            var currentNode = this.Top;

            for (int i = Count - 1; i >= 0; i--)
            {
                array[i] = currentNode.Value;
                if (i != 0)
                {
                    var nextNode = currentNode.Next;
                    currentNode = nextNode;
                }
            }

            return array;
        }

        public bool Contains(T value)
        {
            var currentNode = this.Top;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    return true;
                }

                var nextNode = currentNode.Next;
                currentNode = nextNode;
            }

            return false;
        }
    }
}