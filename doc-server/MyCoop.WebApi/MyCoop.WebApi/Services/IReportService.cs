using System.Threading.Tasks;
using MyCoop.WebApi.Models.Reports;

namespace MyCoop.WebApi.Services
{
    public interface IReportService
    {
        Task<ReportModel[]> GetReports();
        Task<int> AddReport(EditReportModel model);
        Task DeleteReport(int id);
    }
}