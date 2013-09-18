using System;
using System.Linq;

namespace BankSystem
{
    public class Company : Customer
    {
        public Company(string name, int id, string address, int phone):
            base(name, id, address, phone)
        {

        }
    }
}
