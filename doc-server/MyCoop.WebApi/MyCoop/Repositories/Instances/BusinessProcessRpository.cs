using System.Data.Entity;
using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class BusinessProcessRpository : RepositoryBase<BusinessProcess>, IBusinessProcessRpository
    {
        public BusinessProcessRpository(CoopEntities context) : base(context)
        {
        }

        protected override DbSet<BusinessProcess> ObjectSet
        {
            get { return Context.BusinessProcesses; }
        }

        public Task<BusinessProcess> GetValue(int id, params string[] includes)
        {
            return GetEntities(includes).SingleAsync(entity => entity.Id == id);
        }

        public Task Delete(int id)
        {
            return Task.Run(() => Context.DeleteBusinessProcess(id));
        }
    }
}