using DataAccess;
using DomainModel;
using System;

namespace WinApp.Framework.ViewModels.CustomerVMTest
{
    public class CustomerVMTest : MyViewModelTestBase<Customer>
    {
        public CustomerVMTest(IDataGateway dataGateway) : base(dataGateway)
        {
            base.Setup(() =>
            {
                Console.WriteLine("Initializing test");
            });
        }
    }
}