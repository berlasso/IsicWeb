using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;
using ISIC.Entities;
using ISIC.Persistence.Context;
using ISICWeb.Areas.Otip.Models;
using ISICWeb.Areas.PortalSIC.Models;
using MPBA.DataAccess;
using Imputado = ISIC.Entities.Imputado;

namespace ISICWeb.Areas.PortalSIC.Services
{

    public class BusquedaService
    {
        IRepository _repository;

        public BusquedaService(IRepository repository)
        {
            this._repository = repository;
        }

        public BusquedaViewModel CrearViewModel()
        {
            BusquedaViewModel datosBusqueda = new BusquedaViewModel();
            LlenarListas(datosBusqueda);
            datosBusqueda.BusquedaAvanzada = "0";
            return datosBusqueda;
        }

        private void LlenarListas(BusquedaViewModel datosImputado)
        {
            datosImputado.SexoList = new SelectList(_repository.Set<ClaseSexo>().ToList(), "Id", "descripcion", datosImputado.Sexo);
            datosImputado.ProvinciaList = new SelectList(_repository.Set<Provincia>().ToList(), "Id", "ProvinciaNombre", datosImputado.Provincia);
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

        public IEnumerable<Imputado> BuscarImputados(BusquedaViewModel model, int max,out string querystring)
        {
            //ImputadoService imputadoService=new ISICWeb.Services.ImputadoExtraService(_repository);
            ISICContext dbContext = (ISICContext)_repository.UnitOfWork.Context;
            string apellido = model.Apellido ?? "";
            string nombres = model.Nombres ?? "";
            string ipp = model.IPP ?? "";
            string delito = model.Delito ?? "";
            string fg = Convert.ToInt32(model.FiscaliaGeneral).ToString("00");
            string alias = model.Apodos ?? "";
            Int64 nrodoc = model.NumeroDocumento == null ? 0 : Convert.ToInt64(model.NumeroDocumento);
            string otrosNombres = model.OtrosNombres ?? "";
            string fechaNacimiento = model.FechaNacimiento ?? "";
            string madre = model.Madre ?? "";
            string padre = model.Padre ?? "";
            DateTime? fechaDelitoDesde = model.FechaDelitoDesde == null ? (DateTime?)null : DateTime.ParseExact(model.FechaDelitoDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime? fechaDelitoHasta = model.FechaDelitoHasta == null ? (DateTime?)null : DateTime.ParseExact(model.FechaDelitoHasta, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string profesion = model.Profesion ?? "";
            int sexo = model.Sexo == null ? 0 : Convert.ToInt32(model.Sexo);
            string lugarNacimiento = model.LocalidadNacimiento ?? "";
            int provNacimiento = model.ProvinciaNacimiento == null ? 0 : Convert.ToInt32(model.ProvinciaNacimiento);
            int paisNacimiento = model.PaisNacimiento == null ? 0 : Convert.ToInt32(model.PaisNacimiento);
            string calleImputado = model.Calle ?? "";
            string numeroImputado = model.NroH ?? "";
            int localidadImputado = model.Localidad == null ? 0 : Convert.ToInt32(model.Localidad);
            int partidoImputado = model.Partido == null ? 0 : Convert.ToInt32(model.Partido);
            int provinciaImputado = model.Provincia == null ? 0 : Convert.ToInt32(model.Provincia);
            string calleDelito = model.CalleDelito ?? "";
            string numeroDelito = model.NroHDelito ?? "";
            int localidadDelito = model.LocalidadDelito == null ? 0 : Convert.ToInt32(model.LocalidadDelito);
            int partidoDelito = model.PartidoDelito == null ? 0 : Convert.ToInt32(model.PartidoDelito);
            int provinciaDelito = model.ProvinciaDelito == null ? 0 : Convert.ToInt32(model.ProvinciaDelito);
            int edadDesde = model.EdadDesde == null ? 0 : Convert.ToInt32(model.EdadDesde);
            DateTime? fechaDesde = null;
            if (edadDesde > 0) fechaDesde = DateTime.Now.AddYears(-edadDesde);
            int edadHasta = model.EdadHasta == null ? 0 : Convert.ToInt32(model.EdadHasta);
            DateTime? fechaHasta = null;
            if (edadHasta > 0) fechaHasta = DateTime.Now.AddYears(-edadHasta);
            int colorCabello = model.ColorCabellos == null ? 0 : Convert.ToInt32(model.ColorCabellos);
            int robustez = model.Robustez == null ? 0 : Convert.ToInt32(model.Robustez);
            int colorPiel = model.ColorPiel == null ? 0 : Convert.ToInt32(model.ColorPiel);
            int colorOjos = model.ColorOjos == null ? 0 : Convert.ToInt32(model.ColorOjos);
            int tipoCabello = model.TipoCabello == null ? 0 : Convert.ToInt32(model.TipoCabello);
            int tipoCalvicie = model.TipoCalvicie == null ? 0 : Convert.ToInt32(model.TipoCalvicie);
            int formaCara = model.FormaCara == null ? 0 : Convert.ToInt32(model.FormaCara);
            int dimensionCeja = model.DimensionCeja == null ? 0 : Convert.ToInt32(model.DimensionCeja);
            int tipoCeja = model.TipoCeja == null ? 0 : Convert.ToInt32(model.TipoCeja);
            int formaMenton = model.FormaMenton == null ? 0 : Convert.ToInt32(model.FormaMenton);
            int formaOreja = model.FormaOreja == null ? 0 : Convert.ToInt32(model.FormaOreja);
            int formaNariz = model.FormaNariz == null ? 0 : Convert.ToInt32(model.FormaNariz);
            int formaBoca = model.FormaBoca == null ? 0 : Convert.ToInt32(model.FormaBoca);
            int formaLabioInferior = model.FormaLabioInferior == null ? 0 : Convert.ToInt32(model.FormaLabioInferior);
            int formaLabioSuperior = model.FormaLabioSuperior == null ? 0 : Convert.ToInt32(model.FormaLabioSuperior);
            int estatura = model.Estatura == null ? 0 : Convert.ToInt32(model.Estatura);
            //List<Imputado> aa=null;
            IEnumerable<Imputado> imputados = null;
            string whereString = "";

            if (!string.IsNullOrEmpty(model.CodBarras))
            {

                whereString = String.Format("CodigoDeBarras==\"{0}\"", model.CodBarras);

            }
            else
            {

                
                //busqueda basica
                if (fg != "00") whereString = string.Format("CodigoDeBarras.Substring(2, 2) == \"{0}\" &&", fg);
                if (apellido != "") whereString += string.Format("Persona.Apellido.Contains(\"{0}\") &&", apellido);
                if (nrodoc != 0) whereString += string.Format("Persona.DocumentoNumero=={0} &&", nrodoc);
                if (delito != "") whereString += string.Format("Delito.Ipp.caratula.Contains(\"{0}\") &&", delito);
                if (nombres != "") whereString += string.Format("Persona.Nombre.Contains(\"{0}\") &&", nombres);
                whereString += string.Format("Estado.Id!={0} &&", 9);//no trae los que estan en OTIP
                if (model.BusquedaAvanzada == "1")
                {
                    //busqueda avanzada
                    if (ipp != "") whereString += string.Format("Delito.Ipp.Numero.Contains(\"{0}\") &&", ipp);
                    if (alias != "") whereString += string.Format("Alias.Alias.Contains(\"{0}\") &&", alias);
                    if (madre != "") whereString += string.Format("Persona.Madre.Contains(\"{0}\") &&", madre);
                    if (padre != "") whereString += string.Format("Persona.Padre.Contains(\"{0}\") &&", padre);
                    if (otrosNombres != "")
                        whereString += string.Format("OtrosNombres.Contains(\"{0}\") &&", otrosNombres);
                    if (profesion != "")
                        whereString += string.Format("Persona.profesion.Contains(\"{0}\") &&", profesion);
                    if (sexo != 0) whereString += string.Format("Persona.Sexo.Id=={0} &&", sexo);
                    if (lugarNacimiento != "")
                        whereString += string.Format("Persona.LugarNacimiento.Contains(\"{0}\") &&", lugarNacimiento);
                    if (provNacimiento != 0)
                        whereString += string.Format("Persona.ProvinciaNacimiento.Id=={0} &&", provNacimiento);
                    if (paisNacimiento != 0)
                        whereString += string.Format("Persona.Nacionalidad.Id=={0} &&", paisNacimiento);
                    //domicilio imputado
                    if (calleImputado != "")
                        whereString += string.Format("Persona.Domicilio.Calle.Contains(\"{0}\") &&", calleImputado);
                    if (numeroImputado != "")
                        whereString += string.Format("Persona.Domicilio.NroH.Contains(\"{0}\") &&", numeroImputado);
                    if (localidadImputado != 0)
                        whereString += string.Format("Persona.Domicilio.Localidad.Id=={0} &&", localidadImputado);
                    if (partidoImputado != 0)
                        whereString += string.Format("Persona.Domicilio.Partido.Id=={0} &&", partidoImputado);
                    if (provinciaImputado != 0)
                        whereString += string.Format("Persona.Domicilio.Provincia.Id=={0} &&", provinciaImputado);
                    //domicilio delito
                    //if (calleDelito != "") whereString += string.Format("Delito.Domicilio.Calle.Contains(\"{0}\") &&", calleDelito);
                    //if (numeroDelito != "") whereString += string.Format("Delito.Domicilio.NroH.Contains(\"{0}\") &&", numeroDelito);
                    //if (localidadDelito != 0) whereString += string.Format("Delito.Domicilio.Localidad.Id=={0} &&", localidadDelito);
                    //if (partidoDelito != 0) whereString += string.Format("Delito.Domicilio.Partido.Id=={0} &&", partidoDelito);
                    //if (provinciaDelito != 0) whereString += string.Format("Delito.Domicilio.Provincia.Id=={0} &&", provinciaImputado);
                    //datos somaticos
                    if (robustez != 0) whereString += string.Format("Robustez.Id=={0} &&", robustez);
                    if (colorOjos != 0) whereString += string.Format("ColorOjos.Id=={0} &&", colorOjos);
                    if (colorPiel != 0) whereString += string.Format("ColorPiel.Id=={0} &&", colorPiel);
                    if (colorCabello != 0) whereString += string.Format("ColorCabello.Id=={0} &&", colorCabello);
                    if (tipoCabello != 0) whereString += string.Format("TipoCabello.Id=={0} &&", tipoCabello);
                    if (tipoCalvicie != 0) whereString += string.Format("TipoCalvicie.Id=={0} &&", tipoCalvicie);
                    if (formaCara != 0) whereString += string.Format("FormaCara.Id=={0} &&", formaCara);
                    if (dimensionCeja != 0) whereString += string.Format("CejasDimension.Id=={0} &&", dimensionCeja);
                    if (tipoCeja != 0) whereString += string.Format("tipoCeja.Id=={0} &&", tipoCeja);
                    if (formaMenton != 0) whereString += string.Format("FormaMenton.Id=={0} &&", formaMenton);
                    if (formaOreja != 0) whereString += string.Format("FormaOreja.Id=={0} &&", formaOreja);
                    if (formaNariz != 0) whereString += string.Format("FormaNariz.Id=={0} &&", formaNariz);
                    if (formaBoca != 0) whereString += string.Format("FormaBoca.Id=={0} &&", formaBoca);
                    if (formaLabioInferior != 0)
                        whereString += string.Format("FormaLabioInferior.Id=={0} &&", formaLabioInferior);
                    if (formaLabioSuperior != 0)
                        whereString += string.Format("FormaLabioSuperior.Id=={0} &&", formaLabioSuperior);
                    if (estatura != 0) whereString += string.Format("Estatura.Id=={0} &&", estatura);
                    //if (edadDesde != 0 && edadHasta != 0) whereString += string.Format("DATETIME'{0}' >= Persona.FechaNacimiento && Persona.FechaNacimiento >= DATETIME'{1}' &&", fechaDesde,fechaHasta);
                    if (edadDesde != 0 && edadHasta != 0)
                        whereString += "@0 >= Persona.FechaNacimiento && Persona.FechaNacimiento >= @1 &&";
                    if (fechaDelitoDesde != null && fechaDelitoHasta != null)
                        whereString +=
                            "Delito.DescripcionTemporal.FechaDesde>=@2 && Delito.DescripcionTemporal.FechaDesde<=@3 &&";
                    //    && ((fechaDelitoDesde == null || fechaDelitoHasta == null) || (i.Delito.DescripcionTemporal.FechaDesde != null && (i.Delito.DescripcionTemporal.FechaDesde >= fechaDelitoDesde && i.Delito.DescripcionTemporal.FechaDesde <= fechaDelitoHasta)))

                }
                whereString += "Prontuario.baja!=true";
                if (whereString.EndsWith("&&"))
                    whereString = whereString.Remove(whereString.Length - 2, 2);

                if (string.IsNullOrEmpty(whereString)) whereString = "true";

                imputados = dbContext.Imputado
                    .Where(whereString, fechaDesde, fechaHasta, fechaDelitoDesde, fechaDelitoHasta).OrderBy(x=>x.CodigoDeBarras).Take(max);

                if (model.TipoBusqueda == TipoBusqueda.Fotografias)
                {
                    imputados = dbContext.Imputado
                   .Where(whereString, fechaDesde, fechaHasta, fechaDelitoDesde, fechaDelitoHasta).Where(x => x.Archivos.Count > 0).OrderBy(x => x.CodigoDeBarras).Take(max).ToList();
                }
               
            }
            querystring = whereString;
            return imputados;
        }
    }
}