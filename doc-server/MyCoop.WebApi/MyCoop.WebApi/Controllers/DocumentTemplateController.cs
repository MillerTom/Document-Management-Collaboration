using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Any.Logs;
using Aspose.Words;
using Aspose.Words.Saving;
using MyCoop.WebApi.Extentions;
using MyCoop.WebApi.Filters;
using MyCoop.WebApi.Loggers;
using MyCoop.WebApi.Models.DocumentTemplates;
using MyCoop.WebApi.Services;
using Newtonsoft.Json;

namespace MyCoop.WebApi.Controllers
{
    [CoopAuthorize]
    [RoutePrefix("document-template")]
    public class DocumentTemplateController : ApiControllerBase
    {
        public DocumentTemplateController(IServiceManager serviceManager)
            : base(serviceManager)
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<HttpResponseMessage> Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<ITemplateService>().GetDocumentTemplates());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<ITemplateService>().GetDocumentTemplate(id));
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Update([FromUri] int id, [FromBody] EditDocumentTemplateModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "UpdateDocumentTemplate Id: {0}", id);
            await Service.Get<ITemplateService>().UpdateDocumentTemplate(id, model);
            Log.Out.EndInfo("UpdateDocumentTemplate Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            Log.Out.BeginInfo("DeleteDocumentTemplate Id: {0}", id);
            await Service.Get<ITemplateService>().DeleteDocumentTemplate(id);
            Log.Out.EndInfo("DeleteDocumentTemplate Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }




        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> Upload()
        {
            Log.Out.BeginInfo("AddDocumentTemplate");
            if (!Request.Content.IsMimeMultipartContent())
            {
                Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }
            var provider = GetMultipartProvider();
            var result = await Request.Content.ReadAsMultipartAsync(provider);

            var originalFileName = GetDeserializedFileName(result.FileData.First());
            var uploadedFileInfo = new FileInfo(result.FileData.First().LocalFileName);

            var temlateName = String.Format("{0}_{1}{2}", Path.GetFileNameWithoutExtension(originalFileName), Guid.NewGuid(), Path.GetExtension(originalFileName));
            var temlatePath = String.Format("{0}\\{1}", uploadedFileInfo.DirectoryName, temlateName);
            uploadedFileInfo.MoveTo(temlatePath);

            Log.Out.Info("Save file: {0}", temlatePath);

            var model = GetFormData<EditDocumentTemplateModel>(result);

            var doc = new Document(temlatePath);
            model.PagesCount = doc.PageCount;

            model.Link = String.Format("/Content/DocumentTemplates/{0}", temlateName);

            var options = new ImageSaveOptions(SaveFormat.Png);
            options.Resolution = 300;
            options.PageCount = 1;

            doc.Save(String.Format("{0}\\{1}.png",uploadedFileInfo.DirectoryName, Path.GetFileNameWithoutExtension(temlatePath)), options);

            Log.Out.Info(model.ToJson(), "Form model");

            var id = await Service.Get<ITemplateService>().AddDocumentTemplate(model);

            Log.Out.EndInfo("AddDocumentTemplate Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK, new { Id = id });

        }

        private MultipartFormDataStreamProvider GetMultipartProvider()
        {
            var uploadFolder = "~/Content/DocumentTemplates";
            var root = HttpContext.Current.Server.MapPath(uploadFolder);
            Directory.CreateDirectory(root);
            return new MultipartFormDataStreamProvider(root);

        }

        private T GetFormData<T>(MultipartFormDataStreamProvider result)
        {
            if (result.FormData.HasKeys())
            {
                var unescapedFormData = Uri.UnescapeDataString(result.FormData.GetValues(0).FirstOrDefault() ?? String.Empty);
                if (!String.IsNullOrEmpty(unescapedFormData))
                    return JsonConvert.DeserializeObject<T>(unescapedFormData);
            }
            return default(T);
        }

        private string GetDeserializedFileName(MultipartFileData fileData)
        {
            var fileName = GetFileName(fileData);
            return Path.GetFileName(fileName.Trim('\"'));
        }

        private string GetFileName(MultipartFileData fileData)
        {
            return fileData.Headers.ContentDisposition.FileName;
        }
    }
}
