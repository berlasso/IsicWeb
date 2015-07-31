using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISIC.Entities;

namespace ISICWeb.Areas.Antecedentes.Models
{
    public class MigracionesViewModel
    {
        private const string RegexFecha =
       @"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2}).?(\d{1,2}:\d{2}:\d{2})?$";

        public int Id { get; set; }
        public virtual Prontuario Prontuario { get; set; }
        [Display(Name = "Fecha de Inicio")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [RegularExpression(RegexFecha, ErrorMessage = "El formato de {0} es incorrecto")]
        //[DataType(DataType.Date)]
        public DateTime? Fechainicio { get; set; }
        [MinLength(2, ErrorMessage = "El {0} no puede tener menos de 2 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑ']+$", ErrorMessage = "Error de tipeo en el {0}")]
        [MaxLength(100, ErrorMessage = "El {0} es demasiado largo")]
        public string Tema { get; set; }
        [MinLength(2, ErrorMessage = "El {0} no puede tener menos de 2 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑ']+$", ErrorMessage = "Error de tipeo en el {0}")]
        [MaxLength(100, ErrorMessage = "El {0} es demasiado largo")]
        public string Titular { get; set; }
        [RegularExpression(RegexFecha, ErrorMessage = "El formato de {0} es incorrecto")]
        [Display(Name = "Fecha de Nacimiento")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FecNacim { get; set; }
        [MinLength(2, ErrorMessage = "El {0} no puede tener menos de 2 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑ']+$", ErrorMessage = "Error de tipeo en el {0}")]
        [MaxLength(100, ErrorMessage = "El {0} es demasiado largo")]
        public virtual Pais Nacionalidad { get; set; }
        [Display(Name = "Nro. Documento")]
        public string DocumentoNumero { get; set; }
        [Display(Name = "Emisor del Documento")]
        public string EmisorDocumento { get; set; }
        public string Domicilio { get; set; }
        [Display(Name = "Nro. Expte. Ajeno")]
        public string NroExpAjeno { get; set; }
        [Display(Name = "Fecha Exp.")]
        [RegularExpression(RegexFecha, ErrorMessage = "El formato de {0} es incorrecto")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaExp { get; set; }
        public string Comentario { get; set; }
        public string Calificacion { get; set; }
        public string NroActoAnio { get; set; }
        [Display(Name = "Delegación")]
        public string Delegacion { get; set; }
        public string Organismo { get; set; }
        [Display(Name = "Profesión")]
        [MinLength(2, ErrorMessage = "El {0} no puede tener menos de 2 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑ']+$", ErrorMessage = "Error de tipeo en el {0}")]
        [MaxLength(100, ErrorMessage = "El {0} es demasiado largo")]
        public string Profesion { get; set; }
        [Display(Name = "Reside Desde")]
        public string ResideDesde { get; set; }
        [Display(Name = "Fecha Radicación")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [RegularExpression(RegexFecha, ErrorMessage = "El formato de {0} es incorrecto")]
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
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [RegularExpression(RegexFecha, ErrorMessage = "El formato de {0} es incorrecto")]
        public DateTime? FechaUltimoIngreso { get; set; }
        [Display(Name = "Tipo Resolución")]
        public string TipoResolucion { get; set; }
        [Display(Name = "Fecha Resolución")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [RegularExpression(RegexFecha, ErrorMessage = "El formato de {0} es incorrecto")]
        public DateTime? FechaResolucion { get; set; }
        [Display(Name = "Nro. Disposición")]
        public string NroDisposicion { get; set; }
        [Display(Name = "Fecha Disposición")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [RegularExpression(RegexFecha, ErrorMessage = "El formato de {0} es incorrecto")]
        public DateTime? FechaDisposicion { get; set; }
        [Display(Name = "Nro. Certificado")]
        public string NroCertificado { get; set; }
        [Display(Name = "Fecha Certificado")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [RegularExpression(RegexFecha, ErrorMessage = "El formato de {0} es incorrecto")]
        public DateTime? FechaCertificado { get; set; }
        [Display(Name = "Nro. Expte. Anterior")]
        public string NroExpedienteAnterior { get; set; }
        [Display(Name = "Fecha Ingreso Sistema")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [RegularExpression(RegexFecha, ErrorMessage = "El formato de {0} es incorrecto")]
        public DateTime? FechaIngresoSistema { get; set; }
        [Display(Name = "Religión")]
        [MinLength(2, ErrorMessage = "El {0} no puede tener menos de 2 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑ']+$", ErrorMessage = "Error de tipeo en el {0}")]
        [MaxLength(100, ErrorMessage = "El {0} es demasiado largo")]
        public string Religion { get; set; }
        [Display(Name = "Policía")]
        public string Policia { get; set; }
        [Display(Name = "Familiar Radicado")]
        [MinLength(2, ErrorMessage = "El {0} no puede tener menos de 2 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑ']+$", ErrorMessage = "Error de tipeo en el {0}")]
        [MaxLength(100, ErrorMessage = "El {0} es demasiado largo")]
        public string FamiliarRadicado { get; set; }
        [Display(Name = "Enf. Familiar")]
        public string EnferFamiliar { get; set; }
        [Display(Name = "Nombre Padre")]
        [MinLength(2, ErrorMessage = "El {0} no puede tener menos de 2 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑ']+$", ErrorMessage = "Error de tipeo en el {0}")]
        [MaxLength(100, ErrorMessage = "El {0} es demasiado largo")]
        public string NombrePadre { get; set; }
        [Display(Name = "Nombre Madre")]
        public string NombreMadre { get; set; }
        [MinLength(2, ErrorMessage = "El {0} no puede tener menos de 2 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑ']+$", ErrorMessage = "Error de tipeo en el {0}")]
        [MaxLength(100, ErrorMessage = "El {0} es demasiado largo")]
        [Display(Name = "Tipo Solicitud")]
        public string TipoSolicitud { get; set; }
        [Display(Name = "Fecha Precaria")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [RegularExpression(RegexFecha, ErrorMessage = "El formato de {0} es incorrecto")]
        public DateTime? FechaPrecaria { get; set; }
        [Display(Name = "Dias Precaria")]
        public string DiasPrecaria { get; set; }
        [Display(Name = "Nro. Ent. Oficios")]
        public string NroEntOficios { get; set; }
        [Display(Name = "Fecha Ent. Oficios")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [RegularExpression(RegexFecha, ErrorMessage = "El formato de {0} es incorrecto")]
        public DateTime? FechaEntOficios { get; set; }
        public virtual ClaseSexo Sexo { get; set; }
        [Display(Name = "Carátula")]
        public string Caratula { get; set; }
        public string idUsuarioCreacion { get; set; }
        [Display(Name = "Estado Civil")]
        public virtual ClaseEstadoCivil EstadoCivil { get; set; }
        [Display(Name = "Tipo Expediente")]
        public virtual ClaseExpedienteMigraciones ExpedienteMigraciones { get; set; }
        [Display(Name = "Tipo Documento")]
        public virtual ClaseTipoDNI TipoDNI { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<bool> Baja { get; set; }
        public string idUsuarioUltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public SelectList ExpedienteList { get; set; }
        public SelectList SexoList { get; set; }
        public SelectList EstadoCivilList { get; set; }
        public SelectList TipoDocList { get; set; }
        public SelectList PaisList { get; set; }
        [Display(Name = "Fecha Informe")]
        [Required]
        public string FechaInforme { get; set; }
    }
}