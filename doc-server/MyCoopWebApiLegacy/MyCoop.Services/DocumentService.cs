using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoop.Services
{
    public class DocumentService
    {
        public string AddDocument(Document document)
        {
            using (var context = new MyCoopEntities()) 
            {
                var newDoc = new Document
                {
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now,
                    Link = "/api/documents/" + document.Name,
                    Name = document.Name,
                    Reference = document.Reference
                };
                context.Documents.Add(newDoc);
                context.SaveChanges();
                return newDoc.Name;
            }
        }

        public IEnumerable<Document> GetDocuments() 
        {
            using (var context = new MyCoopEntities())
            {
                return context.Documents.ToList();
            }
        }
    }
}
