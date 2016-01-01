using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories
{
    public interface IOrgUnitGroupPermissionRepository : IRepository<OrgUnitGroupPermission>
    {
        Task<OrgUnitGroupPermission[]> GetValuesByOrgUnitId(int id, params string[] includes);
    }
}