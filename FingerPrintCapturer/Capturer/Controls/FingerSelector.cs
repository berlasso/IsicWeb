using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Neurotec.Biometrics;

namespace Capturer.Controls
{
	public sealed partial class FingerSelector : Panel
	{
		#region Nested types

		public class FingerClickArgs : MouseEventArgs
		{
			#region Private fields

			private readonly NFPosition _position;

			#endregion

			#region Public properties

			public NFPosition Position
			{
				get { return _position; }
			}

			#endregion

			#region Public constructor

			public FingerClickArgs(NFPosition position, MouseEventArgs e)
				: base(e.Button, e.Clicks, e.X, e.Y, e.Delta)
			{
				_position = position;
			}

			#endregion
		}

		private sealed class SvgPath
		{
			#region Private fields

			private GraphicsPath _path;
			private float _strokeAlpha;
			private Region _region;
			private bool _fill;
			private Color _fillColor = Color.Transparent;
			private NFPosition _position = (NFPosition)(-1);
			private string _id;
			private float _scale = 1.0f;

			#endregion

			#region Public properties

			public string Id
			{
				get { return _id; }
				set { _id = value; }
			}

			public bool Fill
			{
				get { return _fill; }
				set { _fill = value; }
			}

			public Color FillColor
			{
				get { return _fillColor; }
				set { _fillColor = value; }
			}

			public NFPosition Position
			{
				get { return _position; }
				set { _position = value; }
			}

			public float Scale
			{
				get { return _scale; }
				set { _scale = value; }
			}

			public GraphicsPath Path
			{
				get { return _path; }
				set
				{
					_path = value;
					_region = new Region(_path);
				}
			}

			public float StrokeAlpha
			{
				get { return _strokeAlpha; }
				set { _strokeAlpha = value; }
			}

			#endregion

			#region Public methods

			public void DrawElement(Graphics g)
			{
				using (Pen p = new Pen(Color.FromArgb((int)(_strokeAlpha * 255), Color.Black)))
				{
					g.DrawPath(p, _path);
					if (!Fill) return;
					using (Brush b = new SolidBrush(FillColor))
					{
						g.FillPath(b, _path);
					}
				}
			}

			public bool HitTest(Point point)
			{
				if (_region == null)
					return false;
				return _region.IsVisible(point.X / Scale, point.Y / Scale);
			}

			#endregion
		}

		private class SvgPainter
		{
			#region Private fields

			private int _width, _height;
			private readonly List<SvgPath> _paths;
			private readonly Dictionary<NFPosition, SvgPath> _elements;

			#endregion

			#region Public constructor

			public SvgPainter(string handsString)
			{
				_paths = new List<SvgPath>();
				_elements = new Dictionary<NFPosition, SvgPath>();

				ParsePaths(handsString);

				foreach (SvgPath item in _paths)
				{
					if (!item.Id.EndsWith("Rotate")) continue;
					item.Fill = true;
					item.FillColor = Color.GreenYellow;
					item.StrokeAlpha = 1;
				}
			}

			#endregion

			#region Private methods

			private static PointF ToAbsolute(PointF absolute, PointF reliative)
			{
				return PointF.Add(absolute, new SizeF(reliative.X, reliative.Y));
			}

			private GraphicsPath ParsePath(string value)
			{
				GraphicsPath gp = new GraphicsPath();
				string[] vals = value.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
				PointF[] pnts = new PointF[4];
				PointF endPoint = new PointF();
				int j = 0, k = 0;
				bool relative = false;
				while (j < vals.Length)
				{
					if (vals[j] == "m" || vals[j] == "M")//move
					{
						endPoint = new PointF(float.Parse(vals[j + 1], System.Globalization.CultureInfo.InvariantCulture), float.Parse(vals[j + 2], System.Globalization.CultureInfo.InvariantCulture));
						j += 3;
					}
					else if (vals[j] == "l" || vals[j] == "L")//draw line
					{
						relative = char.IsLower(vals[j][0]);
						PointF point = new PointF(float.Parse(vals[j + 1], System.Globalization.CultureInfo.InvariantCulture), float.Parse(vals[j + 2], System.Globalization.CultureInfo.InvariantCulture));
						j += 3;
						if (relative)
							point = ToAbsolute(endPoint, point);
						gp.AddLine(endPoint, point);
						endPoint = point;
					}
					else if (vals[j] == "z" || vals[j] == "Z")//end
					{
						gp.CloseFigure();
						j++;
					}
					else if (vals[j] == "c" || vals[j] == "C")//curve
					{
						relative = char.IsLower(vals[j][0]);
						j++;
					}
					else
					{
						//still curve
						PointF point = new PointF(float.Parse(vals[j], System.Globalization.CultureInfo.InvariantCulture), float.Parse(vals[j + 1], System.Globalization.CultureInfo.InvariantCulture));
						if (relative)
							point = ToAbsolute(endPoint, point);
						switch (k)
						{
							case 0:
								pnts[0] = endPoint;
								pnts[1] = point;
								k = 2;
								break;
							case 2:
								pnts[k] = point;
								k++;
								break;
							case 3:
								pnts[3] = point;
								endPoint = point;
								k = 0;
								gp.AddBezier(pnts[0], pnts[1], pnts[2], pnts[3]);
								break;
						}
						j += 2;
					}
				}
				return gp;
			}

