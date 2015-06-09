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
    public class ClaseCodBarraPuntoGestion:Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        //Por Ejemplo 01[0201]001234A, el valor seria 0201
        public string SubCodBarra { get; set; }
        public virtual PuntoGestion PuntoGestion { get; set; }
    }
}
