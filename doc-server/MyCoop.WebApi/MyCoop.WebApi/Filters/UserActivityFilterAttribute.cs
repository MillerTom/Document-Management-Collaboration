using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Any.Logs;
using MyCoop.WebApi.Loggers;

namespace MyCoop.WebApi.Filters
{
    public class UserActivityFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response != null)
            {
                Log.Out.UserActivity(actionExecutedContext.Response);
            }
            base.OnActionExecuted(actionExecutedContext);
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Log.Out.UserActivity(actionContext.Request);
            base.OnActionExecuting(actionContext);
        }
    }
}