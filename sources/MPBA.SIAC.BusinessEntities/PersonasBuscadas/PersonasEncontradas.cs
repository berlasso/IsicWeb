using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.PersonasBuscadas.BusinessEntities
{


    public partial class PersonasEncontradas
    {

        #region "Private Variables"
        private int _id;
        private string _ippHallada;
        private string _ippDesaparecida;
        private DateTime? _fecha = null;
        private string _usuario;

        #endregion

        #region "Public Properties"
        /// <summary>
        /// Gets or sets the id of the PersonasEncontradas.
        /// </summary>
        [DataObjectFieldAttribute(true, true, false)]


        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        /// <summary>
        /// Gets or sets the IppHallada  of the PersonasEncontradas.
        /// </summary>


        public string IppHallada
        {
            get
            {
                return _ippHallada;
            }
            set
            {
                _ippHallada = value;
            }
        }

        /// <summary>
        /// Gets or sets the IppDesaparecida  of the PersonasEncontradas.
        /// </summary>


        public string IppDesaparecida
        {
            get
            {
                return _ippDesaparecida;
            }
            set
            {
                _ippDesaparecida = value;
            }
        }

        /// <summary>
        /// Gets or sets the Fecha of the PersonasEncontradas.
        /// </summary>

        public DateTime? Fecha
        {
            get
            {
                return _fecha;
            }
            set
            {
                _fecha = value;
            }
        }

        /// <summary>
        /// Gets or sets the Usuario of the PersonasEncontradas.
        /// </summary>


        public string Usuario
        {
            get
            {
                return _usuario;
            }
            set
            {
                _usuario = value;
            }
        }


        #endregion

    }
}