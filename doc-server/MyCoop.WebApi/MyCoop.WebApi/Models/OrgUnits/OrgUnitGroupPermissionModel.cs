using MyCoop.Data;

namespace MyCoop.WebApi.Models.OrgUnits
{
    public class OrgUnitGroupPermissionModel
    {
        private readonly OrgUnitGroupPermission _permission;
        private readonly GroupModel _group;

        public OrgUnitGroupPermissionModel(OrgUnitGroupPermission permission)
        {
            _permission = permission;
            _group = new GroupModel(_permission.Group);
        }

        public int PermissionLevelId
        {
            get { return _permission.PermissionLevelId; }
        }

        public GroupModel Group
        {
            get { return _group; }
        }

        public class GroupModel
        {
            private readonly Group _group;

            public GroupModel(Group group)
            {
                _group = group;
            }
            public int Id
            {
                get { return _group.Id; }
            }
            public string Name
            {
                get { return _group.Name; }
            }
        }
    }
}