using DomainModel;
using Prism.Events;
using System;
using System.Windows;
using Unity;
using WinApp.Events;
using WinApp.ViewModels;
using WinApp.ViewModels.CustomerVM;
using WinApp.ViewModels.ValidationVM;
using WinApp.Views.ValidationUI;

namespace WinApp
{
    public partial class App : Application
    {
        public class WindowController : IDisposable
        {
            public void Dispose()
            {
            }

            private readonly IEventAggregator _eventAggregator;

            private void SubscribeToStandardEvents<T>() where T : DomainObject
            {
                _eventAggregator.GetEvent<AddItemRequestedEvent<T>>().Subscribe(OnAddItemRequested, true);
                _eventAggregator.GetEvent<OpenItemRequestedEvent<T>>().Subscribe(OpenItemRequested, true);
            }

            private void OnValidationErrorRequested(ValidationEventArgs args)
            {
                var vm = App.MyUnityContainer007.Resolve<ValidationViewModel>();
                var window = App.MyUnityContainer007.Resolve<ValidationWindow>();
                vm.Item = args;
                vm.Window = window;
                window.DataContext = vm;
                window.ShowDialog();
            }

            public WindowController(IEventAggregator eventAggregator)
            {
                _eventAggregator = eventAggregator;

                _eventAggregator.GetEvent<ShowValidationErrorRequestedEvent>().Subscribe(OnValidationErrorRequested, true);

                SubscribeToStandardEvents<Customer>();
                SubscribeToStandardEvents<Vendor>();
                SubscribeToStandardEvents<User>();
            }

            private void OnAddItemRequested<T>(AddItemRequestedEventArgs<T> args) where T : DomainObject
            {
                // Whenever there is a resolve - it goes to the class or a new instane of class if there is any
                var vm = UnityContainer007.ResolveViewModel<T>(App.MyUnityContainer007);
                var window = UnityContainer007.ResolveWindow<IBaseViewModel<T>>(App.MyUnityContainer007);
                vm.Initialize();
                vm.Window = window;
                window.DataContext = vm;
                window.ShowDialog();
            }

            private void OpenItemRequested<T>(OpenItemRequestedEventArgs<T> args) where T : DomainObject
            {
                var vm = UnityContainer007.ResolveViewModel<T>(App.MyUnityContainer007);
                var window = UnityContainer007.ResolveWindow<IBaseViewModel<T>>(App.MyUnityContainer007);
                vm.Window = window;
                vm.Load(args.ID);
                window.DataContext = vm;
                window.ShowDialog();
            }
        }
    }
}
