using ISIC.Utils;
using MPBA.RenaperClient;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIC.Services
{
    public class VerifyIdentityService : IVerifyIdentityService

    {
        private RenaperClient RenaperClient;   

        public VerifyIdentityService(RenaperClient RenaperClient) 
        {
            this.RenaperClient = RenaperClient;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DNI"></param>
        /// <param name="sexo"></param>
        /// <param name="imagenD1"></param>
        /// <param name="imagenD2"></param>
        /// <param name="?"></param>
        public string Verify(int DNI, string sexo, string imagenD1,string imagenD2, string DescripcionD1, string DescripcionD2) 
        {
            var tcn = RenaperClient.GenerarTransaccion(DNI, sexo, imagenD1, imagenD2, DescripcionD1, DescripcionD2);
            return tcn;
        }

    }

    public interface IVerifyIdentityService
    {
        string Verify(int DNI, string sexo, string imagenD1, string imagenD2, string DescripcionD1, string DescripcionD2);
    }

}
