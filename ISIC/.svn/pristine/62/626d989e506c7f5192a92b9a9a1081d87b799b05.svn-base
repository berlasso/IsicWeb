using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Capturer
{
	public class Utilities
	{
		private const string ErrorTitle = "Error";
		private const string InformationTitle = "Information";
		private const string QuestionTitle = "Question";
		private const string WarningTitle = "Warning";

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
	}
}
