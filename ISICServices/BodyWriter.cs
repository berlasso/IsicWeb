using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.Web;
using System.Xml;

namespace ISIC.Services
{
    public class WrappedBodyWriter : BodyWriter
    {
        public WrappedBodyWriter(object value, XmlObjectSerializer serializer, string name, string ns)
            : base(true)
        {
            this.name = name;
            this.ns = ns;
            this.value = value;
            this.serializer = serializer;
        }

        string name, ns;
        object value;
        XmlObjectSerializer serializer;

#if !NET_2_1
        protected override BodyWriter OnCreateBufferedCopy(int maxBufferSize)
        {
            return new WrappedBodyWriter(value, serializer, name, ns);
        }
#endif

        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            WriteXmlBodyContents(writer);
        }


        void WriteXmlBodyContents(XmlDictionaryWriter writer)
        {
            if (name != null)
                writer.WriteStartElement(name, ns);
            serializer.WriteObject(writer,value);
            if (name != null)
                writer.WriteEndElement();
        }


        public void dd(XmlDictionaryWriter writer) 
        {
            this.OnWriteBodyContents(writer);
        }
    }
}