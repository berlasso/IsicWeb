using Neurotec.Biometrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capturer.Forms
{
    public class HuellasImputado
    {
       
            private List<Dedos> dedosFaltantes;
            private List<Dedos> dedosCapturados;
            private byte[] templateSujeto;

            public List<Dedos> DedosFaltantes
            {
                get { return dedosFaltantes; }
                set { dedosFaltantes = value; }
            }

           public List<Dedos> DedosCapturados
            {
                get { return dedosCapturados; }
                set { dedosCapturados = value; }

            }

           public byte[] TemplateSujeto
            {
                get { return templateSujeto; }
                set { templateSujeto = value; }

            }



        }

        public class Dedos
        {
            private byte[] imagen;
            private NFPosition position;
       
            public byte[] Imagen
            {
                get { return imagen; }
                set { imagen = value; }
            }


       
            public NFPosition Position
            {
                get { return position; }
                set { position = value; }

            }

        }
    
}
