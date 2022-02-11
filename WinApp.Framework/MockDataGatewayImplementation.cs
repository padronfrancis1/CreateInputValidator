using DataAccess.Repositories.CustomerRepository;
using DataAccess.Repositories.UserRepository;
using DataAccess.Repositories.VendorRepository;
using System;

namespace WinApp.Framework
{
    public class MockDataGatewayImplementation : IReadOnlyDataGateway
    {
        public virtual MockDataGateway MockDataGateway { get; set; }

        public virtual ICustomerRepository CustomerRepository => MockDataGateway.MockCustomerRepository.Object;

        public IUserRepository UserRepository { get; }

        public IVendorRepository VendorRepository { get; }

        public virtual void Dispose()
        {
        }

        public virtual void SaveChanges()
        {
        }
    }
}
