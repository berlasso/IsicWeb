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
    
    public partial class PBFotos
    {
        public int id { get; set; }
        public int idPersona { get; set; }
        public int idTablaDestino { get; set; }
        public byte[] Foto { get; set; }
        public int idTipoFoto { get; set; }
    
        public virtual PBClaseFoto PBClaseFoto { get; set; }
        public virtual PBClaseTablaDestino PBClaseTablaDestino { get; set; }
    }
}
