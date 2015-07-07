using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using MPBA.PersonasBuscadas.BusinessEntities;

namespace MPBA.PersonasBuscadas.Web
{
    public partial class FuncionesGrales
    {
    

        /// <summary>
        /// Enumeracion para el tipo de busqueda
        /// </summary>
        public  enum TipoBusqueda
        {
            PersonaDesaparecida = 1,
            PersonaHallada = 2
        }

     
        /// <summary>
        /// Enumeracion para el estado del programa
        /// </summary>
        public enum EstadoPrograma
        {
            Creando = 1,
            Modificando = 2,
            Consultando = 3,
            Agregando = 4
        }

        /// <summary>
        /// Enumeracion para el tipo de foto
        /// </summary>
        public enum TipoFoto
        {
            General = 1,
            SeniasParticulares = 2,
            Huellas = 3
        }
    }
}
