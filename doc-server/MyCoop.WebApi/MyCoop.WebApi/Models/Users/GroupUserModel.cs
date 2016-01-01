using System;
using MyCoop.Data;

namespace MyCoop.WebApi.Models.Users
{
    public class GroupUserModel
    {
        private readonly UserGroup _userGroup;

        public GroupUserModel(UserGroup userGroup)
        {
            _userGroup = userGroup;
        }

        public int Id
        {
            get { return _userGroup.UserId; }
        }
        public string Email
        {
            get { return _userGroup.User.Email; }
        }
        public string FirstName
        {
            get { return _userGroup.User.FirstName; }
        }
        public string LastName
        {
            get { return _userGroup.User.LastName; }
        }
        public DateTime LastAcitve
        {
            get { return _userGroup.User.LastAcitve; }
        }
        public int PermissionLevelId
        {
            get { return _userGroup.User.PermissionLevelId; }
        }

        public DateTime AddTime
        {
            get { return _userGroup.CreationTime; }
        }
    }
}