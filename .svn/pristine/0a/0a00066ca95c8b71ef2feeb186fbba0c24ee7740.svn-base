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
    public class Provincia
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
    
        public string ProvinciaNombre { get; set; }
    
        public virtual ICollection<Localidad> Localidad { get; set; }
        public virtual ICollection<Partido> Partido { get; set; }
    }
}
