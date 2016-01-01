using System.Threading.Tasks;
using MyCoop.WebApi.Models.Incidents;
using MyCoop.WebApi.Models.OrgUnits;

namespace MyCoop.WebApi.Services
{
    public interface IManagementSevice
    {
        Task<OrgUnitModel[]> GeOrgUnits();
        Task<OrgUnitModel> GeOrgUnit(int id);
        Task<int> AddOrgUnit(EditOrgUnitModel model);

        Task UpdateOrgUnit(int id, EditOrgUnitModel model);

        Task DeleteOrgUnit(int id);

        Task<PermissionLevelModel[]> GetOrgUnitUserPermissions(int orgUnitId, int userId);

        Task<PermissionLevelModel[]> GetOrgUnitGroupPermissions(int orgUnitId, int groupId);

        Task AddOrgUnitUserPermission(int orgUnitId, int userId, int permissionId);

        Task RemoveOrgUnitUserPermission(int orgUnitId, int userId, int permissionId);

        Task AddOrgUnitGroupPermission(int orgUnitId, int groupId, int permissionId);

        Task RemoveOrgUnitGroupPermission(int orgUnitId, int groupId, int permissionId);

        Task<OrgUnitUserPermissionModel[]> GetUserOrgUnitPermissions(int orgUnitId);

        Task<OrgUnitGroupPermissionModel[]> GetGroupOrgUnitPermissions(int orgUnitId);

        Task<IncidentModel[]> GeIncidents();
        Task<IncidentModel> GeIncident(int id);
        Task<int> AddIncident(EditIncidentModel model);

        Task UpdateIncident(int id, EditIncidentModel model);

        Task DeleteIncident(int id);

        Task<IncidentUserModel[]> GetUsersByIncidentId(int id);

        Task<IncidentOrgUnitModel[]> GetOrgUnitsByIncidentId(int id);

        Task AddIncidentUser(int incidentId, int userId);

        Task RemoveIncidentUser(int incidentId, int userId);

        Task AddIncidentOrgUnit(int incidentId, int orgUnitId);

        Task RemoveIncidentOrgUnit(int incidentId, int orgUnitId);
    }
}