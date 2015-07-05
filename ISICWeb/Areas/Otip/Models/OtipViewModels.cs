using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ISIC.Entities;
using System.Linq;
using System.Web;
using Atlassian.Jira.Remote;
using MPBA.Entities;

namespace ISICWeb.Areas.Otip.Models
{
    public class DatosGeneralesViewModels
    {
        /// <summary>
        /// El id del imputado, si es nulo es nuevo
        /// </summary>

        private const string RegexFecha =
            @"(^(((0[1-9]|[12][0-8])[\/](0[1-9]|1[012]))|((29|30|31)[\/](0[13578]|1[02]))|((29|30)[\/](0[4,6,9]|11)))[\/](19|[2-9][0-9])\d\d$)|(^29[\/]02[\/](19|[2-9][0-9])(00|04|08|12|16|20|24|28|32|36|40|44|48|52|56|60|64|68|72|76|80|84|88|92|96)$)";
        public int? Id { get; set; }

        public bool EsSoloDetalle { get; set; }

        //campos escondidos en la view que guardan los ids de los autocompletes
        public string hidIdLocalidad { get; set; }
        public string hidIdLocalidadNacimiento { get; set; }
        public string hidIdModusOperandi { get; set; }
        public string hidIdPartidoDelito { get; set; }
        public string hidIdPartido { get; set; }
        public string hidIdLocalidadDelito { get; set; }
        //***********************************

        [Required(ErrorMessage = "El código de barras es requerido")]
        [Display(Name = "Código de Barras")]
        [RegularExpression("(01)(0[1-9]|1[0-9]|20|30|35)([0-9]{8})([a-zA-Z])",ErrorMessage = "Código de Barras incorrecto")]
        public string CodBarras { get; set; }

