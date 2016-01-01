using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Any.Logs;
using MyCoop.WebApi.Extentions;
using MyCoop.WebApi.Loggers;
using MyCoop.WebApi.Models.BusinessProcesses;
using MyCoop.WebApi.Services;
using System.Collections.Generic;
using System;
using System.Web;
using System.Net.Http.Headers;
using System.IO;

namespace MyCoop.WebApi.Controllers
{
    [RoutePrefix("business-process")]
    public class BusinessProcessController : ApiControllerBase
    {
        public BusinessProcessController(IServiceManager serviceManager)
            : base(serviceManager)
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<HttpResponseMessage> Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<IBusinessProcessService>().GetBusinessProcesses());
        }


        [HttpGet]
        [Route("csv")]
        public async Task<HttpResponseMessage> GetCSV()
        {
            byte[] output = null;

            var processes = await Service.Get<IBusinessProcessService>().GetBusinessProcesses();
            var lines = new List<string>();
            var reportGuid = Guid.NewGuid();
            var fileName = "BusinessProcesses_" + reportGuid + ".csv";
            var filePath = HttpContext.Current.Server.MapPath("~/Content/Reports/") + fileName;
            lines.Add("Process Name,Description,Location");
            foreach (var item in processes)
            {
                if (item.Location != null)
                {
                    lines.Add(String.Format("{0},{1},{2}", item.Name, item.Description, item.Location.Address));
                }
            }
            File.WriteAllLines(filePath, lines);

            output = File.ReadAllBytes(filePath);
            File.Delete(filePath);

            if (output != null)
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(output) };
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = "myCOOP Business Processes" + ".csv"
                };
                return result;
            }

            return this.Request.CreateErrorResponse(HttpStatusCode.NoContent, "No record found");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<IBusinessProcessService>().GetBusinessProcess(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> Add([FromBody] EditBusinessProcessModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "AddBusinessProcess");
            var id = await Service.Get<IBusinessProcessService>().AddBusinessProcess(model);
            Log.Out.EndInfo("AddBusinessProcess Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK, new { Id = id });
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Update([FromUri] int id, [FromBody] EditBusinessProcessModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "UpdateBusinessProcess Id: {0}", id);
            await Service.Get<IBusinessProcessService>().UpdateBusinessProcess(id, model);
            Log.Out.EndInfo("UpdateBusinessProcess Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            Log.Out.BeginInfo("DeleteBusinessProcess Id: {0}", id);
            await Service.Get<IBusinessProcessService>().DeleteBusinessProcess(id);
            Log.Out.EndInfo("DeleteBusinessProcess");
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("{id}/attribute")]
        public async Task<HttpResponseMessage> GetAttributesByBusinessProcessId(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<IBusinessProcessService>().GetAttributesByBusinessProcessId(id));
        }

        [HttpPost]
        [Route("{businessProcessId}/attribute/{attributeId}")]
        public async Task<HttpResponseMessage> AddAttributeToBusinessProcess(int attributeId, int businessProcessId)
        {
            Log.Out.BeginInfo("AddAttributeToBusinessProcess attributeId: {0}, businessProcessId: {1}", attributeId, businessProcessId);
            await Service.Get<IBusinessProcessService>().AddAttributeToBusinessProcess(attributeId, businessProcessId);
            Log.Out.EndInfo("AddAttributeToBusinessProcess");
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("{businessProcessId}/attribute/{attributeId}")]
        public async Task<HttpResponseMessage> RemoveAttributeFromBusinessProcess(int attributeId, int businessProcessId)
        {
            Log.Out.BeginInfo("RemoveAttributeFromBusinessProcess attributeId: {0}, businessProcessId: {1}", attributeId, businessProcessId);
            await Service.Get<IBusinessProcessService>().RemoveAttributeFromBusinessProcess(attributeId, businessProcessId);
            Log.Out.EndInfo("RemoveAttributeFromBusinessProcess");
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}