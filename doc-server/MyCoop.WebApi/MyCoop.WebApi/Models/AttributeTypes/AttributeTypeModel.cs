using MyCoop.Data;

namespace MyCoop.WebApi.Models.AttributeTypes
{
    public class AttributeTypeModel
    {
        private readonly AttributeType _attributeType;

        public AttributeTypeModel(AttributeType attributeType)
        {
            _attributeType = attributeType;
        }

        public int Id
        {
            get { return _attributeType.Id; }
        }

        public string Name
        {
            get { return _attributeType.Name; }
        }
    }
}