using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Any.Logs;
using MyCoop.WebApi.Extentions;
using MyCoop.WebApi.Helpers;
using MyCoop.WebApi.Loggers;
using MyCoop.WebApi.Models.Reports;
using MyCoop.WebApi.Services;

namespace MyCoop.WebApi.Controllers
{
    public class ReportController : ApiControllerBase
    {
        public ReportController(IServiceManager serviceManager) : base(serviceManager)
        {
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<IReportService>().GetReports());
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Add([FromBody] EditReportModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "AddReport");
            int userId = UserHelper.GetId();
            model.CreatedBy = userId;
            model.ModifiedBy = userId;
            var id = await Service.Get<IReportService>().AddReport(model);
            Log.Out.EndInfo("AddReport Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK, new { Id = id });
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            Log.Out.BeginInfo("DeleteReport Id: {0}", id);
            await Service.Get<IReportService>().DeleteReport(id);
            Log.Out.EndInfo("DeleteReport Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
