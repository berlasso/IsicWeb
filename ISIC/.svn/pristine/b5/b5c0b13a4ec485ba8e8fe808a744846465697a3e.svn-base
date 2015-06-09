using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;
using Neurotec.Biometrics;
using Neurotec.Images;
using Neurotec.IO;
using Neurotec;

namespace Capturer
{
	public class InfoField
	{
		#region Public constructors

		public InfoField()
		{
		}

		public InfoField(string value)
		{
			if (value == null) throw new ArgumentNullException("value");

			string[] items = value.Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string item in items)
			{
				string str = item.Trim();
				string lower = str.ToLower();
				int first = str.IndexOf("'");
				int last = str.LastIndexOf("'");
				string v = str.Substring(first + 1, last - first - 1);
				if (lower.StartsWith("key"))
				{
					Key = v;
				}
				else if (lower.StartsWith("isthumbnail"))
				{
					ShowAsThumbnail = Convert.ToBoolean(v, CultureInfo.InvariantCulture);
					if (ShowAsThumbnail) Value = null;
				}
				else if (lower.StartsWith("enrolltoserver"))
				{
					EnrollToServer = Convert.ToBoolean(v, CultureInfo.InvariantCulture);
				}
			}
		}

		#endregion

		#region Public fields

		public string Key;
		public object Value = string.Empty;
		public bool ShowAsThumbnail;
		public bool EnrollToServer;
		public bool IsEditable = true;

		#endregion

		#region Public methods

		public override string ToString()
		{
			string result = string.Format("Key = '{0}'", Key);
			if (ShowAsThumbnail) result += ", IsThumbnail = 'True'";
			if (EnrollToServer) result += ", EnrollToServer = 'True'";
			return result;
		}

