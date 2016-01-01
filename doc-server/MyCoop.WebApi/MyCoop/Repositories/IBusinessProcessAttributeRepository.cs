using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories
{
    public interface IBusinessProcessAttributeRepository : IStdRepository<BusinessProcessAttribute>
    {
        Task<BusinessProcessAttribute[]> GetValuesByBusinessProcessId(int id, params string[] includes);
    }
}