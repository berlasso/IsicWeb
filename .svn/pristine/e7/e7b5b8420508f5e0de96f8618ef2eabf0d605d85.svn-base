using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Neurotec.Biometrics;
using Neurotec.Biometrics.Client;
using Neurotec.Biometrics.Gui;
using Neurotec.Images;
using Capturer;
using Capturer.Code;

namespace Capturer.Forms
{
	public partial class FingerCaptureForm : Form
	{
		#region Public constructor
       

		public FingerCaptureForm()
		{
			InitializeComponent();
			var tool = new NFingerView.SegmentManipulationTool();
			tool.SegmentManipulationEnded += new EventHandler(OnSegmentManipulationEnded);
			fingerView.ActiveTool = tool;
          
		}

		#endregion

		#region Private fields

		private NBiometricClient _biometricClient;
		private NSubject _subject;
		private List<NFinger> _captureList;
		private NFinger _current;
       

		private volatile bool _isProcessing;
		private volatile bool _isCapturing;

		private bool IsBusy()
		{
			return _isProcessing || _isCapturing;
		}

		private void CancelAndWait()
		{
			if (IsBusy())
			{
				if (_isCapturing) _biometricClient.Cancel();
				while (IsBusy())
				{
					Application.DoEvents();
				}
			}
		}

		#endregion

		#region Public properties

		public NBiometricClient BiometricClient
		{
			get { return _biometricClient; }
			set { _biometricClient = value; }
		}

		public NSubject Subject
		{
			get { return _subject; }
			set { _subject = value; }
		}


        public NFinger Current 
        {
            get { return _current; }
            set { _current = value; }
        }
		#endregion

		#region Private form events

		private void CaptureFormLoad(object sender, EventArgs e)
		{
            string[,] slapPos = new string[7, 2] { { "PlainThumbs", "Ambos Pulgares" }, { "LeftIndexMiddleFingers", "Izq. Indice + Medio"},
                    {"LeftMiddleRingFingers","Izq. Medio + Anular"},{"LeftRingLittleFingers","Izq. Anular + Meñique"},
                    { "RightIndexMiddleFingers", "Der. Indice + Medio"} , { "RightMiddleRingFingers","Der. Medio + Anular"},{"RightRingLittleFingers","Der. Anular + Meñique"} };


                    
           
			if (_biometricClient != null && _subject != null)
			{
                // cuando es slaps empieza por los PkainThumbs
                //ListView.SelectedIndexCollection selected = lvQueue.SelectedIndices;
                // selecciono el Plain Thumbs y deselecciono el resto
              

				fSelector.MissingPositions = _subject.MissingFingers.ToArray();
				SetStatus(string.Empty);
                fSelector.SelectedPosition = NFPosition.PlainThumbs;
             

              



                 _captureList = _subject.Fingers.Where(x => x.ParentObject == null).OrderBy(x => x.Position.ToString()).ToList();
                 _current = _captureList.Where(x => x.Position == NFPosition.PlainThumbs).FirstOrDefault();
                
                 ListViewItem pulgar = null;
				foreach (var item in _captureList)
				{
					bool isRolled = NBiometricTypes.IsImpressionTypeRolled(item.ImpressionType);
                   int fila = ArrayHelper.FindInDimensions(slapPos, item.Position.ToString());
                
					//string text = string.Format("{0}{1}", PositionToString(item.Position), isRolled ? "(rolled)" : string.Empty);
                  

                    string text = string.Format("{0}{1}", slapPos[fila,1], isRolled ? "(rolada)" : string.Empty);
					ListViewItem lvi = lvQueue.Items.Add(text);
                    if (text == "Ambos Pulgares")
                    {
                        pulgar = lvi;
                    }
                    
					if (IsCreateTemplateDone(item)) lvi.ForeColor = Color.Green;
				}
              

                int pos = lvQueue.Items.IndexOf(pulgar);
                lvQueue.Items[pos].ForeColor = Color.Azure;
                lvQueue.Items[pos].Selected = true;
                StartTask(_current);
               

              //_current.Image = null;
            //    int index = _captureList.IndexOf(_current);
             //   lvQueue.Items[index].ForeColor = Color.Black;

               
                /*for (var j = 0; j <= lvQueue.Items.Count; j++)
                {
                    if (lvQueue.Items[j].Text == "Ambos Pulgares")
                    {  
                        lvQueue.Items[j].Selected = true; }
                    else
                    {
                       lvQueue.Items[j].Selected = false;
                    }
                }

                /*
             
				if (!NextTask())
				{
					SetError("Falló para comenzar la captura");
				}
                */
               
			}
		}

