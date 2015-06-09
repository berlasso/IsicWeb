using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPBA.Entities;

namespace ISIC.Entities
{
    public class Delito: Entity
    {
        
        public Nullable<bool> Baja { get; set; }
        public string idUsuarioUltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public string idUsuarioAlta { get; set; }
        public Nullable<System.DateTime> FechaAlta { get; set; }
        public string MotivoBaja { get; set; }
        public Nullable<System.DateTime> FechaBaja { get; set; }
        /// <summary>
        /// IMPORTANTE: Comisarias traidas de la migracion imposibles de tabular, no guardar nada aca!!! Solo para mostrar, en adelante con nuevo sistema usar campo Comisaria
        /// </summary>
        public string ComisariaMigracion { get; set; }
        public virtual Domicilio Domicilio { get; set; }
        public virtual DescripcionTemporal DescripcionTemporal { get; set; }
        //public virtual NNClaseTipoAutor TipoAutor { get; set; }
        public virtual ClaseDelito ClaseDelito { get; set; }
        public virtual PuntoGestion Comisaria { get; set; }
        public virtual NNClaseModusOperandi ModusOperandi { get; set; }
        public virtual IPP Ipp { get; set; }
        public virtual ICollection<Autor> Autores { get; set; }
    }
}
