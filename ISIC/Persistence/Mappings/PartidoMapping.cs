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
    class PartidoMapping : EntityTypeConfiguration<Partido>
    {
        public PartidoMapping()
        {
            this.ToTable("Partido");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.HasOptional(x => x.Departamento).WithMany(s => s.Partidos).Map(m => m.MapKey("idDepartamento"));
            this.HasOptional(x => x.Provincia).WithMany(s => s.Partido).Map(m => m.MapKey("idProvincia"));
            this.Property(t => t.PartidoNombre).HasColumnName("Partido");
        }
    }
}
