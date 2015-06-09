﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPBA.Entities;

namespace ISIC.Entities
{
    public class IdgxDetalle : Entity
    {
        public int causassinefecto { get; set; }
        public virtual ClaseCodigoRestriccionPoliciaFederal codigoRestriccion { get; set; }
        public string causatipo { get; set; }
        public string nrocausa { get; set; }
        public string solicitante { get; set; }
        public string secretaria { get; set; }
        public string observaciones { get; set; }
        public bool provisorio { get; set; }
        public bool pedidovigente { get; set; }
        public DateTime? fechavigente { get; set; }
        public bool resolucion { get; set; }
        public DateTime? fecharesolucion { get; set; }
        public string expedientenro { get; set; }
        public bool publicado { get; set; }
        public bool pedidovigentepublicacion { get; set; }
        public DateTime? fechapublicacion { get; set; }
	    public string ordendeldia { get; set; }
        public DateTime? ctlFecCrea { get; set; }
        public DateTime? ctlFecModi { get; set; }
        public string ctlUsuCrea { get; set; }
        public string ctlUsuModi { get; set; }

        public virtual IdgxDatosPersona DatosPersonaIdg { get; set; }
        

    }
}
