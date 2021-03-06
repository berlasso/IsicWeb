﻿using ISIC.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIC.Persistence.Mappings
{
    public class ImputadoMapping  : EntityTypeConfiguration<Imputado>
    {
        public ImputadoMapping()
        {
            this.ToTable("Imputados");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasOptional(x => x.Estado).WithMany().Map(m => m.MapKey("idEstado"));
            this.HasOptional(x => x.Prontuario).WithMany().Map(m => m.MapKey("idProntuario"));
            this.HasOptional(x => x.PuntoGestionCreacionI).WithMany().Map(m => m.MapKey("idPuntoGestionCreacionI"));
            this.HasOptional(x => x.HuellaPalmar).WithMany().Map(m => m.MapKey("huellaPalmar"));
            

        }
    }
}
