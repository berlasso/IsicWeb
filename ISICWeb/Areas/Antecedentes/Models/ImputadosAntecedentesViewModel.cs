using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISICWeb.Areas.Antecedentes.Models
{
    public class ImputadosAntecedentesViewModel
    {
        public int Id { get; set; }
        public string ProntuarioSIC { get; set; }
        public string CodigoDeBarras { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string DocumentoNumero { get; set; }
        public string IPP { get; set; }
        public bool IDGx { get; set; }
        public bool AFIS { get; set; }
        public bool PB { get; set; }
        public bool RNR { get; set; }
        public bool GNA { get; set; }
    }
}