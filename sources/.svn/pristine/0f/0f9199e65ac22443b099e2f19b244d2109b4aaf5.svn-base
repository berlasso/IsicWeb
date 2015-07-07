using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MPBA.SIAC.Web.Models;
using System.Linq.Expressions;




namespace MPBA.SIAC.Web.Controllers
{
    public class SeniasParticularesController : Controller
    {
        private SIACEntities db = new SIACEntities();
        
        private static List<SeniasParticulares> _seniasp = new List<SeniasParticulares>();            



      
        //
        // Devuelve todas las SeñasParticulares de una Persona/  
        // Este tag es para que no se referencie desde afuera
        [ChildActionOnly]
        public ActionResult SeniasParticularesDetail(Persona _persona)
        {
        
            if (_persona == null)
            {
                _seniasp = new List<SeniasParticulares>();
               SeniasParticulares s=  new SeniasParticulares();
               s.idPersona = _persona.id;
               _seniasp.Add(s);
                 
            }
            else
            {
                _seniasp = (from d in db.SeniasParticulares
                            where d.idPersona == _persona.id
                            select d).ToList(); db.SeniasParticulares.ToList();
            }

            return PartialView(_seniasp);
        }


        
         [HttpPost]
        public JsonResult ClaseUbicacionSeniaParticularList()
        {
              try
                   {
                       var claseS = db.ClaseUbicacionSeniaParticulares.Select
                           (c => new { DisplayText = c.Descripcion, Value = c.id });
                       return Json(new { Result = "OK", Options = claseS });
                   }
                   catch (Exception ex)
                   {
                       return Json(new { Result = "ERROR", Message = ex.Message });
                   }

        }

        [HttpPost]
        public JsonResult ClaseSeniaParticularList()
        {
              try
                   {
                       var claseS = db.ClaseSeniaParticulares.Select
                           (c => new { DisplayText = c.Descripcion, Value = c.id });
                       return Json(new { Result = "OK", Options = claseS });
                   }
                   catch (Exception ex)
                   {
                       return Json(new { Result = "ERROR", Message = ex.Message });
                   }

        }

      /*http://www.codeproject.com/Articles/230353/An-Example-to-Use-jQuery-Grid-Plugin-in-MVC-Part-1  */

     /*sidx, el índice o nombre del campo de ordenación actual.
        sord, “asc” o “desc”, indicando si el orden es ascendente o descendente.
        page, el número de página actual.
        rows, número de elementos a obtener para completar la página.*/

      
  /*      public ActionResult SeniasList(string sidx, string sord, int page, 
          int rows,bool _search, string searchField, string searchOper, string searchString)*/
        public ActionResult SeniasList(string sidx, string sord, int? page,int? rows,int? persona)
        {
            if (rows == null)
            { rows = 1; }

            // Retomar las SeñasParticulares de una persona
            var seniasl = db.Personas.Find(persona).SeniasParticulares.AsQueryable();

                  
            // If search, filter the list against the search condition.
            // Only "contains" search is implemented here.
            var filteredSenias = seniasl;
      /*      if (_search)
            {
                filteredSenias =seniasl.Where(s =>
                    (typeof(SeniasParticulares).GetProperty(searchField).GetValue(s, null) == null) ? false :
                     typeof(SeniasParticulares).GetProperty(searchField).GetValue(s, null)
                        .ToString().Contains(searchString));
           }*/
 
            // Sort the student list
            var sortedSenias = SortIQueryable<SeniasParticulares>(filteredSenias, sidx, sord);
 
            // Calculate the total number of pages
            var totalRecords = filteredSenias.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / (double)rows);
 
            // Prepare the data to fit the requirement of jQGrid
            var data = from a in seniasl     // Datos de filas
                       select new
                       {
                           id = a.id,                // ID único de la fila
                           cell = new string[] {     // Array de celdas de la fila
                       Convert.ToString(a.id),                             // Primera columna,            
                       Convert.ToString(a.idSeniaParticular),                                // Segunda columna,
                       Convert.ToString(a.idUbicacionSeniaParticular), // Tercera columna,
                       a.descripcion                                  // Cuarta columna  
                   }
                       };

            
            // Send the data to the jQGrid
            var jsonData = new
           {
               total = totalPages,
               page = page,
               records = totalRecords,
               rows = from a in seniasl     // Datos de filas
                      select new
                      {
                          id = a.id,                // ID único de la fila
                          cell = new string[] {     // Array de celdas de la fila
                       a.id.ToString(),                             // Primera columna,            
                       a.idSeniaParticular.ToString(),                                // Segunda columna,
                       a.idUbicacionSeniaParticular.ToString(), // Tercera columna,
                       a.descripcion                                  // Cuarta columna  
                   }
                      }
               // rows = data.Skip((page - 1) * rows).Take(rows)
           };
 
            return Json(jsonData);
        }
 
