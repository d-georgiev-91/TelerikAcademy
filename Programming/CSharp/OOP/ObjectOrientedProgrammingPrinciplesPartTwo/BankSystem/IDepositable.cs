using System;
using System.Linq;

namespace BankSystem
{
    public interface IDepositable
    {
        void Deposit(decimal amountOfMoney);
    }
}
