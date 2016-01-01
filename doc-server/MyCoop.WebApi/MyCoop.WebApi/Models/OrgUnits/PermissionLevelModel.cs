using MyCoop.Data;

namespace MyCoop.WebApi.Models.OrgUnits
{
    public class PermissionLevelModel
    {
        private readonly PermissionLevel _permissionLevel;

        public PermissionLevelModel(PermissionLevel permissionLevel)
        {
            _permissionLevel = permissionLevel;
        }

        public int Id
        {
            get { return _permissionLevel.Id; }
        }

        public string Name
        {
            get { return _permissionLevel.Name; }
        }
    }
}