using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories
{
    public interface IDocumentTemplateRepository : IStdRepository<DocumentTemplate>
    {
        Task<DocumentTemplate[]> GetValuesByWorkspaceTemplateId(int id);

        Task Delete(int id);
    }
}