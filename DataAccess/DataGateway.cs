using DataAccess.Repositories.CustomerRepository;

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

        //private IQuoteRepository _quoteRepository;
        //public IQuoteRepository QuoteRepository
        //{
        //    get
        //    {
        //        if (_quoteRepository == null)
        //        {
        //            _quoteRepository = new QuoteRepository(_dataContext);
        //        }
        //        return _quoteRepository;
        //    }
        //    private set
        //    {
        //        _quoteRepository = value;
        //    }
        //}
    }
}
