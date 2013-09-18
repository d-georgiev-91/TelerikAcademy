using System;

namespace BankSystem
{
    class BankMain
    {
        static void Main()
        {
            LoanAccount loanAccountIndividual = new LoanAccount(
            new Individual("Pesho", 24214, "gfdfsdfsdfsd", 4215125), 4214, 12, 55);
            Console.WriteLine(loanAccountIndividual);
            Console.WriteLine("Account interest for {0} months - {1}", loanAccountIndividual.PeriodInMonths, loanAccountIndividual.CalculateInterest(loanAccountIndividual.PeriodInMonths));
            loanAccountIndividual.Deposit(3000);
            Console.WriteLine(loanAccountIndividual);

            //LoanAccount loanAccountCompany = new LoanAccount(
            //new Company("IBM", 52214, "das dasas ", 6664125), 4464, 15, 10);
            //Console.WriteLine(loanAccountCompany);
            //Console.WriteLine("Account interest for {0} months - {1}", loanAccountCompany.PeriodInMonths, loanAccountCompany.CalculateInterest(loanAccountCompany.PeriodInMonths));
            //loanAccountCompany.Deposit(3000);
            //Console.WriteLine(loanAccountCompany);

            //DepositAccount depositAccountIndividual = new DepositAccount(
            //new Individual("Pencho", 321412, "gfdfsdfs412dfsd", 421421), 4124, 50, 13);
            //Console.WriteLine(depositAccountIndividual);
            //Console.WriteLine("Account interest for {0} months - {1}", depositAccountIndividual.PeriodInMonths, depositAccountIndividual.CalculateInterest(depositAccountIndividual.PeriodInMonths));
            //depositAccountIndividual.Deposit(3000);
            //Console.WriteLine(depositAccountIndividual);
            //depositAccountIndividual.Withdraw(300);
            //Console.WriteLine(depositAccountIndividual);

            //DepositAccount depositAccountCompany = new DepositAccount(
            //new Company("Mozilla", 94218421, "dsda sd a", 3234), 241241, 17, 4);
            //Console.WriteLine(depositAccountCompany);
            //Console.WriteLine("Account interest for {0} months - {1}", depositAccountCompany.PeriodInMonths, depositAccountCompany.CalculateInterest(depositAccountCompany.PeriodInMonths));
            //depositAccountCompany.Deposit(3030);
            //Console.WriteLine(depositAccountCompany);
            //depositAccountCompany.Withdraw(100);
            //Console.WriteLine(depositAccountCompany);

            //MortageAccount mortageAccountIndividual = new MortageAccount(
            //new Individual("Stamat", 64514, "sad sa sdfsd", 4446875), 1614, 5, 10);
            //Console.WriteLine(mortageAccountIndividual);
            //Console.WriteLine("Account interest for {0} months - {1}", mortageAccountIndividual.PeriodInMonths, mortageAccountIndividual.CalculateInterest(mortageAccountIndividual.PeriodInMonths));
            //mortageAccountIndividual.Deposit(200);
            //Console.WriteLine(mortageAccountIndividual);

            //MortageAccount mortageAccountCompany = new MortageAccount(
            //new Individual("M$", 24214, "gfdfsdfsdfsd", 6466425), 4664, 2, 11);
            //Console.WriteLine(mortageAccountCompany);
            //Console.WriteLine("Account interest for {0} months - {1}", mortageAccountCompany.PeriodInMonths, mortageAccountCompany.CalculateInterest(mortageAccountCompany.PeriodInMonths));
            //mortageAccountCompany.Deposit(320);
            //Console.WriteLine(mortageAccountCompany);
        }
    }
}
