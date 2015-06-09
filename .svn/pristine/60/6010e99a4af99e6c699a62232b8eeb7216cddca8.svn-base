using FingerCapturer.Properties;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Capturer.Forms
{
	public partial class EditInfoForm : Form
	{
		#region Public constructor

		public EditInfoForm()
		{
			InitializeComponent();

			_enrollToServerColumn = new DataGridViewCheckBoxColumn();
			_enrollToServerColumn.HeaderText = @"Enroll to server";
			_enrollToServerColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
		}

		#endregion

		#region Private fields

		private bool _suspendEvents;
		private readonly DataGridViewCheckBoxColumn _enrollToServerColumn;
		private InfoField [] _information;

		#endregion

		#region Public properties

		public InfoField [] Information
		{
			get { return _information; }
			set { _information = value; }
		}

		#endregion

		#region Private form events

		private void EditInfoFormLoad(object sender, EventArgs e)
		{
			_suspendEvents = true;

			dataGridView.Rows.Clear();
			foreach (InfoField item in Information)
			{
				dataGridView.Rows.Add(item.Key, item.IsEditable);
			}

			UpdateComboxes();

			chbUseCluster.Checked = Settings.Default.UseCluster;

			cbThumbnailField.SelectedItem = Settings.Default.InformationThumbnailField;

			cbTemplate.SelectedItem = Settings.Default.ClusterTemplateField;
			cbDbid.SelectedItem = Settings.Default.ClusterDbidField;
			cbHash.SelectedItem = Settings.Default.ClusterHashField;

			_suspendEvents = false;
		}

		private void ChbUseClusterCheckedChanged(object sender, EventArgs e)
		{
			bool isChecked = chbUseCluster.Checked;
			lblInfo.Enabled = isChecked;
			lblTemplate.Enabled = isChecked;
			lblHash.Enabled = isChecked;
			lblDbid.Enabled = isChecked;
			cbDbid.Enabled = isChecked;
			cbTemplate.Enabled = isChecked;
			cbHash.Enabled = isChecked;

			if (isChecked)
			{
				dataGridView.Columns.Add(_enrollToServerColumn);

				int index = cbDbid.SelectedIndex;
				if (index != -1) dataGridView.Rows[index].Cells[1].Value = true;
				index = cbTemplate.SelectedIndex;
				if (index != -1) dataGridView.Rows[index].Cells[1].Value = true;
				index = cbHash.SelectedIndex;
				if (index != -1) dataGridView.Rows[index].Cells[1].Value = true;

				for (int i = 0; i < _information.Length; i++)
				{
					if (_information[i].EnrollToServer) dataGridView.Rows[i].Cells[1].Value = true;
				}
			}
			else dataGridView.Columns.Remove(_enrollToServerColumn);
		}

		private void BtnUpClick(object sender, EventArgs e)
		{
			DataGridViewSelectedRowCollection rows = dataGridView.SelectedRows;
			if (rows.Count > 0)
			{
				DataGridViewRow row = rows[0];
				if (row.Index != 0)
				{
					_suspendEvents = true;

					int index = row.Index;
					dataGridView.Rows.RemoveAt(index--);
					dataGridView.Rows.Insert(index, row);
					dataGridView.ClearSelection();
					dataGridView.Rows[index].Selected = true;

					_suspendEvents = false;
				}
			}
		}

		private void BtnDownClick(object sender, EventArgs e)
		{
			DataGridViewSelectedRowCollection rows = dataGridView.SelectedRows;
			if (rows.Count > 0)
			{
				DataGridViewRow row = rows[0];
				if (row.Index != dataGridView.RowCount - 2)
				{
					_suspendEvents = true;

					int index = row.Index;
					dataGridView.Rows.RemoveAt(index++);
					dataGridView.Rows.Insert(index, row);
					dataGridView.ClearSelection();
					dataGridView.Rows[index].Selected = true;

					_suspendEvents = false;
				}
			}
		}

		private void DataGridViewRowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			if (_suspendEvents) return;
			UpdateComboxes();
		}

		private void DataGridViewRowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			if (_suspendEvents) return;
			UpdateComboxes();
		}

		private void DataGridViewCellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{
				int thumbnail = cbThumbnailField.SelectedIndex;
				int dbid = cbDbid.SelectedIndex;
				int hash = cbHash.SelectedIndex;
				int template = cbTemplate.SelectedIndex;

				UpdateComboxes();

				if (template == e.RowIndex) cbTemplate.SelectedIndex = template;
				if (hash == e.RowIndex) cbHash.SelectedIndex = hash;
				if (dbid == e.RowIndex) cbDbid.SelectedIndex = dbid;
				if (thumbnail - 1 == e.RowIndex) cbThumbnailField.SelectedIndex = thumbnail;
			}
		}

		private void BtnDeleteClick(object sender, EventArgs e)
		{
			DataGridViewSelectedRowCollection rows = dataGridView.SelectedRows;
			if (rows.Count > 0)
			{
				dataGridView.Rows.RemoveAt(rows[0].Index);
			}
		}

		private void DataGridViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (_suspendEvents) return;

			if (e.ColumnIndex == 0 && e.RowIndex >= 0)
			{
				int thumbnail = cbThumbnailField.SelectedIndex;
				int dbid = cbDbid.SelectedIndex;
				int hash = cbHash.SelectedIndex;
				int template = cbTemplate.SelectedIndex;

				UpdateComboxes();

				if (template == e.RowIndex) cbTemplate.SelectedIndex = template;
				if (hash == e.RowIndex) cbHash.SelectedIndex = hash;
				if (dbid == e.RowIndex) cbDbid.SelectedIndex = dbid;
				if (thumbnail - 1 == e.RowIndex) cbThumbnailField.SelectedIndex = thumbnail;
			}
		}

		private void ComboBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox combo = (ComboBox)sender;
			if (dataGridView.ColumnCount > 1)
			{
				dataGridView.Rows[combo.SelectedIndex].Cells[1].Value = true;
			}
		}

		private void BtnOkClick(object sender, EventArgs e)
		{
			foreach (DataGridViewRow row in dataGridView.Rows)
			{
				if (!row.IsNewRow && string.IsNullOrEmpty(row.Cells[0].Value as string))
				{
					Utilities.ShowError("Key value is invalid");
					dataGridView.ClearSelection();
					row.Selected = true;
					return;
				}
			}

			if (dataGridView.Rows.Count <= 1)
			{
				Utilities.ShowError("Create at least one row of information description");
				return;
			}

			string hash = null;
			string template = null;
			if (chbUseCluster.Checked)
			{
				string dbid = cbDbid.SelectedItem as string;
				hash = cbHash.SelectedItem as string;
				template = cbTemplate.SelectedItem as string;

				if (string.IsNullOrEmpty(dbid)) { Utilities.ShowError("dbid field not selected"); return; }
				if (string.IsNullOrEmpty(hash)) { Utilities.ShowError("hash name field is not selected"); return; }
				if (string.IsNullOrEmpty(template)) { Utilities.ShowError("template field is not selected"); return; }

				if (dbid == hash || dbid == template || hash == template) { Utilities.ShowError("dbid, hash name, template can not be set to same values"); return; }

				Settings.Default.ClusterHashField = hash;
				Settings.Default.ClusterDbidField = dbid;
				Settings.Default.ClusterTemplateField = template;
			}

			string thumbnail = cbThumbnailField.SelectedItem as string;
			Settings.Default.InformationThumbnailField = thumbnail;

			List<InfoField> fields = new List<InfoField>();
			StringBuilder builder = new StringBuilder();
			foreach (DataGridViewRow row in dataGridView.Rows)
			{
				if (row.IsNewRow) continue;

				InfoField inf = new InfoField();
				inf.Key = row.Cells[0].Value as string;
				inf.ShowAsThumbnail = thumbnail == inf.Key;
				inf.IsEditable = !inf.ShowAsThumbnail && !(inf.Key == hash || inf.Key == template);
				if (dataGridView.ColumnCount > 1 && row.Cells[1].Value != null)
				{
					inf.EnrollToServer = (bool)row.Cells[1].Value;
				}
				if (inf.Key != null) inf.Key = inf.Key.Trim();

				fields.Add(inf);
				builder.AppendFormat("{0};", inf);
			}

			Settings.Default.UseCluster = chbUseCluster.Checked;
			Settings.Default.Information = builder.ToString();
			Settings.Default.Save();

			_information = fields.ToArray();

			DialogResult = DialogResult.OK;
		}

		#endregion

		#region Private methods

		private void UpdateComboxes()
		{
			UpdateComboBox(cbThumbnailField, true);
			UpdateComboBox(cbDbid, false);
			UpdateComboBox(cbHash, false);
			UpdateComboBox(cbTemplate, false);
		}

		private void UpdateComboBox(ComboBox combo, bool allowEmpty)
		{
			combo.BeginUpdate();
			try
			{
				string selected = combo.SelectedItem as string;
				combo.Items.Clear();
				if (allowEmpty) combo.Items.Add(string.Empty);
				foreach (DataGridViewRow row in dataGridView.Rows)
				{
					if (row.Cells[0].Value != null)
					{
						combo.Items.Add(row.Cells[0].Value);
					}
				}
				combo.SelectedItem = selected;
			}
			finally
			{
				combo.EndUpdate();
			}
		}

		#endregion
	}
}
