using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Any.Logs;
using MyCoop.WebApi.Extentions;
using MyCoop.WebApi.Filters;
using MyCoop.WebApi.Helpers;
using MyCoop.WebApi.Loggers;
using MyCoop.WebApi.Models.Users;
using MyCoop.WebApi.Services;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Net.Http.Headers;

namespace MyCoop.WebApi.Controllers
{
    [CoopAuthorize]
    [RoutePrefix("user")]
    public class UserController : ApiControllerBase
    {
        public UserController(IServiceManager serviceManager) : base(serviceManager)
        {
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<ISystemService>().GetUsers());

        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<ISystemService>().GetUser(id));
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Add([FromBody] AddUserModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "AddUser");
            var id = await Service.Get<ISystemService>().AddUser(model);
            Log.Out.EndInfo("AddUser - Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK, new { Id = id });

        }

        [HttpPost]
        public async Task<HttpResponseMessage> Update([FromUri] int id,  [FromBody] UpdateUserModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "UpdateUser - Id: {0}", id);
            await Service.Get<ISystemService>().UpdateUser(id, model);
            Log.Out.EndInfo("UpdateUser - Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            Log.Out.BeginInfo("DeleteUser - Id: {0}", id);
            await Service.Get<ISystemService>().DeleteUser(id);
            Log.Out.EndInfo("DeleteUser - Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpGet]
        [Route("{userId}/group")]
        public async Task<HttpResponseMessage> GetGroups(int userId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<ISystemService>().GetUserGroups(userId));
        }

        [HttpGet]
        [Route("current")]
        public async Task<HttpResponseMessage> GetCurrent()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<ISystemService>().GetUser(UserHelper.GetId()));
        }

        [HttpGet]
        [Route("history")]
        public async Task<HttpResponseMessage> GetHistory(DateTime startTime)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<ISystemService>().GetUserHistory(startTime));
        }

        [HttpGet]
        [Route("history-csv")]
        public async Task<HttpResponseMessage> GetHistoryCsvLink(DateTime startTime)
        {
            byte[] output = null;

            var history = await Service.Get<ISystemService>().GetUserHistory(startTime);
            var lines = new List<string>();
            var reportGuid = Guid.NewGuid();
            var fileName = "LoginHistory_" + reportGuid + ".csv";
            var filePath = HttpContext.Current.Server.MapPath("~/Content/Reports/") + fileName;
            lines.Add("Email,UserName,LoginTime,LoginStatus");
            foreach (var item in history)
            {
                if (item.User != null)
                {
                    lines.Add(String.Format("{0},{1},{2},{3}", item.User.Email, item.User.FirstName + " " + item.User.LastName, item.Time, item.Status));
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
                    FileName = "myCOOP Login History" + ".csv"
                };
                return result;
            }

            return this.Request.CreateErrorResponse(HttpStatusCode.NoContent, "No record found");
        }
    }
}
