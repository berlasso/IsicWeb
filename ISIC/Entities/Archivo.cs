using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPBA.Entities;

namespace ISIC.Entities
{
    public class Archivo : Entity
    {
        public string Nombre { get; set; }
        public string Tamano { get; set; }
        public string Descripcion { get; set; }
        /// <summary>
        /// url virtual de la foto
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// url virtual del thumbnail de la foto
        /// </summary>
        public string ThumbUrl { get; set; }
        public DateTime FechaUpload { get; set; }
        public string Uploader { get; set; }
        public virtual ClaseTipoArchivo TipoArchivo { get; set; }
        public virtual Imputado Imputado { get; set; }
        public virtual SeniaParticular SeniaParticular { get; set; }
        public virtual TatuajePersona TatuajePersona { get; set; }

    }
}
