using MPBA.Entities;
using ISIC.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISIC.Enums;

namespace ISIC.Entities
{
    public partial class CotejoRenaper:Entity
    {
        public string CodigoDeBarras { get; set; }
        public string Tcn { get; set; }
        public DateTime? FechaResultado { get; set; }
        public int Resultado { get; set; }
        public int Score { get; set; }

    }
}
