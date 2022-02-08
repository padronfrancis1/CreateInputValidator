using DataAccess.Repositories.RepositoryBase;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.UserRepository
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
