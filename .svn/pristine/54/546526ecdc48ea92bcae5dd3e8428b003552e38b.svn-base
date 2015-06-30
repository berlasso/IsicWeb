using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Neurotec.Devices;
using Neurotec.Images;
using Capturer.Forms;


namespace Capturer.Forms
{
	public partial class InfoPanel : UserControl
	{
		#region Public constructor

		public InfoPanel()
		{
			InitializeComponent();

			OnModelChanged();
		}

		#endregion

		#region Private fields

		private DataModel _model;
		private NDeviceManager _deviceManager;

		#endregion

		#region Public properties

		public DataModel Model
		{
			get { return _model; }
			set
			{
				_model = value;
				OnModelChanged();
			}
		}

		public NDeviceManager DeviceManager
		{
			get { return _deviceManager; }
			set { _deviceManager = value; }
		}

		#endregion

		#region Private methods

		private void OnModelChanged()
		{
			if (DesignMode) return;

			bool showThumbnail = false;
			if (Model != null)
			{
				propertyGrid.SelectedObject = Model.Info;

				InfoField thumbnail = null;
				foreach (InfoField item in Model.Info)
				{
					if (item.ShowAsThumbnail)
					{
						thumbnail = item;
						break;
					}
				}
				if (thumbnail != null)
				{
					pictureBoxThumbnail.Image = null;
					pictureBoxThumbnail.Tag = thumbnail;
					lblThumbnailKey.Text = thumbnail.Key;
					showThumbnail = true;
					if (thumbnail.Value != null && thumbnail.Value.GetType() == typeof(byte[]))
					{
						using (MemoryStream stream = new MemoryStream((byte[])thumbnail.Value))
						{
							pictureBoxThumbnail.Image = Image.FromStream(stream);
						}
					}
				}
			}
			else
				propertyGrid.SelectedObject = null;

			if (showThumbnail)
			{
				tableLayoutPanelMain.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 33);
				panelThumnail.Visible = true;
			}
			else
			{
				panelThumnail.Visible = false;
				tableLayoutPanelMain.ColumnStyles[0] = new ColumnStyle(SizeType.AutoSize, 33);
			}
		}

		private void BtnOpenClick(object sender, EventArgs e)
		{
			openFileDialog.Filter = NImages.GetOpenFileFilterString(true, false);
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					InfoField thumbnail = pictureBoxThumbnail.Tag as InfoField;
					NImage image = NImage.FromFile(openFileDialog.FileName);
					thumbnail.Value = image;
					pictureBoxThumbnail.Image = image.ToBitmap();
				}
				catch (Exception ex)
				{
					Utilities.ShowError(ex);
				}
			}
		}

		private void BtnCaptureClick(object sender, EventArgs e)
		{
			bool cameraFound = false;
			foreach (NDevice item in DeviceManager.Devices)
			{
				if (item is NCamera)
				{
					cameraFound = true;
					break;
				}
			}

			if (!cameraFound)
			{
				Utilities.ShowInformation("No cameras connected. Please connect camera and try again");
				return;
			}

			using (PictureCaptureForm form = new PictureCaptureForm())
			{
				form.DeviceManager = DeviceManager;
				if (form.ShowDialog() != DialogResult.OK) return;
				InfoField thumbnail = pictureBoxThumbnail.Tag as InfoField;
				if (thumbnail.Value != null)
				{
					NImage image = thumbnail.Value as NImage;
					if (image != null) image.Dispose();
				}
				thumbnail.Value = form.Image;

				pictureBoxThumbnail.Image = form.Image.ToBitmap();
			}
		}

		#endregion
	}
}
