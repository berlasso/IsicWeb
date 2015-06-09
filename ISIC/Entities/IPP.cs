using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPBA.Entities;

namespace ISIC.Entities
{
    public class IPP :Entity
    {
        public string numero { get; set; }
        public string caratula { get; set; }
        public string UFI { get; set; }
        public string TitularUFI { get; set; }
        public string ResponsableUFI { get; set; }
        public Nullable<bool> CambioRadicacion { get; set; }
        public Nullable<int> idIncompetencia { get; set; }
        public Nullable<System.DateTime> fechaInicio { get; set; }
        public Nullable<System.DateTime> FechaIncompetencia { get; set; }
        public string NuevaIPP { get; set; }
        public Nullable<int> idEtapaIPP { get; set; }
        public Nullable<int> idFormaInicio { get; set; }
        public string Referente { get; set; }
        public Nullable<int> idReferente { get; set; }
        public Nullable<int> idEstadoIPP { get; set; }
        public Nullable<bool> Baja { get; set; }
        public string JuzgadoGarantias { get; set; }
        public string UsuarioUltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public int TipoIPP { get; set; }
        public string InicioDenunciante { get; set; }
        public Nullable<System.DateTime> FechaEtapaIPP { get; set; }
        public Nullable<bool> Archivo { get; set; }
        public string TipoArchivo { get; set; }
        //public string xxx { get; set; }
        public Nullable<int> idTipoArchivo { get; set; }

        public virtual ICollection<Delito> Delitos { get; set; }
    }
}
