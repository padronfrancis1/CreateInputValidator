using DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Repositories.RepositoryBase
{
    public abstract class Repository<T> : IRepository<T> where T : DomainObject
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public abstract IQueryable<T> FullQuery { get; }

        public abstract IQueryable<T> SearchQuery { get; }

        public abstract DbSet<T> MinimalQuery { get; }

        // Interface
        public void Add(T item)
        {
            MinimalQuery.Add(item);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return FullQuery.Where(predicate);
        }

        public T Get(int id)
        {
            return FullQuery.FirstOrDefault(f => f.ID == id);
        }

        public IEnumerable<T> GetAll()
        {
            return SearchQuery.ToList();
        }

        public void Remove(T item)
        {
            MinimalQuery.Remove(item);
        }
    }
}
