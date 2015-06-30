using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neurotec.Biometrics;

namespace Capturer
{
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
        public static int GetIdentificacionRenaper1(ClaseMano mano, ClaseDedo dedo) 
        {
            if (mano.Equals(ClaseMano.Derecha)) 
            {
                return (int)dedo + 1 ;
            }else
            {
                return (int)dedo + 6;
            }
        }


           public static int GetIdentificacionRenaper(NFPosition posicion) 
          {
             
			switch (posicion)
			{   case NFPosition.RightThumb:
                    return 1;
                case NFPosition.RightIndex:
                    return 2;
               case NFPosition.RightMiddle:
                    return  3;
               case NFPosition.RightRing:
                    return 4;
               case NFPosition.RightLittle:
                    return 5;
               case NFPosition.LeftThumb:
                    return 6;
			   case NFPosition.LeftIndexFinger:
                    return 7;
               case NFPosition.LeftMiddle:
                    return 8;
               case NFPosition.LeftRing:
                   return 9;
                case NFPosition.PlainLeftThumb:
                      return 6;
                case NFPosition.PlainRightThumb:
                    return 1;
                case NFPosition.LeftLittle:
                    return 10;
               
               
               
            	default: return 0;
			}
		}
 
               
               
          
        }

    }