        [MinLength(4, ErrorMessage = "La IPP no puede tener menos de 4 dígitos")]
        [RegularExpression("[0-9]+",ErrorMessage = "La IPP solo puede contener números")]
        public string IPP { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [MinLength(2, ErrorMessage = "El apellido no puede tener menos de 2 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑñÑ']+$", ErrorMessage = "Error de tipeo en el apellido")]
        [MaxLength(100, ErrorMessage = "El apellido es demasiado largo")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MinLength(2, ErrorMessage = "El nombre no puede tener menos de 2 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑñÑ']+$", ErrorMessage = "Error de tipeo en el nombre")]
        [MaxLength(100, ErrorMessage = "El nombre  es demasiado largo")]
        public string Nombres { get; set; }

        [MinLength(3, ErrorMessage = "El apodo no puede tener menos de 3 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑñÑ']+$", ErrorMessage = "Error de tipeo en el apodo")]
        [MaxLength(100, ErrorMessage = "El apodo es demasiado largo")]
        public string Apodos { get; set; }

        [MinLength(3, ErrorMessage = "Los Otros Nombres no pueden tener menos de 3 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑñÑ']+$", ErrorMessage = "Error de tipeo en otros nombres")]
        [MaxLength(100, ErrorMessage = "Otros nombres es demasiado largo")]
        [Display(Name = "Otros Nombres")]
        public string OtrosNombres { get; set; }

        [RegularExpression("Masculino|Femenino", ErrorMessage = "Debe especificar el sexo")]
        public string Sexo { get; set; }

        [Display(Name = "Fiscalía General")]
        public string FiscaliaGeneral { get; set; }

        [Display(Name = "Instrucción")]
        public string Instruccion { get; set; }

        [Display(Name = "Estado Civil")]
        public string EstadoCivil { get; set; }

        [Display(Name = "Tipo de Documento")]
        public string TipoDocumento { get; set; }

        [Required(ErrorMessage = "El delito es requerido")]
        [MinLength(4, ErrorMessage = "El delito no puede tener menos de 4 letras")]
        [MaxLength(300, ErrorMessage = "El delito es demasiado largo")]
        public string Delito { get; set; }

        [Required(ErrorMessage = "La fecha del delito es requerida")]
        [Display(Name = "Fecha del Delito")]
        [RegularExpression(RegexFecha, ErrorMessage = "El formato de la fecha del delito es incorrecto")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        //[DataType(DataType.Date)]
        public string FechaDelito { get; set; }

        [Display(Name = "Cónyuge")]
        [MinLength(4, ErrorMessage = "El cónyuge no puede tener menos de 4 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑñÑ']+$", ErrorMessage = "Error de tipeo en el cónyuge")]
        public string Conyuge { get; set; }

        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        [MinLength(3, ErrorMessage = "La madre no puede tener menos de 3 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑñÑ']+$", ErrorMessage = "Error de tipeo en la madre")]
        [MaxLength(100, ErrorMessage = "El nombre de la madre es demasiado largo")]
        public string Madre { get; set; }

        [MinLength(3, ErrorMessage = "El padre no puede tener menos de 3 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑñÑ']+$", ErrorMessage = "Error de tipeo en el padre")]
        [MaxLength(100, ErrorMessage = "El nombre del padre es demasiado largo")]
        public string Padre { get; set; }

        

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Fecha de Nacimiento")]
        [RegularExpression(RegexFecha, ErrorMessage = "El formato de la fecha de nacimiento es incorrecto")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public string FechaNacimiento { get; set; }

        //[MinLength(3, ErrorMessage = "El lugar de nacimiento no puede tener menos de 3 letras")]
        [MaxLength(100, ErrorMessage = "El lugar de nacimiento es demasiado largo")]
        [Display(Name = "Lugar de Nacimiento")]
        public string LocalidadNacimiento { get; set; }

        [Display(Name = "Provincia de Nacimiento")]
        public string ProvinciaNacimiento { get; set; }

        [Display(Name = "País de Nacimiento")]
        public string PaisNacimiento { get; set; }

        [MinLength(3, ErrorMessage = "El domicilio no puede tener menos de 3 letras")]
        [MaxLength(100, ErrorMessage = "El domicilio es demasiado largo")]
        public string Domicilio { get; set; }

        [MinLength(3, ErrorMessage = "La profesión no puede tener menos de 3 letras")]
        [MaxLength(50, ErrorMessage = "La profesión es demasiado larga")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑñÑ']+$", ErrorMessage = "Error de tipeo en la profesión")]
        [Display(Name = "Profesión")]
        public string Profesion { get; set; }

        [MinLength(4, ErrorMessage = "El  modus operandi no puede tener menos de 4 letras")]
        [MaxLength(150, ErrorMessage = "El modus operandi es demasiado largo")]
        [Display(Name = "Modus Operandi")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑñÑ']+$", ErrorMessage = "Error de tipeo en el modus operandi")]
        public string ModusOperandi { get; set; }

        [MaxLength(50, ErrorMessage = "La UFI es demasiado larga")]
        public string UFI { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "El documento sólo puede contener números")]
        [Range(0,300000000, ErrorMessage = "Nro. de documento fuera de rango")]
        [Display(Name = "Nro. de Documento")]
        public string NumeroDocumento { get; set; }

        [Range(120,220,ErrorMessage = "Estatura fuera de rango")]
        public int? Estatura { get; set; }
        
        [Display(Name = "Dependencia Policial")]
        [MaxLength(100, ErrorMessage = "La dependencia policial es demasiado larga")]
        public string DependenciaPolicial { get; set; }

        [Display(Name = "Juzgado de Garantías")]
        [MaxLength(100, ErrorMessage = "El juzgado de garantías es demasiado largo")]
        public string JuzgadoGarantias { get; set; }

         [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑñÑ']+$", ErrorMessage = "Error de tipeo en el nombre del fiscal")]
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

        [Range(0,100000,ErrorMessage = "Número de puerta fuera de rango")]
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

    }
}