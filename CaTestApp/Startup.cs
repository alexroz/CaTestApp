using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CaTestApp.Startup))]
namespace CaTestApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
