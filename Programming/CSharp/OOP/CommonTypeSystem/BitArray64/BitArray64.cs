using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitArray64
{
    class BitArray64 : IEnumerable<int>
    {
        private ulong number;

        public BitArray64(ulong number)
        {
            this.Number = number;
        }

        public ulong Number
        {
            get
            {
                return this.number;
            }
            set
            {
                if (number < 0)
                {
                    throw new ArgumentException("The number must be positive");
                }
                this.number = value;
            }
        }

        public int this[int index]
        {
            get
            {
                IndexValidation(index);

                if ((number & ((ulong)1 << index)) != 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                IndexValidation(index);

                if (value != 0 && value != 1)
                {
                    throw new ArgumentOutOfRangeException("value", "Value must be 0 or 1.");
                }

                if (value == 1)
                {
                    this.number = this.number | ((ulong)1 << index);
                }
                else
                {
                    this.number = this.number & (~((ulong)1 << index));
                }
            }
        }

        private void IndexValidation(int index)
        {
            if (index < 0 || index > 63)
            {
                throw new IndexOutOfRangeException("Index must be in range [0, 63].");
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 63; i >= 0; i--)
            {
                yield return this[i];
            }
        }

        public override bool Equals(object obj)
        {
            BitArray64 bitArray64 = obj as BitArray64;

            if ((object)bitArray64 == null)
            {
                return false;
            }

            
            for (int i = 0; i < 64; i++)
            {
                if (this[i] != bitArray64[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator ==(BitArray64 firstArray, BitArray64 secondArray)
        {
            return BitArray64.Equals(firstArray, secondArray);
        }

        public static bool operator !=(BitArray64 firstArray, BitArray64 secondArray)
        {
            return BitArray64.Equals(firstArray, secondArray);
        }

        public override int GetHashCode()
        {
            int hashCode = 0;

            unchecked
            {
                foreach (var bit in this)
                {
                    hashCode += 42 * bit.GetHashCode();
                }
            }
            return hashCode;
        }
    }
}
