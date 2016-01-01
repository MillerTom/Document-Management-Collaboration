using System;
using System.Linq;
using System.Threading.Tasks;
using MyCoop.Data;
using MyCoop.Repositories;
using MyCoop.WebApi.Models.Incidents;
using MyCoop.WebApi.Models.OrgUnits;

namespace MyCoop.WebApi.Services.Instances
{
    public class ManagementSevice : ServiceBase, IManagementSevice
    {
        public ManagementSevice(IRepositoryManager repository)
            : base(repository)
        {
        }

        public Task<OrgUnitModel[]> GeOrgUnits()
        {
            return GetValues<OrgUnitModel, OrgUnit, IOrgUnitRepository>(orgUnit => new OrgUnitModel(orgUnit));
        }

        public Task<OrgUnitModel> GeOrgUnit(int id)
        {
            return GetValue<OrgUnitModel, OrgUnit, IOrgUnitRepository>(id, orgUnit => new OrgUnitModel(orgUnit));
        }

        public Task<int> AddOrgUnit(EditOrgUnitModel model)
        {
            return Add<OrgUnit, IOrgUnitRepository>(orgUnit => orgUnit.Id, model.GetEntity);
        }

        public Task UpdateOrgUnit(int id, EditOrgUnitModel model)
        {
            return Update<OrgUnit, IOrgUnitRepository>(id, orgUnit =>
            {
                var entity = model.GetEntity();
                orgUnit.Name = entity.Name;
                orgUnit.Address = entity.Address;
                orgUnit.OwnerId = entity.OwnerId;
                orgUnit.ParentId = entity.ParentId;
                orgUnit.ModificationTime = entity.ModificationTime;
                orgUnit.WorkspaceTemplateId = entity.WorkspaceTemplateId;
            });
        }

        public Task DeleteOrgUnit(int id)
        {
            return Repository.GetWithContext<IOrgUnitRepository>().Delete(id);
        }

        public Task<PermissionLevelModel[]> GetOrgUnitUserPermissions(int orgUnitId, int userId)
        {
            return AsyncOperation(() => Repository.GetWithContext<IPermissionLevelRepository>().GetValuesForUser(orgUnitId, userId),
                values => values.Select(ug => new PermissionLevelModel(ug)).ToArray());
        }

        public Task<PermissionLevelModel[]> GetOrgUnitGroupPermissions(int orgUnitId, int groupId)
        {
            return AsyncOperation(() => Repository.GetWithContext<IPermissionLevelRepository>().GetValuesForGroup(orgUnitId, groupId),
                values => values.Select(ug => new PermissionLevelModel(ug)).ToArray());
        }

        public Task AddOrgUnitUserPermission(int orgUnitId, int userId, int permissionId)
        {
            var entity = new OrgUnitUserPermission
            {
                OrgUnitId = orgUnitId,
                UserId = userId,
                PermissionLevelId = permissionId
            };

            var userGroupRepository = Repository.GetWithContext<IOrgUnitUserPermissionRepository>();
            userGroupRepository.Add(entity);

            return Repository.SaveChangesAsync();
        }

        public Task RemoveOrgUnitUserPermission(int orgUnitId, int userId, int permissionId)
        {
            var entity = new OrgUnitUserPermission
            {
                OrgUnitId = orgUnitId,
                UserId = userId,
                PermissionLevelId = permissionId
            };

            var repository = Repository.GetWithContext<IOrgUnitUserPermissionRepository>();
            repository.Attach(entity);
            repository.Delete(entity);

            return Repository.SaveChangesAsync();
        }

        public Task AddOrgUnitGroupPermission(int orgUnitId, int groupId, int permissionId)
        {
            var entity = new OrgUnitGroupPermission
            {
                OrgUnitId = orgUnitId,
                GroupId = groupId,
                PermissionLevelId = permissionId
            };

            var userGroupRepository = Repository.GetWithContext<IOrgUnitGroupPermissionRepository>();
            userGroupRepository.Add(entity);

            return Repository.SaveChangesAsync();
        }

        public Task RemoveOrgUnitGroupPermission(int orgUnitId, int groupId, int permissionId)
        {
            var entity = new OrgUnitGroupPermission
            {
                OrgUnitId = orgUnitId,
                GroupId = groupId,
                PermissionLevelId = permissionId
            };

            var repository = Repository.GetWithContext<IOrgUnitGroupPermissionRepository>();
            repository.Attach(entity);
            repository.Delete(entity);

            return Repository.SaveChangesAsync();
        }

