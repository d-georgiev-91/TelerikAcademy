namespace ProductSearch
{
    using System;
    using System.Text;

    public class Product : IComparable
    {
        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public int CompareTo(object obj)
        {
            var product = obj as Product;

            if (product == null)
            {
                string exceptionMessage = string.Format("Cannot comapare {0} with {1}", this.GetType(), obj.GetType());
                throw new ArgumentException(exceptionMessage);
            }

            return this.Price.CompareTo(product.Price);
        }

        public override string ToString()
        {
            StringBuilder productAsString = new StringBuilder();
            productAsString.Append("Name: ");
            productAsString.Append(this.Name);
            productAsString.Append(" Price: ");
            productAsString.Append(string.Format("{0:C}", this.Price));

            return productAsString.ToString();
        }

        public string Name { get; private set; }
        
        public double Price { get; private set; }
    }
}