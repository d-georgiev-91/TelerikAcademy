namespace PriorityQueue
{
    using System;
    using System.Text;

    public class PriorityQueue<T> where T : IComparable
    {
        private const int InitialSize = 16;
        public T[] queue;

        public PriorityQueue()
        {
            this.Count = 0;
            this.queue = new T[InitialSize];
        }

        public void Enqueue(T value)
        {
            if (queue.Length >= (this.Count - 1) * 0.75)
            {
                Resize();
            }

            this.Count++;
            var index = this.Count - 1;
            queue[index] = value;

            for (int i = index / 2; i >= 0; i--)
            {
                Reorder(this.queue, i);
            }
        }

        private void Resize()
        {
            T[] resizedQueue = new T[queue.Length * 2];

            for (int i = 0; i < queue.Length; i++)
            {
                resizedQueue[i] = this.queue[i];
            }

            this.queue = resizedQueue;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new ArgumentNullException("The heap is empty");
            }

            T top = this.queue[0];
            this.queue[0] = this.queue[this.Count - 1];
            this.Count--;
            Reorder(this.queue, 0);

            return top;
        }

        public T Peek()
        {
            return this.queue[0];
        }

        private void Reorder(T[] container, int i)
        {
            int leftChildIndex = 2 * i + 1;
            int rightChildIndex = 2 * i + 2;
            int currentIndex = i;

            if (leftChildIndex <= this.Count - 1 && container[leftChildIndex].CompareTo(container[currentIndex]) < 0)
            {
                currentIndex = leftChildIndex;
            }

            if (rightChildIndex <= this.Count - 1 && container[rightChildIndex].CompareTo(container[currentIndex]) < 0)
            {
                currentIndex = rightChildIndex;
            }

            if (currentIndex != i)
            {
                Swap(ref container[i], ref container[currentIndex]);
                Reorder(container, currentIndex);
            }
        }

        private void Swap(ref T firstValue, ref T secondValue)
        {
            T swap = firstValue;
            firstValue = secondValue;
            secondValue = swap;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("[");

            for (int i = 0; i < this.Count - 1; i++)
            {
                result.AppendFormat("{0}, ", queue[i].ToString());
            }

            result.AppendFormat("{0}]", queue[this.Count - 1].ToString());

            return result.ToString();
        }

        public int Count { get; private set; }
    }
}
