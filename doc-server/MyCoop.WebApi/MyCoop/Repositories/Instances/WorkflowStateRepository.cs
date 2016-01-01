using System.Data.Entity;
using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class WorkflowStateRepository : RepositoryBase<WorkflowState>, IWorkflowStateRepository
    {
        public WorkflowStateRepository(CoopEntities context) : base(context)
        {
        }

        protected override DbSet<WorkflowState> ObjectSet
        {
            get { return Context.WorkflowStates; }
        }

        public Task<WorkflowState> GetValue(int id, params string[] includes)
        {
            return GetEntities(includes).SingleAsync(entity => entity.Id == id);
        }
    }
}