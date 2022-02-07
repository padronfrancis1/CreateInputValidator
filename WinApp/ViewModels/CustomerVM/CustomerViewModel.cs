using DomainModel;

namespace WinApp.ViewModels.CustomerVM
{
    public class CustomerViewModel : BaseViewModel<Customer>
    {
        public CustomerViewModel()
        {
            BuilCommands();

            ViewCaption = "Customer Window";
        }

        public override void Initialize()
        {
            Item = new Customer();
        }

        public override void Load(int id)
        {
            Item = new Customer()
            {
                ID = id,
                Name = "Francis",
            };
        }
    }
}