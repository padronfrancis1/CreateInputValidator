using DataAccess.Repositories.CustomerRepository;
using DomainModel;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp.Framework
{
    public class MockDataGateway : Mock<MockDataGatewayImplementation>
    {
        public IEnumerable<Customer> Customers { get; set; }
        private readonly Dictionary<Type, object> _mockDictionary = new Dictionary<Type, object>();
        public MockDataGateway() 
        {
            this.Setup(x => x.MockDataGateway).Returns(this);
            base.CallBase = true;
            MockCustomerRepository.Setup(x => x.GetAll()).Returns(Customers);
        }

        public Mock<T> GetMockRepository<T>() where T : class
        {
            var returnType = typeof(Mock<T>);
            var tType = typeof(T);
            if (!_mockDictionary.TryGetValue(returnType, out object repository))
            {
                var constructor = returnType.GetConstructor(Type.EmptyTypes);
                repository = constructor.Invoke(null);
                _mockDictionary.Add(returnType, repository);
            }
            return (Mock<T>)repository;
        }
        public Mock<ICustomerRepository> MockCustomerRepository => GetMockRepository<ICustomerRepository>();
    }
}
