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
    public class AntecedentesAfisController : Controller
    {
        IRepository _repository;
        private AfisService _afisService;

        public AntecedentesAfisController(IRepository repository, AfisService afisService)
        {
            _repository = repository;
            _afisService = afisService;
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

        
        public ActionResult AltaModificacionAFIS(string prontuariosic,int idAfis=0)
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

        //public ActionResult CargarAfis(string prontuariosic)
        //{
        //    ViewBag.SexoList = new SelectList(_repository.Set<ClaseSexo>().ToList(), "Id", "descripcion");
        //    AFIS afis = _repository.Set<AFIS>().SingleOrDefault(x => x.Prontuario.ProntuarioNro == prontuariosic);
        //    if (afis == null)
        //        afis = new AFIS
        //        {
        //            Sexo = _repository.Set<ClaseSexo>().Single(x => x.Id == 0),
        //            Prontuario = new Prontuario { ProntuarioNro = prontuariosic }
        //        };
        //    return View("AltaModificacionAFIS", afis);
        //}

    }
}