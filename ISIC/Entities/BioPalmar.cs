using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPBA.Entities;
using ISIC.Entities;
using ISIC.Enums;

namespace ISIC.Entities
{
    public class BioPalmar: Entity
    { 
       
        public string CodigoDeBarra { get; set; }
        public string Imagen { get; set; }
        public ClaseEstadoHuella EstadoHuella  { get; set; }
    }
}
