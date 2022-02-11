using DataAccess;
using DomainModel;
using System.Threading.Tasks;
using Unity;
using WinApp.Events;
using WinApp.ViewModels;
using WinApp.ViewModels.CustomerVM;
using WinApp.ViewModels.UserVM;
using WinApp.ViewModels.VendorVM;

namespace WinApp.Framework.ViewModels
{
    public abstract class MyTestBase
    {
        protected EventAggregator007 _eventAggregator;
        protected IUnityContainer _container;
        protected static IUnityContainer _startContainer;
        protected MockDataGateway _dataGateway;

        static MyTestBase()
        {
            _startContainer = new UnityContainer();
        }
        internal virtual void Setup()
        {
            _container = _startContainer.CreateChildContainer();
            App.ConfigureContainer = (container) =>
            {
                container.RegisterInstance<Prism.Events.IEventAggregator>(_eventAggregator);
                container.RegisterInstance<IReadOnlyDataGateway>(_dataGateway.Object);
                container.RegisterInstance<IDataGateway>(_dataGateway.Object);
                container.RegisterType<CreateEditBaseViewModel<Customer>, CustomerViewModel>();
                container.RegisterType<CreateEditBaseViewModel<Vendor>, VendorViewModel>();
                container.RegisterType<CreateEditBaseViewModel<User>, UserViewModel>();
                return Task.CompletedTask;
            };
            _eventAggregator = new EventAggregator007();
            _dataGateway = new MockDataGateway();
            System.Threading.Thread.CurrentPrincipal = null;

            App.ConfigureContainer(_container).Wait();
            App.MyUnityContainer007 = _container;
            App.EventAggregator = _eventAggregator;
        }
    }
}
