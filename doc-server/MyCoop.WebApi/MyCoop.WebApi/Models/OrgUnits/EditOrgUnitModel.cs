using System;
using MyCoop.Data;

namespace MyCoop.WebApi.Models.OrgUnits
{
    public class EditOrgUnitModel
    {
        private readonly OrgUnit _orgUnit = new OrgUnit();
        private LocationModel _location;

        public EditOrgUnitModel()
        {
            _orgUnit.CreationTime = DateTime.UtcNow;
            _orgUnit.ModificationTime = DateTime.UtcNow;
        }

        public string Name
        {
            get { return _orgUnit.Name; }
            set { _orgUnit.Name = value; }
        }

        public LocationModel Location
        {
            get { return _location; }
            set
            {
                _location = value;
                if (_location != null)
                {
                    _orgUnit.Lat = _location.Lat;
                    _orgUnit.Lng = _location.Lng;
                    _orgUnit.Address = _location.Address;
                }
                
            }
        }

        public int OwnerId
        {
            get { return _orgUnit.OwnerId; }
            set { _orgUnit.OwnerId = value; }
        }

        public int? ParentId
        {
            get { return _orgUnit.ParentId; }
            set { _orgUnit.ParentId = value; }
        }

        public int? WorkspaceTemplateId
        {
            get { return _orgUnit.WorkspaceTemplateId; }
            set { _orgUnit.WorkspaceTemplateId = value; }
        }

        public OrgUnit GetEntity()
        {
            return _orgUnit;
        }
    }
}