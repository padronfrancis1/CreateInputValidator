using Moq;
using Prism.Events;
using System;
using System.Threading;
using System.Threading.Tasks;
using Unity;
using Unity.Interception;
using WinApp;
using WinApp.Events;
using WinApp.ViewModels;
using WinApp.ViewModels.CustomerVM;
using Xunit;

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
            //_startContainer.AddNewExtension<Interception>();
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

    public abstract class ViewModelTestBase<T> : MyTestBase where T : CustomerViewModel
    {
        protected T _vm;

        protected void ResolveVM()
        {
            _vm = _container.Resolve<T>();
        }

        internal override void Setup()
        {
            base.Setup();
        }
        internal virtual void Setup(Action a)
        {
            Setup();
            ResolveVM();
        }

    }

    public class CustomerVMTest : ViewModelTestBase<CustomerViewModel>
    {
        public CustomerVMTest()
        {
            base.Setup(() =>
            {
                Console.WriteLine("Initializing test");
            });
        }
        [Fact]
        public void TestInitialize()
        {
            _vm.Initialize();
            Assert.Equal(0, _vm.Item.ID);
        }
        [Fact]
        public void TestLoad()
        {
            _vm.Load(1);
            Assert.Equal(1, _vm.Item.ID);
        }
    }
}