        // Utility method to sort IQueryable given a field name as "string"
        // May consider to put in a central place to be shared
        private IQueryable<T> SortIQueryable<T>(IQueryable<T> data, 
			string fieldName, string sortOrder)
        {
            if (string.IsNullOrWhiteSpace(fieldName)) return data;
            if (string.IsNullOrWhiteSpace(sortOrder)) return data;
 
            var param = Expression.Parameter(typeof(T), "i");
            Expression conversion = Expression.Convert
		(Expression.Property(param, fieldName), typeof(object));
            var mySortExpression = Expression.Lambda<Func<T, object>>(conversion, param);
 
            return (sortOrder == "desc") ? data.OrderByDescending(mySortExpression)
                : data.OrderBy(mySortExpression);
        }
   


        /* Lista las Señas Particulares desde la View, requerido por JTables
         por eso devuelve JSon */
        /*http://www.codeproject.com/Articles/277576/AJAX-based-CRUD-tables-using-ASP-NET-MVC-3-and-jTa#SamplePage*/





        [HttpPost]
        public JsonResult SeniasParticularesList(List<SeniasParticulares> lsenias)
        {

            try
{
    // options: '/SeniasParticulares/ClaseSeniaParticularList',
                //List<SeniasParticulares> lsenias = null;
             
//                seniasL =     _seniasp;

                if (lsenias == null)
                { lsenias = new List<SeniasParticulares>(); }
                return Json(new { Result = "OK", Records = lsenias }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


        public ActionResult Update(SeniasParticulares viewModel, FormCollection formCollection,int? persona)
        {

            var operation = formCollection["oper"];
            if (operation.Equals("add") || operation.Equals("edit"))
            {
                List<SeniasParticulares> seniasl = null;
                /* seniasl =  (db.Persona.Find(persona).SeniasParticulares).ToList();
                var resultado = (SeniasParticulares) seniasl.Find(viewModel);
                if (resultado == null)
                { (SeniasParticulares) (db.Persona.Find(persona).SeniasParticulares).Add(viewModel); }
                else
                { }    

                */
                /*db.SaveOrUpdate(new SeniasParticulares
                {
                    ContactId = viewModel.ContactId,
                    DateOfBirth = viewModel.DateOfBirth,
                    Email = viewModel.Email,
                    IsMarried = viewModel.IsMarried,
                    Name = viewModel.Name,
                    PhoneNumber = viewModel.PhoneNumber
                });*/
            }
            else if (operation.Equals("del"))
            {
                /*repository.Delete(new ContactViewModel
                {
                    ContactId = new Guid(formCollection["id"])
                });*/
            }

            //return Content(repository.HasErrors.ToString().ToLower()); 
            return Json(new { Result = "OK" });
        
        }


        [HttpPost]
        public JsonResult Update(SeniasParticulares senia,int? persona)
        {
            try
            {
               /* if (!ModelState.IsValid)
                {
                    return Json(new
                    {
                        Result = "ERROR",
                        Message = "Form is not valid! " +
                          "Please correct it and try again."
                    });
                }
                 */         
                        

               
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult DeleteSenia(SeniasParticulares senia)
        {
            return Json(new { Result = "OK" });
        }



        [HttpPost]
        public JsonResult DeleteSenia(int ?seniaID)
        {
            try
            {
                
                SeniasParticulares vsenia = db.SeniasParticulares.Find(seniaID);
                db.SeniasParticulares.Remove(vsenia);



                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

   /*     [HttpPost]
        public JsonResult Delete(SeniasParticulares senia)
        {
            try
            {
                int seniaID = senia.id;
                SeniasParticulares vsenia= db.SeniasParticulares.Find(seniaID);
                db.SeniasParticulares.Remove(vsenia);

                    

                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        */
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
            
        [HttpPost]
        public ActionResult Create(SeniasParticulares seniasparticulares)
            {
            try
            {
                //Persona per= (Persona) ViewBag.idPersona;
                ViewBag.idSeniaParticular = new SelectList(db.ClaseSeniaParticulares, "id", "Descripcion", seniasparticulares.idSeniaParticular);
                ViewBag.idTablaDestino = new SelectList(db.ClaseTipoPersonas, "id", "Descripcion", seniasparticulares.idTablaDestino);
                ViewBag.idUbicacionSeniaParticular = new SelectList(db.ClaseUbicacionSeniaParticulares, "id", "Descripcion", seniasparticulares.idUbicacionSeniaParticular);
                if (!ModelState.IsValid)
                {
                    return Json(new
                    {
                        Result = "ERROR",
                        Message = "Form is not valid! " +
                        "Please correct it and try again."
                    });
                  }


                var seniasp = db.SeniasParticulares.Add(seniasparticulares);
                return Json(new { Result = "OK", Record = seniasp });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
                                  
                       
        }

        
    }
}