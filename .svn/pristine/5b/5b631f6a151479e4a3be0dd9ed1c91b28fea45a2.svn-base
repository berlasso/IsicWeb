using System.Web.Mvc;

namespace ISICWeb.Areas.Otip
{
    public class OtipAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Otip";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Otip_default",
                "Otip/{controller}/{action}/{id}",
                new {controller="ImputadoOtip", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}    