        public Task<OrgUnitUserPermissionModel[]> GetUserOrgUnitPermissions(int orgUnitId)
        {
            return AsyncOperation(() => Repository.GetWithContext<IOrgUnitUserPermissionRepository>().GetValuesByOrgUnitId(orgUnitId, "User"),
                values => values.Select(ug => new OrgUnitUserPermissionModel(ug)).ToArray());
        }

        public Task<OrgUnitGroupPermissionModel[]> GetGroupOrgUnitPermissions(int orgUnitId)
        {
            return AsyncOperation(() => Repository.GetWithContext<IOrgUnitGroupPermissionRepository>().GetValuesByOrgUnitId(orgUnitId, "Group"),
                values => values.Select(ug => new OrgUnitGroupPermissionModel(ug)).ToArray());
        }

        public Task<IncidentModel[]> GeIncidents()
        {
            return GetValues<IncidentModel, Incident, IIncidentRepository>(entity => new IncidentModel(entity));
        }

        public Task<IncidentModel> GeIncident(int id)
        {
            return GetValue<IncidentModel, Incident, IIncidentRepository>(id, entity => new IncidentModel(entity));
        }

        public Task<int> AddIncident(EditIncidentModel model)
        {
            return Add<Incident, IIncidentRepository>(entity => entity.Id, model.GetEntity);
        }

        public Task UpdateIncident(int id, EditIncidentModel model)
        {
            return Update<Incident, IIncidentRepository>(id, entity =>
            {
                var updatedEntity = model.GetEntity();
                entity.Name = updatedEntity.Name;
                entity.Address = updatedEntity.Address;
                entity.Lat = updatedEntity.Lat;
                entity.Lng = updatedEntity.Lng;
                entity.Type = updatedEntity.Type;
                entity.Priority = updatedEntity.Priority;
                entity.FacilityType = updatedEntity.FacilityType;
                entity.Duration = updatedEntity.Duration;
                entity.Description = updatedEntity.Description;
            });
        }

        public Task DeleteIncident(int id)
        {
            return Repository.GetWithContext<IIncidentRepository>().Delete(id);
        }

        public Task<IncidentUserModel[]> GetUsersByIncidentId(int id)
        {
            return AsyncOperation(() => Repository.GetWithContext<IUserRepository>().GetValuesByIncidentId(id),
                userGroups => userGroups.Select(ug => new IncidentUserModel(ug)).ToArray());
        }

        public Task<IncidentOrgUnitModel[]> GetOrgUnitsByIncidentId(int id)
        {
            return AsyncOperation(() => Repository.GetWithContext<IOrgUnitRepository>().GetValuesByIncidentId(id),
                userGroups => userGroups.Select(ug => new IncidentOrgUnitModel(ug)).ToArray());
        }

        public Task AddIncidentUser(int incidentId, int userId)
        {
            var entity = new IncidentUser
            {
                IncidentId = incidentId,
                UserId = userId,
                CreationTime = DateTime.UtcNow
            };

            var userGroupRepository = Repository.GetWithContext<IIncidentUserRepository>();
            userGroupRepository.Add(entity);

            return Repository.SaveChangesAsync();
        }

        public Task RemoveIncidentUser(int incidentId, int userId)
        {
            var entity = new IncidentUser
            {
                IncidentId = incidentId,
                UserId = userId
            };

            var repository = Repository.GetWithContext<IIncidentUserRepository>();
            repository.Attach(entity);
            repository.Delete(entity);

            return Repository.SaveChangesAsync();
        }

        public Task AddIncidentOrgUnit(int incidentId, int orgUnitId)
        {
            var entity = new IncidentOrgUnit
            {
                IncidentId = incidentId,
                OrgUnitId = orgUnitId,
                CreationTime = DateTime.UtcNow
            };

            var userGroupRepository = Repository.GetWithContext<IIncidentOrgUnitRepository>();
            userGroupRepository.Add(entity);

            return Repository.SaveChangesAsync();
        }

        public Task RemoveIncidentOrgUnit(int incidentId, int orgUnitId)
        {
            var entity = new IncidentOrgUnit
            {
                IncidentId = incidentId,
                OrgUnitId = orgUnitId
            };

            var repository = Repository.GetWithContext<IIncidentOrgUnitRepository>();
            repository.Attach(entity);
            repository.Delete(entity);

            return Repository.SaveChangesAsync();
        }
    }
}