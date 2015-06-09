using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neurotec.Licensing;
using Neurotec;
using Neurotec.Images;
using System.Reflection;

namespace TestMegaMatcher
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test utilizado para chequear como convertir una imagen a formato wsq, utilizando megamatcher
        /// </summary>
        [TestMethod]
        public void TestConvertToWSQ()
        {
            const string Components = "Images.WSQ";
            // Chequeo licencias
            if (!NLicense.ObtainComponents("mphv12", 5000, Components))
            {
                throw new NotActivatedException(string.Format("Could not obtain licenses for components: {0}", Components));
            }

            var stream = Assembly.GetAssembly(this.GetType()).
            GetManifestResourceStream("TestMegaMatcher.WSQ.huella.png");
            
            // Create an NImage from file
            using (NImage image = NImage.FromStream(stream))
            {
                // Create WSQInfo to store bit rate
                using (var info = (WsqInfo)NImageFormat.Wsq.CreateInfo(image))
                {
                    info.BitRate = WsqInfo.DefaultBitRate;
                    // Save image in WSQ format and bitrate to file.
                    image.Save("image.wsq", info);

                }
            }
        }
    }
}
