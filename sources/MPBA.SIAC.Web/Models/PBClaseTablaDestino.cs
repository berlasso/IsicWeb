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
    
    public partial class PBClaseTablaDestino
    {
        public PBClaseTablaDestino()
        {
            this.Busquedas = new HashSet<Busqueda>();
            this.PBFotos = new HashSet<PBFotos>();
        }
    
        public int Id { get; set; }
        public string Descripcion { get; set; }
    
        public virtual ICollection<Busqueda> Busquedas { get; set; }
        public virtual ICollection<PBFotos> PBFotos { get; set; }
    }
}
