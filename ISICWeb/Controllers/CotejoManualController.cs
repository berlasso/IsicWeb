
using ISICWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISICWeb.Services;
using DataTables.Mvc;

using ISIC.Entities;
using ISIC.Services;
using MPBA.Jira.Model;
using MPBA.Jira;
using MPBA.DataAccess;


namespace ISICWeb.Controllers
{
    public class CotejoManualController : Controller
    {

        
        private IJiraService jiraService;
        private ImputadosSimilaresService imputadoService;
        private IBioDactilarService bioDactilarService;
        private  IRepository repository;

        public CotejoManualController(ImputadosSimilaresService imputadoService,
                                       IBioDactilarService bioDactilarService,
            IJiraService jiraService, IRepository repository)
        {
            this.imputadoService = imputadoService;
            
            this.bioDactilarService = bioDactilarService;
            this.jiraService = jiraService;
            this.repository = repository;
        }



        // GET: CotejoManual

        public ActionResult UnificarImputados(string CodigoBarraImpNuevo, string CodigoBarraImpArchivo)
        {
            var issue = jiraService.GetIssue(CodigoBarraImpNuevo);
            if (issue != null)
            {  
                Transition transition = jiraService.GetTransitions(issue).First();

              //  issue = jiraService.TransitionIssue(issue, transition);
            }
            return View("Index");
        }

        public ActionResult FINCotejoAFIS(string CodigoBarraImpNuevo)
        {
            var issue = jiraService.GetIssue(CodigoBarraImpNuevo);
            if (issue != null)
            {  
                Transition transition = jiraService.GetTransitions(issue).First();

                //issue = jiraService.TransitionIssue(issue, transition);
            }
            return View("Index");
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
              
                  ViewBag.Edad = (DateTime.Now - imputadoBuscado.Persona.FechaNacimiento.Value).Days / 366;
                  ViewBag.NombreMadre = imputadoBuscado.Persona.Madre;
                  ViewBag.DocumentoNro = imputadoBuscado.Persona.DocumentoNumero;

                
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




        