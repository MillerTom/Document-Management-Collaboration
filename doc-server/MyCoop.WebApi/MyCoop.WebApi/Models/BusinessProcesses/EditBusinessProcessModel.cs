using MyCoop.Data;

namespace MyCoop.WebApi.Models.BusinessProcesses
{
    public class EditBusinessProcessModel
    {
        private readonly BusinessProcess _businessProcess = new BusinessProcess();
        private LocationModel _location;

        public string Name
        {
            get { return _businessProcess.Name; }
            set { _businessProcess.Name = value; }
        }

        public string Description
        {
            get { return _businessProcess.Description; }
            set { _businessProcess.Description = value; }
        }

        public int OrgUnitId
        {
            get { return _businessProcess.OrgUnitId; }
            set { _businessProcess.OrgUnitId = value; }
        }

        public LocationModel Location
        {
            get { return _location; }
            set
            {
                _location = value;
                if (_location != null)
                {
                    _businessProcess.Lat = _location.Lat;
                    _businessProcess.Lng = _location.Lng;
                    _businessProcess.Address = _location.Address;
                }
            }
        }

        public BusinessProcess GetEntity()
        {
            return _businessProcess;
        }
    }
}