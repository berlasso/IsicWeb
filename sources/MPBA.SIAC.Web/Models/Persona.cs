//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MPBA.SIAC.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Persona
    {
        public Persona()
        {
            this.PersonaIPPs = new HashSet<PersonaIPP>();
            this.PersonalPoderJudicials = new HashSet<PersonalPoderJudicial>();
            this.SeniasParticulares = new HashSet<SeniasParticulares>();
            this.TatuajesPersonas = new HashSet<TatuajesPersonas>();
            this.PersonaTipoes = new HashSet<PersonaTipo>();
        }
    
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Apodo { get; set; }
        public Nullable<int> idTipoDNI { get; set; }
        public Nullable<int> DocumentoNumero { get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string EMail { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public Nullable<int> Localidad { get; set; }
        public Nullable<int> Partido { get; set; }
        public Nullable<int> idProvincia { get; set; }
        public string idCreador { get; set; }
        public string colegio { get; set; }
        public string Tomo { get; set; }
        public string Folio { get; set; }
        public Nullable<System.DateTime> FechaAlta { get; set; }
        public Nullable<int> PersonalPoderJudicial { get; set; }
        public Nullable<bool> activo { get; set; }
        public Nullable<bool> Muerto { get; set; }
        public Nullable<int> idEstadoCivil { get; set; }
        public string profesion { get; set; }
        public string LugarNacimiento { get; set; }
        public Nullable<int> idNacionalidad { get; set; }
        public string Padre { get; set; }
        public string Madre { get; set; }
        public string ProfesionPadre { get; set; }
        public string ProfesionMadre { get; set; }
        public string Conyuge { get; set; }
        public string NumeroIRNR { get; set; }
        public string NumeroIDAPMS { get; set; }
        public string DefensorParticular { get; set; }
        public Nullable<short> Edad { get; set; }
        public int IdEstadoCivilMaterno { get; set; }
        public int IdEstadoCivilPaterno { get; set; }
        public Nullable<int> idTipoPersona { get; set; }
        public Nullable<int> EstudiosCursados { get; set; }
        public Nullable<int> idSexo { get; set; }
        public byte[] Version { get; set; }
    
        public virtual ClaseEstadoCivil ClaseEstadoCivil { get; set; }
        public virtual ClaseEstadoCivil ClaseEstadoCivilMaterno { get; set; }
        public virtual ClaseEstadoCivil ClaseEstadoCivilPaterno { get; set; }
        public virtual ClaseEstudiosCursados ClaseEstudiosCursados { get; set; }
        public virtual ClaseSexo ClaseSexo { get; set; }
        public virtual Paises Pais { get; set; }
        public virtual ICollection<PersonaIPP> PersonaIPPs { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Provincia Provincia { get; set; }
        public virtual TPClaseTipoDNI TPClaseTipoDNI { get; set; }
        public virtual ICollection<PersonalPoderJudicial> PersonalPoderJudicials { get; set; }
        public virtual ICollection<SeniasParticulares> SeniasParticulares { get; set; }
        public virtual ICollection<TatuajesPersonas> TatuajesPersonas { get; set; }
        public virtual ICollection<PersonaTipo> PersonaTipoes { get; set; }
    }
}