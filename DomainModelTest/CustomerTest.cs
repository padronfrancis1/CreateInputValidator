using DomainModel;
using DomainModel.Helpers;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace DomainModelTest
{
    public class CustomerTest
    {
        [Fact]
        public void TestNameIsNotNull_IsValid()
        {
            Customer c = new Customer();
            c.Name = "Francis";
            Assert.Equal(c.GetErrors(nameof(Customer.Name)), string.Empty);
        }

        [Fact]
        public void TestNameIsNull_IsNotValid()
        {
            Customer c = new Customer();
            c.Name = null;

            string expectedErrorMessage = ValidationAttributeHelper.GetErrorMessageForProperty(
                typeof(Customer), typeof(RequiredAttribute), nameof(Customer.Name));

            Assert.Contains(c.GetErrors(nameof(Customer.Name)).Cast<string>().ToList(), a => a.Contains(expectedErrorMessage));
        }
    }
}
