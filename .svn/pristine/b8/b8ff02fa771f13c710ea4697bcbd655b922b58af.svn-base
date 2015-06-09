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
    class LocalidadMapping: EntityTypeConfiguration<Localidad>
    {
        public LocalidadMapping()
        {
            this.ToTable("Localidad");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.HasOptional(x => x.Partido).WithMany(s => s.Localidad).Map(m => m.MapKey("Partido"));
            this.HasOptional(x => x.Provincia).WithMany(s => s.Localidad).Map(m => m.MapKey("Provincia"));
            this.Property(t => t.LocalidadNombre).HasColumnName("Localidad");
        }
    }
}
