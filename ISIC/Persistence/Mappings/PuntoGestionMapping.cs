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
    class PuntoGestionMapping : EntityTypeConfiguration<PuntoGestion>
    {
        public PuntoGestionMapping()
        {
            //this.ToTable("PuntoGestion");
            //this.HasKey(x => x.Id);
            this.HasOptional(x => x.ClasePuntoGestion).WithMany().Map(m => m.MapKey("idClasePuntoGestion"));
            this.HasOptional(x => x.Localidad).WithMany().Map(m => m.MapKey("idLocalidad"));
            this.HasOptional(x => x.Pais).WithMany().Map(m => m.MapKey("idPais"));
            this.HasOptional(x => x.Departamento).WithMany().Map(m => m.MapKey("idDepartamento"));
            this.HasOptional(x => x.Partido).WithMany().Map(m => m.MapKey("idPartido"));
            this.HasOptional(x => x.Provincia).WithMany().Map(m => m.MapKey("idProvincia"));


        }
    }
}