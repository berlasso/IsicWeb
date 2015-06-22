using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISIC.Entities;
using ISICWeb.Areas.Afis.Models;
using MPBA.DataAccess;

namespace ISICWeb.Services
{
    public class AfisService
    {
        private IRepository _repository;


        public AfisService(IRepository repository)
        {
            _repository = repository;

        }

        public bool BorrarFichaAFIS(int id)
        {
            try
            {
                AFIS afis = _repository.Set<AFIS>().Single(x => x.Id == id);
                afis.Baja = true;
                _repository.UnitOfWork.RegisterChanged(afis);
                _repository.UnitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public string GuardarFichaAFIS(AFISViewModel model)
        {
            string errores = "";
            string prontuariosic = model.Prontuario.ProntuarioNro;
            Prontuario prontuario = _repository.Set<Prontuario>().FirstOrDefault(x => x.ProntuarioNro == prontuariosic);
            AFIS afis = _repository.Set<AFIS>().SingleOrDefault(x => x.Id == model.Id);
            if (afis==null)
            {
                afis = new AFIS{FechaCreacion = DateTime.Now,};
            }
          
            if (prontuario == null)
            {
                prontuario = new Prontuario{ProntuarioNro = prontuariosic};
            }
            afis.NIF = model.NIF;
            afis.DNI = model.DNI;
            afis.Prontuario = prontuario;
            afis.Apellido = model.Apellido;
            afis.Nombre = model.Nombre;
            afis.CTL = model.CTL;
            afis.Clase = model.Clase;
            afis.FechaUltimaModificacion = DateTime.Now;
            afis.Sexo = _repository.Set<ClaseSexo>().Single(x => x.Id.ToString() == model.idClaseSexo);
            afis.TipoDNI = _repository.Set<ClaseTipoDNI>().Single(x => x.Id.ToString() == model.idTipoDoc);
            
            if (model.Id == 0)
            {
                _repository.UnitOfWork.RegisterNew(afis);
            }
            else
            {
                _repository.UnitOfWork.RegisterChanged(afis);
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


        public AFISViewModel LlenarViewModelDesdeBase(string prontuariosic, int idAfis)
        {
            AFIS afis = _repository.Set<AFIS>().SingleOrDefault(x => x.Id == idAfis);
            if (afis==null)afis=new AFIS();
            AFISViewModel model = new AFISViewModel();
            model.Id = idAfis;
            model.idClaseSexo = afis.Sexo == null ? "0" : afis.Sexo.Id.ToString();
            model.idTipoDoc = afis.TipoDNI == null ? "0" : afis.TipoDNI.Id.ToString();
            model.Nombre = afis.Nombre;
            model.Apellido = afis.Apellido;
            Prontuario prontuario = _repository.Set<Prontuario>().SingleOrDefault(x => x.ProntuarioNro == prontuariosic);

            if (prontuario == null)
            {
                prontuario = new Prontuario {ProntuarioNro = prontuariosic};
            };
            model.NIF = afis.NIF;
            model.Prontuario = prontuario;
            model.CTL = afis.CTL;
            model.Clase = afis.Clase;
            model.DNI = afis.DNI;
            model.SexoList = new SelectList(_repository.Set<ClaseSexo>().ToList(), "Id", "descripcion");
            model.TipoDocList = new SelectList(_repository.Set<ClaseTipoDNI>().ToList(), "Id", "descripcion");
            return model;
        }
    }
}