using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MPBA.SIAC.Web.Models;
using MPBA.AutoresIgnorados.BusinessEntities;
using System.Globalization;
using MPBA.SIAC.Web.Filters;
using MPBA.SIAC.Web.Models.MetaDataClass;

namespace MPBA.SIAC.Web.Controllers  
{
    public class AutoresController : Controller
    {
        private SIACEntities db = new SIACEntities();

        //
      
        // GET: /Autores/

        public ActionResult Index()
        {
            var autores = db.Autores.Include(a => a.NNClaseEdadAproximada).Include(a => a.NNClaseRostro).Include(a => a.NNClaseSexo).Include(a => a.Delito);
            return View(autores.ToList());
        }

   

        /*Busqueda General  */


         [Audita(AuditingLevel = 2)]
         public ActionResult BusquedaAutoresCoincidentes(string porautor)
         {
             BusquedaRobosDelitosSexuales criterio;


             criterio = (BusquedaRobosDelitosSexuales)Session["miBusqueda"];
             IEnumerable<MPBA.SIAC.Web.Models.DelitosAutoresAnalisisGeneral_Result> autores = db.DelitosAutoresAnalisisGeneral(porautor,criterio.IdDelito, criterio.FechaDesde,
                 criterio.FechaHasta, criterio.HoraDesde,
                criterio.HoraHasta, criterio.IdClaseDelito,
                criterio.IdClaseMomentoDelDia, criterio.IdPartido, criterio.IdLocalidad, criterio.ParajeBarrioH, criterio.IdCalle, criterio.IdEntreCalle1, criterio.IdEntreCalle2, criterio.IdOtraCalle,
                criterio.IdOtraEntreCalle, criterio.IdOtraEntreCalle2, criterio.NroH, criterio.PisoH, criterio.DeptoH,
                  criterio.IdComisariaH, criterio.IdClaseLugar, criterio.IdClaseRubro, criterio.NomReferenciaLugarRubro,
                  criterio.IdClaseModusOperandi, criterio.IdCausa, criterio.IdClaseModoArriboHuida,
                  criterio.IdMarcaVehiculoMO, criterio.IdModeloVehiculoMO, criterio.DominioMO, criterio.IdColorVehiculoMO, criterio.IdClaseVidrioVehiculoMO, criterio.IngresaronPor,
                  Convert.ToBoolean(criterio.VictimasEnElLugar), Convert.ToBoolean(criterio.HuboAgresionFisicaAVictima), criterio.IdClaseAgresion, criterio.IdClaseZonaCuerpoLesionada,
                  Convert.ToBoolean(criterio.VictimaTrasladadaAOtroLugar), criterio.IdLocalidadTraslado, criterio.IdPartidoL, criterio.idLocalidadL,
                  criterio.ParajeBarrioL, criterio.IdCalleL, criterio.IdOtraCalleL, criterio.IdEntreCalle1L, criterio.OtraEntreCalle1L, criterio.IdEntreCalle2L, criterio.OtraEntreCalle2L,
                  criterio.IdComisariaL,
                 Convert.ToBoolean(criterio.UsoDeArmas), criterio.IdClaseArma, criterio.OtraClaseArma, criterio.ExprUtilizadaComienzoDelHecho,
                  criterio.ExprReiteradaDuranteHecho, criterio.IdClaseCantidadAutores,
                 float.Parse(Convert.ToString(criterio.MontoTotalEstimadoBienSustraido)), criterio.IdVicTestRecRueda, criterio.Nro, criterio.IdClaseEdadAproximada,
                criterio.IdClaseSexo, criterio.IdClaseRostro, criterio.CubiertoCon,
                 criterio.IdClaseSeniaParticularL, criterio.IdClaseTatuajeL, criterio.idDimensionCejaL, criterio.idTipoCejaL, criterio.idClaseColorCabelloL, criterio.idClaseColorOjosL,
                  criterio.idClaseColorPielL, criterio.idClaseEstaturaL,
                  criterio.idClaseFormaCaraL, criterio.idFormaBocaL, criterio.idFormaMentonL, criterio.idFormaLabioInferiorL, criterio.idFormaLabioSuperiorL,
                  criterio.idFormaNarizL, criterio.idFormaOrejaL, criterio.idClaseRobustezL, criterio.idClaseTipoCabelloL, criterio.idClaseCalvicieL, criterio.OtraCaracteristica,
                  criterio.IdClaseBienSustraido,
                 criterio.IdMarcaVehiculoBS, criterio.IdModeloVehiculoBS, criterio.AnioBS, criterio.DominioBS, criterio.IdColorVehiculoBS,
                  criterio.IdClaseVidrioVehiculoBS, criterio.NumeroMotorBS, criterio.NumeroChasisBS, Convert.ToBoolean(criterio.GNCBS), criterio.IdentificacionGNCBS,
                  criterio.IdClaseGanado,
                  criterio.CantidadGanado, criterio.MarcaGanado, criterio.MarcaBienSustraidoOtro, criterio.NroSerieBienSustraidoOtro, criterio.CantidadBienSustraidoOtro,
                  criterio.IdClaseCantidadAutores, criterio.IdClaseCondicionVictima, criterio.IdDepartamento, criterio.NombreAutor, criterio.ApellidoAutor, criterio.ApodoAutor, criterio.DocNroAutor).ToList();

             ViewBag.idClaseEdadAproximada = new SelectList(db.NNClaseEdadAproximadas, "id", "descripcion");
             ViewBag.titulo = "Autores Coincidentes";

             /*Objetivo: Mostrar los resultados del Stored Procedure con la totalidad de Coincidencias y los campos coincidentes en otro color
              Ademas visualizaar los campos que coinciden primero, para evitar scrollar horizontalmente hasta encontrar la coincidencia
              Funcionalidad: Se crea una matriz con los cnombres de cabeceras y nombres columnas. 
              * se arma la grilla dinamicamente segun los campos coincidentes
              Los campos que coinciden del primer reguistro (es el que cuenta con la mayor cantidad de coincidencias, marca el orden de las coluMnas
              * Tener en cuenta que el Stored devuelve siempre un numero +1 de coincidencias por el sexo que es obligatorio
              * Tener en cuenta que el Action de Ignorados puede definir que el Orden de las columnas SEA DIFERENTE Porque no cuenta con Apellido, Nombre, Apodo y los datos son distintos!
              Asi si coincide en apellido, DNI y forma del menton, estas tres columnas deben ir primeras
              las clases marcar y normal estan en dataTable-jui.css*/

             string[,] NombreColumnas = new string[2, 26] {{"idCausa","apellido","nombres","apodo","dni","edadAproximada","estatura","robustez","colorPiel","colorOjos","colorCabello","tipoCabello","calvicie","formaCara","dimesionCeja","tipoCeja","formaMenton" ,"formaOreja","formaNariz","formaBoca","labioInferior" ,"labioSuperior","claseRostro","CubiertoCon", "idImputadoSimp","OtraCaracteristica"},
                      {"Causa","apellido","nombres","apodo","dni","Edad","Estatura","Robustez","Color de Piel","Color de Ojos","Color de Cabello","Tipo de Cabello","Calvicie","Forma de Cara","Dimesion Ceja","Tipo Ceja","Forma Menton" ,"Forma Oreja","Forma Nariz","Forma Boca","Labio Inferior" ,"Labio Superior","Clase de Rostro","Cubierto Con", "ID Imputado SIMP","Otra Caracteristica"}};
             //int[] OrdenColumnas = Enumerable.Repeat(0, 28).ToArray();
             List<Columnas> lista = new List<Columnas>();

             if (autores.Count() > 0)
             {
                 int indice = 1;
                 //string nombre, columna;
                 Columnas p = new Columnas();
                 p.nombreCampo = "CantidadTotal";
                 p.nombreTitulo = "Total de Coincidencias";
                 p.orden = indice;
                 p.clase = "marcar";
                 lista.Add(p);
                 indice++;


                 Columnas p1 = new Columnas();
                 p1.nombreCampo = "IgnoradoAp";
                 p1.nombreTitulo = "Ignorado/Ap";
                 p1.orden = indice;
                 p1.clase = "normal";
                 lista.Add(p1);
                 indice++;


                 if (autores.First().CoincidenciaDNI > 0)
                 {
                     Columnas c = new Columnas();
                     c.nombreCampo = "dni";
                     c.nombreTitulo = "DNI";
                     c.orden = indice;
                     c.clase = "marcar";
                     lista.Add(c);
                     indice++;

                 }

                 if (autores.First().CoincidenciaApellido > 0)
                 {
                     Columnas c = new Columnas();
                     c.nombreCampo = "apellido";
                     c.nombreTitulo = "Apellido";
                     c.orden = indice;
                     c.clase = "marcar";
                     lista.Add(c);
                     indice++;

                 }
                 if (autores.First().CoincidenciaNombre > 0)
                 {
                     Columnas c = new Columnas();
                     c.nombreCampo = "nombres";
                     c.nombreTitulo = "Nombres";
                     c.orden = indice;
                     c.clase = "marcar";
                     lista.Add(c);
                     indice++;

                 }

                 if (autores.First().CoincidenciaApodo > 0)
                 {
                     Columnas c = new Columnas();
                     c.nombreCampo = "apodo";
                     c.nombreTitulo = "Apodo";
                     c.orden = indice;
                     c.clase = "marcar";
                     lista.Add(c);
                     indice++;
                 }
                 if (autores.First().CoincidenciaEdad > 0)
                 {
                     Columnas c = new Columnas();
                     c.nombreCampo = "edadAproximada";
                     c.nombreTitulo = "Edad";
                     c.orden = indice;
                     c.clase = "marcar";
                     lista.Add(c);
                     indice++;
                 }
                 if (autores.First().CoincidenciaTatuajes > 0)
                 {
                     Columnas c = new Columnas();
                     c.nombreCampo = "CoincidenciaTatuajes";
                     c.nombreTitulo = "=Tatuajes/Ubicación";
                     c.orden = indice;
                     c.clase = "marcar";
                     lista.Add(c);
                     indice++;
                 }
                 if (autores.First().CoincidenciaSeniasParticulares > 0)
                 {
                     Columnas c = new Columnas();
                     c.nombreCampo = "CoincidenciaSeniasParticulares";
                     c.nombreTitulo = "=Señas/Ubicación";
                     c.orden = indice;
                     c.clase = "marcar";
                     lista.Add(c);
                     indice++;
                 }
                 if (autores.First().CoincidenciaColorCabello > 0)
                 {
                     Columnas c = new Columnas();
                     c.nombreCampo = "colorCabello";
                     c.nombreTitulo = "Color de Cabello";
                     c.orden = indice;
                     c.clase = "marcar";
                     lista.Add(c);
                     indice++;
                 }

                 if (autores.First().CoincidenciaColorOjos > 0)
                 {
                     Columnas c = new Columnas();
                     c.nombreCampo = "colorOjos";
                     c.nombreTitulo = "Color de Ojos";
                     c.orden = indice;
                     c.clase = "marcar";
                     lista.Add(c);
                     indice++;
                 }
                 if (autores.First().CoincidenciaColorPiel > 0)
                 {
                     Columnas c = new Columnas();
                     c.nombreCampo = "colorPiel";
                     c.nombreTitulo = "Color de Piel";
                     c.orden = indice;
                     c.clase = "marcar";
                     lista.Add(c);
                     indice++;
                 }
                 if (autores.First().CoincidenciaRobustez > 0)
                 {
                     Columnas c = new Columnas();
                     c.nombreCampo = "robustez";
                     c.nombreTitulo = "Robustez";
                     c.orden = indice;
                     c.clase = "marcar";
                     lista.Add(c);
                     indice++;
                 }

                 if (autores.First().CoincidenciaClaseCalvicie > 0)
                 {
                     Columnas c = new Columnas();
                     c.nombreCampo = "calvicie";
                     c.nombreTitulo = "Calvicie";
                     c.orden = indice;
                     c.clase = "marcar";
                     lista.Add(c);
                     indice++;
                 }
                 if (autores.First().CoincidenciaTipoCabello > 0)
                 {
                     Columnas c = new Columnas();
                     c.nombreCampo = "tipoCabello";
                     c.nombreTitulo = "Tipo de Cabello";
                     c.orden = indice;
                     c.clase = "marcar";
                     lista.Add(c);
                     indice++;
                 }

                 if (autores.First().CoincidenciaEstatura > 0)
                 {
                     Columnas c = new Columnas();
                     c.nombreCampo = "estatura";
                     c.nombreTitulo = "Estatura";
                     c.orden = indice;
                     c.clase = "marcar";
                     lista.Add(c);
                     indice++;
                 }

                 if (autores.First().CoincidenciaFormaCara > 0)
                 {
                     Columnas c = new Columnas();
                     c.nombreCampo = " formaCara";
                     c.nombreTitulo = "Forma de Cara";
                     c.orden = indice;
                     c.clase = "marcar";
                     lista.Add(c);
                     indice++;
                 }
                 if (autores.First().CoincidenciaFormaNariz > 0)
                 {
                     Columnas c = new Columnas();
                     c.nombreCampo = "formaNariz";
                     c.nombreTitulo = "Forma de la Nariz";
                     c.orden = indice;
                     c.clase = "marcar";
                     lista.Add(c);
                     indice++;
                 }
                 if (autores.First().CoincidenciaClaseRostro > 0)
                 {
                     Columnas c = new Columnas();
                     c.nombreCampo = "claseRostro";
                     c.nombreTitulo = "Clase de Rostro";
                     c.orden = indice;
                     c.clase = "marcar";
                     lista.Add(c);
                     indice++;
                 }
                 if (autores.First().CoincidenciaFormaBoca > 0)
                 {
                     Columnas c = new Columnas();
                     c.nombreCampo = "formaBoca";
                     c.nombreTitulo = "Forma de Boca";
                     c.orden = indice;
                     c.clase = "marcar";
                     lista.Add(c);
                     indice++;
                 }

                 if (autores.First().CoincidenciaFormaMenton > 0)
                 {
                     Columnas c = new Columnas();
                     c.nombreCampo = "formaMenton";
                     c.nombreTitulo = "Forma del Mentón";
                     c.orden = indice;
                     c.clase = "marcar";
                     lista.Add(c);
                     indice++;
                 }

                 if (autores.First().CoincidenciaFormaOreja > 0)
                 {
                     Columnas c = new Columnas();
                     c.nombreCampo = "formaOreja";
                     c.nombreTitulo = "Forma de la Oreja";
                     c.orden = indice;
                     c.clase = "marcar";
                     lista.Add(c);
                     indice++;
                 }
                 if (autores.First().CoincidenciaDimensionCeja > 0)
                 {
                     Columnas c = new Columnas();
                     c.nombreCampo = "dimesionCeja";
                     c.nombreTitulo = "Dimensión de Ceja";
                     c.orden = indice;
                     c.clase = "marcar";
                     lista.Add(c);
                     indice++;
                 }
                 if (autores.First().CoincidenciaFormaLabioInf > 0)
                 {
                     Columnas c = new Columnas();
                     c.nombreCampo = "labioInferior";
                     c.nombreTitulo = "Labio Inferior";
                     c.orden = indice;
                     c.clase = "marcar";
                     lista.Add(c);
                     indice++;
                 }
                 if (autores.First().CoincidenciaFormaLabioSup > 0)
                 {
                     Columnas c = new Columnas();
                     c.nombreCampo = "labioSuperior";
                     c.nombreTitulo = "Labio Superior";
                     c.orden = indice;
                     c.clase = "marcar";
                     lista.Add(c);
                     indice++;
                 }
                 // Recorro el array NombreColumnas para saber que columnas faltan agregar que no tienen coincidencias
                 // Consulta si el valor de la columna esta en lista.nombreCampo? for (int x = 0; x < array.GetLength(0); x += 1) {
                 for (int i = 0; i < NombreColumnas.GetLength(1); i += 1)
                 {
                     if (!lista.Any(x => x.nombreCampo == NombreColumnas[0, i]))
                     {
                         Columnas c = new Columnas();
                         c.nombreCampo = NombreColumnas[0, i];
                         c.nombreTitulo = NombreColumnas[1, i];
                         c.orden = indice;
                         c.clase = "normal";
                         lista.Add(c);
                         indice++;
                     }
                 }


                 lista = lista.OrderBy(x => x.orden).ToList();
                 ViewBag.DatosGrilla = lista;
                 ViewBag.titulo = "Autores";

             }
             if (autores.Count() == 0)
             {
                 ViewBag.mensaje = "No hay Autores Coincidentes con los filtros indicados en todas las solapas";
                 return View("Mensaje");
             }
             else
                 return View(autores);
         }
       














