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
    class PersonalPoderJudicialMapping : EntityTypeConfiguration<PersonalPoderJudicial>
    {
        public PersonalPoderJudicialMapping()
        {
            this.ToTable("PersonalPoderJudicial");
            this.HasKey(x => x.Id);
            this.HasOptional(x => x.PuntoGestion).WithOptionalDependent().Map(m => m.MapKey("idPuntoGestion"));
            this.HasOptional(x => x.Persona).WithOptionalDependent().Map(m => m.MapKey("idPersona"));


        }
    }
}