using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Neurotec.Biometrics;
using Neurotec.Biometrics.Client;
using Neurotec.Biometrics.Gui;
using Neurotec.Devices;
using Neurotec.Images;
using Neurotec.IO;
using Neurotec.Licensing;

using FingerCapturer.Properties;
using Neurotec;
using System.ComponentModel;
using System.Text;
using System.Drawing.Imaging;
using MPBA.RenaperClient; 
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Drawing.Drawing2D;
using System.Reflection;
using AutoMapper;
using FingerCapturer.ServiceCapturaDecaDactilar;
using Neurotec.Biometrics.Standards;


namespace Capturer.Forms
{
    public partial class MainForm : Form
    {
        #region Public constructor
        public NBiometricClient  BiometricClient;
        bool estadoUpdateHuellas = false;
        bool estadoRegistroBiometrico = false;
        DateTime comienzaProceso = DateTime.Now;

        public MainForm()
        {
            InitializeComponent();
            /*Se conecta al Servidor fijarse si no hacerlo en cada extraccion al final y ver como liberarlo*/
             BiometricClient = Utilities.ConnectionRemoteMegaMatcher(this, 24932, 25452, "mpapdesa01");
             BiometricClient.Initialize();
             LimpiarResultados();
        }

        public void InicializaImputado(string CODBARRA, string Apellido, string Nombres, string DNI, string Sexo, string IPP)
        {
            _codBarra = CODBARRA;
            _apellido = Apellido;
            _nombres = Nombres;
            _dni = DNI;
            _sexo = Sexo;
            _IPP = IPP;
        }

        #endregion

        #region Private fields

        private MemoryStream[] dedosCapturados = new MemoryStream[10];
        private string _codBarra, _apellido, _nombres, _dni, _sexo, _IPP;
        private readonly NFPosition[] _slaps = new NFPosition[]
		{
			NFPosition.LeftIndexMiddleFingers,
            NFPosition.RightIndexMiddleFingers,

            NFPosition.LeftMiddleRingFingers,
            NFPosition.RightMiddleRingFingers,

            NFPosition.LeftRingLittleFingers,
            NFPosition.RightRingLittleFingers,
            NFPosition.PlainThumbs
		};

        private readonly NFPosition[] _fingers = new NFPosition[]
		{
			NFPosition.LeftLittle,
			NFPosition.LeftRing,
			NFPosition.LeftMiddle,
			NFPosition.LeftIndex,
			NFPosition.LeftThumb,
			NFPosition.RightThumb,
			NFPosition.RightIndex,
			NFPosition.RightMiddle,
			NFPosition.RightRing,
			NFPosition.RightLittle,
		};


        private bool _canCaptureRolled;
        private bool _captureStarted;
        public NFinger _huellaCapturada;
        private bool _newSubject = true;

        private DecaDactilarForm _decaForm;
        private FingerSingleForm _captureSingle;
        private bool _exit;
        private NFinger[] dedos = new NFinger[10];
        private NSubject imputadosHuellas;


        private DataModel _model;
        private NBiometricClient _biometricClient;

        #endregion

        #region Private form events

        private void MainFormLoad(object sender, EventArgs e)
        {
            if (DesignMode) return;
            BeginInvoke(new MethodInvoker(OnMainFormLoaded));



            /*Recuperar de un Web Service el Codigo de Barras y el Apellido y nombre del Imputado*/

            /*El label es lo que se despliega en la ppal sincronizado con el tabPage*/
            /*private string _codBarra, _apellido, _nombres, _dni, _sexo, _IPP;*/

            lApeyNom.Text = _apellido != "" ? _apellido + ", " + _nombres : lApeyNom.Text;
            this.lCodigoBarras.Text = _codBarra != "" ? _codBarra : this.lCodigoBarras.Text;
            this.apellido.Text = _apellido;
            this.tCodigoBarra.Text = this.lCodigoBarras.Text;
            this.nombres.Text = _nombres;
            this.DNI.Text = _dni;
            this.rFemenino.Checked = (_sexo == "F");
            this.rMasculino.Checked = (_sexo == "M");

        }

        private void FingerSelectorFingerClick(object sender, FingerSelector.FingerClickArgs e)
        {
            var missing = new List<NFPosition>(fSelector.MissingPositions);
            NFPosition position = e.Position;
            if (missing.Contains(position))
                missing.Remove(position);
            else
                missing.Add(position);

            fSelector.MissingPositions = missing.ToArray();
        }

        private void BtnStartCapturingClick(object sender, EventArgs e)
        {




            // Esto es porque siempre empieza con un sujeto nuevo en cada captura
            // Agregado

            _model.Subject = null;
            LimpiarImagenes();
            LimpiarResultados();
            _model.Subject = new NSubject();
            imputadosHuellas = new NSubject();

            _model.Subject.Fingers.CollectionChanged += OnFingersCollectionChanged;
            CreateFingers(_model.Subject);
            if (_model.Subject.Fingers.Count == 0)
            {
                Utilities.ShowWarning(this, "No hay dedos seleccionados para la captura");
                return;
            }

            _captureStarted = true;
            _newSubject = false;
            EnableControls(false);

            imputadosHuellas.MissingFingers.Concat(_model.Subject.MissingFingers);


            _captureSingle = new FingerSingleForm();
            _captureSingle.BiometricClient = _biometricClient;
            _captureSingle.Subject = _model.Subject;
            _captureSingle.imputadoH = new NSubject();

            _captureSingle.FormClosed += new FormClosedEventHandler(CaptureFormSingleClosed);

            _captureSingle.Show(this);







        }

