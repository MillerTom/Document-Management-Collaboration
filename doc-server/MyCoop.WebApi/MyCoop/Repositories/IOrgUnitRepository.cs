using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories
{
    public interface IOrgUnitRepository : IStdRepository<OrgUnit>
    {
        Task Delete(int id);

        Task<OrgUnit[]> GetValuesByIncidentId(int id);
    }
}