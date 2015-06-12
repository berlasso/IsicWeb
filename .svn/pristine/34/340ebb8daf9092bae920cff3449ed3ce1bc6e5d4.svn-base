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
    class AFISMapping : EntityTypeConfiguration<AFIS>
    {
        public AFISMapping ()
        {
            this.ToTable("AFIS");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasOptional(x => x.Sexo).WithMany().Map(m => m.MapKey("idSexo"));
            this.HasOptional(x => x.TipoDNI).WithMany().Map(m => m.MapKey("idTipoDNI"));
        }
    }
}
