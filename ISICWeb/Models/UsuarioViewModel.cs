using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISIC.Entities;


namespace ISICWeb.Models
{
    public class UsuarioViewModel
    {

        public string id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Documento Nro.")]
        [Range(0, int.MaxValue, ErrorMessage = "Número de documento incorrecto")]
        public string DocumentoNumero { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [MinLength(2, ErrorMessage = "El nombre no puede tener menos de 2 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚ']+$", ErrorMessage = "Error en el {0}")]
        [MaxLength(100, ErrorMessage = "El nombre  es demasiado largo")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido es requerido")]
        [MinLength(2, ErrorMessage = "El apellido no puede tener menos de 2 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚ']+$", ErrorMessage = "Error en el {0}")]
        [MaxLength(100, ErrorMessage = "El apellido es demasiado largo")]
        public string Apellido { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z]*$")]
        [Display(Name = "Usuario")]
        public string NombreUsuario { get; set; }
        public bool activo { get; set; }
        public string Dependencia { get; set; }
        public virtual GrupoUsuario GrupoUsuario { get; set; }
        public SelectList GrupoUsuarioList { get; set; }
        //public SelectList PuntoGestionList { get; set; }
        public SelectList DepartamentoList { get; set; }
        public SelectList SexoList { get; set; }
        public SelectList JerarquiaList { get; set; }
        [Required]
        public virtual PuntoGestion PuntoGestion { get; set; }
        [Required]
        public virtual Departamento Departamento { get; set; }
        public virtual ClaseSexo Sexo { get; set; }
        public virtual JerarquiaPoderJudicial Jerarquia { get; set; }
        public string SubCodBarra { get; set; }
        public bool Validando { get; set; }
        [Display(Name = "Usuario MPBA")]
        public bool UsuarioMPBA { get; set; }
        [Display(Name = "Email Confirmado")]
        public bool? EmailConfirmed { get; set; }
        //[Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string ClaveUsuario { get; set; }
        public virtual PersonalPoderJudicial PersonalPoderJudicial { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [System.ComponentModel.DataAnnotations.Compare("ClaveUsuario", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmarClaveUsuario { get; set; }
        public string code { get; set; }
        public string UsuarioSicViejo { get; set; }
    }
}