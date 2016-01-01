using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace MyCoop.WebApi.Core
{
    public class WebApiDependencyResolver : IDependencyResolver
    {
        public void Dispose()
        {
            
        }

        public object GetService(Type serviceType)
        {
            if (serviceType.IsSubclassOf(typeof(ApiController)))
            {
                return Activator.CreateInstance(serviceType, new ServiceManager());
            }
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Enumerable.Empty<object>();
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }
    }
}