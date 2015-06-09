﻿using ISIC.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ISIC.Persistence.Mappings
{
    class AutorMapping : EntityTypeConfiguration<Autor>
    {
        public AutorMapping()
        {
            this.ToTable("Autores");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Id).HasColumnName("id");
            this.HasOptional(x => x.Persona).WithMany().Map(m => m.MapKey ("idPersona"));
            this.HasOptional(x => x.CejasDimension).WithMany().Map(m => m.MapKey("idDimensionCeja"));
            this.HasOptional(x => x.CejasTipo).WithMany().Map(m => m.MapKey("idTipoCeja"));
            this.HasOptional(x => x.ColorCabello).WithMany().Map(m => m.MapKey("idClaseColorCabello"));
            this.HasOptional(x => x.ColorOjos).WithMany().Map(m => m.MapKey("idClaseColorOjos"));
            this.HasOptional(x => x.ColorPiel).WithMany().Map(m => m.MapKey("idClaseColorPiel"));
            this.HasOptional(x => x.FormaCara).WithMany().Map(m => m.MapKey("idClaseFormaCara"));
            this.HasOptional(x => x.FormaLabioInferior).WithMany().Map(m => m.MapKey("idFormaLabioInferior"));
            this.HasOptional(x => x.FormaLabioSuperior).WithMany().Map(m => m.MapKey("idFormaLabioSuperior"));
            this.HasOptional(x => x.FormaMenton).WithMany().Map(m => m.MapKey("idFormaMenton"));
            this.HasOptional(x => x.FormaBoca).WithMany().Map(m => m.MapKey("idFormaBoca"));
            this.HasOptional(x => x.FormaNariz).WithMany().Map(m => m.MapKey("idFormaNariz"));
            this.HasOptional(x => x.FormaOreja).WithMany().Map(m => m.MapKey("idFormaOreja"));
            this.HasOptional(x => x.ClaseEstatura).WithMany().Map(m => m.MapKey("idClaseEstatura"));
            this.HasOptional(x => x.Robustez).WithMany().Map(m => m.MapKey("idClaseRobustez"));
            this.HasOptional(x => x.TipoCabello).WithMany().Map(m => m.MapKey("idClaseTipoCabello"));
            this.HasOptional(x => x.Delito).WithMany(s => s.Autores).Map(m => m.MapKey("idDelito"));
            this.HasOptional(x => x.Alias).WithMany().Map(m => m.MapKey("idAlias"));
            this.HasOptional(x => x.TipoCalvicie).WithMany().Map(m => m.MapKey("idClaseCalvicie"));
         
          
          

        }
    }
}
