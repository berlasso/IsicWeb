using MPBA.Entities;
using ISIC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISIC.Entities
{
    public class SICEstadoTramite
    {
        //deberia registrar el estado del fichaje. Si ya fue cotejado con la base local, con la base AFIS y Completo
         [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
