using System.Web.Http;
using System.Web.Http.Controllers;
using MyCoop.WebApi.Helpers;
using MyCoop.WebApi.Services;

namespace MyCoop.WebApi.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        private readonly IServiceManager _serviceManager;

        protected ApiControllerBase(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
            IsManualDispose = false;
        }

        public bool IsManualDispose { get; set; }

        protected IServiceManager Service
        {
            get { return _serviceManager; }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!IsManualDispose)
            {
                _serviceManager.Dispose();
            }
        }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            CultureHelper.SetCultureThread();
            base.Initialize(controllerContext);
        }
    }
}