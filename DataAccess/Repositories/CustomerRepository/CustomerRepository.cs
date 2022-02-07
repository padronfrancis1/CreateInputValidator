using DataAccess.Repositories.RepositoryBase;
using DomainModel;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Repositories.CustomerRepository
{
    public class CustomerRepository : Repository<Customer> , ICustomerRepository
    {
        public CustomerRepository(FrancoContext context) : base(context)
        { }

        public override IQueryable<Customer> FullQuery
        {
            get
            {
                return Context.Set<Customer>();
            }
        }

        public override IQueryable<Customer> SearchQuery => FullQuery;

        public override DbSet<Customer> MinimalQuery => Context.Set<Customer>();
    }
}
