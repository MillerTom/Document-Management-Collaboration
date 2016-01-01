using System.Data.Entity;
using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class ReportRepository : RepositoryBase<Report>, IReportRepository
    {
        public ReportRepository(CoopEntities context) : base(context)
        {
        }

        protected override DbSet<Report> ObjectSet
        {
            get { return Context.Reports; }
        }

        public Task<Report> GetValue(int id, params string[] includes)
        {
            return GetEntities(includes).SingleAsync(entity => entity.Id == id);
        }
    }
}