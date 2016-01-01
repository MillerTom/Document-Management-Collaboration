using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories
{
    public interface IBusinessProcessRpository : IStdRepository<BusinessProcess>
    {
        Task Delete(int id);
    }
}