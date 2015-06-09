using Neurotec.Biometrics;
using Neurotec.Biometrics.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FingerCapturer
{
    public partial class MainForm : Form
    {
        #region Public constructor

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Private fields

        private NBiometricClient _biometricClient;

        #endregion

        #region Private form events

        private void MainFormLoad(object sender, EventArgs e)
        {
            _biometricClient = new NBiometricClient { UseDeviceManager = true, BiometricTypes = NBiometricType.Finger };
            _biometricClient.Initialize();

            var enrollFromScanner = new ImageFromScanner { Dock = DockStyle.Fill, BiometricClient = _biometricClient };

            this.Controls.Add(enrollFromScanner);

        }

        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_biometricClient != null)
                _biometricClient.Cancel();
        }

        #endregion


    }
}
