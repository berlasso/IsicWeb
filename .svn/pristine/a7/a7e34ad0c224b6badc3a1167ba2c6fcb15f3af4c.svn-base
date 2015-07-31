using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ISIC.Entities;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Atlassian.Jira.Remote;
using ISICWeb.Infrastructure;
using ISICWeb.Models;
using MPBA.Entities;

namespace ISICWeb.Areas.Otip.Models
{
   
    public class DatosGeneralesViewModel:IDatosSomaticos
    {

   
        /// <summary>
        /// El id del imputado, si es nulo es nuevo
        /// </summary>

        private const string RegexFecha =
            @"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$";
        public int? Id { get; set; }

        public bool EsSoloDetalle { get; set; }

        //campos escondidos en la view que guardan los ids de los autocompletes
        public string hidIdLocalidad { get; set; }
        public string hidIdLocalidadNacimiento { get; set; }
        public string hidIdModusOperandi { get; set; }
        public string hidIdPartidoDelito { get; set; }
        public string hidIdPartido { get; set; }
        public string hidIdLocalidadDelito { get; set; }
        public string hidIdDependenciaPolicial { get; set; }
        public string hidIdLocalidadPolicial { get; set; }
        public string hidIdComisaria { get; set; }
        //***********************************
        public string ComisariaMigracion { get; set; }
        public string ObservacionesMigracion { get; set; }
        [Required(ErrorMessage = "El código de barras es requerido")]
        [Display(Name = "Código de Barras")]
        [RegularExpression("(01)(0[1-9]|1[0-9]|20|30|35)([0-9]{8})([a-zA-Z])", ErrorMessage = "Código de Barras incorrecto")]
        [LetraCodigoBarras]
        public string CodBarras { get; set; }

        [MinLength(12, ErrorMessage = "La IPP no puede tener menos de 12 dígitos")]
        [RegularExpression("[0-9-_]+",ErrorMessage = "La IPP solo puede contener números")]
        public string IPP { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [MinLength(2, ErrorMessage = "El apellido no puede tener menos de 2 letras")]
        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑ']+$", ErrorMessage = "Error de tipeo en el apellido")]
        [MaxLength(100, ErrorMessage = "El apellido es demasiado largo")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
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

        [RegularExpression("1|2", ErrorMessage = "Debe especificar el sexo")]
        public string Sexo { get; set; }

        [RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑ.']+$", ErrorMessage = "Error de tipeo en el nombre del fiscal")]
        [MinLength(4, ErrorMessage = "El nombre del fiscal no puede tener menos de 4 letras")]
        [MaxLength(100, ErrorMessage = "El nombre del fiscal es demasiado largo")]
        public string Fiscal { get; set; }

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

        
        [Display(Name = "Fecha del Delito")]
        [Required(ErrorMessage = "La fecha del delito es requerida")]
        [RegularExpression(RegexFecha, ErrorMessage = "El formato de la fecha del delito es incorrecto")]
        [IsDateAfter("FechaNacimiento", true,   ErrorMessage = "La fecha del delito debe ser posterior a la de nacimiento")]
        public string FechaDelito { get; set; }

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

        public ICollection<Archivo> Archivos { get; set; } 

        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        [RegularExpression(RegexFecha, ErrorMessage = "El formato de la fecha de nacimiento es incorrecto")]
        public string FechaNacimiento { get; set; }

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

        //[MinLength(4, ErrorMessage = "El  modus operandi no puede tener menos de 4 letras")]
        //[MaxLength(150, ErrorMessage = "El modus operandi es demasiado largo")]
        [Display(Name = "Modus Operandi")]
        //[RegularExpression("^[A-Za-z áéíóúüÜÁÉÍÓÚñÑ']+$", ErrorMessage = "Error de tipeo en el modus operandi")]
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


        //DOMICILIO
        [MaxLength(100, ErrorMessage = "La calle es demasiado larga")]
        public string Calle { get; set; }

        [MaxLength(100, ErrorMessage = "Entre Calle es demasiado largo")]
        [Display(Name = "Entre Calle")]
        public string EntreCalle { get; set; }

        [MaxLength(100, ErrorMessage = "Y Calle es demasiado largo")]
        [Display(Name = "Y Calle")]
        public string EntreCalle2 { get; set; }

        //[MinLength(4, ErrorMessage = "La localidad  no puede tener menos de 4 letras")]
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

        //[MinLength(4, ErrorMessage = "El partido  no puede tener menos de 4 letras")]
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

        //[MinLength(4, ErrorMessage = "El partido  no puede tener menos de 4 letras")]
        [MaxLength(150, ErrorMessage = "El partido es demasiado largo")]
        [Display(Name = "Partido")]
        public string PartidoDelito { get; set; }


        [Display(Name = "Provincia")]
        public string ProvinciaDelito { get; set; }

        public virtual Prontuario Prontuario { get; set; }

        //DATOS SOMATICOS

        public string ColorCabellos { get; set; }

        
        public string Robustez { get; set; }


        public string ColorPiel { get; set; }

        public string ColorOjos { get; set; }

        public string TipoCabello { get; set; }

        public string TipoCalvicie { get; set; }

        public string FormaCara { get; set; }

        public string DimensionCeja { get; set; }

        public string TipoCeja { get; set; }

        public string FormaMenton { get; set; }

        public string FormaOreja { get; set; }

        public string FormaNariz { get; set; }

        public string FormaBoca { get; set; }

        public string FormaLabioInferior { get; set; }

        public string FormaLabioSuperior { get; set; }
        public string FechaCarga { get; set; }

        //LISTAS PARA DROPDOWNS
        //public SelectList ComisariaList { get; set; }
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


}