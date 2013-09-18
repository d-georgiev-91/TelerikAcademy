using System;
using System.Text;

namespace BankSystem
{
    public abstract class Account
    {
        private Customer accountOwner;
        private decimal balance;
        private decimal interestRate;
        private int periodInMonths;

        public Account(Customer accountOwner, decimal balance, decimal interestRate, int periodInMonths)
        {
            this.accountOwner = accountOwner;
            this.Balance = balance;
            this.InterestRate = interestRate;
            this.PeriodInMonths = periodInMonths;
        }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }
            set
            {
                this.interestRate = value;
            }
        }

        public int PeriodInMonths
        {
            get
            {
                return this.periodInMonths;
            }
            set
            {
                this.periodInMonths = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                this.balance = value;
            }
        }

        public Customer AccountOwner
        {
            get
            {
                return this.accountOwner;
            }
        }

        public virtual decimal CalculateInterest(int periodInMonts)
        {
            return this.interestRate * periodInMonths;
        }

        public override string ToString()
        {
            StringBuilder accoutToString = new StringBuilder();
            accoutToString.AppendLine(this.AccountOwner.GetType().ToString().Replace("BankSystem.", String.Empty));
            accoutToString.AppendLine(this.AccountOwner.ToString());
            accoutToString.AppendLine(String.Format("Balance: {0:c}", this.Balance));
            accoutToString.AppendLine(String.Format("Interest rate: {0:p}", this.InterestRate/100));
            accoutToString.AppendLine("Period in months: " + this.PeriodInMonths);
            return accoutToString.ToString();
        }
    }
}
