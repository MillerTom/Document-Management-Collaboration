using System.Threading.Tasks;
using MyCoop.WebApi.Models.Components;
using MyCoop.WebApi.Models.DocumentTemplates;
using MyCoop.WebApi.Models.WorkspaceTemplates;

namespace MyCoop.WebApi.Services
{
    public interface ITemplateService
    {
        Task<ComponentModel[]> GetComponents();

        Task<ComponentModel> GetComponent(int id);

        Task<int> AddComponent(EditComponentModel model);

        Task UpdateComponent(int id, EditComponentModel model);

        Task DeleteComponent(int id);

        Task<DocumentTemplateModel[]> GetDocumentTemplates();

        Task<DocumentTemplateModel> GetDocumentTemplate(int id);

        Task<int> AddDocumentTemplate(EditDocumentTemplateModel model);

        Task UpdateDocumentTemplate(int id, EditDocumentTemplateModel model);

        Task DeleteDocumentTemplate(int id);

        Task<WorkspaceTemplateModel[]> GetWorkspaceTemplates();

        Task<WorkspaceTemplateModel> GetWorkspaceTemplate(int id);

        Task<int> AddWorkspaceTemplate(EditWorkspaceTemplateModel model);

        Task UpdateWorkspaceTemplate(int id, EditWorkspaceTemplateModel model);

        Task DeleteWorkspaceTemplate(int id);

        Task<DocumentTemplateModel[]> GetDocumentsByWorkspaceTemplateId(int id);

        Task AddDocumentToWorkspaceTemplate(int workspaceTemplateId, int documentTemplateId);

        Task RemoveDocumentFromWorkspaceTemplate(int workspaceTemplateId, int documentTemplateId);

        Task AddComponentToWorkspaceTemplate(int workspaceTemplateId, int componentId);

        Task RemoveComponentFromWorkspaceTemplate(int workspaceTemplateId, int componentId);
    }
}