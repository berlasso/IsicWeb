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
    class DomicilioMapping: EntityTypeConfiguration<Domicilio>
    {
        public DomicilioMapping()
        {
            this.ToTable("Domicilios");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //this.HasOptional(x => x.Localidad).WithOptionalDependent().Map(m => m.MapKey("idLocalidad"));
            //this.HasOptional(x => x.Partido).WithOptionalDependent().Map(m => m.MapKey("idPartido"));
            //this.HasOptional(x => x.Provincia).WithOptionalDependent().Map(m => m.MapKey("idProvincia"));

            //SIN MAPEO: xq si no el insertar nuevo domicilio, solo conserva datos de loc,part y prov para nuevo registro, todos los demas los manda a NULL

            this.HasOptional(x => x.Localidad).WithMany().Map(m => m.MapKey("idLocalidad"));
            this.HasOptional(x => x.Partido).WithMany().Map(m => m.MapKey("idPartido"));
            this.HasOptional(x => x.Provincia).WithMany().Map(m => m.MapKey("idProvincia"));

        }
    }
}
