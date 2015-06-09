using ISIC.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIC.Utils
{
    /// <summary>
    /// </summary>
    public static class DedosUtils
    {
        /// <summary>
        /// Para Renaper
        ///     1 Pulgar Derecho
        ///     2 Indice Derecho
        ///     3 Mayor Derecho
        ///     4 Anular Derecho
        ///     5 Meñique Derecho
        ///     6 Plugar Izquierdo
        ///     7 Indice Izquierdo
        ///     8 Mayor Izquierdo
        ///     9 Anular Izquierdo
        ///     10 Meñique Izquierdo
        /// </summary>
        /// <param name="mano"></param>
        /// <param name="dedo"></param>
        /// <returns></returns>
        public static int GetIdentificacionRenaper(ClaseMano mano, ClaseDedo dedo) 
        {
            if (mano.Equals(ClaseMano.Derecha)) 
            {
                return (int)dedo + 1 ;
            }else
            {
                return (int)dedo + 6;
            }
        }
    }
}
