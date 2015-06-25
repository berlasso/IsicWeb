using MPBA.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIC.Entities
{
    public class PersonalPoderJudicial
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual PuntoGestion PuntoGestion { get; set; }
        public virtual JerarquiaPoderJudicial JerarquiaPoderJudicial { get; set; }
    }
}
