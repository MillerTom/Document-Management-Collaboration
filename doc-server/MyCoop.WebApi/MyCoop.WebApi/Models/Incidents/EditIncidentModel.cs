using System;
using MyCoop.Data;

namespace MyCoop.WebApi.Models.Incidents
{
    public class EditIncidentModel
    {
        private readonly Incident _incident = new Incident();
        private LocationModel _location;

        public string Name
        {
            get { return _incident.Name; }
            set { _incident.Name = value; }
        }

        public LocationModel Location
        {
            get { return _location; }
            set
            {
                _location = value;
                if (_location != null)
                {
                    _incident.Lat = _location.Lat;
                    _incident.Lng = _location.Lng;
                    _incident.Address = _location.Address;
                }
            }
        }

        public int Type
        {
            get { return _incident.Type; }
            set { _incident.Type = value; }
        }

        public int Priority
        {
            get { return _incident.Priority; }
            set { _incident.Priority = value; }
        }

        public int FacilityType
        {
            get { return _incident.FacilityType; }
            set { _incident.FacilityType = value; }
        }

        public DateTime StartTime
        {
            get { return _incident.StartTime; }
            set { _incident.StartTime = value; }
        }

        public long Duration
        {
            get { return _incident.Duration; }
            set { _incident.Duration = value; }
        }

        public string Description
        {
            get { return _incident.Description; }
            set { _incident.Description = value; }
        }

        public Incident GetEntity()
        {
            return _incident;
        }
    }
}