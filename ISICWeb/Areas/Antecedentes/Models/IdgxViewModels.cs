using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISIC.Entities;

namespace ISICWeb.Areas.Antecedentes.Models
{
    class IdgxViewModels
    {
    }

    public class IdgxProntuarioViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Prontuario Policía Federal")]
        [MinLength(3)]
        public string ProntuarioPF { get; set; }

        public string prontuariosic { get; set; }
        [Display(Name = "Tipo de Prontuario")]
        public string TipoProntuarioPF { get; set; }
        [Display(Name = "Tipo de Prontuario")]
        public virtual ClaseProntuarioPoliciaFederal tipoprontuario { get; set; }
        public SelectList TipoProntuarioPFList { get; set; }
        public virtual ICollection<IdgxDatosPersona> DatosPersona { get; set; }
    }

    public class IdgxDatosPersonalesViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Debe contener al menos 3 caracteres")]
        public string Apellido { get; set; }
        public string Apodo { get; set; }
        [Display(Name = "Nro. Documento")]
        public Nullable<long> DocumentoNumero { get; set; }
        [Display(Name = "Fecha Nacimiento")]
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public string Padre { get; set; }
        public string Madre { get; set; }
        [Display(Name = "Fecha Fallecimiento")]
        public Nullable<System.DateTime> FechaFallecimiento { get; set; }
        [Display(Name = "Localidad Nacimiento")]
        public virtual Localidad LocalidadNacimiento { get; set; }
        [Display(Name = "Partido Nacimiento")]
        public virtual Partido PartidoNacimiento { get; set; }
        [Display(Name = "Provincia Nacimiento")]
        public string ProvinciaNacimiento { get; set; }
        [Display(Name = "Nro. Causas Pendientes")]
        public int causaspendientes { get; set; }
        [Display(Name = "Informe Dactiloscópico")]
        public bool InfDac { get; set; }
        [Display(Name = "Informe Nominativo")]
        public bool InfNom { get; set; }
        [Display(Name = "Tipo Documento")]
        public string TipoDNI { get; set; }
        [Display(Name = "Tipo de Prontuario")]

        public IEnumerable<IdgxDetalle> Delitos { get; set; }
        public virtual ClaseProntuarioPoliciaFederal tipoprontuario { get; set; }
        public int idIdgxProntuario { get; set; }
        public SelectList TipoDocumentoList { get; set; }
        public SelectList ProvinciaList { get; set; }

    }

    public class IdgxDelitoViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Causas sin efecto")]
        public int causassinefecto { get; set; }
        [Display(Name = "Tipo de Causa")]
        public string causatipo { get; set; }
        [Display(Name = "Nro. Causa")]
        public string nrocausa { get; set; }
        [Display(Name = "Solicitante")]
        public string solicitante { get; set; }
        [Display(Name = "Secretaría")]
        public string secretaria { get; set; }
        [Display(Name = "Observaciones")]
        public string observaciones { get; set; }
        [Display(Name = "Provisorio")]
        public bool provisorio { get; set; }
        [Display(Name = "Pedido Vigente")]
        public bool pedidovigente { get; set; }
        [Display(Name = "Desde Fecha")]
        public string fechavigente { get; set; }
        [Display(Name = "Resolución")]
        public bool resolucion { get; set; }
        [Display(Name = "En la Fecha")]
        public string fecharesolucion { get; set; }
        [Display(Name = "Nro. de Expediente")]
        public string expedientenro { get; set; }
        [Display(Name = "Publicado")]
        public bool publicado { get; set; }
        [Display(Name = "Pedido Vigente de Pub.")]
        public bool pedidovigentepublicacion { get; set; }
        [Display(Name = "Fecha de Publicación")]
        public string fechapublicacion { get; set; }
        [Display(Name = "Orden del día")]
        public string ordendeldia { get; set; }
        public string CodigoRestriccionPF { get; set; }
        public SelectList CodigoRestriccionList { get; set; }
        public IdgxDatosPersona DatosPersonaIdg { get; set; }
        public int idIdgxdatospersonales { get; set; } //para que una vez que guarde pueda traer el idgxdatopersonal de la view cargadatospersonalesidgx
        public int idIdgxprontuario { get; set; }//para que una vez que guarde pueda traer el idgxdatopersonal de la view cargadatospersonalesidgx

    }


}