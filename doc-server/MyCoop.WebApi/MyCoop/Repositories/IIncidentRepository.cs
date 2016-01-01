using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories
{
    public interface IIncidentRepository : IStdRepository<Incident>
    {
        Task Delete(int id);
    }
}