using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories
{
    public interface IPermissionLevelRepository : IStdRepository<PermissionLevel>
    {
        Task<PermissionLevel[]> GetValuesForUser(int orgUnitId, int userId);

        Task<PermissionLevel[]> GetValuesForGroup(int orgUnitId, int groupId);

        Task<PermissionLevel[]> GetValuesForOrgUnit(int orgUnitId);
    }
}