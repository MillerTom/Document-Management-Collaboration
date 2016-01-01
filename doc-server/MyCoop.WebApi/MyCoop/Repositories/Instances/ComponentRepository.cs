using System.Data.Entity;
using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class ComponentRepository : RepositoryBase<Component>, IComponentRepository
    {
        public ComponentRepository(CoopEntities context) : base(context)
        {
        }

        protected override DbSet<Component> ObjectSet
        {
            get { return Context.Components; }
        }

        public Task<Component> GetValue(int id, params string[] includes)
        {
            return GetEntities(includes).SingleAsync(entity => entity.Id == id);
        }

        public Task Delete(int id)
        {
            return Task.Run(() => Context.DeleteComponent(id));
        }
    }
}