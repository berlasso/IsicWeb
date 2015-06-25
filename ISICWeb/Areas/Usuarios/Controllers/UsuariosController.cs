using System;
using System.Data.Entity.Validation;
using System.DirectoryServices;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ISIC.Entities;
using ISICWeb.Areas.Usuarios.Models;
using ISICWeb.Services;
using MPBA.DataAccess;
using MPBA.Security.Entities;
using MPBA.Security.Ldap;
using Postal;

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

        public bool BorrarUsuario(string id)
        {
            return _usuarioService.BorrarUsuario(id);
        }

        /// <summary>
        /// Completa registracion el en el isic habiendo estado registrado en el sic viejo
        /// </summary>
        /// <param name="us">usuario en el sic viejo</param>
        /// <param name="id">usuario para el isic</param>
        /// <returns></returns>
        public ActionResult CompletarDatosSicNuevo(string us, string id = "nada")
        {
            UsuarioViewModel uvm = _usuarioService.LlenarViewModelDesdeBase(id);
            uvm.Validando = true;
            uvm.id = null;
            uvm.UsuarioSicViejo = us;
            uvm.UsuarioMPBA = id!="nada";
            LoginDomain ld=new LoginDomain();
            string usuarioDominio = ld.getCommonName(id);

            if (usuarioDominio != "***")
            {
               uvm.Apellido = usuarioDominio.Substring(usuarioDominio.LastIndexOf(' ') + 1);
                uvm.Nombre = usuarioDominio.Substring(0, usuarioDominio.LastIndexOf(' '));
                uvm.Email = id + "@MPBA.GOV.AR";
            }
            if (id == "nada")
                uvm.NombreUsuario = "";
            return View("AltaModificacionUsuario",uvm);
        }

        public ActionResult Index()
        {
            //var Usuarios = _repository.Set<ISIC.Entities.Usuarios>().ToList();
            UsuarioViewModel uvm = new UsuarioViewModel
            {
                DepartamentoList = new SelectList(_repository.Set<Departamento>().ToList(), "id", "Descripcion")
            };
            return View(uvm);
        }

        public string ReenviarToken(string e,string uid = "")
        {
            ISIC.Entities.Usuarios u = _repository.Set<ISIC.Entities.Usuarios>().SingleOrDefault(x => x.id == uid);
            string errores = "";
            if (u != null)
            {
                Guid token = Guid.NewGuid();
                u.TokenEnviado = token;
                u.PersonalPoderJudicial.Persona.EMail = e;
                u.activo = false;
                _repository.UnitOfWork.RegisterChanged(u);
                try
                {
                    _repository.UnitOfWork.Commit();
                   errores= EnviarMail(u);
                    
                }
                catch (DbEntityValidationException ex)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (var failure in ex.EntityValidationErrors)
                    {
                        sb.AppendFormat("{0} fallo validacion\n", failure.Entry.Entity.GetType());
                        foreach (var error in failure.ValidationErrors)
                        {
                            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                            sb.AppendLine();
                            errores = sb.ToString();
                        }
                    }
                }
                catch
                {
                    errores = "Error al enviar ";
                    errores += string.Join("; ", ModelState.Values
                        .SelectMany(x => x.Errors)
                        .Select(x => x.ErrorMessage));

                }
            }
            else
            {
                errores = "No se encontro el usuario";
            }
            return errores;
        }



        public ActionResult ConfirmarEmail(string u, string t)
        {
            ViewBag.Token = t;
            ViewBag.Usuario = u;
            string errores = "";
            ISIC.Entities.Usuarios usuario =
                _repository.Set<ISIC.Entities.Usuarios>().SingleOrDefault(x => x.id == u && x.TokenEnviado.ToString() == t);
            if (usuario != null)
            {
                usuario.TokenEnviado = null;
                usuario.activo = true;
                if (usuario.UsuarioMPBA != null && usuario.UsuarioMPBA != true)
                {
                   UsuarioViewModel uvm= _usuarioService.LlenarViewModelDesdeBase(u);
                    uvm.TokenEnviado = null;
                    uvm.activo = true;
                    return View("~/Views/Account/Register.cshtml",null,uvm);
                }
                _repository.UnitOfWork.RegisterChanged(usuario);
                try
                {
                    _repository.UnitOfWork.Commit();
                    return View();
                }
                catch
                {
                    errores = "No se pudo guarda el alta.";
                }
            }
            else
            {
                errores = "No se encontró ningún usuario con el id y token indicados";
            }
            if (errores != "")
            {
                return View("Error",null, errores);
            }
            return null;
        }

      

        public string EnviarMail( ISIC.Entities.Usuarios u)
        {
            string errores = "";
            var email = new VerificacionEmail
            {
                Sexo = u.PersonalPoderJudicial.Persona.Sexo.Id,
                Apellido = u.PersonalPoderJudicial.Persona.Apellido,
                Nombre = u.PersonalPoderJudicial.Persona.Nombre,
                Email = u.PersonalPoderJudicial.Persona.EMail,
                Token=u.TokenEnviado,
                Departamento = u.PersonalPoderJudicial.PuntoGestion.Departamento.DepartamentoNombre,
                Subject = "Verificacion Cuenta ISIC",
                NombreUsuario = u.NombreUsuario,
                UsuarioMPBA = u.UsuarioMPBA
                
            };
                email.Dependencia =string.IsNullOrEmpty(u.Dependencia)?u.PersonalPoderJudicial.PuntoGestion.Descripcion:u.Dependencia;            
            try
            {
                email.Send();
            }
            catch
            {
                if (!ModelState.IsValid)
                {
                    errores = string.Join("; ", ModelState.Values
                        .SelectMany(x => x.Errors)
                        .Select(x => x.ErrorMessage));
                }
                else
                {
                    errores = "Error al enviar";
                }
                return errores;
            }
            return "";
        }

        [HttpPost]
        public ActionResult GuardarDatosUsuario(UsuarioViewModel u)
        {
            string errores = "";

            if (u.Sexo.Id==0)
            {
                ModelState.AddModelError("Sexo", "Debe indicar el sexo");
            }
            if (u.UsuarioMPBA)
            {
                if (u.PuntoGestion == null || string.IsNullOrEmpty(u.PuntoGestion.Id))
                {
                    ModelState.AddModelError("", "Debe indicar el Punto de Gestion");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(u.Dependencia))
                {
                    ModelState.AddModelError("Dependencia", "Debe indicar la dependencia");
                }
            }
            if (u.Departamento == null)
            {
                ModelState.AddModelError("", "Debe indicar el Departamento");
            }
            if (ModelState.IsValid)
            {
                errores = _usuarioService.GuardarUsuario(u);
                if (errores!="")
                    ModelState.AddModelError("", errores);
            }
            else
            {
                errores = string.Join("; ", ModelState.Values
                                          .SelectMany(x => x.Errors)
                                          .Select(x => x.ErrorMessage));
            }

            if (!ModelState.IsValid)
            {
            //    ModelState.AddModelError("", errores);
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