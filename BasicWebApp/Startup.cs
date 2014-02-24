using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BasicWebApp.Startup))]
namespace BasicWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
