using System.Data.Entity;
using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class DocumentTaskRepository : RepositoryBase<DocumentTask>, IDocumentTaskRepository
    {
        public DocumentTaskRepository(CoopEntities context) : base(context)
        {
        }

        protected override DbSet<DocumentTask> ObjectSet
        {
            get { return Context.DocumentTasks; }
        }

        public Task<DocumentTask> GetValue(int id, params string[] includes)
        {
            return GetEntities(includes).SingleAsync(entity => entity.Id == id);
        }
    }
}