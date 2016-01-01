using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class OrgUnitGroupPermissionRepository : RepositoryBase<OrgUnitGroupPermission>, IOrgUnitGroupPermissionRepository
    {
        public OrgUnitGroupPermissionRepository(CoopEntities context) : base(context)
        {
        }

        protected override DbSet<OrgUnitGroupPermission> ObjectSet
        {
            get { return Context.OrgUnitGroupPermissions; }
        }

        public Task<OrgUnitGroupPermission[]> GetValuesByOrgUnitId(int id, params string[] includes)
        {
            return GetEntities(includes).Where(p => p.OrgUnitId == id).ToArrayAsync();
        }
    }
}