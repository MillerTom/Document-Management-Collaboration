using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using Aspose.Words.Saving;
using _Document = Aspose.Words.Document;
namespace MyCoop.Services
{
    public class DocumentEditingTestService
    {
        private string dir = HttpRuntime.AppDomainAppPath + "\\documents\\";

        private string teamlabDir = HttpRuntime.AppDomainAppPath +
                                    WebConfigurationManager.AppSettings["storage-path"] + "__1/";
        public string FileId { get; private set; }
        public DocumentEditingTestService(string fileId)
        {
            FileId = fileId;
        }

        public string GetDownloadLink(string ext)
        {
            _Document doc = new _Document(dir + FileId);
            SaveOptions options = SaveOptions.CreateSaveOptions(FileId);
            string newFileName = FileId.Split('.')[0] + "." + ext;
            switch (ext)
            {
                case "rtf":
                    doc.Save(dir + newFileName, Aspose.Words.SaveFormat.Rtf);
                    break;
                case "pdf":
                    doc.Save(dir + newFileName, Aspose.Words.SaveFormat.Pdf);
                    break;
                default:
                    doc.Save(dir + FileId);
                    break;
            }
            return "/api/documents/" + newFileName;
        }
        public int SearchAndReplace(string search, string replace)
        {
            _Document doc = new _Document(dir + FileId);
            int result = doc.Range.Replace(search, replace, false, true);
            doc.Save(dir + FileId);
            //doc.Save(teamlabDir + FileId);
            return result;
        }

    }
}
