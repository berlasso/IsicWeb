using MPBA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPBA.Entities;

namespace ISIC.Entities
{
    public class ImputadoEstadoTramite : Entity
    {
        public string CodigoDeBarra { get; set; }
        public virtual SICEstadoTramite Estado { get; set; }//Fichado, Cotejado, CotejadoAFIS, InformeGendarmeria, InformeLiberados, InformeMigraciones, InformePolBon, InformeIDG, InformeReincidencia, EntregaInforme, Archivado
        public string Operador { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<bool> Baja { get; set; }
        public string OperadorBaja { get; set; }
        public Nullable<System.DateTime> FechaBaja { get; set; }
    }
}
