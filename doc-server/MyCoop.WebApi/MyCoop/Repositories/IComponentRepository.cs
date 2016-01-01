using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories
{
    public interface IComponentRepository : IStdRepository<Component>
    {
        Task Delete(int id);
    }
}