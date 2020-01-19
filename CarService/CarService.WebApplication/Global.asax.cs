using CarService.WebApplication.Areas.Admin;
using CarService.WebApplication.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CarService.WebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapper.Mapper.Initialize(cfg => {
                cfg.AddProfile<AutoMapperProfile>();
                cfg.AddProfile<AdminModelsAutoMapperProfile>();
            });
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}