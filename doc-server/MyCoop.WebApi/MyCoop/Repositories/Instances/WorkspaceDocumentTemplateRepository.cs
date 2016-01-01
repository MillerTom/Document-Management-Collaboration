using System.Data.Entity;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class WorkspaceDocumentTemplateRepository : RepositoryBase<WorkspaceDocumentTemplate>, IWorkspaceDocumentTemplateRepository
    {
        public WorkspaceDocumentTemplateRepository(CoopEntities context) : base(context)
        {
        }

        protected override DbSet<WorkspaceDocumentTemplate> ObjectSet
        {
            get { return Context.WorkspaceDocumentTemplates; }
        }
    }
}