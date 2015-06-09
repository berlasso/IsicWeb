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
    public class UsuariosMapping : EntityTypeConfiguration<Usuarios>
    {
        public UsuariosMapping()
        {
            this.ToTable("Usuarios");
            this.HasKey(x => x.id);
            //this.HasOptional(x => x.Estado).WithOptionalDependent().Map(m => m.MapKey("idEstado"));
            this.HasOptional(x => x.GrupoUsuario).WithMany().Map(m => m.MapKey("idGrupoUsuario"));
            //this.HasOptional(x => x.HuellaPalmar).WithOptionalPrincipal().Map(m => m.MapKey("huellaPalmar"));
            this.HasOptional(x => x.PersonalPoderJudicial).WithOptionalDependent().Map(m => m.MapKey("idPersonalPoderJudicial"));


        }
    }
}
