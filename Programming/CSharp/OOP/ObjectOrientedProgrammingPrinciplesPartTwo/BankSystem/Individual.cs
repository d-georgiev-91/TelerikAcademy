using System;
using System.Linq;

namespace BankSystem
{
    public class Individual : Customer
    {
        public Individual(string name, int id, string address, int phone):
            base(name, id, address, phone)
        {

        }
    }
}
