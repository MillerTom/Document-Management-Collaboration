using System.Web;
using System.Web.Routing;

namespace DocService
{
    public class FontServiceRoute : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new FontService(requestContext);
        }
    }
}
