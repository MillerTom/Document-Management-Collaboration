using System;
using System.IO;
using MyCoop.Data;

namespace MyCoop.WebApi.Models.DocumentTemplates
{
    public class DocumentTemplateModel
    {
        private readonly DocumentTemplate _documentTemplate;

        public DocumentTemplateModel(DocumentTemplate documentTemplate)
        {
            _documentTemplate = documentTemplate;
        }

        public int Id
        {
            get { return _documentTemplate.Id; }
        }
        public string Name
        {
            get { return _documentTemplate.Name; }
        }

        public string Reference
        {
            get { return _documentTemplate.Reference; }
        }

        public string Purpose
        {
            get { return _documentTemplate.Purpose; }
        }

        public int PagesCount
        {
            get { return _documentTemplate.PagesCount; }
        }

        public string Link
        {
            get { return _documentTemplate.Link; }
        }

        public string Image
        {
            get { return String.Format("/Content/DocumentTemplates/{0}.png", Path.GetFileNameWithoutExtension(_documentTemplate.Link)); }
        }

        public int? ComponentId
        {
            get { return _documentTemplate.ComponentId; }
        }
    }
}