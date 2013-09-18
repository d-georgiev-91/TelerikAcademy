using System;
using System.Linq;

namespace BankSystem
{
    public class DepositAccount : Account, IDepositable, IWithdrawable
    {
        public DepositAccount(Customer accountOwner, decimal balance, decimal interestRate, int periodInMonths)
            : base(accountOwner, balance, interestRate, periodInMonths)
        {

        }

        public void Deposit(decimal amountOfMoney)
        {
            if (amountOfMoney > 0)
            {
                this.Balance += amountOfMoney;
            }
            else
            {
                throw new ArgumentException("You have nothing to deposit.");
            }
        }

        public void Withdraw(decimal amountOfMoney)
        {
            if (amountOfMoney > this.Balance)
            {
                throw new ArgumentException("You want to withdraw more money than you have.");
            }
            else
            {
                this.Balance -= amountOfMoney;
            }
        }
        public override decimal CalculateInterest(int periodInMonts)
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0;
            }
            else
            {
                return base.CalculateInterest(periodInMonts);
            }
        }
    }
}
