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
    public class RenaperResponseService : IRenaperResponseService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="composite"></param>
        /// <returns> 1 ok, 0 Error</returns>
        public int SendResponse(RenaperResponse composite)
        {
            logger.Info("Datos transacción");
            logger.Info("tcn: {0}, dni: {1}, sexo: {2}",composite.Tcn,composite.DNI,composite.Sexo);
            return 1;
        }
    }
}
