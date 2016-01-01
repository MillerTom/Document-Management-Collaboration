using System;
using System.IO;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;

namespace DocService
{
    public partial class DocEditor : Page
    {
        public static string FileName;

        public static string FileUri
        {
            get
            {
                var fileUri = EditDefault.FileUri(FileName);
                return fileUri;
            }
        }

        protected string Key
        {
            get
            {
                var key =
                    ServiceConverter.GenerateRevisionId(EditDefault.CurUserHostAddress + "/" + Path.GetFileName(FileUri));
                return key;
            }
        }

        protected string ValidateKey
        {
            get
            {
                var validateKey = ServiceConverter.GenerateValidateKey(Key);
                return validateKey;
            }
        }

        protected string DocServiceApiUri
        {
            get { return WebConfigurationManager.AppSettings["files.docservice.url.api"] ?? string.Empty; }
        }

        protected string DocumentType
        {
            get
            {
                var ext = Path.GetExtension(FileName).ToLower();

                if (FileType.ExtsDocument.Contains(ext)) return "text";
                if (FileType.ExtsSpreadsheet.Contains(ext)) return "spreadsheet";
                if (FileType.ExtsPresentation.Contains(ext)) return "presentation";

                return string.Empty;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var externalUrl = Request["fileUrl"];
            if (!string.IsNullOrEmpty(externalUrl))
            {
                FileName = EditDefault.DoUpload(externalUrl);
            }
            else
            {
                FileName = Request["fileID"];
            }

            var type = Request["type"];
            if (!string.IsNullOrEmpty(type))
            {
                Try(type);
                Response.Redirect("doceditor.aspx?fileID=" + HttpUtility.UrlEncode(FileName));
            }
        }

        private static void Try(string type)
        {
            string ext;
            switch (type)
            {
                case "document":
                    ext = ".docx";
                    break;
                case "spreadsheet":
                    ext = ".xlsx";
                    break;
                case "presentation":
                    ext = ".pptx";
                    break;
                default:
                    return;
            }
            var demoName = "demo" + ext;
            FileName = EditDefault.GetCorrectName(demoName);

            File.Copy(HttpRuntime.AppDomainAppPath + "app_data/" + demoName, EditDefault.StoragePath + FileName);
        }
    }
}