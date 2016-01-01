using System.Data.Entity;
using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class WorkflowRepository : RepositoryBase<Workflow>, IWorkflowRepository
    {
        public WorkflowRepository(CoopEntities context)
            : base(context)
        {
        }

        protected override DbSet<Workflow> ObjectSet
        {
            get { return Context.Workflows; }
        }

        public Task<Workflow> GetValue(int id, params string[] includes)
        {
            return GetEntities(includes).SingleAsync(entity => entity.Id == id);
        }
    }
}