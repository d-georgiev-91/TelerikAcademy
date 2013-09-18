using System;
using System.Text;

namespace BankSystem
{
    public abstract class Customer
    {
        private string name;
        private int id;
        private string address;
        private int phone;

        public Customer(string name, int id, string address, int phone)
        {
            this.Name = name;
            this.Id = id;
            this.Address = address;
            this.Phone = phone;
        }

        public int Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                this.phone = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public override string ToString()
        {
            StringBuilder customerToString = new StringBuilder();
            customerToString.AppendLine("Name: " + this.Name);
            customerToString.AppendLine("Id: " + this.Id);
            customerToString.AppendLine("Address: " + this.Address);
            customerToString.AppendLine("Phone: " + this.Phone);
            return customerToString.ToString();
        }
    }
}