using System.Threading.Tasks;
using MyCoop.Data;
using MyCoop.Repositories;
using MyCoop.WebApi.Models.Reports;

namespace MyCoop.WebApi.Services.Instances
{
    public class ReportService : ServiceBase, IReportService
    {
        public ReportService(IRepositoryManager repository) 
            : base(repository)
        {
        }

        public Task<ReportModel[]> GetReports()
        {
            return GetValues<ReportModel, Report, IReportRepository>(entity => new ReportModel(entity));
        }

        public Task<int> AddReport(EditReportModel model)
        {
            return Add<Report, IReportRepository>(entity => entity.Id, model.GetEntity);
        }

        public Task DeleteReport(int id)
        {
            return Delete<Report, IReportRepository>(id);
        }
    }
}