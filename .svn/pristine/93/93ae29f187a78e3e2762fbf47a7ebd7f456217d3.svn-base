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

namespace Capturer.Forms
{
	public partial class FingerSingleForm : Form
	{
		#region Public constructor

		public FingerSingleForm()
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
        private NSubject _imputadoH;

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
        public NSubject imputadoH
        {
            get { return _imputadoH; }
            set { _imputadoH = value; }
        }

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

		#endregion

		#region Private form events

		private void CaptureFormLoad(object sender, EventArgs e)
		{
			if (_biometricClient != null && _subject != null)
			{
				fSelector.MissingPositions = _subject.MissingFingers.ToArray();
				SetStatus(string.Empty);

				_captureList = _subject.Fingers.Where(x => x.ParentObject == null).ToList();


               
                


                
				foreach (var item in _captureList)
				{
					bool isRolled = NBiometricTypes.IsImpressionTypeRolled(item.ImpressionType);

					string text = string.Format("{0}{1}", PositionToString(item.Position), isRolled ? "(rodada)" : string.Empty);

					var lvi = lvQueue.Items.Add(text);
					if (IsCreateTemplateDone(item)) lvi.ForeColor = Color.Green;
                   
				}

				if (!NextTask())
				{
					SetError("No pudo comenzar la captura");
				}
			}
		}

		private void CaptureFormFormClosing(object sender, FormClosingEventArgs e)
		{
			CancelAndWait();
			if (_current != null && !IsCreateTemplateDone(_current))
				_current.Image = null;
		}

		private void BtnPreviousClick(object sender, EventArgs e)
		{
			int index = _captureList.IndexOf(_current) - 1;
			if (index >= 0)
			{
				StartTask(_captureList[index]);
			}
		}

