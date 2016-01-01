using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using Any.Logs;
using Any.Logs.Extentions;
using MyCoop.WebApi.Loggers;

namespace MyCoop.WebApi.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute 
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            Log.Out.Error(actionExecutedContext.Exception, "Api Exception");
            base.OnException(actionExecutedContext);
        }
    }
}