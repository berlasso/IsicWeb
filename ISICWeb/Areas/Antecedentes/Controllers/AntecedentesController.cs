﻿using System;
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
        private ImputadoService _imputadoService;
        private IdgxService _idgxService;

        public AntecedentesController(IRepository repository, BusquedaService busquedaService, ImputadoService imputadoService, IdgxService idgxService)
        {
            _repository = repository;
            _busquedaService = busquedaService;
            _imputadoService = imputadoService;
            _idgxService = idgxService;
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
                                 IDGx = (p != null && p.ProntuarioPF != null),
                                 AFIS = (a != null && a.Prontuario != null),
                                 GNA = (g != null && g.Prontuario != null)
                             };

          //  var aaa = resultados.ToList();
            return View("ResultadoBusqueda", resultados);
        }

        /// <summary>
        /// Trae los datos del prontuario en idgx ya sea por prontuariosic o con prioridad idgxprontuario 
        /// </summary>
        /// <param name="prontuariosic">busca el prontuario en idgx que tenga el prontuariosic indicado</param>
        /// <param name="idIdgxprontuario">trae el prontuario en idgx con id indicado, obviando el paramentro prontuariosic</param>
        /// <returns></returns>
        public ActionResult AltaModificacionProntuarioIDGx(string prontuariosic = "", string idIdgxprontuario = "", bool esNuevo = false)
        {
            IdgxProntuario idgxProntuario = null;
            if (!esNuevo)
            {
                if (idIdgxprontuario.Trim() == "")
                    idgxProntuario =
                        _repository.Set<IdgxProntuario>()
                            .SingleOrDefault(x => x.Prontuario.ProntuarioNro == prontuariosic);
                else
                {
                    idgxProntuario =
                        _repository.Set<IdgxProntuario>().FirstOrDefault(x => x.Id.ToString() == idIdgxprontuario);
                }
            }


            IdgxProntuarioViewModel prontuario = null;

            prontuario = _idgxService.TraerIdgxProntuarioViewModel(idgxProntuario, prontuariosic);


            return View(prontuario);
        }

        public ActionResult BuscarProntuariosIdgx(string prontuariosic)
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
            return View("DetalleProntuariosIdgx", prontuario);
        }

        public int GuardarIdgxProntuario(string idIdgxProntuario, string prontuariopf, string idtipoprontuario, string prontuariosic)
        {
          return   _idgxService.GuardarIdgxProntuario(idIdgxProntuario, prontuariopf, idtipoprontuario, prontuariosic);
 

        }





        public ActionResult AltaModificacionDatosPersonalesIdGx(int idIdgxprontuario, int idIdgxdatospersonales = 0)
        {
            IdgxDatosPersonalesViewModel datosPersona = null;
            if (idIdgxdatospersonales == 0) //nuevo dato
            {
                datosPersona = new IdgxDatosPersonalesViewModel
                {
                    Id = 0,
                    idIdgxProntuario = idIdgxprontuario,
                    TipoDocumentoList = new SelectList(_repository.Set<ClaseTipoDNI>().ToList(), "Id", "descripcion"),
                    ProvinciaList = new SelectList(_repository.Set<Provincia>().ToList(), "Id", "ProvinciaNombre"),

                };
            }
            else //modificando 
            {
                datosPersona = _idgxService.TraerIdgxDatosPersona(idIdgxdatospersonales,
                    idIdgxprontuario);
            }



            return View("CargaDatosPersonalesIDGx", datosPersona);
        }

        [HttpPost]
        public ActionResult GuardarDatosPersonalesIdGx(IdgxDatosPersonalesViewModel datosPersona)
        {
            int idIdgxDatosPersonales = _idgxService.GuardarIdgxDatosPersona(datosPersona);
            // ViewData["idIdgxdatospersonales"] = idIdgxDatosPersonales;
            datosPersona.Id = idIdgxDatosPersonales;
            if (idIdgxDatosPersonales > 0)
            {
                return PartialView("_IdgxDelitosAsociados", datosPersona);
            }
            else
            {
                return PartialView("_IdgxDelitosAsociados", new IdgxDatosPersonalesViewModel());
            }
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

        public bool BorrarDatosPersonales(int id)
        {
            bool borroBien = _idgxService.BorrarIdgxDatosPersonales(id);
            if (!borroBien)
                ModelState.AddModelError("", "No se pudieron borrar los datos de la persona");
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

        //public ActionResult MostrarIdgxDelitosAsociados(int idIdgxDatosPersona)
        //{
        //    IdgxDatosPersona persona = _repository.Set<IdgxDatosPersona>().SingleOrDefault(x => x.Id == idIdgxDatosPersona);
        //    IEnumerable<IdgxDetalle> delitos = null;
        //    if (persona != null && persona.Delitos != null)
        //        delitos = persona.Delitos;

        //    return PartialView("_IdgxDelitosAsociados",delitos);
        //}



        public ActionResult AltaModificacionDelitoIdgx(int idIdgxdatospersonales, int idIdgxdelito = 0)
        {
            IdgxDelitoViewModel delito = null;
            if (idIdgxdelito == 0) //nuevo
            {
                IdgxDatosPersona datosPersona =
                    _repository.Set<IdgxDatosPersona>().Single(x => x.Id == idIdgxdatospersonales);

                delito = new IdgxDelitoViewModel
                {
                    Id = 0,
                    CodigoRestriccionList =
                        new SelectList(_repository.Set<ClaseCodigoRestriccionPoliciaFederal>().ToList(), "Id",
                            "descripcion"),
                    CodigoRestriccionPF = "0",
                    idIdgxdatospersonales = idIdgxdatospersonales,
                    idIdgxprontuario = (datosPersona.IdgxProntuario == null ? 0 : datosPersona.IdgxProntuario.Id)

                };
            }
            else
            {
                delito = _idgxService.TraerIdgxDelito(idIdgxdelito);
            }
            return View("CargarDelitoIdgx", delito);
        }

        [HttpPost]
        public int GuardarDelitoIdgx(IdgxDelitoViewModel delito)
        {
            int idDelito = _idgxService.GuardarIdgxDelito(delito);
            delito.CodigoRestriccionList =
                new SelectList(_repository.Set<ClaseCodigoRestriccionPoliciaFederal>().ToList(), "Id", "descripcion");
            IdgxDatosPersonalesViewModel datosPersona = _idgxService.TraerIdgxDatosPersona(delito.idIdgxdatospersonales, delito.idIdgxprontuario);
            // return View("CargaDatosPersonalesIDGx", datosPersona);
            delito.Id = idDelito;
            //return View("CargarDelitoIdgx", delito);
            return idDelito;

        }

        [ChildActionOnly]
        public ActionResult MostrarIdgxDelitosAsociados(int idIdgxDatosPersona)
        {

            IdgxDatosPersona persona = _repository.Set<IdgxDatosPersona>().SingleOrDefault(x => x.Id == idIdgxDatosPersona);
            IdgxDatosPersonalesViewModel datospersona = null;

            if (persona != null)
                datospersona = _idgxService.TraerIdgxDatosPersona(idIdgxDatosPersona, persona.IdgxProntuario.Id);

            return PartialView("_IdgxDelitosAsociados", datospersona);
        }

        public bool BorrarDelitoIdgx(int id)
        {
            bool borroBien = _idgxService.BorrarIdgxDelito(id);
            if (!borroBien)
                ModelState.AddModelError("", "No se pudo borrar el delito de idgx");
            return borroBien;
        }

        public bool BorrarProntuarioIdgx(int id)
        {
            bool borroBien = _idgxService.BorrarProntuarioIdgx(id);
            if (!borroBien)
                ModelState.AddModelError("", "No se pudo borrar el delito de idgx");
            return borroBien;
        }

        public ActionResult MostrarDatosIdgx(int id)
        {
            IdgxProntuario prontuario = _repository.Set<IdgxProntuario>().Single(x => x.Id == id);
            IdgxProntuarioViewModel prontuarioviewmodel= _idgxService.TraerIdgxProntuarioViewModel(prontuario);
            return View("ListaDatosPersonalesIDGx",prontuarioviewmodel);
        }

        public ActionResult CargarAfis(string prontuariosic)
        {
            ViewBag.SexoList = new SelectList(_repository.Set<ClaseSexo>().ToList(), "Id", "descripcion");
            AFIS afis = _repository.Set<AFIS>().SingleOrDefault(x => x.Prontuario.ProntuarioNro == prontuariosic);
            if (afis==null)
            afis = new AFIS
            {
                Sexo = _repository.Set<ClaseSexo>().Single(x => x.Id == 0),
                Prontuario = new Prontuario { ProntuarioNro = prontuariosic}
            };
            return View("AltaModificacionAFIS", afis);
        }

        public ActionResult CargarGna(string prontuariosic)
        {
            ViewBag.SexoList = new SelectList(_repository.Set<ClaseSexo>().ToList(), "Id", "descripcion");
            ViewBag.TipoDocList = new SelectList(_repository.Set<ClaseTipoDNI>().ToList(), "Id", "descripcion");
            GNA gna = _repository.Set<GNA>().SingleOrDefault(x => x.Prontuario.ProntuarioNro == prontuariosic);
            if (gna == null)
                gna = new GNA
                {
                    Sexo = _repository.Set<ClaseSexo>().Single(x => x.Id == 0),
                    TipoDNI = _repository.Set<ClaseTipoDNI>().Single(x => x.Id == 0),
                    Prontuario = new Prontuario { ProntuarioNro = prontuariosic }
                };

            return View("AltaModificacionGNA", gna);
        }

        [HttpPost]
        public ActionResult GuardarDatosAfis(AFIS model)
        {
             string errores = "";
            string prontuariosic = model.Prontuario.ProntuarioNro;
             Prontuario prontuario = _repository.Set<Prontuario>().FirstOrDefault(x => x.ProntuarioNro == prontuariosic);
             if (prontuario == null)
                 prontuario = new Prontuario
                 {
                     ProntuarioNro = prontuariosic
                 };
            if (ModelState.IsValid)
            {
                model.Sexo = _repository.Set<ClaseSexo>().Single(x => x.Id == model.Sexo.Id);
                model.FechaUltimaModificacion=DateTime.Now;
                if (model.Id == 0)
                {
                    model.FechaCreacion=DateTime.Now;
                    model.Prontuario = prontuario;
                    _repository.UnitOfWork.RegisterNew(model);
                }
                else
                    _repository.UnitOfWork.RegisterChanged(model);
                try
                {
                    _repository.UnitOfWork.Commit();
                }
                catch (Exception e)
                {
                    errores = e.InnerException==null?"Error al guardar":e.InnerException.ToString().Substring(0, 400);
                }
                if (errores != "")
                {
                    ModelState.AddModelError("", errores);
                    return PartialView("_SummaryErrorAfis", model);
                }
                return null;
            }
            else
            {
                return PartialView("_SummaryErrorAfis", model);
            }
        }


        [HttpPost]
        public ActionResult GuardarDatosGNA(GNA model)
        {
            string errores = "";
            string prontuariosic = model.Prontuario.ProntuarioNro;
            Prontuario prontuario = _repository.Set<Prontuario>().FirstOrDefault(x => x.ProntuarioNro == prontuariosic);
            if (prontuario == null)
                prontuario = new Prontuario
                {
                    ProntuarioNro = prontuariosic
                };
            if (ModelState.IsValid)
            {
                model.Sexo = _repository.Set<ClaseSexo>().Single(x => x.Id == model.Sexo.Id);
                model.TipoDNI = _repository.Set<ClaseTipoDNI>().Single(x => x.Id == model.TipoDNI.Id);
                model.FechaUltimaModificacion = DateTime.Now;

                
                if (model.Id == 0)
                {
                    model.FechaCreacion = DateTime.Now;
                    model.Prontuario = prontuario;
                    model.FechaCarga=DateTime.Now;
                    _repository.UnitOfWork.RegisterNew(model);
                }
                else
                    _repository.UnitOfWork.RegisterChanged(model);
                try
                {
                    _repository.UnitOfWork.Commit();
                }
                catch (Exception e)
                {
                    errores = e.InnerException == null ? "Error al guardar" : e.InnerException.ToString().Substring(0, 400);
                }
                if (errores != "")
                {
                    ModelState.AddModelError("", errores);
                    return PartialView("_SummaryErrorGna", model);
                }
                return null;
            }
            else
            {
                return PartialView("_SummaryErrorGna", model);
            }
        }
    }
}