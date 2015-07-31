using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using ISIC.Entities;

using ISICWeb.Areas.Antecedentes.Models;
using MPBA.DataAccess;

namespace ISICWeb.Services
{
    public interface IGnaService
    {
        bool BorrarFichaGNA(int id, IPrincipal user);
        string GuardarFichaGNA(GNAViewModel model, IPrincipal user);
        GNAViewModel LlenarViewModelDesdeBase(string prontuariosic, int idGNA);
    }

    public class GnaService : IGnaService
    {
        private IRepository _repository;


        public GnaService(IRepository repository)
        {
            _repository = repository;

        }

        public bool BorrarFichaGNA(int id, IPrincipal user)
        {
            try
            {
                GNA gna = _repository.Set<GNA>().Single(x => x.Id == id);
                gna.Baja = true;
                gna.FechaUltimaModificacion=DateTime.Now;
                gna.idUsuarioUltimaModificacion = user.Identity.Name;
                _repository.UnitOfWork.RegisterChanged(gna);
                _repository.UnitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public string GuardarFichaGNA(GNAViewModel model, IPrincipal user)
        {
            string errores = "";
            string prontuariosic = model.Prontuario.ProntuarioNro;
            Prontuario prontuario = _repository.Set<Prontuario>().FirstOrDefault(x => x.ProntuarioNro == prontuariosic);
            GNA gna = _repository.Set<GNA>().SingleOrDefault(x => x.Id == model.Id);
            if (gna == null)
            {
                gna = new GNA
                {
                    FechaCreacion = DateTime.Now,
                    idUsuarioCreacion = user.Identity.Name,

                };
            }

            if (prontuario == null)
            {
                prontuario = new Prontuario { ProntuarioNro = prontuariosic };
            }
            gna.Nombre = model.Nombre;
            gna.Apellido = model.Apellido;
            gna.ApellidoMadre = model.ApellidoMadre;
            gna.Prontuario = prontuario;
            gna.Asunto = model.Asunto;
            gna.Captura = model.Captura;
            gna.Caratula = model.Caratula;
            DateTime fecha;
            bool fechacorrecta=DateTime.TryParseExact(model.FechaInforme, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha);
            if (!fechacorrecta )
                errores = "Fecha del informe incorrecta";
            else
                gna.FechaInforme = fecha;
            gna.Corroborado = model.Corroborado;
            gna.DocumentoNumero = model.DocumentoNumero;
            gna.ExpteGNA = model.ExpteGNA;
            if (!string.IsNullOrEmpty(model.FechaNacimiento))
                gna.FechaNacimiento = DateTime.ParseExact(model.FechaNacimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (!string.IsNullOrEmpty(model.FechaPedido))
                gna.FechaPedido = DateTime.ParseExact(model.FechaPedido, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            gna.Generado = model.Generado;
            gna.ImpSalida = model.ImpSalida;
            gna.Juzgadointerviniente = model.Juzgadointerviniente;
            gna.NroLegajoGNA = model.NroLegajoGNA;
            gna.Vigente = model.Vigente;
            gna.Sexo = _repository.Set<ClaseSexo>().Single(x => x.Id.ToString() == model.idClaseSexo);
            gna.TipoDNI = _repository.Set<ClaseTipoDNI>().Single(x => x.Id.ToString() == model.idClaseTipoDNI);
            gna.FechaUltimaModificacion=DateTime.Now;
            gna.idUsuarioUltimaModificacion = user.Identity.Name;
            if (errores == "")
            {

                if (model.Id == 0)
                {
                    _repository.UnitOfWork.RegisterNew(gna);
                }
                else
                {
                    _repository.UnitOfWork.RegisterChanged(gna);
                }
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
            return errores;

        }

        public GNAViewModel LlenarViewModelDesdeBase(string prontuariosic, int idGNA)
        {
            GNA gna = _repository.Set<GNA>().SingleOrDefault(x => x.Id == idGNA);
            if (gna==null)gna=new GNA();
            GNAViewModel model = new GNAViewModel();
            Prontuario prontuario = _repository.Set<Prontuario>().SingleOrDefault(x => x.ProntuarioNro == prontuariosic);
            if (prontuario == null)
            {
                prontuario = new Prontuario { ProntuarioNro = prontuariosic };
            };
            model.Id = idGNA;
            model.idClaseSexo = gna.Sexo == null ? "0" : gna.Sexo.Id.ToString();
            model.idClaseTipoDNI = gna.TipoDNI == null ? "0" : gna.TipoDNI.Id.ToString();
            model.Nombre = gna.Nombre;
            model.Apellido = gna.Apellido;
            model.ApellidoMadre = gna.ApellidoMadre;
            model.Prontuario = prontuario;
            model.Asunto = gna.Asunto;
            model.Captura = gna.Captura;
            model.Caratula = gna.Caratula;
            model.Corroborado = gna.Corroborado;
            model.DocumentoNumero = gna.DocumentoNumero;
            model.ExpteGNA = gna.ExpteGNA;
            model.FechaNacimiento = gna.FechaNacimiento == null ? "" : gna.FechaNacimiento.Value.ToString("dd/MM/yyyy");
            model.FechaPedido = gna.FechaPedido == null ? "" : gna.FechaPedido.Value.ToString("dd/MM/yyyy");
            model.Generado = gna.Generado;
            model.ImpSalida = gna.ImpSalida;
            model.Juzgadointerviniente = gna.Juzgadointerviniente;
            model.NroLegajoGNA = gna.NroLegajoGNA;
            model.Vigente = gna.Vigente;
            model.ClaseSexoList = new SelectList(_repository.Set<ClaseSexo>().ToList(), "Id", "descripcion");
            model.ClaseTipoDNIList = new SelectList(_repository.Set<ClaseTipoDNI>().ToList(), "Id", "descripcion");
            model.FechaInforme = (gna.Id > 0) ? gna.FechaInforme.ToString("dd/MM/yyyy") : DateTime.Now.ToString("dd/MM/yyyy");
            return model;
        }

       
    }
}