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
    
    public partial class BusquedaRobosDelitosSexualesComisaria
    {
        public int id { get; set; }
        public Nullable<int> idBusquedaRoboDS { get; set; }
        public Nullable<int> idComisaria { get; set; }
    
        public virtual BusquedaRobosDelitosSexuale BusquedaRobosDelitosSexuale { get; set; }
    }
}
