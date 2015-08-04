using ISIC.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ISICWeb.Models
{

 /*   public partial class ImputadoViewModel 
    {
        public string ProntuarioSIC { get; set; }
        public string CodigoDeBarra { get; set; }
        public string CodigoDeBarraNuevo { get; set; } //Codigo de barra único que reemplaza el original de la OTIP cuando se refunde el expediente por pertenecer al mismo imputado en la misma IPP
        public int idNroCarpeta { get; set; }
        public int ExisteOficio { get; set; }
        public int ExisteMonodactilar { get; set; }
        public int ExisteDecadactilar { get; set; }
        public int ExistePalmar { get; set; }
        public int InformePoliciaBonaerense { get; set; }
        public int InformeReincidencia { get; set; }
        public int InformeGendarmeria { get; set; }
        public int InformePrefectura { get; set; }
        public int  InformeServicioPenitenciario { get; set; }
        public int InformePoliciaFederal { get; set; }
        public int Informado { get; set; }
        public int corroboradoRenaper { get; set; }
        public <System.DateTime> FechaCreacionI { get; set; }
        public string UsuarioCreacionI { get; set; }
        public virtual SICEstadoTramite Estado { get; set; }
       
        public virtual ClaseEstadoMano ManoDerecha { get; set; }
        public virtual ClaseEstadoMano ManoIzquierda { get; set; }
        public virtual BioPalmar HuellaPalmar { get; set; }
        public virtual ICollection<ImputadoEstadoTramite> ImputadoestadosTramites { get; set; }
        public virtual ICollection<BioDactilar> BioManoDerecha { get; set; }
        public virtual ICollection<BioDactilar> BioManoIzquierda { get; set; }

    }
*/
    public class ClasificacionViewModel
    {
        public string CodigoDeBarra { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string archivoDecaDactilar { get; set; }
        public ICollection<BioDactilarViewModel> BioManoDerecha { get; set; }
        public ICollection<BioDactilarViewModel> BioManoIzquierda { get; set; }
    }

    public class BioDactilarViewModel
    {
        public int Id { get; set; }
        public string CodigoDeBarra { get; set; }
        public byte[] imagen { get; set; }
        public ClaseMano? Mano { get; set; }
        public ClaseDedo? Dedo { get; set; }
        public ClaseEstadoDedo EstadoDedo { get; set; }
        public ClaseEstadoHuella EstadoHuellaDedo { get; set; }
        public VucClasificaViewModel DactilarVuc { get; set; }
        public VucClasificaViewModel SubDactilarVuc { get; set; }
        public BioDactilarPosViewModel DactilarPos { get; set; }
        public int Orden { get; set; }
    }

    public class VucClasificaViewModel
    {
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public string Sigla { get; set; }
        
    }
    // Posicion del dedo dentro de la decadactilar
    public class BioDactilarPosViewModel
    {
        public int Id { get; set; }
        // rectangulo definiendo el dedo dentro de la decadactilar
        // top, left, ancho  y alto
        public decimal[] Rectangulo { get; set; }
    }

    public class CheckRenaperViewModel
    {
        public string CodigoDeBarras { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string DNI { get; set; }
        public int[] dedosDerecha { get; set; }
        public int[] dedosIzquierda { get; set; }

    }

    public class CodigoBarraViewModel
    {
        [Remote("CheckUserName", "Home")]
        public string CodigoBarra { get; set; }
    }

      
}
