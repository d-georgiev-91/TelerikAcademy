using System;
using System.Text;

namespace GenericList
{
    internal class GenericList<T>
    {
        private T[] list;
        private int currentCapacity;
        public int Capacity
        {
            get { return this.currentCapacity; }
            private set { this.currentCapacity = value; }
        }
        public GenericList(int capacity = 0)
        {
            currentCapacity = capacity;
            if (capacity == 0)
            {
                this.list = null;
            }
            else
            {
                this.list = new T[capacity];
            }
        }
        public void AddItem(T item)
        {

            if (this.currentCapacity >= list.Length)
            {
                T[] extendedList = new T[list.Length * 2];
                for (int i = 0; i < list.Length; i++)
                {
                    extendedList[i] = list[i];
                }
                this.currentCapacity++;
                extendedList[list.Length] = item;
                list = extendedList;
            }
            else
            {
                list[currentCapacity] = item;
                this.currentCapacity++;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < list.Length)
                {
                    return list[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
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
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public void RemoveItemAtIndex(int index)
        {
            if (index >= 0 && index < list.Length)
            {
                T[] reducedList = new T[list.Length - 1];
                bool indexFound = false;
                for (int i = 0; i < list.Length - 1; i++)
                {
                    if (index == i)
                    {
                        indexFound = true;
                    }
                    if (!indexFound)
                    {
                        reducedList[i] = list[i];
                    }
                    else
                    {
                        reducedList[i] = list[i + 1];
                    }
                }
                currentCapacity--;
                list = reducedList;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public void InsertItemAtIndex(T item, int index)
        {
            if (index >= 0 && index < currentCapacity)
            {
                T[] extendedList = new T[currentCapacity + 1];
                for (int i = 0; i < index; i++)
                {
                    extendedList[i] = list[i];
                }
                extendedList[index] = item;
                currentCapacity++;
                for (int i = index + 1; i < currentCapacity; i++)
                {
                    extendedList[i] = list[i - 1];
                }
                list = extendedList;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public void Clear()
        {
            list = new T[0];
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
            for (int i = 0; i < currentCapacity; i++)
            {
                if (i < currentCapacity - 1)
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
                throw new ArgumentException("List not IComparable.");
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
                throw new ArgumentException("List not IComparable.");
            }
        }
    }
}