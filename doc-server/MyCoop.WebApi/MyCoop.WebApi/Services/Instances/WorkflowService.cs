using MyCoop.Repositories;

namespace MyCoop.WebApi.Services.Instances
{
    public class WorkflowService : ServiceBase, IWorkflowService
    {
        public WorkflowService(IRepositoryManager repository) : base(repository)
        {
        }
    }
}