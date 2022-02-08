using DataAccess.Repositories.CustomerRepository;
using DataAccess.Repositories.UserRepository;
using DataAccess.Repositories.VendorRepository;
using System;

namespace DataAccess
{
    public interface IDataGateway : IDisposable
    {
        void SaveChanges();
        ICustomerRepository CustomerRepository { get; }
        IUserRepository UserRepository { get; }
        IVendorRepository VendorRepository { get; }
    }
}