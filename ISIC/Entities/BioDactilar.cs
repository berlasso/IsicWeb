using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPBA.Entities;
using ISIC.Enums;

namespace ISIC.Entities
{
   public class BioDactilar :Entity
    {
       public string CodigoDeBarra { get; set; }
       public byte[] imagen { get; set; }
       public ClaseMano Mano { get; set; }
       public ClaseDedo Dedo { get; set; }
       public ClaseEstadoDedo EstadoDedo { get; set; }
     /*Tener en cuenta que VucClasifica es generica si es pulgar se debera usar VucClasificaPulgar si no VucClasificaDactilar*/
       public virtual VucClasifica DactilarVuc { get; set; }
       public string idUsuarioDigitaliza { get; set; }
       public string idUsuarioClasifica { get; set; }
       public string idUsuarioSubClasifica { get; set; }
       
       public Nullable<System.DateTime> FechaDigital { get; set; }
       public Nullable<System.DateTime> FechaClasificacion { get; set; }
       public Nullable<System.DateTime> FechaSubClasificacion { get; set; }
       public Nullable<bool> Baja { get; set; }
       
       
    }
}
