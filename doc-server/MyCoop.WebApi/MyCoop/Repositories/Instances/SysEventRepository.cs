using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class SysEventRepository : RepositoryBase<SysEvent>, ISysEventRepository
    {
        public SysEventRepository(CoopEntities context) : base(context)
        {
        }

        protected override DbSet<SysEvent> ObjectSet
        {
            get { return Context.SysEvents; }
        }

        public Task<SysEvent[]> GetValues(int type, DateTime startTime, params string[] includes)
        {
            return GetEntities(includes).Where(se => se.Type == type && se.Time > startTime).OrderByDescending(se => se.Time).ToArrayAsync();
        }
    }
}