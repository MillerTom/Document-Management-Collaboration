using MyCoop.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoop.Repositories.Instances
{
    public class UserGroupRepository : RepositoryBase<UserGroup>, IUserGroupRepository
    {
        public UserGroupRepository(CoopEntities context)
            : base(context)
        {
        }

        protected override DbSet<UserGroup> ObjectSet
        {
            get { return Context.UserGroups; }
        }

        public Task<UserGroup[]> GetUserGroups(int? userId, int? groupId)
        {
            var query = GetEntities("Group", "User");
            if (userId.HasValue)
            {
                query = query.Where(ug => ug.UserId == userId.Value);
            }
            if (groupId.HasValue)
            {
                query = query.Where(ug => ug.GroupId == groupId.Value);
            }
            return query.ToArrayAsync();
        }
    }
}
