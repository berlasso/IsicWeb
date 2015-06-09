using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using ISIC.Entities;
using ISIC.Persistence.Context;
using ISIC.Services;
using ISICWeb.Areas.Otip.Models;
using ISICWeb.Areas.PortalSIC.Models;
using ISICWeb.Areas.PortalSIC.Services;
using MPBA.DataAccess;
using System.Linq.Dynamic;
using System.Security.Claims;
using DataTables.Mvc;

namespace ISICWeb.Areas.PortalSIC.Controllers
{
    public class BusquedaController : Controller
    {
        private readonly IRepository _repository;
        private BusquedaService _busquedaService;
        const int MaxResultados = 1000;

        public BusquedaController(Repository repository, BusquedaService service)
        {
            _repository = repository;
            _busquedaService = service;
        }
        // GET: PortalSIC/Busqueda
        public ActionResult Index()
        {

            var datosBusqueda = _busquedaService.CrearViewModel();
            return View(datosBusqueda);
        }

        public ActionResult VerImputado(int id, bool? paraEditar = false)
        {
            ISICWeb.Services.ImputadoExtraService imputadoService = new ISICWeb.Services.ImputadoExtraService(_repository);

            DatosGeneralesViewModel datosGeneralesImputado = imputadoService.LlenarViewModelConImputado(id, false);
            return View(datosGeneralesImputado);

        }

        public JsonResult MostrarImputados([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {

            BusquedaViewModel model = (BusquedaViewModel) Session["model"];
            int skip=requestModel.Start;
            int take = requestModel.Length;
            string querystring = "";
            var imputados = _busquedaService.BuscarImputados(model,MaxResultados,out querystring);

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
                    switch (column.Data.ToLower())
                    {
                        case "codigodebarras":
                            orderby = "CodigoDeBarras";
                            break;
                        case "apellido":
                            orderby = "Persona.Apellido";
                            break;
                        case "nombre":
                            orderby = "Persona.Nombre";
                            break;
                        case "documentonumero":
                            orderby = "Persona.DocumentoNumero";
                            break;
                    }
                    if (column.SortDirection == Column.OrderDirection.Descendant)
                        orderby +=  " desc";
                    
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

            imputados = imputados.Skip(requestModel.Start).Take(requestModel.Length);
            ISICContext context = (ISICContext)_repository.UnitOfWork.Context;     
            var paged = (from i in imputados
                             from a in context.Archivo.Where(a => a.Imputado.Id == i.Id && a.TipoArchivo.Id == 1).Take(1).DefaultIfEmpty()
                             select new {ThumbUrl=a==null?"":a.ThumbUrl.Replace("~","")??"", i.CodigoDeBarras, i.Persona.Apellido, i.Persona.Nombre, i.Persona.DocumentoNumero, i.Id });
            //.Select(x=>new {ThumbUrl="", CodigoDeBarras=x.CodigoDeBarras, Apellido=x.Persona.Apellido, Nombre=x.Persona.Nombre, DocumentoNumero=x.Persona.DocumentoNumero,Id=x.Id});;
            


            return Json(new DataTablesResponse(requestModel.Draw, paged, cantFiltrados, cant), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Buscar(BusquedaViewModel model)
        {
            ViewBag.CantidadMaxima = MaxResultados;
            //var imputados = _busquedaService.BuscarImputados(model);
           // Session["imputados"] = imputados;
            Session["model"] =model;
            //if (!imputados.Any())
            //{
            //    ModelState.AddModelError("", "No se encontraron resultados");
            //    return View("ImputadosEncontrados", imputados);
            //}
            //else
            //{
            if (model.TipoBusqueda == TipoBusqueda.Fotografias)
            {
                
                return RedirectToAction("GenerarScroller", "InfiniteScroller");
            }
                
            else
            {
                
                return View("ImputadosEncontrados", null);
            }
            //}

        }

    }
}
    

