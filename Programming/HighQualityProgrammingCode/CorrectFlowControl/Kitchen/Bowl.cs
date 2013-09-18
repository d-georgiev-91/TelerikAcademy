using System;

namespace Kitchen
{
    class Bowl 
    {
        public void Add(Vegetable vegetable)
        {
            string vegetableType = vegetable.GetType().ToString().Replace("Kitchen.", String.Empty);
            Console.WriteLine("{0} added to the bowl...", vegetableType);
        }
    }
}