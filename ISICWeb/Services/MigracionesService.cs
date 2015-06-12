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

     
    }
}