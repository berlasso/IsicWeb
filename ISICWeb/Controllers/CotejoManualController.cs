
using ISICWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISICWeb.Services;
using DataTables.Mvc;

using ISIC.Entities;

namespace ISICWeb.Controllers
{
    public class CotejoManualController : Controller
    {

        private ImputadosSimilaresService imputadoService;

        // GET: CotejoManual


       
         public CotejoManualController(ImputadosSimilaresService imputadoService)
        {
            this.imputadoService = imputadoService;
         }

         public ActionResult Index(string CodigoBarra)
         {
             if (!string.IsNullOrEmpty(CodigoBarra))
             {
                 ViewBag.CodigoBarra = CodigoBarra;
                 
             }
             ViewBag.ResultadoBusqueda = "";
             return View();
         }



          [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
         public ActionResult VisualizaParesDecaDactilares(string CodigoBarraImpNuevo, string CodigoBarraImpArchivo)
         {
             if (string.IsNullOrWhiteSpace(CodigoBarraImpNuevo) || string.IsNullOrWhiteSpace(CodigoBarraImpArchivo))
             {
                 ModelState.AddModelError("CodigoBarra","Código de barras incorrecto");
                 return View("Index");
             }
              // Primero espera el Imputado Nuevo
              // Segundo el imputado a buscar
             List<Imputado> imputadoList = new List<Imputado>();

             imputadoList.Add(imputadoService.GetByCodigoHuellas(CodigoBarraImpNuevo));
              imputadoList.Add(imputadoService.GetByCodigoHuellas(CodigoBarraImpArchivo));
                         
             return View(imputadoList);
            }
             

        /*Child View*/

         public ActionResult VisualizaImputadosPorProntuario(string CodProntuario, int Id, string imputadoAComparar)
         {

                       
            
             List<ImputadosSimilaresViewModel> ImpSimilares = imputadoService.ScorePorProntuario(CodProntuario,imputadoAComparar);

             ViewBag.IdEstrella = Id;
             ViewBag.DirectorioFoto =FuncionesGrales.DirectorioImagenes(imputadoAComparar,false,FuncionesGrales.TipoImagen.Rostro, 1);
             ViewBag.CodigoProntuario= CodProntuario;
             ViewBag.CodigoBarrasImpNuevo = imputadoAComparar;
             return View(ImpSimilares);



         }


          [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
         public ActionResult BusquedaNominal(string CodigoBarra)
         {
             if (string.IsNullOrWhiteSpace(CodigoBarra))
             {
                 ModelState.AddModelError("CodigoBarra", "Código de barras incorrecto");
                 return View("Index");
             }
             Imputado imputadoBuscado = null;
             List<ImputadosSimilaresViewModel> ImpSimilares = imputadoService.BusquedaSimilaresDatosPersonales(CodigoBarra, ref imputadoBuscado);

              if (imputadoBuscado == null)
              {
                    ModelState.AddModelError("CodigoBarra", "No se hallaron resultados");
                 return View("Index");
              }
              ViewBag.CodigoBarra = CodigoBarra;
                  /*la diferencia de 6 con la longitud la rellena con ceros a izquierda*/
                  ViewBag.Apellido = imputadoBuscado.Persona.Apellido;
                  ViewBag.Nombres = imputadoBuscado.Persona.Nombre;
                  ViewBag.Apodo = imputadoBuscado.Persona.Apodo;
                  ViewBag.Edad = imputadoBuscado.Persona.Edad;
                  ViewBag.NombreMadre = imputadoBuscado.Persona.Madre;
                  ViewBag.DocumentoNro = imputadoBuscado.Persona.DocumentoNumero;

                  // German    ViewBag.NombreArchivo = Server.MapPath(String.Format(@"/Images/FotosImputado/{0}/{1}/{2}", CodigoBarra.Substring(0, 4), (Convert.ToInt32(CodigoBarra.Substring(7, 5)) / 1000).ToString("00"), CodigoBarra+".JPG"));


                  //ViewBag.NombreArchivo = String.Format(@"~/Images/FotosImputado/{0}/{1}/{2}", CodigoBarra.Substring(0, 4), (Convert.ToInt32(CodigoBarra.Substring(7, 5)) / 1000).ToString("00"), CodigoBarra + ".JPG");

                  ViewBag.NombreArchivo = FuncionesGrales.DirectorioImagenes(CodigoBarra, false,
                      FuncionesGrales.TipoImagen.Rostro, 1);
                  if (ImpSimilares.Count() == 0)
                  {
                      ViewBag.ResultadoBusqueda = "No se han encontrado Imputados Coincidentes al ingresado";
                      ViewBag.CodigoBarra = null;
                      return View("Index");
                  }
              
              return View("BusquedaNominal", ImpSimilares);
             
         }





      
     

    }
}




        