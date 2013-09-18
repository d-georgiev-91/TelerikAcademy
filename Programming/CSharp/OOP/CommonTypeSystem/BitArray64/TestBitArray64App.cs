using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitArray64
{
    class TestBitArray64App
    {
        static void Main()
        {
            BitArray64 bitArray = new BitArray64(2);
            foreach (var bit in bitArray)
            {
                Console.Write(bit);
            }
            Console.WriteLine();
            Console.WriteLine(bitArray[1]);

            BitArray64 arr1 = new BitArray64(34);
            BitArray64 arr2 = new BitArray64(345);
            BitArray64 arr3 = new BitArray64(34);

            Console.WriteLine("arr1 == arr2 {0}", (arr1 == arr2));
            Console.WriteLine("arr1 == arr2 {0}", (arr1 == arr3));
            Console.WriteLine("arr3 hash code {0}", arr3.GetHashCode());
        }
    }
}
