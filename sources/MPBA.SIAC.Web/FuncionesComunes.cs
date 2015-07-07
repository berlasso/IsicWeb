using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPBA.SIAC.Web
{
    public class FuncionesComunes
    {
        /// <summary>
        /// Encripta el password para acceder a la base del SIC
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static string Encriptar(string pass)
        {
            int j = 0;
            string aux = "";
            string qwerty = "qwertyuiop";
            int valor = 0;
            string c = "";
            for (int i = 0; i < pass.Length; i++)
            {
                if (j == qwerty.Length)
                {
                    j = 0;
                }
                valor = (int)(Convert.ToChar(qwerty.Substring(j, 1)) ^ Convert.ToChar(pass.Substring(i, 1)));
                j++;

                switch (valor)
                {
                    case 0:
                        c = Convert.ToString((char)255) + "0";
                        break;
                    case 255:
                        c = Convert.ToString((char)255) + " ";
                        break;
                    default:
                        c = Convert.ToString((char)valor);
                        break;
                }
                aux += c;
            }
            return aux;
        }

        public  enum TipoDelitos
        {
            RobosHurtos = 1,
            Sexuales = 2
        }

        public  enum TipoAutores
        {
            Desconocidos = 1,
            Conocidos = 2
        }
    }
}