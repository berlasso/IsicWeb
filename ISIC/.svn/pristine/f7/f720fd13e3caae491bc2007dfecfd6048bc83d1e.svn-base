using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPBA.Entities;

namespace ISIC.Entities
{
    public class Autor : Entity
    {
       
        public string OtraCaracteristica { get; set; }
        
        public Nullable<bool> Baja { get; set; }
        public string idUsuarioUltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public  virtual Persona Persona { get; set; }
        //public virtual DescripcionTemporal DescripcionTemporal { get; set; }
        public virtual SICClaseCejasDimension CejasDimension { get; set; }
        public virtual SICClaseCejasTipo CejasTipo { get; set; }
        public virtual SICClaseColorCabello ColorCabello { get; set; }
        public virtual SICClaseColorOjos ColorOjos { get; set; }
        public virtual SICClaseColorPiel ColorPiel { get; set; }
        public virtual SICClaseFormaBoca FormaBoca { get; set; }
        public virtual SICClaseFormaCara FormaCara { get; set; }
        public virtual SICClaseFormaLabioInferior FormaLabioInferior { get; set; }
        public virtual SICClaseFormaLabioSuperior FormaLabioSuperior { get; set; }
        public virtual SICClaseFormaMenton FormaMenton { get; set; }
        public virtual SICClaseFormaNariz FormaNariz { get; set; }
        public virtual SICClaseFormaOreja FormaOreja { get; set; }
        public virtual SICClaseRobustez Robustez { get; set; }
        public virtual SICClaseEstatura ClaseEstatura { get; set; }
        public virtual SICClaseTipoCabello TipoCabello { get; set; }
        public virtual SICClaseTipoCalvicie TipoCalvicie { get; set; }
        public string OtrosNombres { get; set; }
        public int? Estatura { get; set; }
        public virtual Delito Delito { get; set; }
        public virtual AutoresAlias Alias { get; set; }
        public virtual ICollection<SeniaParticular> SeniasParticulares { get; set; }
        public virtual ICollection<TatuajePersona> TatuajesPersonas { get; set; }
       
    }
}
