using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Any.Logs;
using MyCoop.WebApi.Extentions;
using MyCoop.WebApi.Filters;
using MyCoop.WebApi.Loggers;
using MyCoop.WebApi.Models.OrgUnits;
using MyCoop.WebApi.Services;

namespace MyCoop.WebApi.Controllers
{

    [CoopAuthorize]
    [RoutePrefix("orgunit")]
    public class OrgUnitController : ApiControllerBase
    {
        public OrgUnitController(IServiceManager serviceManager) 
            : base(serviceManager)
        {
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GeOrgUnits()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<IManagementSevice>().GeOrgUnits());
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetOrgUnit(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<IManagementSevice>().GeOrgUnit(id));
        }

        [HttpPost]
        public async Task<HttpResponseMessage> AddOrgUnit([FromBody] EditOrgUnitModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "AddOrgUnit");
            var id = await Service.Get<IManagementSevice>().AddOrgUnit(model);
            Log.Out.EndInfo("AddOrgUnit Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK, new { Id = id });
        }

        [HttpPost]
        public async Task<HttpResponseMessage> UpdateOrgUnit([FromUri] int id, [FromBody] EditOrgUnitModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "UpdateOrgUnit Id: {0}", id);
            await Service.Get<IManagementSevice>().UpdateOrgUnit(id, model);
            Log.Out.EndInfo("UpdateOrgUnit Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteOrgUnit(int id)
        {
            Log.Out.BeginInfo("DeleteOrgUnit Id: {0}", id);
            await Service.Get<IManagementSevice>().DeleteOrgUnit(id);
            Log.Out.EndInfo("DeleteOrgUnit Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("{orgUnitId}/user/{userId}")]
        public async Task<HttpResponseMessage> GetOrgUnitUserPermissions(int orgUnitId, int userId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<IManagementSevice>().GetOrgUnitUserPermissions(orgUnitId, userId));
        }

        [HttpGet]
        [Route("{orgUnitId}/group/{groupId}")]
        public async Task<HttpResponseMessage> GetOrgUnitGroupPermissions(int orgUnitId, int groupId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<IManagementSevice>().GetOrgUnitGroupPermissions(orgUnitId, groupId));
        }

        [HttpPost]
        [Route("{orgUnitId}/user/{userId}/permission/{permissionId}")]
        public async Task<HttpResponseMessage> AddOrgUnitUserPermission(int orgUnitId, int userId, int permissionId)
        {
            Log.Out.BeginInfo("AddOrgUnitUserPermission orgUnitId: {0}, userId: {1}, permissionId: {2}", orgUnitId, userId, permissionId);
            await Service.Get<IManagementSevice>().AddOrgUnitUserPermission(orgUnitId, userId, permissionId);
            Log.Out.BeginInfo("AddOrgUnitUserPermission orgUnitId: {0}, userId: {1}, permissionId: {2}", orgUnitId, userId, permissionId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("{orgUnitId}/user/{userId}/permission/{permissionId}")]
        public async Task<HttpResponseMessage> RemoveOrgUnitUserPermission(int orgUnitId, int userId, int permissionId)
        {
            Log.Out.BeginInfo("RemoveOrgUnitUserPermission orgUnitId: {0}, userId: {1}, permissionId: {2}", orgUnitId, userId, permissionId);
            await Service.Get<IManagementSevice>().RemoveOrgUnitUserPermission(orgUnitId, userId, permissionId);
            Log.Out.BeginInfo("RemoveOrgUnitUserPermission orgUnitId: {0}, userId: {1}, permissionId: {2}", orgUnitId, userId, permissionId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("{orgUnitId}/group/{groupId}/permission/{permissionId}")]
        public async Task<HttpResponseMessage> AddOrgUnitGroupPermission(int orgUnitId, int groupId, int permissionId)
        {
            Log.Out.BeginInfo("AddOrgUnitGroupPermission orgUnitId: {0}, groupId: {1}, permissionId: {2}", orgUnitId, groupId, permissionId);
            await Service.Get<IManagementSevice>().AddOrgUnitGroupPermission(orgUnitId, groupId, permissionId);
            Log.Out.BeginInfo("AddOrgUnitGroupPermission orgUnitId: {0}, groupId: {1}, permissionId: {2}", orgUnitId, groupId, permissionId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("{orgUnitId}/group/{groupId}/permission/{permissionId}")]
        public async Task<HttpResponseMessage> RemoveOrgUnitGroupPermission(int orgUnitId, int groupId, int permissionId)
        {
            Log.Out.BeginInfo("RemoveOrgUnitGroupPermission orgUnitId: {0}, groupId: {1}, permissionId: {2}", orgUnitId, groupId, permissionId);
            await Service.Get<IManagementSevice>().RemoveOrgUnitGroupPermission(orgUnitId, groupId, permissionId);
            Log.Out.BeginInfo("RemoveOrgUnitGroupPermission orgUnitId: {0}, groupId: {1}, permissionId: {2}", orgUnitId, groupId, permissionId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("{orgUnitId}/user-permission")]
        public async Task<HttpResponseMessage> GetUserPermissions(int orgUnitId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<IManagementSevice>().GetUserOrgUnitPermissions(orgUnitId));
        }

        [HttpGet]
        [Route("{orgUnitId}/group-permission")]
        public async Task<HttpResponseMessage> GetGroupPermissions(int orgUnitId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<IManagementSevice>().GetGroupOrgUnitPermissions(orgUnitId));
        }
    }
}
