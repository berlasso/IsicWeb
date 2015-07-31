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
    public interface IIdgxService
    {
        /// <summary>
        /// Treae el idgxdatopersona con el id indicado y llena con eso el viewmodel
        /// </summary>
        /// <param name="idIdgxdatospersonales"></param>
        /// <param name="idIdgxprontuario"></param>
        /// <returns></returns>
        IdgxDatosPersonalesViewModel TraerIdgxDatosPersona(int idIdgxdatospersonales, int idIdgxprontuario);

        bool BorrarIdgxDatosPersonales(int idIdgxdatospersonales);
        bool BorrarIdgxDelito(int idIdgxdelito, IPrincipal user);
        IdgxProntuarioViewModel TraerIdgxProntuarioViewModel(IdgxProntuario idgxProntuario, string prontuariosic = "");
        IdgxProntuarioViewModel LlenarIdgxProntuarioViewModel(IdgxProntuario idgxProntuario, string prontuariosic);
        IdgxProntuario NuevoIdgxProntuario(string prontuariosic);
        int GuardarIdgxDatosPersona(IdgxDatosPersonalesViewModel datosPersona, IPrincipal user);
        int GuardarIdgxDelito(IdgxDelitoViewModel delito, IPrincipal user);
        IdgxDelitoViewModel TraerIdgxDelito(int idIdgxdelito);
        int GuardarIdgxProntuario(string idIdgxProntuario, string prontuariopf, string idtipoprontuario, string prontuariosic);
        bool BorrarProntuarioIdgx(int id, IPrincipal user);
    }

    public class IdgxService : IIdgxService
    {
        private IRepository _repository;


        public IdgxService(IRepository repository)
        {
            _repository = repository;

        }


        /// <summary>
        /// Treae el idgxdatopersona con el id indicado y llena con eso el viewmodel
        /// </summary>
        /// <param name="idIdgxdatospersonales"></param>
        /// <param name="idIdgxprontuario"></param>
        /// <returns></returns>
        public IdgxDatosPersonalesViewModel TraerIdgxDatosPersona(int idIdgxdatospersonales, int idIdgxprontuario)
        {
            IdgxDatosPersona datosPersona = _repository.Set<IdgxDatosPersona>().Single(x => x.Id == idIdgxdatospersonales);
            IdgxDatosPersonalesViewModel idgxpersona = new IdgxDatosPersonalesViewModel
            {
                TipoDocumentoList =
                    new SelectList(_repository.Set<ClaseTipoDNI>().ToList(), "Id", "descripcion", datosPersona.TipoDNI == null ? "0" : datosPersona.TipoDNI.Id.ToString()),
                ProvinciaList = new SelectList(_repository.Set<Provincia>().ToList(), "Id", "ProvinciaNombre", datosPersona.ProvinciaNacimiento == null ? "0" : datosPersona.ProvinciaNacimiento.Id.ToString()),
                Apellido = datosPersona.Apellido,
                TipoDNI = datosPersona.TipoDNI == null ? "0" : datosPersona.TipoDNI.Id.ToString(),
                //TipoProntuarioPF = datosPersona.tipoprontuario == null ? "0" : datosPersona.tipoprontuario.Id.ToString(),
                Apodo = datosPersona.Apodo,
                Id = datosPersona.Id,
                PartidoNacimiento = datosPersona.PartidoNacimiento,
                LocalidadNacimiento = datosPersona.LocalidadNacimiento,
                ProvinciaNacimiento = datosPersona.ProvinciaNacimiento == null ? "0" : datosPersona.ProvinciaNacimiento.Id.ToString(),
                InfDac = datosPersona.InfDac,
                DocumentoNumero = datosPersona.DocumentoNumero,
                FechaFallecimiento =datosPersona.FechaFallecimiento==null?"": datosPersona.FechaFallecimiento.Value.ToString("dd/MM/yyyy"),
                FechaNacimiento =datosPersona.FechaNacimiento==null?"": datosPersona.FechaNacimiento.Value.ToString("dd/MM/yyyy"),
                InfNom = datosPersona.InfNom,
                Madre = datosPersona.Madre,
                Padre = datosPersona.Padre,
                FechaInforme = datosPersona.FechaInforme.ToString("dd/MM/yyyy"),
                Nombre = datosPersona.Nombre,
                causaspendientes = datosPersona.causaspendientes,
                idIdgxProntuario = idIdgxprontuario,
                Delitos = datosPersona.Delitos

            };
            
            
            
            return idgxpersona;
        }



        public bool BorrarIdgxDatosPersonales(int idIdgxdatospersonales)
        {
            bool borroBien = false;
            try
            {
                IdgxDatosPersona datosPersona = _repository.Set<IdgxDatosPersona>().Single(x => x.Id == idIdgxdatospersonales);
                _repository.UnitOfWork.RegisterDeleted(datosPersona);
                _repository.UnitOfWork.Commit();
                borroBien = true;
            }
            catch (Exception)
            {

            }
            return borroBien;
        }

        public bool BorrarIdgxDelito(int idIdgxdelito, IPrincipal user)
        {
            bool borroBien = false;
            try
            {
                IdgxDetalle idgxdelito = _repository.Set<IdgxDetalle>().Single(x => x.Id == idIdgxdelito);
                _repository.UnitOfWork.RegisterDeleted(idgxdelito);
                _repository.UnitOfWork.Commit();
                borroBien = true;
            }
            catch (Exception)
            {

            }
            return borroBien;
        }

        public IdgxProntuarioViewModel TraerIdgxProntuarioViewModel(IdgxProntuario idgxProntuario, string prontuariosic = "")
        {
            IdgxProntuarioViewModel prontuario = new IdgxProntuarioViewModel();
            if (idgxProntuario == null) //nuevo
                idgxProntuario = NuevoIdgxProntuario(prontuariosic);
            prontuario = LlenarIdgxProntuarioViewModel(idgxProntuario,prontuariosic);

            return prontuario;

        }

        public IdgxProntuarioViewModel LlenarIdgxProntuarioViewModel(IdgxProntuario idgxProntuario, string prontuariosic)
        {
            

            IdgxProntuarioViewModel prontuario = new IdgxProntuarioViewModel
            {
                TipoProntuarioPFList =
                     new SelectList(_repository.Set<ClaseProntuarioPoliciaFederal>().ToList(), "Id", "descripcion", idgxProntuario.tipoprontuario == null ? "1" : idgxProntuario.tipoprontuario.Id.ToString()),
                ProntuarioPF = idgxProntuario.ProntuarioPF,
                Id = idgxProntuario.Id,
                prontuariosic = prontuariosic,
                tipoprontuario = idgxProntuario.tipoprontuario??_repository.Set<ClaseProntuarioPoliciaFederal>().Single(x=>x.Id==1),//indeterminado
                DatosPersona = idgxProntuario.DatosPersona,
                TipoProntuarioPF = idgxProntuario.tipoprontuario == null ? "1" : idgxProntuario.tipoprontuario.Id.ToString()

            };

            return prontuario;
        }

        public IdgxProntuario NuevoIdgxProntuario(string prontuariosic)
        {
            Prontuario prontuarioSic = _repository.Set<Prontuario>().SingleOrDefault(x => x.ProntuarioNro == prontuariosic);
            if (prontuarioSic==null)
                prontuarioSic=new Prontuario
            {
                ProntuarioNro = prontuariosic,

            };
            IdgxProntuario idgxprontuario = new IdgxProntuario
            {
                Prontuario = prontuarioSic,
                FechaCreacion = DateTime.Now,
                FechaUltimaModificacion = DateTime.Now,
                ProntuarioPF = "",



            };
         //   _repository.UnitOfWork.RegisterNew(idgxprontuario);
         //   _repository.UnitOfWork.Commit();
            return idgxprontuario;
        }

        public int GuardarIdgxDatosPersona(IdgxDatosPersonalesViewModel datosPersona, IPrincipal user)
        {
            IdgxDatosPersona idgxpersona = null;
            if (datosPersona.Id == 0)
                idgxpersona = new IdgxDatosPersona
                {
                    FechaCreacion = DateTime.Now,
                    UsuarioCreacion = user.Identity.Name
                };
            else
                idgxpersona = _repository.Set<IdgxDatosPersona>().Single(x => x.Id == datosPersona.Id);

            if (datosPersona.idIdgxProntuario > 0)
            {
                IdgxProntuario idgxprontuario =
                    _repository.Set<IdgxProntuario>().Single(x => x.Id == datosPersona.idIdgxProntuario);

                if (datosPersona.LocalidadNacimiento.Id != null)
                {
                    idgxpersona.LocalidadNacimiento =
                        _repository.Set<Localidad>().FirstOrDefault(x => x.Id == datosPersona.LocalidadNacimiento.Id);
                }
                if (datosPersona.PartidoNacimiento.Id != null)
                {
                    idgxpersona.PartidoNacimiento =
                        _repository.Set<Partido>().FirstOrDefault(x => x.Id == datosPersona.PartidoNacimiento.Id);
                }
                if (datosPersona.ProvinciaNacimiento != null)
                {
                    idgxpersona.ProvinciaNacimiento =
                        _repository.Set<Provincia>().FirstOrDefault(x => x.Id.ToString() == datosPersona.ProvinciaNacimiento);
                }
                if (datosPersona.TipoDNI != null)
                {
                    idgxpersona.TipoDNI =
                        _repository.Set<ClaseTipoDNI>().FirstOrDefault(x => x.Id.ToString() == datosPersona.TipoDNI);
                }
                //if (datosPersona.TipoProntuarioPF != null)
                //{
                //    idgxpersona.tipoprontuario =
                //        _repository.Set<ClaseProntuarioPoliciaFederal>().FirstOrDefault(x => x.Id.ToString() == datosPersona.TipoProntuarioPF);
                //}
                
                idgxpersona.FechaModificacion = DateTime.Now;
                idgxpersona.UsuarioModificacion = user.Identity.Name;
                idgxpersona.Apellido = datosPersona.Apellido;
                idgxpersona.Apodo = datosPersona.Apodo;
                idgxpersona.Id = datosPersona.Id;
                DateTime fecha;
                bool fechacorrecta = DateTime.TryParseExact(datosPersona.FechaInforme, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha);
                if (!fechacorrecta)
                    throw new Exception("Fecha del informe incorrecta");
                else
                    idgxpersona.FechaInforme = fecha;
                idgxpersona.InfDac = datosPersona.InfDac;
                idgxpersona.DocumentoNumero = datosPersona.DocumentoNumero;
                if (datosPersona.FechaFallecimiento != null)
                    idgxpersona.FechaFallecimiento = DateTime.ParseExact(datosPersona.FechaFallecimiento, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture);
                else
                {
                    idgxpersona.FechaFallecimiento = null;
                }
                if (datosPersona.FechaNacimiento!=null)
                    idgxpersona.FechaNacimiento = DateTime.ParseExact(datosPersona.FechaNacimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                else
                {
                    idgxpersona.FechaNacimiento = null;
                }
                idgxpersona.InfNom = datosPersona.InfNom;
                idgxpersona.Madre = datosPersona.Madre;
                idgxpersona.Padre = datosPersona.Padre;
                idgxpersona.Nombre = datosPersona.Nombre;
                idgxpersona.causaspendientes = datosPersona.causaspendientes;


                if (datosPersona.Id == 0)
                {
                    idgxprontuario.DatosPersona.Add(idgxpersona);
                    _repository.UnitOfWork.RegisterChanged(idgxprontuario);
                }
                else
                    _repository.UnitOfWork.RegisterChanged(idgxpersona);
                _repository.UnitOfWork.Commit();
                return idgxpersona.Id;

            }
            throw new Exception("No se pudo guardar idgxdatospersonales");
        }

        public int GuardarIdgxDelito(IdgxDelitoViewModel delito, IPrincipal user)
        {
            IdgxDetalle idgxdelito = null;
            if (delito.Id == 0)
                idgxdelito = new IdgxDetalle
                {
                    ctlUsuCrea = user.Identity.Name,
                    ctlFecCrea = DateTime.Now
                };
            else
            {
                idgxdelito = _repository.Set<IdgxDetalle>().Single(x => x.Id == delito.Id);
            }
            if (delito.idIdgxdatospersonales > 0)
            {
                IdgxDatosPersona datosPersona =
                    _repository.Set<IdgxDatosPersona>().Single(x => x.Id == delito.idIdgxdatospersonales);
                idgxdelito.DatosPersonaIdg = datosPersona;
            }
            idgxdelito.causassinefecto = delito.causassinefecto;
            idgxdelito.causatipo = delito.causatipo;
            if (delito.CodigoRestriccionPF != null)
            {
                ClaseCodigoRestriccionPoliciaFederal codrespf =
                    _repository.Set<ClaseCodigoRestriccionPoliciaFederal>().FirstOrDefault(x => x.Id.ToString() == delito.CodigoRestriccionPF);
                idgxdelito.codigoRestriccion = codrespf;
            }
            idgxdelito.ctlUsuModi = user.Identity.Name;
            idgxdelito.ctlFecModi = DateTime.Now;
            idgxdelito.expedientenro = delito.expedientenro;
            if (delito.fechapublicacion != null && delito.fechapublicacion.Trim() != "")
                idgxdelito.fechapublicacion = DateTime.ParseExact(delito.fechapublicacion, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            else
            {
                idgxdelito.fechapublicacion = null;
            }
            if (delito.fecharesolucion != null && delito.fecharesolucion.Trim() != "")
                idgxdelito.fecharesolucion = DateTime.ParseExact(delito.fecharesolucion, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            else
            {
                idgxdelito.fecharesolucion = null;
            }
            if (delito.fechavigente != null && delito.fechavigente.Trim() != "")
                idgxdelito.fechavigente = DateTime.ParseExact(delito.fechavigente, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            else
            {
                idgxdelito.fechavigente = null;
            }
            idgxdelito.nrocausa = delito.nrocausa;
            idgxdelito.observaciones = delito.observaciones;
            idgxdelito.ordendeldia = delito.ordendeldia;
            idgxdelito.pedidovigente = delito.pedidovigente;
            idgxdelito.pedidovigentepublicacion = delito.pedidovigentepublicacion;
            idgxdelito.provisorio = delito.provisorio;
            idgxdelito.publicado = delito.publicado;
            idgxdelito.resolucion = delito.resolucion;
            idgxdelito.secretaria = delito.secretaria;
            idgxdelito.solicitante = delito.solicitante;
            

            if (delito.Id == 0)
                _repository.UnitOfWork.RegisterNew(idgxdelito);
            else
                _repository.UnitOfWork.RegisterChanged(idgxdelito);
            _repository.UnitOfWork.Commit();
            return idgxdelito.Id;



        }

        public IdgxDelitoViewModel TraerIdgxDelito(int idIdgxdelito)
        {
            IdgxDetalle detalle = _repository.Set<IdgxDetalle>().Single(x => x.Id == idIdgxdelito);
            IdgxDelitoViewModel delito = null;
            if (detalle != null)
            {
                delito = new IdgxDelitoViewModel
                {
                    Id = detalle.Id,
                    CodigoRestriccionList = new SelectList(_repository.Set<ClaseCodigoRestriccionPoliciaFederal>().ToList(), "Id",
                            "descripcion"),
                    CodigoRestriccionPF = detalle.codigoRestriccion.Id.ToString(),
                    DatosPersonaIdg = detalle.DatosPersonaIdg,
                    causassinefecto = detalle.causassinefecto,
                    idIdgxdatospersonales = detalle.DatosPersonaIdg.Id,
                    idIdgxprontuario = detalle.DatosPersonaIdg.IdgxProntuario.Id,
                    fechapublicacion = detalle.fechapublicacion == null ? "" : detalle.fechapublicacion.ToString(),
                    fecharesolucion = detalle.fecharesolucion == null ? "" : detalle.fecharesolucion.ToString(),
                    fechavigente = detalle.fechavigente == null ? "" : detalle.fechavigente.ToString(),
                    causatipo = detalle.causatipo,
                    expedientenro = detalle.expedientenro,
                    nrocausa = detalle.nrocausa,
                    observaciones = detalle.observaciones,
                    ordendeldia = detalle.ordendeldia,
                    pedidovigente = detalle.pedidovigente,
                    pedidovigentepublicacion = detalle.pedidovigentepublicacion,
                    provisorio = detalle.provisorio,
                    publicado = detalle.publicado,
                    resolucion = detalle.resolucion,
                    secretaria = detalle.secretaria,
                    solicitante = detalle.solicitante
                };
            }

            return delito;
        }

        public int GuardarIdgxProntuario(string idIdgxProntuario, string prontuariopf, string idtipoprontuario, string prontuariosic)
        {
            try
            {
                if (idtipoprontuario == "")
                    idtipoprontuario = "1";

                IdgxProntuario idgxprontuario = _repository.Set<IdgxProntuario>().FirstOrDefault(x => x.Id.ToString() == idIdgxProntuario);

                ClaseProntuarioPoliciaFederal tipoprontuario =
                    _repository.Set<ClaseProntuarioPoliciaFederal>().Single(x => x.Id.ToString() == idtipoprontuario);

                Prontuario prontuarioSic = _repository.Set<Prontuario>().SingleOrDefault(x => x.ProntuarioNro == prontuariosic);
                if (prontuarioSic == null)
                {
                    prontuarioSic = new Prontuario
                    {
                        ProntuarioNro = prontuariosic,
                    };
                }
                if (idgxprontuario == null)
                    idgxprontuario = new IdgxProntuario();

                idgxprontuario.Prontuario = prontuarioSic;
                idgxprontuario.ProntuarioPF = prontuariopf;
                idgxprontuario.tipoprontuario = tipoprontuario;
                idgxprontuario.Baja = false;
                idgxprontuario.FechaUltimaModificacion = DateTime.Now;
                if (idgxprontuario.Id == 0)
                {
                    idgxprontuario.FechaCreacion=DateTime.Now;
                    _repository.UnitOfWork.RegisterNew(idgxprontuario);
                }
                else
                    _repository.UnitOfWork.RegisterChanged(idgxprontuario);
                _repository.UnitOfWork.Commit();


                return idgxprontuario.Id;
            }
            catch 
            {
                
                return -1;
            }
          
        }

        public bool BorrarProntuarioIdgx(int id, IPrincipal user)
        {
            try
            {
                IdgxProntuario idgxProntuario = _repository.Set<IdgxProntuario>().Single(x => x.Id == id);
                idgxProntuario.FechaUltimaModificacion = DateTime.Now;
                idgxProntuario.idUsuarioUltimaModificacion = user.Identity.Name;
                idgxProntuario.Baja = true;
                _repository.UnitOfWork.RegisterChanged(idgxProntuario);
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