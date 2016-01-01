using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using ASC.Api.DocumentConverter;
using MyCoopWebApi.Models;

namespace MyCoopWebApi.Controllers
{
    public class EditorController : ApiController
    {
        // GET api/editor
        public HttpResponseMessage Get(string fileId)
        {
            var fileName = fileId;
            var fileUri = DocumentService.FileUri(fileName);
            var key = ServiceConverter.GenerateRevisionId(/*DocumentService.CurUserHostAddress +*/ "__1/" + Path.GetFileName(fileUri));
            var validateKey = ServiceConverter.GenerateValidateKey(key);
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                type = "desktop",
                documentType = "text",
                fileName = fileName,
                fileUri = fileUri,
                key = key,
                validateKey = validateKey,
                isEditable = true
            });
        }

        // GET api/editor/5
        public string Get(int id)
        {
            return "value";
        }
    }
}
