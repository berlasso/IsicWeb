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
            var resultados = from i in imputados
                             from p in ctx.IdgxProntuario.Where(p => p.Prontuario.ProntuarioNro == i.ProntuarioSIC).DefaultIfEmpty()
                             from a in ctx.AFIS.Where(a => a.Prontuario.ProntuarioNro == i.ProntuarioSIC).DefaultIfEmpty()
                             from g in ctx.GNA.Where(g => g.Prontuario.ProntuarioNro == i.ProntuarioSIC).DefaultIfEmpty()
                             let persona = i.Persona
                             where persona != null
                             let numero = i.Delito != null ? i.Delito.Ipp.numero : ""
                             where numero != null
                             select new ImputadosAntecedentesViewModel()
                             {
                                 Id = i.Id,
                                 ProntuarioSIC = i.ProntuarioSIC,
                                 CodigoDeBarras = i.CodigoDeBarras,
                                 Apellido = persona.Apellido,
                                 Nombre = persona.Nombre,
                                 DocumentoNumero = persona.DocumentoNumero,
                                 IPP = numero,
                                 IDGx = (p != null && p.ProntuarioPF != null && p.Baja!=true),
                                 AFIS = (a != null && a.Prontuario != null && a.Baja!=true),
                                 GNA = (g != null && g.Prontuario != null && g.Baja!=true)
                             };

          //  var aaa = resultados.ToList();
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

            Imputado imputado = _repository.Set<Imputado>().First(x => x.ProntuarioSIC == prontuarioSic);
            return PartialView("_DetalleImputado", imputado);
        }


      

    }
}