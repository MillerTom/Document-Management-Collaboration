using System.Net;
using System.Net.Http;
using System.Web.Http;
using Any.Logs;
using MyCoop.WebApi.Extentions;
using MyCoop.WebApi.Filters;
using MyCoop.WebApi.Loggers;
using MyCoop.WebApi.Services;
using MyCoop.WebApi.Helpers;
using MyCoop.WebApi.Models.Groups;
using System.Threading.Tasks;

namespace MyCoop.WebApi.Controllers
{
    [CoopAuthorize]
    [RoutePrefix("group")]
    public class GroupController : ApiControllerBase
    {
        public GroupController(IServiceManager serviceManager)
            : base(serviceManager)
        {
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetGroups()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<ISystemService>().GetGroups());
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetGroup(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<ISystemService>().GetGroup(id));

        }

        [HttpPost]
        public async Task<HttpResponseMessage> AddGroup([FromBody] EditGroupModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "AddGroup");
            int userId = UserHelper.GetId();
            model.CreatedBy = userId;
            model.ModifiedBy = userId;
            var id = await Service.Get<ISystemService>().AddGroup(model);
            Log.Out.EndInfo("AddGroup - Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK, new { Id = id });

        }

        [HttpPost]
        public async Task<HttpResponseMessage> UpdateGroup([FromUri] int id, [FromBody] EditGroupModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "UpdateGroup - Id: {0}", id);
            model.ModifiedBy = UserHelper.GetId();
            await Service.Get<ISystemService>().UpdateGroup(id, model);
            Log.Out.EndInfo("UpdateGroup - Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteGroup(int id)
        {
            Log.Out.BeginInfo("UpdateGroup - Id: {0}", id);
            await Service.Get<ISystemService>().DeleteGroup(id);
            Log.Out.EndInfo("UpdateGroup - Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpGet]
        [Route("{groupId}/user")]
        public async Task<HttpResponseMessage> GetUsers(int groupId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<ISystemService>().GetGroupUsers(groupId));

        }

        [HttpPost]
        [Route("{groupId}/user/{userId}")]
        public async Task<HttpResponseMessage> AddUserToGroup([FromUri]int userId, [FromUri]int groupId)
        {
            Log.Out.BeginInfo("AddUser ({0}) To Group ({1})", userId, groupId);
            await Service.Get<ISystemService>().AddUserToGroup(userId, groupId);
            Log.Out.EndInfo("AddUser ({0}) To Group ({1})", userId, groupId);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpDelete]
        [Route("{groupId}/user/{userId}")]
        public async Task<HttpResponseMessage> RemoveUserFromGroup([FromUri]int userId, [FromUri]int groupId)
        {
            Log.Out.BeginInfo("RemoveUser ({0}) From Group ({1})", userId, groupId);
            await Service.Get<ISystemService>().RemoveUserFromGroup(userId, groupId);
            Log.Out.BeginInfo("RemoveUser ({0}) From Group ({1})", userId, groupId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
