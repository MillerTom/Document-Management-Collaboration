using System;
using System.Linq;
using System.Threading.Tasks;
using MyCoop.Data;
using MyCoop.Repositories;
using MyCoop.WebApi.Models.AttributeTypes;
using MyCoop.WebApi.Models.BusinessProcessAttributes;
using MyCoop.WebApi.Models.BusinessProcesses;

namespace MyCoop.WebApi.Services.Instances
{
    public class BusinessProcessService : ServiceBase, IBusinessProcessService
    {
        public BusinessProcessService(IRepositoryManager repository) : base(repository)
        {
        }

        public Task<BusinessProcessModel[]> GetBusinessProcesses()
        {
            return GetValues<BusinessProcessModel, BusinessProcess, IBusinessProcessRpository>(entity => new BusinessProcessModel(entity));
        }

        public Task<BusinessProcessModel> GetBusinessProcess(int id)
        {
            return GetValue<BusinessProcessModel, BusinessProcess, IBusinessProcessRpository>(id, entity => new BusinessProcessModel(entity));
        }

        public Task<int> AddBusinessProcess(EditBusinessProcessModel model)
        {
            return Add<BusinessProcess, IBusinessProcessRpository>(entity => entity.Id, model.GetEntity);
        }

        public Task UpdateBusinessProcess(int id, EditBusinessProcessModel model)
        {
            return Update<BusinessProcess, IBusinessProcessRpository>(id, entity =>
            {
                var newEntity = model.GetEntity();
                entity.Name = newEntity.Name;
                entity.Description = newEntity.Description;
                entity.OrgUnitId = newEntity.OrgUnitId;
                entity.Address = newEntity.Address;
                entity.Lat = newEntity.Lat;
                entity.Lng = newEntity.Lng;
            });
        }

        public Task DeleteBusinessProcess(int id)
        {
            return Repository.GetWithContext<IBusinessProcessRpository>().Delete(id);
        }

        public Task<BusinessProcessAttributeModel[]> GetBusinessProcessAttributes()
        {
            return GetValues<BusinessProcessAttributeModel, BusinessProcessAttribute, IBusinessProcessAttributeRepository>(entity => new BusinessProcessAttributeModel(entity));
        }

        public Task<BusinessProcessAttributeModel> GetBusinessProcessAttribute(int id)
        {
            return GetValue<BusinessProcessAttributeModel, BusinessProcessAttribute, IBusinessProcessAttributeRepository>(id, entity => new BusinessProcessAttributeModel(entity));
        }

        public Task<int> AddBusinessProcessAttribute(EditBusinessProcessAttributeModel model)
        {
            return Add<BusinessProcessAttribute, IBusinessProcessAttributeRepository>(entity => entity.Id, model.GetEntity);
        }

        public Task UpdateBusinessProcessAttribute(int id, EditBusinessProcessAttributeModel model)
        {
            return Update<BusinessProcessAttribute, IBusinessProcessAttributeRepository>(id, entity =>
            {
                var newEntity = model.GetEntity();
                entity.Name = newEntity.Name;
                entity.Description = newEntity.Description;
                entity.AttributeTypeId = newEntity.AttributeTypeId;
            });
        }

        public Task DeleteBusinessProcessAttribute(int id)
        {
            return Delete<BusinessProcessAttribute, IBusinessProcessAttributeRepository>(id);
        }

        public Task<AttributeTypeModel[]> GetAttributeTypes()
        {
            return GetValues<AttributeTypeModel, AttributeType, IAttributeTypeRepository>(entity => new AttributeTypeModel(entity));
        }

        public Task<AttributeTypeModel> GetAttributeType(int id)
        {
            return GetValue<AttributeTypeModel, AttributeType, IAttributeTypeRepository>(id, entity => new AttributeTypeModel(entity));
        }

        public Task<int> AddAttributeType(EditAttributeTypeModel model)
        {
            return Add<AttributeType, IAttributeTypeRepository>(entity => entity.Id, model.GetEntity);
        }

        public Task UpdateAttributeType(int id, EditAttributeTypeModel model)
        {
            return Update<AttributeType, IAttributeTypeRepository>(id, entity =>
            {
                var newEntity = model.GetEntity();
                entity.Name = newEntity.Name;
            });
        }

        public Task DeleteAttributeType(int id)
        {
            return Delete<AttributeType, IAttributeTypeRepository>(id);
        }


        public Task<BusinessProcessAttributeModel[]> GetAttributesByBusinessProcessId(int id)
        {
            return AsyncOperation(() => Repository.GetWithContext<IBusinessProcessAttributeRepository>().GetValuesByBusinessProcessId(id),
                userGroups => userGroups.Select(a => new BusinessProcessAttributeModel(a)).ToArray());
        }

        public Task AddAttributeToBusinessProcess(int attributeId, int businessProcessId)
        {
            var entity = new AttributeBusinessProcess
            {
                AttributeId = attributeId,
                BusinessProcessId = businessProcessId,
                CreationTime = DateTime.UtcNow
            };

            Repository.GetWithContext<IAttributeBusinessProcessRepository>().Add(entity);

            return Repository.SaveChangesAsync();
        }

        public Task RemoveAttributeFromBusinessProcess(int attributeId, int businessProcessId)
        {
            var entity = new AttributeBusinessProcess
            {
                AttributeId = attributeId,
                BusinessProcessId = businessProcessId
            };

            var repository = Repository.GetWithContext<IAttributeBusinessProcessRepository>();
            repository.Attach(entity);
            repository.Delete(entity);

            return Repository.SaveChangesAsync();
        }
    }
}