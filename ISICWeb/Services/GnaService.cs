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
    public class GnaService
    {
        private IRepository _repository;


        public GnaService(IRepository repository)
        {
            _repository = repository;

        }

        public bool BorrarFichaGNA(int id)
        {
            try
            {
                GNA gna = _repository.Set<GNA>().Single(x => x.Id == id);
                gna.Baja = true;
                _repository.UnitOfWork.RegisterChanged(gna);
                _repository.UnitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public string GuardarFichaGNA(GNA model)
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
            model.TipoDNI = _repository.Set<ClaseTipoDNI>().Single(x => x.Id == model.TipoDNI.Id);
            model.FechaUltimaModificacion = DateTime.Now;


            if (model.Id == 0)
            {
                model.FechaCreacion = DateTime.Now;
                model.Prontuario = prontuario;
                model.FechaCarga = DateTime.Now;
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