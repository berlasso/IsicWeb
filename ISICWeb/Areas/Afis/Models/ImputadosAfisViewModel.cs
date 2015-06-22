using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISICWeb.Areas.Afis.Models
{
    public class ImputadosAfisViewModel
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
        public bool GNA { get; set; }
        [Display(Name = "Mig.")]
        public bool Migraciones { get; set; }
        public bool SPB { get; set; }
    }
}