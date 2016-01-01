using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MyCoopWebApi.Models;
using MyCoop.Services;

namespace MyCoopWebApi.Controllers
{
    public class SearchAndReplaceController : ApiController
    {
        // GET api/searchandreplace
        public string Get()
        {
            return "success";
        }

        // GET api/searchandreplace/5
        public string Get(string fileId)
        {
           var domain = HttpContext.Current.Request.UserHostAddress;
            string name = DocumentService.DoUpload("http://localhost"+HttpRuntime.AppDomainAppVirtualPath + "/documents/" + fileId);
            DocumentService.DoConvert(name);
            return "value";
        }

        // POST api/searchandreplace
        public string Post(string fileId, [FromBody]SearchAndReplaceModel value)
        {
            var service = new DocumentEditingTestService(fileId);
            string count = service.SearchAndReplace(value.SearchStatement, value.ReplaceStatement).ToString();

            //DocumentService.DoConvert(fileId);
            return count;
        }
    }
}
