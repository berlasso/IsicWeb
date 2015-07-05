using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ISIC.Entities;
using ISICWeb.Infrastructure;
using ISICWeb.Models;

namespace ISICWeb.Areas.PortalSIC.Models
{
    public class BusquedaViewModel:IDatosSomaticos
    {


        /// <summary>
        /// El id del imputado, si es nulo es nuevo
        /// </summary>

        private const string RegexFecha =
            @"(^(((0[1-9]|[12][0-8])[\/](0[1-9]|1[012]))|((29|30|31)[\/](0[13578]|1[02]))|((29|30)[\/](0[4,6,9]|11)))[\/](19|[2-9][0-9])\d\d$)|(^29[\/]02[\/](19|[2-9][0-9])(00|04|08|12|16|20|24|28|32|36|40|44|48|52|56|60|64|68|72|76|80|84|88|92|96)$)";
   

        [Display(Name = "Código de Barras")]
        [RegularExpression("(01)(0[1-9]|1[0-9]|20|30|35)([0-9]{8})([a-zA-Z])", ErrorMessage = "Código de Barras incorrecto")]
        [LetraCodigoBarras]
        public string CodBarras { get; set; }

        [HiddenInput]
        public string BusquedaAvanzada { get; set; }

        //[MinLength(12, ErrorMessage = "La IPP no puede tener menos de 12 dígitos")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "La IPP solo puede contener números")]
        public string IPP { get; set; }

