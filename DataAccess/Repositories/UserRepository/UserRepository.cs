using DataAccess.Repositories.RepositoryBase;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.UserRepository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(FrancoContext context) : base(context) { }
        public override IQueryable<User> FullQuery
        {

            get
            {
                return Context.Set<User>();
            }

        }
        public override IQueryable<User> SearchQuery => FullQuery;

        public override DbSet<User> MinimalQuery => Context.Set<User>();
    }
}
