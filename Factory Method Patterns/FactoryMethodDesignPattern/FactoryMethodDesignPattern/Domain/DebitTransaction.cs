using FactoryMethodDesignPattern.Domain.Base;
using FactoryMethodDesignPattern.Domain.ValueObj;

namespace FactoryMethodDesignPattern.Domain
{
    public sealed class DebitTransaction : TransactionBase
    {
        public string BankName { get; }

        public DebitTransaction(double amount, string bankName) : base(TransactionType.Debit, amount)
        {
            BankName = bankName;
        }
    }
}
