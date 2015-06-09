using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp.Deserializers;

namespace ISICWeb.Areas.Otip.Models
{
    public class WebApiSimpModel
    {
        public string Departamento { get; set; }
        public string Alcance { get; set; }
        public string ClaseCausa { get; set; }
        public int IdClaseCausa { get; set; }
        public int IdDepartamento { get; set; }
        public int IdLocalidad { get; set; }
        public int IdPartido { get; set; }
        public string Idcausa { get; set; }
        public string Localidad { get; set; }
        public string NumeroIPP { get; set; }
        public string Partido { get; set; }
        public string NroCausa { get; set; }
        public List<DelitoSimp> Delitos { get; set; }
        public List<ImputadoSimp> Imputados { get; set; }
        public List<Organismo> Organismos { get; set; } 
    }
    [DeserializeAs(Name = "Delito")]
    public class DelitoSimp
    {
        public string ClaseDelito { get; set; }
        public int IdClaseDelito { get; set; }
        public int Tentativa { get; set; }
    }

    [DeserializeAs(Name = "Imputado")]
    public class ImputadoSimp
    {
        public string Apellido { get; set; }
        public string Apodo { get; set; }
        public string ClaseVinculoPersona { get; set; }
        public int DocumentoNumero { get; set; }
        public string EstadoCivil { get; set; }
        public string EstadoCivilMaterno { get; set; }
        public string EstadoCivilPaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdClaseVinculoPersona { get; set; }
        public string IdPersona { get; set; }
        public string IdVinculoPersona { get; set; }
        public string LugarNacimiento { get; set; }
        public string Madre { get; set; }
        public string Nombre { get; set; }
        public string Padre { get; set; }
        public string Profesion { get; set; }
        public string Sexo { get; set; }
        public int idEstadoCivil { get; set; }
        public int idEstadoCivilMaterno { get; set; }
        public int idEstadoCivilPaterno { get; set; }
    }

    public class Organismo
    {
        public int Baja { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public DateTime FechaEnOrganismo { get; set; }
        public DateTime FechaEnOrganismo1 { get; set; }
        public DateTime FechaUltimaModificacion { get; set; }
        public string Id { get; set; }
        public string IdCausa { get; set; }
        public string IdClasePuntoGestion { get; set; }
        public string IdCreador { get; set; }
        public string IdPuntoGestion { get; set; }
        public string IdUsuarioUltimaModificacion { get; set; }
        public string NumeroCausaEnOrganismo { get; set; }
        public string Titular { get; set; }

    }
}