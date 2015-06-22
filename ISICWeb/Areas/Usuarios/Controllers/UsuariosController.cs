using System;
using System.DirectoryServices;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
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

        public bool BorrarUsuario(string id)
        {
            return _usuarioService.BorrarUsuario(id);
        }

        public ActionResult CompletarDatosSicNuevo(string id = "nada")
        {
            UsuarioViewModel uvm = _usuarioService.LlenarViewModelDesdeBase(id);
            uvm.Validando = true;
            uvm.id = null;
            uvm.UsuarioMPBA = id!="nada";
            LoginDomain ld=new LoginDomain();
            string usuarioDominio = ld.getCommonName(id);

            if (usuarioDominio != "***")
            {
               uvm.Apellido = usuarioDominio.Substring(usuarioDominio.LastIndexOf(' ') + 1);
                uvm.Nombre = usuarioDominio.Substring(0, usuarioDominio.LastIndexOf(' '));
                uvm.Email = id + "@MPBA.GOV.AR";
            }
            return View("AltaModificacionUsuario",uvm);
        }

        public ActionResult Index()
        {
            var Usuarios = _repository.Set<ISIC.Entities.Usuarios>().ToList();
            return View(Usuarios);
        }

        public bool ReenviarToken(string id = "")
        {
            ISIC.Entities.Usuarios u = _repository.Set<ISIC.Entities.Usuarios>().SingleOrDefault(x => x.id == id);
            bool envioCorrecto = false;
            if (u != null)
            {
                Guid token = Guid.NewGuid();
                u.TokenEnviado = token;
                _repository.UnitOfWork.RegisterChanged(u);
                try
                {
                    _repository.UnitOfWork.Commit();
                    EnviarMail(id,token);
                    envioCorrecto = true;
                }
                catch
                {
                    
                }
            }
            return envioCorrecto;
        }

        public ActionResult ConfirmarEmail(string id, string t)
        {
            return View();
        }

       

        public bool EnviarMail(string usuario,Guid token)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("gberlasso@mpba.gov.ar");
            msg.To.Add(new MailAddress("berlasso@hotmail.com"));
            msg.Subject = "Registracion en ISIC";
            UrlHelper u = new UrlHelper(this.ControllerContext.RequestContext);
            string url = u.Action("ConfirmarEmail", "Usuarios", "Usuarios")+@"?id=\"+usuario+"&t="+token;
            string text = string.Format("Please click on this link to {0}: {1}", msg.Subject, msg.Body);
            string html = "Por favor, confirme la cuenta haciendo click aqui: <a class='btn' href=\"" +  url + "\">Confirmar Registracion</a><br/>";

            //html += HttpUtility.HtmlEncode(@"Or click on the copy the following link on the browser:" + msg.Body);
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));
            SmtpClient smtpClient = new SmtpClient("smtp.mpba.gov.ar");
            smtpClient.Send(msg);
            return true;
        }

        [HttpPost]
        public ActionResult GuardarDatosUsuario(UsuarioViewModel u)
        {
            string errores = "";

            if (u.Sexo.Id==0)
            {
                ModelState.AddModelError("", "Debe indicar el sexo");
            }
            if (u.PuntoGestion==null || string.IsNullOrEmpty(u.PuntoGestion.Id))
            {
                ModelState.AddModelError("", "Debe indicar el Punto de Gestion");
            }
            if (u.Departamento == null)
            {
                ModelState.AddModelError("", "Debe indicar el Departamento");
            }
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