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
    
    public partial class ClaseSexo
    {
        public ClaseSexo()
        {
            this.Personas = new HashSet<Persona>();
        }
    
        public int id { get; set; }
        public string Descripcion { get; set; }
        public byte[] Version { get; set; }
    
        public virtual ICollection<Persona> Personas { get; set; }
    }
}
