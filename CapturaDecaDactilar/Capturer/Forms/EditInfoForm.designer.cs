namespace Capturer.Forms
{
    partial class EditInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditInfoForm));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cbTemplate = new System.Windows.Forms.ComboBox();
            this.cbDbid = new System.Windows.Forms.ComboBox();
            this.cbHash = new System.Windows.Forms.ComboBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.chbUseCluster = new System.Windows.Forms.CheckBox();
            this.lblTemplate = new System.Windows.Forms.Label();
            this.lblDbid = new System.Windows.Forms.Label();
            this.lblHash = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cbThumbnailField = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnKey});
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView.Location = new System.Drawing.Point(35, 0);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(560, 172);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCellValueChanged);
            this.dataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DataGridViewRowsAdded);
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCellEndEdit);
            this.dataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.DataGridViewRowsRemoved);
            // 
            // ColumnKey
            // 
            this.ColumnKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnKey.HeaderText = "Key";
            this.ColumnKey.Name = "ColumnKey";
            this.ColumnKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(445, 382);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(526, 382);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbTemplate
            // 
            this.cbTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTemplate.Enabled = false;
            this.cbTemplate.FormattingEnabled = true;
            this.cbTemplate.Location = new System.Drawing.Point(117, 80);
            this.cbTemplate.Name = "cbTemplate";
            this.cbTemplate.Size = new System.Drawing.Size(478, 21);
            this.cbTemplate.TabIndex = 5;
            this.toolTip.SetToolTip(this.cbTemplate, "Select template field. Template will be created from extracted records");
            this.cbTemplate.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectedIndexChanged);
            // 
            // cbDbid
            // 
            this.cbDbid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDbid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDbid.Enabled = false;
            this.cbDbid.FormattingEnabled = true;
            this.cbDbid.Location = new System.Drawing.Point(117, 107);
            this.cbDbid.Name = "cbDbid";
            this.cbDbid.Size = new System.Drawing.Size(478, 21);
            this.cbDbid.TabIndex = 6;
            this.toolTip.SetToolTip(this.cbDbid, "Select dbid field. Before enrolling to server, dbid field must be filled by user " +
                    "in the information tab");
            this.cbDbid.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectedIndexChanged);
            // 
            // cbHash
            // 
            this.cbHash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbHash.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHash.Enabled = false;
            this.cbHash.FormattingEnabled = true;
            this.cbHash.Location = new System.Drawing.Point(117, 134);
            this.cbHash.Name = "cbHash";
            this.cbHash.Size = new System.Drawing.Size(478, 21);
            this.cbHash.TabIndex = 7;
            this.toolTip.SetToolTip(this.cbHash, "Select Hash name field. Hash name is generated automaticly by this program");
            this.cbHash.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectedIndexChanged);
            // 
            // btnUp
            // 
            this.btnUp.Image = global::FingerCapturer.Properties.Resources.ArrowUp;
            this.btnUp.Location = new System.Drawing.Point(0, 0);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(29, 30);
            this.btnUp.TabIndex = 6;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.BtnUpClick);
            // 
            // btnDown
            // 
            this.btnDown.Image = global::FingerCapturer.Properties.Resources.ArrowDown;
            this.btnDown.Location = new System.Drawing.Point(0, 36);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(29, 30);
            this.btnDown.TabIndex = 7;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.BtnDownClick);
            // 
            // chbUseCluster
            // 
            this.chbUseCluster.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chbUseCluster, 3);
            this.chbUseCluster.Location = new System.Drawing.Point(3, 3);
            this.chbUseCluster.Name = "chbUseCluster";
            this.chbUseCluster.Size = new System.Drawing.Size(216, 17);
            this.chbUseCluster.TabIndex = 0;
            this.chbUseCluster.Text = "Make compatible with NServer/NCluster";
            this.chbUseCluster.UseVisualStyleBackColor = true;
            this.chbUseCluster.CheckedChanged += new System.EventHandler(this.ChbUseClusterCheckedChanged);
            // 
            // lblTemplate
            // 
            this.lblTemplate.AutoSize = true;
            this.lblTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTemplate.Enabled = false;
            this.lblTemplate.Location = new System.Drawing.Point(23, 77);
            this.lblTemplate.Name = "lblTemplate";
            this.lblTemplate.Size = new System.Drawing.Size(88, 27);
            this.lblTemplate.TabIndex = 2;
            this.lblTemplate.Text = "Template field:";
            this.lblTemplate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDbid
            // 
            this.lblDbid.AutoSize = true;
            this.lblDbid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDbid.Enabled = false;
            this.lblDbid.Location = new System.Drawing.Point(23, 104);
            this.lblDbid.Name = "lblDbid";
            this.lblDbid.Size = new System.Drawing.Size(88, 27);
            this.lblDbid.TabIndex = 3;
            this.lblDbid.Text = "Dbid field:";
            this.lblDbid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHash
            // 
            this.lblHash.AutoSize = true;
            this.lblHash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHash.Enabled = false;
            this.lblHash.Location = new System.Drawing.Point(23, 131);
            this.lblHash.Name = "lblHash";
            this.lblHash.Size = new System.Drawing.Size(88, 27);
            this.lblHash.TabIndex = 4;
            this.lblHash.Text = "Hash Name field:";
            this.lblHash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblHash, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.chbUseCluster, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDbid, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblTemplate, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbTemplate, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbDbid, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbHash, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblInfo, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 217);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(598, 159);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblInfo, 2);
            this.lblInfo.Enabled = false;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Image = global::FingerCapturer.Properties.Resources.Help;
            this.lblInfo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblInfo.Location = new System.Drawing.Point(23, 23);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(564, 48);
            this.lblInfo.TabIndex = 8;
            this.lblInfo.Text = resources.GetString("lblInfo.Text");
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.cbThumbnailField);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnUp);
            this.panel1.Controls.Add(this.btnDown);
            this.panel1.Controls.Add(this.dataGridView);
            this.panel1.Location = new System.Drawing.Point(3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 210);
            this.panel1.TabIndex = 8;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::FingerCapturer.Properties.Resources.Bad;
            this.btnDelete.Location = new System.Drawing.Point(0, 72);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(29, 30);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDeleteClick);
            // 
            // cbThumbnailField
            // 
            this.cbThumbnailField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbThumbnailField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbThumbnailField.FormattingEnabled = true;
            this.cbThumbnailField.Location = new System.Drawing.Point(137, 184);
            this.cbThumbnailField.Name = "cbThumbnailField";
            this.cbThumbnailField.Size = new System.Drawing.Size(458, 21);
            this.cbThumbnailField.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Subject image field:";
            // 
            // EditInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 408);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(620, 400);
            this.Name = "EditInfoForm";
            this.Text = "Edit Info";
            this.Load += new System.EventHandler(this.EditInfoFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.CheckBox chbUseCluster;
        private System.Windows.Forms.Label lblHash;
        private System.Windows.Forms.Label lblDbid;
        private System.Windows.Forms.Label lblTemplate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbTemplate;
        private System.Windows.Forms.ComboBox cbDbid;
        private System.Windows.Forms.ComboBox cbHash;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbThumbnailField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKey;
        private System.Windows.Forms.Button btnDelete;
    }
}
