namespace RecoverMessage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class RecoverMessage
    {

        static SortedSet<string> result = new SortedSet<string>();

        static void Swap(ref char a, ref char b)
        {
            if (a == b)
                return;
            a ^= b;
            b ^= a;
            a ^= b;
        }

        static void SetPermutation(char[] list)
        {
            int x = list.Length - 1;
            Go(list, 0, x);
        }

        static void Go(char[] list, int k, int m)
        {
            int i;
            if (k == m)
            {
                StringBuilder asdf = new StringBuilder();
                foreach (var chrasr in list)
                {
                    asdf.Append(chrasr);
                }
                result.Add(asdf.ToString());
            }
            else
            {
                for (i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    Go(list, k + 1, m);
                    Swap(ref list[k], ref list[i]);
                }
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> lines = new List<string>();

            for (int i = 0; i < n; i++)
            {
                lines.Add(Console.ReadLine());
            }

            SortedSet<char> word = new SortedSet<char>();

            foreach (var line in lines)
            {
                foreach (var character in line)
                {
                    word.Add(character);
                }
            }

            char[] chars = word.ToArray();

            SetPermutation(chars);

            foreach (var item in result)
            {
                Console.WriteLine(item);
                break;
            }
        }
    }
}