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
