namespace DoubleNumberOccurancesInSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    class DoubleNumberOccurancesInSequence
    {
        static void Main()
        {
            double[] array = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            Dictionary<double, int> numberApperiance = new Dictionary<double, int>();
            
            foreach (var item in array)
            {
                if (numberApperiance.ContainsKey(item))
                {
                    numberApperiance[item]++;
                }
                else
                {
                    numberApperiance.Add(item, 1);
                }
            }

            foreach (var number in numberApperiance.Keys)
            {
                Console.WriteLine("{0} -> {1} times", number, numberApperiance[number]);
            }
        }
    }
}
