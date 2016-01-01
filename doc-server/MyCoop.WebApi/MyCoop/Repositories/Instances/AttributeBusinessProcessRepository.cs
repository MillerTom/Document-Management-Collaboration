using System.Data.Entity;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class AttributeBusinessProcessRepository : RepositoryBase<AttributeBusinessProcess>, IAttributeBusinessProcessRepository
    {
        public AttributeBusinessProcessRepository(CoopEntities context) : base(context)
        {
        }

        protected override DbSet<AttributeBusinessProcess> ObjectSet
        {
            get { return Context.AttributeBusinessProcesses; }
        }
    }
}