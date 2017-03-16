using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TM.IdentityIsolation.MVC.Startup))]
namespace TM.IdentityIsolation.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
