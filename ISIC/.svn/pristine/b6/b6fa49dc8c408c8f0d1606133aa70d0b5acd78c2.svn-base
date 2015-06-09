using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using ISIC.Services;
using MPBA.DataAccess;
using ISIC.Persistence.Context;
using ISICWeb.Controllers;
using MPBA.RenaperClient;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System;

namespace ISICWeb
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IDbContext, ISICContext>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IRepository, Repository>();
            container.RegisterType<IImputadoService, ImputadoService>();
            container.RegisterType<IBioDactilarService, BioDactilarService>();
            container.RegisterType<IJiraService, JiraService>();
            container.RegisterType<MegaMatcherService, MegaMatcherService>();
            container.RegisterType<ICotejoRenaperService, CotejoRenaperService>();            


            var url = ConfigurationManager.AppSettings["Renaper.url"];
            var subjectName = ConfigurationManager.AppSettings["Renaper.certificate.sn"];
            var storeLocation = ConfigurationManager.AppSettings["renaper.certificate.storelocation"];
            var storeName = ConfigurationManager.AppSettings["renaper.certificate.storename"];
            
            container.RegisterType<RenaperClient, RenaperClient>(
                new InjectionConstructor(
                    url, 
                    subjectName, 
                    (StoreLocation)Enum.Parse(typeof(StoreLocation), storeLocation),
                    (StoreName)Enum.Parse(typeof(StoreName), storeName)
                )
            );

            container.RegisterType<AccountController>(new InjectionConstructor(new ResolvedParameter<IRepository>()));
            //container.RegisterType<AccountController>(new InjectionConstructor());
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

    }
}