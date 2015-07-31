using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;


namespace ISIC.Services
{
    /// <summary>
    /// Adds custom formatter to the server which uses the xmlserializer to serialize the body
    /// </summary>
    public class MyFormatterBehavior : Attribute,IOperationBehavior
    {
        public void AddBindingParameters(
            OperationDescription operationDescription,
            BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(
            OperationDescription operationDescription,
            ClientOperation clientOperation)
        {
        }

        public void ApplyDispatchBehavior(
            OperationDescription operationDescription,
            DispatchOperation dispatchOperation)
        {
            dispatchOperation.Formatter = new MyXmlSerializerServerFormatter(operationDescription);
        }

        public void Validate(OperationDescription operationDescription)
        {
        }

    }

    /// <summary>
    /// Formatter which deserialize request messages and serialize response messages in the server side
    /// </summary>
    internal  class MyXmlSerializerServerFormatter :  IDispatchMessageFormatter
    {
        #region fields

        private static Logger logger = LogManager.GetCurrentClassLogger();
        private OperationDescription operation;

        #endregion

        #region constructor

        public MyXmlSerializerServerFormatter(OperationDescription operationDescription)
        {
            operation = operationDescription;
        }

        #endregion

        #region IDispatchMessageFormatter Members

        /// <summary>
        /// Deserializes a message into an array of parameters
        /// </summary>
        /// <param name="message">The incoming message.</param>
        /// <param name="parameters">The objects that are passed to the operation as parameters</param>
        public void DeserializeRequest(
            Message message,
            object[] parameters)
        {
            logger.Info(message.ToString());
            RenaperResponse response = new RenaperResponse();
            var bodyReader = message.GetReaderAtBodyContents();
            String nodeName = null; 
            using (XmlReader reader = bodyReader)
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            nodeName = reader.Name;
                            break;
                        case XmlNodeType.Text:
                            SetValues(response, nodeName, reader.Value);
                            break;
                        case XmlNodeType.EndElement:
                            break;
                        default:
                            Console.WriteLine("Other node {0} with value {1}",reader.NodeType, reader.Value);
                            break;
                    }
                }
            }
            parameters[0] = response;
            
        }

        private void SetValues(RenaperResponse response, String nodeName, String nodeValue)
        {
            if (nodeName.Contains("DNI"))
            {
               response.DNI = Int32.Parse(nodeValue);
            }
            else if (nodeName.Contains("Fecha"))
            {
               response.Fecha = DateTime.Now;
            }
            else if (nodeName.Contains("Resultado"))
            {
               response.Resultado = nodeValue;
            }
            else if (nodeName.Contains("Score"))
            {
               response.Score = nodeValue;
            }
            else if (nodeName.Contains("Sexo"))
            {
               response.Sexo = nodeValue;
            }
            else if (nodeName.Contains("Tcn"))
            {
               response.Tcn = nodeValue;
            }
        }

        /// <summary>
        /// Serializes a reply message from a specified message version, array of parameters, and a return value
        /// </summary>
        /// <param name="messageVersion">The SOAP message version</param>
        /// <param name="parameters">The out parameters</param>
        /// <param name="result">The return value</param>
        /// <returns>The serialized reply message</returns>
        public Message SerializeReply(
            MessageVersion messageVersion,
            object[] parameters,
            object result)
        {
            MessageDescription md = GetMessageDescription(MessageDirection.Output);
            String mediaType = "application/xml";
            var serializer = GetXMLSerializer(md.Body.ReturnValue);
            Message ret = Message.CreateMessage(messageVersion, 
                operation.Messages[1].Action,
                new WrappedBodyWriter(result, serializer, md.Body.ReturnValue.Name, md.Body.ReturnValue.Namespace));

            // Message properties
            var hp = new HttpResponseMessageProperty();
            // FIXME: get encoding from somewhere
            hp.Headers["Content-Type"] = mediaType + "; charset=utf-8";

            // FIXME: fill some properties if required.
            ret.Properties.Add(HttpResponseMessageProperty.Name, hp);
            var wp = new WebBodyFormatMessageProperty(WebContentFormat.Json);            
            ret.Properties.Add(WebBodyFormatMessageProperty.Name, wp);

            return ret;            
        }

        protected MessageDescription GetMessageDescription(MessageDirection dir)
        {
            foreach (MessageDescription md in operation.Messages)
                if (md.Direction == dir)
                    return md;
            throw new SystemException("INTERNAL ERROR: no corresponding message description for the specified direction: " + dir);
        }

        protected XmlObjectSerializer GetXMLSerializer(MessagePartDescription returnValue)
        {
            DataContractSerializer dcs = new DataContractSerializer(returnValue.Type, returnValue.Name, returnValue.Namespace);
            return dcs;
        }
    
        #endregion

    }
}
