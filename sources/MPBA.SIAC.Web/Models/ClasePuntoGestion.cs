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
    
    public partial class ClasePuntoGestion
    {
        public ClasePuntoGestion()
        {
            this.PuntoGestions = new HashSet<PuntoGestion>();
        }
    
        public string id { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionCorta { get; set; }
        public Nullable<bool> PermiteDenuncia { get; set; }
        public Nullable<int> ordenMuestra { get; set; }
        public Nullable<int> UsuarioDelSistema { get; set; }
        public Nullable<int> idMinisterio { get; set; }
        public string idClaseCategoria { get; set; }
        public Nullable<int> UsaFicha { get; set; }
        public Nullable<int> UsaPapeles { get; set; }
    
        public virtual ICollection<PuntoGestion> PuntoGestions { get; set; }
    }
}
