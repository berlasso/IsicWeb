using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using MPBA.SIAC.BusinessEntities;
using System.Net;

namespace MPBA.SIAC.Web
{
    public partial class FuncionesGenerales
    {
      

        public  enum TipoDelitos
        {
            RobosHurtos = 1,
            Sexuales = 2
        }

        public  enum TipoAutores
        {
            Desconocidos = 1,
            Conocidos = 2,
            Todos=3
        }

     
        /// <summary>
        /// Trae delitos de la base del SIC
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="clave"></param>
        /// <param name="fltSexo">si es F o M</param>
        /// <param name="fltDomicilio"></param>
        /// <param name="fltLocalidad"></param>
        /// <param name="nombreSic"></param>
        /// <param name="apellidoSic"></param>
        /// <param name="docNroSic"></param>
        /// <param name="tipoAutor"></param>
        /// <returns></returns>
        public static DelitoSICList TraerDelitosSIC(string usuario, string clave, string fltSexo,string fltDomicilio, string fltLocalidad, string fltNombreSic,string fltApellidoSic,  string fltTatuaje, string fltEdadAprox, string fltIPP, string fltFisGralSic, string fltDocNroSic, TipoAutores tipoAutor, int cantMaxMostrar)
        {
            //MPBA.SIAC.BusinessEntities. Delitos miDelito = (Delitos)Session["miDelito"];
            //Autores miAutor = (Autores)Session["miAutor"];
         
            //*********************************
            //ARREGLAR*************************

            DelitoSICList delitos = new DelitoSICList();
            if (clave == "" || usuario == "")
                return delitos;

            //*********************************

            //int num = 100;
  
  
            //if (tipoAutor==TipoAutores.Conocidos)
            //{
            //    fltNombreSic = this.txtNombreBusquedaSic.Text.Trim();
            //    fltApellidoSic = this.txtApellidoBusquedaSic.Text.Trim();
            //    fltDocNroSic = this.txtDniBusquedaSic.Text.Trim();
            //}
            
          
            
            if (fltFisGralSic == "00")
                fltFisGralSic = "";
            //string urlFotosSic = "http://www.sic.mpba.gov.ar/cons1/frmBuscaXFoto.php?sid=siac&u=" + user + "&NroPagina=1&NroFila=0&NroFilaPrev=0&Sexo=" + fltSexo + "&IPP=" + fltIPP + "&EdadAprox=" + fltEdadAprox + "&Localidad=" + fltLocalidad + "&Tatuaje=" + fltTatuaje + "&Domicilio=" + fltDomicilio + "&FisGral="+ fltFisGralSic;
            
            string url = "http://www.sic.mpba.gov.ar/cons1/admin/webservice.php?user=" + usuario + "&clave=" + clave + "&num=" + cantMaxMostrar + "&Sexo=" + fltSexo + "&IPP=" + fltIPP + "&EdadAprox=" + fltEdadAprox + "&Localidad=" + fltLocalidad + "&Tatuaje=" + fltTatuaje + "&Domicilio=" + fltDomicilio + "&FisGral=" + fltFisGralSic + "&Nombre=" + fltNombreSic + "&Apellido=" + fltApellidoSic + "&DocNro=" + fltDocNroSic;
            WebRequest request = WebRequest.Create(url);
            request.Timeout = 30000;

            try
            {
                //throw new Exception();
                using (WebResponse response = request.GetResponse())
                using (XmlReader reader = XmlReader.Create(response.GetResponseStream()))
                {
                    DelitoSIC delito = new DelitoSIC();

                    try
                    {
                        int cantResultados = 0;
                        while (reader.Read())
                        {

      

                            switch (reader.Name)
                            {
                                case "delito":
                                    if (reader.IsStartElement())
                                    {
                                        delito = new DelitoSIC();
                                        cantResultados++;
                                    }
                                    else if (reader.NodeType == XmlNodeType.EndElement)
                                        delitos.Add(delito);
                                    break;
                                case "NroCarpeta":
                                    if (reader.NodeType == XmlNodeType.EndElement)
                                        continue;
                                    reader.Read();
                                    if (reader.HasValue)
                                    {
                                        delito.NroCarpeta = reader.Value;
                                    }
                                    break;
                                case "tatuaje":
                                    if (reader.NodeType == XmlNodeType.EndElement)
                                        continue;
                                    reader.Read();
                                    if (reader.HasValue)
                                    {
                                        delito.Tatuaje = reader.Value;
                                        if (delito.Tatuaje.ToLower().Trim() == "null")
                                            delito.Tatuaje = "";
                                    }
                                    break;
                                case "ProntuarioSic":
                                    if (reader.NodeType == XmlNodeType.EndElement)
                                        continue;
                                    reader.Read();
                                    if (reader.HasValue)
                                    {
                                        delito.ProntuarioSic = reader.Value;
                                        string prontuario = reader.Value;
                                        delito.LinkSic = "http://www.sic.mpba.gov.ar/cons1/ReportePrintSiac.php?ProntuarioSIC=" + prontuario + "&a=siacsic";
                                        //delito.LinkSic = "http://www.sic.mpba.gov.ar";
                                    }
                                    break;
                                case "Apellido":
                                    if (reader.NodeType == XmlNodeType.EndElement)
                                        continue;
                                    reader.Read();
                                    if (reader.HasValue)
                                    {
                                        delito.Apellido = reader.Value;
                                    }
                                    break;
                                case "Nombres":
                                    if (reader.NodeType == XmlNodeType.EndElement)
                                        continue;
                                    reader.Read();
                                    if (reader.HasValue)
                                    {
                                        delito.Nombres = reader.Value;
                                    }
                                    break;
                                case "TipoDOC":
                                    if (reader.NodeType == XmlNodeType.EndElement)
                                        continue;
                                    reader.Read();
                                    if (reader.HasValue)
                                    {
                                        delito.TipoDoc = reader.Value;
                                    }
                                    break;
                                case "DocNro":
                                    if (reader.NodeType == XmlNodeType.EndElement)
                                        continue;
                                    reader.Read();
                                    if (reader.HasValue)
                                    {
                                        delito.DocNro = reader.Value;
                                    }
                                    break;
                                case "FeNac":
                                    if (reader.NodeType == XmlNodeType.EndElement)
                                        continue;
                                    reader.Read();
                                    if (reader.HasValue)
                                    {
                                        delito.FeNac = reader.Value;
                                    }
                                    break;
                                case "LugarNac":
                                    if (reader.NodeType == XmlNodeType.EndElement)
                                        continue;
                                    reader.Read();
                                    if (reader.HasValue)
                                    {
                                        delito.LugarNac = reader.Value;
                                    }
                                    break;
                                case "PciaNac":
                                    if (reader.NodeType == XmlNodeType.EndElement)
                                        continue;
                                    reader.Read();
                                    if (reader.HasValue)
                                    {
                                        delito.PciaNac = reader.Value;
                                    }
                                    break;
                                case "PaisNac":
                                    if (reader.NodeType == XmlNodeType.EndElement)
                                        continue;
                                    reader.Read();
                                    if (reader.HasValue)
                                    {
                                        delito.PaisNac = reader.Value;
                                    }
                                    break;
                                case "codbarra":
                                    if (reader.NodeType == XmlNodeType.EndElement)
                                        continue;
                                    reader.Read();
                                    if (reader.HasValue)
                                    {
                                        delito.CodBarra = reader.Value;
                                    }
                                    break;
                                case "caratula":
                                    if (reader.NodeType == XmlNodeType.EndElement)
                                        continue;
                                    reader.Read();
                                    if (reader.HasValue)
                                    {
                                        delito.Caratula = reader.Value;
                                    }
                                    break;
                                case "Fecha":
                                    if (reader.NodeType == XmlNodeType.EndElement)
                                        continue;
                                    reader.Read();
                                    if (reader.HasValue)
                                    {
                                        delito.FechaDelito = reader.Value;
                                    }
                                    break;
                                case "ipp":
                                    if (reader.NodeType == XmlNodeType.EndElement)
                                        continue;
                                    reader.Read();
                                    if (reader.HasValue)
                                    {
                                        delito.Ipp = reader.Value;
                                    }
                                    break;
                                case "Sexo":
                                    if (reader.NodeType == XmlNodeType.EndElement)
                                        continue;
                                    reader.Read();
                                    if (reader.HasValue)
                                    {
                                        delito.Sexo = reader.Value;
                                    }
                                    break;
                            }
                        }
                       
                        if (cantResultados > 0)
                        {
            
                        }
                        else
                        {
                         

                        }


                    }
                    catch (XmlException)
                    {
          
                        return delitos;
                    }


             

                    if (delitos.Count > 0)
                    {
                   
                    }
                    else
                    {
                       
                    }
                    return delitos;
                }
            }
            catch (Exception e)
            {

  
                return delitos;
            }

        }
    }
}