using System;
using System.Linq;

namespace BiDicitionaryDemo
{
    class BiDicitionaryDemo
    {
        static void Main()
        {
            BiDictionary<string, string, string> biDictionary = new BiDictionary<string, string, string>();
            biDictionary.Add("Ivan", "Plovdiv", "Rabotnik");
            biDictionary.Add("Ivan", "Kaspichan", "Bezraboten");
            biDictionary.Add("Mimi", "Mezdra", "Feq");

            biDictionary.RemoveByFirstKey("Mimi");

            Console.WriteLine(biDictionary.Count);
            foreach (Tuple<string, string> keysPair in biDictionary.Keys)
            {
                Console.WriteLine("{0}, {1}, {2}", keysPair.Item1, keysPair.Item2, biDictionary[keysPair]);
            }
        }
    }
}