			private void ParsePaths(string xmlString)
			{
				XmlReader xml = new XmlTextReader(new StringReader(xmlString));
				while (xml.Read())
				{
					if (xml.NodeType == XmlNodeType.Element)
					{
						if (xml.Name == "svg")
						{
							if (!xml.MoveToAttribute("width")) throw new Exception("width attribute not found");
							_width = int.Parse(xml.Value);
							if (_width == 0) throw new Exception("width attribute is invalid");
							if (!xml.MoveToAttribute("height")) throw new Exception("height attribute not found");
							_height = int.Parse(xml.Value);
							if (_height == 0) throw new Exception("height attribute is invalid");
						}
						else if (xml.Name == "path")
						{
							int count = xml.AttributeCount;
							SvgPath shape = new SvgPath();

							_paths.Add(shape);
							for (int i = 0; i < count; i++)
							{
								xml.MoveToAttribute(i);
								switch (xml.Name)
								{
									case "d":
										{
											string id = xml.GetAttribute("id");
											if (id != null && id.EndsWith("Rotate"))
											{
												id = 123.ToString();
											}
											shape.Path = ParsePath(xml.Value);
											break;
										}
									case "position":
										{
											shape.Position = (NFPosition)Enum.Parse(typeof(NFPosition), xml.Value);
											shape.Fill = true;
											if (shape.Position == NFPosition.PlainLeftFourFingers ||
												shape.Position == NFPosition.PlainRightFourFingers ||
												shape.Position == NFPosition.PlainThumbs)
											{
												shape.FillColor = Color.Transparent;
											}
											_elements.Add(shape.Position, shape);
											break;
										}
									case "id":
										{
											shape.Id = xml.Value;
											break;
										}
									case "style":
										{
											string[] vals = xml.Value.Split(';');
											foreach (string t in vals)
											{
												string item = t;
												if (item.StartsWith("fill:"))
												{
													item = item.Replace("fill:", "");
													shape.FillColor = Color.Transparent;
													if (item != "none") shape.FillColor = ColorTranslator.FromHtml(item);
													continue;
												}
												if (item.StartsWith("stroke-opacity:"))
												{
													item = item.Replace("stroke-opacity:", "");
													shape.StrokeAlpha = float.Parse(item, System.Globalization.CultureInfo.InvariantCulture);
													continue;
												}
											}
											break;
										}
								}
							}
						}
					}
				}
				xml.Close();
			}

			#endregion

			#region Public methods

			public void Paint(Graphics g, Size clientSize)
			{
				g.SmoothingMode = SmoothingMode.HighQuality;
				Matrix m = g.Transform;

				float scale = Math.Min((float)clientSize.Width / _width, (float)clientSize.Height / _height);
				g.ScaleTransform(scale, scale);

				foreach (SvgPath item in _paths)
				{
					item.Scale = scale;
					if (!item.Id.EndsWith("Rotate"))
					{
						item.DrawElement(g);
					}
				}

				g.Transform = m;
			}

			public void PaintRotateForFinger(Graphics g, Size clientSize, NFPosition position, float angle)
			{
				if (!_elements.ContainsKey(position)) return;

				SvgPath path = null;
				foreach (SvgPath item in _paths)
				{
					if (item.Id == string.Format("{0}Rotate", position).Replace("Finger", string.Empty))
					{
						path = item;
						break;
					}
				}

				if (path == null) return;

				g.SmoothingMode = SmoothingMode.HighQuality;
				Matrix m = g.Transform;

				float scale = Math.Min((float)clientSize.Width / _width, (float)clientSize.Height / _height);
				m.Scale(scale, scale);

				Region reg = new Region(path.Path);
				RectangleF bounds = reg.GetBounds(g);
				PointF rotateAt = new PointF(bounds.X + bounds.Width / 2, bounds.Y + bounds.Height / 2);
				m.RotateAt(angle, rotateAt);
				g.Transform = m;

				path.DrawElement(g);
			}

			#endregion

