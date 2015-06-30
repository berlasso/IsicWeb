using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISICWeb.Models
{
    public class UsuarioIsicViewModel
    {
        [Required(ErrorMessage = "El {0} es requerido")]
        [MinLength(2, ErrorMessage = "El {0} no puede tener menos de 2 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚ']+$", ErrorMessage = "Error de tipeo en el {0}")]
        [MaxLength(100, ErrorMessage = "El {0} es demasiado largo")]
        [Display(Name = "Usuario")]
        public string usuario { get; set; }
        [Required(ErrorMessage = "La {0} es requerida")]
        [MinLength(2, ErrorMessage = "La {0} no puede tener menos de 2 letras")]
        [Display(Name = "Contraseña")]
        public string clave { get; set; }

    }
}