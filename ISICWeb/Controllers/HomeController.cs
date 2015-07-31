﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web.Mvc;
using ISIC.Entities;
using ISICWeb.Areas.Otip.Models;
using ISICWeb.Models;
using MPBA.DataAccess;
using Postal;
using RestSharp;

namespace ISICWeb.Controllers
{
    [Audit]
    [Autorizar(Roles = "Administrador,OTIP, Usuarios, AFIS, Antecedentes")]
   // [CheckSessionOut]
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

        public ActionResult Error()
        {
            string s = "probando";
            return View("Error",null,s);
        }



        public ActionResult Contact()
        {
            //ViewBag.Message = "Completar Página de contacto.";
            //ViewBag.dnilist = new SelectList(repository.Set<ClaseExpedienteMigraciones>().ToList(), "Id", "descripcion");

           //wsSIC.Services ws=new wsSIC.Services();
           // string perfil = ws.PerfilUsuario("usuario", "clave");

            
            return View();
        }


        public ActionResult GuardarContacto(Migraciones model)
        {
            //AFIS afis = repository.Set<AFIS>().FirstOrDefault(x => x.Id == model.Id);
            //ClaseTipoDNI tipoDNI = repository.Set<ClaseTipoDNI>().Single(x => x.Id == model.TipoDNI.Id);
            //if (afis == null)
            //{
            //    afis = new AFIS();
            //    afis.TipoDNI = tipoDNI;
            //    afis.Apellido = "prueba";
                
            //    repository.UnitOfWork.RegisterNew(afis);
            //}
            //else
            //{
            //    afis.Apellido = "prueba";
            //    afis.TipoDNI = tipoDNI;
            //    repository.UnitOfWork.RegisterChanged(afis);
            //}
            //repository.UnitOfWork.Commit();
            return RedirectToAction("Contact");
        }
    }

  
}
