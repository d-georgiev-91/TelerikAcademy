namespace DoubleEndedQueue
{

    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Double-ended queue using <see cref="System.Collections.Generic.LinkedList{T}"/>
    /// </summary>
    /// <typeparam name="T">Specifies the element type of the deque</typeparam>
    public class Deque<T> : IDeque<T>
    {
        private LinkedList<T> deque;

        /// <summary>
        /// Initializes a new instance of the <see cref="Deque{T}"/> class that is empty.
        /// </summary>
        public Deque()
        {
            this.deque = new LinkedList<T>();
        }

        /// <summary>
        /// Adds a new element at the start of the <see cref="Deque{T}"/>
        /// </summary>
        /// <param name="element"> 
        /// The element to add at the start of the <see cref="Deque{T}"/> 
        /// </param>
        public void PushFirst(T element)
        {
            this.deque.AddFirst(element);
        }

        /// <summary>
        /// Adds a new element at the end of the <see cref="Deque{T}"/>
        /// </summary>
        /// <param name="element"> 
        /// The element to add at the end of the <see cref="Deque{T}"/> 
        /// </param>
        public void PushLast(T element)
        {
            this.deque.AddLast(element);
        }

        /// <summary>
        ///     Removes and returns the object at the beggining of the <see cref="Deque{T}"/>
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     The <see cref="Deque{T}"/> is empty.
        /// </exception>
        /// <returns>
        ///     The object removed from the beginning of the <see cref="Deque{T}"/>
        /// </returns>
        public T PopFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The deque is empty");
            }

            T firstItem = deque.First.Value;
            this.deque.RemoveFirst();

            return firstItem;
        }

        /// <summary>
        ///     Removes and returns the object at the end of the <see cref="Deque{T}"/>
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     The <see cref="Deque{T}"/> is empty.
        /// </exception>
        /// <returns>
        ///     The object removed from the end of the <see cref="Deque{T}"/>
        /// </returns>
        public T PopLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The deque is empty");
            }

            T lastItem = deque.Last.Value;
            this.deque.RemoveFirst();

            return lastItem;
        }

        /// <summary>
        /// Returns the object at the beggining of the <see cref="Deque{T}"/> without removing it.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     The <see cref="Deque{T}"/> is empty.
        /// </exception>
        /// <returns>The object at the beggining of the <see cref="Deque{T}"/>.</returns>
        public T PeekFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The deque is empty");
            }

            T firstItem = deque.First.Value;

            return firstItem;
        }

        /// <summary>
        /// Returns the object at the end of the <see cref="Deque{T}"/> without removing it.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     The <see cref="Deque{T}"/> is empty.
        /// </exception>
        /// <returns>The object at the end of the <see cref="Deque{T}"/>.</returns>
        public T PeekLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The deque is empty");
            }

            T lastItem = deque.Last.Value;

            return lastItem;
        }

        /// <summary>
        /// Removes all objects from the <see cref="Deque{T}"/>.
        /// </summary>
        public void Clear()
        {
            this.deque.Clear();
        }

        /// <summary>
        /// Determines whether a element is in the <see cref="Deque{T}"/>.
        /// </summary>
        /// <param name="element">
        ///     The element to locate in the <see cref="Deque{T}"/>. The element can be <strong>null</strong> for reference types.
        /// </param>
        /// <returns>
        ///     <strong>true</strong> if element is found in the <see cref="Deque{T}"/>; otherwise, <strong>false</strong>.
        /// </returns>
        public bool Contains(T element)
        {
            return this.deque.Contains(element);
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="Deque{T}"/>.
        /// </summary>
        public int Count
        {
            get
            {
                return this.deque.Count;
            }
        }
    }
}