                //
                // GET: /Autores/Details/5
        /*
                public ActionResult Details(int id = 0)
                {
                    Autores autores = db.Autores.Find(id);
                    if (autores == null)
                    {
                        return HttpNotFound();
                    }
                    return View(autores);
                }
                */
        //
        // GET: /Autores/Create

        public ActionResult Create()
        {
            ViewBag.idClaseEdadAproximada = new SelectList(db.NNClaseEdadAproximadas, "id", "descripcion");
            ViewBag.idClaseRostro = new SelectList(db.NNClaseRostroes, "id", "descripcion");
            ViewBag.idClaseSexo = new SelectList(db.NNClaseSexoes, "id", "descripcion");
            ViewBag.idDelito = new SelectList(db.Delitos, "id", "idCausa");
            return View();
        }

        //
        // POST: /Autores/Create

      /*  [HttpPost]
        public ActionResult Create(Autores autores)
        {
            if (ModelState.IsValid)
            {
                db.Autores.Add(autores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idClaseEdadAproximada = new SelectList(db.NNClaseEdadAproximadas, "id", "descripcion", autores.idClaseEdadAproximada);
            ViewBag.idClaseRostro = new SelectList(db.NNClaseRostroes, "id", "descripcion", autores.idClaseRostro);
            ViewBag.idClaseSexo = new SelectList(db.NNClaseSexoes, "id", "descripcion", autores.idClaseSexo);
            ViewBag.idDelito = new SelectList(db.Delitos, "id", "idCausa", autores.idDelito);
            return View(autores);
        }*/

