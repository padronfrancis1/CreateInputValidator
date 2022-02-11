using DataAccess;
using DataAccess.Repositories.CustomerRepository;
using DomainModel;
using Moq;
using System;

namespace WinApp.Framework.ViewModels.CustomerVMTest
{
    public class CustomerVMTest : MyViewModelTestBase<Customer>
    {
        internal override void Setup()
        {
            base.Setup();
            _dataGateway.GetMockRepository<ICustomerRepository>().Setup(x => x.Get(1)).Returns(new Customer() { ID = 1, Name = "Name"});
        }
    }
}