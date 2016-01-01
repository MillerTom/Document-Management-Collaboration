using System.Linq;
using MyCoop.Data;
using MyCoop.WebApi.Models.DocumentTemplates;

namespace MyCoop.WebApi.Models.Components
{
    public class ComponentModel
    {
        private readonly Component _component;
        private readonly DocumentTemplateModel[] _documentTemplates;

        public ComponentModel(Component component)
        {
            _component = component;
            _documentTemplates = component.DocumentTemplates.Select(dt => new DocumentTemplateModel(dt)).ToArray();
        }

        public int Id
        {
            get { return _component.Id; }
        }
        public string Name
        {
            get { return _component.Name; }
        }

        public DocumentTemplateModel[] DocumentTemplates
        {
            get
            {
                return _documentTemplates;
            }
        }

    }
}