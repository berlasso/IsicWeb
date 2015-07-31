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
using System.Security.Principal;
using System.Text.RegularExpressions;
using ISIC.Persistence.Context;
using ISIC.Services;
using ISICWeb.Models;
using ISICWeb.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MPBA.Jira.Model;
using ImputadoService = ISICWeb.Services.ImputadoExtraService;
using Session = Glimpse.AspNet.Tab.Session;

namespace ISICWeb.Areas.Otip.Controllers
{
    [Audit]
    [Autorizar(Roles = "Administrador, OTIP")]
    public class ImputadoOtipController : Controller
    {
        
        
        IRepository repository;
        private IImputadoExtraService _imputadoExtraService;
        private IImputadoService _imputadoService;
        private IJiraService _jiraService;
        /// <summary>

        /// Application DB context

        /// </summary>

        protected ApplicationDbContext ApplicationDbContext { get; set; }

        /// <summary>

        /// User manager - attached to application DB context

        /// </summary>

        protected UserManager<ApplicationUser> UserManager { get; set; }

        public ImputadoOtipController(IRepository repository, IImputadoExtraService imputadoExtraService, IJiraService jiraService, IImputadoService imputadoService)
        {
            this.repository = repository;
            _jiraService = jiraService;
            _imputadoExtraService = imputadoExtraService;
            _imputadoService = imputadoService;
        }

        #region GETS
        // GET: Imputado
        public ActionResult Index()
        {

         
            return View();
        }

        public ActionResult DetallePorCodBarra(string cb, int? pe)
        {

            ViewBag.WordDocumentFilename = "AboutMeDocument";
            Imputado imputado = repository.Set<Imputado>().SingleOrDefault(x => x.CodigoDeBarras == cb);
            if (imputado != null)
            {


                DatosGeneralesViewModel model = _imputadoExtraService.LlenarViewModelConImputado(imputado.Id, pe);
                if (model != null)
                    return View("Detalle", model);
                
            }
            String error = "No se encontrol el registro solicitado";
            return View("Error",null,error);
        }

        /// <summary>
        /// Trae detalle del delito
        /// </summary>
        /// <param name="id">id del imputado</param>
        /// <param name="pe">si es para editar</param>
        /// <returns></returns>
        public ActionResult Detalle(int id, int? pe=0)
        {

            ViewBag.WordDocumentFilename = "AboutMeDocument";
            DatosGeneralesViewModel model = _imputadoExtraService.LlenarViewModelConImputado(id, pe);
            if (model != null) return View(model);
            RedirectToAction("Index");
            return null;
        }

        // GET: Imputado/AltaModificacion/5
        [HttpGet]
        public ActionResult AltaModificacion(int? id)
        {
            ViewBag.SubCodBarra = ((ClaimsIdentity)User.Identity).FindFirst("subCodBarra").Value;


            if (id != null && id > 0) //para modificar
                return RedirectToAction("Detalle", "ImputadoOtip", new { id=id, pe=1 });
            DatosGeneralesViewModel datosGenerales = _imputadoExtraService.CrearViewModel();
            return View("Detalle", datosGenerales);
        }

        // GET: Imputado/Borrar/5
        public string Borrar(int id)
        {


            bool borroBien = false;
            string errormsg = "";
            Imputado imp = repository.Set<Imputado>().SingleOrDefault(x => x.Id == id);
            if (imp != null)
            {
                imp.Baja = true;
                using (var tran = repository.UnitOfWork.Context.Database.BeginTransaction())
                {
                       repository.UnitOfWork.RegisterChanged(imp);
                    try
                    {
                        
                        
                        Issue<IssueFields> issue = _jiraService.GetIssue(imp.CodigoDeBarras);
                        Transition transition = _jiraService.GetTransitions(issue).First();
                        
                        //repository.UnitOfWork.Commit();
                        tran.Commit();
                        _jiraService.TransitionIssue(issue, transition);
                        borroBien = true;
                    }
                    catch (MPBA.Jira.JiraClientException jiraex)
                    {
                        errormsg = "Error al marcar como borrado en el Jira";
                    }
                    catch(Exception e)
                    {
                        errormsg = e.InnerException.ToString();
                        int i = errormsg.Length < 400 ? errormsg.Length : 400;
                        errormsg = e.InnerException.ToString().Substring(0, i);
                    }


                }
            }


            if (!borroBien)
            {
                ModelState.AddModelError("",
                    string.Format("No se pudieron guardar los cambios: {0}", errormsg));
            }

            return errormsg;
        }

