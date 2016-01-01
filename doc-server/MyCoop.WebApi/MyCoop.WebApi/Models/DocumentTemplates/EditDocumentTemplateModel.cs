using MyCoop.Data;

namespace MyCoop.WebApi.Models.DocumentTemplates
{
    public class EditDocumentTemplateModel
    {
        private readonly DocumentTemplate _documentTemplate = new DocumentTemplate();

        public string Name
        {
            get { return _documentTemplate.Name; }
            set { _documentTemplate.Name = value; }
        }

        public string Reference
        {
            get { return _documentTemplate.Reference; }
            set { _documentTemplate.Reference = value; }
        }

        public string Purpose
        {
            get { return _documentTemplate.Purpose; }
            set { _documentTemplate.Purpose = value; }
        }

        public int PagesCount
        {
            get { return _documentTemplate.PagesCount; }
            set { _documentTemplate.PagesCount = value; }
        }

        public string Link
        {
            get { return _documentTemplate.Link; }
            set { _documentTemplate.Link = value; }
        }

        public int? ComponentId
        {
            get { return _documentTemplate.ComponentId; }
            set { _documentTemplate.ComponentId = value; }
        }

        public DocumentTemplate GetEntity()
        {
            return _documentTemplate;
        }
    }
}