using System.Data.Entity;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class IncidentUserRepository : RepositoryBase<IncidentUser>, IIncidentUserRepository
    {
        public IncidentUserRepository(CoopEntities context) : base(context)
        {
        }

        protected override DbSet<IncidentUser> ObjectSet
        {
            get { return Context.IncidentUsers; }
        }
    }
}