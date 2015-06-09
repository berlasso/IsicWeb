using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neurotec.Biometrics;
using Neurotec.Biometrics.Client;
using Neurotec.Devices;
using Neurotec.Licensing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMegaMatcher.Fingers
{

    [TestClass]
    public class UnitTestDevices
    {

        /// <summary>
        /// Test utilizado para chequear los dispositivos conectados a la pc
        /// </summary>
        [TestMethod]
        public void TestListaDispositivos()
        {
            const string Components = "Devices.FingerScanners";

            foreach (string component in Components.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                NLicense.ObtainComponents("mphv12.mpba.gov.ar", 5000, component);
            }
            var deviceManager = new NDeviceManager { DeviceTypes = NDeviceType.FingerScanner, AutoPlug = true };
            deviceManager.Initialize();
            int count = deviceManager.Devices.Count;
            Assert.AreNotEqual(0,count);
        }
        
        /// <summary>
        /// Test utilizado para capturar un huella 
        /// </summary>
        [TestMethod]
        public void TestFingerPrintCapture()
        {
            // Las dos licencias se necesitan para que funcione la extraccion.
            const string Components = "Biometrics.FingerExtraction,Devices.FingerScanners";
            try
            {
                foreach (string component in Components.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    NLicense.ObtainComponents("mphv12.mpba.gov.ar", 5000, component);
                }

                var biometricClient = new NBiometricClient { UseDeviceManager = true };
                var deviceManager = new NDeviceManager { DeviceTypes = NDeviceType.FingerScanner, AutoPlug = true };
                deviceManager.Initialize();
                int count = deviceManager.Devices.Count;
                Assert.AreNotEqual(0, count);

                var subject = new NSubject();
                var finger = new NFinger();

                // Selecciono Dispositivo
                NDevice device = deviceManager.Devices[0];
                Console.WriteLine(String.Format("DeviceName {0} , DeviceType {1}", device.DisplayName, device.DeviceType));

                biometricClient.FingerScanner = (NFScanner)device;

                //add NFinger to NSubject
                subject.Fingers.Add(finger);

                //start capturing
                NBiometricStatus status = biometricClient.Capture(subject);
                if (status != NBiometricStatus.Ok)
                {
                    Console.WriteLine("Failed to capture: " + status);
                }
                //Set finger template size (recommended, for enroll to database, is large) (optional)
                biometricClient.FingersTemplateSize = NTemplateSize.Large;

                //Create template from added finger image
                status = biometricClient.CreateTemplate(subject);
                if (status == NBiometricStatus.Ok)
                {
                    // save image to file
                    using (var image = subject.Fingers[0].Image)
                    {
                        image.Save("img.png");
                    }
                }
            }
            catch (Exception ex)
            {                
            }
			finally
			{
				NLicense.ReleaseComponents(Components);
			}
        }   
    }
}
