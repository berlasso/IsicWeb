using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISIC.Entities;

using ISICWeb.Areas.Antecedentes.Models;
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

        public string GuardarFichaAFIS(AFIS model)
        {
            

            string errores = "";
            string prontuariosic = model.Prontuario.ProntuarioNro;
            Prontuario prontuario = _repository.Set<Prontuario>().FirstOrDefault(x => x.ProntuarioNro == prontuariosic);
            if (prontuario == null)
                prontuario = new Prontuario
                {
                    ProntuarioNro = prontuariosic
                };

            model.Sexo = _repository.Set<ClaseSexo>().Single(x => x.Id == model.Sexo.Id);
            //model.TipoDNI = _repository.Set<ClaseTipoDNI>().Single(x => x.Id == model.TipoDNI.Id);
            model.FechaUltimaModificacion = DateTime.Now;


            if (model.Id == 0)
            {
                model.FechaCreacion = DateTime.Now;
                model.Prontuario = prontuario;
                _repository.UnitOfWork.RegisterNew(model);
            }
            else
                _repository.UnitOfWork.RegisterChanged(model);
            try
            {
                _repository.UnitOfWork.Commit();
            }
            catch (Exception e)
            {
                errores = e.InnerException == null ? "Error al guardar" : e.InnerException.ToString().Substring(0, 400);
            }
            return errores;

        }

    

       
    }
}