        [MinLength(2, ErrorMessage = "El apellido no puede tener menos de 2 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑ']+$", ErrorMessage = "Error de tipeo en el apellido")]
        [MaxLength(100, ErrorMessage = "El apellido es demasiado largo")]
        public string Apellido { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Edad incorrecta.")]
        [NumericLessThan("EdadHasta",AllowEquality = true,ErrorMessage = "Edad desde debe ser inferior a hasta")]
        [Display(Name = "Edad Desde (años)")]
        public string EdadDesde { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Edad incorrecta.")]
        [Display(Name = "Edad Hasta (años)")]
        [NumericGreaterThan("EdadDesde", AllowEquality = true, ErrorMessage = "Edad desde debe ser inferior a hasta.")]
        public string EdadHasta { get; set; }

        [MinLength(2, ErrorMessage = "El nombre no puede tener menos de 2 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑ']+$", ErrorMessage = "Error de tipeo en el nombre")]
        [MaxLength(100, ErrorMessage = "El nombre  es demasiado largo")]
        public string Nombres { get; set; }

        [MinLength(3, ErrorMessage = "El apodo no puede tener menos de 3 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑ']+$", ErrorMessage = "Error de tipeo en el apodo")]
        [MaxLength(100, ErrorMessage = "El apodo es demasiado largo")]
        public string Apodos { get; set; }

        [MinLength(3, ErrorMessage = "Los Otros Nombres no pueden tener menos de 3 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑ']+$", ErrorMessage = "Error de tipeo en otros nombres")]
        [MaxLength(100, ErrorMessage = "Otros nombres es demasiado largo")]
        [Display(Name = "Otros Nombres")]
        public string OtrosNombres { get; set; }

        public string Sexo { get; set; }

        public string FiscaliaGeneral { get; set; }

        [Display(Name = "Instrucción")]
        public string Instruccion { get; set; }

        [Display(Name = "Estado Civil")]
        public string EstadoCivil { get; set; }

        [Display(Name = "Tipo de Documento")]
        public string TipoDocumento { get; set; }

        [MinLength(4, ErrorMessage = "El delito no puede tener menos de 4 letras")]
        [MaxLength(300, ErrorMessage = "El delito es demasiado largo")]
        public string Delito { get; set; }

        [Display(Name = "Cónyuge")]
        [MinLength(4, ErrorMessage = "El cónyuge no puede tener menos de 4 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑ']+$", ErrorMessage = "Error de tipeo en el cónyuge")]
        public string Conyuge { get; set; }

        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        [MinLength(3, ErrorMessage = "La madre no puede tener menos de 3 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑ']+$", ErrorMessage = "Error de tipeo en la madre")]
        [MaxLength(100, ErrorMessage = "El nombre de la madre es demasiado largo")]
        public string Madre { get; set; }

        [MinLength(3, ErrorMessage = "El padre no puede tener menos de 3 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑ']+$", ErrorMessage = "Error de tipeo en el padre")]
        [MaxLength(100, ErrorMessage = "El nombre del padre es demasiado largo")]
        public string Padre { get; set; }



        [Display(Name = "Fecha de Nacimiento")]
        [RegularExpression(RegexFecha, ErrorMessage = "El formato de la fecha de nacimiento es incorrecto")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        //[IsDateBefore("FechaDelito", true, ErrorMessage = "La fecha de nacimiento debe ser anterior a la del delito")]
        public string FechaNacimiento { get; set; }

        //[MinLength(3, ErrorMessage = "El lugar de nacimiento no puede tener menos de 3 letras")]
        [MaxLength(100, ErrorMessage = "El lugar de nacimiento es demasiado largo")]
        [Display(Name = "Lugar de Nacimiento")]
        public string LocalidadNacimiento { get; set; }

        [MaxLength(100, ErrorMessage = "La localidad policial es demasiado larga")]
        [Display(Name = "Localidad Policial")]
        public string LocalidadPolicial { get; set; }

        [Display(Name = "Provincia de Nacimiento")]
        public string ProvinciaNacimiento { get; set; }

        [Display(Name = "País de Nacimiento")]
        public string PaisNacimiento { get; set; }

        [MinLength(3, ErrorMessage = "El domicilio no puede tener menos de 3 letras")]
        [MaxLength(100, ErrorMessage = "El domicilio es demasiado largo")]
        public string Domicilio { get; set; }

        [MinLength(3, ErrorMessage = "La profesión no puede tener menos de 3 letras")]
        [MaxLength(50, ErrorMessage = "La profesión es demasiado larga")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑ']+$", ErrorMessage = "Error de tipeo en la profesión")]
        [Display(Name = "Profesión")]
        public string Profesion { get; set; }

        [MinLength(4, ErrorMessage = "El  modus operandi no puede tener menos de 4 letras")]
        [MaxLength(150, ErrorMessage = "El modus operandi es demasiado largo")]
        [Display(Name = "Modus Operandi")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑ']+$", ErrorMessage = "Error de tipeo en el modus operandi")]
        public string ModusOperandi { get; set; }

        [MaxLength(50, ErrorMessage = "La UFI es demasiado larga")]
        public string UFI { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "El documento sólo puede contener números")]
        [Range(0, 300000000, ErrorMessage = "Nro. de documento fuera de rango")]
        [Display(Name = "Nro. de Documento")]
        public string NumeroDocumento { get; set; }

        [Range(120, 220, ErrorMessage = "Estatura fuera de rango")]
        public int? Estatura { get; set; }

        [Display(Name = "Dependencia Policial")]
        [MaxLength(100, ErrorMessage = "La dependencia policial es demasiado larga")]
        public string DependenciaPolicial { get; set; }

        [Display(Name = "Juzgado de Garantías")]
        [MaxLength(100, ErrorMessage = "El juzgado de garantías es demasiado largo")]
        public string JuzgadoGarantias { get; set; }

        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑ']+$", ErrorMessage = "Error de tipeo en el nombre del fiscal")]
        [MinLength(4, ErrorMessage = "El nombre del fiscal no puede tener menos de 4 letras")]
        [MaxLength(100, ErrorMessage = "El nombre del fiscal es demasiado largo")]
        public string Fiscal { get; set; }

        public ICollection<Archivo> Archivos { get; set; }


        //DOMICILIO
        [MaxLength(100, ErrorMessage = "La calle es demasiado larga")]
        public string Calle { get; set; }

        [MaxLength(100, ErrorMessage = "Entre Calle es demasiado largo")]
        [Display(Name = "Entre Calle")]
        public string EntreCalle { get; set; }

        [MaxLength(100, ErrorMessage = "Y Calle es demasiado largo")]
        [Display(Name = "Y Calle")]
        public string EntreCalle2 { get; set; }

        [MinLength(4, ErrorMessage = "La localidad  no puede tener menos de 4 letras")]
        [MaxLength(150, ErrorMessage = "La localidad es demasiado larga")]
        public string Localidad { get; set; }

        [Range(0, 100000, ErrorMessage = "Número de puerta fuera de rango")]
        [Display(Name = "Número")]
        public string NroH { get; set; }

        [MaxLength(50, ErrorMessage = "El departamento es demasiado largo")]
        [Display(Name = "Departamento")]
        public string DeptoH { get; set; }

        [MaxLength(50, ErrorMessage = "El piso  es demasiado largo")]
        [Display(Name = "Piso")]
        public string PisoH { get; set; }

        [MinLength(4, ErrorMessage = "El barrio  no puede tener menos de 4 letras")]
        [MaxLength(150, ErrorMessage = "El barrio es demasiado largo")]
        [Display(Name = "Barrio")]
        public string ParajeBarrioH { get; set; }

        [MinLength(4, ErrorMessage = "El partido  no puede tener menos de 4 letras")]
        [MaxLength(150, ErrorMessage = "El partido es demasiado largo")]
        public string Partido { get; set; }

        public string Provincia { get; set; }

        //DOMICILIO DEL DELITO
        [MaxLength(100, ErrorMessage = "La calle es demasiado larga")]
        [Display(Name = "Calle")]
        public string CalleDelito { get; set; }

        [MaxLength(100, ErrorMessage = "Entre Calle es demasiado largo")]
        [Display(Name = "Entre Calle")]
        public string EntreCalleDelito { get; set; }

        [MaxLength(100, ErrorMessage = "Y Calle es demasiado largo")]
        [Display(Name = "Y Calle")]
        public string EntreCalle2Delito { get; set; }

        [MinLength(4, ErrorMessage = "La localidad  no puede tener menos de 4 letras")]
        [MaxLength(150, ErrorMessage = "La localidad es demasiado larga")]
        [Display(Name = "Localidad")]
        public string LocalidadDelito { get; set; }

        [Range(0, 100000, ErrorMessage = "Número de puerta fuera de rango")]
        [Display(Name = "Número")]
        public string NroHDelito { get; set; }

        [MaxLength(50, ErrorMessage = "El departamento es demasiado largo")]
        [Display(Name = "Departamento")]
        public string DeptoHDelito { get; set; }

        [MaxLength(50, ErrorMessage = "El piso  es demasiado largo")]
        [Display(Name = "Piso")]
        public string PisoHDelito { get; set; }

        [MinLength(4, ErrorMessage = "El barrio  no puede tener menos de 4 letras")]
        [MaxLength(150, ErrorMessage = "El barrio es demasiado largo")]
        [Display(Name = "Barrio")]
        public string ParajeBarrioHDelito { get; set; }

        [MinLength(4, ErrorMessage = "El partido  no puede tener menos de 4 letras")]
        [MaxLength(150, ErrorMessage = "El partido es demasiado largo")]
        [Display(Name = "Partido")]
        public string PartidoDelito { get; set; }


        [Display(Name = "Provincia")]
        public string ProvinciaDelito { get; set; }

        [Display(Name = "Fecha del Delito Desde")]
        //[RegularExpression(RegexFecha, ErrorMessage = "El formato de la fecha del delito es incorrecto")]
        [IsDateBefore("FechaDelitoHasta", true, false, ErrorMessage = "La fecha del delito desde debe ser anterior a la hasta")]
        public string FechaDelitoDesde { get; set; }

        [Display(Name = "Fecha del Delito Hasta")]
        //[RegularExpression(RegexFecha, ErrorMessage = "El formato de la fecha del delito es incorrecto")]
        [IsDateAfter("FechaDelitoDesde", true,false, ErrorMessage = "La fecha del delito hasta debe ser posterior a la desde")]
        public string FechaDelitoHasta { get; set; }


        //DATOS SOMATICOS
        [Display(Name = "Color de Cabello")]
        public string ColorCabellos { get; set; }
        [Display(Name = "Robustez")]
        //public IEnumerable<SICClaseRobustez> Robustez { get; set; }
        public string Robustez { get; set; }
        [Display(Name = "Color de Piel")]
        public string ColorPiel { get; set; }
        [Display(Name = "Color de Ojos")]
        public string ColorOjos { get; set; }
        [Display(Name = "Tipo de Cabello")]
        public string TipoCabello { get; set; }
        [Display(Name = "Calvicie")]
        public string TipoCalvicie { get; set; }
        [Display(Name = "Forma de la Cara")]
        public string FormaCara { get; set; }
        [Display(Name = "Dimensión de la Ceja")]
        public string DimensionCeja { get; set; }
        [Display(Name = "Tipo de la Ceja")]
        public string TipoCeja { get; set; }
        [Display(Name = "Forma del Mentón")]
        public string FormaMenton { get; set; }
        [Display(Name = "Forma de la Oreja")]
        public string FormaOreja { get; set; }
        [Display(Name = "Forma de la Nariz")]
        public string FormaNariz { get; set; }
        [Display(Name = "Forma de la Boca")]
        public string FormaBoca { get; set; }
        [Display(Name = "Forma del Labio Inferior")]
        public string FormaLabioInferior { get; set; }
        [Display(Name = "Forma del Labio Superior")]
        public string FormaLabioSuperior { get; set; }
        public TipoBusqueda TipoBusqueda { get; set; }
        //public bool UsaBusquedaAvanzada { get; set; }

        //LISTAS PARA DROPDOWNS
        public SelectList SexoList { get; set; }
        public SelectList PaisList { get; set; }
        public SelectList ProvinciaList { get; set; }
        public SelectList InstruccionList { get; set; }
        public SelectList TipoDocumentoList { get; set; }
        public SelectList EstadoCivilList { get; set; }
        public SelectList RobustezList { get; set; }
        public SelectList FormaCaraList { get; set; }
        public SelectList FormaLabioSuperiorList { get; set; }
        public SelectList FormaLabioInferiorList { get; set; }
        public SelectList ColorPielList { get; set; }
        public SelectList ColorCabellosList { get; set; }
        public SelectList ColorOjosList { get; set; }
        public SelectList TipoCabelloList { get; set; }
        public SelectList DimensionCejaList { get; set; }
        public SelectList TipoCejaList { get; set; }
        public SelectList FormaMentonList { get; set; }
        public SelectList FormaOrejaList { get; set; }
        public SelectList FormaNarizList { get; set; }
        public SelectList FormaBocaList { get; set; }
        public SelectList TipoCalvicieList { get; set; }
        public SelectList FiscaliaGeneralList { get; set; }
    }

    public enum TipoBusqueda
    {
        ListadoGeneral=1,
        Fotografias=2
    }


}