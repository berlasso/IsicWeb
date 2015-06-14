using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ISIC.Entities;

using ISICWeb.Areas.Antecedentes.Models;
using MPBA.DataAccess;

namespace ISICWeb.Services
{
    public class MigracionesService
    {
        private IRepository _repository;


        public MigracionesService(IRepository repository)
        {
            _repository = repository;

        }

        public bool BorrarFichaMigraciones(int id)
        {
            try
            {
                Migraciones migraciones = _repository.Set<Migraciones>().Single(x => x.Id == id);
                migraciones.Baja = true;
                _repository.UnitOfWork.RegisterChanged(migraciones);
                _repository.UnitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public MigracionesViewModel LlenarViewModelDesdeBase(string prontuariosic, int idMigraciones)
        {
            Migraciones mig = _repository.Set<Migraciones>().SingleOrDefault(x => x.Id == idMigraciones);
            
            if (mig==null)mig=new Migraciones();
            MigracionesViewModel migracionesViewModel=new MigracionesViewModel();
            Mapper.CreateMap<Migraciones, MigracionesViewModel>();
            migracionesViewModel = Mapper.Map<MigracionesViewModel>(mig);
            Prontuario prontuario = _repository.Set<Prontuario>().SingleOrDefault(x => x.ProntuarioNro == prontuariosic);
            if (prontuario == null)
            {
                prontuario = new Prontuario { ProntuarioNro = prontuariosic };
            };
            migracionesViewModel.Prontuario = prontuario;
            migracionesViewModel.SexoList = new SelectList(_repository.Set<ClaseSexo>().ToList(), "Id", "descripcion");
            migracionesViewModel.ExpedienteList = new SelectList(_repository.Set<ClaseExpedienteMigraciones>().ToList(), "Id", "descripcion");
            migracionesViewModel.EstadoCivilList = new SelectList(_repository.Set<ClaseEstadoCivil>().ToList(), "Id", "descripcion");
            migracionesViewModel.TipoDocList = new SelectList(_repository.Set<ClaseTipoDNI>().ToList(), "Id", "descripcion");
            migracionesViewModel.PaisList = new SelectList(_repository.Set<Pais>().ToList(), "Id", "Nacionalidad");
            if (migracionesViewModel.Id == 0)
            {
                migracionesViewModel.LocalidadJusticia = _repository.Set<Localidad>().Single(x => x.Id == 0);
                migracionesViewModel.PaisEmbarque = _repository.Set<Pais>().Single(x => x.Id == 0);

            }

      
            //migracionesViewModel.GetType().GetProperties();
            return migracionesViewModel;
        }

        /// <summary>
        /// Convertidor de string a datetime? para el AutoMapper 
        /// </summary>
        private class StringToNullableDateTimeConverter : ITypeConverter<string, DateTime?>
        {
            public DateTime? Convert(ResolutionContext context)
            {
                if (String.IsNullOrEmpty(System.Convert.ToString(context.SourceValue)) || String.IsNullOrWhiteSpace(System.Convert.ToString(context.SourceValue)))
                {
                    return default(DateTime?);
                }
                else
                {
                    //return DateTime.Parse(context.SourceValue.ToString());
                    return DateTime.ParseExact(context.SourceValue.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
            }
        }

        public string GuardarFichaMigraciones(MigracionesViewModel model)
        {
            string errores = "";
            string prontuariosic = model.Prontuario.ProntuarioNro;
            Prontuario prontuario = _repository.Set<Prontuario>().FirstOrDefault(x => x.ProntuarioNro == prontuariosic);
            Migraciones mig = _repository.Set<Migraciones>().SingleOrDefault(x => x.Id == model.Id);
            if (mig == null)
            {
                mig = new Migraciones();;
            }

            if (prontuario == null)
            {
                prontuario = new Prontuario { ProntuarioNro = prontuariosic };
            }
            Mapper.CreateMap<string, DateTime?>().ConvertUsing(new StringToNullableDateTimeConverter());
            Mapper.CreateMap<MigracionesViewModel,Migraciones>();
            mig = Mapper.Map(model,mig);
            mig.Prontuario = prontuario;
            mig.FechaUltimaModificacion = DateTime.Now;
            mig.Sexo = _repository.Set<ClaseSexo>().Single(x => x.Id == model.Sexo.Id);
            mig.EstadoCivil = _repository.Set<ClaseEstadoCivil>().Single(x => x.Id == model.EstadoCivil.Id);
            mig.ExpedienteMigraciones = _repository.Set<ClaseExpedienteMigraciones>().Single(x => x.Id == model.ExpedienteMigraciones.Id);
            mig.TipoDNI = _repository.Set<ClaseTipoDNI>().Single(x => x.Id == model.TipoDNI.Id);
            mig.PaisEmbarque = _repository.Set<Pais>().Single(x => x.Id == model.PaisEmbarque.Id);
            mig.LocalidadJusticia = _repository.Set<Localidad>().Single(x => x.Id == model.LocalidadJusticia.Id);

            if (model.Id == 0)
            {
                _repository.UnitOfWork.RegisterNew(mig);
            }
            else
            {
                _repository.UnitOfWork.RegisterChanged(mig);
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
    }
}