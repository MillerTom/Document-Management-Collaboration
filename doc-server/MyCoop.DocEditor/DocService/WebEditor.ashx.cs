using System;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Services;

namespace DocService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class WebEditor : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            switch (context.Request["type"])
            {
                case "get":
                    Get(context);
                    break;
                case "save":
                    Save(context);
                    break;
                case "upload":
                    Upload(context);
                    break;
                case "convert":
                    Convert(context);
                    break;
            }
        }

        private static void Get(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var fileName = context.Request["fileName"];
            if (string.IsNullOrEmpty(fileName))
            {
                context.Response.Write("error");
                return;
            }
            try
            {
                var fileUri = EditDefault.FileUri(fileName);
                var key = ServiceConverter.GenerateRevisionId(EditDefault.CurUserHostAddress + "/" + Path.GetFileName(fileUri));
                var validateKey = ServiceConverter.GenerateValidateKey(key);
                context.Response.Write(String.Format("{{ \"fileUri\": \"{0}\", \"key\": \"{1}\", \"validateKey\": \"{2}\" }}", fileUri, key, validateKey));
            }
            catch (Exception e)
            {
                context.Response.Write("{ \"error\": \"" + e.Message + "\"}");
            }
        }

        private static void Save(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            var downloadUri = context.Request["fileuri"];
            var fileName = context.Request["filename"];
            if (string.IsNullOrEmpty(downloadUri) || string.IsNullOrEmpty(fileName))
            {
                context.Response.Write("error");
                return;
            }

            var newType = Path.GetExtension(downloadUri).Trim('.');
            var currentType = (context.Request["filetype"] ?? Path.GetExtension(fileName)).Trim('.');

            if (newType.ToLower() != currentType.ToLower())
            {
                var key = ServiceConverter.GenerateRevisionId(downloadUri);

                string newFileUri;
                try
                {
                    var result = ServiceConverter.GetConvertedUri(downloadUri, newType, currentType, key, false, out newFileUri);
                    if (result != 100)
                        throw new Exception();
                }
                catch (Exception)
                {
                    context.Response.Write("error");
                    return;
                }
                downloadUri = newFileUri;
                newType = currentType;
            }

            fileName = Path.GetFileNameWithoutExtension(fileName) + "." + newType;

            var req = (HttpWebRequest) WebRequest.Create(downloadUri);

            try
            {
                using (var stream = req.GetResponse().GetResponseStream())
                {
                    if (stream == null) throw new Exception("stream is null");
                    const int bufferSize = 4096;

                    using (var fs = File.Open(EditDefault.StoragePath + fileName, FileMode.Create))
                    {
                        var buffer = new byte[bufferSize];
                        int readed;
                        while ((readed = stream.Read(buffer, 0, bufferSize)) != 0)
                        {
                            fs.Write(buffer, 0, readed);
                        }
                    }
                }
            }
            catch (Exception)
            {
                context.Response.Write("error");
                return;
            }

            context.Response.Write("success");
        }

        private static void Upload(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                context.Response.Write("{ \"filename\": \"" + EditDefault.DoUpload(context) + "\"}");
            }
            catch (Exception e)
            {
                context.Response.Write("{ \"error\": \"" + e.Message + "\"}");
            }
        }

        private static void Convert(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                context.Response.Write(EditDefault.DoConvert(context));
            }
            catch (Exception e)
            {
                context.Response.Write("{ \"error\": \"" + e.Message + "\"}");
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}