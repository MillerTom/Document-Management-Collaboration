using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class WorkspaceTemplateRepository : RepositoryBase<WorkspaceTemplate>, IWorkspaceTemplateRepository
    {
        public WorkspaceTemplateRepository(CoopEntities context) : base(context)
        {
        }

        protected override DbSet<WorkspaceTemplate> ObjectSet
        {
            get { return Context.WorkspaceTemplates; }
        }

        public Task<WorkspaceTemplate> GetValue(int id, params string[] includes)
        {
            return GetEntities(includes).SingleAsync(entity => entity.Id == id);
        }

        public Task Delete(int id)
        {
            return Task.Run(() => Context.DeleteWorkspaceTemplate(id));
        }
    }
}