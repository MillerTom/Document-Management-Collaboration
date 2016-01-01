using System.Threading.Tasks;

namespace MyCoop.Repositories
{
    public interface IRepository<T>
    {
        void Add(T value);

        void Attach(T value);

        void Delete(T value);

        Task<T[]> GetValues(params string[] includes);
    } 
}