using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Neurotec.Devices;
using Neurotec.Biometrics.Client;
using Neurotec.Biometrics;
using Neurotec.Biometrics.Gui;
using Neurotec.Images;
using System.IO;

namespace FingerCapturer
{
    public partial class ImageFromScanner : UserControl
    {
        public ImageFromScanner()
        {
            InitializeComponent();
        }
        
        #region Private fields

        private NDeviceManager _deviceManager;
        private NBiometricClient _biometricClient;
        private NSubject _subject;
        private NFinger _subjectFinger;
        
        #endregion

        #region Public properties

        public NBiometricClient BiometricClient
        {
            get { return _biometricClient; }
            set { _biometricClient = value; }
        }

        #endregion

        #region Private methods

        private void EnableControls(bool capturing)
        {
            cancelScanningButton.Enabled = capturing;
            scanButton.Enabled = !capturing;
            var fingerStatus = !capturing && _subjectFinger != null && _subjectFinger.Status == NBiometricStatus.Ok;
            saveImageButton.Enabled = fingerStatus;
            chbShowProcessedImage.Enabled = fingerStatus;
            saveTemplateButton.Enabled = !capturing && _subject != null && _subject.Status == NBiometricStatus.Ok;
        }

        private void OnEnrollCompleted(IAsyncResult r)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnEnrollCompleted), r);
            }
            else
            {
                NBiometricTask task = _biometricClient.EndPerformTask(r);
                EnableControls(false);
                NBiometricStatus status = task.Status;

                // Check if extraction was canceled
                if (status == NBiometricStatus.Canceled) return;

                if (status == NBiometricStatus.Ok)
                {
                    lblQuality.Text = String.Format("Quality: {0}", _subjectFinger.Objects[0].Quality);
                }
                else
                {
                    MessageBox.Show(string.Format("The template was not extracted: {0}.", status), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _subject = null;
                    _subjectFinger = null;
                    EnableControls(false);
                }
            }
        }

        private void UpdateScannerList()
        {
            try
            {
                if (_deviceManager != null)
                {
                    foreach (NDevice item in _deviceManager.Devices)
                    {
                    }
                }
            }
            finally
            {
            }
        }

        #endregion

        #region Private form events

        private void ScanButtonClick(object sender, EventArgs e)
        {
            if (_biometricClient.FingerScanner == null)
            {
                MessageBox.Show(@"Please select a scanner from the list.");
            }
            else
            {
                EnableControls(true);
                lblQuality.Text = String.Empty;

                // Create a finger
                _subjectFinger = new NFinger();

                // Set Manual capturing mode if not automatic selected
                if (false)
                {
                    _subjectFinger.CaptureOptions = NBiometricCaptureOptions.Manual;
                }

                // Add finger to the subject and fingerView
                _subject = new NSubject();
                _subject.Fingers.Add(_subjectFinger);
                _subjectFinger.PropertyChanged += OnAttributesPropertyChanged;
                fingerView.Finger = _subjectFinger;
                fingerView.ShownImage = ShownImage.Original;

                // Begin capturing
                _biometricClient.FingersReturnProcessedImage = true;
                NBiometricTask task = _biometricClient.CreateTask(NBiometricOperations.Capture | NBiometricOperations.CreateTemplate, _subject);
                _biometricClient.BeginPerformTask(task, OnEnrollCompleted, null);
            }
        }

        private void OnAttributesPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Status")
            {
                BeginInvoke(new Action<NBiometricStatus>(status => lblQuality.Text = status.ToString()), _subjectFinger.Status);
            }
        }

        private void CancelScanningButtonClick(object sender, EventArgs e)
        {
            _biometricClient.Cancel();
        }

        private void RefreshListButtonClick(object sender, EventArgs e)
        {
            UpdateScannerList();
        }

        private void SaveImageButtonClick(object sender, EventArgs e)
        {
            if (_subjectFinger.Status == NBiometricStatus.Ok)
            {
                saveFileDialog.FileName = string.Empty;
                saveFileDialog.Title = @"Guardar Imagen";
                saveFileDialog.Filter = NImages.GetSaveFileFilterString();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (chbShowProcessedImage.Checked)
                        {
                            _subjectFinger.ProcessedImage.Save(saveFileDialog.FileName);
                        }
                        else
                        {
                            _subjectFinger.Image.Save(saveFileDialog.FileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            }
        }

        private void SaveTemplateButtonClick(object sender, EventArgs e)
        {
            if (_subject.Status == NBiometricStatus.Ok)
            {
                saveFileDialog.FileName = string.Empty;
                saveFileDialog.Filter = string.Empty;
                saveFileDialog.Title = @"Guardar Template";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Save template to file
                        File.WriteAllBytes(saveFileDialog.FileName, _subject.GetTemplateBuffer().ToArray());
                    }
                    catch (Exception ex)
                    {
                       
                    }
                }
            }
        }

        private void EnrollFromScannerLoad(object sender, EventArgs e)
        {
            _deviceManager = _biometricClient.DeviceManager;
            UpdateScannerList();
            saveFileDialog.Filter = NImages.GetSaveFileFilterString();
        }

        private void ScannersListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            _biometricClient.FingerScanner = scannersListBox.SelectedItem as NFScanner;
        }

        private void ChbShowProcessedImageCheckedChanged(object sender, EventArgs e)
        {
            fingerView.ShownImage = chbShowProcessedImage.Checked ? ShownImage.Result : ShownImage.Original;
        }

        private void FingerViewMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && chbShowProcessedImage.Enabled)
            {
                chbShowProcessedImage.Checked = !chbShowProcessedImage.Checked;
            }
        }

        private void ForceCaptureButtonClick(object sender, EventArgs e)
        {
            _biometricClient.Force();
        }

        #endregion

    }
}
