namespace DataAccessObject
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Text;
    using Northwind;

    class DataAccessObject
    {
        static void Main()
        {
            //InsertCustomer("Pesho", "Rakiya Ood");
            //UpdateCustomer("Pesho");
            //RemoveCustomer("Pesho");
            //var customers1 = GetCustomersWhoHaveOrdersMadeIn1997AndShippedToCanada();
            //PrintCustomers(customers1);
            //var customers2 = GetCustomersWhoHaveOrdersMadeIn1997AndShippedToCanadaFullSqlQuery();
            //PrintCustomers(customers2);
            //var sales = GetSales("SP", new DateTime(1996, 8, 2), new DateTime(2004, 12, 22));
            //PrintSales(sales);
            //CreateNortwindTwin();
            //TwoDataContextProblem();
            TestEmployeeTeritory();
        }

        private static void TestEmployeeTeritory()
        {
            Employee employee = new Employee();

            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                employee = northwindEntities.Employees.Find(1);

                foreach (var entityTerritory in employee.EntityTerritories)
                {
                    Console.WriteLine("Teritory id: {0}", entityTerritory.TerritoryID);
                    Console.WriteLine("Teritory description: {0}", entityTerritory.TerritoryDescription);
                }
            }
        }

        private static void TwoDataContextProblem()
        {
            using (NorthwindEntities dbCon1 = new NorthwindEntities())
            {
                using (NorthwindEntities dbCon2 = new NorthwindEntities())
                {
                    var customer1 = GetCustomerById(dbCon1, "Pesho");
                    var customer2 = GetCustomerById(dbCon2, "Pesho");
                    customer1.City = "Sofia";
                    customer2.City = "Varna";
                    dbCon1.SaveChanges();
                    dbCon2.SaveChanges();
                }
            }
        }

        private static void PrintCustomers(IEnumerable<Customer> customers)
        {
            StringBuilder output = new StringBuilder();

            foreach (var customer in customers)
            {
                output.AppendLine(string.Format("Customer id: {0}", customer.CustomerID));
                output.AppendLine(string.Format("Company name: {0} ", customer.CompanyName));
                output.AppendLine();
            }

            output.AppendLine(string.Format("Total customers count: {0}\n", customers.Count()));
            Console.WriteLine(output);
        }

        static void InsertCustomer(string customerId, string companyName, string contactName = null,
            string contactTitle = null, string address = null, string city = null, string region = null,
            string postalCode = null, string country = null, string phone = null, string fax = null)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                throw new ArgumentException("Customer id is empty or is null");
            }
            if (string.IsNullOrEmpty(companyName))
            {
                throw new ArgumentException("Company name is empty or is null");
            }
            Customer customer = new Customer
            {
                CustomerID = customerId,
                CompanyName = companyName,
                ContactName = contactName,
                ContactTitle = contactTitle,
                Address = address,
                City = city,
                Region = region,
                PostalCode = postalCode,
                Country = country,
                Phone = phone,
                Fax = fax
            };

            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                northwindEntities.Customers.Add(customer);
                try
                {
                    northwindEntities.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.InnerException.InnerException.Message);
                }
            }
        }

        private static void UpdateCustomer(string customerId)
        {
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                var customer = GetCustomerById(northwindEntities, customerId);
                Console.Write("New company name: ");
                string companyName = Console.ReadLine();
                if (string.IsNullOrEmpty(companyName))
                {
                    throw new ArgumentException("Company name is empty or is null");
                }
                customer.ContactName = ChangeCustomerField("contact name");
                customer.ContactTitle = ChangeCustomerField("contact title");
                customer.Address = ChangeCustomerField("address");
                customer.City = ChangeCustomerField("city");
                customer.Region = ChangeCustomerField("region");
                customer.PostalCode = ChangeCustomerField("postal code");
                customer.Country = ChangeCustomerField("country");
                customer.Phone = ChangeCustomerField("phone");
                customer.Fax = ChangeCustomerField("fax");
                northwindEntities.SaveChanges();
            }
        }

        private static string ChangeCustomerField(string fieldName)
        {
            Console.Write("Enter new " + fieldName + ": ");
            string newFieldValue = Console.ReadLine();
            if (string.IsNullOrEmpty(newFieldValue))
            {
                return null;
            }
            return newFieldValue;
        }

        private static void RemoveCustomer(string customerId)
        {
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                var customer = GetCustomerById(northwindEntities, customerId);
                northwindEntities.Customers.Remove(customer);
                northwindEntities.SaveChanges();
            }
        }

        static Customer GetCustomerById(NorthwindEntities northwindEntities, string customerId)
        {
            Customer customer = northwindEntities.Customers.FirstOrDefault(
                c => c.CustomerID == customerId);
            return customer;
        }

        private static IEnumerable<Customer> GetCustomersWhoHaveOrdersMadeIn1997AndShippedToCanada()
        {
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                var customers =
                               from c in northwindEntities.Customers
                               join o in northwindEntities.Orders on c.CustomerID equals o.CustomerID
                               where o.ShipCountry == "Canada" &&
                                     o.ShippedDate.Value.Year == 1997
                               orderby c.CustomerID
                               select c;
                return customers.ToList();
            }
        }

        private static IEnumerable<CustomerIdAndCompanyName> GetCustomersWhoHaveOrdersMadeIn1997AndShippedToCanadaFullSqlQuery()
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            string nativeSqlQuery =
                @"SELECT c.CustomerID as CustomerID, c.CompanyName as CompanyName
                FROM Orders o
                    JOIN Customers c
                        ON o.CustomerID = c.CustomerID
                WHERE o.ShipCountry = {0} AND YEAR(o.ShippedDate) = {1}
                ORDER BY c.CustomerID";

            object[] parameters = { "Canada", 1997 };
            var customers = northwindEntities.Database.SqlQuery<CustomerIdAndCompanyName>(nativeSqlQuery, parameters);

            return customers;
        }

        private static IEnumerable<Sale> GetSales(string region, DateTime startDate, DateTime endDate)
        {
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                var sales =
                           from o in northwindEntities.Orders
                           join d in northwindEntities.Order_Details on o.OrderID equals d.OrderID
                           join p in northwindEntities.Products on d.ProductID equals p.ProductID
                           where o.ShipRegion == region &&
                                 startDate < o.OrderDate &&
                                 o.OrderDate < endDate
                           select new Sale
                           {
                               OrderId = o.OrderID,
                               ProductId = p.ProductID,
                               ProductName = p.ProductName
                           };

                return sales.ToList();
            }
        }

        private static void PrintSales(IEnumerable<Sale> sales)
        {
            StringBuilder output = new StringBuilder();

            if (sales.Count() == 0)
            {
                output.AppendLine("No sales");

                return;
            }

            foreach (var sale in sales)
            {
                output.AppendLine(string.Format("Order id: {0}", sale.OrderId));
                output.AppendLine(string.Format("Product id: {0}", sale.ProductId));
                output.AppendLine(string.Format("Product name: {0}", sale.ProductName));
                output.AppendLine();
            }

            Console.WriteLine(output);
        }

        private static void CreateNortwindTwin()
        {
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                StringBuilder dbScript = new StringBuilder();
                dbScript.Append("USE NorthwindTwin ");

                string generatedScript =
                    ((IObjectContextAdapter)northwindEntities).ObjectContext.CreateDatabaseScript();
                dbScript.Append(generatedScript);
                northwindEntities.Database.ExecuteSqlCommand("CREATE DATABASE NorthwindTwin");
                northwindEntities.Database.ExecuteSqlCommand(dbScript.ToString());
            }
        }
    }
}