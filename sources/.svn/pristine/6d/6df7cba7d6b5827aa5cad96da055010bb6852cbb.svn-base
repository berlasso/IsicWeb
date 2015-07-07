using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIACGral.Models;

namespace MPBA.SIAC.Web.Controllers
{
    public class HomeController : Controller
    {
        private MarkerRepository _markerRepository = new MarkerRepository();

        public ActionResult Index()
        {
            ViewBag.Message = "";

            return View();
        }

        [HttpGet]
        public ActionResult Sync()
        {
            //return View(_markerRepository.GetMarkers());
         List<GoogleMarker> marcadores =new List<GoogleMarker>
                 {
             new GoogleMarker {
                domicilio="Diagonal 76 736,La Plata",
                SiteName = "CIPAE",
              },
            new GoogleMarker            
              {
                domicilio="57 Esq 20,La Plata",
                SiteName = "Abuela Martha",
              },
                  new GoogleMarker            
              {
                domicilio="15 Nro 2030,La Plata",
                SiteName = "Abuela Lilia",
              }};
            
             int resultado=0;
            return View(_markerRepository.GetMarcadores(marcadores, out resultado));
        }

        [HttpGet]
        public ActionResult Async()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetMarkersAsync()
        {
            return Json(_markerRepository.GetMarkers());
        }
        public ActionResult About()
        {
            ViewBag.Message = "  ";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = " ";

            return View();
        }
        public ActionResult AltaPersonas()
        {
            ViewBag.Message = " ";

            return View();
      
        
        }

        
          }


}
