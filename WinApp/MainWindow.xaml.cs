using DomainModel;
using System.Windows;
using WinApp.Events;
using Unity;
using WinApp.ViewModels;

namespace WinApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var vm = App.MyUnityContainer007.Resolve<MainViewModel>();
            DataContext = vm;
            InitializeComponent();
        }
    }
}
