using System;
using MyCoop.Data;

namespace MyCoop.WebApi.Models.Incidents
{
    public class IncidentOrgUnitModel
    {
        private readonly OrgUnit _orgUnit;
        private readonly LocationModel _location;

        public IncidentOrgUnitModel(OrgUnit orgUnit)
        {
            _orgUnit = orgUnit;
            _location = new LocationModel { Lat = _orgUnit.Lat, Lng = _orgUnit.Lng, Address = _orgUnit.Address };
        }

        public int Id
        {
            get { return _orgUnit.Id; }
        }

        public string Name
        {
            get { return _orgUnit.Name; }
        }

        public LocationModel Location
        {
            get { return _location; }
        }

        public DateTime CreationTime
        {
            get { return _orgUnit.CreationTime; }
        }

        public DateTime ModificationTime
        {
            get { return _orgUnit.ModificationTime; }
        }

        public int OwnerId
        {
            get { return _orgUnit.OwnerId; }
        }

        public int? ParentId
        {
            get { return _orgUnit.ParentId; }
        }

        public int? WorkspaceTemplateId
        {
            get { return _orgUnit.WorkspaceTemplateId; }
        } 
    }
}