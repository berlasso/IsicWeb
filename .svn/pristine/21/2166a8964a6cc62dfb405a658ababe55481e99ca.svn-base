using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ISIC.Persistence.Context;
using MPBA.DataAccess;
using ISIC.Entities;
using ISIC.Services;
using System.Drawing;
using System.Reflection;
using ISIC.Utils;
using System.Drawing.Imaging;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Text;
using System.Runtime.Serialization;

namespace TestProject
{
    [TestClass]
    public class TestUtils
    {
        [TestMethod]
        public void TestImgToBase64()
        {
            var stream = Assembly.GetAssembly(this.GetType()).
            GetManifestResourceStream("TestProject.Resources.huella.png");
            Image img = Image.FromStream(stream);
            var imgbase64 = img.ImageToBase64(ImageFormat.Png);
            Assert.IsNotNull(imgbase64);
            Console.WriteLine(imgbase64);
        }

        [TestMethod]
        public void TestStringBase64ToImg()
        {
            var stringBase64 = "ssss";
            Image img = stringBase64.Base64ToImage();
            Assert.IsNotNull(img);
        }

        [TestMethod]
        public void TestXML()
        {                      
            var result = 1;
            StringBuilder strBuilder = new StringBuilder(10);
            XmlWriter writer = XmlWriter.Create(strBuilder);
            XmlDictionaryWriter dictionaryWriter = XmlDictionaryWriter.CreateDictionaryWriter(writer);
            
            DataContractSerializer serializer = new DataContractSerializer(typeof(Int32));

            WrappedBodyWriter br = new WrappedBodyWriter(result, serializer, "hola", "http://");
            br.dd(dictionaryWriter);
            dictionaryWriter.Flush();
        }



    }
}
