using MyCoop.Data;

namespace MyCoop.WebApi.Models.BusinessProcesses
{
    public class BusinessProcessModel
    {
        private readonly BusinessProcess _businessProcess;
        private readonly LocationModel _location;

        public BusinessProcessModel(BusinessProcess businessProcess)
        {
            _businessProcess = businessProcess;
            _location = new LocationModel { Lat = _businessProcess.Lat, Lng = _businessProcess.Lng, Address = _businessProcess.Address };
        }

        public int Id
        {
            get { return _businessProcess.Id; }
        }

        public string Name
        {
            get { return _businessProcess.Name; }
        }

        public string Description
        {
            get { return _businessProcess.Description; }
        }

        public int OrgUnitId
        {
            get { return _businessProcess.OrgUnitId; }
        }

        public LocationModel Location
        {
            get { return _location; }
        }
    }
}