using MPBA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIC.Entities
{
    public class Usuarios
    {
        public string id { get; set; }
        public virtual PersonalPoderJudicial PersonalPoderJudicial { get; set; }
        public string NombreUsuario { get; set; }
        public string ClaveUsuario { get; set; }
        public bool activo { get; set; }
        public virtual GrupoUsuario GrupoUsuario { get; set; }

    }
}
