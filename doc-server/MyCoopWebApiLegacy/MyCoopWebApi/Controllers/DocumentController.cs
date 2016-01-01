using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using MyCoop.Services;
using MyCoopWebApi.Models;

namespace MyCoopWebApi.Controllers
{
    public class DocumentController : ApiController
    {
        // GET api/document
        public HttpResponseMessage Get()
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, ((new MyCoop.Services.DocumentService()).GetDocuments()));
        }

        // GET api/document/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/document
        public string Post([FromBody]DocumentModel value)
        {
            return (new MyCoop.Services.DocumentService()).AddDocument(new Document { Reference = value.Reference, Name = value.Name });
        }

        // PUT api/document/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/document/5
        public void Delete(int id)
        {
        }
    }
}
