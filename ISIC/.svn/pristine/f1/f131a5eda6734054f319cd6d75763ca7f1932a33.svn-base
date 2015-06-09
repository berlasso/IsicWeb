using System;
using System.Windows.Forms;
using Neurotec.Biometrics;
using Neurotec.Biometrics.Client;

namespace Capturer.Forms
{
	public partial class ExtractionOptionsForm : Form
	{
		#region Public constructor

		public ExtractionOptionsForm()
		{
			InitializeComponent();

			cbTemplateSize.Items.Add(NTemplateSize.Small);
			cbTemplateSize.Items.Add(NTemplateSize.Medium);
			cbTemplateSize.Items.Add(NTemplateSize.Large);
		}

		#endregion

		#region Public properties

		public NBiometricClient BiometricClient { get; set; }

		#endregion

		#region Private form events

		private void BtnDefaultClick(object sender, EventArgs e)
		{
			BiometricClient.ResetProperty("Fingers.TemplateSize");
			BiometricClient.ResetProperty("Fingers.QualityThreshold");
			BiometricClient.ResetProperty("Fingers.MaximalRotation");
			BiometricClient.ResetProperty("Fingers.FastExtraction");
			LoadSettings();
		}
	
		private void BtnOkClick(object sender, EventArgs e)
		{
			if (SaveSettings())
				DialogResult = DialogResult.OK;
		}

		private void OptionsFormLoad(object sender, EventArgs e)
		{
			if (BiometricClient == null) throw new ArgumentException("BiometricClient");
			LoadSettings();
		}

		#endregion

		#region Private methods

		private bool SaveSettings()
		{
			try
			{
				BiometricClient.FingersTemplateSize = (NTemplateSize)cbTemplateSize.SelectedItem;
				BiometricClient.FingersQualityThreshold = Convert.ToByte(nudQualityThreshold.Value);
				BiometricClient.FingersMaximalRotation = Convert.ToSingle(nudMaximalRotation.Value);
				BiometricClient.FingersFastExtraction = chbFastExtraction.Checked;
				return true;
			}
			catch (Exception ex)
			{
				Utilities.ShowError("Failed to set value: {0}", ex.Message);
				return false;
			}
		}

		private void LoadSettings()
		{
			cbTemplateSize.SelectedItem = BiometricClient.FingersTemplateSize;
			nudQualityThreshold.Value = BiometricClient.FingersQualityThreshold;
			nudMaximalRotation.Value = Convert.ToDecimal(BiometricClient.FingersMaximalRotation);
			chbFastExtraction.Checked = BiometricClient.FingersFastExtraction;
		}

		#endregion
	}
}