			#region Public properties

			public Dictionary<NFPosition, SvgPath> Elements
			{
				get { return _elements; }
			}

			#endregion
		}

		#endregion

		#region Private fields

		private readonly SvgPainter _painter;
		private NFPosition _selectedPosition = NFPosition.Unknown;
		private readonly List<NFPosition> _missingPositions = new List<NFPosition>();
		private Point _mousePosition = new Point(0, 0);
		private bool _allowHighlight = true;
		private bool _isRolled;
		private bool _rollStarted;
		private float _rollAngle;

		#endregion

		#region Public constructor

		public FingerSelector()
		{
			InitializeComponent();
			DoubleBuffered = true;

			_painter = new SvgPainter(Encoding.UTF8.GetString(FingerCapturer.Properties.Resources.TwoHands));
		}

		#endregion

		#region Public properties

		[Browsable(false)]
		public bool IsRolled
		{
			get
			{
				return _isRolled;
			}
			set
			{
				if (_isRolled != value)
				{
					_isRolled = value;
					OnDataChanged();
				}
			}
		}

		[Browsable(false)]
		public NFPosition SelectedPosition
		{
			get { return _selectedPosition; }
			set
			{
				if (_selectedPosition != value)
				{
					_selectedPosition = value;
					OnDataChanged();
				}
			}
		}

		[Browsable(false)]
		public NFPosition[] MissingPositions
		{
			get { return _missingPositions.ToArray(); }
			set
			{
				_missingPositions.Clear();
				if (value != null)
				{
					foreach (NFPosition item in value)
					{
						if (NBiometricTypes.IsPositionSingleFinger(item))
							_missingPositions.Add(item);
					}
				}
				OnDataChanged();
			}
		}

		[Category("Behavior")]
		public bool AllowHighlight
		{
			get { return _allowHighlight; }
			set
			{
				if (_allowHighlight != value)
				{
					_allowHighlight = value;
					OnDataChanged();
				}
			}
		}

		#endregion

		#region Public events

		public event EventHandler<FingerClickArgs> FingerClick;

		#endregion

		#region Private methods

		private void OnDataChanged()
		{
			bool needsRepaint = false;
			foreach (SvgPath item in _painter.Elements.Values)
			{
				Color color = Color.Transparent;
				if (_allowHighlight && item.HitTest(_mousePosition) && NBiometricTypes.IsPositionSingleFinger(item.Position))
					color = Color.DarkRed;
				else if (_missingPositions.Contains(item.Position))
					color = Color.Red;
				else if (item.Position == _selectedPosition)
					color = Color.Green;
				if (item.FillColor != color)
				{
					item.FillColor = color;
					needsRepaint = true;
				}
			}

			if (IsRolled && NBiometricTypes.IsPositionSingleFinger(_selectedPosition))
			{
				if (!_rollStarted)
				{
					_rollStarted = true;
					timer.Start();
				}
				needsRepaint = true;
			}
			else if (_rollStarted)
			{
				timer.Stop();
				_rollStarted = false;
				needsRepaint = true;
			}

			if (needsRepaint) Invalidate();
		}

		#endregion

		#region Private form events

		protected override void OnPaint(PaintEventArgs e)
		{
			if (_painter != null)
			{
				_painter.Paint(e.Graphics, ClientSize);

				if (_isRolled && NBiometricTypes.IsPositionSingleFinger(_selectedPosition))
				{
					_painter.PaintRotateForFinger(e.Graphics, ClientSize, _selectedPosition, _rollAngle);
				}
			}

			base.OnPaint(e);
		}

		protected override void OnResize(EventArgs e)
		{
			Invalidate();

			base.OnResize(e);
		}

		private void FingerSelectorMouseMove(object sender, MouseEventArgs e)
		{
			if (_allowHighlight)
			{
				_mousePosition = e.Location;

				OnDataChanged();
			}
		}

		private void FingerSelectorMouseClick(object sender, MouseEventArgs e)
		{
			if (FingerClick != null)
			{
				EventHandler<FingerClickArgs> click = FingerClick;
				Point p = e.Location;

				foreach (SvgPath item in _painter.Elements.Values)
				{
					if (NBiometricTypes.IsPositionSingleFinger(item.Position) && item.HitTest(p))
					{
						click(this, new FingerClickArgs(item.Position, e));
						return;
					}
				}
			}
		}

		private void TimerTick(object sender, EventArgs e)
		{
			if (InvokeRequired)
			{
				BeginInvoke(new EventHandler(TimerTick), sender, e);
			}
			else
			{
				_rollAngle = (_rollAngle + 15) % 360;
				Invalidate();
			}
		}

		#endregion
	}
}
