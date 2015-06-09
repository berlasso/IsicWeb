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
    class TatuajePersonaMapping  : EntityTypeConfiguration<TatuajePersona>
    {
        public TatuajePersonaMapping()
        {
            this.ToTable("TatuajesPersona");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasOptional(x => x.ClaseTatuaje).WithMany().Map(m => m.MapKey("idTatuaje"));
            this.HasOptional(x => x.ClaseUbicacionSeniaPart).WithMany().Map(m => m.MapKey("idUbicacionTatuaje"));
            this.HasOptional(x => x.Autor).WithMany(s => s.TatuajesPersonas).Map(m => m.MapKey("idAutor"));
          
        }
    }
}
