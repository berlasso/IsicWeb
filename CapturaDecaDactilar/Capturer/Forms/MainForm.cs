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



namespace Capturer.Forms
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

	     /* Parametro cantidad de huellas que toma */
        private int cantHuellas;
        private MemoryStream[] dedosCapturados = new MemoryStream[10];

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

		private bool _canCaptureSlaps;
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
            this.apellido.Text = lApeyNom.Text;
            this.tCodigoBarra.Text = this.lCodigoBarras.Text;
           
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
		}

		private void CaptureFormFormClosed(object sender, FormClosedEventArgs e)
		{
		
        
			_captureStarted = false;
			EnableControls(true);

			if (_exit) Close();
		}
        private void CaptureFormSingleClosed(object sender, FormClosedEventArgs e)
        {
         //   imputadosHuellas =(NSubject) _captureSingle.Subject.Clone();
            /*foreach (var item in imputadosHuellas.Fingers.Where(x => x.ProcessedImage != null))
            {
                imputadosHuellas.Fingers.Add(item);
            
            }
            foreach (var item in _captureSingle.Subject.MissingFingers)
            {
                imputadosHuellas.MissingFingers.Add(item);

            }*/

            /*Al Web Service enviar imputadosHuellas un NSubjects con GetTemplate = NLTemplate : Fingers => NFRecords una coleccion con atributos de los templates extraidos*/
     //       imputadosHuellas.SetTemplate(_captureSingle.Subject.GetTemplate());
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
            CheckBox other = target ;
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

			_model = new DataModel();
			_model.Info.AddRange(LoadInfoFields());
			infoPanel.Model = _model;
			_newSubject = true;
			EnableControls(true);
            this.apellido.Text ="";
            this.tCodigoBarra.Text = "";
            this.DNI.Text = "";
            this.nombres.Text = "";
		}

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
							string name = string.Format("{0}{1}.png", item.Position, isRolled? "_rolled" : string.Empty);
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
		private NFingerView GetView(NFPosition position, bool isRolled)
		{
			switch (position)
			{
				case NFPosition.LeftIndex: return nfvLeftIndexRolled;
				case NFPosition.LeftLittle: return  nfvLeftLittleRolled;
				case NFPosition.LeftMiddle: return nfvLeftMiddleRolled ;
				case NFPosition.LeftRing: return  nfvLeftRingRolled ;
				case NFPosition.LeftThumb: return nfvLeftThumbRolled;
				case NFPosition.RightIndex: return  nfvRightIndexRolled ;
				case NFPosition.RightLittle: return nfvRightLittleRolled ;
				case NFPosition.RightMiddle: return  nfvRightMiddleRolled ;
				case NFPosition.RightRing: return  nfvRightRingRolled ;
				case NFPosition.RightThumb: return nfvRightThumbRolled ;
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
				if (Utilities.ShowQuestion("Cambiando el scanner borrar�n los datos caputrados.. Contin�a ?"))
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

     
        private void CheckRenaper()
        {
            int cantidad = _model.Subject.Fingers.Count();
            string h1, h2, h1d, h2d;

            NFinger finger1 = _model.Subject.Fingers[cantidad - 1];
            NFinger finger2 = _model.Subject.Fingers[cantidad - 2];
            NImage image1 = finger1.GetImage(false);
            NImage image2 = finger2.GetImage(false);
            byte[] imagenArreglo1,imagenArreglo2;
           
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

        
        }
        


        private void bSalvar_Click(object sender, EventArgs e)
        {
            int i;
          
           
            int cantidad = _model.Subject.Fingers.Count();
         
          
            i=0;

            


            foreach (var posicionF in _model.Subject.MissingFingers)
            {
                i = Utilities.ConvertNFingerToIndex(posicionF);

              //  dedosCapturados[i] = imgStream;

            }
            

            
            foreach (NFinger dedo in _model.Subject.Fingers)
            {
           //    _biometricClient.Dispose();

                if (dedo.ProcessedImage != null)
                {
                    byte[] imagenDig;
                    MemoryStream imgStream = new MemoryStream();
                    NFinger dedoN = new NFinger();
                    dedoN.ProcessedImage = dedo.ProcessedImage;
                    dedoN.Position = dedo.Position;

                    imputadosHuellas.Fingers.Add(dedoN);
                   // imputadosHuellas.Fingers.Add(dedo);

                    NImage imagen = dedo.GetImage(false);

                    // imagen.Save(imgStream, NImageFormat.Jpeg);

                    imagen.Save(imgStream, NImageFormat.Jpeg);

                    imgStream.Close();
                    i = Utilities.ConvertNFingerToIndex(dedo.Position);


                    imagenDig = imgStream.ToArray();
                    imgStream.Dispose();
                    dedosCapturados[i] = new MemoryStream(imagenDig);
                    if (this.apellido.Text == null || (this.apellido.Text == ""))
                    {
                        this.apellido.Text = "Anonimo";
                    }
                    //    string NombreArchivo = string.Format("{0}{1}{2}{3}", "DedoNro:"+ i.ToString(), this.apellido.Text + "_", this.nombres.Text + "_", "_Rodada.jpeg");                 
                    string NombreArchivo = "\\DedoNro" + i.ToString() + "_Rodada.jpeg";
                    if (this.nombres.Text == null)
                    {
                        this.nombres.Text = "Anonimo";
                    }

                    File.WriteAllBytes(Application.StartupPath + NombreArchivo, imagenDig);
                    // imagenDig guardarlo en la BD enviarlo al WebService 


                }
                else
                {
                  
                } 
    
                    }

              NTemplate templateSujeto = _model.Subject.GetTemplate();
              imputadosHuellas.SetTemplate(templateSujeto);
            // PASAR AL WEB SERVICE imputadosHuellas
            
            string a = "";
            return;
     
        }

        private void amputada_CheckedChanged(object sender, EventArgs e)
        {
           
             fSelector.SetManoAmputada(this.amputada.Checked); 
        }

        private void bdecadactilar_Click(object sender, EventArgs e)
        {

          int i=0;


            int cantidad = _model.Subject.Fingers.Count();

            NFinger[] dedosF = new NFinger[10];

            foreach (NFinger dedo in _model.Subject.Fingers)
            {
                //    _biometricClient.Dispose();

                if (dedo.ProcessedImage != null)
                {
                    byte[] imagenDig;
                    MemoryStream imgStream = new MemoryStream();
                    NFinger dedoN = new NFinger();
                    dedoN.ProcessedImage = dedo.ProcessedImage;
                    dedoN.Position = dedo.Position;
                    dedosF[i] = dedo;
                    imputadosHuellas.Fingers.Add(dedoN);
                    // imputadosHuellas.Fingers.Add(dedo);

                    NImage imagen = dedo.GetImage(false);
                  
                    // imagen.Save(imgStream, NImageFormat.Jpeg);

                    imagen.Save(imgStream, NImageFormat.Jpeg);

                    imgStream.Close();
                    i = Utilities.ConvertNFingerToIndex(dedo.Position);
                    
                    imagenDig = imgStream.ToArray();
                    imgStream.Dispose();
                    dedosCapturados[i] = new MemoryStream(imagenDig);
                  
                }
               
            }

            NTemplate templateSujeto = _model.Subject.GetTemplate();
            imputadosHuellas.SetTemplate(templateSujeto);
            // PASAR AL WEB SERVICE imputadosHuellas

           
           
        // Visualiza DecaDactilar    
            _decaForm = new DecaDactilarForm();
            _decaForm.InicilizaDedos(dedosCapturados, this.lApeyNom.Text, this.lCodigoBarras.Text);

            

            _decaForm.FormClosed += new FormClosedEventHandler(DecaFormClosed);

            _decaForm.Show(this);
            
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
	}
}
