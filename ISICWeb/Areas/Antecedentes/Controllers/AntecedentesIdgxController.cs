using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISIC.Entities;
using ISICWeb.Areas.Antecedentes.Models;
using ISICWeb.Services;
using MPBA.DataAccess;

namespace ISICWeb.Areas.Antecedentes.Controllers
{
    public class AntecedentesIdgxController : Controller
    {
        IRepository _repository;
        private IdgxService _idgxService;

        public AntecedentesIdgxController(IRepository repository, IdgxService idgxService)
        {
            _repository = repository;
            _idgxService = idgxService;
        }

        /// <summary>
        /// Trae los datos del prontuario en idgx ya sea por prontuariosic o con prioridad idgxprontuario 
        /// </summary>
        /// <param name="prontuariosic">busca el prontuario en idgx que tenga el prontuariosic indicado</param>
        /// <param name="idIdgxprontuario">trae el prontuario en idgx con id indicado, obviando el paramentro prontuariosic</param>
        /// <returns></returns>
        public ActionResult AltaModificacionProntuarioIDGx(string prontuariosic = "", string idIdgxprontuario = "",
            bool esNuevo = false)
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


        public bool BorrarDatosPersonales(int id)
        {
            bool borroBien = _idgxService.BorrarIdgxDatosPersonales(id);
            if (!borroBien)
                ModelState.AddModelError("", "No se pudieron borrar los datos de la persona");
            return borroBien;
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
            return View("ListadoProntuariosIdgx", prontuario);
        }




        public int GuardarIdgxProntuario(string idIdgxProntuario, string prontuariopf, string idtipoprontuario, string prontuariosic)
        {
            return _idgxService.GuardarIdgxProntuario(idIdgxProntuario, prontuariopf, idtipoprontuario, prontuariosic);


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
                datosPersona = _idgxService.TraerIdgxDatosPersona(idIdgxDatosPersonales, datosPersona.idIdgxProntuario);
                return PartialView("_IdgxDelitosAsociados", datosPersona);
            }
            else
            {
                return PartialView("_IdgxDelitosAsociados", new IdgxDatosPersonalesViewModel());
            }
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
            IdgxProntuarioViewModel prontuarioviewmodel = _idgxService.TraerIdgxProntuarioViewModel(prontuario);
            return View("ListaDatosPersonalesIDGx", prontuarioviewmodel);
        }

     

    }
}