using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MPBA.SIAC.Web.Models;
using System.Xml.Serialization;
using System.Xml;


namespace MPBA.SIAC.Web.Controllers
{
    public class IPPController : Controller
    {
        private SIACEntities db = new SIACEntities();

        //
        // GET: /IPP/

        public ActionResult Index()
        {
            
            return View();
        }

        //
        // GET: /IPP/Details/5

        public ActionResult Details(int id = 0)
        {
            IPP ipp = db.IPPs.Find(id);
            if (ipp == null)
            {
                return HttpNotFound();
            }
            return View(ipp);
        }

        //
        // GET: /IPP/Create

        public ActionResult Create()
        {

           
            return View();
        }
        

        //
        // POST: /IPP/Create

        [HttpPost]
        public ActionResult Create(IPP ipp)
        {
            
            if ((ModelState.IsValid == true) && (ModelState.IsValid == false))
            {
                db.IPPs.Add(ipp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ObtenerIPPSimp(ipp.numero, ipp);
         
            return View(ipp);
        }

       [HttpPost]
        public ActionResult IPPDetail(IPP ipp)
        {
            //string nro = this.ViewData.Eval("IPP1").ToString();
            string num = ViewBag.IPP1;
            if (ipp.IPP1 != null)
            {

                ObtenerIPPSimp(ipp.IPP1 , ipp);
                ViewBag.UFI = ipp.UFI;
                ViewBag.TitularUFI = ipp.UFI;
                ViewBag.ResponsableUFI = ipp.ResponsableUFI;
                ViewBag.caratula = ipp.caratula;
                ViewBag.FechaInicio = ipp.fechaInicio;
             
                return PartialView("IPPDetail");
            }
            return View("Create");
           
        }

        //
        // GET: /IPP/Edit/5

        public ActionResult Edit(int id = 0)
        {
            IPP ipp = db.IPPs.Find(id);
            if (ipp == null)
            {
                return HttpNotFound();
            }
           
           
            return View(ipp);
        }

        //
        // POST: /IPP/Edit/5

        [HttpPost]
        public ActionResult Edit(IPP ipp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ipp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
          
           
            return View(ipp);
        }

        //
        // GET: /IPP/Delete/5

        public ActionResult Delete(int id = 0)
        {
            IPP ipp = db.IPPs.Find(id);
            if (ipp == null)
            {
                return HttpNotFound();
            }
            return View(ipp);
        }

        //
        // POST: /IPP/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            IPP ipp = db.IPPs.Find(id);
            db.IPPs.Remove(ipp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        private bool ObtenerIPPSimp(string nroIPP, IPP myIPP)
        {
           /* WebServiceIPP.WebServiceMesaVirtualNNSoapClient wsIPP = new WebServiceIPP.WebServiceMesaVirtualNNSoapClient();*/
            System.Data.DataTable tblPuntosGestion = new System.Data.DataTable();
            tblPuntosGestion.Columns.Add("PuntoGestion");
            tblPuntosGestion.Columns.Add("ClasePuntoGestion");
            tblPuntosGestion.Rows.Clear();
     /*       try
            {
                string ippSimp = wsIPP.ConsultaCaratula(nroIPP);
                wsIPP.Close();
                XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(ippSimp));


                //Defino tabla para grilla de Victimas/Denunciante
                System.Data.DataTable tblVictimas = new System.Data.DataTable();
                tblVictimas.Columns.Add("tipo");
                tblVictimas.Columns.Add("Apellido");
                tblVictimas.Columns.Add("Nombre");
                //tblVictimas.Columns.Add("Id");
                // this.gvVictimas.DataSource = tblVictimas;
                //tblVictimas.Rows.Clear();
                ////////////////////////////////////
                //Defino tabla para grilla de Delitos
                System.Data.DataTable tblDelitos = new System.Data.DataTable();
                tblDelitos.Columns.Add("Descripcion");
                //

                //myIPP.organismosVinculadoss.Columns.Add("PuntoGestion");
                //myIPP.organismosVinculadoss.Columns.Add("ClasePuntoGestion");
                //myIPP.organismosVinculadoss.Rows.Clear();

                //this.gvDelitos.DataSource = tblDelitos;
                tblDelitos.Rows.Clear();
                ///////////////////////////////
                while (reader.Read())
                {
                    if (reader.NodeType != XmlNodeType.Element)
                        continue;
                    switch (reader.Name)
                    {
                        case "Causa":
                            while (reader.MoveToNextAttribute())
                            {
                                string nombre = reader.Name;
                                string valor = reader.Value;
                                switch (nombre)
                                {
                                    case "UFI":
                                        {
                                            myIPP.UFI = valor;
                                            break;
                                        }
                                    case "ResponsableUFI":
                                        {
                                            myIPP.ResponsableUFI = valor;
                                            break;
                                        }
                                    case "TitularUFI":
                                        {
                                            myIPP.TitularUFI = valor;
                                            break;
                                        }
                                    case "FechaInicioIPP":
                                        {
                                            myIPP.fechaInicio = Convert.ToDateTime(valor);
                                            break;
                                        }
                                }
                            }
                            break;
                        case "personas":
                            while (reader.MoveToNextAttribute())
                            {
                                string nombre = reader.Name;
                                string aa = reader.Value;
                            }
                            break;
                        case "Denunciante":
                            if (reader.HasAttributes)
                            {
                                System.Data.DataRow rowDenunciante = tblVictimas.NewRow();
                                rowDenunciante["tipo"] = "D";
                                while (reader.MoveToNextAttribute())
                                {
                                    switch (reader.Name)
                                    {
                                        case "Nombre":
                                            rowDenunciante["Nombre"] = reader.Value;
                                            break;
                                        case "Apellido":
                                            rowDenunciante["Apellido"] = reader.Value;
                                            break;
                                        //case "ID":
                                        //    rowDenunciante["Id"] = reader.Value;
                                        //    break;
                                    }

                                }
                                tblVictimas.Rows.Add(rowDenunciante);
                            }
                            break;
                        case "Victima":
                            if (reader.HasAttributes)
                            {
                                System.Data.DataRow rowVictima = tblVictimas.NewRow();
                                rowVictima["tipo"] = "V";
                                while (reader.MoveToNextAttribute())
                                {
                                    switch (reader.Name)
                                    {
                                        case "Nombre":
                                            rowVictima["Nombre"] = reader.Value;
                                            break;
                                        case "Apellido":
                                            rowVictima["Apellido"] = reader.Value;
                                            break;
                                        //case "ID":
                                        //    rowVictima["Id"] = reader.Value;
                                        //    break;
                                    }
                                }
                                tblVictimas.Rows.Add(rowVictima);
                            }
                            break;
                        case "Imputado":
                            while (reader.MoveToNextAttribute())
                            {
                                string nombre = reader.Name;
                                string aa = reader.Value;
                            }
                            break;
                        case "Delitos":
                            reader.ReadToDescendant("Delito");
                            if (reader.HasAttributes)
                            {
                                System.Data.DataRow rowDelito = tblDelitos.NewRow();
                                while (reader.MoveToNextAttribute())
                                {
                                    switch (reader.Name)
                                    {
                                        case "Descripcion":
                                            rowDelito["Descripcion"] = reader.Value;
                                            break;
                                    }
                                    tblDelitos.Rows.Add(rowDelito);
                                }
                            }
                            break;
                        case "Delito":
                            while (reader.MoveToNextAttribute())
                            {
                                string nombre = reader.Name;
                                string aa = reader.Value;
                            }
                            break;
                        case "OrganismoVinculado":
                            if (reader.HasAttributes)
                            {
                                System.Data.DataRow rowPuntoGestion = tblPuntosGestion.NewRow();
                                while (reader.MoveToNextAttribute())
                                {
                                    switch (reader.Name)
                                    {
                                        case "idPuntoGestion":
                                            rowPuntoGestion["PuntoGestion"] = reader.Value;
                                            break;
                                        case "idClasePuntoGestion":
                                            rowPuntoGestion["ClasePuntoGestion"] = reader.Value;
                                            break;
                                    }
                                }
                                tblPuntosGestion.Rows.Add(rowPuntoGestion);
                            }
                            break;



                    }

                }


            }
            catch (System.Web.Services.Protocols.SoapException ex) { return false; }*/
            return true;
            //si solo tiene permiso para su punto de Gestion controlo que la IPP pertenezca a su punto de gestion
            
           
        }
    }
}