namespace KnapsackProblem
{
    using System;
    using System.Collections.Generic;

    public class Knapsack
    {
        private int capacity;

        private int[,] combinations;
        private List<Product> products;

        public Knapsack(int capacity)
        {
            this.Capacity = capacity;
        }

        public void FillWithBestProducts(List<Product> products)
        {
            combinations = new int[products.Count, this.Capacity + 1];
            this.products = new List<Product>(products);
            Console.WriteLine("The optimal cost is {0}",FillWithBestProducts(products.Count - 1, this.capacity, products));
        }

        public int FillWithBestProducts(int currentIndex, int capacity, List<Product> products)
        {
            int put,dontPut;

            put = dontPut = 0;

            if (combinations[currentIndex, capacity] != 0)
            {
                return combinations[currentIndex, capacity];
            }

            if (currentIndex == 0)
            {
                if (products[0].Weight <= capacity)
                {
                    combinations[currentIndex, capacity] = products[0].Cost;

                    return products[0].Cost;
                }
                else
                {
                    combinations[currentIndex, capacity] = 0;

                    return 0;
                }
            }

            if (products[currentIndex].Weight <= capacity)
            {
                put = products[currentIndex].Cost + 
                    FillWithBestProducts(currentIndex - 1, capacity - products[currentIndex].Weight, products);
            }

            dontPut = FillWithBestProducts(currentIndex - 1, capacity, products);

            combinations[currentIndex, capacity] = Math.Max(put, dontPut);

            return combinations[currentIndex, capacity];
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                if (value < 1 || value > 500)
                {
                    throw new ArgumentException("Value should be in range [1, 500]");
                }

                this.capacity = value;
            }
        }
    }
}