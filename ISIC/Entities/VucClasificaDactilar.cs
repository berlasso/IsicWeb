using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPBA.Entities;

namespace ISIC.Entities
{
    public class VucClasificaDactilar : VucClasifica
    {
        public override string GetSiglaClasificacion()
        {
            return this.Clasificacion.Sigla_Dactilar;
        }
    }
}
