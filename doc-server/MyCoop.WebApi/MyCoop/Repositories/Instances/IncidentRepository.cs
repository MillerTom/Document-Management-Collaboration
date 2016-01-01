using System.Data.Entity;
using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class IncidentRepository : RepositoryBase<Incident>, IIncidentRepository
    {
        public IncidentRepository(CoopEntities context) : base(context)
        {
        }

        protected override DbSet<Incident> ObjectSet
        {
            get { return Context.Incidents; }
        }

        public Task<Incident> GetValue(int id, params string[] includes)
        {
            return GetEntities(includes).SingleAsync(entity => entity.Id == id);
        }

        public Task Delete(int id)
        {
            return Task.Run(() => Context.DeleteIncident(id));
        }
    }
}