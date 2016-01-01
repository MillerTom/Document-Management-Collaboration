using MyCoop.Data;

namespace MyCoop.WebApi.Models.Components
{
    public class EditComponentModel
    {
        private readonly Component _component = new Component();

        public int Id
        {
            get { return _component.Id; }
            set { _component.Id = value; }
        }
        public string Name
        {
            get { return _component.Name; }
            set { _component.Name = value; }
        }

        public Component GetEntity()
        {
            return _component;
        }
    }
}