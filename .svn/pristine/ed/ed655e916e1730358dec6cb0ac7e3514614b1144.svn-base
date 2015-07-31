using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using ISIC.Entities;
using ISICWeb.Areas.Antecedentes.Models;
using ISICWeb.Services;
using MPBA.DataAccess;

namespace ISICWeb.Areas.Antecedentes.Controllers
{
    [Audit]
    [Autorizar(Roles = "Administrador, Antecedentes")]
    public class AntecedentesMigracionesController : Controller
    {
        
            IRepository _repository;
        private IMigracionesService _migracionesService;

        public AntecedentesMigracionesController(IRepository repository, IMigracionesService migracionesService)
        {
            _repository = repository;
            _migracionesService = migracionesService;
        }

        public ActionResult BuscarFichasMigraciones(string prontuariosic)
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
            return View("ListadoMigraciones", prontuario);
        }

        public ActionResult AltaModificacionMigraciones(string prontuariosic = "",  int idMigraciones = 0)
        {
            MigracionesViewModel model = _migracionesService.LlenarViewModelDesdeBase(prontuariosic, idMigraciones);

            return View(model);

        }

        [HttpPost]
        public ActionResult GuardarDatosMigraciones(MigracionesViewModel model)
        {
            string errores = "";

            if (ModelState.IsValid)
            {
                errores = _migracionesService.GuardarFichaMigraciones(model, User);
                 
            }
            else
            {
                errores = string.Join("; ", ModelState.Values
                                          .SelectMany(x => x.Errors)
                                          .Select(x => x.ErrorMessage));
            }

            if (errores != "")
            {
                int i;
                ModelState.AddModelError("", errores);
                return PartialView("_SummaryErrorMigraciones", model);
            }
            return null;
        }

        public bool BorrarFichasMigraciones(int id)
        {
            bool borroBien = _migracionesService.BorrarFichaMigraciones(id, User);
            if (!borroBien)
                ModelState.AddModelError("", "No se pudo borrar la ficha de Migraciones");
            return borroBien;
        }
    }
}