using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories
{
    public interface IGroupRepository : IStdRepository<Group>
    {
        Task<Group[]> GetGroupsByUserId(int userId);

        Task Delete(int id);
    }
}