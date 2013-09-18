using System;
using System.Collections.Generic;
using System.IO;

namespace SortListOfNames
{
    class SortListOfNames
    {
        static void Main()
        {
            StreamReader unsortedList = new StreamReader("UnsortedList.txt");
            string line;
            List<string> names = new List<string>();
            while ((line = unsortedList.ReadLine()) != null)
            {
                names.Add(line);
            }
            unsortedList.Close();
            names.Sort();
            StreamWriter sortedList = new StreamWriter("SortedList.txt");
            foreach (var name in names)
            {
                if (name == names[names.Count - 1])
                {
                    sortedList.WriteLine(name);   
                }
                else
                {
                    sortedList.Write(name);   
                }
            }
            sortedList.Close();
        }
    }
}
