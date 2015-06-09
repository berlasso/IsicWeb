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
    class PersonaMapping  : EntityTypeConfiguration<Persona>
    {
        public PersonaMapping()
        {
            this.ToTable("Persona");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //this.Property(x => x.Id).HasColumnName("id");

            this.HasOptional(x => x.TipoDNI).WithMany().Map(m => m.MapKey("idTipoDNI"));
            //this.HasOptional(x => x.TipoDNI).WithOptionalDependent().Map(m => m.MapKey("idTipoDNI"));
            this.HasOptional(x => x.Domicilio).WithMany().Map(m => m.MapKey("idDomicilio"));
            //this.HasOptional(x => x.Domicilio).WithOptionalDependent().Map(m => m.MapKey("idDomicilio"));
            this.HasOptional(x => x.LocalidadNacimiento).WithMany().Map(m => m.MapKey("idLocalidad"));
            //this.HasOptional(x => x.LocalidadNacimiento).WithOptionalDependent().Map(m => m.MapKey("idLocalidad"));
            this.HasOptional(x => x.PartidoNacimiento).WithMany().Map(m => m.MapKey("Partido"));
           // this.HasOptional(x => x.PartidoNacimiento).WithOptionalDependent().Map(m => m.MapKey("Partido"));
            this.HasOptional(x => x.ProvinciaNacimiento).WithMany().Map(m => m.MapKey("idProvinciaNac"));
            this.HasOptional(x => x.ProvinciaNacimiento).WithMany().Map(m => m.MapKey("idProvinciaNac"));
            //this.HasOptional(x => x.ProvinciaNacimiento).WithOptionalDependent().Map(m => m.MapKey("idProvinciaNac"));
            this.HasOptional(x => x.EstadoCivil).WithMany().Map(m => m.MapKey("idEstadoCivil"));
            //this.HasOptional(x => x.Nacionalidad).WithOptionalDependent().Map(m => m.MapKey("idNacionalidad"));
            this.HasOptional(x => x.Nacionalidad).WithMany().Map(m => m.MapKey("idNacionalidad"));
            this.HasOptional(x => x.EstadoCivilMaterno).WithMany().Map(m => m.MapKey("IdEstadoCivilMaterno"));
            //this.HasOptional(x => x.EstadoCivilMaterno).WithOptionalDependent().Map(m => m.MapKey("IdEstadoCivilMaterno"));
            this.HasOptional(x => x.EstadoCivilPaterno).WithMany().Map(m => m.MapKey("IdEstadoCivilPaterno"));
            //this.HasOptional(x => x.EstadoCivilPaterno).WithOptionalDependent().Map(m => m.MapKey("IdEstadoCivilPaterno"));
            this.HasOptional(x => x.TipoPersona).WithOptionalDependent().Map(m => m.MapKey("idTipoPersona"));
            //this.HasOptional(x => x.EstudiosCursados).WithOptionalDependent().Map(m => m.MapKey("EstudiosCursados"));
            this.HasOptional(x => x.EstudiosCursados).WithMany().Map(m => m.MapKey("EstudiosCursados"));
            //this.HasOptional(x => x.Sexo).WithOptionalDependent().Map(m => m.MapKey("idSexo"));
            this.HasOptional(x => x.Sexo).WithMany().Map(m => m.MapKey("idSexo"));
            //this.HasOptional(x => x.Identidad).WithOptionalDependent().Map(m => m.MapKey("idPersonaUnica"));
            this.HasOptional(x => x.Identidad).WithMany().Map(m => m.MapKey("idPersonaUnica"));
            

        }
    }
}
