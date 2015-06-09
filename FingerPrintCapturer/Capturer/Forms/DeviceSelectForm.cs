using System;
using System.Windows.Forms;
using Neurotec.Biometrics;
using Neurotec.Devices;
using FingerCapturer.Properties;

namespace Capturer.Forms
{
	public partial class DeviceSelectForm : Form
	{
		#region Public constructor

		public DeviceSelectForm()
		{
			InitializeComponent();
		}

		#endregion

		#region Public properties

		public NDeviceManager DeviceManager { get; set; }

		public NFScanner SelectedDevice { get; set; }

		#endregion

		#region Private form methods

		private void ScannerFormLoad(object sender, EventArgs e)
		{
			cbScanner.BeginUpdate();
			try
			{
				cbScanner.Items.Clear();
				if (DeviceManager != null)
				{
					foreach (NDevice item in DeviceManager.Devices)
					{
						if (item is NFScanner)
						{
							cbScanner.Items.Add(item);
						}
					}

					cbScanner.SelectedItem = SelectedDevice;
					if (cbScanner.SelectedItem == null && cbScanner.Items.Count > 0)
					{
						cbScanner.SelectedIndex = 0;
					}
				}
			}
			finally
			{
				cbScanner.EndUpdate();
			}
		}

		private void CbScannerSelectedIndexChanged(object sender, EventArgs e)
		{
			SelectedDevice = cbScanner.SelectedItem as NFScanner;
			if (SelectedDevice != null)
			{
				bool canCaptureSlaps = false;
				bool canCaptureRolled = false;

				foreach (NFPosition item in SelectedDevice.GetSupportedPositions())
				{
					if (!NBiometricTypes.IsPositionFourFingers(item)) continue;
					canCaptureSlaps = true;
					break;
				}

				foreach (NFImpressionType item in SelectedDevice.GetSupportedImpressionTypes())
				{
					if (!NBiometricTypes.IsImpressionTypeRolled(item)) continue;
					canCaptureRolled = true;
					break;
				}

				if (canCaptureRolled) lblCanCaptureRolled.Image = Resources.Ok;
				else lblCanCaptureRolled.Image = Resources.Bad;

				if (canCaptureSlaps) lblCanCaptureSlaps.Image = Resources.Ok;
				else lblCanCaptureSlaps.Image = Resources.Bad;
			}
			else
			{
				lblCanCaptureRolled.Visible = false;
				lblCanCaptureSlaps.Visible = false;
			}
		}

		private void BtnOkClick(object sender, EventArgs e)
		{
			if (SelectedDevice != null) DialogResult = DialogResult.OK;
			else
				Utilities.ShowWarning("Scanner not selected");
		}

		#endregion
	}
}
