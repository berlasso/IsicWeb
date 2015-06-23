using System;
using System.EnterpriseServices;
using System.Linq;
using System.Web.Mvc;
using DataTables.Mvc;
using ISIC.Entities;
using MPBA.DataAccess;
using ISICWeb.Areas.Otip.Models;
using System.Linq.Dynamic;
using System.Security.Claims;
using System.Text.RegularExpressions;
using ISIC.Persistence.Context;
using ISIC.Services;
using ISICWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MPBA.Jira.Model;
using ImputadoService = ISICWeb.Services.ImputadoExtraService;
using Session = Glimpse.AspNet.Tab.Session;

namespace ISICWeb.Areas.Otip.Controllers
{
    [Authorize]
    public class ImputadoOtipController : Controller
    {
        
        
        IRepository repository;
        private ImputadoService ImputadoSrv;
        private IJiraService _jiraService;
        /// <summary>

        /// Application DB context

        /// </summary>

        protected ApplicationDbContext ApplicationDbContext { get; set; }

        /// <summary>

        /// User manager - attached to application DB context

        /// </summary>

        protected UserManager<ApplicationUser> UserManager { get; set; }

        public ImputadoOtipController(IRepository repository, ImputadoService service, IJiraService jiraService)
        {
            this.repository = repository;
            _jiraService = jiraService;
            ImputadoSrv = service;
        }

        #region GETS
        // GET: Imputado
        public ActionResult Index()
        {

         
            return View();
        }

        public ActionResult DetalleConCodBarra(string cb, bool pe = false)
        {

            ViewBag.WordDocumentFilename = "AboutMeDocument";
            Imputado imputado = repository.Set<Imputado>().SingleOrDefault(x => x.CodigoDeBarras == cb);
            if (imputado != null)
            {


                DatosGeneralesViewModel model = ImputadoSrv.LlenarViewModelConImputado(imputado.Id, pe);
                if (model != null)
                    return View("Detalle", model);
                
            }
            String error = "No se encontrol el registro solicitado";
            return View("~/Views/Shared/Error.cshtml",error);
        }

        /// <summary>
        /// Trae detalle del delito
        /// </summary>
        /// <param name="id">id del imputado</param>
        /// <param name="pe">si es para editar</param>
        /// <returns></returns>
        public ActionResult Detalle(int id, bool pe = false)
        {

            ViewBag.WordDocumentFilename = "AboutMeDocument";
            DatosGeneralesViewModel model = ImputadoSrv.LlenarViewModelConImputado(id, pe);
            if (model != null) return View(model);
            RedirectToAction("Index");
            return null;
        }

        // GET: Imputado/AltaModificacion/5
        [HttpGet]
        public ActionResult AltaModificacion(int? id)
        {
            ViewBag.SubCodBarra = "0200";//((ClaimsIdentity)User.Identity).FindFirst("subCodBarra").Value;


            if (id != null && id > 0) //para modificar
                return RedirectToAction("Detalle", "ImputadoOtip", new { id, pe = true });
            DatosGeneralesViewModel datosGenerales = ImputadoSrv.CrearViewModel();
            return View("Detalle", datosGenerales);
        }

        // GET: Imputado/Borrar/5
        public bool Borrar(int id)
        {


            bool borroBien = false;
            Imputado imp = repository.Set<Imputado>().SingleOrDefault(x => x.Id == id);
            if (imp != null)
            {
                imp.Baja = true;
                repository.UnitOfWork.RegisterChanged(imp);
                try
                {
                    repository.UnitOfWork.Commit();
                    borroBien = true;
                }
                catch { }
                

            }
            if (!borroBien)
                ModelState.AddModelError("",
                    "No se pudieron guardar los cambios. Intentar nuevamente, si el problema persiste contacte al administrador del sistema.");
           
            return borroBien;
        }

        public int BuscarIdImputado(string codBarras)
        {
            Imputado imputado = new ImputadoService(repository).GetByCodigoBarra(codBarras);

            return imputado == null ? 0 : imputado.Id;
        }

        public bool BuscarDelito(string codBarras)
        {
            bool existente = ImputadoSrv.GetByCodigoBarra(codBarras) != null;
            //if (existente)
            //{
            //    ModelState.AddModelError("CodBarras","Codigo de Barras existente");
            //}
            return existente;
        }

        public string TraerCodigoBarasAutogenerado()
        {
            var subCodBarra = ((ClaimsIdentity) User.Identity).FindFirst("subCodBarra").Value;
            var cb =
                repository.Set<Imputado>()
                    .Where(x => x.CodigoDeBarras.Substring(2, 4) == subCodBarra)
                    .OrderByDescending(x => x.CodigoDeBarras).Select(x=>x.CodigoDeBarras).FirstOrDefault();
            if (cb == null)
                cb = string.Format("01{0}000001X", subCodBarra);
            else
            {
                cb=(Convert.ToInt64(cb.Substring(0,12)) + 1).ToString("000000000000")+"X";
            }
            return cb;
        }

