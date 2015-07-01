using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.DirectoryServices;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ISIC.Entities;
using ISIC.Persistence.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using ISICWeb.Models;
using MPBA.DataAccess;
using MPBA.Security.Ldap;
using UsuarioViewModel = ISICWeb.Models.UsuarioViewModel;


namespace ISICWeb.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        private ApplicationUserManager _userManager;
        private IRepository _repository;

        public AccountController()
        {
        }


        public AccountController(IRepository repository)
        {
            _repository = repository;
        }

        public AccountController(IRepository repository, ApplicationUserManager userManager)
        {
            _userManager = userManager;
            _repository = repository;

        }

        public ActionResult Index(string depto = "")
        {
            //var Usuarios = _repository.Set<ISIC.Entities.Usuarios>().ToList();
            UsuarioViewModel uvm = new UsuarioViewModel
            {
                DepartamentoList = new SelectList(_repository.Set<Departamento>().ToList(), "Id", "DepartamentoNombre"),
                Departamento = depto != "" ? _repository.Set<Departamento>().SingleOrDefault(x => x.Id.ToString() == depto) : null
            };

            return View(uvm);
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindAsync(model.UserName, model.Password);

                if (user != null)
                {
                    
                    if (user.activo == false)
                        ModelState.AddModelError("", "El usuario se encuentra desactivado.");
                    else if (user.EmailConfirmed == false)
                        ModelState.AddModelError("", "El usuario no ha confirmado el email de verificación.");
                    else if (UserManager.IsLockedOut(user.Id))
                        ModelState.AddModelError("", "El usuario ha perdido autorizacion.");
                    else
                    {
                        await SignInAsync(user, model.RememberMe);
                        //Traigo el punto de gestion del usuario y el substring del codbarra con el cual puede operar en la consulta y carga 
                        //de legajos en la otip

                        var userProp = TraerPropiedades(model.UserName);
                        /////////////////////////////////////////////////


                        //user.idPuntoGestion = userProp["idPuntoGestion"];
                        //user.subCodBarra = userProp["subCodBarra"];

                        await UserManager.UpdateAsync(user);


                        return RedirectToLocal(returnUrl);
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Nombre de usuario o contraseña no válidos.");
                }
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }


        /// <summary>
        /// trae propiedades adicionales de la tabla Users
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private Dictionary<string, string> TraerPropiedades(string email)
        {
            ISICContext ctx = (ISICContext)_repository.UnitOfWork.Context;
            string usuario = Regex.Split(email, "@")[0];
            var pg = from u in ctx.Usuarios
                     join ppj in ctx.PersonalPoderJudicial
                         on u.PersonalPoderJudicial.Id equals ppj.Id
                     where u.NombreUsuario == usuario
                     select ppj.PuntoGestion.Id;
            string punto = pg.FirstOrDefault() ?? "";
            var subCodB = from s in ctx.ClaseCodBarraPuntoGestion
                          join p in ctx.PuntoGestion
                              on s.PuntoGestion.Id equals p.Id
                          where s.PuntoGestion.Id == punto
                          select s.SubCodBarra;
            string subCodBarra = subCodB.FirstOrDefault() ?? "";
            var dict = new Dictionary<string, string>();
            dict.Add("idPuntoGestion", punto);
            dict.Add("subCodBarra", subCodBarra);
            return dict;

        }




        //
        // GET: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> Registrar(bool RegistrandoUsuarioViejo = false, string userId = "", string code = "")
        {
            ViewBag.RegistrandoUsuarioViejo = RegistrandoUsuarioViejo;

            UsuarioViewModel uvm = await LlenarViewModelDesdeBase(userId);
            uvm.code = code;
            return View(uvm);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar(UsuarioViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            if (string.IsNullOrEmpty(model.ClaveUsuario))
            {
                ModelState.AddModelError("ClaveUsuario", "La contraseña es requerida");
                return View("Registrar", model);
            }
            ApplicationUser u = UserManager.FindById(model.id);
            //Usuarios u = _repository.Set<Usuarios>().Single(x => x.NombreUsuario == model.NombreUsuario);
            //u.TokenEnviado = !model.EmailConfirmed;
            u.activo = model.activo;
            u.EmailConfirmed = true;
            u.PasswordHash = Crypto.HashPassword(model.ClaveUsuario);
            //_repository.UnitOfWork.RegisterChanged(u);
            IdentityResult resultado = null;
            try
            {
                resultado = UserManager.Update(u);
                //_repository.UnitOfWork.Commit();
                if (resultado.Succeeded)
                {

                    RedirectToAction("ConfirmarEmail", new { userId = model.id, code = model.code });
                }
                ViewBag.Usuario = model.UserName;
                return View("ConfirmarEmail");
            }
            catch
            {
                return View("Error", null, "No se pudo guardar el alta.");
            }
            //}
            //else
            //{
            //    string errores = string.Join("; ", ModelState.Values
            //                          .SelectMany(x => x.Errors)
            //                          .Select(x => x.ErrorMessage));


            //    ModelState.AddModelError("", errores);
            //   return View("Register",model);
            //}
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = model.Email, Email = model.Email, };
                //IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                IdentityResult result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInAsync(user, isPersistent: false);
                    var userProp = TraerPropiedades(model.Email);
                    /////////////////////////////////////////////////


                    user.idPuntoGestion = userProp["idPuntoGestion"];
                    user.subCodBarra = userProp["subCodBarra"];
                    // Para obtener más información sobre cómo habilitar la confirmación de cuenta y el restablecimiento de contraseña, visite http://go.microsoft.com/fwlink/?LinkID=320771
                    // Enviar correo electrónico con este vínculo
                    string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmarEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    await UserManager.SendEmailAsync(user.Id, "Confirmar cuenta", "Para confirmar la cuenta, haga clic <a href=\"" + callbackUrl + "\">aquí</a>");

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    AddErrors(result);
                }
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            //return View(model);
            return null;
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmarEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }

            IdentityResult result = await UserManager.ConfirmEmailAsync(userId, code);
            if (result.Succeeded)
            {
                ApplicationUser u = await UserManager.FindByIdAsync(userId);
                u.activo = true;
                result = await UserManager.UpdateAsync(u);
                if (result.Succeeded)
                {
                    return View("ConfirmarEmail");
                }
                else
                {
                    AddErrors(result);
                    return View(false);
                }
            }
            else
            {
                AddErrors(result);
                return View(false);
            }
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.UserName);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    ModelState.AddModelError("", "El usuario no existe o no se ha confirmado.");
                    return View();
                }

                // Para obtener más información sobre cómo habilitar la confirmación de cuenta y el restablecimiento de contraseña, visite http://go.microsoft.com/fwlink/?LinkID=320771
                // Enviar correo electrónico con este vínculo
                string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                await UserManager.SendEmailAsync(user.Id, "Restablecer contraseña", "Para restablecer la contraseña, haga clic <a href=\"" + callbackUrl + "\">aquí</a>");
                return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            if (code == null)
            {
                return View("Error");
            }
            return View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "No se encontró ningún usuario.");
                    return View();
                }
                IdentityResult result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
                if (result.Succeeded)
                {
                    user.EmailConfirmed = true;
                    user.activo = true;
                    await UserManager.UpdateAsync(user);
                    return RedirectToAction("ResetPasswordConfirmation", "Account");
                }
                else
                {
                    AddErrors(result);
                    return View();
                }
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/Disassociate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Disassociate(string loginProvider, string providerKey)
        {
            ManageMessageId? message = null;
            IdentityResult result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                await SignInAsync(user, isPersistent: false);
                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageId.Error;
            }
            return RedirectToAction("Manage", new { Message = message });
        }
        [Authorize]
        //
        // GET: /Account/Manage
        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "La contraseña se ha cambiado."
                : message == ManageMessageId.SetPasswordSuccess ? "La contraseña se ha establecido."
                : message == ManageMessageId.RemoveLoginSuccess ? "El inicio de sesión externo se ha quitado."
                : message == ManageMessageId.Error ? "Se produjo un error."
                : "";
            ViewBag.HasLocalPassword = HasPassword();
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        // POST: /Account/Manage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Manage(ManageUserViewModel model)
        {
            bool hasPassword = HasPassword();
            ViewBag.HasLocalPassword = hasPassword;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasPassword)
            {
                if (ModelState.IsValid)
                {
                    IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                        await SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }
            else
            {
                // El usuario no tiene contraseña. Quite los errores de validación producidos porque falta un campo OldPassword
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    IdentityResult result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Solicitar redireccionamiento al proveedor de inicio de sesión externo
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Si el usuario ya tiene un inicio de sesión, iniciar sesión del usuario con este proveedor de inicio de sesión externo
            var user = await UserManager.FindAsync(loginInfo.Login);
            if (user != null)
            {
                await SignInAsync(user, isPersistent: false);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                // Si el usuario no tiene ninguna cuenta, solicitar que cree una
                ViewBag.ReturnUrl = returnUrl;
                ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Solicitar redirección a proveedor de inicio de sesión externo para vincular un inicio de sesión para el usuario actual
            return new ChallengeResult(provider, Url.Action("LinkLoginCallback", "Account"), User.Identity.GetUserId());
        }

        //
        // GET: /Account/LinkLoginCallback
        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return RedirectToAction("Manage", new { Message = ManageMessageId.Error });
            }
            IdentityResult result = await UserManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);
            if (result.Succeeded)
            {
                return RedirectToAction("Manage");
            }
            return RedirectToAction("Manage", new { Message = ManageMessageId.Error });
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Manage");
            }

            if (ModelState.IsValid)
            {
                // Obtener datos del usuario del proveedor de inicio de sesión externo
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };
                IdentityResult result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInAsync(user, isPersistent: false);

                        // Para obtener más información sobre cómo habilitar la confirmación de la cuenta y el restablecimiento de la contraseña, visite http://go.microsoft.com/fwlink/?LinkID=320771
                        // Enviar un correo electrónico con este vínculo
                        //string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                        // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                        // SendEmail(user.Email, callbackUrl, "Confirmar cuenta", "Haga clic en este vínculo para confirmar la cuenta");

                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult RemoveAccountList()
        {
            var linkedAccounts = UserManager.GetLogins(User.Identity.GetUserId());
            ViewBag.ShowRemoveButton = HasPassword() || linkedAccounts.Count > 1;
            return (ActionResult)PartialView("_RemoveAccountPartial", linkedAccounts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && UserManager != null)
            {
                UserManager.Dispose();
                UserManager = null;
            }
            base.Dispose(disposing);
        }

        #region Aplicaciones auxiliares
        // Se usa para la protección XSRF al agregar inicios de sesión externos
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, await user.GenerateUserIdentityAsync(UserManager));
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        private void SendEmail(string email, string callbackUrl, string subject, string message)
        {
            // Para obtener información para enviar correo, visite http://go.microsoft.com/fwlink/?LinkID=320771
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }


        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties() { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion


        /// <summary>
        /// Completa registracion el en el isic habiendo estado registrado en el sic viejo
        /// </summary>
        /// <param name="us">usuario en el sic viejo</param>
        /// <param name="ui">usuario para el isic</param>
        /// <returns></returns>
        public async Task<ViewResult> CompletarDatosSicNuevo(string us, string ui = "nada")
        {
            UsuarioViewModel uvm = await LlenarViewModelDesdeBase(ui);
            uvm.Validando = true;
            uvm.id = null;
            uvm.UsuarioSicViejo = us;
            uvm.UsuarioMPBA = ui != "nada";
            LoginDomain ld = new LoginDomain();
            string usuarioDominio = ld.getCommonName(ui);

            if (usuarioDominio != "***")
            {
                uvm.Apellido = usuarioDominio.Substring(usuarioDominio.LastIndexOf(' ') + 1);
                uvm.Nombre = usuarioDominio.Substring(0, usuarioDominio.LastIndexOf(' '));
                uvm.Email = ui + "@MPBA.GOV.AR";
            }
            if (ui == "nada")
                uvm.UserName = "";
            return View("AltaModificacionUsuario", uvm);
        }

        /// <summary>
        /// valida los datos en el sic nuevo
        /// </summary>
        /// <param name="us">usuario en el sic viejo</param>
        /// <param name="id">si es usuario mpba(1) o externo(2)</param>
        /// <returns></returns>
        public ActionResult ValidarLoginSicNuevo(string us, int id = 0)
        {
            ViewBag.us = us;
            if (id == 1)
            {

                return View();
            }

            else if (id == 2)
            {
                //  return RedirectToAction("Register",new {RegistrandoUsuarioViejo=true});
                return RedirectToAction("CompletarDatosSicNuevo",new {us});
            }
            return null;
        }

        public ActionResult ValidarLoginSicViejo()
        {
            return View();
        }

        public ActionResult SeleccionDominio(string id)
        {
            return View("DominioUsuario", null, id);
        }

        [HttpPost]
        public ActionResult ControlarUsuarioSic(UsuarioIsicViewModel u)
        {
            // return null;
            string perfil = "";
            string errores = "";
            if (ModelState.IsValid)
            {
                wsSIC.Services ws = new wsSIC.Services();
                perfil = ws.PerfilUsuario(u.usuario, u.clave);
                if (perfil == "")
                {
                    errores = "No se encontró el usuario";
                }
                else
                {
                   if(UserManager.Users.Any(x=>x.UsuarioSicViejo==u.usuario))
                    {
                        errores = "Usuario SIC ya existente en el sistema nuevo";
                    }
                }
            }
            else
            {
                return PartialView("_SummaryErrorSic");
            }

            if (errores != "")
            {
                ModelState.AddModelError("", errores);
                return PartialView("_SummaryErrorSic");
            }
            return null;
        }

        [HttpPost]
        public ActionResult ControlarUsuarioIsic(UsuarioIsicViewModel u)
        {
            //       return null;
            string errores = "";
            if (ModelState.IsValid)
            {
                var loginDomain = new LoginDomain();
                try
                {
                    bool validado = loginDomain.CheckLogin(u.usuario, u.clave);
                    if (!validado)
                        errores = "No se encontró el usuario y/o contraseña indicados";
                }
                catch
                {
                    errores = "No se pudo conectar al servidor remoto";
                }


            }
            else
            {
                errores = string.Join("; ", ModelState.Values
                                          .SelectMany(x => x.Errors)
                                          .Select(x => x.ErrorMessage));
            }

            if (errores == "")
            {
                string usic = u.usuario.Trim().ToLower();
                bool existente = UserManager.Users.Any(x => x.UserName.ToLower()==usic);
                if (existente)
                    errores = "El usuario ya existe en la base del Isic";

            }

            if (errores != "")
            {
                ModelState.AddModelError("", errores);
                return PartialView("_SummaryErrorSic");
            }
            return null;
        }

        [Authorize]
        public async Task<ViewResult> AltaModificacionUsuario(string depto = "", string id = "")
        {
            UsuarioViewModel uvm = await LlenarViewModelDesdeBase(id, depto);

            return View(uvm);
        }



        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> GuardarDatosUsuario(UsuarioViewModel model)
        {
            string errores = "";

            if (model.Sexo.Id == 0)
            {
                ModelState.AddModelError("Sexo", "Debe indicar el sexo");
            }
            if (model.UsuarioMPBA)
            {
                if (model.PuntoGestion == null || string.IsNullOrEmpty(model.PuntoGestion.Id))
                {
                    ModelState.AddModelError("", "Debe indicar el Punto de Gestion");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(model.Dependencia))
                {
                    ModelState.AddModelError("Dependencia", "Debe indicar la dependencia");
                }
            }
            if (model.Departamento == null)
            {
                ModelState.AddModelError("", "Debe indicar el Departamento");
            }


            if (ModelState.IsValid)
            {
                PuntoGestion pg;
                if (model.UsuarioMPBA)
                {
                    pg = _repository.Set<PuntoGestion>().SingleOrDefault(x => x.Id == model.PuntoGestion.Id);
                }
                else
                {
                    pg = _repository.Set<PuntoGestion>().SingleOrDefault(x => x.Id == "00000000000000");//No Especifica
                }
                PersonalPoderJudicial ppj = null;
                ApplicationUser usuario = await UserManager.FindByIdAsync(model.id);
                if (model.Jerarquia.Id == 0)
                    model.Jerarquia.Id = 3;//no especifica
                if (usuario == null)
                {
                    int temp;
                    int ppjid = _repository.Set<PersonalPoderJudicial>().Select(x => x.Id).ToList().Select(n => int.TryParse(n, out temp) ? temp : 0).Max() + 1;
                    ppj = new PersonalPoderJudicial
                    {
                        Id = ppjid.ToString(),
                        JerarquiaPoderJudicial = _repository.Set<JerarquiaPoderJudicial>().Single(x=>x.Id==model.Jerarquia.Id), //no especifica
                        Persona = new Persona
                        {
                            DocumentoNumero = model.DocumentoNumero,
                            Apellido = model.Apellido,
                            Nombre = model.Nombre,
                            EMail = model.Email,
                            FechaCreacion = DateTime.Now,
                            FechaAlta = DateTime.Now,
                            FechaUltimaModificacion = DateTime.Now,
                            Sexo = _repository.Set<ClaseSexo>().SingleOrDefault(x => x.Id == model.Sexo.Id),
                        },
                        PuntoGestion = pg
                    };
                    _repository.UnitOfWork.RegisterNew(ppj);
                    _repository.UnitOfWork.Commit();
                    usuario = new ApplicationUser
                    {
                        FechaCreacion = DateTime.Now,


                    };
                }
                else
                {
                    ppj = _repository.Set<PersonalPoderJudicial>().SingleOrDefault(x => x.Id == usuario.idPersonalPoderJudicial);
                    if (ppj != null)
                    {
                        ppj.PuntoGestion = pg;
                        ppj.JerarquiaPoderJudicial = _repository.Set<JerarquiaPoderJudicial>().SingleOrDefault(x => x.Id == model.Jerarquia.Id);
                        ppj.Persona.EMail = model.Email;
                        ppj.Persona.Apellido = model.Apellido;
                        ppj.Persona.Nombre = model.Nombre;
                        ppj.Persona.DocumentoNumero = model.DocumentoNumero;
                        ppj.Persona.FechaUltimaModificacion = DateTime.Now;
                        ppj.Persona.Sexo = _repository.Set<ClaseSexo>().SingleOrDefault(x => x.Id == model.Sexo.Id);
                        _repository.UnitOfWork.RegisterChanged(ppj);
                        _repository.UnitOfWork.Commit();
                    }
                }

                if (string.IsNullOrEmpty(model.ClaveUsuario))
                    usuario.PasswordHash = null;
                else
                {
                    usuario.PasswordHash = Crypto.HashPassword(model.ClaveUsuario);
                
                }
                
                usuario.UsuarioSicViejo = model.UsuarioSicViejo;
                usuario.idPersonalPoderJudicial = ppj.Id;
                usuario.UserName = model.UserName;
                usuario.Email = model.Email;
                usuario.Dependencia = model.Dependencia;
                //usuario.FechaCreacion = DateTime.Now;
                usuario.UsuarioMPBA = model.UsuarioMPBA;
                usuario.idPuntoGestion = pg.Id;
                usuario.subCodBarra = model.SubCodBarra;

                IdentityResult result = null;
                bool usuarioNuevo = model.id == null;
                if (usuarioNuevo)
                {
                    result = UserManager.Create(usuario);
                    //result = await UserManager.CreateAsync(usuario, _repository);
                }
                else
                {
                    result = await UserManager.UpdateAsync(usuario);
                }
                if (result.Succeeded)
                {
                    //await SignInAsync(user, isPersistent: false);
                    //var userProp = TraerPropiedades(model.Email);
                    /////////////////////////////////////////////////

                    if (usuarioNuevo)
                    {
                        errores = await ReenviarToken(usuario.Id);

                    }
                    //user.idPuntoGestion = userProp["idPuntoGestion"];
                    //user.subCodBarra = userProp["subCodBarra"];
                    // Para obtener más información sobre cómo habilitar la confirmación de cuenta y el restablecimiento de contraseña, visite http://go.microsoft.com/fwlink/?LinkID=320771
                    // Enviar correo electrónico con este vínculo
                    //string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    //await UserManager.SendEmailAsync(user.Id, "Confirmar cuenta", "Para confirmar la cuenta, haga clic <a href=\"" + callbackUrl + "\">aquí</a>");

                    return Content(errores);
                    //return textre;
                }
                else
                {
                    AddErrors(result);
                    _repository.UnitOfWork.RegisterDeleted(ppj);
                    _repository.UnitOfWork.Commit();
                    //  return Content("error");
                }
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            //return View(model);
            return PartialView("_SummaryErrorUsuario", model);
        }

        public async Task<UsuarioViewModel> LlenarViewModelDesdeBase(string id, string depto = "")
        {
            //Usuarios usuario = _repository.Set<Usuarios>().SingleOrDefault(x => x.id == id);
            ApplicationUser usuario = await UserManager.FindByIdAsync(id);
            UsuarioViewModel uvm = new UsuarioViewModel
            {
                UsuarioMPBA = true,
                GrupoUsuarioList = new SelectList(_repository.Set<GrupoUsuario>().ToList(), "id", "Descripcion"),
                JerarquiaList = new SelectList(_repository.Set<JerarquiaPoderJudicial>().ToList().OrderBy(x => x.Descripcion), "id", "Descripcion"),
                SexoList = new SelectList(_repository.Set<ClaseSexo>().ToList(), "Id", "Descripcion"),
                DepartamentoList = new SelectList(_repository.Set<Departamento>().ToList(), "Id", "DepartamentoNombre"),
                id = (usuario!=null?usuario.Id:""),
                UserName = id
            };

            if (usuario != null)
            {

                uvm.ClaveUsuario = usuario.PasswordHash;
                uvm.UserName = usuario.UserName;
                uvm.EmailConfirmed = usuario.EmailConfirmed;
                //uvm.TokenEnviado = usuario.TokenEnviado;
                uvm.SubCodBarra = usuario.subCodBarra;
                uvm.Email = usuario.Email;
                if (usuario.idPersonalPoderJudicial != null)
                {
                    PersonalPoderJudicial ppj = _repository.Set<PersonalPoderJudicial>().SingleOrDefault(x => x.Id == usuario.idPersonalPoderJudicial);
                    if (ppj != null && ppj.Persona != null && ppj.Persona.Sexo != null)
                        uvm.Sexo = _repository.Set<ClaseSexo>().SingleOrDefault(x => x.Id == ppj.Persona.Sexo.Id);
                    if (ppj != null && ppj.JerarquiaPoderJudicial != null)
                        uvm.Jerarquia = _repository.Set<JerarquiaPoderJudicial>().SingleOrDefault(x => x.Id == ppj.JerarquiaPoderJudicial.Id);
                    if (ppj != null && ppj.PuntoGestion != null)
                        uvm.PuntoGestion = _repository.Set<PuntoGestion>().SingleOrDefault(x => x.Id == ppj.PuntoGestion.Id);
                    if (ppj != null && ppj.PuntoGestion != null && ppj.PuntoGestion.Departamento != null)
                        uvm.Departamento = _repository.Set<Departamento>().SingleOrDefault(x => x.Id == ppj.PuntoGestion.Departamento.Id);
                    if (ppj != null && ppj.Persona != null)
                    {
                        uvm.DocumentoNumero = ppj.Persona.DocumentoNumero;
                        uvm.Nombre = ppj.Persona.Nombre;
                        uvm.Apellido = ppj.Persona.Apellido;

                    }
                }
                uvm.activo = usuario.activo;
                uvm.Dependencia = usuario.Dependencia;
                if (usuario.idGrupoUsuario != null)
                    uvm.GrupoUsuario = _repository.Set<GrupoUsuario>().SingleOrDefault(x => x.id == usuario.idGrupoUsuario);
                uvm.UsuarioMPBA = usuario.UsuarioMPBA ?? true;

            }
            else
            {
                uvm.Jerarquia = _repository.Set<JerarquiaPoderJudicial>().SingleOrDefault(x => x.Id == 3);//No especifica
                uvm.Departamento = _repository.Set<Departamento>().SingleOrDefault(x => x.Id.ToString() == depto);
            }

            return uvm;
        }

        public async Task<string> ReenviarToken(string uid = "")
        {
            ApplicationUser u = await UserManager.FindByIdAsync(uid);
            //ApplicationUser u =await UserManager.FindByIdExtendido(uid, _repository);
            string errores = "";
            if (u != null)
            {
                string code = await UserManager.GenerateEmailConfirmationTokenAsync(uid);

                string callbackUrl = "";
                if (u.UsuarioMPBA == true)
                    callbackUrl = Url.Action("ConfirmarEmail", "Account", new { userId = uid, code = code }, protocol: Request.Url.Scheme);
                else
                {
                    //callbackUrl = Url.Action("Registrar", "Account", new { userId = uid, code = code }, protocol: Request.Url.Scheme);
                    code = await UserManager.GeneratePasswordResetTokenAsync(uid);
                    callbackUrl = Url.Action("ResetPassword", "Account", new { userId = uid, code = code }, protocol: Request.Url.Scheme);
                }
                try
                {
                    u.EmailConfirmed = false;
                    errores = EnviarMail(u, callbackUrl);
                    IdentityResult result = await UserManager.UpdateAsync(u);
                    if (result == IdentityResult.Failed())
                    {
                        errores += "No se pudo desmarcar emailconfirmed";
                    }
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


        public string EnviarMail(ApplicationUser u, string callbackUrl)
        {
            string errores = "";
            PersonalPoderJudicial ppj =
                _repository.Set<PersonalPoderJudicial>().SingleOrDefault(x => x.Id == u.idPersonalPoderJudicial);
            var email = new VerificacionEmail
            {
                Sexo = ppj.Persona.Sexo.Id,
                Apellido = ppj.Persona.Apellido,
                Nombre = ppj.Persona.Nombre,
                //Email = u.PersonalPoderJudicial.Persona.EMail,
                //Token = u.TokenEnviado,
                Departamento = ppj.PuntoGestion.Departamento.DepartamentoNombre,
                Email = u.Email,
                Subject = "Verificacion Cuenta ISIC",
                NombreUsuario = u.UserName,
                UsuarioMPBA = u.UsuarioMPBA,
                Link = callbackUrl,
                Dependencia = string.IsNullOrEmpty(u.Dependencia) ? ppj.PuntoGestion.Descripcion : u.Dependencia
            };

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


        public async Task<bool> BorrarUsuario(string id)
        {
            try
            {
                ApplicationUser u = await UserManager.FindByIdAsync(id);
                u.activo = false;
                IdentityResult resultado = await UserManager.UpdateAsync(u);
                
                return resultado.Succeeded;
            }
            catch (Exception)
            {
                return false;
            }

        }


        [HttpPost]
        public ActionResult Buscar(UsuarioViewModel model)
        {
            var ctx = new ApplicationDbContext();

            IEnumerable<ApplicationUser> usuarios = null;
            switch (model.Departamento.Id)
            {
                case 0: //todos
                    usuarios = UserManager.Users.ToList();
                    break;
                case 22: // fuera mpba
                    usuarios = UserManager.Users.Where(x => x.Dependencia != null && x.Dependencia != "");
                    break;
                default:
                    usuarios = UserManager.Users.Where(x => x.idPersonalPoderJudicial != null && x.idPuntoGestion != null);

                    break;
            }
            var lista = (from u in usuarios
                         from p in _repository.Set<PersonalPoderJudicial>().Where(x => x.Id == u.idPersonalPoderJudicial)
                         select new UsuarioViewModel
                         {
                             id = u.Id,
                             Apellido = p.Persona.Apellido,
                             UserName = u.UserName,
                             PersonalPoderJudicial = p,
                             Dependencia = u.Dependencia,
                             Email = u.Email,
                             Nombre = p.Persona.Nombre,
                             PuntoGestion = p.PuntoGestion,
                             activo = u.activo,
                             EmailConfirmed = u.EmailConfirmed,
                             UsuarioMPBA = (u.UsuarioMPBA ?? false),
                         }
                );
            return PartialView("_ResultadosBusqueda", lista);
        }

        public async Task<RedirectToRouteResult> Prueba()
        {
            ApplicationUser user = await UserManager.FindByIdAsync("d4de5ab1-bc89-4965-93a8-746040fe5ce6");
            string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
            UserManager.VerifyUserToken("d4de5ab1-bc89-4965-93a8-746040fe5ce6", "email", "bla");
            UserManager.GenerateUserToken("email", "d4de5ab1-bc89-4965-93a8-746040fe5ce6");
            //  var callbackUrl = Url.Action("ConfirmarEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
            // EnviarMail(user, callbackUrl);
            return RedirectToAction("Index", "Home");
        }



        public JsonResult BuscarUsuarioMPBA(string u)
        {

            string apellido = "";
            string nombre = "";
            bool huboError = false;
            string errorMessage = "";
            var loginDomain = new LoginDomain();
            try
            {

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
            catch 
            {
                JsonResult json = new JsonResult
                {
                    Data = new
                    {
                        HuboError = true,
                        ErrorMessage = "Error: No se pudo conectar al servidor o usuario no encontrado",
                        Apellido = "",
                        Nombre = ""
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };

                return json;
            }
        }


        public JsonResult BuscarUsuariosMPBAPorApellido(string apellido)
        {

            string nombre = "";
            bool huboError = false;
            string errorMessage = "";
            ArrayList lista = new ArrayList();
            try
            {
                DirectoryEntry objRoot = new DirectoryEntry("LDAP://rootDSE");
                DirectoryEntry objUsers =
                    new DirectoryEntry("LDAP://" + (string) objRoot.Properties["defaultNamingContext"].Value);
                DirectorySearcher Filter1 = new DirectorySearcher(objUsers);

                Filter1.Filter = "(&(objectClass=user)(CN=*" + apellido + "*))";
                SearchResultCollection FilterResult1 = Filter1.FindAll();
                int cant = FilterResult1.Count;
                string usuarios = "";
                
                if (cant > 0)
                {
                    foreach (SearchResult iter in FilterResult1)
                    {
                        //TableRow row = new TableRow();

                        string usuario = (string) iter.GetDirectoryEntry().Properties["sAMAccountName"].Value;
                        string apenom = (string) iter.GetDirectoryEntry().Properties["CN"].Value;
                        if (apenom != "")
                        {
                            apellido = apenom.Substring(apenom.LastIndexOf(' ') + 1);
                            nombre = apenom.Substring(0, apenom.LastIndexOf(' '));
                        }
                        lista.Add(new {usuario = usuario, apellido = apellido, nombre = nombre});
                    }
                    
                }
                else
                {
                    lista.Add(new { usuario = "", apellido = "NO HAY RESULTADOS", nombre = "" });
                }
            }
            catch
            {
                lista.Add(new { usuario = "", apellido = "ERROR CON EL SERVIDOR", nombre = "" });
            }
            return Json(lista, JsonRequestBehavior.AllowGet);

     
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

        public ActionResult InfoRegistracion()
        {
            return View();
        }
    }


}