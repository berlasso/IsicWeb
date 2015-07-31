using Microsoft.Practices.Unity;
using MPBA.RenaperClient;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;
using Unity.Wcf;

namespace ISIC.Services
{
	public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterType<MegaMatcherService, MegaMatcherService>();

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

            container.RegisterType<IVerifyIdentityService, VerifyIdentityService>();
            container.RegisterType<IRenaperIdentityService, RenaperIdentityService>();
            container.RegisterType<ICapturaDecaDactilarService, CapturaDecaDactilarService>();

            container.RegisterType<ICapturaDecaDactilarService, CapturaDecaDactilarService>();
            container.RegisterType<IImputadoService, ImputadoService>();
             container.RegisterType<IBioDactilarService, BioDactilarService>();
             container.RegisterType<MPBA.DataAccess.IRepository, MPBA.DataAccess.Repository>();
             container.RegisterType<MPBA.DataAccess.IUnitOfWork, MPBA.DataAccess.UnitOfWork>();
             container.RegisterType<MPBA.DataAccess.IDbContext, ISIC.Persistence.Context.ISICContext>();
        
            
            
        }
    }    
}