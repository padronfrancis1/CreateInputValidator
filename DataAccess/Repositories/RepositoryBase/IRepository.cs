using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Repositories.RepositoryBase
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Add(T item);
        void Remove(T item);
    }
}