		#endregion
	}

	public class DataModel : IDisposable
	{
		#region Private types

		private class InfoDescriptor : PropertyDescriptor
		{
			#region Private fields

			private InfoField target;

			#endregion

			#region Public constructor

			public InfoDescriptor(InfoField inf)
				: base(inf.Key, null)
			{
				target = inf;
			}

			#endregion

			#region Public methods

			public override bool ShouldSerializeValue(object component)
			{
				return false;
			}

			public override void SetValue(object component, object value)
			{
				target.Value = value;
			}

			public override void ResetValue(object component)
			{
				throw new NotSupportedException();
			}

			public override object GetValue(object component)
			{
				return target.Value;
			}

			public override bool CanResetValue(object component)
			{
				return false;
			}

			#endregion

			#region Public properties

			public override Type PropertyType
			{
				get
				{
					if (target.Value != null) return target.Value.GetType();
					else return typeof(string);
				}
			}

			public override bool IsReadOnly { get { return false; } }

			public override Type ComponentType { get { return null; } }

			public override string Category
			{
				get
				{
					return target.EnrollToServer ? "Enroll to Server" : "Information";
				}
			}

			#endregion
		};

		private class Information : List<InfoField>, ICustomTypeDescriptor
		{
			#region ICustomTypeDescriptor Members

			public AttributeCollection GetAttributes()
			{
				return TypeDescriptor.GetAttributes(this, true);
			}

			public string GetClassName()
			{
				return TypeDescriptor.GetClassName(this, true);
			}

			public string GetComponentName()
			{
				return TypeDescriptor.GetComponentName(this, true);
			}

			public TypeConverter GetConverter()
			{
				return TypeDescriptor.GetConverter(this, true);
			}

			public EventDescriptor GetDefaultEvent()
			{
				return TypeDescriptor.GetDefaultEvent(this, true);
			}

			public PropertyDescriptor GetDefaultProperty()
			{
				return TypeDescriptor.GetDefaultProperty(this, true);
			}

			public object GetEditor(Type editorBaseType)
			{
				return TypeDescriptor.GetEditor(this, editorBaseType, true);
			}

			public EventDescriptorCollection GetEvents()
			{
				return TypeDescriptor.GetEvents(this, true);
			}

			public EventDescriptorCollection GetEvents(Attribute[] attributes)
			{
				return TypeDescriptor.GetEvents(this, attributes, true);
			}

			public PropertyDescriptorCollection GetProperties()
			{
				return this.GetProperties(new Attribute[0]);
			}

			public object GetPropertyOwner(PropertyDescriptor pd)
			{
				return this;
			}

			public virtual PropertyDescriptorCollection GetProperties(Attribute[] attributes)
			{
				List<InfoDescriptor> descriptors = new List<InfoDescriptor>();
				foreach (InfoField inf in this)
				{
					if (inf.IsEditable)
					{
						descriptors.Add(new InfoDescriptor(inf));
					}
				}
				return new PropertyDescriptorCollection(descriptors.ToArray());
			}

			#endregion
		}

		#endregion

		#region Private fields

		private Information _info = new Information();
		private NSubject _subject;

		#endregion

		#region Private readonly fields

		private static readonly string InformationElement = "Information";
		private static readonly string InfoFieldElement = "Info";
		private static readonly string DataElement = "Data";
		private static readonly string TemplateAttribute = "Template";
		private static readonly string DataFieldElement = "DataField";
		private static readonly string PositionAttribute = "Position";
		private static readonly string ImpressionAttribute = "Impression";
		private static readonly string CreateStringAttribute = "CreateString";
		private static readonly string FileAttribute = "File";

		#endregion

		#region Public properties

		public List<InfoField> Info { get { return _info; } }
		public NSubject Subject
		{
			get { return _subject; }
			set { _subject = value; }
		}

		#endregion

		#region Public methods

		public void Save(string dir)
		{
			string dirName = Path.GetFileName(dir);

			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Indent = true;
			settings.NewLineOnAttributes = true;

			XmlWriter xml = XmlWriter.Create(Path.ChangeExtension(Path.Combine(dir, dirName), "xml"), settings);
			try
			{
				xml.WriteStartDocument();
				xml.WriteStartElement("EnrollmentResult");

				xml.WriteStartElement(InformationElement);
				foreach (InfoField inf in Info)
				{
					xml.WriteStartElement(InfoFieldElement);
					xml.WriteAttributeString(CreateStringAttribute, inf.ToString());
					if (inf.Value != null)
					{
						if (inf.Value is NImage)
						{
							string name = Path.ChangeExtension(inf.Key, ".png");
							xml.WriteAttributeString(FileAttribute, name);
							((NImage)inf.Value).Save(Path.Combine(dir, name));
						}
						else xml.WriteValue(inf.Value);
					}
					xml.WriteEndElement();
				}
				xml.WriteEndElement();

				if (Subject != null)
				{
					xml.WriteStartElement(DataElement);
					using (NBuffer template = Subject.GetTemplateBuffer())
					{
						string name = "template";
						File.WriteAllBytes(Path.Combine(dir, name), template.ToArray());
						xml.WriteAttributeString(TemplateAttribute, name);
					}

					foreach (NFinger finger in Subject.Fingers.Where(x => x.Status == NBiometricStatus.Ok && x.ParentObject == null))
					{
						WriteFingerData(xml, dir, finger);
					}
					xml.WriteEndElement();
				}

				xml.WriteEndElement();
				xml.WriteEndDocument();
			}
			finally
			{
				xml.Close();
			}
		}

		public object[] GetClusterEnrollParams(string dbidField, string templateField, string hashNameField, out int keyIndex)
		{
			keyIndex = -1;

			bool dbidFound = false, templateFound = false, hashNameFound = false;
			List<object> values = new List<object>();
			foreach (InfoField item in _info.Where(x => x.EnrollToServer))
			{
				if (item.Key == dbidField)
				{
					if (string.IsNullOrEmpty(item.Value as string)) throw new ArgumentNullException(string.Format("{0} value is null", item.Key));
					values.Add(item.Value);
					keyIndex = values.Count;
					dbidFound = true;
				}
				else if (item.Key == templateField)
				{
					if (Subject != null)
					{
						using (NTemplate template = Subject.GetTemplate())
						{
							if (template.Fingers != null)
							{
								using (var buffer = template.Save())
								{
									values.Add(buffer.ToArray());
									templateFound = true;
								}
							}
						}
					}
					if (templateFound == false) throw new InvalidOperationException("Template is empty. Please extract at least one record to proceed");
				}
				else if (item.Key == hashNameField)
				{
					values.Add(new Random().Next(ushort.MaxValue));
					hashNameFound = true;
				}
				else
				{
					if (item.Value is NObject)
					{
						using (NBuffer buffer = ((NObject)item.Value).Save())
						{
							values.Add(buffer.ToArray());
						}
					}
					else
						values.Add(item.Value);
				}
			}

			if (!hashNameFound) throw new ArgumentException("Hash name not found");
			if (!dbidFound) throw new ArgumentException("dbid not found");
			if (!templateFound) throw new ArgumentException("template not found");

			return values.ToArray();
		}

		#endregion

		#region Private methods

		private void WriteFingerData(XmlWriter xml, string dir, NFinger finger)
		{
			xml.WriteStartElement(DataFieldElement);
			xml.WriteAttributeString(PositionAttribute, finger.Position.ToString());
			xml.WriteAttributeString(ImpressionAttribute, finger.ImpressionType.ToString());

			string name = string.Format("{0}{1}", finger.Position, NBiometricTypes.IsImpressionTypeRolled(finger.ImpressionType) ? "_Rolled" : string.Empty);
			name = Path.ChangeExtension(name, "png");
			string imagePath = Path.Combine(dir, name);
			finger.Image.Save(imagePath);
			xml.WriteAttributeString(FileAttribute, name);

			var children = finger.Objects.Select(x => x.Child as NFinger).Where(x => x != null);
			foreach (var child in children)
			{
				WriteFingerData(xml, dir, child);
			}

			xml.WriteEndElement();
		}

		#endregion

		#region IDisposable Members

		public void Dispose()
		{
			Subject.Dispose();
			Subject = null;
		}

		#endregion
	}
}
