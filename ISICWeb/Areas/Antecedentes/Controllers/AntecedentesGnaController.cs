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
           ViewBag.SexoList = new SelectList(_repository.Set<ClaseSexo>().ToList(), "Id", "descripcion");
           ViewBag.TipoDocList = new SelectList(_repository.Set<ClaseTipoDNI>().ToList(), "Id", "descripcion");

           //GNA gna = _repository.Set<GNA>().SingleOrDefault(x => (x.Prontuario != null && x.Prontuario.ProntuarioNro == prontuariosic));
           GNA gna = null;

           if (idGNA!=0)
           {
               gna = _repository.Set<GNA>().SingleOrDefault(x => x.Id == idGNA);
           }
           else
           {
               gna = new GNA
               {
                   Sexo = _repository.Set<ClaseSexo>().Single(x => x.Id == 0),
                   TipoDNI = _repository.Set<ClaseTipoDNI>().Single(x => x.Id == 0),
                   Prontuario = new Prontuario { ProntuarioNro = prontuariosic }
               };

           }

           return View(gna);

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
       public ActionResult GuardarDatosGNA(GNA model)
       {
           string errores = "";
           if (ModelState.IsValid)
           {
               errores = _gnaService.GuardarFichaGNA(model);
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