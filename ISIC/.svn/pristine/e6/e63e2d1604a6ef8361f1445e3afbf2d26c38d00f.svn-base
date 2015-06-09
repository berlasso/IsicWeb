using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPBA.Entities;

namespace ISIC.Entities
{
    public class Partido
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string PartidoNombre { get; set; }

        public virtual Departamento Departamento { get; set; }
        public virtual Provincia Provincia { get; set; }

        public virtual ICollection<Localidad> Localidad { get; set; }

    }
}
