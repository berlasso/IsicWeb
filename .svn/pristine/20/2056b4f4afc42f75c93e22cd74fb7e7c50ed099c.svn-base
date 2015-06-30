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
    public class PuntoGestion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public virtual ClasePuntoGestion ClasePuntoGestion { get; set; }
        [Display(Name = "Dependencia")]
        public string Descripcion { get; set; }
        public int? Numero { get; set; }
        //public int? Externo { get; set; }
        public virtual Provincia Provincia { get; set; }
        public virtual  Pais Pais { get; set; }
        public virtual Localidad Localidad { get; set; }
        public virtual Partido Partido { get; set; }
        public string Direccion { get; set; }
        public string Telefonos { get; set; }
        //public string OrdenMuestra { get; set; }
        public string titular { get; set; }
        public virtual Departamento Departamento { get; set; }


    }

}
 