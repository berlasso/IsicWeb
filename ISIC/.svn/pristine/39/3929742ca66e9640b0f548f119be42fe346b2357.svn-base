using MPBA.Jira;
using MPBA.Jira.Model;
using Neurotec;
using Neurotec.Images;
using Neurotec.Licensing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ISIC.Services
{
    public class MegaMatcherService
    {
        /// <summary>
        /// Convierte un Stream de una imagen a formato WSQ
        /// </summary>
        /// <param name="imageStream"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public byte[] ConvertStreamToWSQ(Stream imageStream, ImageFormat format) 
        {
            const string Components = "Images.WSQ";
            CheckLicense(Components);

            MemoryStream msWSQ = new MemoryStream();

            using (MemoryStream ms = new MemoryStream())
            {
                using (NImage nimage = NImage.FromStream(imageStream))
                {
                    using (var info = (WsqInfo)NImageFormat.Wsq.CreateInfo(nimage))
                    {
                        info.BitRate = WsqInfo.DefaultBitRate;
                        nimage.Save(msWSQ, info);
                    }
                }   
            }
            byte[] result = msWSQ.ToArray();
            msWSQ.Dispose();
            
            return result ;
        }


        /// <summary>
        /// Convierte un Stream de una imagen a formato WSQ en base 64.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public String ConvertStreamToWSQBase64(Stream image, ImageFormat format) 
        {
            var imageBytes = this.ConvertStreamToWSQ(image, format);
            var stringBase64  = Convert.ToBase64String(imageBytes);            
            return stringBase64 ;
        }

        /// <summary>
        /// Convierte un Stream de una imagen a formato WSQ en base 64.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public String ConvertBytesToWSQBase64(byte[] imagebytes, ImageFormat format)
        {
            MemoryStream msImage = new MemoryStream(imagebytes);
            var imageBytes = this.ConvertStreamToWSQ(msImage, format);
            var stringBase64 = Convert.ToBase64String(imageBytes);
            return stringBase64;
        }
        /// <summary>
        /// Metodo utilizado para chequear licencia
        /// @TODO@ levantar server y port de la configuración
        /// </summary>
        /// <param name="Components">string con los nombres de los componentes separados por ,</param>
        private void CheckLicense(String Components) 
        {
            var server = "mphv12";
            var port = 5000;
            if (!NLicense.ObtainComponents(server, port, Components))
            {
                throw new NotActivatedException(string.Format("No es posible obtener la licencia para los siguientes componentes: {0}", Components));
            }
        }
    }
}
