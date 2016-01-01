using System;
using System.Collections.Generic;
using MyCoop.WebApi.Services;
using MyCoop.WebApi.Services.Instances;

namespace MyCoop.WebApi.Core
{
    public class ServiceManager : IServiceManager
    {
        private static readonly Dictionary<Type, Type> _mapTypes = new Dictionary<Type, Type>();

        static ServiceManager()
        {
            _mapTypes.Add(typeof(ISystemService), typeof(SystemService));
            _mapTypes.Add(typeof(IManagementSevice), typeof(ManagementSevice));
            _mapTypes.Add(typeof(ITemplateService), typeof(TemplateService));
            _mapTypes.Add(typeof(IBusinessProcessService), typeof(BusinessProcessService));
            _mapTypes.Add(typeof(IReportService), typeof(ReportService));
            _mapTypes.Add(typeof(IWorkflowService), typeof(WorkflowService));
        }

        private readonly RepositoryManager _repositoryManager = new RepositoryManager();

        public void Dispose()
        {
            _repositoryManager.Dispose();
        }

        public T Get<T>()
        {
            return (T)Activator.CreateInstance(_mapTypes[typeof(T)], _repositoryManager);
        }
    }
}