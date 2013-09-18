namespace ATM.Client
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Transactions;
    using ATM.Data;

    static class Client
    {
        static void Main()
        {
            WidthdrawMoney("9792110867", "1234", 321);
        }

        private static void WidthdrawMoney(string cardNumber, string cardPin, decimal cardCash)
        {
            if (cardCash <= 0)
            {
                throw new ArgumentException(cardCash + " is invalid sum");
            }

            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.RepeatableRead,
                Timeout = new TimeSpan(0, 0, 0, 10)
            };
            
            using (var transaction = new TransactionScope(TransactionScopeOption.RequiresNew, transactionOptions))
            {
                var atmEntities = new ATMEntities();
                
                var cardAccount = GetCardAccount(cardNumber, atmEntities);
                ValidatePin(cardAccount, cardPin);

                if ((cardAccount.CardCash ?? 0) < cardCash)
                {
                    throw new ArgumentException("No enough cash in card");
                }

                cardAccount.CardCash = cardAccount.CardCash - cardCash;
                atmEntities.SaveChanges();
                transaction.Complete();
                // Според мен е по-добре да се пази Id-то на aкаунта отколкото номера на карата.
                AddTransactionToHistory(cardAccount.CardAccountId, cardCash);
            }

            Console.WriteLine("Successfuly widthdrawed {0} money", cardCash);
        }

        private static void AddTransactionToHistory(int cardAccount, decimal cardCash)
        {
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.RepeatableRead,
                Timeout = new TimeSpan(0, 0, 0, 10)
            };

            using (var scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                var transaction = new TransactionsHistory()
                {
                    CardAccountId = cardAccount,
                    TransactionDate = DateTime.Now,
                    Ammount = cardCash
                };

                var atmEntities = new ATMEntities();
                atmEntities.TransactionsHistories.Add(transaction);

                atmEntities.SaveChanges();

                scope.Complete();
            }
        }
  
        private static void ValidatePin(CardAccount cardAccount, string cardPin)
        {
            if (cardAccount.CardPIN != cardPin)
            {
                throw new ArgumentException("Wrong card PIN");
            }
        }
  
        private static CardAccount GetCardAccount(string cardNumber, ATMEntities atmEntities)
        {
            var cardAccount = atmEntities.CardAccounts
                                         .Where(c => c.CardNumber == cardNumber)
                                         .FirstOrDefault();
            if (cardAccount == null)
            {
                throw new ArgumentException("Invalid card number " + cardNumber);
            }

            return cardAccount;
        }
    }
}