using System;
using System.Diagnostics;
using System.Net.Http;
using System.Web;
using Any.Logs;
using Any.Logs.Extentions;
using MyCoop.WebApi.Helpers;

namespace MyCoop.WebApi.Loggers
{
    public static class LogExtensions
    {
        public static void Error(this Log log, string summary, params object[] values)
        {
            int? userId = UserHelper.TryGetId();
            Guid transactionId = TransactionHelper.GetId();
            summary = summary.Format(values);
            var description = new StackTrace(1).ToString();
            log.WriteAsync<EventLogger>(logger => logger.WriteAsync(summary, description, EventType.Error, userId, transactionId));
        }

        public static void Error(this Log log, Exception e, string summary, params object[] values)
        {
            int? userId = UserHelper.TryGetId();
            Guid transactionId = TransactionHelper.GetId();
            summary = summary.Format(values);
            var description = e.GetFullMessage();
            log.WriteAsync<EventLogger>(logger => logger.WriteAsync(summary, description, EventType.Error, userId, transactionId));
        }

        public static void Info(this Log log, string description, string summary, params object[] values)
        {
            int? userId = UserHelper.TryGetId();
            Guid transactionId = TransactionHelper.GetId();
            summary = summary.Format(values);
            log.WriteAsync<EventLogger>(logger => logger.WriteAsync(summary, description, EventType.Info, userId, transactionId));
        }

        public static void Info(this Log log, string summary, params object[] values)
        {
            log.Info(String.Empty, summary, values);
        }

        public static void BeginInfo(this Log log, string summary, params object[] values)
        {
            log.Info(String.Format("Begin {0}", summary), values);
        }

        public static void BeginInfo(this Log log, string description, string summary, params object[] values)
        {
            log.Info(description, String.Format("Begin {0}", summary), values);
        }

        public static void EndInfo(this Log log, string summary, params object[] values)
        {
            log.Info(String.Format("End {0}", summary), values);
        }

        public static void EndInfo(this Log log, string description, string summary, params object[] values)
        {
            log.Info(description, String.Format("End {0}", summary), values);
        }

        public static void UserActivity(this Log log, HttpRequestMessage request)
        {
            int? userId = UserHelper.TryGetId();
            Guid transactionId = TransactionHelper.GetId();
            var summary = request.RequestUri.AbsolutePath;
            var description = String.Format("ip: {1}{0}{2}", Environment.NewLine,
                ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress, request.Headers);
            log.WriteAsync<EventLogger>(logger => logger.WriteAsync(summary, description, EventType.UserActivity, userId, transactionId));
        }

        public static void UserActivity(this Log log, HttpResponseMessage response)
        {
            int? userId = UserHelper.TryGetId();
            Guid transactionId = TransactionHelper.GetId();
            var summary = String.Format("{0} {1} {2}", response.RequestMessage.RequestUri.AbsolutePath, (int)response.StatusCode, response.ReasonPhrase);
            var description = response.Content != null ? String.Format("{1}{0}{2}", Environment.NewLine, response.Content.Headers, response.Content.ReadAsStringAsync().Result) : String.Empty;
            log.WriteAsync<EventLogger>(logger => logger.WriteAsync(summary, description, EventType.UserActivity, userId, transactionId));
        }

        public static void LoginActivity(this Log log, string status, HttpRequestMessage request)
        {
            int? userId = UserHelper.TryGetId();
            Guid transactionId = TransactionHelper.GetId();
            var summary = status;
            var description = request.Headers.UserAgent.ToString();
            log.WriteAsync<EventLogger>(logger => logger.WriteAsync(summary, description, EventType.LoginActivity, userId, transactionId));
        }
    }
}