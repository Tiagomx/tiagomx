using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TM.Presentation.UI.App_Start;

namespace TM.Presentation.UI
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}