namespace DocService
{
    using System;
    using System.Net;
    using System.Configuration;
    using System.Web;
    using System.IO;
    using System.Text;

    public class fileDownloader : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {

                System.IO.FileInfo file = new System.IO.FileInfo(Convert.ToString(context.Server.MapPath(context.Server.UrlDecode("~" + context.Request.Params[0]))));
                string sOutputFilename = null;
                if (context.Request.Params.Count > 1)
                    sOutputFilename = context.Server.UrlDecode(context.Request.Params[1]);
                if (string.IsNullOrEmpty(sOutputFilename))
                    sOutputFilename = file.Name;
                if (!file.Exists)
                    return;
                context.Response.Clear();
                context.Response.ContentType = "application/octet-stream";
                if (context.Request.ServerVariables.Get("HTTP_USER_AGENT").Contains("MSIE"))
                    context.Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + context.Server.UrlEncode(sOutputFilename) + "\"");
                else
                    context.Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + sOutputFilename + "\"");
                context.Response.AddHeader("Content-Length", file.Length.ToString());
                context.Response.TransmitFile(file.FullName);
                context.Response.Flush();
                context.Response.End();
            }
            catch (Exception) { }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public static string GetIP4Address()
        {
            return "1";

            string IP4Address = String.Empty;

            foreach (IPAddress IPA in Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }

            if (IP4Address != String.Empty)
            {
                return IP4Address;
            }

            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }

            return IP4Address;
        }
    }
}