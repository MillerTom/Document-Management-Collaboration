using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories
{
    public interface IOrgUnitUserPermissionRepository : IRepository<OrgUnitUserPermission>
    {
        Task<OrgUnitUserPermission[]> GetValuesByOrgUnitId(int id, params string[] includes);
    }
}