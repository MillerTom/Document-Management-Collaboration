using MyCoop.Data;

namespace MyCoop.WebApi.Models.BusinessProcessAttributes
{
    public class BusinessProcessAttributeModel
    {
        private readonly BusinessProcessAttribute _businessProcessAttribute;

        public BusinessProcessAttributeModel(BusinessProcessAttribute businessProcessAttribute)
        {
            _businessProcessAttribute = businessProcessAttribute;
        }

        public int Id
        {
            get { return _businessProcessAttribute.Id; }
        }

        public string Name
        {
            get { return _businessProcessAttribute.Name; }
        }

        public string Description
        {
            get { return _businessProcessAttribute.Description; }
        }

        public int AttributeTypeId
        {
            get { return _businessProcessAttribute.AttributeTypeId; }
        }
    }
}