using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISICWeb.Models
{
    public static class FuncionesGrales
    {
        private static string PathBaseVirtual = "https://test.mpba.gov.ar/isic/archivosisic";
        private static string PathBaseAbsoluto = @"\\mpaptest01\ArchivosIsic";
        /// <summary>
        /// Trae la ruta virtual desde la absoluta y viceversa
        /// </summary>
        /// <param name="fullPath">Ruta a cambiar</param>
        /// <param name="tipoSwap">Tipo de cambio</param>
        /// <returns>la ruta modificada</returns>
        public static string SwapPathsImagen(string fullPath, TipoSwap tipoSwap)
        {
            string newPath = "";
            switch (tipoSwap)
            {
                    case TipoSwap.AbsolutoAVirtual:
                    newPath = fullPath.Replace(PathBaseAbsoluto, PathBaseVirtual);
                    break;
                    case TipoSwap.VirtualAAbsoluto:
                    newPath = fullPath.Replace(PathBaseVirtual, PathBaseAbsoluto);
                    break;
            }
            return newPath;
        }

        /// <summary>
        /// Devuelve el directorio relativo completo de la imagen
        /// </summary>
        /// <param name="CodigoBarra">El cod de barras de la imagen a buscar</param>
        /// /// <param name="esMiniatura">Si la imagen es thumbnail</param>
        /// <param name="tipoImagen">Tipo de imagen deseada</param>
        /// <param name="nroImagen">El nro de imagen buscado</param>
        /// <returns></returns>
        public static string DirectorioImagenes(string CodigoBarra, bool esMiniatura, TipoImagen tipoImagen, int nroImagen)
        {
            
            
            if (CodigoBarra.Trim() == "")
                return "";
            else
            {
                CodigoBarra = CodigoBarra.ToUpper();
            }
            string dir = TraerNombreDir(tipoImagen);
            string dirThumb = esMiniatura ? "Thumbnails/" : "";
            string nro = nroImagen.ToString("00");
            //////////PRUEBA
            //pathbase = "/Areas/Otip/Content/uploads";
            //return String.Format(@"{0}/{1}{2}/{3}/{4}.JPG", pathbase, dirThumb, dir,  CodigoBarra.Substring(0, 4), (Convert.ToInt32(CodigoBarra.Substring(7, 5)) / 1000).ToString("00"), CodigoBarra);
            //////////////////////
            return String.Format(@"{0}/{1}{2}/{3}/{4}/{5}{6}.JPG",PathBaseVirtual,dirThumb, dir,  CodigoBarra.Substring(0, 4), (Convert.ToInt32(CodigoBarra.Substring(7, 5)) / 1000).ToString("00"),CodigoBarra, nro);

        }

        /// <summary>
        /// Devuelve el directorio absoluto completo de la imagen
        /// </summary>
        /// <param name="CodigoBarra">El cod de barras de la imagen a buscar</param>
        /// <param name="esMiniatura">Si la imagen es thumbnail</param>
        /// <param name="tipoImagen">Tipo de imagen deseada</param>
        /// <param name="nroImagen">El nro de imagen buscado</param>
        /// <returns></returns>
        public static string DirectorioAbsolutoImagenes(string CodigoBarra, bool esMiniatura, TipoImagen tipoImagen, int nroImagen)
        {
            if (CodigoBarra.Trim() == "")
                return "";
            else
            {
                CodigoBarra = CodigoBarra.ToUpper();
            }
            string dir = TraerNombreDir(tipoImagen);
            string dirThumb = esMiniatura ? @"Thumbnails\" : "";
            string nro = nroImagen.ToString("00");
            return String.Format(@"{0}\{1}{2}\{3}\{4}\{5}{6}.JPG",PathBaseAbsoluto,dirThumb, dir, CodigoBarra.Substring(0, 4), (Convert.ToInt32(CodigoBarra.Substring(7, 5)) / 1000).ToString("00"), CodigoBarra, nro);

        }

        public enum TipoImagen
        {
            Rostro = 0,
            Tatuaje = 1,
            Senas = 2,
            HuellasDactulares = 3,
            HuellasPalmares = 4,
            Documentacion = 5
        }

        private static string TraerNombreDir(TipoImagen tipo)
        {
            switch (tipo)
            {
                case TipoImagen.Rostro:
                    return "Rostros";
                case TipoImagen.Tatuaje:
                    return "Tatuaje";
                case TipoImagen.Senas:
                    return "Senas";
                case TipoImagen.HuellasDactulares:
                    return "Dactilares";
                case TipoImagen.HuellasPalmares:
                    return "Palmares";
                case TipoImagen.Documentacion:
                    return "Documentacion";
                default:
                    return "";
            }
        }

        public enum TipoSwap
        {
            VirtualAAbsoluto=1,
            AbsolutoAVirtual=2
        }
    }





}
