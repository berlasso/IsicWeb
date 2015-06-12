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
    public class AntecedentesMigracionesController : Controller
    {
            IRepository _repository;
        private MigracionesService _migracionesService;

        public AntecedentesMigracionesController(IRepository repository, MigracionesService migracionesService)
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
            Migraciones model = _repository.Set<Migraciones>().SingleOrDefault(x => x.Id == idMigraciones);
            if (model == null)
            {
                Prontuario prontuario = _repository.Set<Prontuario>().FirstOrDefault(x => x.ProntuarioNro == prontuariosic);
                if (prontuario == null)
                {
                    prontuario = new Prontuario { ProntuarioNro = prontuariosic };
                };
                model = new Migraciones
                {
                    Prontuario = prontuario,
                };
            }
            ViewBag.exptelist = new SelectList(_repository.Set<ClaseExpedienteMigraciones>().ToList(), "Id", "descripcion");
            return View(model);
        }

        [HttpPost]
        public ActionResult GuardarDatosMigraciones(Migraciones model)
        {
            string errores = "";
            if (ModelState.IsValid)
            {
                Prontuario prontuario = null;
                if (model.Prontuario.Id == 0)
                {
                    prontuario = new Prontuario
                    {
                        ProntuarioNro = model.Prontuario.ProntuarioNro
                    };
                }
                else
                {
                    prontuario = _repository.Set<Prontuario>().Single(x => x.Id == model.Prontuario.Id);
                }
                model.Prontuario = prontuario;
                model.FechaUltimaModificacion=DateTime.Now;
                ClaseExpedienteMigraciones expte =
                    _repository.Set<ClaseExpedienteMigraciones>().Single(x => x.Id == model.ExpedienteMigraciones.Id);
                model.ExpedienteMigraciones = expte;
                if (model.Id == 0)
                {

                    model.FechaCreacion=DateTime.Now;

                    _repository.UnitOfWork.RegisterNew(model);
                }
                else
                {
                    _repository.UnitOfWork.RegisterChanged(model);
                }
                try
                {
                    _repository.UnitOfWork.Commit();
                }
                catch (Exception e)
                {
                    errores = e.InnerException == null ? "Error al guardar. " + e.Message : e.InnerException.ToString().Substring(0, 400);
                }
                 
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
            bool borroBien = _migracionesService.BorrarFichaMigraciones(id);
            if (!borroBien)
                ModelState.AddModelError("", "No se pudo borrar la ficha de Migraciones");
            return borroBien;
        }
    }
}