using System.Data.Entity;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class IncidentOrgUnitRepository : RepositoryBase<IncidentOrgUnit>, IIncidentOrgUnitRepository
    {
        public IncidentOrgUnitRepository(CoopEntities context) : base(context)
        {
        }

        protected override DbSet<IncidentOrgUnit> ObjectSet
        {
            get { return Context.IncidentOrgUnits; }
        }
    }
}