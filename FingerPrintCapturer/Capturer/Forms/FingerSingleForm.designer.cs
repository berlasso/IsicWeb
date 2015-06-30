using Capturer.Controls;
namespace  Capturer.Forms
{
	partial class FingerSingleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FingerSingleForm));
            this.captureWorker = new System.ComponentModel.BackgroundWorker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvQueue = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnRescan = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.fSelector = new Capturer.Controls.FingerSelector();
            this.tableLayoutPanelCenter = new System.Windows.Forms.TableLayoutPanel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.fingerView = new Neurotec.Biometrics.Gui.NFingerView();
            this.lblStatus = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.extractWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanelCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // captureWorker
            // 
            this.captureWorker.WorkerSupportsCancellation = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.btnAccept);
            this.splitContainer1.Panel1.Controls.Add(this.btnRescan);
            this.splitContainer1.Panel1.Controls.Add(this.btnNext);
            this.splitContainer1.Panel1.Controls.Add(this.btnPrevious);
            this.splitContainer1.Panel1.Controls.Add(this.fSelector);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanelCenter);
            this.splitContainer1.Size = new System.Drawing.Size(901, 496);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lvQueue);
            this.groupBox1.Location = new System.Drawing.Point(3, 157);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 334);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Capture dos Dedos de la lista";
            // 
            // lvQueue
            // 
            this.lvQueue.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvQueue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvQueue.FullRowSelect = true;
            this.lvQueue.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvQueue.HideSelection = false;
            this.lvQueue.Location = new System.Drawing.Point(3, 16);
            this.lvQueue.MultiSelect = false;
            this.lvQueue.Name = "lvQueue";
            this.lvQueue.Size = new System.Drawing.Size(206, 315);
            this.lvQueue.TabIndex = 0;
            this.lvQueue.UseCompatibleStateImageBehavior = false;
            this.lvQueue.View = System.Windows.Forms.View.Details;
            this.lvQueue.SelectedIndexChanged += new System.EventHandler(this.LvQueueSelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 185;
            // 
            // btnAccept
            // 
            this.btnAccept.Enabled = false;
            this.btnAccept.Image = global::FingerCapturer.Properties.Resources.Ok;
            this.btnAccept.Location = new System.Drawing.Point(153, 111);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(50, 40);
            this.btnAccept.TabIndex = 5;
            this.toolTip.SetToolTip(this.btnAccept, "Accept image and extract recors");
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.BtnAcceptClick);
            // 
            // btnRescan
            // 
            this.btnRescan.Enabled = false;
            this.btnRescan.Image = global::FingerCapturer.Properties.Resources.Repeat;
            this.btnRescan.Location = new System.Drawing.Point(103, 111);
            this.btnRescan.Name = "btnRescan";
            this.btnRescan.Size = new System.Drawing.Size(50, 40);
            this.btnRescan.TabIndex = 4;
            this.toolTip.SetToolTip(this.btnRescan, "Repeat");
            this.btnRescan.UseVisualStyleBackColor = true;
            this.btnRescan.Click += new System.EventHandler(this.BtnRescanClick);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Image = global::FingerCapturer.Properties.Resources.GoToNext;
            this.btnNext.Location = new System.Drawing.Point(53, 111);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(50, 40);
            this.btnNext.TabIndex = 3;
            this.toolTip.SetToolTip(this.btnNext, "Next");
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.BtnNextClick);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Enabled = false;
            this.btnPrevious.Image = global::FingerCapturer.Properties.Resources.GoToPrevious;
            this.btnPrevious.Location = new System.Drawing.Point(3, 111);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(50, 40);
            this.btnPrevious.TabIndex = 2;
            this.toolTip.SetToolTip(this.btnPrevious, "Back");
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.BtnPreviousClick);
            // 
            // fSelector
            // 
            this.fSelector.AllowHighlight = false;
            this.fSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fSelector.IsRolled = false;
            this.fSelector.Location = new System.Drawing.Point(3, 3);
            this.fSelector.MissingPositions = new Neurotec.Biometrics.NFPosition[0];
            this.fSelector.Name = "fSelector";
            this.fSelector.SelectedPosition = Neurotec.Biometrics.NFPosition.Unknown;
            this.fSelector.Size = new System.Drawing.Size(212, 102);
            this.fSelector.TabIndex = 1;
            this.fSelector.Paint += new System.Windows.Forms.PaintEventHandler(this.fSelector_Paint);
            // 
            // tableLayoutPanelCenter
            // 
            this.tableLayoutPanelCenter.ColumnCount = 1;
            this.tableLayoutPanelCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelCenter.Controls.Add(this.lblInfo, 0, 0);
            this.tableLayoutPanelCenter.Controls.Add(this.fingerView, 0, 1);
            this.tableLayoutPanelCenter.Controls.Add(this.lblStatus, 0, 2);
            this.tableLayoutPanelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCenter.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelCenter.Name = "tableLayoutPanelCenter";
            this.tableLayoutPanelCenter.RowCount = 4;
            this.tableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCenter.Size = new System.Drawing.Size(675, 494);
            this.tableLayoutPanelCenter.TabIndex = 7;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(0, 0);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblInfo.Size = new System.Drawing.Size(675, 23);
            this.lblInfo.TabIndex = 6;
            this.lblInfo.Text = "Info";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fingerView
            // 
            this.fingerView.BackColor = System.Drawing.SystemColors.Control;
            this.fingerView.BoundingRectColor = System.Drawing.Color.Red;
            this.fingerView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fingerView.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fingerView.Location = new System.Drawing.Point(3, 26);
            this.fingerView.MinutiaColor = System.Drawing.Color.Red;
            this.fingerView.Name = "fingerView";
            this.fingerView.NeighborMinutiaColor = System.Drawing.Color.Orange;
            this.fingerView.ResultImageColor = System.Drawing.Color.Green;
            this.fingerView.SelectedMinutiaColor = System.Drawing.Color.Magenta;
            this.fingerView.SelectedSingularPointColor = System.Drawing.Color.Magenta;
            this.fingerView.SingularPointColor = System.Drawing.Color.Red;
            this.fingerView.Size = new System.Drawing.Size(669, 444);
            this.fingerView.TabIndex = 5;
            this.fingerView.TreeColor = System.Drawing.Color.Crimson;
            this.fingerView.TreeMinutiaNumberDiplayFormat = Neurotec.Biometrics.Gui.MinutiaNumberDiplayFormat.DontDisplay;
            this.fingerView.TreeMinutiaNumberFont = new System.Drawing.Font("Arial", 10F);
            this.fingerView.TreeWidth = 2D;
            this.fingerView.Resize += new System.EventHandler(this.FingerViewResize);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(3, 473);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(669, 16);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Status: comenzando la captura ...";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblStatus.Visible = false;
            // 
            // extractWorker
            // 
            this.extractWorker.WorkerSupportsCancellation = true;
            // 
            // FingerSingleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 496);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(250, 250);
            this.Name = "FingerSingleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Capturando ...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CaptureFormFormClosing);
            this.Load += new System.EventHandler(this.CaptureFormLoad);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanelCenter.ResumeLayout(false);
            this.tableLayoutPanelCenter.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.ComponentModel.BackgroundWorker captureWorker;
		private FingerSelector fSelector;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private Neurotec.Biometrics.Gui.NFingerView fingerView;
		private System.Windows.Forms.Button btnRescan;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnPrevious;
		private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.ToolTip toolTip;
		private System.ComponentModel.BackgroundWorker extractWorker;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCenter;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.ListView lvQueue;
		private System.Windows.Forms.ColumnHeader columnHeader1;
	}
}
