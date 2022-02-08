using DomainModel;
using System.Configuration;
using System.Data.Entity;

namespace DataAccess
{
    public class FrancoContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public FrancoContext() : base(nameOrConnectionString: ConfigurationManager.ConnectionStrings["FrancoContext"].ConnectionString)
        {
        }
    }
}
