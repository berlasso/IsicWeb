using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPBA.Entities;

namespace ISIC.Entities
{
    public partial class Migraciones : Entity
    {
        public virtual Prontuario Prontuario { get; set; }
        [Display(Name = "Expediente")]
        public virtual ClaseExpedienteMigraciones ExpedienteMigraciones { get; set; }
        [Display(Name = "Fecha de Inicio")]
        public DateTime? Fechainicio { get; set; }
        public string Tema { get; set; }
        public string Titular { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? FecNacim { get; set; }
        public virtual ClaseSexo Sexo { get; set; }
        [Display(Name = "Estado Divil")]
        public virtual ClaseEstadoCivil EstadoCivil { get; set; }
        public virtual Pais Nacionalidad { get; set; }
        [Display(Name = "Tipo Documento")]
        public virtual ClaseTipoDNI TipoDNI { get; set; }
        [Display(Name = "Nro. Documento")]
        public string DocumentoNumero { get; set; }
        [Display(Name = "Emisor del Documento")]
        public string EmisorDocumento { get; set; }
        public string Domicilio { get; set; }
        [Display(Name = "Nro. Expte. Ajeno")]
        public string NroExpAjeno { get; set; }
        [Display(Name = "Fecha Exp.")]
        public DateTime? FechaExp { get; set; }
        public string Comentario { get; set; }
        public string Calificacion { get; set; }
        public string NroActoAnio { get; set; }
        [Display(Name = "Delegación")]
        public string Delegacion { get; set; }
        public string Organismo { get; set; }
        [Display(Name = "Profesión")]
        public string Profesion { get; set; }
        [Display(Name = "Reside Desde")]
        public string ResideDesde { get; set; }
        [Display(Name = "Fecha Radicación")]
	    public DateTime? FechaRadica { get; set; }
        [Display(Name = "Nro. Expediente")]
        public string NroExpediente { get; set; }
        [Display(Name = "Tipo Justicia")]
        public string TipoJusticia { get; set; }
        [Display(Name = "Localidad Justicia")]
        public virtual Localidad LocalidadJusticia { get; set; }
        public string Observaciones { get; set; }
        [Display(Name = "Nro. Causa")]
        public string NroCausa { get; set; }
        [Display(Name = "Juzgado Txt.")]
        public string JuzgadoTxt { get; set; }
        [Display(Name = "Motivo Causa")]
        public string MotivoCausa { get; set; }
        [Display(Name = "Juez de la Causa")]
        public string JuezCausa { get; set; }
        [Display(Name = "Plazo Causa")]
        public string PlazoCausaMD { get; set; }
        [Display(Name = "Tipo Restricción")]
        public string TipoRestriccion { get; set; }
        public string Instancia { get; set; }
        [Display(Name = "Desc. Causa")]
        public string DescCausa { get; set; }
        [Display(Name = "Instrucción")]
        public string Instruccion { get; set; }
        [Display(Name = "Lugar Inicio")]
        public string LugarInicio { get; set; }
        [Display(Name = "País Embarque")]
	    public virtual Pais PaisEmbarque { get; set; }
        [Display(Name = "Lugar Entrada")]
        public string LugarEntrada { get; set; }
        [Display(Name = "Fecha Ultimo Ingreso")]
        public DateTime? FechaUltimoIngreso { get; set; }
        [Display(Name = "Tipo Resolución")]
        public string TipoResolucion { get; set; }
        [Display(Name = "Fecha Resolución")]
        public DateTime? FechaResolucion { get; set; }
        [Display(Name = "Nro. Disposición")]
        public string NroDisposicion { get; set; }
        [Display(Name = "Fecha Disposición")]
        public DateTime? FechaDisposicion { get; set; }
        [Display(Name = "Nro. Certificado")]
        public string NroCertificado { get; set; }
        [Display(Name = "Fecha Certificado")]
        public DateTime? FechaCertificado { get; set; }
        [Display(Name = "Nro. Expte. Anterior")]
        public string NroExpedienteAnterior { get; set; }
        [Display(Name = "Fecha Ingreso Sistema")]
        public DateTime? FechaIngresoSistema { get; set; }
        [Display(Name = "Religión")]
        public string Religion { get; set; }
        [Display(Name = "Policía")]
        public string Policia { get; set; }
        [Display(Name = "Familiar Radicado")]
        public string FamiliarRadicado { get; set; }
        [Display(Name = "Enf. Familiar")]
        public string EnferFamiliar { get; set; }
        [Display(Name = "Nombre Padre")]
        public string NombrePadre { get; set; }
        [Display(Name = "Nombre Madre")]
        public string NombreMadre { get; set; }
        [Display(Name = "Tipo Solicitud")]
        public string TipoSolicitud { get; set; }
        [Display(Name = "Fecha Precaria")]
        public DateTime? FechaPrecaria { get; set; }
        [Display(Name = "Dias Precaria")]
        public string DiasPrecaria { get; set; }
        [Display(Name = "Nro. Ent. Oficios")]
        public string NroEntOficios { get; set; }
        [Display(Name = "Fecha Ent. Oficios")]
        public DateTime? FechaEntOficios { get; set; }
        [Display(Name = "Carátula")]
        public string Caratula { get; set; }
        public string idUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<bool> Baja { get; set; }
        public string idUsuarioUltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
    }
}
