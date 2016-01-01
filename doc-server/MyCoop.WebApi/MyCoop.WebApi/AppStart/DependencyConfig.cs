using System.Web.Http;
using System.Web.Mvc;
using MyCoop.WebApi.Core;

namespace MyCoop.WebApi.AppStart
{
    public static class DependencyConfig
    {
        public static void RegisterDependencies(HttpConfiguration config, ControllerBuilder controllerBuilder)
        {
            config.DependencyResolver = new WebApiDependencyResolver();
        }
    }
}