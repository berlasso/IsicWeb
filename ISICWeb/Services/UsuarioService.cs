using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Glimpse.AspNet.Tab;
using ISIC.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using ISICWeb.Areas.Antecedentes.Models;
using ISICWeb.Areas.Usuarios.Models;
using ISICWeb.Models;
using Microsoft.AspNet.Identity;
using MPBA.DataAccess;

namespace ISICWeb.Services
{
    public class UsuarioService
    {
        private IRepository _repository;
        private ApplicationUserManager _userManager;


        public UsuarioService(IRepository repository, ApplicationUserManager userManager)
        {
            _repository = repository;
            _userManager = userManager;

        }

        public bool BorrarUsuario(string id)
        {
            try
            {
                Usuarios usuario = _repository.Set<Usuarios>().Single(x => x.id == id.ToString());
                usuario.activo = false;
                _repository.UnitOfWork.RegisterChanged(usuario);
                _repository.UnitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Register(RegisterViewModel model)
        //{
           
        //        var user = new ApplicationUser() { UserName = model.Email, Email = model.Email, };
        //        IdentityResult result = await UserManager.CreateAsync(user, model.Password);
        //        if (result.Succeeded)
        //        {
        //            await SignInAsync(user, isPersistent: false);
        //            var userProp = TraerPropiedades(model.Email);
        //            /////////////////////////////////////////////////


        //            user.idPuntoGestion = userProp["idPuntoGestion"];
        //            user.subCodBarra = userProp["subCodBarra"];
              
        //            string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
        //            var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
        //            await UserManager.SendEmailAsync(user.Id, "Confirmar cuenta", "Para confirmar la cuenta, haga clic <a href=\"" + callbackUrl + "\">aquí</a>");

        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            AddErrors(result);
        //        }
        //    }

        //    // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
        //    return View(model);
        //}




        public string GuardarUsuario(UsuarioViewModel model)
        {
            string errores = "";
            model.id = model.NombreUsuario;
            Usuarios usuario = _repository.Set<Usuarios>().SingleOrDefault(x => x.id == model.id.ToString());
            PuntoGestion pg = null;
            if (model.UsuarioMPBA)
            {
                pg = _repository.Set<PuntoGestion>().SingleOrDefault(x => x.Id == model.PuntoGestion.Id);
            }
            else
            {
                pg = _repository.Set<PuntoGestion>().SingleOrDefault(x => x.Id == "00000000000000");//No Especifica
            }
            if (usuario == null)
            {
                int temp;
                int ppjid = _repository.Set<PersonalPoderJudicial>().Select(x => x.Id).ToList().Select(n => int.TryParse(n, out temp) ? temp : 0).Max()+1;
                usuario = new Usuarios
                {
                    FechaCreacion = DateTime.Now,

                    PersonalPoderJudicial = new PersonalPoderJudicial
                    {
                        Id =ppjid.ToString(),
                        Persona = new Persona(),
                        PuntoGestion =pg

                    }
                };
            }
            else
            {
                usuario.PersonalPoderJudicial.PuntoGestion =pg;

            }

            if (usuario.PersonalPoderJudicial.Persona.EMail != model.Email)
            {
                bool emailExistente = _repository.Set<Persona>().Any(x => x.EMail == model.Email);
                if (emailExistente)
                {
                    errores = "El email consignado ya existe en la base de datos";
                    return errores;

                }
                else
                {
                    usuario.PersonalPoderJudicial.Persona.EMail = model.Email;        
                }
            }




            //usuario.ClaveUsuario = u.ClaveUsuario;
            if ( model.UsuarioMPBA == false && model.Validando)
            {
                usuario.ClaveUsuario = Crypto.HashPassword(model.ClaveUsuario);
            }
            usuario.UsuarioSicViejo = model.UsuarioSicViejo;
            usuario.PersonalPoderJudicial.Persona.Apellido = model.Apellido;
            usuario.PersonalPoderJudicial.Persona.Nombre = model.Nombre;
            usuario.PersonalPoderJudicial.Persona.DocumentoNumero = model.DocumentoNumero;
            usuario.PersonalPoderJudicial.Persona.FechaAlta = DateTime.Now;
            usuario.PersonalPoderJudicial.Persona.FechaUltimaModificacion = DateTime.Now;
            usuario.PersonalPoderJudicial.Persona.Sexo = _repository.Set<ClaseSexo>().Single(x => x.Id == model.Sexo.Id);
            usuario.PersonalPoderJudicial.JerarquiaPoderJudicial = _repository.Set<JerarquiaPoderJudicial>().Single(x => x.Id == model.Jerarquia.Id);
            if (model.GrupoUsuario!=null)
                usuario.GrupoUsuario = _repository.Set<GrupoUsuario>().SingleOrDefault(x => x.id == model.GrupoUsuario.id);
            else
            {
                usuario.GrupoUsuario = _repository.Set<GrupoUsuario>().SingleOrDefault(x => x.id == 5);//todos los delitos/personas
            }
            usuario.NombreUsuario = model.NombreUsuario;
            usuario.activo = model.activo;
            if (model.activo)
                usuario.TokenEnviado = null;
            usuario.FechaModificacion = DateTime.Now;
            usuario.Dependencia = model.Dependencia;
            usuario.SubCodBarra = model.SubCodBarra;
            usuario.UsuarioMPBA = model.UsuarioMPBA;
            if (!string.IsNullOrEmpty(usuario.id))
            {
                _repository.UnitOfWork.RegisterChanged(usuario);
            }
            else
            {
                usuario.id = model.id;
                _repository.UnitOfWork.RegisterNew(usuario);
            }

            try
            {
                _repository.UnitOfWork.Commit();
            }
            catch (Exception e)
            {
                errores = e.InnerException == null ? "Error al guardar. " + e.Message : e.InnerException.ToString().Substring(0, 400);
            }
            return errores;

        }


        public UsuarioViewModel LlenarViewModelDesdeBase(string id, string depto="")
        {
            Usuarios usuario = _repository.Set<Usuarios>().SingleOrDefault(x => x.id == id);
            UsuarioViewModel uvm = new UsuarioViewModel();
            uvm.UsuarioMPBA = true;
            uvm.GrupoUsuarioList = new SelectList(_repository.Set<GrupoUsuario>().ToList(), "id", "Descripcion");
            uvm.JerarquiaList = new SelectList(_repository.Set<JerarquiaPoderJudicial>().ToList().OrderBy(x=>x.Descripcion), "id", "Descripcion");
            uvm.SexoList = new SelectList(_repository.Set<ClaseSexo>().ToList(), "Id", "Descripcion");
            uvm.DepartamentoList = new SelectList(_repository.Set<Departamento>().ToList(), "Id", "DepartamentoNombre");
            uvm.id = id;
            uvm.NombreUsuario = id;
            
            if (usuario != null)
            {

                uvm.ClaveUsuario = usuario.ClaveUsuario;
                uvm.NombreUsuario = usuario.NombreUsuario;
                uvm.TokenEnviado = usuario.TokenEnviado;
                uvm.SubCodBarra = usuario.SubCodBarra;
                if (usuario.PersonalPoderJudicial != null && usuario.PersonalPoderJudicial.Persona != null && usuario.PersonalPoderJudicial.Persona.Sexo!=null)
                    uvm.Sexo =_repository.Set<ClaseSexo>().SingleOrDefault(x => x.Id == usuario.PersonalPoderJudicial.Persona.Sexo.Id);
                if (usuario.PersonalPoderJudicial != null && usuario.PersonalPoderJudicial.JerarquiaPoderJudicial != null)
                    uvm.Jerarquia = _repository.Set<JerarquiaPoderJudicial>().SingleOrDefault(x => x.Id == usuario.PersonalPoderJudicial.JerarquiaPoderJudicial.Id);
                if (usuario.PersonalPoderJudicial!=null && usuario.PersonalPoderJudicial.PuntoGestion!=null)
                    uvm.PuntoGestion =_repository.Set<PuntoGestion>().SingleOrDefault(x => x.Id == usuario.PersonalPoderJudicial.PuntoGestion.Id);
                if (usuario.PersonalPoderJudicial != null && usuario.PersonalPoderJudicial.PuntoGestion != null && usuario.PersonalPoderJudicial.PuntoGestion.Departamento!=null)
                    uvm.Departamento =_repository.Set<Departamento>().SingleOrDefault(x => x.Id == usuario.PersonalPoderJudicial.PuntoGestion.Departamento.Id);
                uvm.activo = usuario.activo;
                uvm.Dependencia = usuario.Dependencia;
                uvm.GrupoUsuario = usuario.GrupoUsuario;
                uvm.UsuarioMPBA = usuario.UsuarioMPBA ?? true;
                
            }
            else
            {
                uvm.Jerarquia = _repository.Set<JerarquiaPoderJudicial>().SingleOrDefault(x => x.Id == 3);//No especifica
                uvm.Departamento = _repository.Set<Departamento>().SingleOrDefault(x => x.Id.ToString() == depto);
            }
            if (usuario != null && usuario.id != "" && usuario.PersonalPoderJudicial != null && usuario.PersonalPoderJudicial.Persona != null)
            {
                uvm.DocumentoNumero = usuario.PersonalPoderJudicial.Persona.DocumentoNumero;
                uvm.Email = usuario.PersonalPoderJudicial.Persona.EMail;
                uvm.Apellido = usuario.PersonalPoderJudicial.Persona.Apellido;
                uvm.Nombre = usuario.PersonalPoderJudicial.Persona.Nombre;

            }
            return uvm;
        }
    }
}