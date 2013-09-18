namespace KnapsackProblem
{
    using System;
    using System.Text;

    public class Product
    {
        private int weight;
        private int cost;

        public Product(string name, int weight, int cost)
        {
            this.Name = name;
            this.Weight = weight;
            this.Cost = cost;
        }

        public override string ToString()
        {
            StringBuilder productAsString = new StringBuilder();
            productAsString.AppendFormat("{0} - weight: {1} - cost: {2}", this.Name, this.Weight, this.Cost);

            return productAsString.ToString();
        }

        public string Name { get; set; }

        public int Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value < 1 || value > 500)
                {
                    throw new ArgumentException("Value should be in range [1, 500]");
                }

                this.weight = value;
            }
        }

        public int Cost
        {
            get
            {
                return this.cost;
            }
            set
            {
                if (value < 1 || value > 500)
                {
                    throw new ArgumentException("Value should be in range [1, 500]");
                }

                this.cost = value;
            }
        }
    }
}