        #endregion
        #region POSTs
        // POST: Otip/AltaModificacion
        [HttpPost]
        public ActionResult AltaModificacion(DatosGeneralesViewModel imp)
        {
            string errores = "";
            if (ModelState.IsValid)
            {

                var idPuntoGestion = "2866";// ((ClaimsIdentity)User.Identity).FindFirst("idPuntoGestion").Value;
                var subCodBarra = "0200";//((ClaimsIdentity)User.Identity).FindFirst("subCodBarra").Value;
                
                if (idPuntoGestion == null)
                {
                    errores = "No hay punto de gestion asociado al usuario";
                }
                if (subCodBarra == null)
                {
                    errores = "No hay subcodigobarras asociado al usuario";
                }
                if (imp.Id == 0 && imp.CodBarras.Substring(2, 4) != subCodBarra)
                {
                    errores = "Código de barras no pertenece a la OTIP";
                }
                else if (imp.Id == 0 && BuscarDelito(imp.CodBarras) == true)
                {
                    errores = "Código de barras existente en la base de datos del SIC";
                }
                else
                {
                    errores = ImputadoSrv.GuardarImputadoDesdeViewModel(imp, idPuntoGestion);


                }
                if (errores != "")
                {
                    ModelState.AddModelError("", errores);


                    return PartialView("SummaryError", imp);
                }
                else
                {
                    
                }

                return null;
            }
            else
            {

                return PartialView("SummaryError", imp);
            }

        }
        #endregion

        //public ApplicationUser TraerApplicationUserActual()
        //{
        //    this.ApplicationDbContext = new ApplicationDbContext();
        //    UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        //    return UserManager.FindById(User.Identity.GetUserId());
        //}
        [Authorize]
        public JsonResult MostrarImputados([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            //Para visualistar delitos tengo que controlar que el punto de gestion de quien dio de alta el delito(usuarioCreacionI)
            //coincida con el punto de gestion de quien esta haciendo la consulta(tablas persona y personalpoderjudicial) y 'opcionalmente'
            //filtrar por substring del codbarra de dicho punto de gestion (tabla clasecodbarrapuntogestion)
          
            /////////////////////////////////////////////

            //ApplicationUser user = TraerApplicationUserActual();

            var subCodBarra = "0200";// ((ClaimsIdentity)User.Identity).FindFirst("subCodBarra").Value;
            var idPuntoGestion = "2866";// ((ClaimsIdentity)User.Identity).FindFirst("idPuntoGestion").Value;

            ISICContext context = (ISICContext)repository.UnitOfWork.Context;            
            var imputados = (from i in context.Imputado
                             from a in context.Archivo.Where(a=>a.Imputado.Id==i.Id && a.TipoArchivo.Id==1).Take(1).DefaultIfEmpty()
                             where i.Estado.Id == 9  //en OTIP
                                    && i.Baja!=true
                                    //&& (a==null || a.Imputado.Id==i.Id && (a.TipoArchivo==null || a.TipoArchivo.Id==1))
                                   && i.CodigoDeBarras.Substring(2, 4) == subCodBarra && //codbarras coincide con el permitido al usuario 
                                   i.PuntoGestionCreacionI.Id == idPuntoGestion //el punto de gestion que dio de alta es el mismo al que pertenece el usuario
                             select new {ThumbUrl=a.ThumbUrl.Replace("~",""), i.CodigoDeBarras, i.Persona.Apellido, i.Persona.Nombre, i.Persona.DocumentoNumero,Borrar="",i.Id});
            var cant = imputados.Count();
            //var filteredColumns = requestModel.Columns.GetFilteredColumns();
            //foreach (var column in filteredColumns)
            //    Filtrar(column.Data, column.Search.Value, column.Search.IsRegexValue);

            var sortedColumns = requestModel.Columns.GetSortedColumns();
            var isSorted = false;
           
           
            string orderby = "";
            string where = "";

            if (requestModel.Search.Value != "")
            {
                foreach (var columna in requestModel.Columns)
                {
                    if (columna.Data != "" && columna.Data != "Id")
                        where += String.Format("{0}.Contains(\"{1}\") OR ", columna.Data, requestModel.Search.Value);

                }
            }

            if (where.EndsWith("OR "))
                where = where.Remove(where.Length - 3, 3);
            else
            {
                where = "1=1";
            }

            foreach (var column in sortedColumns)
            {
                if (!isSorted)
                {
                    if (column.SortDirection == Column.OrderDirection.Ascendant)
                        orderby = column.Data;
                    else
                    {
                        orderby = column.Data + " desc";
                    }
                    isSorted = true;
                }
                else
                {
                    // SortAgain(column.Data, column.SortDirection);
                }
            }

            if (orderby == "") orderby = "CodigoDeBarras";

            imputados = imputados.Where(where).OrderBy(orderby);
            int cantFiltrados = imputados.Count();

            var paged = imputados.Skip(requestModel.Start).Take(requestModel.Length);


            return Json(new DataTablesResponse(requestModel.Draw, paged, cantFiltrados, cant), JsonRequestBehavior.AllowGet);
        }


        public bool EnviarDelitos(int id)
        {
            bool envioOk = false;
            Imputado imputado = repository.Set<Imputado>().First(x => x.Id == id);
            if (imputado != null)
            {
                imputado.Estado =
                    repository.Set<SICEstadoTramite>().First(x => x.Descripcion.Contains("segmen"));
                if (imputado.Estado != null)
                {
                    repository.UnitOfWork.RegisterChanged(imputado);
                    repository.UnitOfWork.Commit();
                    Issue<IssueFields> issue = _jiraService.GetIssue(imputado.CodigoDeBarras);
                    Transition transition = _jiraService.GetTransitions(issue).First();
                    _jiraService.TransitionIssue(issue, transition);
                    envioOk = true;
                }
            }
            return envioOk;
            //if (!envioBien)
            //    ModelState.AddModelError("",
            //        "No se pudieron guardar los cambios. Intentar nuevamente, si el problema persiste contacte al administrador del sistema.");
            //return borroBien;
            return true;
        }
    }

}