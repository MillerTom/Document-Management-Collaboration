using MyCoop.Data;

namespace MyCoop.WebApi.Models.BusinessProcessAttributes
{
    public class EditBusinessProcessAttributeModel
    {
        private readonly BusinessProcessAttribute _businessProcessAttribute = new BusinessProcessAttribute();

        public string Name
        {
            get { return _businessProcessAttribute.Name; }
            set { _businessProcessAttribute.Name = value; }
        }

        public string Description
        {
            get { return _businessProcessAttribute.Description; }
            set { _businessProcessAttribute.Description = value; }
        }

        public int AttributeTypeId
        {
            get { return _businessProcessAttribute.AttributeTypeId; }
            set { _businessProcessAttribute.AttributeTypeId = value; }
        }

        public BusinessProcessAttribute GetEntity()
        {
            return _businessProcessAttribute;
        } 
    }
}