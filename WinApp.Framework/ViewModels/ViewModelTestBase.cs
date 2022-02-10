using System;
using Unity;
using WinApp.Events;
using WinApp.ViewModels;
using Xunit;
using DomainModel;
using DataAccess;

namespace WinApp.Framework.ViewModels
{
    public abstract class ViewModelTestBase<T> : MyTestBase where T : class
    {
        protected IDataGateway _dataGateway { get; set; }
        public ViewModelTestBase(IDataGateway dataGateway)
        {
            _dataGateway = dataGateway;
        }
        protected T _vm;
        internal virtual void Setup(Action additionalSetup)
        {
            Setup(additionalSetup, null);
        }

        internal virtual void Setup(Action additionalSetup, Action postResolveSetup)
        {
            Setup();
            additionalSetup?.Invoke();
            ResolveVM();
            postResolveSetup?.Invoke();
        }

        protected void ResolveVM()
        {
            _vm = _container.Resolve<T>();
        }

        internal override void Setup()
        {
            base.Setup();
        }

    }

    public abstract class MyViewModelTestBase<T> : ViewModelTestBase<CreateEditBaseViewModel<T>>
        where T : DomainObject
    {

        public MyViewModelTestBase(IDataGateway dataGateway) : base(dataGateway)
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

        [Fact]
        public void TestSaveCommand_ItemValid()
        {
            bool eventFired = false;
            _eventAggregator.GetEvent<ShowValidationErrorRequestedEvent>().Subscribe(arg =>
            {
                eventFired = true;
            });
            _vm.Load(1);
            Assert.True(_vm.Item.IsValid);
            _vm.SaveCommand.Execute(null);
            Assert.False(eventFired);
        }

        [Fact]
        public void TestSaveCommand_ItemNotValid()
        {
            bool eventFired = false;
            _vm.Initialize();
            Assert.False(_vm.Item.IsValid);
            App.EventAggregator.GetEvent<ShowValidationErrorRequestedEvent>().Subscribe(arg =>
            {
                eventFired = true;
            }, true);
            _vm.SaveCommand.Execute(null);
            Assert.True(eventFired);
        }
    }
}
