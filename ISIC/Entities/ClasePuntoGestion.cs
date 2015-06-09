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
    public class ClasePuntoGestion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionCorta { get; set; }

    }
}
