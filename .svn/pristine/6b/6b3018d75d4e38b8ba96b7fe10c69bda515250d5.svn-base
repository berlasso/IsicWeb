using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISIC.Entities;

namespace ISICWeb.Areas.Afis.Models
{
    public class AFISViewModel
    {
        public int Id { get; set; }
        public virtual Prontuario Prontuario { get; set; }
        [Required(ErrorMessage = "El {0} es requerido")]
        [RegularExpression("([0-9]{12})([a-zA-Z])", ErrorMessage = "{0} incorrecto")]
        public string NIF { get; set; } //prontuario de Policía Federal
        public string CTL { get; set; }
        [Display(Name = "Tipo Doducmento")]
        public string idTipoDoc { get; set; }
        [Required(ErrorMessage = "El apellido es requerido")]
        [MinLength(2, ErrorMessage = "El apellido no puede tener menos de 2 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÑñÉÍÓÚ']+$", ErrorMessage = "Error de tipeo en el apellido")]
        [MaxLength(100, ErrorMessage = "El apellido es demasiado largo")]
        public string Apellido { get; set; }
        [MinLength(2, ErrorMessage = "El nombre no puede tener menos de 2 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑ']+$", ErrorMessage = "Error de tipeo en el nombre")]
        [MaxLength(100, ErrorMessage = "El nombre  es demasiado largo")]
        public string Nombre { get; set; }
        [RegularExpression("[0-9]+", ErrorMessage = "El documento sólo puede contener números")]
        [Range(0, 300000000, ErrorMessage = "Nro. de documento fuera de rango")]
        [Display(Name = "Nro. de Documento")]
        public string DNI { get; set; }
        public string Clase { get; set; }
        //public virtual ClaseSexo Sexo { get; set; }
        public string idClaseSexo { get; set; }
        public string idUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<bool> Baja { get; set; }
        public string idUsuarioUltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public SelectList TipoDocList { get; set; }
        public SelectList SexoList { get; set; }
    }
}