using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPBA.Entities;

namespace ISIC.Entities
{
    public class Prontuario : Entity
    {
        public string ProntuarioNro { get; set; }
        public virtual ICollection<IdgxProntuario> ProntuariosIdgx { get; set; }
        public virtual ICollection<GNA> DatosGNA { get; set; }
        public virtual ICollection<AFIS> DatosAFIS { get; set; }
    }
}
