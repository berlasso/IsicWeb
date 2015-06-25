using Neurotec.Licensing;
using System;
using System.Windows.Forms;

namespace Capturer.Forms
{
	public partial class ConnectionForm : Form
	{
		#region Public constructor

		public ConnectionForm()
		{
			InitializeComponent();
		}

		#endregion

		#region Public properties

		public int AdminPort
		{
			get { return Convert.ToInt32(nudAdminPort.Value); }
			set { nudAdminPort.Value = value; }
		}

		public string Address
		{
			get { return tbServerAddress.Text; }
			set { tbServerAddress.Text = value; }
		}

		#endregion

		#region Private form events

		private void BtnCheckClusterConnectionClick(object sender, EventArgs e)
		{
		/*	if (ClusterClient.Instance.CheckConnection(Address, AdminPort))
			{
				Utilities.ShowInformation("Connection test succeeded.");
			}
			else
			{
				Utilities.ShowError("Connection check failed.");
			}*/

		}

		private void BtnDefaultClick(object sender, EventArgs e)
		{
			tbServerAddress.Text = @"mphv12.mpba.gov.ar";
			nudAdminPort.Value = 5000;
		}

		private void BtnOKClick(object sender, EventArgs e)
		{
            const string Components = "Images.WSQ,Biometrics.FingerExtraction,Biometrics.FingerMatching,Devices.FingerScanners,Biometrics.FingerSegmentation,Biometrics.FingerQualityAssessmentBase,Devices.Cameras";
            try
            {
                foreach (string component in Components.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    NLicense.ObtainComponents("mphv12.mpba.gov.ar", 5000, component);
                }
            }
            catch (Exception ex)
            { Utilities.ShowError("Fallo para obtener las licencias ");
 
               return ; }

					DialogResult = DialogResult.OK;
			
		}

		#endregion
	}
}
