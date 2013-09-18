using System;
using System.Linq;

namespace BankSystem
{
    public class MortageAccount : Account, IDepositable
    {
        public MortageAccount(Customer accountOwner, decimal balance, decimal interestRate, int periodInMonths)
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

        public override decimal CalculateInterest(int periodInMonths)
        {

            if (this.AccountOwner is Company)
            {
                if (PeriodInMonths < 12)
                {
                    return base.CalculateInterest(periodInMonths);
                }
                else
                {
                    return (base.CalculateInterest(periodInMonths) - base.CalculateInterest(periodInMonths - 12) / 2) + base.CalculateInterest(periodInMonths - 12);
                }
            }
            else
            {
                if (PeriodInMonths < 6)
                {
                    return base.CalculateInterest(periodInMonths);
                }
                else
                {
                   return base.CalculateInterest(periodInMonths - 6);
                }
            }
        }
    }
}
