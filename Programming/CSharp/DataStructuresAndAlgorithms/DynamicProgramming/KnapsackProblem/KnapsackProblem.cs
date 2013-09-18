namespace KnapsackProblem
{
    using System;
    using System.Collections.Generic;

    class KnapsackProblem
    {
        static void Main()
        {
            List<Product> products = new List<Product>()
            {
                new Product("beer", 3, 2),
                new Product("vodka", 8, 12),
                new Product("cheese", 4, 5),
                new Product("nuts", 1, 4),
                new Product("ham", 2, 3),
                new Product("whiskey", 8, 13),
            };
            Knapsack knapsack = new Knapsack(10);
            knapsack.FillWithBestProducts(products);
        }
    }
}