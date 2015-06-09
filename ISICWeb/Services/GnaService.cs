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

    

       
    }
}