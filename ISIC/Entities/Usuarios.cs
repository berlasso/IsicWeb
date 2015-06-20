using MPBA.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIC.Entities
{
    public class Usuarios
    {
        public string id { get; set; }
        public virtual PersonalPoderJudicial PersonalPoderJudicial { get; set; }
        [Display(Name = "Usuario")]
        public string NombreUsuario { get; set; }
        public string ClaveUsuario { get; set; }
        public bool activo { get; set; }
        public virtual GrupoUsuario GrupoUsuario { get; set; }
        public Guid? TokenEnviado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string Dependencia { get; set; }
        public string SubCodBarra { get; set; }

    }
}
