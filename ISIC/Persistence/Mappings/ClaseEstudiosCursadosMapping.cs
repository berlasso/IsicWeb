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
    class ClaseEstudiosCursadosMapping : EntityTypeConfiguration<ClaseEstudiosCursados>
    {
        public ClaseEstudiosCursadosMapping()
        {
            this.ToTable("ClaseEstudiosCursados");
            this.HasKey(x => x.Id);
            //this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Id).HasColumnName("id");




        }
    }
}