using System;
using System.Net;
using System.Web;
using FileConverterUtils2;
using log4net;

namespace DocService
{
    public class ResourceService : IHttpAsyncHandler
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(ResourceService));

        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, Object extraData)
        {
            bool bStartAsync = false;
            try
            {
                _log.Info("Starting process request...");
                _log.Info(context.Request.Params.ToString());

                Storage oStorage = new Storage();
                TaskResult oTaskResult = new TaskResult();
                string sPathOriginal = context.Request.Params["path"];
                string sPath = null;
                if (null != sPathOriginal)
                {
                    sPath = sPathOriginal.Replace("../", "").Replace("..\\", "");
                    if (sPathOriginal != sPath)
                    {
                        _log.Error("Possible XSS attack:" + sPathOriginal);
                    }
                }

                string sOutputFilename = context.Request.Params["filename"];

                string sDeletePathOriginal = context.Request.Params["deletepath"];
                string sDeletePath = null;
                if (null != sDeletePathOriginal)
                {
                    sDeletePath = sDeletePathOriginal.Replace("../", "").Replace("..\\", "");
                    if (sDeletePathOriginal != sDeletePath)
                    {
                        _log.Error("Possible XSS attack:" + sDeletePathOriginal);
                    }
                }
                if (string.IsNullOrEmpty(sOutputFilename))
                {
                    if (null != sPath)
                    {
                        int nIndex1 = sPath.LastIndexOf('/');
                        int nIndex2 = sPath.LastIndexOf('\\');
                        if (-1 != nIndex1 || -1 != nIndex2)
                        {
                            int nIndex = Math.Max(nIndex1, nIndex2);
                            sOutputFilename = sPath.Substring(nIndex + 1);
                        }
                        else
                            sOutputFilename = "resource";
                    }
                }

                context.Response.Clear();
                context.Response.Cache.SetExpires(DateTime.Now);
                context.Response.Cache.SetCacheability(HttpCacheability.Public);
                context.Response.ContentType = Utils.GetMimeType(sOutputFilename);
                string sUserAgent = context.Request.ServerVariables.Get("HTTP_USER_AGENT");
                if (false == string.IsNullOrEmpty(sUserAgent) && sUserAgent.Contains("MSIE"))
                    context.Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + context.Server.UrlEncode(sOutputFilename) + "\"");
                else
                    context.Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + sOutputFilename + "\"");
                if (null != sPath)
                {
                    TransportClass oTransportClass = new TransportClass(context, cb, oStorage, oTaskResult, sPath, sDeletePath);
                    StorageFileInfo oStorageFileInfo;
                    if (ErrorTypes.NoError == oStorage.GetFileInfo(sPath, out oStorageFileInfo) && null != oStorageFileInfo)
                    {
                        string sETag = oStorageFileInfo.m_oLastModify.Ticks.ToString("x");
                        DateTime oLastModified = oStorageFileInfo.m_oLastModify;

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

                            oStorage.ReadFileBegin(sPath, context.Response.OutputStream, ReadFileCallback, oTransportClass);
                            bStartAsync = true;
                        }
                    }
                    else
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                }
                else
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;

            }
            catch (Exception e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                _log.Error(context.Request.Params.ToString());
                _log.Error("Exeption catched in BeginProcessRequest:", e);
            }
            TransportClass oTempTransportClass = new TransportClass(context, cb, null, null, null, null);
            if (false == bStartAsync)
                cb(new AsyncOperationData(oTempTransportClass));
            return new AsyncOperationData(oTempTransportClass);
        }
        public void EndProcessRequest(IAsyncResult result)
        {
        }
        private void ReadFileCallback(IAsyncResult result)
        {
            TransportClass oTransportClass = result.AsyncState as TransportClass;
            HttpContext context = oTransportClass.m_oContext;
            try
            {
                Storage oStorage = oTransportClass.m_oStorage;
                if (null != oStorage)
                {
                    int nReadWriteBytes = 0;
                    ErrorTypes eResult = oStorage.ReadFileEnd(result, out nReadWriteBytes);
                    if (ErrorTypes.NoError != eResult)
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    else
                    {
                        context.Response.AddHeader("Content-Length", nReadWriteBytes.ToString());
                        context.Response.StatusCode = (int)HttpStatusCode.OK;
                    }
                    context.Response.Flush();
                    context.Response.End();
                }
                if (null != oTransportClass.m_sDeletePath && false == string.IsNullOrEmpty(oTransportClass.m_sDeletePath))
                {
                    TaskResult oTaskResult = oTransportClass.m_oTaskResult;

                    string sKey = oTransportClass.m_sDeletePath;

                    oTaskResult.RemoveBegin(sKey, RemoveTaskCallback, oTransportClass);
                }
                else
                {
                    oTransportClass.m_oCallback(new AsyncOperationData(oTransportClass));
                }
            }
            catch (Exception e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                oTransportClass.m_oCallback(new AsyncOperationData(oTransportClass));

                _log.Error("Exception catched in ReadFileCallback:", e);
            }
        }
        private void RemoveTaskCallback(IAsyncResult result)
        {
            TransportClass oTransportClass = result.AsyncState as TransportClass;
            HttpContext context = oTransportClass.m_oContext;
            try
            {
                TaskResult oTaskResult = oTransportClass.m_oTaskResult;

                if (null != oTaskResult)
                    oTaskResult.RemoveEnd(result);

                Storage oStorage = oTransportClass.m_oStorage;

                if (null != oStorage)
                    oStorage.RemovePathBegin(oTransportClass.m_sDeletePath, RemoveFileCallback, oTransportClass);
            }
            catch (Exception e)
            {
                oTransportClass.m_oCallback(new AsyncOperationData(oTransportClass));

                _log.Error("Exception catched in RemoveTaskCallback:", e);
            }
        }
        private void RemoveFileCallback(IAsyncResult result)
        {
            TransportClass oTransportClass = result.AsyncState as TransportClass;
            HttpContext context = oTransportClass.m_oContext;
            try
            {
                Storage oStorage = oTransportClass.m_oStorage;
                if (null != oStorage)
                    oStorage.RemovePathEnd(result);
                oTransportClass.m_oCallback(new AsyncOperationData(oTransportClass));
            }
            catch (Exception e)
            {
                oTransportClass.m_oCallback(new AsyncOperationData(oTransportClass));

                _log.Error("Exception catched in RemoveFileCallback:", e);
            }
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
        private class TransportClass
        {
            public HttpContext m_oContext;
            public AsyncCallback m_oCallback;
            public Storage m_oStorage;
            public TaskResult m_oTaskResult;
            public string m_sPath;
            public string m_sDeletePath;
            public TransportClass(HttpContext oContext, AsyncCallback oCallback, Storage oStorage, TaskResult oTaskResult, string sPath, string sDeletePath)
            {
                m_oContext = oContext;
                m_oCallback = oCallback;
                m_oStorage = oStorage;
                m_oTaskResult = oTaskResult;
                m_sPath = sPath;
                m_sDeletePath = sDeletePath;
            }
        }
    }
}