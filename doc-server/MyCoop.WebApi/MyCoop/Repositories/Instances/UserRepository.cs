using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(CoopEntities context)
            : base(context)
        {
        }

        protected override DbSet<User> ObjectSet
        {
            get { return Context.Users; }
        }

        public Task<User> GetValue(string email, string password)
        {
            return ObjectSet.SingleOrDefaultAsync(user => user.Email == email && user.Password == password);
        }

        public Task<User[]> GetValuesByGroupId(int id)
        {
            return GetEntities().Where(entity => entity.UserGroups.Any(item => item.GroupId == id)).ToArrayAsync();
        }

        public Task Delete(int id)
        {
            return Task.Run(() => Context.DeleteUser(id));
        }

        public Task<User> GetValue(int id, params string[] includes)
        {
            return GetEntities(includes).SingleAsync(entity => entity.Id == id);
        }

        public Task<User[]> GetValuesByIncidentId(int id)
        {
            return GetEntities().Where(entity => entity.IncidentUsers.Any(item => item.IncidentId == id)).ToArrayAsync();
        }
    }
}