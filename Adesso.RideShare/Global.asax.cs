using Adesso.RideShare.Service;
using Adesso.RideShare.Service.Interfaces;
using LightInject;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Adesso.RideShare
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var container = new ServiceContainer();
            container.RegisterApiControllers();
            container.EnableWebApi(GlobalConfiguration.Configuration);
            container.Register<IRideShareService, RideShareService>();
        }
    }
}
