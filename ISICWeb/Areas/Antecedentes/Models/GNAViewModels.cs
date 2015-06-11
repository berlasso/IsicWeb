using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISIC.Entities;

namespace ISICWeb.Areas.Antecedentes.Models
{
     class GNAViewModels
    {
    }

    public class GNAViewModel
    {
        public int Id { get; set; }

        private const string RegexFecha =
            @"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$";
       //@"(^(((0[1-9]|[12][0-8])[\/](0[1-9]|1[012]))|((29|30|31)[\/](0[13578]|1[02]))|((29|30)[\/](0[4,6,9]|11)))[\/](19|[2-9][0-9])\d\d$)|(^29[\/]02[\/](19|[2-9][0-9])(00|04|08|12|16|20|24|28|32|36|40|44|48|52|56|60|64|68|72|76|80|84|88|92|96)$)";
        public virtual Prontuario Prontuario { get; set; }
        [Required(ErrorMessage = "El apellido es requerido")]
        [MinLength(2, ErrorMessage = "El apellido no puede tener menos de 2 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚ']+$", ErrorMessage = "Error de tipeo en el apellido")]
        [MaxLength(100, ErrorMessage = "El apellido es demasiado largo")]
        public string Apellido { get; set; }
        [MinLength(2, ErrorMessage = "El nombre no puede tener menos de 2 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚ']+$", ErrorMessage = "Error de tipeo en el nombre")]
        [MaxLength(100, ErrorMessage = "El nombre  es demasiado largo")]
        public string Nombre { get; set; }
        [Display(Name = "Sexo")]
        public string idClaseSexo { get; set; }
        [Display(Name = "Tipo Doducmento")]
        public string idClaseTipoDNI { get; set; }
        [RegularExpression("[0-9]+", ErrorMessage = "El documento sólo puede contener números")]
        [Range(0, 300000000, ErrorMessage = "Nro. de documento fuera de rango")]
        [Display(Name = "Nro. de Documento")]
        public string DocumentoNumero { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        [RegularExpression(RegexFecha, ErrorMessage = "El formato de la fecha de nacimiento es incorrecto")]
        public string FechaNacimiento { get; set; }
        [Display(Name = "Apellido Madre")]
        [MinLength(2, ErrorMessage = "El apellido de la madre no puede tener menos de 2 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚ']+$", ErrorMessage = "Error de tipeo en el apellido de la madre")]
        [MaxLength(100, ErrorMessage = "El apellido de la madre es demasiado largo")]
        public string ApellidoMadre { get; set; }
        public string Generado { get; set; }
        [Display(Name = "Nro. de Legajo")]
        public string NroLegajoGNA { get; set; }
        [Display(Name = "Nro. de Expediente")]
        public string ExpteGNA { get; set; }
        [Display(Name = "Pedido de Captura")]
        public bool Captura { get; set; }
        public bool Vigente { get; set; }
        [Display(Name = "Imp. Salida")]
        public bool ImpSalida { get; set; }
        public string Caratula { get; set; }
        public string Asunto { get; set; }
        [Display(Name = "Juzgado Interviniente")]
        public string Juzgadointerviniente { get; set; }
        public bool Corroborado { get; set; }
        public DateTime? FechaCarga { get; set; }
        [Display(Name = "Fecha de Pedido de Captura")]
        [RegularExpression(RegexFecha, ErrorMessage = "El formato de la fecha de pedido es incorrecto")]
        public string FechaPedido { get; set; }
        public string idUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<bool> Baja { get; set; }
        public string idUsuarioUltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public SelectList ClaseSexoList { get; set; }
        public SelectList ClaseTipoDNIList { get; set; }
        
    }
}