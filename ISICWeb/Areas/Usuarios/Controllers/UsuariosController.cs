using System;
using System.DirectoryServices;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using ISIC.Entities;
using ISICWeb.Areas.Usuarios.Models;
using ISICWeb.Services;
using MPBA.DataAccess;
using MPBA.Security.Entities;
using MPBA.Security.Ldap;

namespace ISICWeb.Areas.Usuarios.Controllers
{

    
    public class UsuariosController : Controller
    {
        private IRepository _repository;
        private UsuarioService _usuarioService;
        public UsuariosController(IRepository repository, UsuarioService usuarioService)
        {
            _repository = repository;
            _usuarioService = usuarioService;
        }

        [Authorize]
        public ActionResult AltaModificacionUsuario(string id = "")
        {
            UsuarioViewModel uvm= _usuarioService.LlenarViewModelDesdeBase(id);
            return View(uvm);
        }

        public bool BorrarUsuario(int id)
        {
            return _usuarioService.BorrarUsuario(id);
        }

        public ActionResult CompletarDatosSicNuevo(string id = "")
        {
            UsuarioViewModel uvm = _usuarioService.LlenarViewModelDesdeBase(id);
            uvm.Validando = true;
            LoginDomain ld=new LoginDomain();
            string usuarioDominio = ld.getCommonName(id);

            if (usuarioDominio != "")
            {
               uvm.Apellido = usuarioDominio.Substring(usuarioDominio.LastIndexOf(' ') + 1);
                uvm.Nombre = usuarioDominio.Substring(0, usuarioDominio.LastIndexOf(' '));
            }
            return View("AltaModificacionUsuario",uvm);
        }

        public ActionResult Index()
        {
            var Usuarios = _repository.Set<ISIC.Entities.Usuarios>().ToList();
            return View(Usuarios);
        }

        [HttpPost]
        public ActionResult GuardarDatosUsuario(UsuarioViewModel u)
        {
            string errores = "";
            if (ModelState.IsValid)
            {
                errores = _usuarioService.GuardarUsuario(u);
            }
            else
            {
                errores = string.Join("; ", ModelState.Values
                                          .SelectMany(x => x.Errors)
                                          .Select(x => x.ErrorMessage));
            }

            if (errores != "")
            {
                ModelState.AddModelError("", errores);
                return PartialView("_SummaryErrorUsuario", u);
            }
            return null;
      
        }



        public JsonResult BuscarUsuarioMPBA(string u)
        {

            string apellido = "";
            string nombre = "";
            bool huboError = false;
            string errorMessage = "";
            var loginDomain = new LoginDomain();

            string usuarioDominio = loginDomain.getCommonName(u);

            if (usuarioDominio != "")
            {
                apellido = usuarioDominio.Substring(usuarioDominio.LastIndexOf(' ') + 1);
                nombre = usuarioDominio.Substring(0, usuarioDominio.LastIndexOf(' '));
            }
            else
            {
                huboError = true;
                errorMessage = "No se encontraron resultados";
            }
            JsonResult json = new JsonResult
            {
                Data = new
                {
                    HuboError = huboError,
                    ErrorMessage = errorMessage,
                    Apellido = apellido,
                    Nombre = nombre
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            return json;

        }

        public ActionResult BuscarPuntoGestion(string term, string depto)
        {
            if (depto == "0")
            {
                var routeList =
                    _repository.Set<PuntoGestion>()
                        .Where(r => r.Descripcion.Contains(term))
                        .Take(50)
                        .Select(r => new { id = r.Id, label = r.Descripcion.Trim(), name = "PuntoGestionID", deptoId = r.Departamento.Id });
                return Json(routeList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var routeList =
                    _repository.Set<PuntoGestion>()
                        .Where(r => r.Descripcion.Contains(term) && (r.Departamento.Id.ToString() == depto))
                        .Take(50)
                        .Select(r => new { id = r.Id, label = r.Descripcion.Trim(), name = "PuntoGestionID", deptoId = r.Departamento.Id });
                return Json(routeList, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AltaUsuarioValidado(string u="")
        {
            //var loginDomain = new LoginDomain();
            //UsuarioViewModel uvm=new UsuarioViewModel();
            //string usuarioDominio = loginDomain.getCommonName(u);

            //if (usuarioDominio != "")
            //{
            //    uvm.Apellido = usuarioDominio.Substring(usuarioDominio.LastIndexOf(' ') + 1);
            //    uvm.Nombre = usuarioDominio.Substring(0, usuarioDominio.LastIndexOf(' '));
            //    uvm.NombreUsuario = u;
            //}
            //return View("AltaModificacionUsuario", "Usuario", uvm);
            return RedirectToAction("AltaModificacionUsuario",u);
        }
    }
}