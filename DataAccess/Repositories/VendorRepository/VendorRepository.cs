using DataAccess.Repositories.RepositoryBase;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.VendorRepository
{
    public class VendorRepository : Repository<Vendor>, IVendorRepository
    {
        public VendorRepository(FrancoContext context) : base(context) { }
        public override IQueryable<Vendor> FullQuery
        {
            get
            {
                return Context.Set<Vendor>();
            }
        }

        public override IQueryable<Vendor> SearchQuery => throw new NotImplementedException();

        public override DbSet<Vendor> MinimalQuery => Context.Set<Vendor>();
    }
}
