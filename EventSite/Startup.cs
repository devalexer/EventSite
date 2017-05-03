using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventSite.Startup))]
namespace EventSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
