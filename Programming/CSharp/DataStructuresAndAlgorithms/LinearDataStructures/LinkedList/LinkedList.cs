namespace LinkedList
{
    using System;

    public class LinkedList<T>
    {
        public LinkedList()
        {
            this.FirstElement = null;
            this.LastElement = null;
            this.Count = 0;
        }

        public void AddFirst(T value)
        {
            if (FirstElement == null)
            {
                this.FirstElement = new ListNode<T>(value);
                this.LastElement = FirstElement;
            }
            else
            {
                ListNode<T> nextElement = this.FirstElement;
                this.FirstElement = new ListNode<T>(value, nextElement);
                nextElement.Previous = FirstElement;
                if (Count < 2)
                {
                    this.LastElement = nextElement;
                }
            }

            this.Count++;
        }

        public void AddLast(T value)
        {
            if (FirstElement == null)
            {
                this.FirstElement = new ListNode<T>(value);
                this.LastElement = this.FirstElement;
            }
            else
            {
                var nextItem = new ListNode<T>(value, null, LastElement);
                this.LastElement.Next = nextItem;
                this.LastElement = nextItem;
            }

            this.Count++;
        }

        public void AddBefore(ListNode<T> element, ListNode<T> newElement)
        {
            ListNode<T> el = GetElement(element);

            if (el == null)
            {
                var message = string.Format("No such elemenet {0} in the list.", element);
                throw new InvalidOperationException(message);
            }

            var beforeNewElement = el.Previous;
            var afterNewElement = el;
            newElement.Previous = beforeNewElement;
            newElement.Next = afterNewElement;

            el.Previous = beforeNewElement;

            Count++;
        }

        public void AddBefore(ListNode<T> element, T value)
        {
            this.AddBefore(element,new ListNode<T>(value));
        }

        public void AddAfter(ListNode<T> element, ListNode<T> newElement)
        {
            ListNode<T> el = GetElement(element);

            if (el == null)
            {
                var message = string.Format("No such elemenet {0} in the list.", element);
                throw new InvalidOperationException(message);
            }

            var afterElement = el.Next;
            var newElementAfter = afterElement;
            var newElementBefore = el;

            newElement.Next = newElementAfter;
            newElement.Previous = newElementBefore;

            Count++;
        }

        public void AddAfter(ListNode<T> element, T value)
        {
            this.AddAfter(element, new ListNode<T>(value));
        }

        private ListNode<T> GetElement(ListNode<T> element)
        {
            var currentElement = this.FirstElement;

            while (currentElement != null)
            {
                if (currentElement == element)
                {
                    return currentElement;
                }

                currentElement = currentElement.Next;
            }

            return null;
        }

        public void RemoveFirst()
        {
            if (this.FirstElement == null)
            {
                throw new InvalidOperationException("Cannot remove first element of empty list.");
            }

            this.FirstElement = this.FirstElement.Next;
            this.FirstElement.Previous = null;

            Count--;
        }

        public void RemoveLast()
        {
            if (this.FirstElement == null)
            {
                throw new InvalidOperationException("Cannot remove last element of empty list.");
            }

            this.LastElement = this.LastElement.Previous;
            this.LastElement.Next = null;

            Count--;
        }

        public int Count { get; private set; }

        public ListNode<T> FirstElement { get; private set; }

        public ListNode<T> LastElement { get; private set; }
    }
}