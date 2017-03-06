using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetosTiagomx.Startup))]
namespace ProjetosTiagomx
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
