using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories
{
    public interface IUserRepository : IStdRepository<User>
    {
        Task<User> GetValue(string email, string password);

        Task<User[]> GetValuesByGroupId(int id);

        Task Delete(int id);

        Task<User[]> GetValuesByIncidentId(int id);
    }
}