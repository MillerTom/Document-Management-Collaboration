using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCoop.Data;
using MyCoop.Repositories;
using MyCoop.Repositories.Instances;

namespace MyCoop.WebApi.Core
{
    public class RepositoryManager : IRepositoryManager
    {
        private static readonly Dictionary<Type, Type> _mapTypes = new Dictionary<Type, Type>();

        static RepositoryManager()
        {
            _mapTypes.Add(typeof(IUserRepository), typeof(UserRepository));
            _mapTypes.Add(typeof(IGroupRepository), typeof(GroupRepository));
            _mapTypes.Add(typeof(IUserGroupRepository), typeof(UserGroupRepository));
            _mapTypes.Add(typeof(IPermissionLevelRepository), typeof(PermissionLevelRepository));
            _mapTypes.Add(typeof(IOrgUnitRepository), typeof(OrgUnitRepository));
            _mapTypes.Add(typeof(IComponentRepository), typeof(ComponentRepository));
            _mapTypes.Add(typeof(IDocumentTemplateRepository), typeof(DocumentTemplateRepository));
            _mapTypes.Add(typeof(IWorkspaceTemplateRepository), typeof(WorkspaceTemplateRepository));
            _mapTypes.Add(typeof(IWorkspaceDocumentTemplateRepository), typeof(WorkspaceDocumentTemplateRepository));
            _mapTypes.Add(typeof(IWorkspaceTemplateComponentRepository), typeof(WorkspaceTemplateComponentRepository));
            _mapTypes.Add(typeof(IOrgUnitUserPermissionRepository), typeof(OrgUnitUserPermissionRepository));
            _mapTypes.Add(typeof(IOrgUnitGroupPermissionRepository), typeof(OrgUnitGroupPermissionRepository));
            _mapTypes.Add(typeof(IIncidentRepository), typeof(IncidentRepository));
            _mapTypes.Add(typeof(IIncidentUserRepository), typeof(IncidentUserRepository));
            _mapTypes.Add(typeof(IIncidentOrgUnitRepository), typeof(IncidentOrgUnitRepository));
            _mapTypes.Add(typeof(ISysEventRepository), typeof(SysEventRepository));
            _mapTypes.Add(typeof(IAttributeBusinessProcessRepository), typeof(AttributeBusinessProcessRepository));
            _mapTypes.Add(typeof(IAttributeTypeRepository), typeof(AttributeTypeRepository));
            _mapTypes.Add(typeof(IBusinessProcessAttributeRepository), typeof(BusinessProcessAttributeRepository));
            _mapTypes.Add(typeof(IBusinessProcessRpository), typeof(BusinessProcessRpository));
            _mapTypes.Add(typeof(IReportRepository), typeof(ReportRepository));

            _mapTypes.Add(typeof(IWorkflowRepository), typeof(WorkflowRepository));
            _mapTypes.Add(typeof(IDocumentTaskRepository), typeof(DocumentTaskRepository));
            _mapTypes.Add(typeof(IWorkflowStateRepository), typeof(WorkflowStateRepository));
        }

        private CoopEntities _context;

        private readonly List<CoopEntities> _contexts = new List<CoopEntities>();

        public T Get<T>()
        {
            return (T)Activator.CreateInstance(_mapTypes[typeof(T)]);
        }

        public T GetWithContext<T>()
        {
            if (_context == null)
            {
                _context = new CoopEntities();
                _contexts.Add(_context);
            }
            return (T)Activator.CreateInstance(_mapTypes[typeof(T)], _context);
        }

        public T GetWithNewContext<T>()
        {
            var context = new CoopEntities();
            _contexts.Add(context);
            return (T)Activator.CreateInstance(_mapTypes[typeof(T)], context);
        }

        public void SaveChanges()
        {
            foreach (var context in _contexts)
            {
                context.SaveChanges();
            }
        }

        public Task<int[]> SaveChangesAsync()
        {
            return Task.WhenAll(_contexts.Select(context => context.SaveChangesAsync()));
        }

        public void Dispose()
        {
            foreach (var context in _contexts)
            {
                context.Dispose();
            }
        }
    }
}