using DataAccess;
using DataAccess.Repositories.RepositoryBase;
using DomainModel;

namespace WinApp.ViewModels.CustomerVM
{
    public class CustomerViewModel : CreateEditBaseViewModel<Customer>
    {
        public CustomerViewModel(IDataGateway dataGateway) : base(dataGateway)
        {
        }
        protected override IRepository<Customer> Repository { get => _dataGateway.CustomerRepository; }

        public override void Initialize()
        {
            Item = new Customer();
        }

        public override void Load(int id)
        {
            Item = Repository.Get(id);
        }
    }
}