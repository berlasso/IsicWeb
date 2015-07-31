using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ISIC.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class RenaperIdentityService : IRenaperIdentityService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private IVerifyIdentityService VIService;

        public RenaperIdentityService(IVerifyIdentityService VIService) 
        {
            logger.Info("Iniciando Servicio");
            this.VIService = VIService;
            logger.Info("Servicio Iniciado");
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="composite"></param>
        /// <returns> 1 ok, 0 Error</returns>
        public string VerifyIdentity(RenaperIdentityRequest request)
        {
            var tcn = VIService.Verify(request.DNI,request.Sexo,request.ImagenH1,request.ImagenH2,request.DescripsionH1,request.DescripsionH2);
            return tcn;            
        }
    }
}
