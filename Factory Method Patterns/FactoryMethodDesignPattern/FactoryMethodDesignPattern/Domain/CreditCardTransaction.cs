using FactoryMethodDesignPattern.Domain.Base;
using FactoryMethodDesignPattern.Domain.ValueObj;

namespace FactoryMethodDesignPattern.Domain
{
    public sealed class CreditCardTransaction : TransactionBase
    {
        public string HolderName { get; }
        public string SecurityCode { get; }
        public string CardNumber { get; }

        public CreditCardTransaction(double amount, string holderName, string securityCode, string cardNumber)
            : base(TransactionType.CreditCard, amount)
        {
            HolderName = holderName;
            SecurityCode = securityCode;
            CardNumber = cardNumber;
        }
    }
}
