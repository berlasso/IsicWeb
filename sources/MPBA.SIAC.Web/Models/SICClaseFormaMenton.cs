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
    
    public partial class SICClaseFormaMenton
    {
        public SICClaseFormaMenton()
        {
            this.Autores = new HashSet<Autores>();
        }
    
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Letra { get; set; }
    
        public virtual ICollection<Autores> Autores { get; set; }
    }
}
