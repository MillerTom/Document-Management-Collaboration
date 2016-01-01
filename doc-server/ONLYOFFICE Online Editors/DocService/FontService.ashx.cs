using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Routing;
using FileConverterUtils2;
using log4net;
using Microsoft.Win32;

namespace DocService
{
    public class FontService : IHttpAsyncHandler
    {
        //private readonly ILog _log = LogManager.GetLogger(typeof(FontServiceRoute));
        private readonly ILog _log = LogManager.GetLogger(typeof(FontService));
        private string m_sFontName = null;
        private readonly static System.Collections.Generic.Dictionary<string, string> m_mapFontNameToFullPath;
        static FontService()
        {
            m_mapFontNameToFullPath = new System.Collections.Generic.Dictionary<string, string>();
            DirectoryInfo dirWindowsFolder = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.System));
            string sWinFontDir = Path.Combine(dirWindowsFolder.FullName, "Fonts");
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts");
            if (null == key)
                key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Fonts");
            if (null != key)
            {
                string[] aValues = key.GetValueNames();
                for (int i = 0, length = aValues.Length; i < length; i++)
                {
                    string sCurPath = key.GetValue(aValues[i]) as string;
                    if (null != sCurPath && !string.IsNullOrEmpty(sCurPath))
                    {
                        if (Path.IsPathRooted(sCurPath))
                            m_mapFontNameToFullPath[Path.GetFileName(sCurPath).ToUpper()] = sCurPath;
                        else
                            m_mapFontNameToFullPath[sCurPath.ToUpper()] = Path.Combine(sWinFontDir, sCurPath);
                    }
                }
            }
        }
        public FontService(RequestContext context)
        {
            m_sFontName = Convert.ToString(context.RouteData.Values["fontname"]);
        }

        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, Object extraData)
        {
            bool bStartAsync = false;
            try
            {
                _log.Info("Starting process request...");
                _log.Info("fontname: " + m_sFontName);

                context.Response.Clear();
                context.Response.Cache.SetExpires(DateTime.Now);
                context.Response.Cache.SetCacheability(HttpCacheability.Public);
                context.Response.ContentType = Utils.GetMimeType(m_sFontName);
                if (context.Request.ServerVariables.Get("HTTP_USER_AGENT").Contains("MSIE"))
                    context.Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + context.Server.UrlEncode(m_sFontName) + "\"");
                else
                    context.Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + m_sFontName + "\"");

                string sConfigFontDir = ConfigurationManager.AppSettings["utils.common.fontdir"];
                string strFilepath;
                if (null != sConfigFontDir && string.Empty != sConfigFontDir)
                    strFilepath = Path.Combine(Environment.ExpandEnvironmentVariables(sConfigFontDir), m_sFontName);
                else
                    m_mapFontNameToFullPath.TryGetValue(m_sFontName.ToUpper(), out strFilepath);
                if (".js" == Path.GetExtension(m_sFontName))
                {
                    string[] aFontExts = { ".ttf", ".ttc", ".otf" };
                    for (int i = 0; i < aFontExts.Length; i++)
                    {
                        strFilepath = Path.ChangeExtension(strFilepath, aFontExts[i]);
                        if (File.Exists(strFilepath))
                            break;
                    }
                }
                FileInfo oFileInfo = new FileInfo(strFilepath);
                if (oFileInfo.Exists)
                {
                    DateTime oLastModified = oFileInfo.LastWriteTimeUtc;
                    string sETag = oLastModified.Ticks.ToString("x");

                    DateTime oDateTimeUtcNow = DateTime.UtcNow;

                    if (oLastModified.CompareTo(oDateTimeUtcNow) > 0)
                    {
                        _log.DebugFormat("LastModifiedTimeStamp changed from {0} to {1}", oLastModified, oDateTimeUtcNow);
                        oLastModified = oDateTimeUtcNow;
                    }

                    string sRequestIfModifiedSince = context.Request.Headers["If-Modified-Since"];
                    string sRequestETag = context.Request.Headers["If-None-Match"];
                    bool bNoModify = false;
                    if (false == string.IsNullOrEmpty(sRequestETag) || false == string.IsNullOrEmpty(sRequestIfModifiedSince))
                    {
                        bool bRequestETag = true;
                        if (false == string.IsNullOrEmpty(sRequestETag) && sRequestETag != sETag)
                            bRequestETag = false;
                        bool bRequestIfModifiedSince = true;
                        if (false == string.IsNullOrEmpty(sRequestIfModifiedSince))
                        {
                            try
                            {
                                DateTime oRequestIfModifiedSince = DateTime.ParseExact(sRequestIfModifiedSince, "R", System.Globalization.CultureInfo.InvariantCulture);
                                if ((oRequestIfModifiedSince - oLastModified).TotalSeconds > 1)
                                    bRequestIfModifiedSince = false;
                            }
                            catch
                            {
                                bRequestIfModifiedSince = false;
                            }
                        }
                        if (bRequestETag && bRequestIfModifiedSince)
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.NotModified;
                            bNoModify = true;
                        }
                    }
                    if (false == bNoModify)
                    {
                        context.Response.Cache.SetETag(sETag);
                        context.Response.Cache.SetLastModified(oLastModified);

                        FileStream oFileStreamInput = new FileStream(strFilepath, FileMode.Open, FileAccess.Read, FileShare.Read, (int)oFileInfo.Length, true);
                        byte[] aBuffer = new byte[oFileStreamInput.Length];
                        TransportClass oTransportClass = new TransportClass(context, cb, oFileStreamInput, aBuffer);
                        oFileStreamInput.BeginRead(aBuffer, 0, aBuffer.Length, ReadFileCallback, oTransportClass);
                        bStartAsync = true;
                    }
                }
                else
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            catch (Exception e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                _log.Error(context.Request.Params.ToString());
                _log.Error("Exeption catched in BeginProcessRequest:", e);
            }
            TransportClass oTempTransportClass = new TransportClass(context, cb, null, null);
            if (false == bStartAsync)
                cb(new AsyncOperationData(oTempTransportClass));
            return new AsyncOperationData(oTempTransportClass);
        }
        public void EndProcessRequest(IAsyncResult result)
        {
        }
        public void ProcessRequest(HttpContext context)
        {
            throw new InvalidOperationException();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        private void ReadFileCallback(IAsyncResult result)
        {
            TransportClass oTransportClass = result.AsyncState as TransportClass;
            HttpContext context = oTransportClass.m_oContext;
            try
            {
                FileStream oFileStreamInput = oTransportClass.m_oFileStreamInput;
                oTransportClass.nReadWriteBytes = oFileStreamInput.EndRead(result);
                oFileStreamInput.Dispose();
                if (oTransportClass.nReadWriteBytes <= 0)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    oTransportClass.m_oCallback(new AsyncOperationData(oTransportClass));
                }
                else
                {
                    byte[] aOutput = null;
                    if (".js" == Path.GetExtension(m_sFontName))
                    {
                        aOutput = GetJsContent(oTransportClass.m_aBuffer);
                        oTransportClass.nReadWriteBytes = aOutput.Length;
                    }
                    else
                        aOutput = oTransportClass.m_aBuffer;
                    context.Response.OutputStream.BeginWrite(aOutput, 0, aOutput.Length, WriteBufferCallback, oTransportClass);
                }
            }
            catch (Exception e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                oTransportClass.m_oCallback(new AsyncOperationData(oTransportClass));

                _log.Error("Exception catched in ReadFileCallback:", e);
            }
        }
        private void WriteBufferCallback(IAsyncResult result)
        {
            TransportClass oTransportClass = result.AsyncState as TransportClass;
            HttpContext context = oTransportClass.m_oContext;
            try
            {
                context.Response.OutputStream.EndWrite(result);
                context.Response.AddHeader("Content-Length", oTransportClass.nReadWriteBytes.ToString());
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                context.Response.Flush();
                context.Response.End();
                oTransportClass.m_oCallback(new AsyncOperationData(oTransportClass));
            }
            catch (Exception e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                oTransportClass.m_oCallback(new AsyncOperationData(oTransportClass));

                _log.Error("Exception catched in WriteBufferCallback:", e);
            }
        }
        private byte[] GetJsContent(byte[] aBuffer)
        {
            string data = Convert.ToBase64String(aBuffer);
            string sRes = string.Format("var __font_data1=\"{0}\";var __font_data1_idx = g_fonts_streams.length;g_fonts_streams[__font_data1_idx] = CreateFontData2(__font_data1,{1});__font_data1 = null;g_font_files[1].SetStreamIndex(__font_data1_idx);", data, aBuffer.Length);
            return Encoding.UTF8.GetBytes(sRes);
        }
        private class TransportClass
        {
            public HttpContext m_oContext;
            public AsyncCallback m_oCallback;
            public FileStream m_oFileStreamInput;
            public byte[] m_aBuffer;
            public int nReadWriteBytes;
            public TransportClass(HttpContext oContext, AsyncCallback oCallback, FileStream oFileStreamInput, byte[] aBuffer)
            {
                m_oContext = oContext;
                m_oCallback = oCallback;
                m_oFileStreamInput = oFileStreamInput;
                m_aBuffer = aBuffer;
            }
        }
    }
}