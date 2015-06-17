using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.EntitySql;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using System.Web.UI.WebControls.Expressions;
using ISIC.Entities;
using ISIC.Persistence.Context;
using ISICWeb.Areas.PortalSIC.Models;
using ISICWeb.Areas.PortalSIC.Services;
using MPBA.DataAccess;

namespace ISICWeb.Areas.PortalSIC.Controllers
{
    
    public class InfiniteScrollerController : Controller
    {
        private IRepository repository;
        private BusquedaService _busquedaService;
        private const int CantPorPag = 30;
        private const int MaxImputados = 1000;

        public InfiniteScrollerController(IRepository repository, BusquedaService busquedaService)
        {
            this.repository = repository;
            _busquedaService = busquedaService;
        }

        public ActionResult MostrarFotosSeleccionadas(string fotos)
        {
            IEnumerable<string> fotosElegidas= fotos.Split(',');

            return View(fotosElegidas);
        }

        // GET: Home
        public ActionResult GenerarScroller(int? pag)
        {
            if (pag == null)
                pag = 1;

            ViewBag.cantPorPag = CantPorPag;
       
            //var archivos= repository.Set<Archivo>().ToList();
            //System.IO.DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Areas/PortalSIC/Fotos"));

            //var files1 = di.GetFiles();
            //    .Where(x => x.Extension.ToLower() == ".jpg")
            //    .Select((v, i) => new Row { value = v.Name, index = i }).Skip((CantPorPag - 1) * Convert.ToInt32(pag)).Take(CantPorPag);
            //ViewBag.CantidadTotal= repository.Set<Archivo>().Count();
            //ImportarFotosATabla(files1);
            BusquedaViewModel model = (BusquedaViewModel)Session["model"];
            ISICContext ctx = (ISICContext)repository.UnitOfWork.Context;
            string querystring = "";
            var imputados = _busquedaService.BuscarImputados(model,MaxImputados,out querystring);

            //var files = (from i in imputados
            //             join a in ctx.Archivos.ToList()
            //                 on i.Id equals a.Imputado.Id
            //             where a.TipoArchivo.Id == 1 //solo fotos de rostros;
            //             select a);




            IEnumerable<Archivo> files = imputados.Join(ctx.Archivo.ToList(), i => i.Id, a => a.Imputado.Id, (i, a) => a).Where(a => a.TipoArchivo.Id == 1);
           
           
            if (pag == 1)
            {
                
                
                ViewBag.CantidadTotal = files.Count();
                ViewBag.CantidadMaxima = MaxImputados;
            }
            else
            {
                
            }
            //if (cant > 0)
            //{
                
                files = files.OrderBy(f => f.Url).Take(MaxImputados).Skip((CantPorPag)*(Convert.ToInt32(pag) - 1)).Take(CantPorPag);

                if (files.Any())
                {
                    ViewBag.pagina = pag++;

                    return View(files);
                }
            //}


            return View(files);
        }

        public void ImportarFotosATabla(FileInfo[] files)
        {
            foreach (var file in files)
            {
                Archivo archivo = new Archivo
                {
                    Descripcion = "prueba scroller",
                    FechaUpload = DateTime.Now,
                    Nombre = file.Name,
                    Tamano = file.Length.ToString(),
                    TipoArchivo = repository.Set<ClaseTipoArchivo>().First(x => x.Id == 1),
                    Uploader = "German",
                    Imputado = repository.Set<Imputado>().First(i=>i.Id==1),
                    Url = string.Format("~/Areas/PortalSIC/Fotos/{0}", file.Name)
                };
                repository.UnitOfWork.RegisterNew(archivo);
            }
            repository.UnitOfWork.Commit();
        }
    }
}