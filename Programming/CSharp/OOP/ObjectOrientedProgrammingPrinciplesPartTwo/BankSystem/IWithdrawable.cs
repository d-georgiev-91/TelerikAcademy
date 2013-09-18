using System;
using System.Linq;

namespace BankSystem
{
    public interface IWithdrawable
    {
        void Withdraw(decimal amountOfMoney);
    }
}
