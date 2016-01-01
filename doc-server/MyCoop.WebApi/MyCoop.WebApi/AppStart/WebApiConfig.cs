using System.Net.Http.Headers;
using System.Web.Http;
using MyCoop.WebApi.Filters;
using Newtonsoft.Json.Serialization;

namespace MyCoop.WebApi.AppStart
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.Filters.Add(new ApiExceptionFilterAttribute());
            config.Filters.Add(new UserActivityFilterAttribute());
        }
    }
}
