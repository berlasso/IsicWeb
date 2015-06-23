using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;
using ISIC.Entities;
using ISIC.Persistence.Context;
using ISICWeb.Areas.Afis.Models;
using ISICWeb.Areas.Antecedentes.Models;
using ISICWeb.Areas.PortalSIC.Models;
using ISICWeb.Areas.PortalSIC.Services;
using ISICWeb.Services;
using MPBA.DataAccess;

namespace ISICWeb.Areas.Afis.Controllers
{
    public class AfisController : Controller
    {
        IRepository _repository;
        private AfisService _afisService;
        private BusquedaService _busquedaService;

        public AfisController(IRepository repository, AfisService afisService, BusquedaService busquedaService)
        {
            _repository = repository;
            _afisService = afisService;
            _busquedaService = busquedaService;
        }



        [HttpPost]
        public ActionResult GuardarDatosAfis(AFISViewModel model)
        {
            string errores = "";
            if (ModelState.IsValid)
            {
                errores = _afisService.GuardarFichaAFIS(model);
            }
            else
            {
                errores = string.Join("; ", ModelState.Values
                                          .SelectMany(x => x.Errors)
                                          .Select(x => x.ErrorMessage));
            }

            if (errores != "")
            {
                ModelState.AddModelError("", errores);
                return PartialView("_SummaryErrorAfis", model);
            }
            return null;
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
                             from p in ctx.Prontuario.Where(p => p.ProntuarioNro == imp.ProntuarioSIC).DefaultIfEmpty()
                             select new ImputadosAfisViewModel
                             {
                                 Id = imp.Id,
                                 ProntuarioSIC = imp.ProntuarioSIC,
                                 CodigoDeBarras = imp.CodigoDeBarras,
                                 Apellido = imp.Persona.Apellido,
                                 Nombre = imp.Persona.Nombre,
                                 DocumentoNumero = imp.Persona.DocumentoNumero,
                                 //IPP = imp.Delito.Ipp.numero,
                                 //AFIS = (from a in ctx.AFIS where a.Prontuario == p select a).Any(),
                                 //GNA = (from g in ctx.GNA where g.Prontuario == p select g).Any(),
                                 //IDGx = (from i in ctx.IdgxProntuario where i.Prontuario == p select i).Any(),
                                 //Migraciones = (from m in ctx.Migraciones where m.Prontuario == p select m).Any()
                             };


            return View("ResultadoBusqueda", resultados);
        }


        public ActionResult Index()
        {


            return View();
        }

        public ActionResult BuscarFichasAFIS(string prontuariosic)
        {
            Session["prontuariosic"] = prontuariosic;
            Prontuario prontuario = _repository.Set<Prontuario>().FirstOrDefault(x => x.ProntuarioNro == prontuariosic);
            if (prontuario == null)
            {
                prontuario = new Prontuario
                {
                    ProntuarioNro = prontuariosic
                };
            }
            return View("ListadoAFIS", prontuario);
        }


        public ActionResult AltaModificacionAFIS(string prontuariosic, int idAfis = 0)
        {

            AFISViewModel model = _afisService.LlenarViewModelDesdeBase(prontuariosic, idAfis);

            return View(model);
        }

        public bool BorrarFichasAFIS(int id)
        {
            bool borroBien = _afisService.BorrarFichaAFIS(id);
            if (!borroBien)
                ModelState.AddModelError("", "No se pudo borrar la ficha de AFIS");
            return borroBien;
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