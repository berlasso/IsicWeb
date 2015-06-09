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
    class DelitoMapping : EntityTypeConfiguration<Delito>
    {
        public DelitoMapping()
        {
            this.ToTable("Delitos");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Id).HasColumnName("id");
            this.HasOptional(x => x.Domicilio).WithMany().Map(m => m.MapKey("idDomicilio"));
            this.HasOptional(x => x.DescripcionTemporal).WithMany().Map(m => m.MapKey("idDescripcionTemporal"));
            this.HasOptional(x => x.ClaseDelito).WithMany().Map(m => m.MapKey("idClaseDelito"));
            this.HasOptional(x => x.Comisaria).WithMany().Map(m => m.MapKey("idComisariaH"));
            this.HasOptional(x => x.ModusOperandi).WithMany().Map(m => m.MapKey("idClaseModusOperandis"));
            this.HasOptional(x => x.Ipp).WithMany(s => s.Delitos).Map(m => m.MapKey("idIPP"));


        }
    }
}
