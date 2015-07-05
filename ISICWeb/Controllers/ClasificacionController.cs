using ISIC.Entities;
using ISIC.Services;
using ISIC.Enums;
using ISICWeb.Models;
using ISICWeb.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MPBA.Jira;
using MPBA.Jira.Model;


namespace ISICWeb.Controllers
{
    [Audit]
    [Authorize]
    public class ClasificacionController : Controller
    {
        private IImputadoService imputadoService;
        private IBioDactilarService bioDactilarService;
         private IJiraService jiraService;

        public ClasificacionController(IImputadoService imputadoService,
                                       IBioDactilarService bioDactilarService)
        {
            this.imputadoService = imputadoService;
            this.bioDactilarService = bioDactilarService;
        }

        // GET: Clasificacion
        public ActionResult Index(string CodigoBarra)
        {
            if (!string.IsNullOrEmpty(CodigoBarra))
            {
                ViewBag.CodigoBarra = CodigoBarra;
            }
            return View();
        }
         
        [HttpPost]
        public ActionResult Index()
        {
            return View();
          
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResultadoBusquedaImputado(CodigoBarraViewModel model)
        {
            Imputado imputado = this.imputadoService.GetByCodigoBarra(model.CodigoBarra);

            if (imputado != null)
            {
                List<BioDactilar> BioManoDerecha = this.bioDactilarService.GetBioManoDerechaByCodigoBarra(model.CodigoBarra);
                List<BioDactilar> BioManoIzquierda = this.bioDactilarService.GetBioManoIzquierdaByCodigoBarra(model.CodigoBarra);

                if ((BioManoDerecha.Count > 0) && (BioManoIzquierda.Count > 0))
                {
                    ClasificacionViewModel cViewModel = new ClasificacionViewModel();
                    cViewModel.CodigoDeBarra = imputado.CodigoDeBarras;
                    cViewModel.Apellido = imputado.Persona.Apellido;
                    cViewModel.Nombre = imputado.Persona.Nombre;
                    cViewModel.BioManoDerecha = new BioDactilarMapper().MapFromModelList(BioManoDerecha);
                    cViewModel.BioManoIzquierda = new BioDactilarMapper().MapFromModelList(BioManoIzquierda);

                    return this.View(cViewModel);
                }
                else
                {
                    ModelState.AddModelError("", "Es necesario segmentar las huellas antes de clasificarlas.");
                    return this.View();
                }

            }
            else
            {
                ModelState.AddModelError("", "No existe ningún imputado con el código de barra ingresado.");
                return this.View();
            }

            
        }

        public ActionResult Clasificar(string idBiodactilar)
        {
            if (!string.IsNullOrEmpty(idBiodactilar))
            {
                BioDactilar bioDactilarDB = this.bioDactilarService.GetById(Convert.ToInt32(idBiodactilar));
                BioDactilarViewModel bioDactilar = new BioDactilarMapper().MapFromModel(bioDactilarDB);
                ViewBag.ListaClasificacion = this.bioDactilarService.GetListaClasificacionVuc().Select(p => new SelectListItem { Text = p.Descripcion, Value = p.Id.ToString() }).ToList();
                if (bioDactilarDB.DactilarVuc != null)
                    ViewBag.ListaSubClasificacion = this.bioDactilarService.GetListaSubClasificacionVuc(bioDactilarDB.DactilarVuc.Clasificacion.Id).Select(p => new SelectListItem { Text = p.Sigla + ": " + p.Descripcion, Value = p.Id.ToString() }).ToList();
                else
                    ViewBag.ListaSubClasificacion = new List<SelectListItem>();
                return View(bioDactilar);
            }
            return View();
        }

        public ActionResult Finalizar(string codBarra)
        {
            jiraService = new JiraService();
            Issue<IssueFields> issue = jiraService.GetIssue(codBarra);
            if (issue != null)
            {
                Transition transition = jiraService.GetTransitions(issue).First();
                jiraService.TransitionIssue(issue, transition);
            }
            return RedirectToAction("IndexPorTareas", "Imputado");
        }

        [HttpPost]
        public ActionResult Clasificar(BioDactilarViewModel BioDactilarViewModel)
        {
            try
            {
                BioDactilar BioDactilarDB = this.bioDactilarService.GetById(BioDactilarViewModel.Id);
                VucClasificacion clasificacion = this.bioDactilarService.GetClasificacionVuc(Convert.ToInt32(BioDactilarViewModel.DactilarVuc.Id));
                VucSubClasificacion subClasificacion = this.bioDactilarService.GetSubClasificacionVuc(Convert.ToInt32(BioDactilarViewModel.SubDactilarVuc.Id));
                if (BioDactilarDB.DactilarVuc == null)
                {
                    if (BioDactilarDB.Dedo == ClaseDedo.Pulgar)
                        BioDactilarDB.DactilarVuc = new VucClasificaPulgar();
                    else
                        BioDactilarDB.DactilarVuc = new VucClasificaDactilar();
                }
                BioDactilarDB.DactilarVuc.Clasificacion = clasificacion;
                BioDactilarDB.DactilarVuc.SubClasificacion = subClasificacion;
                this.bioDactilarService.Modificar(BioDactilarDB);

                return RedirectToAction("Index", "Clasificacion", new { CodigoBarra = BioDactilarViewModel.CodigoDeBarra });
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "No se pudieron guardar los cambios. Intentar nuevamente, si el problema persiste contacte al administrador del sistema.");
                return View(BioDactilarViewModel);
            }
        }

        public JsonResult GetSubclasificaciones(int idClasificacion)
        {
            var listaSubclasificaciones = (idClasificacion > 0) ?
                                this.bioDactilarService.GetListaSubClasificacionVuc(idClasificacion).Select(p => new SelectListItem { Text = p.Sigla + ": " + p.Descripcion, Value = p.Id.ToString() }).ToList()
                                : new List<SelectListItem>();

            return Json(listaSubclasificaciones, JsonRequestBehavior.AllowGet);
        }
        
        
        
    }
}
