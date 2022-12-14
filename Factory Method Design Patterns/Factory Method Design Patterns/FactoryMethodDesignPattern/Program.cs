using FactoryMethodDesignPattern.Domain;
using FactoryMethodDesignPattern.Domain.ValueObj;
using FactoryMethodDesignPattern.Manager.Factory;
using System;

namespace FactoryMethodDesignPattern
{
    public class Program
    {
        private static void Main(string[] args)
        {
            #region CreditCard Transaction

            var creditCardTransactionProcessor =
                TransactionProcessorFactory.CreateTransactionProcessor(TransactionType.CreditCard);

            var creditCardTransaction = new CreditCardTransaction(
                1000, "Joe Satriani", "222", "1111222233334444");

            var creditCardTransactionInfo = creditCardTransactionProcessor.Authorize(creditCardTransaction);

            Console.WriteLine($"{creditCardTransactionInfo.Amount} | {creditCardTransactionInfo.CreateDate:g} | " +
                              $"{creditCardTransactionInfo.TransactionKey} | {creditCardTransactionInfo.TransactionStatusType}");

            #endregion

            #region Debit Transaction

            var debitTransactionProcessor =
                TransactionProcessorFactory.CreateTransactionProcessor(TransactionType.Debit);

            var debitTransaction = new DebitTransaction(1300, "Banco Itaú");

            var debitTransactionInfo = debitTransactionProcessor.Authorize(debitTransaction);

            Console.WriteLine($"{debitTransactionInfo.Amount} | {debitTransactionInfo.CreateDate:g} | " +
                              $"{debitTransactionInfo.TransactionKey} | {debitTransactionInfo.TransactionStatusType}");

            #endregion
        }
    }
}
