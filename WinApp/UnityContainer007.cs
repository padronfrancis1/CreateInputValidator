using DataAccess;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Windows;
using Unity;
using WinApp.ViewModels;
using WinApp.ViewModels.CustomerVM;
using WinApp.ViewModels.UserVM;
using WinApp.ViewModels.ValidationVM;
using WinApp.ViewModels.VendorVM;
using WinApp.Views.CustomerUI;
using WinApp.Views.UserUI;
using WinApp.Views.ValidationUI;
using WinApp.Views.VendorUI;

namespace WinApp
{
    public class UnityContainer007 : UnityContainer
    {
        private static readonly Dictionary<Type, Type> _viewModelWindowDictionary;
        private static readonly Dictionary<Type, Type> _modelViewModelDictionary;

        static UnityContainer007()
        {
            _viewModelWindowDictionary = new Dictionary<Type, Type>();
            _modelViewModelDictionary = new Dictionary<Type, Type>();
        }

        public UnityContainer007() : base()
        {
            /// Map Create Edit Class to View Models
            MapModelToViewModel<ICreateEditBaseViewModel<Customer>, CustomerViewModel>();
            MapModelToViewModel<ICreateEditBaseViewModel<Vendor>, VendorViewModel>();
            MapModelToViewModel<ICreateEditBaseViewModel<User>, UserViewModel>();

            /// Map List Class to View Models
            MapModelToViewModel<IListBaseViewModel<User>, UserListViewModel>();
            MapModelToViewModel<IListBaseViewModel<Customer>, CustomerListViewModel>();
            MapModelToViewModel<IListBaseViewModel<Vendor>, VendorListViewModel>();

            /// Map Create Edit Class to Window
            MapViewModelToView<ICreateEditBaseViewModel<Customer>, CustomerWindow>();
            MapViewModelToView<ICreateEditBaseViewModel<Vendor>, VendorWindow>();
            MapViewModelToView<ICreateEditBaseViewModel<User>, UserWindow>();

            /// Map List Class to List View
            MapViewModelToView<IListBaseViewModel<User>, UserListViewModelWindow>();
            MapViewModelToView<IListBaseViewModel<Customer>, CustomerListViewModelWindow>();
            MapViewModelToView<IListBaseViewModel<Vendor>, VendorListViewModelWindow>();

            /// Register View Model and Windows
            this.RegisterType<IDataGateway, DataGateway>();

            this.RegisterType<UserListViewModelWindow>();
            this.RegisterType<CustomerListViewModelWindow>();
            this.RegisterType<VendorListViewModelWindow>();

            this.RegisterType<CustomerViewModel>();
            this.RegisterType<CustomerWindow>();

            this.RegisterType<VendorViewModel>();
            this.RegisterType<VendorWindow>();

            this.RegisterType<UserViewModel>();
            this.RegisterType<UserWindow>();

            this.RegisterType<ValidationViewModel>();
            this.RegisterType<ValidationWindow>();
        }

        public void MapViewModelToView<TViewModel, TView>()
        {
            _viewModelWindowDictionary[typeof(TViewModel)] = typeof(TView);
        }

        public void MapModelToViewModel<TModel, TViewModel>()
        {
            _modelViewModelDictionary[typeof(TModel)] = typeof(TViewModel);
        }

        public static Window ResolveWindow<T>(IUnityContainer container)
        {
            return (Window)container.Resolve(_viewModelWindowDictionary[typeof(T)]);
        }

        public static IBaseViewModel ResolveViewModel<T>(IUnityContainer container) // >> WE TOLD IT TO GET THE IBASEVIEWMODEL WHERE METHOD LOAD IS AVAILABLE
        {
            return (IBaseViewModel)container.Resolve(_modelViewModelDictionary[typeof(T)]);
        }

        public static T ReturnNewInstance<T>(IUnityContainer container) // >> THIS WILL TAKE THE DOMAINOBJECT WHERE METHOD LOAD IS NOT AVAIALABLE
        {
            T instance = (T)container.Resolve(_modelViewModelDictionary[typeof(T)]);
            return instance;
        }
    }
}
