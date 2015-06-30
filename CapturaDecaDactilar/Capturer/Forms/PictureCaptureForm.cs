using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Neurotec.Devices;
using Neurotec.Images;
using Neurotec.Media;

namespace Capturer.Forms
{
	public partial class PictureCaptureForm : Form
	{
		#region Public constructor

		public PictureCaptureForm()
		{
			InitializeComponent();
		}

		#endregion

		#region Private fields

		private bool _capture;
		private NMediaFormat _pendingFormat;

		#endregion

		#region Public properties

		public NDeviceManager DeviceManager { get; set; }

		public NImage Image { get; set; }

		#endregion

		#region Private form events

		private void PictureCaptureFormLoad(object sender, EventArgs e)
		{
			if (DeviceManager == null) throw new ArgumentNullException("DeviceManager");

			foreach (NDevice device in DeviceManager.Devices)
			{
				if ((device.DeviceType & NDeviceType.Camera) == NDeviceType.Camera)
					cbCameras.Items.Add(device);
			}

			if (cbCameras.Items.Count > 0)
				cbCameras.SelectedIndex = 0;
		}

		private void PictureCaptureFormFormClosing(object sender, FormClosingEventArgs e)
		{
			CancelCapture();
		}

		private void BtnCaptureClick(object sender, EventArgs e)
		{
			NCamera camera = cbCameras.SelectedItem as NCamera;
			if (camera != null)
			{
				if (backgroundWorker.IsBusy)
				{
					_capture = true;
				}
				else
				{
					if (camera.IsStillCaptureSupported) camera.StillCaptured += new EventHandler<NCameraStillCapturedEventArgs>(CameraStillCaptured);
					camera.StartCapturing();
					backgroundWorker.RunWorkerAsync(camera);
				}
			}
			else Utilities.ShowWarning("Camera not selected");
		}

		private void CameraStillCaptured(object sender, NCameraStillCapturedEventArgs e)
		{
			BeginInvoke(new Action<NImage>(OnStillCaptured), NImage.FromStream(e.Stream));
		}

		private void CbCamerasSelectedIndexChanged(object sender, EventArgs e)
		{
			CancelCapture();

			NCamera camera = cbCameras.SelectedItem as NCamera;
			if (camera == null) return;

			cbFormats.Items.Clear();
			cbFormats.BeginUpdate();
			try
			{
				if (camera.IsStillCaptureSupported) camera.StillCaptured += new EventHandler<NCameraStillCapturedEventArgs>(CameraStillCaptured);
				camera.StartCapturing();

				foreach (NMediaFormat item in camera.GetFormats())
				{
					cbFormats.Items.Add(item);
				}

				NMediaFormat current = camera.GetCurrentFormat();
				if (current != null)
				{
					if (cbFormats.Items.Contains(current)) cbFormats.SelectedItem = current;
					else
					{
						cbFormats.Items.Insert(0, current);
						cbFormats.SelectedItem = current;
					}
				}
			}
			finally
			{
				cbFormats.EndUpdate();
			}

			backgroundWorker.RunWorkerAsync(camera);
		}

		private void ViewImage(Bitmap image)
		{
			Image old = pictureBox.Image;
			pictureBox.Image = image;
			if (old != null) old.Dispose();
		}

		private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			NCamera camera = e.Argument as NCamera;
			if (camera == null) return;

			try
			{
				while (!backgroundWorker.CancellationPending)
				{
					if (_pendingFormat != null)
					{
						camera.SetCurrentFormat(_pendingFormat);
						_pendingFormat = null;
					}
					using (NImage frame = camera.GetFrame())
					{
						if (frame == null) break;
						BeginInvoke(new Action<Bitmap>(ViewImage), frame.ToBitmap());
						if (_capture)
						{
							Image = frame.Clone() as NImage;
							_capture = false;
							break;
						}
					}
				}
			}
			finally
			{
				camera.StopCapturing();
				if (camera.IsStillCaptureSupported) camera.StillCaptured -= new EventHandler<NCameraStillCapturedEventArgs>(CameraStillCaptured);
			}
		}

		private void BtnOkClick(object sender, EventArgs e)
		{
			if (Image == null)
			{
				Utilities.ShowWarning("Image not captured");
				return;
			}

			CancelCapture();
			DialogResult = DialogResult.OK;
		}

		private void CbFormatsSelectedIndexChanged(object sender, EventArgs e)
		{
			_pendingFormat = cbFormats.SelectedItem as NMediaFormat;
		}

		#endregion

		#region Private methods

		private void CancelCapture()
		{
			if (backgroundWorker.IsBusy)
			{
				backgroundWorker.CancelAsync();
				while (backgroundWorker.IsBusy)
				{
					Thread.Sleep(0);
					Application.DoEvents();
				}
			}
		}

		private void OnStillCaptured(NImage img)
		{
			CancelCapture();
			Image = img;
		}

		#endregion
	}
}
