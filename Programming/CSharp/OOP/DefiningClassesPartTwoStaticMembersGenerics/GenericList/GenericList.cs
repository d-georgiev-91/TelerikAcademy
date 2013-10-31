namespace GenericList
{
    using System;
    using System.Text;
    using System.Linq;

    public class GenericList<T>
    {
        private T[] list;
        private int currentCapacity;
        private const string InvalidIndexMessage = "{0} is invalid index";

        public int Capacity
        {
            get
            {
                return this.currentCapacity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity should be positive number");
                }

                this.currentCapacity = value;
            }
        }

        public int Count { get; private set; }

        public GenericList(int capacity = 0)
        {
            this.currentCapacity = capacity;
            this.list = new T[capacity];
            this.Count = 0;
        }

        public void Add(T item)
        {
            if (this.Count >= this.Capacity)
            {
                this.ResizeList();
            }

            this.list[this.Count] = item;
            this.Count++;
        }

        private void ResizeList()
        {
            if (this.Capacity == 0)
            {
                this.Capacity = 1;    
            }
            else
            {
                this.Capacity *= 2;
            }

            T[] swapList = new T[this.Capacity];

            for (int i = 0; i < this.Count; i++)
            {
                swapList[i] = this.list[i];
            }

            this.list = swapList;
        }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < list.Length)
                {
                    return this.list[index];
                }
                else
                {
                    throw new IndexOutOfRangeException(string.Format(InvalidIndexMessage, index));
                }
            }

            set
            {
                if (index >= 0 && index < list.Length)
                {
                    list[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException(string.Format(InvalidIndexMessage, index));
                }
            }
        }

        public void RemoveItemAtIndex(int index)
        {
            if (index >= 0 && index < this.Count)
            {
                for (int i = index; i < this.Count - 1; i++)
                {
                    this.list[i] = this.list[i + 1];
                }

                this.Count--;
            }
            else
            {
                throw new IndexOutOfRangeException(string.Format(InvalidIndexMessage, index));
            }
        }

        public void InsertItemAtIndex(T item, int index)
        {
            if (index >= 0 && index < this.Capacity)
            {
                if (index == this.Capacity - 1)
                {
                    this.ResizeList();
                }

                if (index < this.Count)
                {
                    for (int i = index; i < this.Count; i++)
                    {
                        list[i + 1] = list[i];
                    }
                }

                list[index] = item;
                this.Count++;
            }
            else
            {
                throw new IndexOutOfRangeException(string.Format(InvalidIndexMessage, index));
            }
        }

        public void Clear()
        {
            list = new T[this.Capacity];
        }

        public int FindItemByValue(T value)
        {
            int index = -1;
            
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].Equals(value))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                if (i < this.Count - 1)
                {
                    result.AppendFormat("{0}, ", list[i]);
                }
                else
                {
                    result.AppendFormat("{0}", list[i]);
                }
            }

            return result.ToString();
        }

        public T Min()
        {
            if (currentCapacity == 0)
            {
                throw new InvalidOperationException("Empty list!");
            }

            if (list[0] is IComparable<T>)
            {
                T min = list[0];
                for (int i = 1; i < currentCapacity; i++)
                {
                    if ((min as IComparable<T>).CompareTo(list[i]) > 0)
                    {
                        min = list[i];
                    }
                }

                return min;
            }
            else
            {
                throw new ArgumentException("Items in list are not IComparable.");
            }
        }

        public T Max()
        {
            if (currentCapacity == 0)
            {
                throw new InvalidOperationException("Empty list!");
            }

            if (list[0] is IComparable<T>)
            {
                T max = list[0];
            
                for (int i = 1; i < currentCapacity; i++)
                {
                    if ((max as IComparable<T>).CompareTo(list[i]) < 0)
                    {
                        max = list[i];
                    }
                }

                return max;
            }
            else
            {
                throw new ArgumentException("Items in list are not IComparable.");
            }
        }
    }
}