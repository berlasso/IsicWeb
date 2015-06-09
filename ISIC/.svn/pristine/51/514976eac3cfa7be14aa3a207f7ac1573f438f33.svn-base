using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISIC.Entities;

namespace ISIC.Persistence.Mappings
{
    class SeniaParticularMapping  : EntityTypeConfiguration<SeniaParticular>
    {
        public SeniaParticularMapping()
        {
            this.ToTable("SeniasParticulares");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Id).HasColumnName("id");
            this.HasOptional(x => x.ClaseSeniaParticular).WithMany().Map(m => m.MapKey("idSeniaParticular"));
            this.HasOptional(x => x.ClaseUbicacionSeniaPart).WithMany().Map(m => m.MapKey("idUbicacionSeniaParticular"));
            this.HasOptional(x => x.Autor).WithMany(s=>s.SeniasParticulares).Map(m => m.MapKey("idAutor"));
            
            
          
        }
    }
}
