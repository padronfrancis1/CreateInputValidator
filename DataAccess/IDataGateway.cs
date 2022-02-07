using DataAccess.Repositories.CustomerRepository;
using System;

namespace DataAccess
{
    public interface IDataGateway : IDisposable
    {
        void SaveChanges();
        ICustomerRepository CustomerRepository { get; }
        //IQuoteRepository QuoteRepository { get; }
    }
}