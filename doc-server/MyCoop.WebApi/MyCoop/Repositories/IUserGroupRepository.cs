using MyCoop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoop.Repositories
{
    public interface IUserGroupRepository : IRepository<UserGroup>
    {
        Task<UserGroup[]> GetUserGroups(int? userId, int? groupId);
    }
}
