using FactoryMethodDesignPattern.Domain;
using FactoryMethodDesignPattern.Domain.Base;

namespace FactoryMethodDesignPattern.Manager.Processors.Interfaces
{
    public interface ITransactionProcessor
    {
        TransactionInfo Authorize(TransactionBase transaction);
    }
}
