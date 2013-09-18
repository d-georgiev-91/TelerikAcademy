namespace HashTableDemo
{
    using System;
    using HashTable;

    class HashTableDemo
    {
        static void Main()
        {
            HashTable<int, string> hashTable = new HashTable<int, string>();
            hashTable.Add(1, "Ivan");
            hashTable.Add(9, "Pesho");
            hashTable.Add(10, "Stamat");
            hashTable.Add(11, "Gosho");
            hashTable.Add(12, "Tisho");
            hashTable.Add(13, "Mincho");
            hashTable.Add(14, "Petar");
            hashTable.Add(15, "Pencho");
            hashTable.Add(16, "Gesho");

            string itemAtPosition = hashTable.Find(15);
            Console.WriteLine(itemAtPosition);
            Console.WriteLine(hashTable[1]);
            hashTable[12] = "Pesho";
            Console.WriteLine(hashTable[12]);
            var keys = hashTable.Keys;

            foreach (var key in keys)
            {
                Console.Write(key + " ");
            }

            Console.WriteLine();

            hashTable.Remove(12);

            foreach (var item in hashTable)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("The count of content is {0}", hashTable.Count);

            hashTable.Clear();

            foreach (var item in hashTable)
            {
                Console.WriteLine("Proof it's empty: " + item);
            }
        }
    }
}