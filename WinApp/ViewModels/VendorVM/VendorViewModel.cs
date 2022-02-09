using DataAccess;
using DataAccess.Repositories.RepositoryBase;
using DomainModel;

namespace WinApp.ViewModels.VendorVM
{
    public class VendorViewModel : CreateEditBaseViewModel<Vendor>
    {
        public VendorViewModel(IDataGateway dataGateway) : base(dataGateway)
        {
            //ViewCaption = "Customer Window";
        }

        protected override IRepository<Vendor> Repository { get => _dataGateway.VendorRepository; }

        public override void Initialize()
        {
            Item = new Vendor();
        }

        public override void Load(int id)
        {
            Item = new Vendor() { ID = id, Name = "Vendor 009"};
        }
    }
}