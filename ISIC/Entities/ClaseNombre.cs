using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPBA.Entities;

namespace ISIC.Entities
{
    /// <summary>
    /// Listado general de nombres femeninos y masculinos 
    /// </summary>
    public class ClaseNombre
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string descripcion { get; set; }
        public virtual ClaseSexo sexo { get; set; }
    }
}
