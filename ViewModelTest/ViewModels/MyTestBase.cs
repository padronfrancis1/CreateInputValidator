using Moq;
using Prism.Events;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;
using WinApp.Events;
using WinApp;

namespace ViewModelTest
{
    public abstract class MyTestBase
    {
        protected EventAggregator007 _eventAggregator;
        protected IUnityContainer _container;
        protected static IUnityContainer _startContainer;


        static MyTestBase()
        {
            _startContainer = new UnityContainer();
            _startContainer.AddNewExtension<Unity.Interception.Interception>();
        }
        internal virtual void Setup()
        {
            _container = _startContainer.CreateChildContainer();
            WinApp.App.test = "test2";

            //App.ConfigureContainer = (container) =>
            //{
            //    container.RegisterInstance<Prism.Events.IEventAggregator>(_eventAggregator);
            //    return Task.CompletedTask;
            //};
            _eventAggregator = new EventAggregator007();
            System.Threading.Thread.CurrentPrincipal = null;
            
            //// By default give us access to everything so we can test it
            //App.ConfigureContainer(_container).Wait();
            //App.MyUnityContainer007 = _container;
            //App.EventAggregator = _eventAggregator;
        }
    }
}
