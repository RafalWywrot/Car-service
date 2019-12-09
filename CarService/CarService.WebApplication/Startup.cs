using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarService.WebApplication.Startup))]
namespace CarService.WebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
