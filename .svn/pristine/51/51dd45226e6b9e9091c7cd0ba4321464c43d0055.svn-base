using MPBA.Entities;
using ISIC.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISIC.Enums;

namespace ISIC.Entities
{
    public partial class Imputado : Autor
    {
        public string ProntuarioSIC { get; set; }
        public string CodigoDeBarrasOriginal { get; set; }
        [Index(IsUnique = true)]
        [MaxLength(13)] // 
        public string CodigoDeBarras { get; set; } //Codigo de barra único que reemplaza el original de la OTIP cuando se refunde el expediente por pertenecer al mismo imputado en la misma IPP
        public Nullable<int> idNroCarpeta { get; set; }
        public Nullable<int> ExisteOficio { get; set; }
        public Nullable<int> ExisteMonodactilar { get; set; }
        public Nullable<int> ExisteDecadactilar { get; set; }
        public Nullable<int> ExistePalmar { get; set; }
        public Nullable<int> InformePoliciaBonaerense { get; set; }
        public Nullable<int> InformeReincidencia { get; set; }
        public Nullable<int> InformeGendarmeria { get; set; }
        public Nullable<int> InformePrefectura { get; set; }
        public Nullable<int> InformeServicioPenitenciario { get; set; }
        public Nullable<int> InformePoliciaFederal { get; set; }
        public Nullable<int> Informado { get; set; }
        public Nullable<int> corroboradoRenaper { get; set; }
        public DateTime FechaCreacionI { get; set; }
        public string UsuarioCreacionI { get; set; }
        public string UsuarioAsignadoI { get; set; }
        /// <summary>
        /// PuntoGestion que dio el alta al legajo
        /// </summary>
        public virtual PuntoGestion PuntoGestionCreacionI { get; set; }
        /// <summary>
        /// IMPORTANTE: Exclusivamente indica datos importantes de la migracion de la base vieja
        /// </summary>
        public string ObservacionesMigracion { get; set; }
        public virtual SICEstadoTramite Estado { get; set; }
        /*La Mano faltante, enyesada esta relacionado con el imputado, independiente del tipo de Huella*/
        public virtual ClaseEstadoMano ManoDerecha { get; set; }
        public virtual ClaseEstadoMano ManoIzquierda { get; set; }
        public virtual BioPalmar HuellaPalmar { get; set; }
        public virtual ICollection<ImputadoEstadoTramite> ImputadoestadosTramites { get; set; }
        public virtual ICollection<BioDactilar> BioManoDerecha { get; set; }
        public virtual ICollection<BioDactilar> BioManoIzquierda { get; set; }
        public virtual ICollection<Archivo> Archivos { get; set; } 

    }
}
