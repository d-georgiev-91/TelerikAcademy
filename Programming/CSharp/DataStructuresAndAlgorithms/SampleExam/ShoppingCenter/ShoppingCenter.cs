namespace ShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using System.Threading;
    using Wintellect.PowerCollections;

    public class Product : IComparable<Product>
    {
        public Product(string name, decimal price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
            this.NameAndProducer = name + ";" + producer;
        }
        
        public int CompareTo(Product product)
        {
            int comparisonResult = this.Name.CompareTo(product.Name);

            if (comparisonResult == 0)
            {
                comparisonResult = this.Producer.CompareTo(product.Producer);
            }

            if (comparisonResult == 0)
            {
                comparisonResult = this.Price.CompareTo(product.Price);
            }

            return comparisonResult;
        }

        public override string ToString()
        {
            return "{" + this.Name + ";" + this.Producer + ";" + this.Price.ToString("0.00") + "}";
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Producer { get; set; }

        public string NameAndProducer { get; set; }
    }

    class ShoppingCenter
    {
        static List<string> commands;
        static StringBuilder commandsStatus = new StringBuilder();

        static MultiDictionary<string, Product> productsByName = new MultiDictionary<string, Product>(true);
        static MultiDictionary<string, Product> productsByProducer = new MultiDictionary<string, Product>(true);
        static MultiDictionary<string, Product> productsByNameAndProducer = new MultiDictionary<string, Product>(true);
        static OrderedMultiDictionary<decimal, Product> productsByPrice = new OrderedMultiDictionary<decimal, Product>(true);

        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            InputCommands();
            ExecuteCommands();
            Console.Write(commandsStatus);
        }
  
        private static void InputCommands()
        {
            int commandsCount = int.Parse(Console.ReadLine());
            commands = new List<string>(commandsCount);

            for (int i = 0; i < commandsCount; i++)
            {
                commands.Add(Console.ReadLine());
            }
        }

        private static void ExecuteCommands()
        {
            foreach (var command in commands)
            {
                ExecuteCommand(command);
            }
        }

        private static void ExecuteCommand(string command)
        {
            string commandIdetifier = command.Substring(0, command.IndexOf(' '));
            string commandArguments = command.Substring(command.IndexOf(' ') + 1);

            string status = string.Empty;

            switch (commandIdetifier)
            {
                case "AddProduct":
                    status = AddProduct(commandArguments);
                    break;
                case "DeleteProducts":
                    status = DeleteProducts(commandArguments);
                    break;
                case "FindProductsByName":
                    status = FindProductsByName(commandArguments);
                    break;
                case "FindProductsByPriceRange":
                    status = FindProductsByPriceRange(commandArguments);
                    break;
                case "FindProductsByProducer":
                    status = FindProductsByProducer(commandArguments);
                    break;
                default:
                    status = "Error";
                    throw new ArgumentException("Invalid command " + command);
            }

            commandsStatus.AppendLine(status);
        }

        private static string AddProduct(string commandArguments)
        {
            var arguments = commandArguments.Split(';');
            string name = arguments[0];
            decimal price = decimal.Parse(arguments[1]);
            string producer = arguments[2];
            Product product = new Product(name, price, producer);

            productsByName.Add(product.Name, product);
            productsByProducer.Add(product.Producer, product);
            productsByPrice.Add(product.Price, product);
            productsByNameAndProducer.Add(product.NameAndProducer, product);

            return "Product added";
        }

        private static string DeleteProducts(string commandArguments)
        {
            var arguments = commandArguments.Split(';');
            string status = string.Empty;
            
            switch (arguments.Length)
            {
                case 1:
                    status = DeleteProductsByProducer(arguments[0]);
                    break;
                case 2:
                    status = DeleteProductsByNameAndProducer(arguments[0], arguments[1]);
                    break;
                default:
                    throw new ArgumentException("Invalid arguments " + commandArguments);
            }

            return status;
        }

        private static string DeleteProductsByProducer(string producer)
        {
            string status = string.Empty;

            if (!productsByProducer.ContainsKey(producer))
            {
                status = "No products found";
            }
            else
            {
                var productsToRemove = productsByProducer[producer];

                foreach (var product in productsToRemove)
                {
                    productsByName.Remove(product.Name, product);
                    productsByPrice.Remove(product.Price, product);
                    productsByNameAndProducer.Remove(product.NameAndProducer, product);
                }

                int removedProductsCount = productsToRemove.Count;
                productsByProducer.Remove(producer);

                status = removedProductsCount + " products deleted";
            }

            return status;
        }

        private static string DeleteProductsByNameAndProducer(string name, string producer)
        {
            string status = string.Empty;
            string nameAndProducer = name + ";" + producer;
            
            if (!productsByNameAndProducer.ContainsKey(nameAndProducer))
            {
                status = "No products found";
            }
            else
            {
                var productsToRemove = productsByNameAndProducer[nameAndProducer];

                foreach (var product in productsToRemove)
                {
                    productsByName.Remove(name, product);
                    productsByPrice.Remove(product.Price, product);
                    productsByProducer.Remove(producer, product);
                }

                int removedProductsCount = productsToRemove.Count;
                productsByNameAndProducer.Remove(nameAndProducer);

                status = removedProductsCount + " products deleted";
            }

            return status;
        }

        private static string FindProductsByName(string name)
        {
            string status = string.Empty;

            if (!productsByName.ContainsKey(name))
            {
                status = "No products found";
            }
            else
            {
                var productsFound = productsByName[name];
                status = SortProducts(productsFound);
            }

            return status;
        }

        private static string FindProductsByProducer(string producer)
        {
            string status = string.Empty;

            if (!productsByProducer.ContainsKey(producer))
            {
                status = "No products found";
            }
            else
            {
                var productsFound = productsByProducer[producer];
                status = SortProducts(productsFound);
            }

            return status;
        }

        private static string FindProductsByPriceRange(string range)
        {
            var rangeBounds = range.Split(';');
            string from = rangeBounds[0];
            string to = rangeBounds[1];

            decimal rangeStart = decimal.Parse(from);
            decimal rangeEnd = decimal.Parse(to);
            var productsFound = productsByPrice.Range(rangeStart, true, rangeEnd, true).Values;
            string status = string.Empty;
            
            if (productsFound.Count == 0)
            {
                status = "No products found";
            }
            else
            {
                status = SortProducts(productsFound);
            }

            return status;
        }

        private static string SortProducts(ICollection<Product> products)
        {
            List<Product> sortedProducts = new List<Product>(products);
            sortedProducts.Sort();
            StringBuilder sortedProductsAsString = new StringBuilder();

            foreach (var product in sortedProducts)
            {
                sortedProductsAsString.AppendLine(product.ToString());
            }

            return sortedProductsAsString.ToString().TrimEnd();
        }
    }
}