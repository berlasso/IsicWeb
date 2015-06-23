using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using ISIC.Entities;
using ISICWeb.Areas.Otip.Models;
using ISICWeb.simpWs;
using MPBA.DataAccess;
using RestSharp;


namespace ISICWeb.Areas.Otip.Controllers
{
    public class BuscadorSimpController : Controller
    {
        IRepository repository;

        public BuscadorSimpController(IRepository repository)
        {
            this.repository = repository;
        }

        
        public JsonResult BuscarIppSimpPrueba(string ipp)
        {
            ipp = ipp.Trim();
            ipp = ipp.Replace("-", "");
            if (ipp.Length < 12)
            {
                const string error = "Error: IPP inválida";
                return Json(new { HuboError = true, errorMessage = error }, JsonRequestBehavior.AllowGet);
            }
            Uri uriSimp = new Uri(ConfigurationManager.AppSettings["webapiSimp"]);
            var client = new RestClient
            {
                BaseUrl = uriSimp,
                Authenticator = new HttpBasicAuthenticator("userwebapi", "pa$$w0rd")
            };
            var request = new RestRequest("api/mv/Causa/SearchCausa?", Method.GET) { RequestFormat = DataFormat.Json };
            request.AddQueryParameter("IPP", ipp);
            request.AddQueryParameter("Alcance", "00");//00 si no tiene desdoble. 01, 02,etc segun los desdobles
            request.AddQueryParameter("Prefijo", "PP"); //Proceso Penal
            request.AddQueryParameter("CausaRecords", "true");//trae los registros relacionados
            var response = client.Execute<List<WebApiSimpModel>>(request);
            if (response.Data == null)
            {
                string error = string.IsNullOrEmpty(response.ErrorMessage)
                    ? "IPP inexistente en el SIMP"
                    : response.ErrorMessage;
                
                return Json(new { HuboError = true, errorMessage = error }, JsonRequestBehavior.AllowGet);
            }

            JsonResult json = Json(new { HuboError = false, DatosSimp = response.Data }, JsonRequestBehavior.AllowGet);
            return json;
        }

    //    public JsonResult BuscarIppSimp(string ipp)
    //    {
    //        ipp = ipp.Trim();
    //        if (ipp.Length < 12)
    //        {
    //            const string error = "Error: IPP inválida";
    //            return Json(new { HuboError = true, errorMessage = error }, JsonRequestBehavior.AllowGet);
    //        }
    //        ipp = ipp.Replace("-", "");
    //        string nombre = "", apellido = "",caratula;
    //        JsonResult json = null;
    //        //060000507315
    //        WebServiceMesaVirtualNN ws = new WebServiceMesaVirtualNN();
    //        string alcance = ipp.Substring(0, 2) == "06" ? "00" : "NULL";
    //        ws.Url = "https://sistemas.mpba.gov.ar/NN/WebServiceMesaVirtualNN.asmx?wsdl";
    //        ArrayList jsonImputados = new ArrayList();
    //        try
    //        {
    //            caratula = ws.ConsultaCaratula(ipp, alcance);

    //        }
    //        catch
    //        {
    //            const string error = "Error al intentar conectarse al WebService";
    //            return  Json(new {HuboError = true, errorMessage = error},JsonRequestBehavior.AllowGet);
    //        }

    //        if (caratula == "")
    //        {
    //            const string error = "IPP inexistente en el SIMP";
    //            return Json(new { HuboError = true, errorMessage = error }, JsonRequestBehavior.AllowGet);
    //        }

    //        XDocument soap = XDocument.Parse(caratula);
                
    //            if (soap.Elements().Any())
    //            {
    //                var causa = soap.Elements().First();
    //                var ufi = soap.Elements().First().Attribute("UFI").Value;
    //                var titularUfi = soap.Elements().First().Attribute("TitularUFI").Value.Replace(",", " ");
    //                var titularJg = soap.Elements().First().Attribute("TitularJG").Value.Replace(",", " ");
    //                var juzGar = soap.Elements().First().Attribute("JuzgadoGarantia").Value.Replace(",", " ");
    //                var depPol = soap.Elements().First().Attribute("SedePolicial").Value.Replace(",", " ");
    //                var fechaDelito = soap.Elements().First().Attribute("FechaHecho") == null ? "" : soap.Elements().First().Attribute("FechaHecho").Value;
    //                var hecho = "";
    //                var delitos = soap.Descendants("Delitos").Descendants();
    //                foreach (var delito in delitos)
    //                {
    //                    hecho += delito.Attribute("Descripcion").Value+", ";
    //                }
    //                if (hecho.EndsWith(", "))
    //                    hecho = hecho.Substring(0, hecho.Length - 2);
    //                var personas = soap.Descendants("personas");
                    
    //                foreach (var persona in personas)
    //                {
    //                    var imputados = persona.Descendants("Imputado");
    //                    foreach (var imputado in imputados)
    //                    {
    //                        nombre = imputado.Attribute("Nombre").Value;
    //                        apellido = imputado.Attribute("Apellido").Value;
    //                        int sexo = 0;
    //                        if (nombre != "")
    //                        {
    //                            var j = nombre.IndexOf(" ", StringComparison.Ordinal);
    //                            var nombreBuscado = nombre;
    //                            if (j != null && j>-1)
    //                                nombreBuscado = nombre.Substring(0, j).ToLower();
    //                            var nombreGral =
    //                                repository.Set<ClaseNombre>().FirstOrDefault(n => n.descripcion.ToLower() == nombreBuscado);

    //                            if (nombreGral != null)
    //                            {
    //                                sexo = nombreGral.sexo.Id;
    //                            }
    //                        }
    //                        jsonImputados.Add(new { ufi, titularUfi, titularJg, juzGar, depPol, fechaDelito, nombre, apellido, sexo, hecho });
    //                    }

    //                }
                    
    //            }
            
          
    //        json = Json(new {HuboError=false, ImputadosSimp=jsonImputados}, JsonRequestBehavior.AllowGet);
    //        return json;
    //    }
    }
}