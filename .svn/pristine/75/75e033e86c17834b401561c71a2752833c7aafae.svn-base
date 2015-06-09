using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ISIC.Services
{
    [ServiceContract]
    public interface IRenaperResponseService
    {
        [OperationContract]
        int SendResponse(RenaperResponse renaperResponse);
    }


    [DataContract]
    public class RenaperResponse
    {
        int dni;
        string sexo;
        string tcn;
        string score;
        string resultado;
        DateTime fecha;

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
        public string Tcn
        {
            get { return tcn; }
            set { tcn = value; }
        }

        [DataMember]
        public string Score
        {
            get { return score; }
            set { score = value; }
        }

        [DataMember]
        public string Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }

        [DataMember]
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

    }
}
