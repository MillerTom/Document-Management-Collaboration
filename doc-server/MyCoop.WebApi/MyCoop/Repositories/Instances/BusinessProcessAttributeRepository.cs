using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class BusinessProcessAttributeRepository : RepositoryBase<BusinessProcessAttribute>, IBusinessProcessAttributeRepository
    {
        public BusinessProcessAttributeRepository(CoopEntities context) : base(context)
        {
        }

        protected override DbSet<BusinessProcessAttribute> ObjectSet
        {
            get { return Context.BusinessProcessAttributes; }
        }

        public Task<BusinessProcessAttribute> GetValue(int id, params string[] includes)
        {
            return GetEntities(includes).SingleAsync(entity => entity.Id == id);
        }

        public Task<BusinessProcessAttribute[]> GetValuesByBusinessProcessId(int id, params string[] includes)
        {
            return GetEntities(includes).Where(a => a.AttributeBusinessProcesses.Any(bp => bp.BusinessProcessId == id)).ToArrayAsync();
        }
    }
}