using System.Data.Entity;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class WorkspaceTemplateComponentRepository : RepositoryBase<WorkspaceTemplateComponent>, IWorkspaceTemplateComponentRepository
    {
        public WorkspaceTemplateComponentRepository(CoopEntities context) : base(context)
        {
        }

        protected override DbSet<WorkspaceTemplateComponent> ObjectSet
        {
            get { return Context.WorkspaceTemplateComponents; }
        }
    }
}