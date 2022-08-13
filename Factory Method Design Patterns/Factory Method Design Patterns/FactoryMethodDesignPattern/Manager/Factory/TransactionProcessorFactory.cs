using FactoryMethodDesignPattern.Domain.ValueObj;
using FactoryMethodDesignPattern.Manager.Processors;
using FactoryMethodDesignPattern.Manager.Processors.Interfaces;
using System;

namespace FactoryMethodDesignPattern.Manager.Factory
{
    public static class TransactionProcessorFactory
    {
        public static ITransactionProcessor CreateTransactionProcessor(TransactionType transactionType)
        {
            switch (transactionType)
            {
                case TransactionType.CreditCard: return new CrediCardTransactionProcessor();
                case TransactionType.Debit: return new DebitTransactionProcessor();
                case TransactionType.PaymentSlip: return new PaymentSlipTransactionProcessor();

                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}