        private void OnChangeHuellaCorriente(object sender, PropertyChangedEventArgs e)
        {
            string a;
            a = e.PropertyName;

        }
        private static string EnumToString(Enum value)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in value.ToString())
            {
                if (char.IsUpper(c)) sb.Append(' ');
                sb.Append(c);
            }
            return sb.ToString().Trim();
        }
        private void OnFingersCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

            if (_model.Subject.Fingers.Count() == 0)
            {
                LimpiarImagenes();

                chbCaptureRolled.Enabled = true;

            }
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        BeginInvoke(new Action<NFinger[]>(newItems =>
                            {
                                NFingerView view = null;
                                foreach (NFinger f in newItems)
                                {
                                    view = GetView(f);
                                    if (view != null)
                                        view.Finger = f;

                                }

                            }), (object)e.NewItems.Cast<NFinger>().ToArray());



                        break;
                    }
                case NotifyCollectionChangedAction.Remove:
                    {
                        BeginInvoke(new Action<NFinger[]>(oldItems =>
                            {
                                NFingerView view = null;
                                foreach (NFinger f in oldItems)
                                {
                                    view = GetView(f);
                                    if (view != null)
                                        view.Finger = null;


                                }
                            }), (object)e.OldItems.Cast<NFinger>().ToArray());
                        break;
                    }
                case NotifyCollectionChangedAction.Reset:
                    {
                        BeginInvoke(new Action(() =>
                        {
                            NFingerView view = null;

                            foreach (NFPosition position in _fingers)
                            {
                                view = GetView(position, false);
                                view.Finger = null;
                                view = GetView(position, true);
                                view.Finger = null;

                            }
                        }));
                        break;
                    }
                default:
                    break;
            }
        }

        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();


            if (_captureSingle != null)
            {
                Text = @"Cierre de la captura de Huellas ...";
                e.Cancel = true;
                _exit = true;
                _captureSingle.Close();
            }

            if (_decaForm != null)
            {
                Text = @"Cierre de la Captura de Huellas ...";
                e.Cancel = true;
                _exit = true;
                _decaForm.Close();
            }
            if (BiometricClient != null)
            {
                BiometricClient.Dispose();
                BiometricClient = null;
            }
        }

        private void CaptureFormFormClosed(object sender, FormClosedEventArgs e)
        {


            _captureStarted = false;
            EnableControls(true);

            if (_exit) Close();
        }
        private void CaptureFormSingleClosed(object sender, FormClosedEventArgs e)
        {
             _captureSingle.Dispose();
            _captureSingle = null;

            _captureStarted = false;
            EnableControls(true);

            if (_exit) Close();
        }

        private void CaptureComboBoxCheckedChanged(object sender, EventArgs e)
        {

            btnStartCapturing.Enabled = chbCaptureRolled.Checked;
        }

        private void ChbShowOriginalCheckedChanged(object sender, EventArgs e)
        {
            CheckBox target = (CheckBox)sender;
            CheckBox other = target;
            if (other.Checked == target.Checked) return;
            other.Checked = target.Checked;

            NFingerView view;
            ShownImage shown = target.Checked ? ShownImage.Original : ShownImage.Result;
            foreach (NFPosition position in _fingers)
            {
                view = (NFingerView)GetView(position, false);
                view.ShownImage = shown;

                view = (NFingerView)GetView(position, true);
                view.ShownImage = shown;
            }
        }

        private void MainFormResize(object sender, EventArgs e)
        {
            ZoomViews();
        }

        private void TabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            ZoomViews();
        }

        private void ViewMouseEnter(object sender, EventArgs e)
        {
            NFingerView view = sender as NFingerView;
            if (view == null || _captureStarted) return;
            if (toolStripViewControls.Parent != null) toolStripViewControls.Parent.Controls.Remove(toolStripViewControls);
            if (view.Finger != null)
            {
                NFrictionRidge finger = view.Finger;
                if (finger != _biometricClient.CurrentBiometric)
                {
                    if (finger.Image != null)
                    {
                        bool canSaveRecord = false;
                        if (NBiometricTypes.IsPositionSingleFinger(finger.Position))
                        {
                            canSaveRecord = finger.Objects.ToArray().Any(x => x.Template != null);
                        }
                        tsbSaveRecord.Visible = canSaveRecord;
                        toolStripViewControls.Tag = finger;
                        view.Parent.Controls.Add(toolStripViewControls);
                        toolStripViewControls.Visible = true;
                        toolStripViewControls.BringToFront();
                    }
                }
            }
        }

        private void ViewMouseLeave(object sender, EventArgs e)
        {
            if (!toolStripViewControls.Bounds.Contains(toolStripViewControls.PointToClient(MousePosition)))
            {
                toolStripViewControls.Visible = false;
                toolStripViewControls.Tag = null;
            }
        }

        private void TsbSaveImageClick(object sender, EventArgs e)
        {
            string fileName = string.Empty;
            NFinger finger = (NFinger)toolStripViewControls.Tag;
            saveFileDialog.Filter = NImages.GetSaveFileFilterString();
            saveFileDialog.FileName = fileName;
            if (finger != null)
            {
                bool originalImage = chbShowOriginalRolled.Checked && NBiometricTypes.IsPositionSingleFinger(finger.Position);
                bool isRolled = NBiometricTypes.IsImpressionTypeRolled(finger.ImpressionType);
                using (NImage image = originalImage ? finger.GetImage(false) : finger.GetProcessedImage(false))
                {
                    fileName = string.Format("{0}{1}{2}", finger.Position, isRolled ? "_Rolled" : string.Empty, originalImage ? string.Empty : "_Binarized");
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        image.Save(saveFileDialog.FileName);
                    }
                }
            }
        }

        private void TsbSaveRecordClick(object sender, EventArgs e)
        {
            NFinger finger = (NFinger)toolStripViewControls.Tag;
            saveFileDialog.Filter = string.Empty;
            if (finger != null)
            {
                bool isRolled = NBiometricTypes.IsImpressionTypeRolled(finger.ImpressionType);
                saveFileDialog.FileName = string.Format("{0}{1}", finger.Position, isRolled ? "_Rolled" : string.Empty);
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    NFRecord record = finger.Objects.ToArray().First().Template;
                    using (NBuffer buffer = record.Save())
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, buffer.ToArray());
                    }
                }
            }
        }

        private void NewToolStripMenuItemClick(object sender, EventArgs e)
        {
            /*if (!Utilities.ShowQuestion(this, "This will erase all images and records. Are you sure you want to continue?")) return;*/

            if (_model.Subject != null)
            {
                _model.Subject.Fingers.Clear();
                _model.Subject = null;
            }
            fSelector.MissingPositions = null;
            LimpiarResultados();
            LimpiarImagenes();

            _model = new DataModel();
            _model.Info.AddRange(LoadInfoFields());
            infoPanel.Model = _model;
            _newSubject = true;
            EnableControls(true);
            this.apellido.Text = "";
            this.tCodigoBarra.Text = "";
            this.DNI.Text = "";
            this.nombres.Text = "";
        }
        /*GUARDA EL TEMPLATE COMO ATRCHIVOS*/
        private void SaveTemplateToolStripMenuItemClick(object sender, EventArgs e)
        {
            saveFileDialog.FileName = string.Empty;
            saveFileDialog.Filter = string.Empty;

            if (_model.Subject == null)
            {
                Utilities.ShowWarning("No hay datos para guardar");
            }
            else
            {
                using (NTemplate template = _model.Subject.GetTemplate())
                {
                    if (template.Fingers == null)
                    {
                        Utilities.ShowWarning("No hay datos para guardar");
                    }
                    else if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (NBuffer buffer = template.Save())
                            File.WriteAllBytes(saveFileDialog.FileName, buffer.ToArray());
                    }
                }
            }
        }

        /*GUARDA LAS IMAGENES COMO ARCHIVOS SEPARADOS*/
        private void SaveImagesToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (_model.Subject != null)
            {
                NSubject subject = _model.Subject;
                var fingers = subject.Fingers.Where(x => x.Status == NBiometricStatus.Ok);
                if (fingers.Count() > 0)
                {
                    if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
                    try
                    {
                        string dir = folderBrowserDialog.SelectedPath;
                        foreach (NFinger item in fingers)
                        {
                            bool isRolled = NBiometricTypes.IsImpressionTypeRolled(item.ImpressionType);
                            string name = string.Format("{0}{1}.png", item.Position, isRolled ? "_rolled" : string.Empty);
                            item.Image.Save(Path.Combine(dir, name));
                        }
                    }
                    catch (Exception ex)
                    {
                        Utilities.ShowError(ex);
                    }
                }
                else Utilities.ShowWarning("No hay datos para guardar");
            }
            else Utilities.ShowWarning("No hay datos para guardar");
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }

        private void ChangeScannerToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (DeviceSelectForm form = new DeviceSelectForm())
            {
                form.SelectedDevice = _biometricClient.FingerScanner;
                form.DeviceManager = _biometricClient.DeviceManager;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (_biometricClient.FingerScanner != form.SelectedDevice)
                    {
                        OnSelectedDeviceChanging(form.SelectedDevice);
                    }
                }
            }
        }

        private void OptionsToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (ExtractionOptionsForm form = new ExtractionOptionsForm())
            {
                form.BiometricClient = _biometricClient;
                form.ShowDialog();
            }
        }

        private void AboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            Neurotec.Gui.AboutBox.Show(this);
        }
        /* EXPORTA LAS IMAGENES Y TEMPLATES*/

        private void ExportToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                _model.Save(folderBrowserDialog.SelectedPath);
            }
        }

        private void EditRequiredInfoToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (EditInfoForm form = new EditInfoForm())
            {
                form.Information = LoadInfoFields();
                if (form.ShowDialog() != DialogResult.OK) return;
                _model.Info.Clear();
                _model.Info.AddRange(form.Information);
                infoPanel.Model = _model;
            }
        }

        private void EnrollToServerToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (!Settings.Default.UseCluster)
            {
                Utilities.ShowInformation("Cluster enroll is not configured. Use \"Options->Change connection settings\" and \"Options->Edit required info\" to configure it, and try again");
                return;
            }

            try
            {
                LongTaskForm.RunLongTask("Enrolling to server ...", EnrollToServerDoWork, null);
            }
            catch (Exception ex)
            {
                Utilities.ShowError(ex);
            }
        }

        private void ChangeconntionSettingsToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (ConnectionForm form = new ConnectionForm())
            {
                try
                {
                    form.Address = Settings.Default.ConnectionAddress;
                    form.AdminPort = Settings.Default.ConnectionAdminPort;
                }
                catch { }

                if (form.ShowDialog() != DialogResult.OK) return;

                Settings.Default.ConnectionAdminPort = form.AdminPort;
                Settings.Default.ConnectionAddress = form.Address;
                Settings.Default.Save();

                _biometricClient.CurrentBiometricCompleted -= OnCurrentBiometricCompleted;
                _biometricClient.Dispose();
                _biometricClient = CreateBiometricClient();
            }
        }

        private void OnCurrentBiometricCompleted(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(ZoomViews));
        }

        private void EnrollToServerDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            ClusterClient.Instance.Address = Settings.Default.ConnectionAddress;
            ClusterClient.Instance.AdminPort = Settings.Default.ConnectionAdminPort;
            if (!ClusterClient.Instance.CheckConnection())
            {
                Utilities.ShowWarning("Failed to connect to server. Please check connection settings in \"Options->Change connection settings\"");
                return;
            }

            int keyIndex;
            object[] values = _model.GetClusterEnrollParams(Settings.Default.ClusterDbidField,
                                                            Settings.Default.ClusterTemplateField,
                                                            Settings.Default.ClusterHashField,
                                                            out keyIndex);
            ClusterClient.Instance.EnrollTemplate(keyIndex, values);
        }

        #endregion

        #region Private methods

        private void OnMainFormLoaded()
        {
            try
            {
                _biometricClient = CreateBiometricClient();
            }
            catch (Exception ex)
            {
                Utilities.ShowError(ex);
                BeginInvoke(new MethodInvoker(Close));
                return;
            }
         
            _model = new DataModel();
            _model.Info.AddRange(LoadInfoFields());
            infoPanel.Model = _model;
            infoPanel.DeviceManager = _biometricClient.DeviceManager;

            toolStripViewControls.Visible = false;
            try
            {
                chbCaptureRolled.Checked = Settings.Default.ScanRolled;


            }
            catch { }

            if (_biometricClient.FingerScanner == null)
            {
                using (DeviceSelectForm form = new DeviceSelectForm())
                {
                    form.DeviceManager = _biometricClient.DeviceManager;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        _biometricClient.FingerScanner = form.SelectedDevice;
                    }
                    else
                    {
                        Close();
                    }
                }
            }

            OnSelectedDeviceChanging(_biometricClient.FingerScanner);
        }

        private NBiometricClient CreateBiometricClient()
        {
            NBiometricClient client = new NBiometricClient();

            string propertiesString = string.Empty;
            try { propertiesString = Settings.Default.ClientProperties; }
            catch { }

            NPropertyBag propertyBag = NPropertyBag.Parse(propertiesString);
            propertyBag.ApplyTo(client);

            client.BiometricTypes = NBiometricType.Finger | NBiometricType.Face;
            client.FingersReturnProcessedImage = true;
            client.UseDeviceManager = true;
            client.FingersCalculateNfiq = NLicense.IsComponentActivated("Biometrics.FingerQualityAssessmentBase");

            int adminPort = 0;
            string address = string.Empty;
            try
            {
                adminPort = Settings.Default.ConnectionAdminPort;
                address = Settings.Default.ConnectionAddress;
            }
            catch { }

            LongTaskForm.RunLongTask("Initializing biometric client ...", (sender, args) => { ((NBiometricClient)args.Argument).Initialize(); }, client);

            string preferedDeviceId = string.Empty;
            try { preferedDeviceId = Settings.Default.SelectedFScannerId; }
            catch { }

            NDevice device = null;
            if (!string.IsNullOrEmpty(preferedDeviceId))
            {
                if (client.DeviceManager.Devices.Contains(preferedDeviceId))
                    device = client.DeviceManager.Devices[preferedDeviceId];
            }
            client.FingerScanner = (NFScanner)device;

            client.CurrentBiometricCompleted += OnCurrentBiometricCompleted;

            return client;
        }

        private void LimpiarImagenes()
        {
            nfvLeftIndexRolled.Finger = null;
            nfvLeftLittleRolled.Finger = null;
            nfvLeftMiddleRolled.Finger = null; ;
            nfvLeftRingRolled.Finger = null;

            nfvRightIndexRolled.Finger = null;
            nfvRightLittleRolled.Finger = null;
            nfvRightMiddleRolled.Finger = null;
            nfvRightRingRolled.Finger = null;
            nfvRightThumbRolled.Finger = null;
        }
        private void LimpiarResultados()
        {

            this.lb_estadoRegistro.Text = "";
             this.lbStatus.Text = "";
             this.picEspera.Visible = false;
           

        }



        private NFingerView GetView(NFPosition position, bool isRolled)
        {
            switch (position)
            {
                case NFPosition.LeftIndex: return nfvLeftIndexRolled;
                case NFPosition.LeftLittle: return nfvLeftLittleRolled;
                case NFPosition.LeftMiddle: return nfvLeftMiddleRolled;
                case NFPosition.LeftRing: return nfvLeftRingRolled;
                case NFPosition.LeftThumb: return nfvLeftThumbRolled;
                case NFPosition.RightIndex: return nfvRightIndexRolled;
                case NFPosition.RightLittle: return nfvRightLittleRolled;
                case NFPosition.RightMiddle: return nfvRightMiddleRolled;
                case NFPosition.RightRing: return nfvRightRingRolled;
                case NFPosition.RightThumb: return nfvRightThumbRolled;
                default: return null;
            }
        }

        private NFingerView GetView(NFinger finger)
        {
            NFPosition position = finger.Position;
            bool isRolled = NBiometricTypes.IsImpressionTypeRolled(finger.ImpressionType);
            return GetView(position, isRolled);
        }

        private InfoField[] LoadInfoFields()
        {
            List<InfoField> info = new List<InfoField>();
            string[] split = Settings.Default.Information.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in split)
            {
                InfoField inf = new InfoField(item);
                if (inf.Key == Settings.Default.ClusterHashField ||
                    inf.Key == Settings.Default.ClusterTemplateField ||
                    inf.ShowAsThumbnail)
                {
                    inf.IsEditable = false;
                }
                info.Add(inf);
            }
            return info.ToArray();
        }

        private void CreateFingers(NSubject subject)
        {
            var missing = fSelector.MissingPositions;
            foreach (var item in missing)
            {
                subject.MissingFingers.Add(item);
            }

            var fingers = _fingers.Where(x => !missing.Contains(x));




            foreach (var pos in fingers)
            {
                subject.Fingers.Add(new NFinger { Position = pos, ImpressionType = NFImpressionType.LiveScanRolled });
            }

        }

        private void OnSelectedDeviceChanging(NFScanner newDevice)
        {
            bool canCaptureRolled = false;

            if (newDevice != null)
            {

                foreach (NFImpressionType item in newDevice.GetSupportedImpressionTypes())
                {
                    if (NBiometricTypes.IsImpressionTypeRolled(item))
                    {
                        canCaptureRolled = true;
                        break;
                    }
                }
            }

            if (_biometricClient.FingerScanner != null && _biometricClient.FingerScanner != newDevice)
            {
                if (Utilities.ShowQuestion("Cambiando el scanner borrarán los datos caputrados.. Continúa ?"))
                {
                    if (_model.Subject != null)
                    {
                        _model.Subject.Fingers.Clear();
                        _model.Subject = null;
                    }
                    fSelector.MissingPositions = null;

                    _model = new DataModel();
                    _model.Info.AddRange(LoadInfoFields());
                    infoPanel.Model = _model;
                    _newSubject = true;
                }
                else return;
            }


            _canCaptureRolled = canCaptureRolled;

            _biometricClient.FingerScanner = newDevice;
            ;
            if (!_canCaptureRolled) chbCaptureRolled.Checked = false;
            EnableControls(true);
        }

        private void SaveSettings()
        {
            if (_biometricClient != null)
            {
                Settings.Default.SelectedFScannerId = _biometricClient.FingerScanner != null ? _biometricClient.FingerScanner.Id : null;
                Settings.Default.ScanRolled = chbCaptureRolled.Checked;

                Settings.Default.ShowOriginal = chbShowOriginalRolled.Checked;

                NPropertyBag propertyBag = new NPropertyBag();
                _biometricClient.CaptureProperties(propertyBag);
                Settings.Default.ClientProperties = propertyBag.ToString();
                Settings.Default.Save();
            }
        }

        private void EnableControls(bool enable)
        {
            btnStartCapturing.Enabled = enable && (chbCaptureRolled.Checked);

            chbCaptureRolled.Enabled = _canCaptureRolled && enable && _newSubject;

            gbFingerSelector.Enabled = enable && _newSubject;
            fSelector.Enabled = enable && _newSubject;
            changeScannerToolStripMenuItem.Enabled = enable;
            optionsToolStripMenuItem.Enabled = enable;
            saveImagesToolStripMenuItem.Enabled = enable;
            saveTemplateToolStripMenuItem.Enabled = enable;
            newToolStripMenuItem.Enabled = enable;
            exportToolStripMenuItem.Enabled = enable;

        }

        private static void ZoomView(NFingerView view)
        {
            float zoom = 1;
            NFrictionRidge finger = view.Finger;
            if (finger != null)
            {
                using (NImage image = finger.GetImage(false))
                {
                    if (image != null)
                    {
                        Size clientSize = view.Size;
                        int imageWidth = (int)image.Width;
                        int imageHeight = (int)image.Height;
                        zoom = Math.Min((float)clientSize.Width / imageWidth, (float)clientSize.Height / imageHeight);
                        zoom = Math.Max(0.01f, zoom);
                    }
                }
            }
            view.Zoom = zoom;
            view.Invalidate();
        }

        private void ZoomViews()
        {


            ZoomView(nfvLeftLittleRolled);
            ZoomView(nfvLeftRingRolled);
            ZoomView(nfvLeftMiddleRolled);
            ZoomView(nfvLeftIndexRolled);
            ZoomView(nfvLeftThumbRolled);
            ZoomView(nfvRightThumbRolled);
            ZoomView(nfvRightIndexRolled);
            ZoomView(nfvRightMiddleRolled);
            ZoomView(nfvRightRingRolled);
            ZoomView(nfvRightLittleRolled);
        }

        #endregion

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void saveFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }




        private void SalvaImagenTemplate(NFinger finger)
        {

            // salva el tempalte

            bool isRolled = NBiometricTypes.IsImpressionTypeRolled(finger.ImpressionType);
            saveFileDialog.FileName = string.Format("{0}{1}", finger.Position, isRolled ? "_Rolled" : string.Empty);
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                NFRecord record = finger.Objects.ToArray().First().Template;
                using (NBuffer buffer = record.Save())
                {
                    File.WriteAllBytes(saveFileDialog.FileName, buffer.ToArray());
                }
            }



            /////


        }


        private string CheckRenaper()
        {
            int cantidad = _model.Subject.Fingers.Count();
            string h1, h2, h1d, h2d;

            NFinger finger1 = _model.Subject.Fingers[cantidad - 1];
            NFinger finger2 = _model.Subject.Fingers[cantidad - 2];
            NImage image1 = finger1.GetImage(false);
            NImage image2 = finger2.GetImage(false);
            byte[] imagenArreglo1, imagenArreglo2;

            MemoryStream imgStream = new MemoryStream();
            MemoryStream imgStream2 = new MemoryStream();

            image1.Save(imgStream, NImageFormat.Jpeg);
            imgStream.Close();


            imagenArreglo1 = imgStream.ToArray();


            image2.Save(imgStream2, NImageFormat.Jpeg);
            imgStream2.Close();


            imagenArreglo2 = imgStream2.ToArray();


            h1 = Utilities.ConvertBytesToWSQBase64(imagenArreglo1, ImageFormat.Png);
            h2 = Utilities.ConvertBytesToWSQBase64(imagenArreglo2, ImageFormat.Png);
            h1d = DedosUtils.GetIdentificacionRenaper(finger1.Position).ToString();
            h2d = DedosUtils.GetIdentificacionRenaper(finger2.Position).ToString();


            int dni;
            dni = 17816143;
            string sexo = "F";



            RenaperClient rc = new RenaperClient(Utilities.RenaperGetUrl(), Utilities.RenaperGetSubject(), (StoreLocation)Enum.Parse(typeof(StoreLocation), Utilities.RenaperGetSoreLocation()),
                  (StoreName)Enum.Parse(typeof(StoreName), Utilities.RenaperGetstoreName()));


            string tcn = rc.GenerarTransaccion(dni, sexo, h1, h1d, h2, h2d);

            return tcn;
        }


        /*Genera el template de todos los Dedos */
        private int GenerarImagenesyTemplate(HuellasImputado huellas)
        {

            huellas.DedosFaltantes = new List<Dedos>();
            huellas.DedosCapturados = new List<Dedos>();
            huellas.TemplateSujeto = null;


            int i;


            int cantidad = _model.Subject.Fingers.Count();


            i = 0;




            foreach (var posicionF in _model.Subject.MissingFingers)
            {
                i = Utilities.ConvertNFingerToIndex(posicionF);
                Dedos dedoF = new Dedos();
                dedoF.Imagen = null;
                dedoF.Position = posicionF;
                huellas.DedosFaltantes.Add(dedoF);


            }



            foreach (NFinger dedo in _model.Subject.Fingers)
            {
                if (dedo.ProcessedImage != null)
                {

                    Dedos dedoCapturdo = new Dedos();

                    MemoryStream imgStream = new MemoryStream();
                    NImage imagen = dedo.GetImage(false);

                    imagen.Save(imgStream, NImageFormat.Jpeg);
                    imgStream.Close();
                    dedoCapturdo.Imagen = imgStream.ToArray();
                    imgStream.Dispose();
                    dedoCapturdo.Position = dedo.Position;

                    huellas.DedosCapturados.Add(dedoCapturdo);

                }
            }
            if (huellas.DedosCapturados.Count() + huellas.DedosFaltantes.Count() < 10)
            {
                // error no son 10 huellas
                return 1;
            }
            // template en arraglo de bytes al cliente
            huellas.TemplateSujeto = _model.Subject.GetTemplate().Save().ToArray();

            return 0;

        }

        private void amputada_CheckedChanged(object sender, EventArgs e)
        {

            fSelector.SetManoAmputada(this.amputada.Checked);
        }

        private void bdecadactilar_Click(object sender, EventArgs e)
        {
            ArmaDecaDactilar();
        }


        private void DecaFormClosed(object sender, FormClosedEventArgs e)
        {
            _decaForm.Dispose();
            _decaForm = null;

            if (_exit) Close();
        }

        private void nfvLeftThumbRolled_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }



        public void ArmaDecaDactilar()
        {


            int i = 0;


            int cantidad = _model.Subject.Fingers.Count();

            foreach (NFinger dedo in _model.Subject.Fingers)
            {
                //    _biometricClient.Dispose();

                if (dedo.ProcessedImage != null)
                {

                    MemoryStream imgStream = new MemoryStream();
                    NImage imagen = dedo.GetImage(false);
                    imagen.Save(imgStream, NImageFormat.Jpeg);
                    i = Utilities.ConvertNFingerToIndex(dedo.Position);
                    dedosCapturados[i] = imgStream;



                }

            }

              GraficaDecaDactilar(dedosCapturados);

            
        }


        private void  GraficaDecaDactilar(MemoryStream[] dedosCapturados)
        {
             int i=0;
            /*Path archivo Deca*/
            string exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
            string exeDir = Path.GetDirectoryName(exeFile);

            Image originalImage = Image.FromFile(Path.Combine(exeDir, "..\\..\\Resources\\FichaNueva500.jpg"));

            Bitmap tempBmp = new Bitmap(originalImage.Width, originalImage.Height);

            Graphics memoryGraphics = Graphics.FromImage(tempBmp);



            memoryGraphics.DrawImage(originalImage, 0, 0, originalImage.Width, originalImage.Height);
            /*scale los dedos */

            int anchoImagen = 504;
            int altoImagen = 604;
            float scale = Math.Min(670 / anchoImagen, 700 / altoImagen);


            var scaleWidth = (int)(anchoImagen * scale);
            var scaleHeight = (int)(altoImagen * scale);


            Image dedosI = null;

            for (i = 0; i < 10; i++)
            {

                if (dedosCapturados[i] == null)
                {
                    /*Importa imagen Sin Huella*/
                    Point p = new Point(0, 0);
                    switch (i)
                    {
                        case 0:
                            p.X = 722;
                            p.Y = 1187;
                            break;
                        case 1:
                            p.X = 1442;
                            p.Y = 1187;
                            break;
                        case 2:
                            p.X = 2127;
                            p.Y = 1187;
                            break;
                        case 3:
                            p.X = 2819;
                            p.Y = 1187;
                            break;
                        case 4:
                            p.X = 3507;
                            p.Y = 1187;
                            break;


                        case 5:
                            p.X = 752;
                            p.Y = 372;
                            break;
                        case 6:
                            p.X = 1442;
                            p.Y = 372;
                            break;
                        case 7:
                            p.X = 2127;
                            p.Y = 372;
                            break;
                        case 8:
                            p.X = 2819;
                            p.Y = 372;
                            break;
                        case 9:
                            p.X = 3507;
                            p.Y = 372;
                            break;


                    }
                    System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 48, FontStyle.Bold);

                    System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

                    System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                    memoryGraphics.DrawString("SIN HUELLA", drawFont, drawBrush, p.X, p.Y, drawFormat);
                    drawFont.Dispose();
                    drawBrush.Dispose();
                    drawFormat.Dispose();
                    continue;
                }


                dedosI = Image.FromStream(dedosCapturados[i]);
                Image newImage = dedosI;

                memoryGraphics.SmoothingMode = SmoothingMode.HighQuality;
                memoryGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                memoryGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                Rectangle destRect = new Rectangle(554, 882, newImage.Width, newImage.Height); ;





                switch (i)
                {
                    case 0:
                        destRect = new Rectangle(554, 882, 600, 700);
                        break;
                    case 1:
                        destRect = new Rectangle(1268, 882, scaleWidth, scaleHeight);
                        break;
                    case 2:
                        destRect = new Rectangle(1959, 882, scaleWidth, scaleHeight);
                        break;
                    case 3:
                        destRect = new Rectangle(2650, 882, scaleWidth, scaleHeight);
                        break;

                    case 4:
                        destRect = new Rectangle(3351, 882, scaleWidth, scaleHeight);
                        break;
                    case 5:
                        destRect = new Rectangle(554, 37, 600, 700);
                        break;
                    case 6:
                        destRect = new Rectangle(1268, 37, 600, 700);
                        break;
                    case 7:
                        destRect = new Rectangle(1959, 37, 600, 700);
                        break;
                    case 8:
                        destRect = new Rectangle(2650, 37, 600, 700);
                        break;
                    case 9:
                        destRect = new Rectangle(3351, 37, 600, 700);
                        break;

                }

                memoryGraphics.DrawImage(newImage, destRect);
            }
            /*Al final agrego Cod Barras y Apellido y nombres*/
            String datosPers = this.lCodigoBarras.Text;

            System.Drawing.Font drawFontT = new System.Drawing.Font("Arial", 36, FontStyle.Bold);

            System.Drawing.SolidBrush drawBrushT = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            float x = 28.0F;
            float y = 22.0F;
            System.Drawing.StringFormat drawFormatT = new System.Drawing.StringFormat();


            memoryGraphics.DrawString(datosPers, drawFontT, drawBrushT, x, y, drawFormatT);

            x = 28;
            y = 100;
            drawFontT = new System.Drawing.Font("Arial", 36, FontStyle.Italic ^ FontStyle.Underline);
            datosPers = this.lApeyNom.Text;
            memoryGraphics.DrawString(datosPers, drawFontT, drawBrushT, x, y, drawFormatT);

            drawFontT.Dispose();
            drawBrushT.Dispose();
            drawFormatT.Dispose();
            //   graph.DrawImage(image, new Rectangle(((int)width - scaleWidth) / 2, ((int)height - scaleHeight) / 2, scaleWidth, scaleHeight));



            tempBmp.SetResolution(500, 500);
            tempBmp.Save(Path.Combine(exeDir, "..\\..\\output\\" + this.lCodigoBarras.Text + ".jpg"), ImageFormat.Jpeg);
            /*Dispose memoria*/
            memoryGraphics.Dispose();
            originalImage.Dispose();
            for (var t = 0; t < 10; t++)
            {

                if (dedosCapturados[t] != null)
                {
                    dedosCapturados[t].Close();
                    dedosCapturados[t].Dispose();
                }



            }


            if (!Utilities.ShowQuestion(this, "La DecaDactilar fue salvada exitosamente. Desea visualizar la Imagen ?"))
            {

                return;
            }
            // Utilities.ShowInformation("Fue salvada con éxito la Decadactilar del Imputado con Codigo de Barras:"+this.lCodigoBarras.Text + ".jpg");
            // ir a DecaDactilar Form y mostrar la imagen del disco
            // Visualiza DecaDactilar    
            _decaForm = new DecaDactilarForm();
            //  _decaForm.InicilizaDedos(dedosCapturados, this.lApeyNom.Text, this.lCodigoBarras.Text);



            _decaForm.FormClosed += new FormClosedEventHandler(DecaFormClosed);
            _decaForm.inicializaImagen(tempBmp);
            _decaForm.Show(this);
         
        
        
        
        }
        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            //MessageBox.Show(this, "Va a Subir Deca Dactilar");
            SubirHuellasAsync();

        }

        private  void SubirHuellasAsync()
        {


            /* Suponemos que el Imputado lo puede actualizara la aplicacion desktop?? */
           
            FingerCapturer.ServiceCapturaDecaDactilar.ImputadoDatosPers imp = new FingerCapturer.ServiceCapturaDecaDactilar.ImputadoDatosPers();
            FingerCapturer.ServiceCapturaDecaDactilar.HuellasImputado huellasImp = new FingerCapturer.ServiceCapturaDecaDactilar.HuellasImputado();
             


            imp.Apellido = this.apellido.Text;
          //  imp.DNI = DNI.Text !=null || DNI.Text !="" ? Convert.ToInt32(this.DNI.Text): 0;
            imp.DNI = 0;
            imp.Nombres = this.nombres.Text;
            imp.IPP = _IPP;
            imp.Sexo = this.rFemenino.Checked ? "F" : "M";
            imp.CodigoBarras = _codBarra;
            imp.ScoreRenaper = "0";
            HuellasImputado huellas = new HuellasImputado();
         
            int resp = GenerarImagenesyTemplate(huellas);

           
            if (resp != 0)
            {
                
                Utilities.ShowQuestion(this, "La DecaDactilar no fue definida correctamente. Por favor, defina todas las huellas y las extremidades faltantes y/o lastimadas (10) ");
                return;
            }

            FingerCapturer.ServiceCapturaDecaDactilar.CapturaDecaDactilarServiceClient capturaService = new FingerCapturer.ServiceCapturaDecaDactilar.CapturaDecaDactilarServiceClient();
            huellasImp.DedosCapturados = new FingerCapturer.ServiceCapturaDecaDactilar.Dedos[huellas.DedosCapturados.Count()];
            huellasImp.DedosFaltantes = new FingerCapturer.ServiceCapturaDecaDactilar.Dedos[huellas.DedosFaltantes.Count()];

            int i = 0;
            foreach (var k in huellas.DedosCapturados)
            {
          
                byte[] imagenAux  = k.Imagen.ToArray();
                huellasImp.DedosCapturados[i] = new FingerCapturer.ServiceCapturaDecaDactilar.Dedos();
                huellasImp.DedosCapturados[i].Imagen = imagenAux;
                huellasImp.DedosCapturados[i].Position = k.Position;


                i++;
                
            }


            i = 0;
            foreach (var k in huellas.DedosFaltantes)
            {
               //byte[] imagenAux = k.Imagen.ToArray();
              huellasImp.DedosFaltantes[i] = new FingerCapturer.ServiceCapturaDecaDactilar.Dedos();
               huellasImp.DedosFaltantes[i].Imagen = null;
               huellasImp.DedosFaltantes[i].Position = k.Position;

               i++;

            }


                huellasImp.TemplateSujeto = huellas.TemplateSujeto;




           try
           {
                startProgress();
                capturaService.CapturaHuellasClienteCompleted += new EventHandler<CapturaHuellasClienteCompletedEventArgs>(CallbackCaptura);
                capturaService.CapturaHuellasClienteAsync(imp, huellasImp);
               
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception", e.GetBaseException());
                
            }
           
               
               int cantidadDedos = _model.Subject.Fingers.Where(p=> p.ProcessedImage != null).Count();

               _model.Subject.Fingers.RemoveRange(0, _model.Subject.Fingers.Count() - cantidadDedos);

               _model.Subject.Id = _codBarra;
               try
               {
                   /*FUNCIONA:  NBiometricTask task = BiometricClient.CreateTask(NBiometricOperations.Identify, _model.Subject);*/
                   /*    NBiometricTask task = BiometricClient.CreateTask(NBiometricOperations.Delete, _model.Subject);  */
                   /* y dsps testear en el retorno de la tarea en el callbak OnTaskCompleted task.status  y task.Subjects*/

                   /*NO FUNCIONAN: Tarea Update,Get,NBiometricTask task = BiometricClient.CreateTask(NBiometricOperations.EnrollWithDuplicateCheck, _model.Subject); y Verify da Invalid Operations no funciona*/
                   /* Verification - 1:1 matching. Identification - 1:many matching.**/

                   NBiometricTask task = BiometricClient.CreateTask(NBiometricOperations.Enroll, _model.Subject);
                 
                   BiometricClient.BeginPerformTask(task, OnTaskCompleted, null);
               }
            catch(Exception e){

                string a = "FeatureSupport";
             
            }
           



        }

        private void startProgress()
        {
            picEspera.Visible = true;
            tabControl.SelectTab("tabResultado");
          
        
        
        }


       void CallbackCaptura(object sender, CapturaHuellasClienteCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Utilities.ShowInformation("La operacion fue cancelada y las huellas no fueron salvadas intente nuevamente...");
                return;
            }
            Console.WriteLine("Registro de las Huellas Digitalizadas", "Termino la captura, Empieza la extraccion del template Con resultado " + e.Result);
            estadoUpdateHuellas = true;
            lb_estadoRegistro.Text = string.Format("{0}: {1}", "Finalizó la inserción de las imagenes dactilares!", e.Result);
            lb_estadoRegistro.BackColor = Color.Azure;

           if (estadoRegistroBiometrico)
           {
               picEspera.Visible = false;
           }
         //   lb_estadoRegistro.BackColor = status == NBiometricStatus.Ok ? Color.Azure : Color.Red;
           // El manejo del control de progress bar lo maneja la SIAC base de datos que tarda mas
             // HideProgressbar();
                       
        }
   
   

