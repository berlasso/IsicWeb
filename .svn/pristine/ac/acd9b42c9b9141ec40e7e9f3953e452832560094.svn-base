using System.Web.Mvc;

namespace ISICWeb.Areas.PortalSIC
{
    public class PortalSICAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PortalSIC";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PortalSIC_default",
                "PortalSIC/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}