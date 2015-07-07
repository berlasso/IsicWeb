using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MPBA.SIAC.Web.Models;

namespace MPBA.SIAC.Web.Controllers
{
    public class PersonasController : Controller
    {
        private SIACEntities db = new SIACEntities();

        //
        // GET: /Personas/

        public ActionResult Index() 
        {
            var persona = db.Personas.Include(p => p.ClaseEstadoCivil).Include(p => p.ClaseEstudiosCursados).Include(p => p.ClaseSexo).Include(p => p.Pais).Include(p => p.Provincia);
            return View(persona.ToList());
        }

        //
        // GET: /Personas/Details/5

        public ActionResult Details(int id = 0)
        {
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

         //
        // GET: /Personas/Create

        public ActionResult Create()
        {
              
            Persona p = new Persona();
            p.id = 3;
            db.Personas.Add(p);
            ViewBag.idEstadoCivil = new SelectList(db.ClaseEstadoCiviles, "id", "descripcion");
            ViewBag.IdEstadoCivilMaterno = new SelectList(db.ClaseEstadoCiviles, "id", "descripcion");
            ViewBag.IdEstadoCivilPaterno = new SelectList(db.ClaseEstadoCiviles, "id", "descripcion");
            ViewBag.EstudiosCursados = new SelectList(db.ClaseEstudiosCursados, "id", "Descripcion");
            ViewBag.idSexo = new SelectList(db.ClaseSexos, "id", "Descripcion");
          
              
            ViewBag.idNacionalidad = new SelectList(db.Paises, "id", "Pais");
            ViewBag.idCreador = new SelectList(db.Usuarios, "id", "idPersonalPoderJudicial");
            ViewBag.pcia = new SelectList(db.Provincias, "id", "Provincia1");
            ViewBag.parti = new SelectList(db.Partidos, "id", "Partido1");
            ViewBag.localidad = new SelectList(db.Localidades, "id", "Localidad1");
            List<SeniasParticulares> seniasl = new List<SeniasParticulares>();
            SeniasParticulares s = new SeniasParticulares();
            s.idPersona = 3;
          
            s.idUbicacionSeniaParticular = 1;
            s.idSeniaParticular = 1;
            s.descripcion = "Hola";
            seniasl.Add(s);
            s = new SeniasParticulares();
            s.idPersona = 3;
          
            s.idUbicacionSeniaParticular = 3;
            s.idSeniaParticular = 4;
            s.descripcion = "Hola como estas";
            seniasl.Add(s);
            p.SeniasParticulares = seniasl;
            
            return View(p);
        }

        //
        // POST: /Personas/Create

        [HttpPost]
        public ActionResult Create(Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Personas.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstadoCivil = new SelectList(db.ClaseEstadoCiviles, "id", "descripcion", persona.idEstadoCivil);
            ViewBag.IdEstadoCivilMaterno = new SelectList(db.ClaseEstadoCiviles, "id", "descripcion", persona.IdEstadoCivilMaterno);
            ViewBag.IdEstadoCivilPaterno = new SelectList(db.ClaseEstadoCiviles, "id", "descripcion", persona.IdEstadoCivilPaterno);
            ViewBag.EstudiosCursados = new SelectList(db.ClaseEstudiosCursados, "id", "Descripcion", persona.EstudiosCursados);
            ViewBag.idSexo = new SelectList(db.ClaseSexos, "id", "Descripcion", persona.idSexo);
            
            ViewBag.idNacionalidad = new SelectList(db.Paises, "id", "Pais");
            ViewBag.idCreador = new SelectList(db.Usuarios, "id", "idPersonalPoderJudicial", persona.idCreador);
            ViewBag.idProvincia = new SelectList(db.Provincias, "id", "Provincia1");
          
            return View(persona);
        }

        //
        // GET: /Personas/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstadoCivil = new SelectList(db.ClaseEstadoCiviles, "id", "descripcion", persona.idEstadoCivil);
            ViewBag.IdEstadoCivilMaterno = new SelectList(db.ClaseEstadoCiviles, "id", "descripcion", persona.IdEstadoCivilMaterno);
            ViewBag.IdEstadoCivilPaterno = new SelectList(db.ClaseEstadoCiviles, "id", "descripcion", persona.IdEstadoCivilPaterno);
            ViewBag.EstudiosCursados = new SelectList(db.ClaseEstudiosCursados, "id", "Descripcion", persona.EstudiosCursados);
            ViewBag.idSexo = new SelectList(db.ClaseSexos, "id", "Descripcion", persona.idSexo);
            ViewBag.idNacionalidad = new SelectList(db.Paises, "id", "Pais1", persona.idNacionalidad);
            ViewBag.idCreador = new SelectList(db.Usuarios, "id", "idPersonalPoderJudicial", persona.idCreador);
            ViewBag.idProvincia = new SelectList(db.Provincias, "id", "Provincia1", persona.idProvincia);
            return View(persona);
        }

        //
        // POST: /Personas/Edit/5

        [HttpPost]
        public ActionResult Edit(Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstadoCivil = new SelectList(db.ClaseEstadoCiviles, "id", "descripcion", persona.idEstadoCivil);
            ViewBag.IdEstadoCivilMaterno = new SelectList(db.ClaseEstadoCiviles, "id", "descripcion", persona.IdEstadoCivilMaterno);
            ViewBag.IdEstadoCivilPaterno = new SelectList(db.ClaseEstadoCiviles, "id", "descripcion", persona.IdEstadoCivilPaterno);
            ViewBag.EstudiosCursados = new SelectList(db.ClaseEstudiosCursados, "id", "Descripcion", persona.EstudiosCursados);
            ViewBag.idSexo = new SelectList(db.ClaseSexos, "id", "Descripcion", persona.idSexo);
            ViewBag.idNacionalidad = new SelectList(db.Paises, "id", "Pais1", persona.idNacionalidad);
            ViewBag.idCreador = new SelectList(db.Usuarios, "id", "idPersonalPoderJudicial", persona.idCreador);
            ViewBag.idProvincia = new SelectList(db.Provincias, "id", "Provincia1", persona.idProvincia);
            return View(persona);
        }

     
     
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}