/*Vuelta del MEgaMatcher, respuesta asyncrionica */

      private void OnTaskCompleted(IAsyncResult result)
      {
          if (InvokeRequired)
          {
              BeginInvoke(new AsyncCallback(OnTaskCompleted), result);
          }
          else
          {
              try
              {
                  estadoRegistroBiometrico = true;
                  if (estadoRegistroBiometrico)
                  {
                      picEspera.Visible = false;
                  }
              

                  NBiometricTask task = _biometricClient.EndPerformTask(result);
                  NBiometricStatus status = task.Status;
                  lbStatus.Text = string.Format("{0}: {1}", " Finalizó el registro Biométrico, resultado del proceso :", status);
                  lbStatus.BackColor = status == NBiometricStatus.Ok ? Color.Azure : Color.Red;

                  if (task.Error != null)
                  {
                     Utilities.ShowError(task.Error);
                  }
                  task.Dispose();
                
              }
              catch (Exception ex)
              {
                  lbStatus.Text = string.Format("{0}: {1}", NBiometricOperations.Enroll, "Error");
                  lbStatus.BackColor = Color.Red;
                  Utilities.ShowError(ex);
              }
          }

      }

      private void toolStripViewControls_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
      {

      }

      private void tabResultado_Click(object sender, EventArgs e)
      {

      }

      private void picEspera_Click(object sender, EventArgs e)
      {

      }

      private void tabPage1_Click(object sender, EventArgs e)
      {

      }

      private void btn_abrir_Click(object sender, EventArgs e)
      {
          // Show the dialog and get result.
          DialogResult result = openFileDialog1.ShowDialog();
          if (result == DialogResult.OK) // Test result.
          {
              NSubject sujetoImp = new NSubject();
              
             string file = openFileDialog1.FileName;
              try
              {
                  
                  lNombreArchivo.Text =file;
                  MemoryStream[] dedosCapturados = new MemoryStream[10];
                  var j = 0;
                  using (var template = new ANTemplate(file, ANValidationLevel.Standard, ANTemplate.FlagLeaveInvalidRecordsUnvalidated))
                  {
                      for (int i = 0; i < template.Records.Count; i++)
                      {
                          ANRecord record = template.Records[i];
                          NImage image = null;
                          int number = record.RecordType.Number;
                          if (number >= 3 && number <= 8 && number != 7)
                          {
                              image = ((ANImageBinaryRecord)record).ToNImage();
                          }
                          else if (number >= 10 && number <= 17)
                          {
                              image = ((ANImageAsciiBinaryRecord)record).ToNImage();
                          }

                          if (image != null)
                          {
                              Neurotec.Biometrics.Standards.ANType4Record regi = (Neurotec.Biometrics.Standards.ANType4Record)record;
                              string posicionDedo= regi.Positions.First().ToString();

                              MemoryStream imgStream = new MemoryStream();
                              image.Save(imgStream, NImageFormat.Jpeg);
                              /*posicionDedo pasarlo a la posicion*/
                              j = Utilities.ConvertNFingerToIndex(posicionDedo);
                              dedosCapturados[j] = imgStream;
                                NFinger dedoimp = new NFinger();
                               NFPosition posicionNeu = Utilities.ConvertStringToNeuro(posicionDedo);
                               dedoimp.Position = posicionNeu;
                              
                              string fileName = string.Format(posicionDedo+"{0}Number{1}.jpg", j,number);
                              image.Save(fileName);
                              dedoimp.FileName=fileName;
                              dedoimp.ImpressionType = NFImpressionType.NonliveScanRolled;
                              dedoimp.Image = image;
                              sujetoImp.Fingers.Add(dedoimp);

                              image.Dispose();
                              Console.WriteLine("La imagen se salvo a {0}", fileName);
                          }
                      }



                      // Converting ANTemplate object to NTemplate object
                      NTemplate nTemplate = template.ToNTemplate();

                      // Packing NTemplate object
                      byte[] packedNTemplate = template.Save().ToArray();
                      

                   //   sujetoImp.SetTemplate(nTemplate); Esto ANDUVOOOOOO el enroll en el MegaMatcher


                      sujetoImp.Id = "CODIGOBARRAS14";
                      // Storing NTemplate object in file
                      File.WriteAllBytes("pruebaTemplate", packedNTemplate);

                  }
                  GraficaDecaDactilar(dedosCapturados);


                  try
                  {
                      /*FUNCIONA:  NBiometricTask task = BiometricClient.CreateTask(NBiometricOperations.Identify, _model.Subject);*/
                      /*    NBiometricTask task = BiometricClient.CreateTask(NBiometricOperations.Delete, _model.Subject);  */
                      /* y dsps testear en el retorno de la tarea en el callbak OnTaskCompleted task.status  y task.Subjects*/

                      /*NO FUNCIONAN: Tarea Update,Get,NBiometricTask task = BiometricClient.CreateTask(NBiometricOperations.EnrollWithDuplicateCheck, _model.Subject); y Verify da Invalid Operations no funciona*/
                      /* Verification - 1:1 matching. Identification - 1:many matching.**/

                     /* el Enroll anduvo pero el tema es que el template es distinto es mas chico
                      * NBiometricTask task = BiometricClient.CreateTask(NBiometricOperations.Enroll,sujetoImp);
                      
                      BiometricClient.BeginPerformTask(task, OnTaskCompleted, null);*/

                      
                      foreach(var item in sujetoImp.Fingers )
                      {
                      	NBiometricTask task = _biometricClient.CreateTask(NBiometricOperations.CreateTemplate,sujetoImp);
                        task.Biometric = item;
                 
        				_biometricClient.BeginPerformTask(task, OnCreateTemplateCompleted, null);
                      }
                      int cantidad =1;
                      while (cantidad >0)
                      {
                          var lista = sujetoImp.Fingers.Where(x => x.ProcessedImage == null && x.Image != null).ToList();
                           cantidad = lista.Count;
                      }

                     

                      NBiometricTask task1 = BiometricClient.CreateTask(NBiometricOperations.Enroll, sujetoImp);

                      BiometricClient.BeginPerformTask(task1, OnTaskCompleted, null);

			         }
                  catch (Exception eh)
                  {

                      string a = "FeatureSupport";

                  }
             
              }
              catch (IOException)
              {
              }
          }
          Console.WriteLine(result); // <-- For debugging use.
      }



      private void OnCreateTemplateCompleted(IAsyncResult r)
      {
          if (InvokeRequired)
          {
              BeginInvoke(new AsyncCallback(OnCreateTemplateCompleted), r);
          }
          else
          {
              NBiometricStatus status = NBiometricStatus.None;
              try
              {
                  _biometricClient.EndPerformTask(r);


              }
              catch (Exception ex)
              {
                  Utilities.ShowError(ex);

                  /*Vuelve a Intentarlo ?*/


              }
              finally
              {
              }

             
          }
      }

      private void bRenaper_Click(object sender, EventArgs e)
      {
          string token= CheckRenaper();
      }



    }

}



