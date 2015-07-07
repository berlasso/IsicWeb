using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.PersonasBuscadas.BusinessEntities
{


    public partial class PersDesapCantXDeptoXFecha
    {

        #region "Private Variables"
        private string _departamento;
        private int _cantidad;

        #endregion

        #region "Public Properties"
        /// <summary>
        /// Gets or sets the departamento of the PersDesapCantXFecha.
        /// </summary>
        [DataObjectFieldAttribute(true, true, false)]


        public string departamento
        {
            get
            {
                return _departamento;
            }
            set
            {
                _departamento = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the cantidad of the PersDesapCantXFecha.
        /// </summary>
        [DataObjectFieldAttribute(true, true, false)]


        public int cantidad
        {
            get
            {
                return _cantidad;
            }
            set
            {
                _cantidad = value;
            }
        }

        #endregion

    }
}
