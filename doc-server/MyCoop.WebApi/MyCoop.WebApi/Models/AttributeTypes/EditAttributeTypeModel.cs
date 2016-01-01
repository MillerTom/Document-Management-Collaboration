using MyCoop.Data;

namespace MyCoop.WebApi.Models.AttributeTypes
{
    public class EditAttributeTypeModel
    {
        private readonly AttributeType _attributeType = new AttributeType();

        public string Name
        {
            get { return _attributeType.Name; }
            set { _attributeType.Name = value; }
        }

        public AttributeType GetEntity()
        {
            return _attributeType;
        }  
    }
}