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
    class DepartamentoMapping : EntityTypeConfiguration<Departamento>
    {
        public DepartamentoMapping()
        {
            this.ToTable("Departamento");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DepartamentoNombre).HasColumnName("Departamento");
        }
    }
}
