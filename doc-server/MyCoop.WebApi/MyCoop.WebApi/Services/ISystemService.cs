using System;
using System.Threading.Tasks;
using MyCoop.WebApi.Models.Users;
using MyCoop.WebApi.Models.Groups;

namespace MyCoop.WebApi.Services
{
    public interface ISystemService
    {
        Task<int> Connect(string email, string password);

        Task<UserModel[]> GetUsers();

        Task<UserModel> GetUser(int id);

        Task DeleteUser(int id);

        Task<int> AddUser(AddUserModel model);

        Task UpdateUser(int id, UpdateUserModel model);

        Task<UserGroupModel[]> GetUserGroups(int userId);

        Task<GroupModel[]> GetGroups();

        Task<GroupModel> GetGroup(int id);

        Task<int> AddGroup(EditGroupModel model);

        Task UpdateGroup(int id, EditGroupModel model);

        Task DeleteGroup(int id);

        Task<GroupUserModel[]> GetGroupUsers(int groupId);

        Task AddUserToGroup(int userId, int groupId);

        Task RemoveUserFromGroup(int userId, int groupId);

        Task<UserHistoryModel[]> GetUserHistory(DateTime startTime);
    }
}