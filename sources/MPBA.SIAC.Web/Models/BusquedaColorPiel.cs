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
    
    public partial class BusquedaColorPiel
    {
        public decimal id { get; set; }
        public Nullable<int> idBusqueda { get; set; }
        public Nullable<int> idClaseColorPiel { get; set; }
    
        public virtual Busqueda Busqueda { get; set; }
        public virtual PBClaseColorDePiel PBClaseColorDePiel { get; set; }
    }
}
