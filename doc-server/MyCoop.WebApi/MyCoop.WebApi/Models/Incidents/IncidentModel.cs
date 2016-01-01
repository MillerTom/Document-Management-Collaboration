using System;
using MyCoop.Data;

namespace MyCoop.WebApi.Models.Incidents
{
    public class IncidentModel
    {
        private readonly Incident _incident;
        private readonly LocationModel _location;

        public IncidentModel(Incident incident)
        {
            _incident = incident;
            _location = new LocationModel { Lat = _incident.Lat, Lng = _incident.Lng, Address = _incident.Address };
        }

        public int Id
        {
            get { return _incident.Id; }
        }

        public string Name
        {
            get { return _incident.Name; }
        }

        public LocationModel Location
        {
            get { return _location; }
        }

        public int Type
        {
            get { return _incident.Type; }
        }

        public int Priority
        {
            get { return _incident.Priority; }
        }

        public int FacilityType
        {
            get { return _incident.FacilityType; }
        }

        public DateTime StartTime
        {
            get { return _incident.StartTime; }
        }

        public long Duration
        {
            get { return _incident.Duration; }
        }

        public string Description
        {
            get { return _incident.Description; }
        }
    }
}