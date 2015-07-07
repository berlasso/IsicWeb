using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ISICWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            logger.Info("Iniciando aplicacion..");
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            UnityConfig.RegisterComponents();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            logger.Info("Aplicacion iniciada!!");
        }
    }


}
