using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Neurotec;
using Neurotec.Biometrics;
using System.Collections.ObjectModel;
using Neurotec.Images;
using System.IO;
using System.Threading.Tasks;

namespace ISIC.Services
{
    [ServiceContract]
    public interface ICapturaDecaDactilarService
    {
         [OperationContract]
        int CapturaHuellasCliente(ImputadoDatosPers imputado, HuellasImputado sujeto);
    }


    [DataContract]
    public class ImputadoDatosPers
    {
        int dni;
        string sexo;
        string apellido;
        string nombres;
        string codigoBarras;
        string scoreRenaper;
        string resultadoRenaper;
        bool accesoRenaper;
        string ipp;

        [DataMember]
        public int DNI
        {
            get { return dni; }
            set { dni = value; }
        }

        [DataMember]
        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        [DataMember]
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }


        [DataMember]
        public string Nombres
        {
            get { return nombres; }
            set { nombres = value; }
        }
        [DataMember]
        public string CodigoBarras
        {
            get { return codigoBarras; }
            set { codigoBarras = value; }
        }

        [DataMember]
        public string ScoreRenaper
        {
            get { return scoreRenaper; }
            set { scoreRenaper = value; }
        }


        [DataMember]
        public string ResultadoRenaper
        {
            get { return resultadoRenaper; }
            set { resultadoRenaper = value; }
        }

        [DataMember]
        public bool AccesoRenaper
        {
            get { return accesoRenaper; }
            set { accesoRenaper = value; }
        }

        [DataMember]
        public string IPP
        {
            get { return ipp; }
            set { ipp = value; }
        }



    }


    [DataContract]
    public class HuellasImputado
    {
        private List<Dedos> dedosFaltantes;
        private List<Dedos> dedosCapturados;
        private byte[] templateSujeto;

        [DataMember]
        public List<Dedos> DedosFaltantes {
            get { return dedosFaltantes;}
            set {dedosFaltantes = value ;} 
        }

        [DataMember]
        public List<Dedos> DedosCapturados {
            get { return dedosCapturados;}
            set { dedosCapturados=value;}
        
        }

      [DataMember]
        public byte[] TemplateSujeto {
            get { return templateSujeto; }
            set {templateSujeto = value; } 
        
        }
       

                   
    }
    
    [DataContract]
    public class Dedos
    {
        private byte[] imagen;
        private NFPosition position;
        [DataMember]
        public byte[] Imagen
        { 
            get  { return imagen; }
            set { imagen = value;}
        }
       

        [DataMember]
        public NFPosition Position {
            get { return position;}
            set { position = value;} 
        
        }

    }

    
    
 
}