		private void BtnNextClick(object sender, EventArgs e)
		{
			NextTask();
		}

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
				SetStatus("Extrayendo los registro(s). Un momento por favor ...");
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
						SetStatus(Color.Green, Color.White, "El template ha sido creado exitosamente");
                     
          
                        _isProcessing = false;
                        // LOS ULTIMOS DOS ELEMENTOS DE SUBJECT SON LOS que scaneo OK
                        if (_subject.Fingers.Count() >= (10 - _subject.MissingFingers.Count()) * 2)
                      { // ya tengo loes 10  ultimos dedos scaneados OK
                            fingerView.Finger = null;
                            Close();
                            return;
                            /*hasta aca*/
                        }
                        else { 
                        // seguir scaneando el resto de los dedos
                          // NextTask();
                        }
                            
                            
                           


					}
					else
					{
                        SetError("No pudo crear el template, estado = {0}", EnumToString(status));
					}
				}
				catch (Exception ex)
				{
					Utilities.ShowError(ex);
					SetError("No pudo crear el template {0}", "Intentara volver a escanear: "+ex.Message);
                    /*Vuelve a Intentarlo ?*/
                    this.btnRescan.PerformClick();

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
			if (_current != null && _biometricClient.FingersCalculateNfiq)
			{
				NBiometricTask task = _biometricClient.CreateTask(NBiometricOperations.Segment | NBiometricOperations.AssessQuality, _subject);
				task.Biometric = _current;
				_isProcessing = true;
				_biometricClient.BeginPerformTask(task, OnAssessQualityCompleted, null);
				EnableControls();
			}
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
					SetStatus(Color.Green, Color.White, "Captura exitosa {0}. Ajuste el area(s) en caso de ser necesario y presione el botón aceptar", PositionToString(_current.Position));
				}
				catch (Exception ex)
				{
					SetError("El índice de calidad no alcanzado {0}", ex.Message);
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
            Capturer.Code.NBiometricStatusEsp traducirEstado;
			if (args.PropertyName == "Status")
			{
				BeginInvoke(new Action<NBiometricStatus>(status =>
				{
					Color statusColor = status == NBiometricStatus.Ok || status == NBiometricStatus.None ? Color.Green : Color.Red;
                
                    int valor = (int)status;

                    traducirEstado = (Capturer.Code.NBiometricStatusEsp)valor;
                    lblStatus.Text = string.Format("Score: {0}", EnumToString(traducirEstado));
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
						SetStatus(Color.Green, Color.White, "Captura exitosa {0}. Ajuste el area en caso de ser necesario y presione el botón aceptar", PositionToString(_current.Position));
					}
					else
					{
						SetError("La operación falló, estado = {0}", EnumToString(status));
                        _isCapturing = false;
                        _isProcessing = false;
                       // EnableControls();
                        _current.PropertyChanged -= OnPropertyChanged;
                        /*agregado*/
                        btnRescan.Enabled = true;
                        BtnRescanClick(null,null);
                        return;
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
					if (!Utilities.ShowQuestion(this, "Los registros no fueron extraídos de esta imagen! Por favor, presione 'Yes' para continuar de todos modos, presione 'No' y luego presione el botoón Aceptar"))
					{
						toolTip.Show("Acepta la imagen y la extracción que se visualiza", btnAccept);
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
			SetStatus(isRolled ? "Por favor apoye el dedo {0} sobre el scanner (rodada automáticamente)" : "Por favor apoye el dedo {0} (plana) sobre el scanner", PositionToString(task.Position));

			int index = _captureList.IndexOf(_current);
			lvQueue.Items[index].Selected = true;

			fingerView.Finger = _current;
			if (!IsCreateTemplateDone(_current))
			{
				var biometricTask = _biometricClient.CreateTask(NBiometricOperations.Capture | NBiometricOperations.Segment | NBiometricOperations.AssessQuality, _subject);
				biometricTask.Biometric = _current;
				_current.PropertyChanged += OnPropertyChanged;
				_isCapturing = true;
                /*AGREGADO MARTHA NUEVO*/
                OnFingerViewResize();

                _biometricClient.BeginPerformTask(biometricTask, OnCaptureCompleted, null);
			}
			else
			{
				SetStatus(Color.Green, Color.White, "Registro(s) extraído exitosamente");
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
					tool.AllowManipulations = !_isProcessing && !_isCapturing;
					fingerView.Invalidate();
				}
				btnPrevious.Enabled = _current != _captureList.First() && !_isProcessing;
				btnNext.Enabled = _current != _captureList.Last() && !_isProcessing;
				btnAccept.Enabled = !_isCapturing && !_isProcessing && IsCaptureDone(_current) && !IsCreateTemplateDone(_current);
				btnRescan.Enabled = !_isCapturing && !_isProcessing && IsCaptureDone(_current);
				lvQueue.Enabled = true;
			}
			lblStatus.Visible = _isCapturing;
		}

		private void DisableNavigation()
		{
			btnNext.Enabled = false;
			btnPrevious.Enabled = false;
			btnRescan.Enabled = false;
			btnAccept.Enabled = false;
			lvQueue.Enabled = false;
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
			switch (value)
			{
				case NFPosition.PlainLeftFourFingers:
				case NFPosition.PlainRightFourFingers:
				case NFPosition.PlainThumbs: return EnumToString(value).Replace("Plain ", string.Empty);
                case NFPosition.LeftIndexFinger:
                    return "Izq. Indice";
                 case NFPosition.PlainLeftThumb:
                 case NFPosition.LeftThumb:
                    return "Izq. Pulgar";
                case NFPosition.PlainRightThumb:
                case NFPosition.RightThumb:
                    return "Der. Pulgar";
                case NFPosition.RightIndex:
                    return "Der. Indice";
                case NFPosition.LeftRing:
                    return "Izq. Anular";
                case NFPosition.LeftMiddle:
                    return "Izq. Medio";
                case NFPosition.LeftLittle:
                    return "Izq. Meñique";
                case NFPosition.RightRing:
                    return "Der. Anular";
                case NFPosition.RightMiddle:
                    return "Der. Medio";
                case NFPosition.RightLittle:
                    return "Der. Meñique";

            	default: return EnumToString(value);
			}
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

        private void fSelector_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lvQueue_MouseDoubleClick(object sender, MouseEventArgs e)
        {

           
            _current.Image = null;
            int index = _captureList.IndexOf(_current);
            lvQueue.Items[index].ForeColor = Color.Black;

            StartTask(_current);


            
          /*  int index = 0;
           ListView.SelectedIndexCollection selected = lvQueue.SelectedIndices;
           if (selected.Count > 0)
           {
               
               _current.Image = null;
               _current = null;

               _isCapturing = false;
               _isProcessing = false;
           
               btnRescan.Enabled = true;
               StartTask(_captureList[selected[0]]);
           }*/
        }
	}
}
