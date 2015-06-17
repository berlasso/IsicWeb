using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISIC.Entities;
using ISICWeb.Areas.Antecedentes.Models;
using ISIC.Services;
using ISICWeb.Areas.PortalSIC.Services;
using ISICWeb.Services;
using MPBA.DataAccess;

namespace ISICWeb.Areas.Antecedentes.Controllers
{
    public class AntecedentesGnaController : Controller
    {
        IRepository _repository;
        private GnaService _gnaService;

       public AntecedentesGnaController(IRepository repository, GnaService gnaService)
        {
            _repository = repository;
            _gnaService = gnaService;
        }

       public ActionResult AltaModificacionGNA(string prontuariosic = "", int idGNA=0)
       {
           GNAViewModel model = _gnaService.LlenarViewModelDesdeBase(prontuariosic, idGNA);
           return View(model);
       }

       public ActionResult BuscarFichasGNA(string prontuariosic)
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
           return View("ListadoGNAs", prontuario);
       }


       public bool BorrarFichaGNA(int id)
       {
           bool borroBien = _gnaService.BorrarFichaGNA(id);
           if (!borroBien)
               ModelState.AddModelError("", "No se pudo borrar la ficha de GNA");
           return borroBien;
       }


       [HttpPost]
       public ActionResult GuardarDatosGNA(GNAViewModel model)
       {
           string errores = "";
           if (ModelState.IsValid)
           {
               errores = _gnaService.GuardarFichaGNA(model);
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
               return PartialView("_SummaryErrorGna", model);
           }
           return null;



       }

    }
}