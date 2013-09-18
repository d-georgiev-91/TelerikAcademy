using System;

namespace Queue
{
    public class Queue<T>
    {
        public Queue()
        {
            this.Tail = null;
            this.Head = null;
            this.Count = 0;
        }

        public T[] ToArray()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            var array = new T[Count];
            var currentNode = this.Head;

            for (int i = 0; i < Count; i++)
            {
                array[i] = currentNode.Value;
                if (i != Count - 1)
                {
                    var nextNode = currentNode.Next;
                    currentNode = nextNode;
                }
            }

            return array;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            var value = this.Head.Value;

            return value;
        }

        public bool Contains(T value)
        {
            var currentNode = this.Head;

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

        public void Clear()
        {
            this.Head = null;
            this.Tail = null;
            this.Count = 0;
        }

        public void Enqueue(T value)
        {
            var node = new QueueNode<T>(value);

            if (Count == 0)
            {
                this.Head = node;
            }
            else
            {
                this.Tail.Next = node;
            }

            this.Tail = node;

            Count++;
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
            else
            {
                var value = Head.Value;
                Head = Head.Next;
                Count--;

                if (Count == 0)
                {
                    this.Tail = null;
                }

                return value;
            }
        }

        public QueueNode<T> Tail { get; private set; }

        public QueueNode<T> Head { get; private set; }

        public int Count { get; private set; }
    }
}