        public int BuscarIdImputado(string codBarras)
        {
            Imputado imputado = _imputadoService.GetByCodigoBarra(codBarras);

            return imputado == null ? 0 : imputado.Id;
        }

        public bool BuscarDelito(string codBarras)
        {
            bool existente = _imputadoExtraService.GetByCodigoBarra(codBarras) != null;
            //if (existente)
            //{
            //    ModelState.AddModelError("CodBarras","Codigo de Barras existente");
            //}
            return existente;
        }

        public JsonResult BuscarDni(string dni="", string id="")
        {
            var imputados =repository.Set<Imputado>().Where(x =>x.Persona.DocumentoNumero == dni && x.Id.ToString()!=id).Select(x=>new{dni=x.Persona.DocumentoNumero, codbarra=x.CodigoDeBarras, apellido=x.Persona.Apellido, nombre=x.Persona.Nombre, delito=x.Delito.Ipp.caratula}).ToList();
            JsonResult json = Json(new { imputados }, JsonRequestBehavior.AllowGet);
            return json;
        }

        public JsonResult BuscarApeNom(string ape = "", string nom="", string id = "")
        {
            var imputados = repository.Set<Imputado>().Where(x => x.Persona.Apellido == ape && x.Persona.Nombre==nom && x.Id.ToString() != id).Select(x => new { dni = x.Persona.DocumentoNumero, codbarra = x.CodigoDeBarras, apellido = x.Persona.Apellido, nombre = x.Persona.Nombre, delito=x.Delito.Ipp.caratula }).ToList();
            JsonResult json = Json(new { imputados }, JsonRequestBehavior.AllowGet);
            return json;
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
                
                var idPuntoGestion =  ((ClaimsIdentity)User.Identity).FindFirst("idPuntoGestion").Value;
                var subCodBarra = ((ClaimsIdentity)User.Identity).FindFirst("subCodBarra").Value;
                
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
                    errores = _imputadoExtraService.GuardarImputadoDesdeViewModel(imp, User);

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

            var subCodBarra = ((ClaimsIdentity)User.Identity).FindFirst("subCodBarra").Value;
            var idPuntoGestion = ((ClaimsIdentity)User.Identity).FindFirst("idPuntoGestion").Value;

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


        public string EnviarDelitos(int id)
        {
            bool envioOk = false;
            string errormsg = "";
            Imputado imputado = repository.Set<Imputado>().First(x => x.Id == id);
            if (imputado != null)
            {
                imputado.Estado =
                    repository.Set<SICEstadoTramite>().First(x => x.Descripcion.Contains("segmen"));
                if (imputado.Estado != null)
                {
                    using (var tran = repository.UnitOfWork.Context.Database.BeginTransaction())
                    {
                        repository.UnitOfWork.RegisterChanged(imputado);
                        try
                        {
                            Issue<IssueFields> issue = _jiraService.GetIssue(imputado.CodigoDeBarras);
                            Transition transition = _jiraService.GetTransitions(issue).First();
                            tran.Commit();
                            _jiraService.TransitionIssue(issue, transition);
                            envioOk = true;
                        }
                        catch (MPBA.Jira.JiraClientException jiraex)
                        {
                            errormsg = "Error al marcar el envio en el Jira";
                        }
                        catch (Exception e)
                        {
                            errormsg = e.InnerException.ToString();
                            int i = errormsg.Length < 400 ? errormsg.Length : 400;
                            errormsg = e.InnerException.ToString().Substring(0, i);
                        }

                    }
                }
            }
          
            return errormsg;
        }
    }

}