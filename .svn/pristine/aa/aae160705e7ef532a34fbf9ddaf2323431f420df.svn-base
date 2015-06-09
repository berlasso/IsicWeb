using ISIC.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIC.Persistence.Mappings
{
    class ClaseCodBarraPuntoGestionMapping : EntityTypeConfiguration<ClaseCodBarraPuntoGestion>
    {
        public ClaseCodBarraPuntoGestionMapping()
        {
            this.HasOptional(x => x.PuntoGestion).WithOptionalDependent().Map(m => m.MapKey("idPuntoGestion"));



        }
    }
}