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
    [Audit]
    [Autorizar(Roles = "Administrador, Portal")]
    public class InfiniteScrollerController : Controller
    {
        private IRepository repository;
        private IBusquedaService _busquedaService;
        private const int CantPorPag = 30;
        private const int MaxImputados = 1000;

        public InfiniteScrollerController(IRepository repository, IBusquedaService busquedaService)
        {
            this.repository = repository;
            _busquedaService = busquedaService;
        }

        public ActionResult MostrarFotosSeleccionadas(string fotos)
        {
            IEnumerable<string> fotosElegidas = fotos.Split(',');

            return View(fotosElegidas);
        }

        // GET: Home
        public ActionResult GenerarScroller(int? pag)
        {
              BusquedaViewModel model = (BusquedaViewModel)Session["model"];
            if (model == null)
            {
                return RedirectToAction("Index","Busqueda");
            }
            if (pag == null)
                pag = 1;
            ViewBag.cantPorPag = CantPorPag;
          
            ISICContext ctx = (ISICContext)repository.UnitOfWork.Context;
            string querystring = "";
            var imputados = _busquedaService.BuscarImputados(model, MaxImputados, out querystring);
            IEnumerable<Archivo> files = imputados.SelectMany(x => x.Archivos).Where(n => n.TipoArchivo.Id == 1).OrderBy(f => f.Url).Skip((CantPorPag) * (Convert.ToInt32(pag) - 1)).Take(CantPorPag).ToList();
            if (pag == 1)
            {
                ViewBag.CantidadMaxima = MaxImputados;
            }

            if (files.Any())
            {
                ViewBag.pagina = pag++;

                return View(files);
            }
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
                    Imputado = repository.Set<Imputado>().First(i => i.Id == 1),
                    Url = string.Format("~/Areas/PortalSIC/Fotos/{0}", file.Name)
                };
                repository.UnitOfWork.RegisterNew(archivo);
            }
            repository.UnitOfWork.Commit();
        }
    }
}