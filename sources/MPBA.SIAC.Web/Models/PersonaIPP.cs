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
    
    public partial class PersonaIPP
    {
        public int id { get; set; }
        public int idIPP { get; set; }
        public int idPersona { get; set; }
    
        public virtual IPP IPP { get; set; }
        public virtual Persona Persona { get; set; }
    }
}
