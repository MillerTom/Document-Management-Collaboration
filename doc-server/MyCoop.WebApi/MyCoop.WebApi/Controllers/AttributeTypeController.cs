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
using MyCoop.WebApi.Models.AttributeTypes;
using MyCoop.WebApi.Services;

namespace MyCoop.WebApi.Controllers
{
    [RoutePrefix("attribute-type")]
    public class AttributeTypeController : ApiControllerBase
    {
        public AttributeTypeController(IServiceManager serviceManager) : base(serviceManager)
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<HttpResponseMessage> Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<IBusinessProcessService>().GetAttributeTypes());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<IBusinessProcessService>().GetAttributeType(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> Add([FromBody] EditAttributeTypeModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "AddAttributeType");
            var id = await Service.Get<IBusinessProcessService>().AddAttributeType(model);
            Log.Out.EndInfo("AddAttributeType Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK, new { Id = id });
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Update([FromUri] int id, [FromBody] EditAttributeTypeModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "UpdateAttributeType Id: {0}", id);
            await Service.Get<IBusinessProcessService>().UpdateAttributeType(id, model);
            Log.Out.EndInfo("UpdateAttributeType Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            Log.Out.BeginInfo("DeleteAttributeType Id: {0}", id);
            await Service.Get<IBusinessProcessService>().DeleteAttributeType(id);
            Log.Out.EndInfo("DeleteAttributeType Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
