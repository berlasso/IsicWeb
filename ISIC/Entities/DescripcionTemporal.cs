using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPBA.Entities;

namespace ISIC.Entities
{
    public class DescripcionTemporal: Entity
    {
        public Nullable<int> idClaseFecha { get; set; }
        public Nullable<System.DateTime> FechaDesde { get; set; }
        public Nullable<System.DateTime> FechaHasta { get; set; }
        public Nullable<int> idClaseHora { get; set; }
        public string HoraDesde { get; set; }
        public string HoraHasta { get; set; }
        public Nullable<int> idClaseMomentoDelDia { get; set; }

        
    }
}
