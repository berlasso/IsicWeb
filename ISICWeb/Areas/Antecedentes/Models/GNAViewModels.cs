using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISIC.Entities;

namespace ISICWeb.Areas.Antecedentes.Models
{
     class GNAViewModels
    {
    }

    public class GNAViewModel
    {
        public int Id { get; set; }
        public virtual Prontuario Prontuario { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string DocumentoNumero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string ApellidoMadre { get; set; }
        public string Generado { get; set; }
        public string NroLegajoGNA { get; set; }
        public string ExpteGNA { get; set; }
        public bool Captura { get; set; }
        public bool Vigente { get; set; }
        public bool ImpSalida { get; set; }
        public string Caratula { get; set; }
        public string Asunto { get; set; }
        public string Juzgadointerviniente { get; set; }
        public bool Corroborado { get; set; }
        public DateTime FechaCarga { get; set; }
        public DateTime FechaPedido { get; set; }
        public string idUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<bool> Baja { get; set; }
        public string idUsuarioUltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public SelectList ClaseSexoList { get; set; }
        public SelectList ClaseTipoDNIList { get; set; }
        public string idClaseSexo { get; set; }
        public string idClaseTipoDNI { get; set; }
    }
}