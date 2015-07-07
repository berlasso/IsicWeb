using System;
using System.ComponentModel;
using System.Diagnostics;


namespace MPBA.PersonasBuscadas.BusinessEntities
{


    public partial class PersHalladaCantXDeptoXFecha
    {

        #region "Private Variables"
        private string _departamento;
        private int _cantidad;

        #endregion

        #region "Public Properties"
        /// <summary>
        /// Gets or sets the departamento of the PersHalladaCantXFecha.
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
        /// Gets or sets the cantidad of the PersHalladaCantXFecha.
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
