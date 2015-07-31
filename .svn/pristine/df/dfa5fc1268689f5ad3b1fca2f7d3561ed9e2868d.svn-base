using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISIC.Entities;
using ISIC.Persistence.Context;
using ISIC.Services;
using ISICWeb.Areas.Antecedentes.Models;
using ISICWeb.Areas.PortalSIC.Models;
using ISICWeb.Areas.PortalSIC.Services;
using ISICWeb.Services;
using System.Linq.Dynamic;
using MPBA.DataAccess;

namespace ISICWeb.Areas.Antecedentes.Controllers
{
    [Audit]
    [Autorizar(Roles = "Administrador, Antecedentes")]
    public class AntecedentesController : Controller
    {
        IRepository _repository;
        private BusquedaService _busquedaService;

        public AntecedentesController(IRepository repository, BusquedaService busquedaService)
        {
            _repository = repository;
            _busquedaService = busquedaService;
        }

        // GET: Antecedentes/Antecedentes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buscar(BusquedaViewModel busqueda)
        {
            if (ModelState.IsValid == false)
                RedirectToAction("Index");
            int maxResultados = 100;
            ViewBag.MaxResultados = maxResultados;
            ISICContext ctx = (ISICContext)_repository.UnitOfWork.Context;
            string querystring = "";
             _busquedaService.BuscarImputados(busqueda, maxResultados, out querystring);


            var imputados = ctx.Imputado.Where(querystring).OrderBy(x => x.CodigoDeBarras).Take(100);
            var resultados = from imp in imputados
                from p in ctx.Prontuario.Where(p => p.ProntuarioNro == imp.Prontuario.ProntuarioNro && imp.Prontuario.baja!=false).DefaultIfEmpty()
                select new ImputadosAntecedentesViewModel
                {
                    Id = imp.Id,
                    ProntuarioSIC = imp.Prontuario.ProntuarioNro,
                    CodigoDeBarras = imp.CodigoDeBarras,
                    Apellido = imp.Persona.Apellido,
                    Nombre = imp.Persona.Nombre,
                    DocumentoNumero = imp.Persona.DocumentoNumero,
                    IPP = imp.Delito.Ipp.numero,
                    AFIS = (from a in ctx.AFIS where a.Prontuario == p select a).Any(),
                    GNA = (from g in ctx.GNA where g.Prontuario == p select g).Any(),
                    IDGx = (from i in ctx.IdgxProntuario where i.Prontuario == p select i).Any(),
                    Migraciones = (from m in ctx.Migraciones where m.Prontuario == p select m).Any()
                };

         
            return View("ResultadoBusqueda", resultados);
        }

    


        public ActionResult BuscarLocalidad(string term)
        {
            var routeList = _repository.Set<Localidad>().Where(r => r.LocalidadNombre.Contains(term))
                              .Take(50)
                              .Select(r => new { id = r.Id, label = r.LocalidadNombre.Trim() + ", " + r.Partido.PartidoNombre.Trim() + ", " + r.Provincia.ProvinciaNombre.Trim(), name = "LocalidadID" });
            return Json(routeList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BuscarPartido(string term)
        {
            var routeList = _repository.Set<Partido>().Where(r => r.PartidoNombre.Contains(term))
                              .Take(50)
                              .Select(r => new { id = r.Id, label = r.PartidoNombre.Trim() + ", " + r.Provincia.ProvinciaNombre.Trim(), name = "PartidoID" });
            return Json(routeList, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Muestra datos del imputado en el SIC segun alguno de los 2 parametros, son excluyentes con prioridad prontuariosic
        /// </summary>
        /// <param name="idIdgxprontuario">id del prontuario en idgx</param>
        /// <param name="prontuarioSic">nro de prontuario en el sic</param>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult MostrarDatosImputado(int idIdgxprontuario = 0, string prontuarioSic = "")
        {
            if (prontuarioSic == "" && idIdgxprontuario > 0)
                prontuarioSic = _repository.Set<IdgxProntuario>().First(x => x.Id == idIdgxprontuario).Prontuario.ProntuarioNro;

            Imputado imputado = _repository.Set<Imputado>().First(x => x.Prontuario.ProntuarioNro == prontuarioSic);
            return PartialView("_DetalleImputado", imputado);
        }


      

    }
}