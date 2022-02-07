using System;
using Unity;
using WinApp;

namespace ViewModelTest
{

    public abstract class ViewModelTestBase<T> : MyTestBase where T : class
    {
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
            WinApp.App.test = "test2";
            base.Setup();
        }

    }
}
