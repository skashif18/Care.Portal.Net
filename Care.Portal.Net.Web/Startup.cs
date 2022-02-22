using JobPortal.Data.Models.Repository.Employee;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Care.Portal.Net.Web.Startup))]
namespace Care.Portal.Net.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
       
    }
}
