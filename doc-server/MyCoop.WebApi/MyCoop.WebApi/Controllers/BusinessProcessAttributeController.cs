using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Any.Logs;
using MyCoop.WebApi.Extentions;
using MyCoop.WebApi.Loggers;
using MyCoop.WebApi.Models.BusinessProcessAttributes;
using MyCoop.WebApi.Services;

namespace MyCoop.WebApi.Controllers
{
    [RoutePrefix("business-process-attribute")]
    public class BusinessProcessAttributeController : ApiControllerBase
    {
        public BusinessProcessAttributeController(IServiceManager serviceManager) : base(serviceManager)
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<HttpResponseMessage> Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<IBusinessProcessService>().GetBusinessProcessAttributes());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<IBusinessProcessService>().GetBusinessProcessAttribute(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> Add([FromBody] EditBusinessProcessAttributeModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "AddBusinessProcessAttribute");
            var id = await Service.Get<IBusinessProcessService>().AddBusinessProcessAttribute(model);
            Log.Out.EndInfo("AddBusinessProcessAttribute Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK, new { Id = id });
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Update([FromUri] int id, [FromBody] EditBusinessProcessAttributeModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "UpdateBusinessProcessAttribute Id: {0}", id);
            await Service.Get<IBusinessProcessService>().UpdateBusinessProcessAttribute(id, model);
            Log.Out.EndInfo("UpdateBusinessProcessAttribute Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            Log.Out.BeginInfo("DeleteBusinessProcessAttribute Id: {0}", id);
            await Service.Get<IBusinessProcessService>().DeleteBusinessProcessAttribute(id);
            Log.Out.EndInfo("DeleteBusinessProcessAttribute Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
