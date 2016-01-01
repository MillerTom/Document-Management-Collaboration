using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories
{
    public interface IWorkspaceTemplateRepository : IStdRepository<WorkspaceTemplate>
    {
        Task Delete(int id);
    }
}