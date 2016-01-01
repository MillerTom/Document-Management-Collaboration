using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class OrgUnitUserPermissionRepository : RepositoryBase<OrgUnitUserPermission>, IOrgUnitUserPermissionRepository
    {
        public OrgUnitUserPermissionRepository(CoopEntities context) : base(context)
        {
        }

        protected override DbSet<OrgUnitUserPermission> ObjectSet
        {
            get { return Context.OrgUnitUserPermissions; }
        }

        public Task<OrgUnitUserPermission[]> GetValuesByOrgUnitId(int id, params string[] includes)
        {
            return GetEntities(includes).Where(p => p.OrgUnitId == id).ToArrayAsync();
        }
    }
}