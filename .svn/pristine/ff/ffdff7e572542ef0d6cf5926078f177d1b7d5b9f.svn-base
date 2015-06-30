using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ISIC.Entities;
using ISIC.Services;
using MPBA.DataAccess;
using ISICWeb.Areas.Otip.Models;

namespace ISICWeb.Areas.Otip.Models
{
    public class ImputadoService: ISIC.Services.ImputadoService
    {
        private IRepository repository;


        public ImputadoService(IRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public DatosGeneralesViewModel CrearViewModel()
        {
            DatosGeneralesViewModel datosGenerales= new DatosGeneralesViewModel();
            datosGenerales.Id = 0;
            LlenarListas(datosGenerales);
            return datosGenerales;
        }

        public DatosGeneralesViewModel LlenarViewModelConImputado(int id, bool ParaEditar)
        {
            Imputado imputado = repository.Set<Imputado>().FirstOrDefault(s => s.Id == id);
            if (imputado != null)
            {
                Persona persona = imputado.Persona;
                DatosGeneralesViewModel datosImputado = new DatosGeneralesViewModel
                {
                    Id = imputado.Id,
                    CodBarras = imputado.CodigoDeBarras,
                    FechaCarga = imputado.FechaCreacionI.ToString("dd/MM/yyyy"),
                    Apellido = persona.Apellido,
                    Nombres = persona.Nombre,
                    Apodos = imputado.Alias == null ? "" : imputado.Alias.Alias,
                    Padre = persona.Padre??"",
                    Madre = persona.Madre ?? "",
                    Telefono = persona.Telefono,
                    FechaNacimiento =
                        persona.FechaNacimiento == null ? "" : persona.FechaNacimiento.Value.ToString("dd/MM/yyyy"),
                    Profesion = persona.profesion??"",
                    PaisNacimiento = persona.Nacionalidad == null ? "" : persona.Nacionalidad.Id.ToString(),
                    ProvinciaNacimiento =
                        persona.ProvinciaNacimiento == null ? "" : persona.ProvinciaNacimiento.Id.ToString(),
                    TipoDocumento = persona.TipoDNI.Id.ToString(),
                    NumeroDocumento = persona.DocumentoNumero == null ? "" : persona.DocumentoNumero.ToString(),
                    Instruccion = persona.EstudiosCursados == null ? "" : persona.EstudiosCursados.Id.ToString(),
                    EstadoCivil = persona.EstadoCivil == null ? "" : persona.EstadoCivil.Id.ToString(),
                    EsSoloDetalle = !ParaEditar,
                    Conyuge = persona.Conyuge??"",
                    Robustez = imputado.Robustez.Id.ToString(),
                    FormaBoca = imputado.FormaBoca.Id.ToString(),
                    FormaCara = imputado.FormaCara.Id.ToString(),
                    FormaLabioInferior = imputado.FormaLabioInferior.Id.ToString(),
                    FormaLabioSuperior = imputado.FormaLabioSuperior.Id.ToString(),
                    FormaMenton = imputado.FormaMenton.Id.ToString(),
                    FormaNariz = imputado.FormaNariz.Id.ToString(),
                    FormaOreja = imputado.FormaOreja.Id.ToString(),
                    ColorCabellos = imputado.ColorCabello.Id.ToString(),
                    TipoCabello = imputado.TipoCabello.Id.ToString(),
                    DimensionCeja = imputado.CejasDimension.Id.ToString(),
                    TipoCeja = imputado.CejasTipo.Id.ToString(),
                    ColorOjos = imputado.ColorOjos.Id.ToString(),
                    ColorPiel = imputado.ColorPiel.Id.ToString(),
                    TipoCalvicie = imputado.TipoCalvicie.Id.ToString(),
                    IPP = imputado.Delito.Ipp.numero??"",
                    Delito = imputado.Delito.Ipp.caratula,
                    
                    Estatura = imputado.Estatura,
                    FechaDelito = imputado.Delito.DescripcionTemporal.FechaDesde.Value.ToString("dd/MM/yyyy"),
                    FiscaliaGeneral = imputado.CodigoDeBarras == null ? "" : imputado.CodigoDeBarras.Substring(2, 2),
                    Sexo = persona.Sexo == null ? "" : persona.Sexo.Id.ToString(),
                    OtrosNombres = imputado.OtrosNombres??"",
                    Archivos = imputado.Archivos
                };
                bool hayModusOperandi = imputado.Delito.ModusOperandi != null;
                datosImputado.hidIdModusOperandi = hayModusOperandi ? imputado.Delito.ModusOperandi.Id.ToString() : "0";
                datosImputado.ModusOperandi = hayModusOperandi ? imputado.Delito.ModusOperandi.Descripcion : "";

                bool hayLocalidadPolicial = imputado.Delito.Comisaria != null &&
                                            imputado.Delito.Comisaria.Localidad != null;
                
                datosImputado.LocalidadPolicial = hayLocalidadPolicial
                    ? imputado.Delito.Comisaria.Localidad.LocalidadNombre
                    : "";

                datosImputado.hidIdLocalidadPolicial = hayLocalidadPolicial? imputado.Delito.Comisaria.Localidad.Id.ToString(): "0";

                bool hayComisaria = imputado.Delito.Comisaria != null;
                datosImputado.hidIdComisaria = hayComisaria ? imputado.Delito.Comisaria.Id.ToString() : "0";
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
                        Partido partido = repository.Set<Partido>().First(p => p.Id == 0);
                        dom.Partido = partido;
                    }
                    datosImputado.Partido = dom.Partido.PartidoNombre;
                    datosImputado.hidIdPartido = dom.Partido.Id.ToString();

                    bool hayLocalidad = dom.Localidad != null;
                    datosImputado.hidIdLocalidad = hayLocalidad ? dom.Localidad.Id.ToString() : "0";
                    datosImputado.Localidad = hayLocalidad ? dom.Localidad.LocalidadNombre : "";
                    datosImputado.Provincia = dom.Provincia == null ? "0" : dom.Provincia.Id.ToString();

                }

                Domicilio domDelito = imputado.Delito.Domicilio;
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
                        Partido partido = repository.Set<Partido>().First(p => p.Id == 0);
                        domDelito.Partido = partido;
                    }
                    datosImputado.hidIdPartidoDelito = domDelito.Partido.Id.ToString();
                    datosImputado.PartidoDelito = domDelito.Partido.PartidoNombre;

