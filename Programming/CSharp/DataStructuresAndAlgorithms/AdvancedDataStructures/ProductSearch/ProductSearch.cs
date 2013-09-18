namespace ProductSearch
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class ProductSearch
    {
        public static double GetRandomDouble(double min, double max)
        {
            Random random = new Random();

            return random.NextDouble() * (max - min) + min;
        }

        public static void Main()
        {
            OrderedBag<Product> products = new OrderedBag<Product>();

            FillRandomProducts(products);

            double from = 200;
            double to = 500;

            var firstTwentyInRange = GetFirstTwentyInRange(products, from, to);

            foreach (var product in firstTwentyInRange)
            {
                Console.WriteLine(product);
            }
        }
  
        private static void FillRandomProducts(OrderedBag<Product> products)
        {
            Console.WriteLine("Generating 500000 random products with random prices...");
            for (int i = 1; i <= 500000; i++)
            {
                string name = "product #" + i;
                double price = GetRandomDouble(0, 10000);
                products.Add(new Product(name, price));
            }
        }

        private static List<Product> GetFirstTwentyInRange(OrderedBag<Product> products, double from, double to)
        {
            if (from > to || to < from)
            {
                throw new ArgumentException(string.Format("Invalid range [{0}, {1}]", from, to));
            }

            var matchedProducst = products.Range(new Product("match", from), true, new Product("match", to), true);

            if (matchedProducst.Count == 0)
            {
                return null;    
            }

            List<Product> firstTwentyProducts = new List<Product>();

            for (int i = 0; i < 20; i++)
            {
                if (i >= matchedProducst.Count)
                {
                    break;
                }

                firstTwentyProducts.Add(matchedProducst[i]);
            }

            return firstTwentyProducts;
        }
    }
}
