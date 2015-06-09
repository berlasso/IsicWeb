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
    class ArchivoMapping : EntityTypeConfiguration<Archivo>
    {
        public ArchivoMapping()
        {
            this.ToTable("Archivo");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasOptional(x => x.TipoArchivo).WithMany().Map(m => m.MapKey("idTipoArchivo"));
            //this.HasOptional(x => x.Imputado).WithOptionalDependent().Map(m => m.MapKey("idImputado"));
            this.HasOptional(x => x.SeniaParticular).WithOptionalDependent().Map(m => m.MapKey("idSeniaParticular"));
            this.HasOptional(x => x.TatuajePersona).WithOptionalDependent().Map(m => m.MapKey("idTatuajePersona"));
            


        }
    }
}