                    bool hayLocalidadDelito = domDelito.Localidad != null;
                    datosImputado.hidIdLocalidadDelito = hayLocalidadDelito ? domDelito.Localidad.Id.ToString() : "0";
                    datosImputado.LocalidadDelito = hayLocalidadDelito ? domDelito.Localidad.LocalidadNombre : "";

                    datosImputado.ProvinciaDelito = domDelito.Provincia == null
                        ? "0"
                        : domDelito.Provincia.Id.ToString();
                }
                IPP ipp = imputado.Delito.Ipp;
                if (ipp != null)
                {
                    datosImputado.Fiscal = imputado.Delito.Ipp.TitularUFI??"";
                    datosImputado.UFI = imputado.Delito.Ipp.UFI??"";
                    datosImputado.JuzgadoGarantias = imputado.Delito.Ipp.JuzgadoGarantias??"";
                }
                this.LlenarListas(datosImputado);

                return datosImputado;
            }
            return null;
        }

        public string GuardarImputadoDesdeViewModel(DatosGeneralesViewModel imp)
        {
            int? id = imp.Id ?? 0;

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
            if (string.IsNullOrEmpty(imp.hidIdComisaria)) imp.hidIdComisaria = "0";
            ////////////////////////////////


            var imputado = id > 0 ? repository.Set<Imputado>().SingleOrDefault(s => s.Id == imp.Id) : new Imputado();
            if (id == 0)
            {
                imputado.CodigoDeBarrasOriginal = imp.CodBarras;
                imputado.CodigoDeBarras = imp.CodBarras;
                imputado.Prontuario = new Prontuario{ProntuarioNro = imp.CodBarras};
                imputado.FechaCreacionI = DateTime.Now;
            }
            
            imputado.FechaUltimaModificacion = DateTime.Now;

            //DATOS SOMATICOS
            imputado.CejasDimension = repository.Set<SICClaseCejasDimension>().First(x => x.Id.ToString() == imp.DimensionCeja);
            imputado.CejasTipo = repository.Set<SICClaseCejasTipo>().First(x => x.Id.ToString() == imp.TipoCeja);
            imputado.ColorCabello = repository.Set<SICClaseColorCabello>().First(x => x.Id.ToString() == imp.ColorCabellos);
            imputado.ColorOjos = repository.Set<SICClaseColorOjos>().First(x => x.Id.ToString() == imp.ColorOjos);
            imputado.ColorPiel = repository.Set<SICClaseColorPiel>().First(x => x.Id.ToString() == imp.ColorPiel);
            imputado.FormaBoca = repository.Set<SICClaseFormaBoca>().First(x => x.Id.ToString() == imp.FormaBoca);
            imputado.FormaCara = repository.Set<SICClaseFormaCara>().First(x => x.Id.ToString() == imp.FormaCara);
            imputado.FormaLabioInferior = repository.Set<SICClaseFormaLabioInferior>().First(x => x.Id.ToString() == imp.FormaLabioInferior);
            imputado.FormaLabioSuperior = repository.Set<SICClaseFormaLabioSuperior>().First(x => x.Id.ToString() == imp.FormaLabioSuperior);
            imputado.FormaMenton = repository.Set<SICClaseFormaMenton>().First(x => x.Id.ToString() == imp.FormaMenton);
            imputado.FormaNariz = repository.Set<SICClaseFormaNariz>().First(x => x.Id.ToString() == imp.FormaNariz);
            imputado.FormaOreja = repository.Set<SICClaseFormaOreja>().First(x => x.Id.ToString() == imp.FormaOreja);
            imputado.Robustez = repository.Set<SICClaseRobustez>().First(x => x.Id.ToString() == imp.Robustez);
            imputado.TipoCabello = repository.Set<SICClaseTipoCabello>().First(x => x.Id.ToString() == imp.TipoCabello);
            imputado.TipoCalvicie = repository.Set<SICClaseTipoCalvicie>().First(x => x.Id.ToString() == imp.TipoCalvicie);
            imputado.Estatura = imp.Estatura;
            //////////////////////
      
            imputado.OtrosNombres = imp.OtrosNombres;





            if (imputado.Persona == null)
                imputado.Persona = new Persona();
            Localidad localidadNacimiento = null;
            localidadNacimiento = repository.Set<Localidad>().First(x => x.Id.ToString() == imp.hidIdLocalidadNacimiento);
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
            imputado.Persona.Nacionalidad = repository.Set<Pais>().First(x => x.Id.ToString() == imp.PaisNacimiento);
            imputado.Persona.ProvinciaNacimiento = repository.Set<Provincia>().First(x => x.Id.ToString() == imp.ProvinciaNacimiento);
            imputado.Persona.TipoDNI = repository.Set<ClaseTipoDNI>().First(x => x.Id.ToString() == imp.TipoDocumento);
            imputado.Persona.DocumentoNumero = imp.NumeroDocumento??"";
            imputado.Persona.EstudiosCursados = repository.Set<ClaseEstudiosCursados>().First(x => x.Id.ToString() == imp.Instruccion);
            imputado.Persona.EstadoCivil = repository.Set<ClaseEstadoCivil>().First(x => x.Id.ToString() == imp.EstadoCivil);
            imputado.Persona.Conyuge = imp.Conyuge;
            imputado.Persona.Sexo = repository.Set<ClaseSexo>().First(x => x.Id.ToString() == imp.Sexo);
            imputado.Persona.Direccion = imp.Domicilio;

            if (imputado.Persona.Domicilio == null)
                imputado.Persona.Domicilio = new Domicilio();
            imputado.Persona.Domicilio.Calle = imp.Calle;
            imputado.Persona.Domicilio.EntreCalle = imp.EntreCalle;
            imputado.Persona.Domicilio.EntreCalle2 = imp.EntreCalle2;

            imputado.Persona.Domicilio.Localidad = repository.Set<Localidad>().First(x => x.Id.ToString() == imp.hidIdLocalidad);
            imputado.Persona.Domicilio.NroH = imp.NroH;
            imputado.Persona.Domicilio.DeptoH = imp.DeptoH;
            imputado.Persona.Domicilio.PisoH = imp.PisoH;
            imputado.Persona.Domicilio.ParajeBarrioH = imp.ParajeBarrioH;

            imputado.Persona.Domicilio.Partido = repository.Set<Partido>().First(x => x.Id.ToString() == imp.hidIdPartido);
            imputado.Persona.Domicilio.Provincia = repository.Set<Provincia>().First(x => x.Id.ToString() == imp.Provincia);

            //Comisaria comisaria = null;
            //if (!string.IsNullOrWhiteSpace(imp.DependenciaPolicial))
            //{
            //    comisaria = id > 0 ? delito.Comisaria : new Comisaria();
            //    comisaria.ComisariaNombre = imp.DependenciaPolicial;
            //}


            if (imputado.Alias == null)
                imputado.Alias = new AutoresAlias();
            imputado.Alias.Alias = imp.Apodos;

            if (imputado.Delito == null)
                imputado.Delito = new Delito
                {
                    FechaAlta = DateTime.Now,
                };
            imputado.Delito.FechaUltimaModificacion = DateTime.Now;

            imputado.Delito.ModusOperandi = repository.Set<NNClaseModusOperandi>().FirstOrDefault(x => x.Id.ToString() == imp.hidIdModusOperandi);

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
            if (imp.hidIdComisaria == "0" && imp.DependenciaPolicial != "") //nueva comisaria
                imputado.Delito.Comisaria = null;
            else
                imputado.Delito.Comisaria = repository.Set<PuntoGestion>().First(c => c.Id.ToString() == imp.hidIdComisaria);
            //if (imputado.Delito.Comisaria == null)
            //    imputado.Delito.Comisaria = new Comisaria { };

            imputado.Delito.Comisaria.Descripcion = imp.DependenciaPolicial;
            imputado.Delito.Comisaria.Localidad = repository.Set<Localidad>().First(x => x.Id.ToString() == imp.hidIdLocalidadPolicial);


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
            imputado.Delito.Domicilio.Partido = repository.Set<Partido>().First(x => x.Id.ToString() == imp.hidIdPartidoDelito);
            imputado.Delito.Domicilio.Provincia = repository.Set<Provincia>().First(x => x.Id.ToString() == imp.ProvinciaDelito);
            imputado.Delito.Domicilio.Localidad = repository.Set<Localidad>().First(x => x.Id.ToString() == imp.hidIdLocalidadDelito);
            
                if (id > 0)
                    repository.UnitOfWork.RegisterChanged(imputado);
                else
                    repository.UnitOfWork.RegisterNew(imputado);
            string error = "";
            try
            {
                repository.UnitOfWork.Commit();
            }
            catch (Exception e)
            {
                error = e.InnerException.ToString().Substring(0,400);
            }
            return error;
        }

        private void LlenarListas(DatosGeneralesViewModel datosImputado)
        {
            datosImputado.SexoList = new SelectList(repository.Set<ClaseSexo>().ToList(), "Id", "descripcion", datosImputado.Sexo);
            datosImputado.ProvinciaList = new SelectList(repository.Set<Provincia>().ToList(), "Id", "ProvinciaNombre", datosImputado.Provincia);
            datosImputado.PaisList = new SelectList(repository.Set<Pais>().ToList(), "Id", "Nacionalidad", datosImputado.PaisNacimiento);
            datosImputado.InstruccionList = new SelectList(repository.Set<ClaseEstudiosCursados>().ToList(), "Id", "descripcion", datosImputado.Instruccion);
            datosImputado.TipoDocumentoList = new SelectList(repository.Set<ClaseTipoDNI>().ToList(), "Id", "descripcion", datosImputado.TipoDocumento);
            datosImputado.EstadoCivilList = new SelectList(repository.Set<ClaseEstadoCivil>().ToList(), "Id", "descripcion", datosImputado.EstadoCivil);
            datosImputado.ColorCabellosList = new SelectList(repository.Set<SICClaseColorCabello>().ToList(), "Id", "descripcion", datosImputado.ColorCabellos);
            datosImputado.RobustezList = new SelectList(repository.Set<SICClaseRobustez>().ToList(), "Id", "descripcion", datosImputado.Robustez);
            datosImputado.ColorPielList = new SelectList(repository.Set<SICClaseColorPiel>().ToList(), "Id", "descripcion", datosImputado.ColorPiel);
            datosImputado.ColorOjosList = new SelectList(repository.Set<SICClaseColorOjos>().ToList(), "Id", "descripcion", datosImputado.ColorOjos);
            datosImputado.TipoCabelloList = new SelectList(repository.Set<SICClaseTipoCabello>().ToList(), "Id", "descripcion", datosImputado.TipoCabello);
            datosImputado.TipoCalvicieList = new SelectList(repository.Set<SICClaseTipoCalvicie>().ToList(), "Id", "descripcion", datosImputado.TipoCalvicie);
            datosImputado.FormaCaraList = new SelectList(repository.Set<SICClaseFormaCara>().ToList(), "Id", "descripcion", datosImputado.FormaCara);
            datosImputado.DimensionCejaList = new SelectList(repository.Set<SICClaseCejasDimension>().ToList(), "Id", "descripcion", datosImputado.DimensionCeja);
            datosImputado.TipoCejaList = new SelectList(repository.Set<SICClaseCejasTipo>().ToList(), "Id", "descripcion", datosImputado.TipoCeja);
            datosImputado.FormaMentonList = new SelectList(repository.Set<SICClaseFormaMenton>().ToList(), "Id", "descripcion", datosImputado.FormaMenton);
            datosImputado.FormaOrejaList = new SelectList(repository.Set<SICClaseFormaOreja>().ToList(), "Id", "descripcion", datosImputado.FormaOreja);
            datosImputado.FormaNarizList = new SelectList(repository.Set<SICClaseFormaNariz>().ToList(), "Id", "descripcion", datosImputado.FormaNariz);
            datosImputado.FormaBocaList = new SelectList(repository.Set<SICClaseFormaBoca>().ToList(), "Id", "descripcion", datosImputado.FormaBoca);
            datosImputado.FormaLabioInferiorList = new SelectList(repository.Set<SICClaseFormaLabioInferior>().ToList(), "Id", "descripcion", datosImputado.FormaLabioInferior);
            datosImputado.FormaLabioSuperiorList = new SelectList(repository.Set<SICClaseFormaLabioSuperior>().ToList(), "Id", "descripcion", datosImputado.FormaLabioSuperior);
        }


    }
}