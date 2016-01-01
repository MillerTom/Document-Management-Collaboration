using MyCoop.Data;

namespace MyCoop.WebApi.Models.OrgUnits
{
    public class OrgUnitUserPermissionModel
    {
        private readonly OrgUnitUserPermission _permission;
        private readonly UserModel _user;

        public OrgUnitUserPermissionModel(OrgUnitUserPermission permission)
        {
            _permission = permission;
            _user = new UserModel(_permission.User);
        }

        public int PermissionLevelId
        {
            get { return _permission.PermissionLevelId; }
        }

        public UserModel User
        {
            get { return _user; }
        }

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
        }
    }
}