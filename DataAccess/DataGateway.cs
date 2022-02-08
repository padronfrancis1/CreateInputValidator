using DataAccess.Repositories.CustomerRepository;
using DataAccess.Repositories.UserRepository;
using DataAccess.Repositories.VendorRepository;

namespace DataAccess
{
    public class DataGateway : IDataGateway
    {
        private FrancoContext _dataContext;

        public DataGateway()
        {
            _dataContext = new FrancoContext();
        }

        public void Dispose()
        {
            _dataContext?.Dispose();
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }

        private ICustomerRepository _customerRepository;
        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(_dataContext);
                }
                return _customerRepository;
            }
            private set
            {
                _customerRepository = value;
            }
        }

        private IUserRepository _userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_dataContext);
                }
                return _userRepository;
            }
            private set
            {
                _userRepository = value;
            }
        }

        private IVendorRepository _vendorRepository;
        public IVendorRepository VendorRepository
        {
            get
            {
                if (_vendorRepository == null)
                {
                    _vendorRepository = new VendorRepository(_dataContext);
                }
                return _vendorRepository;
            }
            private set
            {
                _vendorRepository = value;
            }
        }
    }

}

