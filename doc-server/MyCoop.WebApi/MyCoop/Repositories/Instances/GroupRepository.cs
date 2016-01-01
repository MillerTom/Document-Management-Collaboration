using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class GroupRepository : RepositoryBase<Group>, IGroupRepository
    {
        public GroupRepository(CoopEntities context) : base(context)
        {
        }

        protected override DbSet<Group> ObjectSet
        {
            get { return Context.Groups; }
        }

        public Task<Group[]> GetGroupsByUserId(int userId)
        {
            return GetEntities().Where(g => g.UserGroups.Any(item => item.UserId == userId)).ToArrayAsync();
        }

        public Task Delete(int id)
        {
            return Task.Run(() => Context.DeleteGroup(id));
        }

        public Task<Group> GetValue(int id, params string[] includes)
        {
            return GetEntities(includes).SingleAsync(entity => entity.Id == id);
        }
    }
}