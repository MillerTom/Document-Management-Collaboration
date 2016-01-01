using System.Data.Entity;
using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class AttributeTypeRepository : RepositoryBase<AttributeType>, IAttributeTypeRepository
    {
        public AttributeTypeRepository(CoopEntities context) : base(context)
        {
        }

        protected override DbSet<AttributeType> ObjectSet
        {
            get { return Context.AttributeTypes; }
        }

        public Task<AttributeType> GetValue(int id, params string[] includes)
        {
            return GetEntities(includes).SingleAsync(entity => entity.Id == id);
        }
    }
}