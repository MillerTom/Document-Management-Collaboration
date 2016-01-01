using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Any.Logs;
using MyCoop.WebApi.Extentions;
using MyCoop.WebApi.Loggers;
using MyCoop.WebApi.Models.Incidents;
using MyCoop.WebApi.Services;

namespace MyCoop.WebApi.Controllers
{
    [RoutePrefix("incident")]
    public class IncidentController : ApiControllerBase
    {
        public IncidentController(IServiceManager serviceManager) : base(serviceManager)
        {
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<IManagementSevice>().GeIncidents());
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<IManagementSevice>().GeIncident(id));
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Add([FromBody] EditIncidentModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "AddIncident");
            var id = await Service.Get<IManagementSevice>().AddIncident(model);
            Log.Out.EndInfo("AddIncident Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK, new { Id = id });
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Update([FromUri] int id, [FromBody] EditIncidentModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "UpdateIncident Id: {0}", id);
            await Service.Get<IManagementSevice>().UpdateIncident(id, model);
            Log.Out.EndInfo("UpdateIncident Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            Log.Out.BeginInfo("DeleteIncident Id: {0}", id);
            await Service.Get<IManagementSevice>().DeleteIncident(id);
            Log.Out.EndInfo("DeleteIncident Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("{id}/user")]
        public async Task<HttpResponseMessage> GetUsers(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<IManagementSevice>().GetUsersByIncidentId(id));
        }

        [HttpGet]
        [Route("{id}/org-unit")]
        public async Task<HttpResponseMessage> GetOrgUnits(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<IManagementSevice>().GetOrgUnitsByIncidentId(id));
        }

        [HttpPost]
        [Route("{incidentId}/user/{userId}")]
        public async Task<HttpResponseMessage> AddIncidentUser([FromUri]int incidentId, [FromUri]int userId)
        {
            Log.Out.BeginInfo("AddIncidentUser {0}, {1}", incidentId, userId);
            await Service.Get<IManagementSevice>().AddIncidentUser(incidentId, userId);
            Log.Out.EndInfo("AddIncidentUser {0}, {1}", incidentId, userId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("{incidentId}/user/{userId}")]
        public async Task<HttpResponseMessage> RemoveIncidentUser([FromUri]int incidentId, [FromUri]int userId)
        {
            Log.Out.BeginInfo("RemoveIncidentUser {0}, {1}", incidentId, userId);
            await Service.Get<IManagementSevice>().RemoveIncidentUser(incidentId, userId);
            Log.Out.EndInfo("RemoveIncidentUser {0}, {1}", incidentId, userId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("{incidentId}/org-unit/{orgUnitId}")]
        public async Task<HttpResponseMessage> AddIncidentOrgUnit([FromUri]int incidentId, [FromUri]int orgUnitId)
        {
            Log.Out.BeginInfo("AddIncidentOrgUnit {0}, {1}", incidentId, orgUnitId);
            await Service.Get<IManagementSevice>().AddIncidentOrgUnit(incidentId, orgUnitId);
            Log.Out.EndInfo("AddIncidentOrgUnit {0}, {1}", incidentId, orgUnitId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("{incidentId}/org-unit/{orgUnitId}")]
        public async Task<HttpResponseMessage> RemoveIncidentOrgUnit([FromUri]int incidentId, [FromUri]int orgUnitId)
        {
            Log.Out.BeginInfo("RemoveIncidentOrgUnit {0}, {1}", incidentId, orgUnitId);
            await Service.Get<IManagementSevice>().RemoveIncidentOrgUnit(incidentId, orgUnitId);
            Log.Out.EndInfo("RemoveIncidentOrgUnit {0}, {1}", incidentId, orgUnitId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
