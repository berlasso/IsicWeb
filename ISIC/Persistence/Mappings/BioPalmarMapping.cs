using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISIC.Entities;

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace ISIC.Persistence.Mappings
{
    class BioPalmarMapping : EntityTypeConfiguration<BioPalmar>
    {
        public BioPalmarMapping()
        {
            this.ToTable("BioPalmar");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
         //   this.HasOptional(x => x.EstadoHuella).WithOptionalDependent().Map(m => m.MapKey("estadoHuella"));
               
        }
    }
}



