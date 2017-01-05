using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TMS.Web.Client.Startup))]
namespace TMS.Web.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
