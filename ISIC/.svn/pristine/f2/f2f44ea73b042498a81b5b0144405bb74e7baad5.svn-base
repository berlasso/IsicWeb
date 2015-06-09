using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIC.Utils
{
    /// <summary>
    /// Clase con extensions methods que permiten convertir una imagen a string base64 y viceversa
    /// </summary>
    public static class ImageConverter
    {
        /// <summary>
        /// Metodo utilizado para convertir una Imagen en formato Base64
        /// </summary>
        /// <example>  
        /// Ejemplo de uso:
        /// <code> 
        ///         Image img = Image.FromStream(stream);
        ///         var imgbase64 = img.ImageToBase64(ImageFormat.Png); 
        /// </code> 
        /// </example>
        /// <param name="image"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string ImageToBase64(this Image image,System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string BitmapToBase64(this Bitmap image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <example>  
        /// Ejemplo de uso:
        /// <code> 
        ///      var stringBase64 = "ssss";
        ////     Image img = stringBase64.Base64ToImage();
        /// </code> 
        /// </example>
        /// <param name="base64String">Imagen en formato base64</param>
        /// <returns>Imagen convertida</returns>
        public static Image Base64ToImage(this string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
    }
}
