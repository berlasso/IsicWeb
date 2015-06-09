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
			if (ClusterClient.Instance.CheckConnection(Address, AdminPort))
			{
				Utilities.ShowInformation("Connection test succeeded.");
			}
			else
			{
				Utilities.ShowError("Connection check failed.");
			}
		}

		private void BtnDefaultClick(object sender, EventArgs e)
		{
			tbServerAddress.Text = @"localhost";
			nudAdminPort.Value = 24932;
		}

		private void BtnOKClick(object sender, EventArgs e)
		{
			if (!ClusterClient.Instance.CheckConnection(Address, AdminPort))
			{
				if (Utilities.ShowQuestion(this, "Failed to connect to server, continue anyway?"))
				{
					DialogResult = DialogResult.OK;
				}
				return;
			}
			DialogResult = DialogResult.OK;
		}

		#endregion
	}
}
