using DomainModel;
using WinApp.Commands;
using WinApp.Events;

namespace WinApp.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            BuildCommands();
        }

        private void BuildCommands()
        {
            // Button Click will hit here
            AddCustomerCommand = BuildAddRelayCommand<Customer>();
            OpenCustomerCommand = BuildOpenRelayCommand<Customer>();

            AddVendorCommand = BuildAddRelayCommand<Vendor>();
            OpenVendorCommand = BuildOpenRelayCommand<Vendor>();

            AddUserCommand = BuildAddRelayCommand<User>();
            OpenUserCommand = BuildAddRelayCommand<User>();

        }

        private RelayCommand BuildAddRelayCommand<T>() where T : DomainObject
        {
            return new RelayCommand(x =>
            {
                App.EventAggregator.GetEvent<AddItemRequestedEvent<T>>().Publish(null);
            });
        }
        private RelayCommand BuildOpenRelayCommand<T>() where T : DomainObject
        {
            return new RelayCommand(x =>
            {
                App.EventAggregator.GetEvent<OpenItemRequestedEvent<T>>().Publish(new OpenItemRequestedEventArgs<T>() { ID = 1 });
            });
        }

        public RelayCommand AddCustomerCommand { get; set; }
        public RelayCommand OpenCustomerCommand { get; set; }

        public RelayCommand AddVendorCommand { get; set; }
        public RelayCommand OpenVendorCommand { get; set; }

        public RelayCommand AddUserCommand { get; set; }
        public RelayCommand OpenUserCommand { get; set; }
    }
}
