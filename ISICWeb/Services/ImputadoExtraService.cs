using System;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;
using ISIC.Entities;
using ISIC.Services;
using ISICWeb.Areas.Otip.Models;
using Microsoft.Owin.Security.Provider;
using MPBA.DataAccess;
using MPBA.Jira.Model;

namespace ISICWeb.Services
{
    public class ImputadoExtraService: ISIC.Services.ImputadoService
    {
        private IRepository _repository;
        private JiraService _jiraService;

        public ImputadoExtraService(IRepository repository, JiraService jiraService=null) : base(repository)
        {
            this._repository = repository;
            _jiraService = jiraService;
        }

        public DatosGeneralesViewModel CrearViewModel()
        {
            DatosGeneralesViewModel datosGenerales= new DatosGeneralesViewModel();
            datosGenerales.Id = 0;
            LlenarListas(datosGenerales);
            return datosGenerales;
        }

        /// <summary>
        /// Llena el viewmodel con el imputado cuyo id se indica traido para mostrarlo el la vista
        /// </summary>
        /// <param name="id">id del imputado a traer</param>
        /// <param name="ParaEditar">si es para editar o solo lectura</param>
        /// <returns></returns>
        public DatosGeneralesViewModel LlenarViewModelConImputado(int id, bool ParaEditar)
        {
            Imputado imputado = _repository.Set<Imputado>().FirstOrDefault(s => s.Id == id);
            if (imputado != null)
            {
                Persona persona = imputado.Persona;
                //DatosGeneralesViewModel datosImputado=new DatosGeneralesViewModel();
                DatosGeneralesViewModel datosImputado = new DatosGeneralesViewModel
                {
                    Id = imputado.Id,
                    CodBarras = imputado.CodigoDeBarras,
                    FechaCarga = imputado.FechaCreacionI.ToString("dd/MM/yyyy"),
                    Apellido = persona.Apellido,
                    Nombres = persona.Nombre,
                    Apodos = imputado.Alias == null ? "" : imputado.Alias.Alias,
                    Padre = persona.Padre ?? "",
                    Madre = persona.Madre ?? "",
                    ObservacionesMigracion = imputado.ObservacionesMigracion,
                    Telefono = persona.Telefono,
                    FechaNacimiento = persona.FechaNacimiento == null ? "" : persona.FechaNacimiento.Value.ToString("dd/MM/yyyy"),
                    Profesion = persona.profesion ?? "",
                    PaisNacimiento = persona.Nacionalidad == null ? "" : persona.Nacionalidad.Id.ToString(),
                    ProvinciaNacimiento =
                        persona.ProvinciaNacimiento == null ? "" : persona.ProvinciaNacimiento.Id.ToString(),
                    TipoDocumento = persona.TipoDNI == null ? "0" : persona.TipoDNI.Id.ToString(),
                    NumeroDocumento = persona.DocumentoNumero == null ? "" : persona.DocumentoNumero.ToString(),
                    Instruccion = persona.EstudiosCursados == null ? "" : persona.EstudiosCursados.Id.ToString(),
                    EstadoCivil = persona.EstadoCivil == null ? "" : persona.EstadoCivil.Id.ToString(),
                    EsSoloDetalle = !ParaEditar,
                    Conyuge = persona.Conyuge ?? "",
                    Robustez = imputado.Robustez == null ? "0" : imputado.Robustez.Id.ToString(),
                    FormaBoca = imputado.FormaBoca == null ? "0" : imputado.FormaBoca.Id.ToString(),
                    FormaCara = imputado.FormaCara == null ? "0" : imputado.FormaCara.Id.ToString(),
                    FormaLabioInferior = imputado.FormaLabioInferior == null ? "0" : imputado.FormaLabioInferior.Id.ToString(),
                    FormaLabioSuperior = imputado.FormaLabioSuperior == null ? "0" : imputado.FormaLabioSuperior.Id.ToString(),
                    FormaMenton = imputado.FormaMenton == null ? "0" : imputado.FormaMenton.Id.ToString(),
                    FormaNariz = imputado.FormaNariz == null ? "0" : imputado.FormaNariz.Id.ToString(),
                    FormaOreja = imputado.FormaOreja == null ? "0" : imputado.FormaOreja.Id.ToString(),
                    ColorCabellos = imputado.ColorCabello == null ? "0" : imputado.ColorCabello.Id.ToString(),
                    TipoCabello = imputado.TipoCabello == null ? "0" : imputado.TipoCabello.Id.ToString(),
                    DimensionCeja = imputado.CejasDimension == null ? "0" : imputado.CejasDimension.Id.ToString(),
                    TipoCeja = imputado.CejasTipo == null ? "0" : imputado.CejasTipo.Id.ToString(),
                    ColorOjos = imputado.ColorOjos == null ? "0" : imputado.ColorOjos.Id.ToString(),
                    ColorPiel = imputado.ColorPiel == null ? "0" : imputado.ColorPiel.Id.ToString(),
                    TipoCalvicie = imputado.TipoCalvicie == null ? "0" : imputado.TipoCalvicie.Id.ToString(),
                    IPP = imputado.Delito == null ? "" : imputado.Delito.Ipp == null ? "" : imputado.Delito.Ipp.numero ?? "",
                    Delito = imputado.Delito == null ? "" : imputado.Delito.Ipp == null ? "" : imputado.Delito.Ipp.caratula,
                    Estatura = imputado.Estatura,
                    FechaDelito = imputado.Delito == null ? "" : imputado.Delito.DescripcionTemporal == null ? "" : imputado.Delito.DescripcionTemporal.FechaDesde.Value.ToString("dd/MM/yyyy"),
                    FiscaliaGeneral = imputado.CodigoDeBarras == null ? "" : Convert.ToInt32(imputado.CodigoDeBarras.Substring(2, 2)).ToString(),
                    Sexo = persona.Sexo == null ? "0" : persona.Sexo.Id.ToString(),
                    OtrosNombres = imputado.OtrosNombres ?? "",
                    Archivos = imputado.Archivos
                };
               
                bool hayModusOperandi = imputado.Delito!=null&&imputado.Delito.ModusOperandi != null;
                datosImputado.hidIdModusOperandi = hayModusOperandi ? imputado.Delito.ModusOperandi.Id.ToString() : "0";
                datosImputado.ModusOperandi = hayModusOperandi ? imputado.Delito.ModusOperandi.Descripcion : "";

                bool hayLocalidadPolicial = imputado.Delito!=null && imputado.Delito.Comisaria != null &&
                                            imputado.Delito.Comisaria.Localidad != null;
                
                datosImputado.LocalidadPolicial = hayLocalidadPolicial
                    ? imputado.Delito.Comisaria.Localidad.LocalidadNombre
                    : "";
                //datosImputado.LocalidadPolicial = imputado.Delito.Comisaria.Localidad.LocalidadNombre;
                datosImputado.hidIdLocalidadPolicial = hayLocalidadPolicial? imputado.Delito.Comisaria.Localidad.Id.ToString(): "0";

                bool hayComisaria =imputado.Delito!=null&& imputado.Delito.Comisaria != null;
                datosImputado.hidIdDependenciaPolicial = hayComisaria ? imputado.Delito.Comisaria.Id.ToString() : "0";
                datosImputado.DependenciaPolicial = hayComisaria? imputado.Delito.Comisaria.Descripcion: "";

                bool hayLocalidadNacimiento = persona.LocalidadNacimiento != null;
                datosImputado.hidIdLocalidadNacimiento = hayLocalidadNacimiento
                    ? persona.LocalidadNacimiento.Id.ToString()
                    : "0";
                datosImputado.LocalidadNacimiento = hayLocalidadNacimiento
                    ? persona.LocalidadNacimiento.LocalidadNombre
                    : "";
                
                Domicilio dom = persona.Domicilio;
                if (dom != null)
                {
                    
                    datosImputado.Calle = dom.Calle??"";
                    datosImputado.EntreCalle = dom.EntreCalle ?? "";
                    datosImputado.EntreCalle2 = dom.EntreCalle2 ?? "";
                    datosImputado.NroH = dom.NroH ?? "";
                    datosImputado.DeptoH = dom.DeptoH ?? "";
                    datosImputado.ParajeBarrioH = dom.ParajeBarrioH ?? "";
                    datosImputado.PisoH = dom.PisoH ?? "";
                    bool hayPartido = dom.Partido != null;
                    if (!hayPartido)
                    {
                        Partido partido = _repository.Set<Partido>().FirstOrDefault(p => p.Id == 0);
                        dom.Partido = partido;
                    }
                    datosImputado.Partido = dom.Partido==null?"":dom.Partido.PartidoNombre;
                    datosImputado.hidIdPartido = dom.Partido==null?"0":dom.Partido.Id.ToString();

                    bool hayLocalidad = dom.Localidad != null;
                    datosImputado.hidIdLocalidad = hayLocalidad ? dom.Localidad.Id.ToString() : "0";
                    datosImputado.Localidad = hayLocalidad ? dom.Localidad.LocalidadNombre : "";
                    datosImputado.Provincia = dom.Provincia == null ? "0" : dom.Provincia.Id.ToString();

                }

                Domicilio domDelito = imputado.Delito==null?null:imputado.Delito.Domicilio;
                if (imputado.Delito != null)
                    datosImputado.ComisariaMigracion = imputado.Delito.ComisariaMigracion;
                if (domDelito != null)
                {
                    datosImputado.CalleDelito = domDelito.Calle;
                    datosImputado.EntreCalleDelito = domDelito.EntreCalle;
                    datosImputado.EntreCalle2Delito = domDelito.EntreCalle2;
                    datosImputado.NroHDelito = domDelito.NroH;
                    datosImputado.DeptoHDelito = domDelito.DeptoH;
                    datosImputado.ParajeBarrioHDelito = domDelito.ParajeBarrioH;
                    datosImputado.PisoHDelito = domDelito.PisoH;
                    bool hayPartidoDelito = domDelito.Partido != null;
                    if (!hayPartidoDelito)
                    {
                        Partido partido = _repository.Set<Partido>().FirstOrDefault(p => p.Id == 0);
                        domDelito.Partido = partido;
                    }
                    datosImputado.hidIdPartidoDelito = domDelito.Partido==null?"0":domDelito.Partido.Id.ToString();
                    datosImputado.PartidoDelito = domDelito.Partido==null?"":domDelito.Partido.PartidoNombre;

                    bool hayLocalidadDelito = domDelito.Localidad != null;
                    datosImputado.hidIdLocalidadDelito = hayLocalidadDelito ? domDelito.Localidad.Id.ToString() : "0";
                    datosImputado.LocalidadDelito = hayLocalidadDelito ? domDelito.Localidad.LocalidadNombre : "";

                    datosImputado.ProvinciaDelito = domDelito.Provincia == null
                        ? "0"
                        : domDelito.Provincia.Id.ToString();
                }
                IPP ipp = imputado.Delito==null?null:imputado.Delito.Ipp;
                if (ipp != null)
                {
                    datosImputado.Fiscal = imputado.Delito.Ipp.TitularUFI??"";
                    datosImputado.UFI = imputado.Delito.Ipp.UFI??"";
                    datosImputado.JuzgadoGarantias = imputado.Delito.Ipp.JuzgadoGarantias??"";
                }
                LlenarListas(datosImputado);

                return datosImputado;
            }
            return null;
        }