		private void CaptureFormFormClosing(object sender, FormClosingEventArgs e)
		{
			CancelAndWait();
			if (_current != null && !IsCreateTemplateDone(_current))
				_current.Image = null;
		}

		/*private void BtnPreviousClick(object sender, EventArgs e)
		{
			int index = _captureList.IndexOf(_current) - 1;
			if (index >= 0)
			{
				StartTask(_captureList[index]);
			}
		}*/

	/*	private void BtnNextClick(object sender, EventArgs e)
		{
			NextTask();
		}
        */
		private void BtnRescanClick(object sender, EventArgs e)
		{
			_current.Image = null;
			int index = _captureList.IndexOf(_current);
			lvQueue.Items[index].ForeColor = Color.Black;

			StartTask(_current);
		}

		private void BtnAcceptClick(object sender, EventArgs e)
		{
			if (_current != null)
			{
				NBiometricTask task = _biometricClient.CreateTask(NBiometricOperations.CreateTemplate, _subject);
				task.Biometric = _current;
				_isProcessing = true;
				_biometricClient.BeginPerformTask(task, OnCreateTemplateCompleted, null);
				SetStatus("Extracción del registro(s). Por favor espere...");
			}
			EnableControls();
		}

		private void FingerViewResize(object sender, EventArgs e)
		{
			OnFingerViewResize();
		}

		private void LvQueueSelectedIndexChanged(object sender, EventArgs e)
		{
			ListView.SelectedIndexCollection selected = lvQueue.SelectedIndices;
			if (selected.Count > 0)
			{
				int current = _captureList.IndexOf(_current);
				int index = selected[0];
				if (index != current)
				{
                               

					StartTask(_captureList[index]);
				}
			}
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

					status = _current.Status;
					if (status == NBiometricStatus.Ok)
					{
						int index = _captureList.IndexOf(_current);
                        
						lvQueue.Items[index].ForeColor = Color.Green;
						SetStatus(Color.Green, Color.White, "El template fue creado exitosamente");
                        /* Vuelve a  la pantalla principal con las imagenes y templates capturados !!!! Martha */
                        _isProcessing = false;
                      // LOS ULTIMOS DOS ELEMENTOS DE SUBJECT SON LOS SLAPS
                        fingerView.Finger = null;
                        Close();
                        return;
                        /*hasta aca*/
                       
					}
					else
					{
						SetError("Falló la creación del template, estado = {0}", EnumToString(status));
					}
				}
				catch (Exception ex)
				{
					Utilities.ShowError(ex);
					SetError("La creación del template falló  {0}", ex.Message);
				}
				finally
				{
					_isProcessing = false;
					EnableControls();
				}

