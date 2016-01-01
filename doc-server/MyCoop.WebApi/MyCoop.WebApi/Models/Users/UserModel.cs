using System;
using MyCoop.Data;

namespace MyCoop.WebApi.Models.Users
{
    public class UserModel
    {
        private readonly User _user;

        public UserModel(User user)
        {
            _user = user;
        }
        public int Id
        {
            get { return _user.Id; }
        }
        public string Email
        {
            get { return _user.Email; }
        }
        public string FirstName
        {
            get { return _user.FirstName; }
        }
        public string LastName
        {
            get { return _user.LastName; }
        }
        public DateTime LastAcitve
        {
            get { return _user.LastAcitve; }
        }
        public int PermissionLevelId
        {
            get { return _user.PermissionLevelId; }
        }
    }
}