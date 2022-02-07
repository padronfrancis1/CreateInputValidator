using DomainModel;

namespace WinApp.ViewModels.VendorVM
{
    public class VendorViewModel : BaseViewModel<Vendor>
    {
        public VendorViewModel()
        {
            BuilCommands();

            ViewCaption = "Customer Window";
        }

        public override void Initialize()
        {
            Item = new Vendor();
        }

        public override void Load(int id)
        {
            Item = new Vendor() { Name = "Vendor 007"};
        }
    }
}