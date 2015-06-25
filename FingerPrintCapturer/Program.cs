using Neurotec.Licensing;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FingerCapturer
{
	static class Program
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			logger.Info("Iniciando Applicacion");
			logger.Info("Copiando librerias nativas");
			CopyNativeLibs();
			const string Components = "Biometrics.FingerExtraction,Biometrics.FingerMatching,Devices.FingerScanners,Biometrics.FingerSegmentation,Biometrics.FingerQualityAssessmentBase,Devices.Cameras";
			try
			{
				foreach (string component in Components.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					NLicense.ObtainComponents("mphv12.mpba.gov.ar", 5000, component);
				}

				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				//Application.Run(new MainForm());
               Application.Run(new Capturer.Forms.MainForm());
			}
			catch (Exception ex)
			{
				logger.ErrorException("Error al consultar licencias", ex);
			}
			finally
			{
				NLicense.ReleaseComponents(Components);
			} 
		}

		static void CopyNativeLibs()
		{
			// Copy from the current directory, include subdirectories.
			if (Directory.Exists(@".\lib"))
			{
			   DirectoryCopy(@".\lib", @".", true);
			}
		}

		private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
		{
			// Get the subdirectories for the specified directory.
			DirectoryInfo dir = new DirectoryInfo(sourceDirName);
			DirectoryInfo[] dirs = dir.GetDirectories();

			if (!dir.Exists)
			{
				throw new DirectoryNotFoundException(
					"Source directory does not exist or could not be found: "
					+ sourceDirName);
			}

			// If the destination directory doesn't exist, create it. 
			if (!Directory.Exists(destDirName))
			{
				Directory.CreateDirectory(destDirName);
			}

			// Get the files in the directory and copy them to the new location.
			FileInfo[] files = dir.GetFiles();
			foreach (FileInfo file in files)
			{
				string temppath = Path.Combine(destDirName, file.Name);
				if (!File.Exists(temppath))
				{
					// This path is a file
					file.CopyTo(temppath, false);
				} 
			}

			// If copying subdirectories, copy them and their contents to new location. 
			if (copySubDirs)
			{
				foreach (DirectoryInfo subdir in dirs)
				{
					string temppath = Path.Combine(destDirName, subdir.Name);
					DirectoryCopy(subdir.FullName, temppath, copySubDirs);
				}
			}
		}
	}
}
