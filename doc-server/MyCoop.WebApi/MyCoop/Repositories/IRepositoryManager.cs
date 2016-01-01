using System.Threading.Tasks;

namespace MyCoop.Repositories
{
    public interface IRepositoryManager
    {
        T Get<T>();

        T GetWithContext<T>();

        T GetWithNewContext<T>();

        void SaveChanges();

        Task<int[]> SaveChangesAsync();

        void Dispose();
    }
}