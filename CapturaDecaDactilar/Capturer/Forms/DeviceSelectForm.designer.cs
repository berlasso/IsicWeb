namespace Capturer.Forms
{
    partial class DeviceSelectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceSelectForm));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbScanner = new System.Windows.Forms.ComboBox();
            this.lblCanCaptureSlaps = new System.Windows.Forms.Label();
            this.lblCanCaptureRolled = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(191, 109);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(272, 109);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Selected scanner";
            // 
            // cbScanner
            // 
            this.cbScanner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbScanner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbScanner.FormattingEnabled = true;
            this.cbScanner.Location = new System.Drawing.Point(12, 26);
            this.cbScanner.Name = "cbScanner";
            this.cbScanner.Size = new System.Drawing.Size(335, 21);
            this.cbScanner.TabIndex = 3;
            this.cbScanner.SelectedIndexChanged += new System.EventHandler(this.CbScannerSelectedIndexChanged);
            // 
            // lblCanCaptureSlaps
            // 
            this.lblCanCaptureSlaps.Image = global::FingerCapturer.Properties.Resources.Bad;
            this.lblCanCaptureSlaps.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCanCaptureSlaps.Location = new System.Drawing.Point(37, 62);
            this.lblCanCaptureSlaps.Name = "lblCanCaptureSlaps";
            this.lblCanCaptureSlaps.Size = new System.Drawing.Size(127, 13);
            this.lblCanCaptureSlaps.TabIndex = 4;
            this.lblCanCaptureSlaps.Text = "Can capture slaps";
            this.lblCanCaptureSlaps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCanCaptureRolled
            // 
            this.lblCanCaptureRolled.Image = global::FingerCapturer.Properties.Resources.Bad;
            this.lblCanCaptureRolled.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCanCaptureRolled.Location = new System.Drawing.Point(37, 90);
            this.lblCanCaptureRolled.Name = "lblCanCaptureRolled";
            this.lblCanCaptureRolled.Size = new System.Drawing.Size(160, 13);
            this.lblCanCaptureRolled.TabIndex = 5;
            this.lblCanCaptureRolled.Text = "Can capture rolled fingers";
            this.lblCanCaptureRolled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DeviceSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 144);
            this.Controls.Add(this.lblCanCaptureRolled);
            this.Controls.Add(this.lblCanCaptureSlaps);
            this.Controls.Add(this.cbScanner);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Scanner";
            this.Load += new System.EventHandler(this.ScannerFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbScanner;
        private System.Windows.Forms.Label lblCanCaptureSlaps;
        private System.Windows.Forms.Label lblCanCaptureRolled;
    }
}
