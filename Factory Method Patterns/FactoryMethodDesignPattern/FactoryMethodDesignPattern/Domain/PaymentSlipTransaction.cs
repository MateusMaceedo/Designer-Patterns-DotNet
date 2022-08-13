using FactoryMethodDesignPattern.Domain.Base;
using FactoryMethodDesignPattern.Domain.ValueObj;
using System;

namespace FactoryMethodDesignPattern.Domain
{
    public sealed class PaymentSlipTransaction : TransactionBase
    {
        public string DocumentNumber { get; }
        public string BarCode { get; }
        public DateTime DueDate { get; }

        public PaymentSlipTransaction(double amount, string documentNumber, string barCode, DateTime dueDate)
            : base(TransactionType.PaymentSlip, amount)
        {
            DocumentNumber = documentNumber;
            BarCode = barCode;
            DueDate = dueDate;
        }
    }
}