				if (status == NBiometricStatus.Ok)
				{
					NextTask();
				}
			}
		}

		private void OnSegmentManipulationEnded(object sender, EventArgs e)
        {

        }

		private void OnAssessQualityCompleted(IAsyncResult result)
		{
			if (InvokeRequired)
			{
				BeginInvoke(new AsyncCallback(OnAssessQualityCompleted), result);
			}
			else
			{
				try
				{
					_biometricClient.EndPerformTask(result);
					SetStatus(Color.Green, Color.White, "Captura exitosa {0}. Ajuste el area rectangular(s) de ser necesario y presione el botón Aceptar", PositionToString(_current.Position));
				}
				catch (Exception ex)
				{
					SetError("Falló el control de la calidad {0}", ex.Message);
					Utilities.ShowError(ex);
				}
				finally
				{
					_isProcessing = false;
					EnableControls();
				}
			}
		}

		private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
		{
            NBiometricStatusEsp traducirEstado;
			if (args.PropertyName == "Status")
			{
				BeginInvoke(new Action<NBiometricStatus>(status =>
				{
					Color statusColor = status == NBiometricStatus.Ok || status == NBiometricStatus.None ? Color.Green : Color.Red;
                    int valor = (int) status;
                    traducirEstado = (NBiometricStatusEsp) valor;
                    lblStatus.Text = string.Format("Score: {0}", EnumToString(traducirEstado));
					//lblStatus.Text = string.Format("Score: {0}", EnumToString(status));
					lblStatus.ForeColor = statusColor;
				}), _current.Status);
			}
			else if (args.PropertyName == "Image")
			{
				using (NImage image = _current.GetImage(false))
				{
					if (image != null) BeginInvoke(new Action<int, int>(UpdateViewSize), (int)image.Width, (int)image.Height);
				}
			}
		}

		private void OnCaptureCompleted(IAsyncResult result)
		{
			if (InvokeRequired)
			{
				BeginInvoke(new AsyncCallback(OnCaptureCompleted), result);
			}
			else
			{
				try
				{
					_biometricClient.EndPerformTask(result);

					NBiometricStatus status = _current.Status;
					if (status == NBiometricStatus.Ok)
					{
                        SetStatus(Color.Green, Color.White, "Captura exitosa {0}. Ajuste el area rectangular(s) de ser necesario y presione el botón Aceptar", PositionToString(_current.Position));
                        // la captura es completa y exitosa marca en verde las posiciones delas manos correspondientes  agregado
                        fSelector.SelectedPosition = _current.Position;
                        btnRescan.Enabled = true;
                        btnAccept.Enabled = true;
					}
					else
					{
						SetError("Operación fallida = {0}", EnumToString(status));
					}
				}
				catch (Exception ex)
				{
					SetError(ex.Message);
					Utilities.ShowError(ex);
				}
				finally
				{
					_isCapturing = false;
					EnableControls();
					_current.PropertyChanged -= OnPropertyChanged;
				}
			}
		}

		#endregion

		#region Private methods

		private void SetStatus(Color backColor, Color foreColor, string format, params object[] args)
		{
			lblInfo.BackColor = backColor;
			lblInfo.ForeColor = foreColor;
			lblInfo.Text = string.Format(format, args);
		}

		private void SetStatus(string format, params object[] args)
		{
			SetStatus(SystemColors.Control, Color.Black, format, args);
		}

		private void SetError(string format, params object[] args)
		{
			SetStatus(Color.Red, Color.White, format, args);
		}

		private void FinishTask()
		{
			CancelAndWait();
			if (_current != null)
			{
				if (IsCaptureDone(_current) && !IsCreateTemplateDone(_current))
				{
					_current.Image = null; // Reset partial progress
				}
			}
		}

		private bool NextTask()
		{
			
             if (_captureList != null && _captureList.Count > 0)
			{
				int index = 0;
				if (_current != null)
				{
					index = _captureList.IndexOf(_current) + 1;
				}

				if (index != _captureList.Count)
				{
					StartTask(_captureList[index]);
					return true;
				}
			}

			return false;
		}

		private void StartTask(NFinger task)
		{
		
         if (_current != null)
			{
				if (IsCaptureDone(_current) && !IsCreateTemplateDone(_current))
				{
					if (!Utilities.ShowQuestion(this, "Registros no extraídos para esta imagen! Presione 'Yes' para continuar de todos modos, presione 'No' para permitir su resguardo"))
					{
						toolTip.Show("Acepta la extracción de la imagen", btnAccept);
						return;
					}
				}
			}


			DisableNavigation();
			FinishTask();

			fingerView.Finger = null;
			_current = task;
			fSelector.SelectedPosition = task.Position;

			bool isRolled = NBiometricTypes.IsImpressionTypeRolled(_current.ImpressionType);
			fSelector.IsRolled = isRolled;
			

			int index = _captureList.IndexOf(_current);
			lvQueue.Items[index].Selected = true;
            lvQueue.Items[index].ForeColor = Color.Black;
			fingerView.Finger = _current;
            SetStatus("Por favor coloque {0} dedo(s) sobre el scanner ", PositionToString(task.Position));
			if (!IsCreateTemplateDone(_current))
			{
				var biometricTask = _biometricClient.CreateTask(NBiometricOperations.Capture | NBiometricOperations.Segment | NBiometricOperations.AssessQuality, _subject);
				biometricTask.Biometric = _current;
				_current.PropertyChanged += OnPropertyChanged;
				_isCapturing = true;
				_biometricClient.BeginPerformTask(biometricTask, OnCaptureCompleted, null);
			}
			else
			{
				SetStatus(Color.Green, Color.White, "Registro(s) extraídos exitosamente");
				OnFingerViewResize();
			}
			EnableControls();
		}

		private bool IsCaptureDone(NFinger finger)
		{
			return !_isCapturing && finger.Image != null;
		}

		private bool IsCreateTemplateDone(NFinger finger)
		{
			if (finger == null || !IsCaptureDone(finger) || finger.Status != NBiometricStatus.Ok) return false;
			else
			{
				NFAttributes[] attributes = finger.Objects.ToArray();
				if (!attributes.All(x => x.Status == NBiometricStatus.Ok || x.Status == NBiometricStatus.ObjectMissing)) return false;

				NFinger[] children = attributes.Select(x => (NFinger)x.Child).Where(x => x != null).ToArray();
				if (children.Length == 0)
					return attributes.All(x => x.Template != null);
				else
					return children.All(x => IsCreateTemplateDone(x));
			}
		}

		private void EnableControls()
		{
			if (_captureList != null && _captureList.Count > 0)
			{
				var tool = fingerView.ActiveTool as NFingerView.SegmentManipulationTool;
				if (tool != null)
				{
					tool.AllowManipulations = !_isProcessing && !_isCapturing && _current != null && _current.Status == NBiometricStatus.Ok;
					fingerView.Invalidate();
				}
			
				btnAccept.Enabled = !_isCapturing && !_isProcessing && IsCaptureDone(_current) && !IsCreateTemplateDone(_current);
				btnRescan.Enabled = !_isCapturing && !_isProcessing && IsCaptureDone(_current);
				lvQueue.Enabled = true;
			}
			lblStatus.Visible = _isCapturing;
		}

		private void DisableNavigation()
		{
			
			btnRescan.Enabled = false;
			btnAccept.Enabled = false;
		//	lvQueue.Enabled = false;
		}

		private void UpdateViewSize(int width, int height)
		{
			Size sz = fingerView.Size;
			fingerView.Zoom = Math.Max(0.01f, Math.Min((float)sz.Width / width, (float)sz.Height / height));
			fingerView.Invalidate();
		}

		private void OnFingerViewResize()
		{
			if (!_isCapturing && _current != null)
			{
				using (NImage image = _current.GetImage(false))
				{
					if (image != null) UpdateViewSize((int)image.Width, (int)image.Height);
				}
			}
		}

		#endregion

		#region Private static methods

		private static string PositionToString(NFPosition value)
		{
            string[,] slapPos = new string[7, 2] { { "PlainThumbs", "Ambos Pulgares" }, { "LeftIndexMiddleFingers", "Izq. Indice + Medio"},
                    {"LeftMiddleRingFingers","Izq. Medio + Anular"},{"LeftRingLittleFingers","Izq. Anular + Meñique"},
                    { "RightIndexMiddleFingers", "Der. Indice + Medio"} , { "RightMiddleRingFingers","Der. Medio + Anular"},{"RightRingLittleFingers","Der. Anular + Meñique"} };


            int fila = ArrayHelper.FindInDimensions(slapPos, value.ToString());

            //string text = string.Format("{0}{1}", PositionToString(item.Position), isRolled ? "(rolled)" : string.Empty);
            string text = string.Format("{0}", slapPos[fila, 1]);

			/*switch (value)
			{
				case NFPosition.LeftIndexMiddleRingFingers:
				case NFPosition.LeftMiddleRingFingers:
				case NFPosition.PlainThumbs: return EnumToString(value).Replace("Plain ", string.Empty);
				default: return EnumToString(value);
			}*/
            return text;
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

		#endregion

        private void LvQueueSelectedIndexChanged(object sender, MouseEventArgs e)
        {
            
            ListView.SelectedIndexCollection selected = lvQueue.SelectedIndices;
            if (selected.Count > 0)
            {
                int current = _captureList.IndexOf(_current);
                int index = selected[0];
                if (index != current)
                {
                    StartTask(_captureList[index]);
                }
            }

        }

        private void ChangeFingers(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection selected = lvQueue.SelectedIndices;
            if (selected.Count > 0)
            {
                int current = _captureList.IndexOf(_current);
                int index = selected[0];
                // if (index != current)
                //{
                NFinger dedoMouse = _captureList[index];
                fSelector.SelectedPosition = dedoMouse.Position;

                //  }
            }

        }

        private void captureWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void cancela_Click(object sender, EventArgs e)
        {
            FinishTask();

            fingerView.Finger = null;
            _current = null;
            SetStatus(string.Empty);
            _subject.Fingers.Clear();
            Close();
            return;

            
        }
	}
}
