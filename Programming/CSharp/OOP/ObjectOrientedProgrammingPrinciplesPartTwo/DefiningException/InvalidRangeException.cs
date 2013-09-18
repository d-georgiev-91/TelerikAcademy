using System;
using System.Linq;

namespace DefiningException
{
    class InvalidRangeException<T> : ApplicationException
        where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        T start;
        T end;

        public InvalidRangeException(string message, T start, T end, Exception innerException)
            : base(message, innerException)
        {
            this.start = start;
            this.end = end;
        }


        public InvalidRangeException(T start, T end)
            :this (null, start, end, null)
        {
        }

        public InvalidRangeException(string message, T start, T end)
            : this(message,start, end, null)
        {
        }

        public T Start
        {
            get
            {
                return this.start;
            }
        }

        public T End
        {
            get
            {
                return this.end;
            }
        }
    }
}
