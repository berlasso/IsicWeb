using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.ComponentModel.DataAnnotations;
using MPBA.SIAC.Web.Models;
using System.Web.Mvc;

namespace SIACGral.Models
{
    [MetadataType(typeof(IPPMetadata))]
    public partial class IPP
    {
    
    internal sealed class IPPMetadata
    {
        private IPPMetadata()
        { }
        [Display(Name = "IPP")]
        //[RegularExpressionAttribute("/^[0-9]{0,2}[0-9]{0,2}[0-9]{0,6}[0-9]{0,2}$/")]
        [DisplayFormat(DataFormatString = "{0:D2}-{0:D6}-{0:D2}-{0:D2}")]
        [StringLength(15)]
        [Required(ErrorMessageResourceType = typeof(MPBA.SIAC.Web.Properties.Resources), ErrorMessageResourceName = "Requerido")]
        public string IPP1 { get; set; }
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "")]
        public string numero { get; set; }
        [Display(Name = "Carátula")]
        public string caratula { get; set; }
        public string UFI { get; set; }
        [Display(Name = "Titular de la UFI")]
        public string TitularUFI { get; set; }
        [Display(Name = "Responsable de la UFI")]
        public string ResponsableUFI { get; set; }
        [Display(Name = "Cambio de Radicación")]
        public Nullable<bool> CambioRadicacion { get; set; }
        [Display(Name = "Incompetencia")]
        public Nullable<int> idIncompetencia { get; set; }
        [Display(Name = "Fecha Inicio")]
        public Nullable<System.DateTime> fechaInicio { get; set; }
        [Display(Name = "Fecha Incompetencia")]
        public Nullable<System.DateTime> FechaIncompetencia { get; set; }
        [Display(Name = "Nueva IPP")]
        public string NuevaIPP { get; set; }
        [Display(Name = "Etapa")]
        public Nullable<int> idEtapaIPP { get; set; }
        [Display(Name = "Forma de Inicio")]
        public Nullable<int> idFormaInicio { get; set; }
        [Display(Name = "Referente")]
        public string Referente { get; set; }
        [Display(Name = "Referente")]
        public Nullable<int> idReferente { get; set; }
        [Display(Name = "Estado")]
        public Nullable<int> idEstadoIPP { get; set; }
        public Nullable<bool> Baja { get; set; }
        public string UsuarioUltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public byte[] Version { get; set; }
        [Display(Name = "Tipo de IPP")]
        public int TipoIPP { get; set; }
        [Display(Name = "Denunciante")]
        public string InicioDenunciante { get; set; }
        [Display(Name = "Fecha Etapa")]
        public Nullable<System.DateTime> FechaEtapaIPP { get; set; }
        [Display(Name = "Archivo")]
        public Nullable<bool> Archivo { get; set; }
        [Display(Name = "Tipo de Archivo")]
        public string TipoArchivo { get; set; }
    }
    }
}