using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected RepositoryBase(CoopEntities context)
        {
            Context = context;
        }

        protected CoopEntities Context { get; private set; }

        protected abstract DbSet<T> ObjectSet { get; }

        public void Add(T value)
        {
            ObjectSet.Add(value);
        }

        public void Attach(T value)
        {
            ObjectSet.Attach(value);
        }

        public void Delete(T value)
        {
            ObjectSet.Remove(value);
        }

        public Task<T[]> GetValues(params string[] includes)
        {
            return GetEntities(includes).ToArrayAsync();
        }

        protected IQueryable<T> GetEntities(params string[] includes)
        {
            return Include(includes);
        }

        private DbQuery<T> Include(string[] names, int index = 0)
        {
            if (index >= names.Length)
            {
                return ObjectSet;
            }
            return Include(names, index + 1).Include(names[index]);
        }
    }
}
