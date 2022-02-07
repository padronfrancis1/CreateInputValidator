using Prism.Events;
using System;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using WinApp.Events;

namespace WinApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IUnityContainer MyUnityContainer007 { get; set; }

        public static IEventAggregator EventAggregator;

        public static WindowController WindowControllerInstance;

        static App()
        {
            MyUnityContainer007 = new UnityContainer007();
            EventAggregator = new EventAggregator007();
            WindowControllerInstance = new WindowController(EventAggregator);
        }

        public static Func<IUnityContainer, Task> ConfigureContainer { get; set; }
    }
}
