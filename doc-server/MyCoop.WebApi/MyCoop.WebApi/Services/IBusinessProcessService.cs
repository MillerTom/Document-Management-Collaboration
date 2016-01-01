using System.Threading.Tasks;
using MyCoop.Data;
using MyCoop.WebApi.Models.AttributeTypes;
using MyCoop.WebApi.Models.BusinessProcessAttributes;
using MyCoop.WebApi.Models.BusinessProcesses;

namespace MyCoop.WebApi.Services
{
    public interface IBusinessProcessService
    {
        Task<BusinessProcessModel[]> GetBusinessProcesses();

        Task<BusinessProcessModel> GetBusinessProcess(int id);

        Task<int> AddBusinessProcess(EditBusinessProcessModel model);

        Task UpdateBusinessProcess(int id, EditBusinessProcessModel model);

        Task DeleteBusinessProcess(int id);

        Task<BusinessProcessAttributeModel[]> GetBusinessProcessAttributes();

        Task<BusinessProcessAttributeModel> GetBusinessProcessAttribute(int id);

        Task<int> AddBusinessProcessAttribute(EditBusinessProcessAttributeModel model);

        Task UpdateBusinessProcessAttribute(int id, EditBusinessProcessAttributeModel model);

        Task DeleteBusinessProcessAttribute(int id);

        Task<AttributeTypeModel[]> GetAttributeTypes();

        Task<AttributeTypeModel> GetAttributeType(int id);

        Task<int> AddAttributeType(EditAttributeTypeModel model);

        Task UpdateAttributeType(int id, EditAttributeTypeModel model);

        Task DeleteAttributeType(int id);

        Task<BusinessProcessAttributeModel[]> GetAttributesByBusinessProcessId(int id);

        Task AddAttributeToBusinessProcess(int attributeId, int businessProcessId);

        Task RemoveAttributeFromBusinessProcess(int attributeId, int businessProcessId);
    }
}