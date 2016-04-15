using System.Web.Mvc;

namespace myHost.WebSite1PlugIn
{
    public class WebSite1AreaRegister : AreaRegistration
    {
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "WebSite1_Default",
                "WebSite1/{controller}/{action}/{id}",
                new { controller = "TestWebSite1", action = "Index", id = UrlParameter.Optional }
                );
        }

        public override string AreaName { get { return "WebSite1"; } }
    }
}