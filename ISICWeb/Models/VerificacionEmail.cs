using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Postal;

namespace ISICWeb.Models
{
    public class VerificacionEmail : Email
    {
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public int Sexo { get; set; }
        public string Dependencia { get; set; }
        public string Email { get; set; }
        public Guid? Token { get; set; }
        public string Departamento { get; set; }
        public string Subject { get; set; }
        public string NombreUsuario { get; set; }
        public bool? UsuarioMPBA { get; set; }
        public string Link { get; set; }
    }
}