using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception;
using WinApp.Events;
using WinApp.ViewModels.CustomerVM;

namespace ViewModelTest.CustomerVMTest
{
    public abstract class MyTestBase
    {
        protected EventAggregator007 _eventAggregator;
        protected IUnityContainer _container;
        protected static IUnityContainer _startContainer;


        static MyTestBase()
        {
            _startContainer = new UnityContainer();
            _startContainer.AddNewExtension<Interception>();
        }
        internal virtual void Setup()
        {
            _container = _startContainer.RegisterType<CustomerViewModel>();

            //App.ConfigureContainer = (container) =>
            //{
            //    container.RegisterInstance<IEventAggregator>(_eventAggregator);
            //    return Task.CompletedTask;
            //};
            //_eventAggregator = new EventAggregator007();
            ////Thread.CurrentPrincipal = null;

            //// By default give us access to everything so we can test it
            //App.MyUnityContainer007 = _container;
            //App.EventAggregator = _eventAggregator;
        }
    }
}
