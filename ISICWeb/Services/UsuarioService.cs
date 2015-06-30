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

   
    }
}