using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyCoop.Services;

namespace MyCoopWebApi.Controllers
{
    public class ConvertController : ApiController
    {
        // GET api/convert
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/convert/5
        public string Get(string fileId, string ext)
        {
            var service = new DocumentEditingTestService(fileId);
            return service.GetDownloadLink(ext);
        }

        // POST api/convert
        public void Post([FromBody]string value)
        {
        }

        // PUT api/convert/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/convert/5
        public void Delete(int id)
        {
        }
    }
}
