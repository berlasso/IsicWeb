using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Quartz;
using Quartz.Impl;
using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Bll;
using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Bll;

using System.Web.Mvc;
using System.Web.Routing;
using log4net;
using log4net.Config;
using log4net.Core;
using log4net.Repository.Hierarchy;
using log4net.Appender;
  

using System.Web.Http;
using System.Configuration;




namespace MPBA.SIAC.Web

{
    
    public class Global : System.Web.HttpApplication
    {
        ISchedulerFactory schedFact;
        IScheduler sched;
       public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



     


        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");
       
         /*   routes.MapRoute(
            "Fotos", // Route name
            "{controller}/{action}/{persona}/{indice}", // URL with parameters
            new { controller = "PBFotos", action = "GetImageById", persona = UrlParameter.Optional, indice = UrlParameter.Optional } // Parameter defaults
        );*/
            routes.MapRoute("Default", // Route name
            "{controller}/{action}/{id}", // URL with parameters
            new { controller = "Home", action = "Index", id = "" },
            new[] { "MPBA.SIAC.Web.Controllers" }   // Parameter defaults
            );
         
                 

        }
        void Application_Start(object sender, EventArgs e)
        {


            //WebApiConfig.Register(GlobalConfiguration.Configuration);
         
         
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            //AuthConfig.RegisterAuth();

            /*permite pasar como parametros byte[]
             * http://www.prideparrot.com/blog/archive/2012/6/model_binding_posted_file_to_byte_array
             */
            ModelBinders.Binders.Remove(typeof(byte[]));
            ModelBinders.Binders.Add(typeof(byte[]), new MPBA.SIAC.Web.Models.MetaDataClass.CustomByteArrayModelBinder());

            /**/

            AreaRegistration.RegisterAllAreas();
            
                         
            
 
             RegisterGlobalFilters(GlobalFilters.Filters);

            RegisterRoutes(RouteTable.Routes);
            schedFact = new StdSchedulerFactory();
            sched = schedFact.GetScheduler();
            sched.Start();
            Application["scheduler"] = sched;
            log4net.Config.XmlConfigurator.Configure();

            log.Info("Se ejecuta desde el Application_Start");
         /*   log.Debug("log Debug");
            log.Info("log Info");
            log.Warn("log Warn");
            log.Error("log Error");
            log.Fatal("log Fatal");*/
            //***************************************
            //ENVIO DE MAILS                        *
            ProgramarSchedulerCoincidencias(09,00);//control diario de coincidencias xa envio x mail
            //***************************************                  
            ViewEngines.Engines.Add(new RazorViewEngine()); 
        }
     

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
            log.Info("Se ejecuta desde el Application_End");

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
  
                 Exception ex = Server.GetLastError();
                log.Error("Exception - \n" + ex); 
              


        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

        public IScheduler getScheduler()
        {
            return sched;
        }

        /// <summary>
        /// Lanza el scheduler para la busqueda diaria de coincidencias
        /// </summary>
        public void ProgramarSchedulerCoincidencias(int horaArranque, int minutosArranque)
        {
            //Trigger trigger = TriggerUtils.MakeImmediateTrigger(1, new TimeSpan(1, 1, 0));
            Trigger trigger = TriggerUtils.MakeDailyTrigger(horaArranque, minutosArranque);
            log.Info("Configura el Trigger a las :"+Convert.ToString(horaArranque)+" " + Convert.ToString(minutosArranque)) ;
            JobDetail jdBusquedaCoincidencias = new JobDetail(Guid.NewGuid().ToString(), null, typeof(MPBA.PersonasBuscadas.Web.BuscarCoincidenciasJob));
            jdBusquedaCoincidencias.JobDataMap["sched"] = sched;
            trigger.Name = Guid.NewGuid().ToString();
            getScheduler().ScheduleJob(jdBusquedaCoincidencias, trigger);
        }


    }


}