        /// <summary>
        /// Creo/modifico los datos de un imputado con los datos ingresados el el viewmodel
        /// </summary>
        /// <param name="imp">el viewmodel que uso para modificar el imputado</param>
        /// <returns></returns>
        public string GuardarImputadoDesdeViewModel(DatosGeneralesViewModel imp,string idPuntoGestion)
        {
            int? id = imp.Id ?? 0;
            string error = "";
            long dni = 0;
            imp.EsSoloDetalle = false;
            //para que salga  indeterminado(0) en los autocompletes
            if (string.IsNullOrEmpty(imp.hidIdLocalidad)) imp.hidIdLocalidad = "0";
            if (string.IsNullOrEmpty(imp.hidIdLocalidadDelito)) imp.hidIdLocalidadDelito = "0";
            if (string.IsNullOrEmpty(imp.hidIdLocalidadNacimiento)) imp.hidIdLocalidadNacimiento = "0";
            if (string.IsNullOrEmpty(imp.hidIdPartido)) imp.hidIdPartido = "0";
            if (string.IsNullOrEmpty(imp.hidIdPartidoDelito)) imp.hidIdPartidoDelito = "0";
            if (string.IsNullOrEmpty(imp.hidIdModusOperandi)) imp.hidIdModusOperandi = "0";
            if (string.IsNullOrEmpty(imp.hidIdLocalidadPolicial)) imp.hidIdLocalidadPolicial = "0";
            if (string.IsNullOrEmpty(imp.hidIdDependenciaPolicial)) imp.hidIdDependenciaPolicial = "0";
            ////////////////////////////////


            var imputado = id > 0 ? _repository.Set<Imputado>().SingleOrDefault(s => s.Id == imp.Id) : new Imputado();
            if (id == 0)
            {
                imputado.CodigoDeBarrasOriginal = imp.CodBarras;
                imputado.CodigoDeBarras = imp.CodBarras;
                imputado.ProntuarioSIC = imp.CodBarras;
                imputado.FechaCreacionI = DateTime.Now;
                //CAMBIAR!!
                imputado.PuntoGestionCreacionI =
                    _repository.Set<PuntoGestion>().SingleOrDefault(p => p.Id == idPuntoGestion);
                /////////////////
                imputado.Estado = _repository.Set<SICEstadoTramite>().SingleOrDefault(e => e.Id == 9);
            }
            
            imputado.FechaUltimaModificacion = DateTime.Now;

            //DATOS SOMATICOS
            imputado.CejasDimension = _repository.Set<SICClaseCejasDimension>().First(x => x.Id.ToString() == imp.DimensionCeja);
            imputado.CejasTipo = _repository.Set<SICClaseCejasTipo>().First(x => x.Id.ToString() == imp.TipoCeja);
            imputado.ColorCabello = _repository.Set<SICClaseColorCabello>().First(x => x.Id.ToString() == imp.ColorCabellos);
            imputado.ColorOjos = _repository.Set<SICClaseColorOjos>().First(x => x.Id.ToString() == imp.ColorOjos);
            imputado.ColorPiel = _repository.Set<SICClaseColorPiel>().First(x => x.Id.ToString() == imp.ColorPiel);
            imputado.FormaBoca = _repository.Set<SICClaseFormaBoca>().First(x => x.Id.ToString() == imp.FormaBoca);
            imputado.FormaCara = _repository.Set<SICClaseFormaCara>().First(x => x.Id.ToString() == imp.FormaCara);
            imputado.FormaLabioInferior = _repository.Set<SICClaseFormaLabioInferior>().First(x => x.Id.ToString() == imp.FormaLabioInferior);
            imputado.FormaLabioSuperior = _repository.Set<SICClaseFormaLabioSuperior>().First(x => x.Id.ToString() == imp.FormaLabioSuperior);
            imputado.FormaMenton = _repository.Set<SICClaseFormaMenton>().First(x => x.Id.ToString() == imp.FormaMenton);
            imputado.FormaNariz = _repository.Set<SICClaseFormaNariz>().First(x => x.Id.ToString() == imp.FormaNariz);
            imputado.FormaOreja = _repository.Set<SICClaseFormaOreja>().First(x => x.Id.ToString() == imp.FormaOreja);
            imputado.Robustez = _repository.Set<SICClaseRobustez>().First(x => x.Id.ToString() == imp.Robustez);
            imputado.TipoCabello = _repository.Set<SICClaseTipoCabello>().First(x => x.Id.ToString() == imp.TipoCabello);
            imputado.TipoCalvicie = _repository.Set<SICClaseTipoCalvicie>().First(x => x.Id.ToString() == imp.TipoCalvicie);
            imputado.Estatura = imp.Estatura;
            //////////////////////
      
            imputado.OtrosNombres = imp.OtrosNombres;





            if (imputado.Persona == null)
                imputado.Persona = new Persona();
            Localidad localidadNacimiento = null;
            localidadNacimiento = _repository.Set<Localidad>().FirstOrDefault(x => x.Id.ToString() == imp.hidIdLocalidadNacimiento);
            imputado.Persona.Apellido = imp.Apellido;
            imputado.Persona.Nombre = imp.Nombres;
            imputado.Persona.Padre = imp.Padre;
            imputado.Persona.Madre = imp.Madre;
            imputado.Persona.FechaAlta = DateTime.Now;
            imputado.Persona.Telefono = imp.Telefono;
            imputado.Persona.FechaNacimiento = DateTime.ParseExact(imp.FechaNacimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            imputado.Persona.profesion = imp.Profesion;

            imputado.Persona.FechaUltimaModificacion = DateTime.Now;
            imputado.Persona.LocalidadNacimiento = localidadNacimiento;
            imputado.Persona.LugarNacimiento = localidadNacimiento != null ? localidadNacimiento.LocalidadNombre : null;
            imputado.Persona.Nacionalidad = _repository.Set<Pais>().FirstOrDefault(x => x.Id.ToString() == imp.PaisNacimiento);
            imputado.Persona.ProvinciaNacimiento = _repository.Set<Provincia>().FirstOrDefault(x => x.Id.ToString() == imp.ProvinciaNacimiento);
            imputado.Persona.TipoDNI = _repository.Set<ClaseTipoDNI>().First(x => x.Id.ToString() == imp.TipoDocumento);
            imputado.Persona.DocumentoNumero = imp.NumeroDocumento??"";
            imputado.Persona.EstudiosCursados = _repository.Set<ClaseEstudiosCursados>().First(x => x.Id.ToString() == imp.Instruccion);
            imputado.Persona.EstadoCivil = _repository.Set<ClaseEstadoCivil>().First(x => x.Id.ToString() == imp.EstadoCivil);
            imputado.Persona.Conyuge = imp.Conyuge;
            imputado.Persona.Sexo = _repository.Set<ClaseSexo>().First(x => x.Id.ToString() == imp.Sexo);
            imputado.Persona.Direccion = imp.Domicilio;

            if (imputado.Persona.Domicilio == null)
                imputado.Persona.Domicilio = new Domicilio();
            imputado.Persona.Domicilio.Calle = imp.Calle;
            imputado.Persona.Domicilio.EntreCalle = imp.EntreCalle;
            imputado.Persona.Domicilio.EntreCalle2 = imp.EntreCalle2;

            imputado.Persona.Domicilio.Localidad = _repository.Set<Localidad>().FirstOrDefault(x => x.Id.ToString() == imp.hidIdLocalidad);
            imputado.Persona.Domicilio.NroH = imp.NroH;
            imputado.Persona.Domicilio.DeptoH = imp.DeptoH;
            imputado.Persona.Domicilio.PisoH = imp.PisoH;
            imputado.Persona.Domicilio.ParajeBarrioH = imp.ParajeBarrioH;

            imputado.Persona.Domicilio.Partido = _repository.Set<Partido>().FirstOrDefault(x => x.Id.ToString() == imp.hidIdPartido);
            imputado.Persona.Domicilio.Provincia = _repository.Set<Provincia>().FirstOrDefault(x => x.Id.ToString() == imp.Provincia);

      

            if (imputado.Alias == null)
                imputado.Alias = new AutoresAlias();
            imputado.Alias.Alias = imp.Apodos;

            if (imputado.Delito == null)
                imputado.Delito = new Delito
                {
                    FechaAlta = DateTime.Now,
                };
            imputado.Delito.FechaUltimaModificacion = DateTime.Now;
            if (!string.IsNullOrEmpty(imp.hidIdDependenciaPolicial))
            {
                PuntoGestion comisaria = _repository.Set<PuntoGestion>().FirstOrDefault(x => x.Id == imp.hidIdDependenciaPolicial);
                if (comisaria != null)
                    imputado.Delito.Comisaria = comisaria;
            }
            
            imputado.Delito.ModusOperandi = _repository.Set<NNClaseModusOperandi>().FirstOrDefault(x => x.Id.ToString() == imp.hidIdModusOperandi);

            if (imputado.Delito.Ipp == null)
                imputado.Delito.Ipp = new IPP
                {
                    FechaCreacion = DateTime.Now,
                };
            imputado.Delito.Ipp.JuzgadoGarantias = imp.JuzgadoGarantias;
            imputado.Delito.Ipp.TitularUFI = imp.Fiscal;
            imputado.Delito.Ipp.numero = imp.IPP;
            imputado.Delito.Ipp.UFI = imp.UFI;
            imputado.Delito.Ipp.FechaUltimaModificacion = DateTime.Now;
            imputado.Delito.Ipp.caratula = imp.Delito;


            if (imputado.Delito.DescripcionTemporal == null)
                imputado.Delito.DescripcionTemporal = new DescripcionTemporal();
            DateTime fecha = DateTime.ParseExact(imp.FechaDelito, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            imputado.Delito.DescripcionTemporal.FechaDesde = fecha;
            imputado.Delito.DescripcionTemporal.FechaHasta = fecha;
         
            //if (imputado.Delito.Comisaria == null)
            //    imputado.Delito.Comisaria = new Comisaria { };

            //imputado.Delito.Comisaria.ComisariaNombre = imp.DependenciaPolicial;
            //imputado.Delito.Comisaria.Localidad = repository.Set<Localidad>().FirstOrDefault(x => x.Id.ToString() == imp.hidIdLocalidadPolicial);


            //if (id>0)
            //    alias=repository.Set<AutoresAlias>().
            //else
            //alias = new AutoresAlias();
            //alias.Alias = imp.Apodos;
            //alias.Autor = imputado;





            if (imputado.Delito.Domicilio == null)
                imputado.Delito.Domicilio = new Domicilio();
            imputado.Delito.Domicilio.Calle = imp.CalleDelito;
            imputado.Delito.Domicilio.EntreCalle = imp.EntreCalleDelito;
            imputado.Delito.Domicilio.EntreCalle2 = imp.EntreCalle2Delito;
            imputado.Delito.Domicilio.NroH = imp.NroHDelito;
            imputado.Delito.Domicilio.DeptoH = imp.DeptoHDelito;
            imputado.Delito.Domicilio.PisoH = imp.PisoHDelito;
            imputado.Delito.Domicilio.ParajeBarrioH = imp.ParajeBarrioHDelito;
            imputado.Delito.Domicilio.Partido = _repository.Set<Partido>().FirstOrDefault(x => x.Id.ToString() == imp.hidIdPartidoDelito);
            imputado.Delito.Domicilio.Provincia = _repository.Set<Provincia>().FirstOrDefault(x => x.Id.ToString() == imp.ProvinciaDelito);
            imputado.Delito.Domicilio.Localidad = _repository.Set<Localidad>().FirstOrDefault(x => x.Id.ToString() == imp.hidIdLocalidadDelito);

            if (imputado.Persona.FechaNacimiento != null && imputado.Delito.DescripcionTemporal.FechaDesde != null)
            {
                DateTime fechaNac=(DateTime)imputado.Persona.FechaNacimiento;
                DateTime fechaDel=(DateTime)imputado.Delito.DescripcionTemporal.FechaDesde;
                if(fechaDel.Subtract(fechaNac).Days >36000)
                {
                    error = "Error en la fecha de nacimiento o del delito.";
                }
                
                
            }
            

            if (error!="")
            {
                return error;
            }
            if (id > 0)
                    _repository.UnitOfWork.RegisterChanged(imputado);
                else
                    _repository.UnitOfWork.RegisterNew(imputado);
            
            try
            {
                _repository.UnitOfWork.Commit();
                if (id == 0 && imputado.Id>0)
                {
                    Issue<IssueFields> issue = _jiraService.CreateIssue(imputado.CodigoDeBarras);
                    //Transition transition = _jiraService.GetTransitions(issue).First();
                    //_jiraService.TransitionIssue(issue, transition);
                }
              

            }
            catch (Exception e)
            {
                error = e.InnerException.ToString().Substring(0,400);
            }
            return error;
        }

        private void LlenarListas(DatosGeneralesViewModel datosImputado)
        {
            //datosImputado.ComisariaList = new SelectList(repository.Set<PuntoGestion>().AsEnumerable().Select(x => new { id = x.Id, Descripcion = x.Descripcion + ", " + ((x.Localidad == null) ? "" : x.Localidad.LocalidadNombre) + ", " + ((x.Provincia == null) ? "" : x.Provincia.ProvinciaNombre) }), "id", "Descripcion");
            datosImputado.SexoList = new SelectList(_repository.Set<ClaseSexo>().ToList(), "Id", "descripcion", datosImputado.Sexo);
            datosImputado.ProvinciaList = new SelectList(DynamicQueryable.Distinct(_repository.Set<Provincia>().ToList()), "Id", "ProvinciaNombre", datosImputado.Provincia);
            datosImputado.PaisList = new SelectList(_repository.Set<Pais>().ToList(), "Id", "Nacionalidad", datosImputado.PaisNacimiento);
            datosImputado.InstruccionList = new SelectList(_repository.Set<ClaseEstudiosCursados>().ToList(), "Id", "descripcion", datosImputado.Instruccion);
            datosImputado.TipoDocumentoList = new SelectList(_repository.Set<ClaseTipoDNI>().ToList(), "Id", "descripcion", datosImputado.TipoDocumento);
            datosImputado.EstadoCivilList = new SelectList(_repository.Set<ClaseEstadoCivil>().ToList(), "Id", "descripcion", datosImputado.EstadoCivil);
            datosImputado.ColorCabellosList = new SelectList(_repository.Set<SICClaseColorCabello>().ToList(), "Id", "descripcion", datosImputado.ColorCabellos);
            datosImputado.RobustezList = new SelectList(_repository.Set<SICClaseRobustez>().ToList(), "Id", "descripcion", datosImputado.Robustez);
            datosImputado.ColorPielList = new SelectList(_repository.Set<SICClaseColorPiel>().ToList(), "Id", "descripcion", datosImputado.ColorPiel);
            datosImputado.ColorOjosList = new SelectList(_repository.Set<SICClaseColorOjos>().ToList(), "Id", "descripcion", datosImputado.ColorOjos);
            datosImputado.TipoCabelloList = new SelectList(_repository.Set<SICClaseTipoCabello>().ToList(), "Id", "descripcion", datosImputado.TipoCabello);
            datosImputado.TipoCalvicieList = new SelectList(_repository.Set<SICClaseTipoCalvicie>().ToList(), "Id", "descripcion", datosImputado.TipoCalvicie);
            datosImputado.FormaCaraList = new SelectList(_repository.Set<SICClaseFormaCara>().ToList(), "Id", "descripcion", datosImputado.FormaCara);
            datosImputado.DimensionCejaList = new SelectList(_repository.Set<SICClaseCejasDimension>().ToList(), "Id", "descripcion", datosImputado.DimensionCeja);
            datosImputado.TipoCejaList = new SelectList(_repository.Set<SICClaseCejasTipo>().ToList(), "Id", "descripcion", datosImputado.TipoCeja);
            datosImputado.FormaMentonList = new SelectList(_repository.Set<SICClaseFormaMenton>().ToList(), "Id", "descripcion", datosImputado.FormaMenton);
            datosImputado.FormaOrejaList = new SelectList(_repository.Set<SICClaseFormaOreja>().ToList(), "Id", "descripcion", datosImputado.FormaOreja);
            datosImputado.FormaNarizList = new SelectList(_repository.Set<SICClaseFormaNariz>().ToList(), "Id", "descripcion", datosImputado.FormaNariz);
            datosImputado.FormaBocaList = new SelectList(_repository.Set<SICClaseFormaBoca>().ToList(), "Id", "descripcion", datosImputado.FormaBoca);
            datosImputado.FormaLabioInferiorList = new SelectList(_repository.Set<SICClaseFormaLabioInferior>().ToList(), "Id", "descripcion", datosImputado.FormaLabioInferior);
            datosImputado.FormaLabioSuperiorList = new SelectList(_repository.Set<SICClaseFormaLabioSuperior>().ToList(), "Id", "descripcion", datosImputado.FormaLabioSuperior);
            datosImputado.FiscaliaGeneralList = new SelectList(_repository.Set<ClaseDepartamentoJudicial>().ToList(), "Id", "descripcion", datosImputado.FiscaliaGeneral);
        }


    }
}