using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(irg.Backend.Startup))]
namespace irg.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
