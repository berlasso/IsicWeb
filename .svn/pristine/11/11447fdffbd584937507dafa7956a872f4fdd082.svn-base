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
    public interface IRenaperIdentityService
    {
        [OperationContract]
        string VerifyIdentity(RenaperIdentityRequest renaperIdentityRequest);
    }


    [DataContract]
    public class RenaperIdentityRequest
    {
        int dni;
        /// <summary>
        /// M o F
        /// </summary>
        string sexo;
        /// <summary>
        /// Base64 WSQ
        /// </summary>
        string imagenH1;
        /// <summary>
        /// Base64 WSQ
        /// </summary>
        string imagenH2;
        string descripsionH1;
        string descripsionH2;

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
        public string ImagenH1
        {
            get { return imagenH1; }
            set { imagenH1 = value; }
        }

        [DataMember]
        public string ImagenH2
        {
            get { return imagenH2; }
            set { imagenH2 = value; }
        }

        [DataMember]
        public string DescripsionH1
        {
            get { return descripsionH1; }
            set { descripsionH1 = value; }
        }

        [DataMember]
        public string DescripsionH2
        {
            get { return descripsionH2; }
            set { descripsionH2 = value; }
        }

    }
}
