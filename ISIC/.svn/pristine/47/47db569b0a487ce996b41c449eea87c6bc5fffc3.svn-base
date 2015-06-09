namespace Capturer.Forms
{
	partial class LongTaskForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LongTaskForm));
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.lblTitle = new System.Windows.Forms.Label();
			this.bwLongTask = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(12, 29);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(343, 23);
			this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.progressBar1.TabIndex = 1;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Location = new System.Drawing.Point(12, 13);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(56, 13);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Working...";
			// 
			// bwLongTask
			// 
			this.bwLongTask.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwLongTaskDoWork);
			this.bwLongTask.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BwRefresherRunWorkerCompleted);
			// 
			// LongTaskForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(367, 69);
			this.ControlBox = false;
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.progressBar1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "LongTaskForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Working";
			this.Shown += new System.EventHandler(this.LongTaskFormShown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label lblTitle;
		private System.ComponentModel.BackgroundWorker bwLongTask;
	}
}
