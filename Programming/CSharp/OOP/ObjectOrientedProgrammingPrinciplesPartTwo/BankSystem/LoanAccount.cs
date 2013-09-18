using System;
using System.Linq;

namespace BankSystem
{
    public class LoanAccount : Account, IDepositable
    {
        public LoanAccount(Customer accountOwner, decimal balance, decimal interestRate, int periodInMonths)
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
            if (this.AccountOwner is Individual)
            {
                if (periodInMonths < 3)
                {
                    return 0;
                }
                else
                {
                    return base.CalculateInterest(periodInMonths-3);
                }
            }
            else
            {
                if (PeriodInMonths < 2)
                {
                    return 0;
                }
                else
                {
                    return base.CalculateInterest(periodInMonths - 2);
                }
            }
        }
    }
}
