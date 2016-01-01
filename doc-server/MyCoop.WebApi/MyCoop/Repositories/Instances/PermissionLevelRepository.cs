using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class PermissionLevelRepository : RepositoryBase<PermissionLevel>, IPermissionLevelRepository
    {
        public PermissionLevelRepository(CoopEntities context) : base(context)
        {
        }

        protected override DbSet<PermissionLevel> ObjectSet
        {
            get { return Context.PermissionLevels; }
        }

        public Task<PermissionLevel> GetValue(int id, params string[] includes)
        {
            return GetEntities(includes).SingleAsync(entity => entity.Id == id);
        }

        public Task<PermissionLevel[]> GetValuesForUser(int orgUnitId, int userId)
        {
            return GetEntities().Where(entity => entity.OrgUnitUserPermissions.Any(oup => oup.OrgUnitId == orgUnitId && oup.UserId == userId)).ToArrayAsync();
        }

        public Task<PermissionLevel[]> GetValuesForGroup(int orgUnitId, int groupId)
        {
            return GetEntities().Where(entity => entity.OrgUnitGroupPermissions.Any(oup => oup.OrgUnitId == orgUnitId && oup.GroupId == groupId)).ToArrayAsync();
        }

        public Task<PermissionLevel[]> GetValuesForOrgUnit(int orgUnitId)
        {
            return GetEntities().Where(entity => entity.OrgUnitGroupPermissions.Any(oup => oup.OrgUnitId == orgUnitId) || entity.OrgUnitUserPermissions.Any(oup => oup.OrgUnitId == orgUnitId)).ToArrayAsync();
        }
    }
}