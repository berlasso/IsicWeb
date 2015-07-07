using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MPBA.SIAC.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace MPBA.SIAC.Web.Models
{
    [MetadataType(typeof(PersonaMetadata))]
    public partial class Persona {

        internal sealed class PersonaMetadata
        {
            private PersonaMetadata()
            { }
            [Display(Name = "Nombre")]
            [StringLength(50)]
            [Required(ErrorMessageResourceType = typeof(MPBA.SIAC.Web.Properties.Resources), ErrorMessageResourceName = "Requerido")]
            public string Nombre { get; set; }
            [Display(Name = "Tipo Doc.")]
            public Nullable<int> idTipoDNI { get; set; }
            [DataType(DataType.Date)]
            [Display(Name = "F.Nacimiento")]
            public DateTime FechaNacimiento { get; set; }
            [Display(Name = "Nro.Doc.")]
            [DataType(DataType.Text)]
            public Nullable<int> DocumentoNumero { get; set; }

            [Display(Name = "Sexo")]
            public Nullable<int> idSexo { get; set; }

            [Display(Name = "Estado Civil Materno")]
            public int IdEstadoCivilMaterno { get; set; }
            [Display(Name = "Estado Civil Paterno")]
            public int IdEstadoCivilPaterno { get; set; }
            [Display(Name = "Fallecido")]
            public bool Muerto { get; set; }
            [Display(Name = "Estado Civil")]
            public int idEstadoCivil { get; set; }

            public Nullable<int> Localidad { get; set; }
            public Nullable<int> Partido { get; set; }
            [Display(Name = "Provincia")]
            public Nullable<int> idProvincia { get; set; }
            [Display(Name = "Profesión")]
            public string profesion { get; set; }
        }
        
    }

    }



