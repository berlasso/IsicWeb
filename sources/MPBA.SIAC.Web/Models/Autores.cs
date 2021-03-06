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
    
    public partial class Autores
    {
        public Autores()
        {
            this.SeniasParticulares = new HashSet<SeniasParticulares>();
            this.TatuajesPersonas = new HashSet<TatuajesPersonas>();
        }
    
        public int id { get; set; }
        public int idDelito { get; set; }
        public string idCausa { get; set; }
        public string Nro { get; set; }
        public Nullable<int> idClaseEdadAproximada { get; set; }
        public Nullable<int> idClaseSexo { get; set; }
        public Nullable<int> idClaseRostro { get; set; }
        public string CubiertoCon { get; set; }
        public string OtraCaracteristica { get; set; }
        public Nullable<bool> Baja { get; set; }
        public string idUsuarioUltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public string idImputadoSimp { get; set; }
        public Nullable<int> idPersona { get; set; }
        public Nullable<int> idClaseEstatura { get; set; }
        public Nullable<int> idClaseRobustez { get; set; }
        public Nullable<int> idClaseColorPiel { get; set; }
        public Nullable<int> idClaseColorOjos { get; set; }
        public Nullable<int> idClaseColorCabello { get; set; }
        public Nullable<int> idClaseTipoCabello { get; set; }
        public Nullable<int> idClaseCalvicie { get; set; }
        public Nullable<int> idClaseFormaCara { get; set; }
        public Nullable<int> idDimensionCeja { get; set; }
        public Nullable<int> idTipoCeja { get; set; }
        public Nullable<int> idFormaMenton { get; set; }
        public Nullable<int> idFormaOreja { get; set; }
        public Nullable<int> idFormaNariz { get; set; }
        public Nullable<int> idFormaBoca { get; set; }
        public Nullable<int> idFormaLabioInferior { get; set; }
        public Nullable<int> idFormaLabioSuperior { get; set; }
        public string idSic { get; set; }
    
        public virtual NNClaseEdadAproximada NNClaseEdadAproximada { get; set; }
        public virtual NNClaseRostro NNClaseRostro { get; set; }
        public virtual NNClaseSexo NNClaseSexo { get; set; }
        public virtual Delito Delito { get; set; }
        public virtual ICollection<SeniasParticulares> SeniasParticulares { get; set; }
        public virtual ICollection<TatuajesPersonas> TatuajesPersonas { get; set; }
        public virtual SICClaseCejasDimension SICClaseCejasDimension { get; set; }
        public virtual SICClaseCejasTipo SICClaseCejasTipo { get; set; }
        public virtual SICClaseColorCabello SICClaseColorCabello { get; set; }
        public virtual SICClaseColorOjos SICClaseColorOjos { get; set; }
        public virtual SICClaseColorPiel SICClaseColorPiel { get; set; }
        public virtual SICClaseEstatura SICClaseEstatura { get; set; }
        public virtual SICClaseFormaBoca SICClaseFormaBoca { get; set; }
        public virtual SICClaseFormaCara SICClaseFormaCara { get; set; }
        public virtual SICClaseFormaLabioInferior SICClaseFormaLabioInferior { get; set; }
        public virtual SICClaseFormaLabioSuperior SICClaseFormaLabioSuperior { get; set; }
        public virtual SICClaseFormaMenton SICClaseFormaMenton { get; set; }
        public virtual SICClaseFormaNariz SICClaseFormaNariz { get; set; }
        public virtual SICClaseFormaOreja SICClaseFormaOreja { get; set; }
        public virtual SICClaseRobustez SICClaseRobustez { get; set; }
        public virtual SICClaseTipoCabello SICClaseTipoCabello { get; set; }
        public virtual SICClaseTipoCalvicie SICClaseTipoCalvicie { get; set; }
    }
}
