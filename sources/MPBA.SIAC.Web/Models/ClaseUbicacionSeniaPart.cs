//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MPBA.SIAC.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClaseUbicacionSeniaPart
    {
        public ClaseUbicacionSeniaPart()
        {
            this.BusquedaRobosDelitosSexualesSenias = new HashSet<BusquedaRobosDelitosSexualesSenia>();
            this.BusquedaRobosDelitosSexualesTatuajes = new HashSet<BusquedaRobosDelitosSexualesTatuaje>();
            this.SeniasParticulares = new HashSet<SeniasParticulares>();
            this.TatuajesPersonas = new HashSet<TatuajesPersonas>();
        }
    
        public int id { get; set; }
        public string Descripcion { get; set; }
    
        public virtual ICollection<BusquedaRobosDelitosSexualesSenia> BusquedaRobosDelitosSexualesSenias { get; set; }
        public virtual ICollection<BusquedaRobosDelitosSexualesTatuaje> BusquedaRobosDelitosSexualesTatuajes { get; set; }
        public virtual ICollection<SeniasParticulares> SeniasParticulares { get; set; }
        public virtual ICollection<TatuajesPersonas> TatuajesPersonas { get; set; }
    }
}
