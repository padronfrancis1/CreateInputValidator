using DomainModel;
using System.Configuration;
using System.Data.Entity;

namespace DataAccess
{
    public class FrancoContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public FrancoContext() : base(nameOrConnectionString: ConfigurationManager.ConnectionStrings["FrancoContext"].ConnectionString)
        {
        }
    }
}
