using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Any.Logs;
using MyCoop.WebApi.Extentions;
using MyCoop.WebApi.Filters;
using MyCoop.WebApi.Loggers;
using MyCoop.WebApi.Models.WorkspaceTemplates;
using MyCoop.WebApi.Services;

namespace MyCoop.WebApi.Controllers
{
    [CoopAuthorize]
    [RoutePrefix("workspace-template")]
    public class WorkspaceTemplateController : ApiControllerBase
    {
        public WorkspaceTemplateController(IServiceManager serviceManager) : base(serviceManager)
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<HttpResponseMessage> Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<ITemplateService>().GetWorkspaceTemplates());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<ITemplateService>().GetWorkspaceTemplate(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> Add([FromBody] EditWorkspaceTemplateModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "AddWorkspaceTemplate");
            var id = await Service.Get<ITemplateService>().AddWorkspaceTemplate(model);
            Log.Out.EndInfo("AddWorkspaceTemplate - Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK, new { Id = id });
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Update([FromUri] int id, [FromBody] EditWorkspaceTemplateModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "UpdateWorkspaceTemplate - Id: {0}", id);
            await Service.Get<ITemplateService>().UpdateWorkspaceTemplate(id, model);
            Log.Out.EndInfo("UpdateWorkspaceTemplate - Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            Log.Out.BeginInfo("DeleteWorkspaceTemplate - Id: {0}", id);
            await Service.Get<ITemplateService>().DeleteWorkspaceTemplate(id);
            Log.Out.EndInfo("DeleteWorkspaceTemplate - Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("{id}/document-template")]
        public async Task<HttpResponseMessage> GetDocumentsByWorkspaceTemplateId(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<ITemplateService>().GetDocumentsByWorkspaceTemplateId(id));
        }

        [HttpPost]
        [Route("{workspaceTemplateId}/document-template/{documentTemplateId}")]
        public async Task<HttpResponseMessage> AddDocumentToWorkspaceTemplate([FromUri]int workspaceTemplateId, [FromUri]int documentTemplateId)
        {
            Log.Out.BeginInfo("AddDocument ({0}) To WorkspaceTemplate ({1})", workspaceTemplateId, documentTemplateId);
            await Service.Get<ITemplateService>().AddDocumentToWorkspaceTemplate(workspaceTemplateId, documentTemplateId);
            Log.Out.EndInfo("AddDocument ({0}) To WorkspaceTemplate ({1})", workspaceTemplateId, documentTemplateId);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpDelete]
        [Route("{workspaceTemplateId}/document-template/{documentTemplateId}")]
        public async Task<HttpResponseMessage> RemoveDocumentFromWorkspaceTemplate([FromUri]int workspaceTemplateId, [FromUri]int documentTemplateId)
        {
            Log.Out.BeginInfo("RemoveDocument ({0}) From WorkspaceTemplate ({1})", workspaceTemplateId, documentTemplateId);
            await Service.Get<ITemplateService>().RemoveDocumentFromWorkspaceTemplate(workspaceTemplateId, documentTemplateId);
            Log.Out.EndInfo("RemoveDocument ({0}) From WorkspaceTemplate ({1})", workspaceTemplateId, documentTemplateId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("{workspaceTemplateId}/component-template/{componentTemplateId}")]
        public async Task<HttpResponseMessage> AddComponentToWorkspaceTemplate([FromUri]int workspaceTemplateId, [FromUri]int componentTemplateId)
        {
            Log.Out.BeginInfo("AddComponent ({0}) To WorkspaceTemplate ({1})", workspaceTemplateId, componentTemplateId);
            await Service.Get<ITemplateService>().AddComponentToWorkspaceTemplate(workspaceTemplateId, componentTemplateId);
            Log.Out.EndInfo("AddComponent ({0}) To WorkspaceTemplate ({1})", workspaceTemplateId, componentTemplateId);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpDelete]
        [Route("{workspaceTemplateId}/component-template/{componentTemplateId}")]
        public async Task<HttpResponseMessage> RemoveComponentFromWorkspaceTemplate([FromUri]int workspaceTemplateId, [FromUri]int componentTemplateId)
        {
            Log.Out.BeginInfo("RemoveComponent ({0}) From WorkspaceTemplate ({1})", workspaceTemplateId, componentTemplateId);
            await Service.Get<ITemplateService>().RemoveComponentFromWorkspaceTemplate(workspaceTemplateId, componentTemplateId);
            Log.Out.EndInfo("RemoveComponent ({0}) From WorkspaceTemplate ({1})", workspaceTemplateId, componentTemplateId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
