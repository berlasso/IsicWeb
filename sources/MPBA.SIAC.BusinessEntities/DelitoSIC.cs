using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.SIAC.BusinessEntities
{


    public partial class DelitoSIC
    {

        #region "Private Variables"
        private string _nroCarpeta;
        private string _prontuarioSic;
        private string _tatuaje;
        private string _apellido;
        private string _nombres;
        private string _tipoDoc;
        private string _docNro;
        private string _feNac;
        private string _lugarNac;
        private string _pciaNac;
        private string _paisNac;
        private string _codBarra;
        private string _caratula;
        private string _fechaDelito;
        private string _ipp;
        private string _sexo;
        private string _linkSic;


        #endregion

        #region "Public Properties"




        /// <summary>
        /// Gets or sets the NroCarpeta of the Persona.
        /// </summary>


        public string NroCarpeta
        {
            get
            {
                return _nroCarpeta;
            }
            set
            {
                _nroCarpeta = value;
            }
        }

        /// <summary>
        /// Gets or sets the ProntuarioSic of the Persona.
        /// </summary>


        public string ProntuarioSic
        {
            get
            {
                return _prontuarioSic;
            }
            set
            {
                _prontuarioSic = value;
            }
        }
        /// <summary>
        /// Gets or sets the Tatuaje of the Persona.
        /// </summary>


        public string Tatuaje
        {
            get
            {
                return _tatuaje;
            }
            set
            {
                _tatuaje = value;
            }
        }
        /// <summary>
        /// Gets or sets the Apellido of the Persona.
        /// </summary>


        public string Apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
                _apellido = value;
            }
        }
        /// <summary>
        /// Gets or sets the Nombres of the Persona.
        /// </summary>


        public string Nombres
        {
            get
            {
                return _nombres;
            }
            set
            {
                _nombres = value;
            }
        }
        /// <summary>
        /// Gets or sets the TipoDoc of the Persona.
        /// </summary>


        public string TipoDoc
        {
            get
            {
                return _tipoDoc;
            }
            set
            {
                _tipoDoc = value;
            }
        }
        /// <summary>
        /// Gets or sets the DocNro of the Persona.
        /// </summary>


        public string DocNro
        {
            get
            {
                return _docNro;
            }
            set
            {
                _docNro = value;
            }
        }
        /// <summary>
        /// Gets or sets the FeNac of the Persona.
        /// </summary>


        public string FeNac
        {
            get
            {
                return _feNac;
            }
            set
            {
                _feNac = value;
            }
        }
        /// <summary>
        /// Gets or sets the LugarNac of the Persona.
        /// </summary>


        public string LugarNac
        {
            get
            {
                return _lugarNac;
            }
            set
            {
                _lugarNac = value;
            }
        }
        /// <summary>
        /// Gets or sets the PciaNac of the Persona.
        /// </summary>


        public string PciaNac
        {
            get
            {
                return _pciaNac;
            }
            set
            {
                _pciaNac = value;
            }
        }
        /// <summary>
        /// Gets or sets the PaisNac of the Persona.
        /// </summary>


        public string PaisNac
        {
            get
            {
                return _paisNac;
            }
            set
            {
                _paisNac = value;
            }
        }
        /// <summary>
        /// Gets or sets the CodBarra of the Persona.
        /// </summary>


        public string CodBarra
        {
            get
            {
                return _codBarra;
            }
            set
            {
                _codBarra = value;
            }
        }
        /// <summary>
        /// Gets or sets the Caratula of the Persona.
        /// </summary>


        public string Caratula
        {
            get
            {
                return _caratula;
            }
            set
            {
                _caratula = value;
            }
        }
        /// <summary>
        /// Gets or sets the FechaDelito of the Persona.
        /// </summary>


        public string FechaDelito
        {
            get
            {
                return _fechaDelito;
            }
            set
            {
                _fechaDelito = value;
            }
        }
        /// <summary>
        /// Gets or sets the Ipp of the Persona.
        /// </summary>


        public string Ipp
        {
            get
            {
                return _ipp;
            }
            set
            {
                _ipp = value;
            }
        }

        /// <summary>
        /// Gets or sets the Sexo of the Persona.
        /// </summary>


        public string Sexo
        {
            get
            {
                return _sexo;
            }
            set
            {
                _sexo = value;
            }
        }

        /// <summary>
        /// Gets or sets the LinkSic of the Persona.
        /// </summary>


        public string LinkSic
        {
            get
            {
                return _linkSic;
            }
            set
            {
                _linkSic = value;
            }
        }
        #endregion
    }
}


