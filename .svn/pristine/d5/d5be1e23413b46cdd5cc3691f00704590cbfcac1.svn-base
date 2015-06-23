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
    class MigracionesMapping : EntityTypeConfiguration<Migraciones>
    {
        public MigracionesMapping ()
        {
            this.ToTable("Migraciones");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasOptional(x => x.ExpedienteMigraciones).WithMany().Map(m => m.MapKey("idExpedienteMigraciones"));
            this.HasOptional(x => x.PaisEmbarque).WithMany().Map(m => m.MapKey("idPaisEmbarque"));
            this.HasOptional(x => x.Sexo).WithMany().Map(m => m.MapKey("idSexo"));
            this.HasOptional(x => x.EstadoCivil).WithMany().Map(m => m.MapKey("idEstadoCivil"));
            this.HasOptional(x => x.TipoDNI).WithMany().Map(m => m.MapKey("idTipoDNI"));
        }
    }
}
