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
    
    public partial class BusquedaPrincipal
    {
        public BusquedaPrincipal()
        {
            this.VinculoMenuBusquedaPrincipals = new HashSet<VinculoMenuBusquedaPrincipal>();
        }
    
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Campo { get; set; }
        public string Tabla { get; set; }
        public string Tipo { get; set; }
        public string IdPadre { get; set; }
        public Nullable<int> Orden { get; set; }
        public string Qry { get; set; }
    
        public virtual ICollection<VinculoMenuBusquedaPrincipal> VinculoMenuBusquedaPrincipals { get; set; }
    }
}
