using DataAccess;
using DataAccess.Repositories.RepositoryBase;
using DomainModel;

namespace WinApp.ViewModels.CustomerVM
{
    public class CustomerViewModel : BaseViewModel<Customer>
    {
        public CustomerViewModel(IDataGateway dataGateway) : base(dataGateway)
        {
            BuilCommands();

            ViewCaption = "Customer Window";
        }

        protected override IRepository<Customer> Repository { get => _dataGateway.CustomerRepository; }

        public override void Initialize()
        {
            Item = new Customer();
        }

        public override void Load(int id)
        {
            Item = new Customer()
            {
                ID = id,
                Name = "Customer",
            };
        }
    }
}