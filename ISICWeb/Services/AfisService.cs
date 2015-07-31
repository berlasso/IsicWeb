using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using ISIC.Entities;
using ISICWeb.Areas.Afis.Models;
using MPBA.DataAccess;
using WebGrease.Css.Extensions;


namespace ISICWeb.Services
{
    public interface IAfisService
    {
        bool BorrarFichaAFIS(int id, IPrincipal user);
        string GuardarFichaAFIS(AFISViewModel model, IPrincipal user);
        AFISViewModel LlenarViewModelDesdeBase(string prontuariosic, int idAfis);
    }

    public class AfisService : IAfisService
    {
        private IRepository _repository;


        public AfisService(IRepository repository)
        {
            _repository = repository;

        }

        public bool BorrarFichaAFIS(int id, IPrincipal user)
        {
            try
            {
                AFIS afis = _repository.Set<AFIS>().Single(x => x.Id == id);
                afis.idUsuarioUltimaModificacion = user.Identity.Name;
                afis.FechaUltimaModificacion=DateTime.Now;
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

        public string GuardarFichaAFIS(AFISViewModel model, IPrincipal user)
        {
            string errores = "";
            string prontuariosic = model.Prontuario.ProntuarioNro;
            Prontuario prontuarioAlta = _repository.Set<Prontuario>().SingleOrDefault(x => x.Id == model.Prontuario.Id);
            Prontuario prontuarioBaja = _repository.Set<Prontuario>().SingleOrDefault(x => x.ProntuarioNro==model.NIF);
            AFIS afis = _repository.Set<AFIS>().SingleOrDefault(x => x.Id == model.Id);
            if (afis==null)
            {
                afis = new AFIS{
                    FechaCreacion = DateTime.Now,
                    idUsuarioCreacion = user.Identity.Name,
                    
                };
            }

            
            if (prontuarioAlta == null)
            {
                //prontuario = new Prontuario{ProntuarioNro = prontuariosic};
                errores = "No se hallo prontuario asociado.";
                    return errores;
            }
            if (afis.Prontuario!=null && afis.Prontuario.Id != model.Prontuario.Id)
            {
            
                    afis.Prontuario.baja = true;
               
            }

            if (prontuarioBaja != null && prontuarioAlta!=prontuarioBaja)
            {
                prontuarioBaja.baja = true;
                IEnumerable<GNA> gnas = prontuarioBaja.DatosGNA;
                gnas.ForEach(x => x.Prontuario = prontuarioAlta);
                IEnumerable<IdgxProntuario> idgx = prontuarioBaja.ProntuariosIdgx;
                idgx.ForEach(x => x.Prontuario = prontuarioAlta);
                IEnumerable<Migraciones> migracioneses = prontuarioBaja.DatosMigracioneses;
                migracioneses.ForEach(x => x.Prontuario = prontuarioAlta);
            }

            afis.Prontuario = prontuarioAlta;
            afis.NIF = model.NIF;
            afis.DNI = model.DNI;
          
            afis.Apellido = model.Apellido;
            afis.Nombre = model.Nombre;
            afis.CTL = model.CTL;
            afis.Clase = model.Clase;
            afis.FechaUltimaModificacion = DateTime.Now;
            afis.idUsuarioUltimaModificacion = user.Identity.Name;
            afis.Sexo = _repository.Set<ClaseSexo>().Single(x => x.Id.ToString() == model.idClaseSexo);
            afis.TipoDNI = _repository.Set<ClaseTipoDNI>().Single(x => x.Id.ToString() == model.idTipoDoc);
            DateTime fecha;
            bool fechacorrecta = DateTime.TryParseExact(model.FechaInforme, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha);
            if (!fechacorrecta)
                errores = "Fecha del informe incorrecta";
            else
                afis.FechaInforme = fecha;
            if (errores == "")
            {
                
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

            Imputado imputado = _repository.Set<Imputado>().FirstOrDefault(x => x.CodigoDeBarras == model.NIF);
                if (imputado != null)
                {
                    imputado.Prontuario = prontuarioAlta;

                    _repository.UnitOfWork.RegisterChanged(imputado);
                    try
                    {
                        _repository.UnitOfWork.Commit();
                    }
                    catch (Exception e)
                    {
                        errores = e.InnerException == null
                            ? "Error al guardar. " + e.Message
                            : e.InnerException.ToString().Substring(0, 400);
                    }
                }

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
            model.FechaInforme = (afis.Id > 0) ? afis.FechaInforme.ToString("dd/MM/yyyy") : DateTime.Now.Date.ToString("dd/MM/yyyy");
            model.Clase = afis.Clase;
            model.DNI = afis.DNI;
            model.SexoList = new SelectList(_repository.Set<ClaseSexo>().ToList(), "Id", "descripcion");
            model.TipoDocList = new SelectList(_repository.Set<ClaseTipoDNI>().ToList(), "Id", "descripcion");
            return model;
        }
    }
}