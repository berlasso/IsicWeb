using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using ISICWeb.Areas.Otip.Models;
using ISICWeb.Models;
using MPBA.DataAccess;
using RestSharp;

namespace ISICWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IRepository repository;
        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }




        public ActionResult Index()
        {


            return View();
        }


        public ActionResult About()
        {

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Completar Página de contacto.";

            return View();
        }


    
    }

  
}
