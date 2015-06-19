using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISIC.Entities;

using ISICWeb.Areas.Antecedentes.Models;
using ISICWeb.Areas.Usuarios.Models;
using MPBA.DataAccess;

namespace ISICWeb.Services
{
    public class UsuarioService
    {
        private IRepository _repository;


        public UsuarioService(IRepository repository)
        {
            _repository = repository;

        }

        public bool BorrarUsuario(int id)
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

        public string GuardarUsuario(UsuarioViewModel model)
        {
            string errores = "";
           
            Usuarios usuario = _repository.Set<Usuarios>().Single(x => x.id == model.id.ToString());
            if (usuario ==null)
            {
                usuario = new Usuarios
                {
                    FechaCreacion = DateTime.Now,
                    PersonalPoderJudicial = new PersonalPoderJudicial{
                        Persona = new Persona
                        {
                            
                        },
                        PuntoGestion = _repository.Set<PuntoGestion>().SingleOrDefault(x=>x.Id==model.PuntoGestion.Id)
                        
                    }
                };
            }
            {
                if (usuario.PersonalPoderJudicial.Persona.EMail != model.Email)
                {
                    bool emailExistente = _repository.Set<Persona>().Any(x => x.EMail == model.Email);
                    if (emailExistente)
                    {
                        errores = "El email consignado ya existe en la base de datos";
                        return errores;

                    }
                }
                
            }
           
            //usuario.ClaveUsuario = u.ClaveUsuario;

            usuario.PersonalPoderJudicial.Persona.Apellido = model.Apellido;
            usuario.PersonalPoderJudicial.Persona.DocumentoNumero = model.DocumentoNumero;
            usuario.PersonalPoderJudicial.Persona.FechaAlta = DateTime.Now;
            usuario.PersonalPoderJudicial.Persona.FechaUltimaModificacion = DateTime.Now;
            usuario.PersonalPoderJudicial.Persona.Sexo = model.Sexo;
            usuario.GrupoUsuario = _repository.Set<GrupoUsuario>().SingleOrDefault(x=>x.id==model.GrupoUsuario.id);
            usuario.NombreUsuario = model.NombreUsuario;
            usuario.activo = model.activo;
            usuario.FechaModificacion=DateTime.Now;
            usuario.Dependencia = model.Dependencia;
            usuario.SubCodBarra = model.SubCodBarra;

            if (usuario.id != "")
            {
                _repository.UnitOfWork.RegisterChanged(usuario);
            }
            else
            {
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


        public UsuarioViewModel LlenarViewModelDesdeBase(string id)
        {
            Usuarios usuario = _repository.Set<Usuarios>().SingleOrDefault(x => x.id == id);
            UsuarioViewModel uvm = new UsuarioViewModel();
            uvm.GrupoUsuarioList = new SelectList(_repository.Set<GrupoUsuario>().ToList(), "id", "Descripcion");
            uvm.SexoList = new SelectList(_repository.Set<ClaseSexo>().ToList(), "Id", "Descripcion");
            uvm.DepartamentoList = new SelectList(_repository.Set<Departamento>().ToList(), "Id", "DepartamentoNombre");
            if (usuario != null)
            {
                uvm.id = usuario.id;
                //  uvm.ClaveUsuario = usuario.ClaveUsuario;
                uvm.NombreUsuario = usuario.NombreUsuario;
                uvm.activo = usuario.activo;
                uvm.GrupoUsuario = usuario.GrupoUsuario;
                
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