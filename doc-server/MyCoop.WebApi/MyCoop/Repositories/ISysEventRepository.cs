using System;
using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories
{
    public interface ISysEventRepository : IRepository<SysEvent>
    {
        Task<SysEvent[]> GetValues(int type, DateTime startTime, params string[] includes);
    }
}