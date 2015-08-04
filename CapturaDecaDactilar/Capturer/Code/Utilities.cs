using Neurotec.Biometrics;
using Neurotec.Biometrics.Client;
using Neurotec.Images;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Capturer.Forms
{
	public class Utilities
	{
		private const string ErrorTitle = "Error";
		private const string InformationTitle = "Information";
		private const string QuestionTitle = "Question";
		private const string WarningTitle = "Warning";
        private const string urlRenaper = "https://afisrenaper.idear.gov.ar:13443/AFIS_MinJusticia.php";
        private const string subjectNameRenaper = "ProcuracionGral" ;
        private const string storeLocationRenaper = "1";
         private const string storeNameRenaper = "5";


        public static int ConvertNFingerToIndex(NFPosition pos)
        {  
          switch (pos)

          {  case NFPosition.LeftIndexFinger:
                  return 1;
              case NFPosition.LeftThumb:
                  return 0;
             case NFPosition.LeftMiddleFinger:
                  return 2;
             case NFPosition.LeftRingFinger:
                  return 3;
             case NFPosition.LeftLittleFinger:
                  return 4;
              case NFPosition.RightIndexFinger:
                  return 6;
              case NFPosition.RightThumb:
                  return 5;
             case NFPosition.RightMiddleFinger:
                  return 7;
             case NFPosition.RightRingFinger:
                  return 8;
             case NFPosition.RightLittleFinger:
                  return 9;
              default :return 0;

          }
        }




        public static int ConvertNFingerToIndex(string pos)
        {
            switch (pos)
            {
                case "LeftIndexFinger":
                    return 1;
                case "LeftThumb":
                    return 0;
                case "LeftMiddleFinger":
                    return 2;
                case "LeftRingFinger":
                    return 3;
                case "LeftLittleFinger":
                    return 4;
                case "RightIndexFinger":
                    return 6;
                case "RightThumb":
                    return 5;
                case "RightMiddleFinger":
                    return 7;
                case "RightRingFinger":
                    return 8;
                case "RightLittleFinger":
                    return 9;
                default: return 0;

            }
        }


        public static NFPosition ConvertStringToNeuro(string pos)
        {
            switch (pos)
            {
                case "LeftIndexFinger":
                    return NFPosition.LeftIndexFinger;
                case "LeftThumb":
                    return NFPosition.LeftThumb;
                case "LeftMiddleFinger":
                    return NFPosition.LeftMiddleFinger;
                case "LeftRingFinger":
                    return NFPosition.LeftRingFinger;
                case "LeftLittleFinger":
                    return NFPosition.LeftLittleFinger;
                case "RightIndexFinger":
                    return NFPosition.RightIndexFinger;
                case "RightThumb":
                    return NFPosition.RightThumb;
                case "RightMiddleFinger":
                    return NFPosition.RightMiddleFinger;
                case "RightRingFinger":
                    return NFPosition.RightRingFinger;
                case "RightLittleFinger":
                    return NFPosition.RightLittleFinger;
                default: return NFPosition.LeftIndexFinger;

            }
        }

         public static string RenaperGetSubject()
         {
             return subjectNameRenaper;
         }
         public static string RenaperGetSoreLocation()
         {
             return storeLocationRenaper;
         }

         public static string RenaperGetUrl()
         {
             return urlRenaper;
         }

         public static string RenaperGetstoreName()
         {
             return storeNameRenaper;
         }
		/// <summary>
		/// Gets location for current applicaiton folder.
		/// </summary>
		/// <returns></returns>
		public static string GetCurrentApplicationLocation()
		{
			return Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + Path.DirectorySeparatorChar;
		}

        

		/// <summary>
		/// Returns the current application name.
		/// </summary>
		/// <returns></returns>
		public static string GetCurrentApplicationName()
		{
			return Assembly.GetEntryAssembly().GetName().Name;
		}

		/// <summary>
		/// Returns the current application version.
		/// </summary>
		/// <returns></returns>
		public static Version GetCurrentApplicationVersion()
		{
			return Assembly.GetExecutingAssembly().GetName().Version;
		}

		/// <summary>
		/// Shows the error message with the exclamation mark.
		/// </summary>
		/// <param name="message">Message to be displayed.</param>
		public static void ShowError(string message)
		{
			MessageBox.Show(message, GetCurrentApplicationName() + ": " + ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		/// <summary>
		/// Shows the error message with the exclamation mark.
		/// </summary>
		/// <param name="ex">Exception.</param>
		public static void ShowError(Exception ex)
		{
			ShowError(ex.ToString());
		}

		/// <summary>
		/// Shows the error message with the exclamation mark.
		/// </summary>
		public static void ShowError(string format, params object[] args)
		{
			string str = string.Format(format, args);
			ShowError(str);
		}

		/// <summary>
		/// Shows the information message with the exclamation mark.
		/// </summary>
		/// <param name="message">Message to be displayed.</param>
		public static void ShowInformation(string message)
		{
			MessageBox.Show(message, GetCurrentApplicationName() + ": " + InformationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// Shows the information message with the exclamation mark.
		/// </summary>
		public static void ShowInformation(string format, params object[] args)
		{
			string str = string.Format(format, args);
			ShowInformation(str);
		}

		/// <summary>
		/// Shows the question message with the question mark.
		/// </summary>
		/// <param name="message">Message to be displayed.</param>
		/// <returns>Returns the user response.</returns>
		public static bool ShowQuestion(string message)
		{
			return ShowQuestion((IWin32Window)null, message);
		}

		/// <summary>
		/// Shows the question message with the question mark.
		/// </summary>
		/// <returns>Returns the user response.</returns>
		public static bool ShowQuestion(string format, params object[] args)
		{
			return ShowQuestion((IWin32Window)null, format, args);
		}

		public static bool ShowQuestion(IWin32Window owner, string message, params object[] args)
		{
			string str = string.Format(message, args);
			return ShowQuestion(owner, str);
		}

		public static bool ShowQuestion(IWin32Window owner, string message)
		{
			if (DialogResult.Yes == MessageBox.Show(owner, message, GetCurrentApplicationName() + ": " + QuestionTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
			{
				return true;
			}
			return false;
		}

		public static void ShowWarning(string format, params object[] args)
		{
			ShowWarning((IWin32Window)null, format, args);
		}

		public static void ShowWarning(IWin32Window owner, string message, params object[] args)
		{
			ShowWarning(owner, string.Format(message, args));
		}

		public static void ShowWarning(IWin32Window owner, string message)
		{
			MessageBox.Show(owner, message, GetCurrentApplicationName() + ": " + QuestionTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}


        public static String ConvertBytesToWSQBase64(byte[] imagebytes, ImageFormat format)
        {
            MemoryStream msImage = new MemoryStream(imagebytes);
            var imageBytes = ConvertStreamToWSQ(msImage, format);
            var stringBase64 = Convert.ToBase64String(imageBytes);
            return stringBase64;
        }


        public static byte[] ConvertStreamToWSQ(Stream imageStream, ImageFormat format)
        {
            //  const string Components = "Images.WSQ";


            MemoryStream msWSQ = new MemoryStream();

            using (MemoryStream ms = new MemoryStream())
            {
                using (NImage nimage = NImage.FromStream(imageStream))
                {
                    using (var info = (WsqInfo)NImageFormat.Wsq.CreateInfo(nimage))
                    {
                        info.BitRate = WsqInfo.DefaultBitRate;
                        nimage.Save(msWSQ, info);
                    }
                }
            }
            byte[] result = msWSQ.ToArray();
            msWSQ.Dispose();

            return result;
        }

        public static  NBiometricClient ConnectionRemoteMegaMatcher(IWin32Window wind, int adminPort, int port, string hostname)
        {
                        NBiometricClient BiometricClient= new NBiometricClient();
                        BiometricClient.DatabaseConnection = null;
                       BiometricClient.FingersCheckForDuplicatesWhenCapturing = true;
                        BiometricClient.RemoteConnections.AddToCluster(hostname, port, adminPort);
                      

                       try
                       {
                           LongActionDialog.ShowDialog(wind, "Conectándose al Servidor de Reconocimiento Biométrico ... ", new Action<NBiometricClient>(biometricClient =>
                           {
                                         biometricClient.Initialize();
                             
                              
                           }), BiometricClient);
                       }
                       catch (Exception ex)
                       {
                           Utilities.ShowError(ex);
                           BiometricClient.Dispose();
                           BiometricClient = null;
                          
                       }


                       return BiometricClient;
        }
	}
}
