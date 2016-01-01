using System;
using System.Linq;
using System.Threading.Tasks;
using MyCoop.Data;
using MyCoop.Helpers;
using MyCoop.Repositories;
using MyCoop.WebApi.Loggers;
using MyCoop.WebApi.Models.Users;
using MyCoop.WebApi.Models.Groups;

namespace MyCoop.WebApi.Services.Instances
{
    public class SystemService : ServiceBase, ISystemService
    {
        public SystemService(IRepositoryManager repository)
            : base(repository)
        {
        }

        public Task<int> Connect(string email, string password)
        {
            var hash = SecurityHelper.GetHash(String.Concat(email, password));
            return AsyncOperation(() => Repository.GetWithContext<IUserRepository>().GetValue(email, hash),
                result => result != null ? result.Id : -1);
        }

        public Task<UserModel[]> GetUsers()
        {
            return GetValues<UserModel, User, IUserRepository>(user => new UserModel(user));
        }

        public Task<UserModel> GetUser(int id)
        {
            return GetValue<UserModel, User, IUserRepository>(id, user => new UserModel(user));
        }

        public Task<int> AddUser(AddUserModel model)
        {
            return Add<User, IUserRepository>(user => user.Id, () => new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PermissionLevelId = model.PermissionLevelId,
                Email = model.Email,
                Password = SecurityHelper.GetHash(String.Concat(model.Email, model.Password))
            });
        }

        public Task UpdateUser(int id, UpdateUserModel model)
        {
            return Update<User, IUserRepository>(id, user =>
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.PermissionLevelId = model.PermissionLevelId;
            });
        }

        public Task<UserGroupModel[]> GetUserGroups(int userId)
        {
            return AsyncOperation(() => Repository.GetWithContext<IUserGroupRepository>().GetUserGroups(userId, null),
                userGroups => userGroups.Select(ug => new UserGroupModel(ug)).ToArray());
        }

        public Task DeleteUser(int id)
        {
            return Repository.GetWithContext<IUserRepository>().Delete(id);
        }

        public Task<GroupModel[]> GetGroups()
        {
            return GetValues<GroupModel, Group, IGroupRepository>(group => new GroupModel(group), "User1", "User");
        }

        public Task<GroupModel> GetGroup(int id)
        {
            return GetValue<GroupModel, Group, IGroupRepository>(id, group => new GroupModel(group));
        }

        public Task<int> AddGroup(EditGroupModel model)
        {
            return Add<Group, IGroupRepository>(group => group.Id, model.GetEntity);
        }

        public Task UpdateGroup(int id, EditGroupModel model)
        {
            return Update<Group, IGroupRepository>(id, group =>
            {
                var entity = model.GetEntity();
                group.Name = entity.Name;
                group.Description = entity.Description;
                group.ModifiedByUserId = entity.ModifiedByUserId;
                group.ModificationTime = DateTime.UtcNow;
            });
        }

        public Task DeleteGroup(int id)
        {
            return Repository.GetWithContext<IGroupRepository>().Delete(id);
        }

        public Task<GroupUserModel[]> GetGroupUsers(int groupId)
        {
            return AsyncOperation(() => Repository.GetWithContext<IUserGroupRepository>().GetUserGroups(null, groupId),
                userGroups => userGroups.Select(ug => new GroupUserModel(ug)).ToArray());
        }

        public Task AddUserToGroup(int userId, int groupId)
        {
            var userGroup = new UserGroup
            {
                UserId = userId,
                GroupId = groupId,
                CreationTime = DateTime.UtcNow
            };

            var userGroupRepository = Repository.GetWithContext<IUserGroupRepository>();
            userGroupRepository.Add(userGroup);

            return Repository.SaveChangesAsync();
        }

        public Task RemoveUserFromGroup(int userId, int groupId)
        {
            var userGroup = new UserGroup
            {
                UserId = userId,
                GroupId = groupId
            };

            var userGroupRepository = Repository.GetWithContext<IUserGroupRepository>();
            userGroupRepository.Attach(userGroup);
            userGroupRepository.Delete(userGroup);

            return Repository.SaveChangesAsync();
        }

        public Task<UserHistoryModel[]> GetUserHistory(DateTime startTime)
        {
            return AsyncOperation(() => Repository.GetWithContext<ISysEventRepository>().GetValues((int)EventType.LoginActivity, startTime, "User"),
                userGroups => userGroups.Select(entity => new UserHistoryModel(entity)).ToArray());
        }
    }
}