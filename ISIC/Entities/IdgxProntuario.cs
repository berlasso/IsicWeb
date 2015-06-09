using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPBA.Entities;

namespace ISIC.Entities
{
    public class IdgxProntuario: Entity
    {
        public string ProntuarioPF { get; set; }
        public virtual ClaseProntuarioPoliciaFederal tipoprontuario { get; set; }
        public virtual Prontuario Prontuario { get; set; }
        public virtual ICollection<IdgxDatosPersona> DatosPersona { get; set; }
        public string idUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<bool> Baja { get; set; }
        public string idUsuarioUltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
    }
}
