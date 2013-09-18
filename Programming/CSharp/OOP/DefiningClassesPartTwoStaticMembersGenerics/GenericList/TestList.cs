using System;

namespace GenericList
{
    class TestList
    {
        static void Main()
        {
            GenericList<int> intList = new GenericList<int>(1);
            intList[0] = 1;
            intList.AddItem(5);
            intList.AddItem(315);
            intList.AddItem(515);
            intList.AddItem(4);
            
            Console.WriteLine(intList.ToString());
            intList.RemoveItemAtIndex(3);
            Console.WriteLine(intList.ToString());
            intList.InsertItemAtIndex(15,3);
            Console.WriteLine(intList.ToString());
            Console.WriteLine(intList.Max());
            Console.WriteLine(intList.Min());
            GenericList<double> doubleList = new GenericList<double>(1);


            GenericList<string> stringList = new GenericList<string>(1);
        }
    }
}
