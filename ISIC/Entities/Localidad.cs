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
    public class Localidad
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string LocalidadNombre { get; set; }
        public string CodigoPostal { get; set; }

        public virtual Partido Partido { get; set; }
        public virtual Provincia Provincia { get; set; }
    }
}
