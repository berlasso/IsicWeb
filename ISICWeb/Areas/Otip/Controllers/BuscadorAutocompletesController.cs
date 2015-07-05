using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISIC.Entities;
using MPBA.DataAccess;
using ISICWeb.Areas.Otip.Models;
namespace ISICWeb.Areas.Otip.Controllers
{
    [Audit]
    [Authorize(Roles = "Administrador, OTIP")]
    public class BuscadorAutocompletesController : Controller
    {
        IRepository repository;

    

        public BuscadorAutocompletesController(IRepository repository)
        {
            this.repository = repository;

        }


        public JsonResult BuscaPartido(string partido)
        {
            var partidosEncontrados = repository.Set<Partido>().Where(p => p.PartidoNombre.ToLower().Contains(partido.ToLower())).Select(p => new { value = p.Id.ToString(),  search=p.PartidoNombre.Trim(), name = p.PartidoNombre.Trim() + ", " + p.Provincia.ProvinciaNombre.Trim() }).ToList();
            var json = Json(new {partidosEncontrados}, JsonRequestBehavior.AllowGet);
            return json;
        }

        public JsonResult BuscaModusOperandi(string mo)
        {
            var moEncontrados = repository.Set<NNClaseModusOperandi>().Where(m => m.Descripcion.ToLower().Contains(mo.ToLower())).Select(m => new { value = m.Id.ToString(), search=m.Descripcion.Trim(), name = m.Descripcion.Trim() }).ToList();
            var json = Json(new {moEncontrados}, JsonRequestBehavior.AllowGet);
            return json;
    
        }

        public JsonResult BuscaComisaria(string comisaria, string loc)
        {
            int idLocalidad = Convert.ToInt16(loc);
            
            var dpEncontrados = repository.Set<PuntoGestion>().Where(p => p.Localidad.Id == idLocalidad && p.ClasePuntoGestion.Id == "5")
            .Select(n => new { value = n.Id.ToString(), search = n.Descripcion.Trim(), name = n.Descripcion.Trim(), localidad = n.Localidad.LocalidadNombre, provincia = n.Provincia.ProvinciaNombre }).ToList();
            var json = Json(new { dpEncontrados }, JsonRequestBehavior.AllowGet);
            return json;

        }

        public class clase
        {
            public string url { get; set; }
            public string name { get; set; }
        }

        public JsonResult BuscaLocalidad(string localidad)
        {
            try
            {
                var localidadesEncontradas = repository.Set<Localidad>().Where(l => l.LocalidadNombre.ToLower().Contains(localidad.ToLower())).Select(l => new { value = l.Id.ToString(), search=l.LocalidadNombre.Trim(), idProvincia=l.Provincia.Id, provincia=l.Provincia.ProvinciaNombre, localidad=l.LocalidadNombre, partido=l.Partido.PartidoNombre, idPartido=l.Partido.Id}).ToList();
            var json = Json(new { localidadesEncontradas }, JsonRequestBehavior.AllowGet);
            return json;
            }
            catch (Exception)
            {
                
                throw;
            }
            
         
        }
    }
}