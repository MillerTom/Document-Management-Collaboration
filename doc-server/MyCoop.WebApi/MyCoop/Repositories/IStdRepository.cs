using System.Threading.Tasks;

namespace MyCoop.Repositories
{
    public interface IStdRepository<T> : IRepository<T>
    {
        Task<T> GetValue(int id, params string[] includes);
    }
}