        //
        // GET: /Autores/Edit/5

   /*     public ActionResult Edit(int id = 0)
        {
            Autores autores = db.Autores.Find(id);
            if (autores == null)
            {
                return HttpNotFound();
            }
            ViewBag.idClaseEdadAproximada = new SelectList(db.NNClaseEdadAproximadas, "id", "descripcion", autores.idClaseEdadAproximada);
            ViewBag.idClaseRostro = new SelectList(db.NNClaseRostroes, "id", "descripcion", autores.idClaseRostro);
            ViewBag.idClaseSexo = new SelectList(db.NNClaseSexoes, "id", "descripcion", autores.idClaseSexo);
            ViewBag.idDelito = new SelectList(db.Delitos, "id", "idCausa", autores.idDelito);
            return View(autores);
        }
        */
        //
        // POST: /Autores/Edit/5

   /*     [HttpPost]
        public ActionResult Edit(Autores autores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idClaseEdadAproximada = new SelectList(db.NNClaseEdadAproximadas, "id", "descripcion", autores.idClaseEdadAproximada);
            ViewBag.idClaseRostro = new SelectList(db.NNClaseRostroes, "id", "descripcion", autores.idClaseRostro);
            ViewBag.idClaseSexo = new SelectList(db.NNClaseSexoes, "id", "descripcion", autores.idClaseSexo);
            ViewBag.idDelito = new SelectList(db.Delitos, "id", "idCausa", autores.idDelito);
            return View(autores);
        }*/

        //
        // GET: /Autores/Delete/5

        /*public ActionResult Delete(int id = 0)
        {
            Autores autores = db.Autores.Find(id);
            if (autores == null)
            {
                return HttpNotFound();
            }
            return View(autores);
        }
        */
        //
        // POST: /Autores/Delete/5

        /*[HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Autores autores = db.Autores.Find(id);
            db.Autores.Remove(autores);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }*/
    }
}