using Capturer.Controls;

namespace Capturer.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeScannerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeconntionSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editRequiredInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.bconsultaR = new System.Windows.Forms.Button();
            this.resultadoRNR = new System.Windows.Forms.Label();
            this.scoreRNR = new System.Windows.Forms.Label();
            this.ApyNomRNR = new System.Windows.Forms.Label();
            this.DNIRNR = new System.Windows.Forms.Label();
            this.RESULTADO = new System.Windows.Forms.Label();
            this.bSalvar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbCapturePlainFingers = new System.Windows.Forms.CheckBox();
            this.chbCaptureSlaps = new System.Windows.Forms.CheckBox();
            this.btnStartCapturing = new System.Windows.Forms.Button();
            this.chbCaptureRolled = new System.Windows.Forms.CheckBox();
            this.gbFingerSelector = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabInformation = new System.Windows.Forms.TabPage();
            this.label27 = new System.Windows.Forms.Label();
            this.cidentifica = new System.Windows.Forms.ComboBox();
            this.DNI = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.nombres = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rFemenino = new System.Windows.Forms.RadioButton();
            this.rMasculino = new System.Windows.Forms.RadioButton();
            this.apellido = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.toolStripViewControls = new System.Windows.Forms.ToolStrip();
            this.tsbSaveImage = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveRecord = new System.Windows.Forms.ToolStripButton();
            this.tabFingers = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.chbShowOriginal = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nfvLeftThumb = new Neurotec.Biometrics.Gui.NFingerView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.nfvLeftIndex = new Neurotec.Biometrics.Gui.NFingerView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.nfvLeftMiddle = new Neurotec.Biometrics.Gui.NFingerView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.nfvLeftRing = new Neurotec.Biometrics.Gui.NFingerView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.nfvLeftLittle = new Neurotec.Biometrics.Gui.NFingerView();
            this.panel9 = new System.Windows.Forms.Panel();
            this.nfvRightThumb = new Neurotec.Biometrics.Gui.NFingerView();
            this.panel10 = new System.Windows.Forms.Panel();
            this.nfvRightIndex = new Neurotec.Biometrics.Gui.NFingerView();
            this.panel11 = new System.Windows.Forms.Panel();
            this.nfvRightMiddle = new Neurotec.Biometrics.Gui.NFingerView();
            this.panel12 = new System.Windows.Forms.Panel();
            this.nfvRightRing = new Neurotec.Biometrics.Gui.NFingerView();
            this.panel13 = new System.Windows.Forms.Panel();
            this.nfvRightLittle = new Neurotec.Biometrics.Gui.NFingerView();
            this.tabRolled = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.chbShowOriginalRolled = new System.Windows.Forms.CheckBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.nfvLeftThumbRolled = new Neurotec.Biometrics.Gui.NFingerView();
            this.panel15 = new System.Windows.Forms.Panel();
            this.nfvLeftIndexRolled = new Neurotec.Biometrics.Gui.NFingerView();
            this.panel16 = new System.Windows.Forms.Panel();
            this.nfvLeftMiddleRolled = new Neurotec.Biometrics.Gui.NFingerView();
            this.panel17 = new System.Windows.Forms.Panel();
            this.nfvLeftRingRolled = new Neurotec.Biometrics.Gui.NFingerView();
            this.panel18 = new System.Windows.Forms.Panel();
            this.nfvLeftLittleRolled = new Neurotec.Biometrics.Gui.NFingerView();
            this.panel19 = new System.Windows.Forms.Panel();
            this.nfvRightThumbRolled = new Neurotec.Biometrics.Gui.NFingerView();
            this.panel20 = new System.Windows.Forms.Panel();
            this.nfvRightIndexRolled = new Neurotec.Biometrics.Gui.NFingerView();
            this.panel21 = new System.Windows.Forms.Panel();
            this.nfvRightMiddleRolled = new Neurotec.Biometrics.Gui.NFingerView();
            this.panel22 = new System.Windows.Forms.Panel();
            this.nfvRightRingRolled = new Neurotec.Biometrics.Gui.NFingerView();
            this.panel23 = new System.Windows.Forms.Panel();
            this.nfvRightLittleRolled = new Neurotec.Biometrics.Gui.NFingerView();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.fSelector = new Capturer.Controls.FingerSelector();
            this.infoPanel = new Capturer.Controls.InfoPanel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbFingerSelector.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabInformation.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStripViewControls.SuspendLayout();
            this.tabFingers.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.tabRolled.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel23.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1474, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator2,
            this.exportToolStripMenuItem,
            this.saveTemplateToolStripMenuItem,
            this.saveImagesToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.fileToolStripMenuItem.Text = "&Opciones";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.newToolStripMenuItem.Text = "&Nuevo";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItemClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(167, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.exportToolStripMenuItem.Text = "&Guardar Todo";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.ExportToolStripMenuItemClick);
            // 
            // saveTemplateToolStripMenuItem
            // 
            this.saveTemplateToolStripMenuItem.Name = "saveTemplateToolStripMenuItem";
            this.saveTemplateToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.saveTemplateToolStripMenuItem.Text = "Guardar template";
            this.saveTemplateToolStripMenuItem.Click += new System.EventHandler(this.SaveTemplateToolStripMenuItemClick);
            // 
            // saveImagesToolStripMenuItem
            // 
            this.saveImagesToolStripMenuItem.Name = "saveImagesToolStripMenuItem";
            this.saveImagesToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.saveImagesToolStripMenuItem.Text = "Guardar Imagenes";
            this.saveImagesToolStripMenuItem.Click += new System.EventHandler(this.SaveImagesToolStripMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.exitToolStripMenuItem.Text = "Salir";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeScannerToolStripMenuItem,
            this.changeconntionSettingsToolStripMenuItem,
            this.optionsToolStripMenuItem1,
            this.editRequiredInfoToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.optionsToolStripMenuItem.Text = "&Configuraci�n";
            // 
            // changeScannerToolStripMenuItem
            // 
            this.changeScannerToolStripMenuItem.Name = "changeScannerToolStripMenuItem";
            this.changeScannerToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.changeScannerToolStripMenuItem.Text = "&Cambia Scanner";
            this.changeScannerToolStripMenuItem.Click += new System.EventHandler(this.ChangeScannerToolStripMenuItemClick);
            // 
            // changeconntionSettingsToolStripMenuItem
            // 
            this.changeconntionSettingsToolStripMenuItem.Name = "changeconntionSettingsToolStripMenuItem";
            this.changeconntionSettingsToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.changeconntionSettingsToolStripMenuItem.Text = "Change Co&nnection Settings";
            this.changeconntionSettingsToolStripMenuItem.Visible = false;
            this.changeconntionSettingsToolStripMenuItem.Click += new System.EventHandler(this.ChangeconntionSettingsToolStripMenuItemClick);
            // 
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            this.optionsToolStripMenuItem1.Size = new System.Drawing.Size(225, 22);
            this.optionsToolStripMenuItem1.Text = "&Extraction Options";
            this.optionsToolStripMenuItem1.Click += new System.EventHandler(this.OptionsToolStripMenuItemClick);
            // 
            // editRequiredInfoToolStripMenuItem
            // 
            this.editRequiredInfoToolStripMenuItem.Name = "editRequiredInfoToolStripMenuItem";
            this.editRequiredInfoToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.editRequiredInfoToolStripMenuItem.Text = "Edit Required &Info";
            this.editRequiredInfoToolStripMenuItem.Visible = false;
            this.editRequiredInfoToolStripMenuItem.Click += new System.EventHandler(this.EditRequiredInfoToolStripMenuItemClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.helpToolStripMenuItem.Text = "&Ayuda";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 28);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.bconsultaR);
            this.splitContainer.Panel1.Controls.Add(this.resultadoRNR);
            this.splitContainer.Panel1.Controls.Add(this.scoreRNR);
            this.splitContainer.Panel1.Controls.Add(this.ApyNomRNR);
            this.splitContainer.Panel1.Controls.Add(this.DNIRNR);
            this.splitContainer.Panel1.Controls.Add(this.RESULTADO);
            this.splitContainer.Panel1.Controls.Add(this.bSalvar);
            this.splitContainer.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer.Panel1.Controls.Add(this.gbFingerSelector);
            this.splitContainer.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tabControl);
            this.splitContainer.Size = new System.Drawing.Size(1474, 702);
            this.splitContainer.SplitterDistance = 131;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 0;
            // 
            // bconsultaR
            // 
            this.bconsultaR.BackColor = System.Drawing.Color.LightSteelBlue;
            this.bconsultaR.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bconsultaR.Location = new System.Drawing.Point(409, 72);
            this.bconsultaR.Name = "bconsultaR";
            this.bconsultaR.Size = new System.Drawing.Size(160, 40);
            this.bconsultaR.TabIndex = 14;
            this.bconsultaR.Text = "Acceso al Renaper";
            this.bconsultaR.UseVisualStyleBackColor = false;
            this.bconsultaR.Click += new System.EventHandler(this.button2_Click);
            // 
            // resultadoRNR
            // 
            this.resultadoRNR.AutoSize = true;
            this.resultadoRNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultadoRNR.ForeColor = System.Drawing.Color.ForestGreen;
            this.resultadoRNR.Location = new System.Drawing.Point(1039, 64);
            this.resultadoRNR.Name = "resultadoRNR";
            this.resultadoRNR.Size = new System.Drawing.Size(118, 20);
            this.resultadoRNR.TabIndex = 11;
            this.resultadoRNR.Text = "AFIRMATIVO";
            this.resultadoRNR.Visible = false;
            // 
            // scoreRNR
            // 
            this.scoreRNR.AutoSize = true;
            this.scoreRNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreRNR.Location = new System.Drawing.Point(962, 64);
            this.scoreRNR.Name = "scoreRNR";
            this.scoreRNR.Size = new System.Drawing.Size(44, 20);
            this.scoreRNR.TabIndex = 10;
            this.scoreRNR.Text = "75%";
            this.scoreRNR.Visible = false;
            // 
            // ApyNomRNR
            // 
            this.ApyNomRNR.AutoSize = true;
            this.ApyNomRNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApyNomRNR.Location = new System.Drawing.Point(803, 64);
            this.ApyNomRNR.Name = "ApyNomRNR";
            this.ApyNomRNR.Size = new System.Drawing.Size(119, 20);
            this.ApyNomRNR.TabIndex = 9;
            this.ApyNomRNR.Text = "Ramirez Juan";
            this.ApyNomRNR.Visible = false;
            // 
            // DNIRNR
            // 
            this.DNIRNR.AutoSize = true;
            this.DNIRNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DNIRNR.Location = new System.Drawing.Point(641, 64);
            this.DNIRNR.Name = "DNIRNR";
            this.DNIRNR.Size = new System.Drawing.Size(125, 20);
            this.DNIRNR.TabIndex = 8;
            this.DNIRNR.Text = "DNI 17815623";
            this.DNIRNR.Visible = false;
            // 
            // RESULTADO
            // 
            this.RESULTADO.AutoSize = true;
            this.RESULTADO.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RESULTADO.ForeColor = System.Drawing.Color.SteelBlue;
            this.RESULTADO.Location = new System.Drawing.Point(582, 8);
            this.RESULTADO.Name = "RESULTADO";
            this.RESULTADO.Size = new System.Drawing.Size(249, 25);
            this.RESULTADO.TabIndex = 7;
            this.RESULTADO.Text = "Resultado del RENAPER";
            this.RESULTADO.Visible = false;
            // 
            // bSalvar
            // 
            this.bSalvar.Location = new System.Drawing.Point(407, 10);
            this.bSalvar.Name = "bSalvar";
            this.bSalvar.Size = new System.Drawing.Size(141, 33);
            this.bSalvar.TabIndex = 6;
            this.bSalvar.Text = "Guarda Imagen ";
            this.bSalvar.UseVisualStyleBackColor = true;
            this.bSalvar.Visible = false;
            this.bSalvar.Click += new System.EventHandler(this.bSalvar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbCapturePlainFingers);
            this.groupBox1.Controls.Add(this.chbCaptureSlaps);
            this.groupBox1.Controls.Add(this.btnStartCapturing);
            this.groupBox1.Controls.Add(this.chbCaptureRolled);
            this.groupBox1.Location = new System.Drawing.Point(4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(145, 122);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // chbCapturePlainFingers
            // 
            this.chbCapturePlainFingers.AutoSize = true;
            this.chbCapturePlainFingers.Checked = true;
            this.chbCapturePlainFingers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbCapturePlainFingers.Location = new System.Drawing.Point(9, 7);
            this.chbCapturePlainFingers.Name = "chbCapturePlainFingers";
            this.chbCapturePlainFingers.Size = new System.Drawing.Size(86, 17);
            this.chbCapturePlainFingers.TabIndex = 5;
            this.chbCapturePlainFingers.Text = "Huella Plana";
            this.chbCapturePlainFingers.UseVisualStyleBackColor = true;
            this.chbCapturePlainFingers.CheckedChanged += new System.EventHandler(this.CaptureComboBoxCheckedChanged);
            // 
            // chbCaptureSlaps
            // 
            this.chbCaptureSlaps.AutoSize = true;
            this.chbCaptureSlaps.Checked = true;
            this.chbCaptureSlaps.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbCaptureSlaps.Location = new System.Drawing.Point(29, 30);
            this.chbCaptureSlaps.Name = "chbCaptureSlaps";
            this.chbCaptureSlaps.Size = new System.Drawing.Size(95, 17);
            this.chbCaptureSlaps.TabIndex = 3;
            this.chbCaptureSlaps.Text = "Dos Dactilares";
            this.chbCaptureSlaps.UseVisualStyleBackColor = true;
            this.chbCaptureSlaps.CheckedChanged += new System.EventHandler(this.CaptureComboBoxCheckedChanged);
            // 
            // btnStartCapturing
            // 
            this.btnStartCapturing.Location = new System.Drawing.Point(9, 76);
            this.btnStartCapturing.Name = "btnStartCapturing";
            this.btnStartCapturing.Size = new System.Drawing.Size(125, 40);
            this.btnStartCapturing.TabIndex = 0;
            this.btnStartCapturing.Text = "Comienza Captura";
            this.btnStartCapturing.UseVisualStyleBackColor = true;
            this.btnStartCapturing.Click += new System.EventHandler(this.BtnStartCapturingClick);
            // 
            // chbCaptureRolled
            // 
            this.chbCaptureRolled.AutoSize = true;
            this.chbCaptureRolled.Location = new System.Drawing.Point(9, 53);
            this.chbCaptureRolled.Name = "chbCaptureRolled";
            this.chbCaptureRolled.Size = new System.Drawing.Size(97, 17);
            this.chbCaptureRolled.TabIndex = 4;
            this.chbCaptureRolled.Text = "Huella Rodada";
            this.chbCaptureRolled.UseVisualStyleBackColor = true;
            this.chbCaptureRolled.CheckedChanged += new System.EventHandler(this.CaptureComboBoxCheckedChanged);
            // 
            // gbFingerSelector
            // 
            this.gbFingerSelector.Controls.Add(this.fSelector);
            this.gbFingerSelector.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbFingerSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFingerSelector.Location = new System.Drawing.Point(155, 3);
            this.gbFingerSelector.Name = "gbFingerSelector";
            this.gbFingerSelector.Size = new System.Drawing.Size(246, 125);
            this.gbFingerSelector.TabIndex = 2;
            this.gbFingerSelector.TabStop = false;
            this.gbFingerSelector.Text = "Indica dedos faltantes";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(579, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 66);
            this.panel1.TabIndex = 12;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabInformation);
            this.tabControl.Controls.Add(this.tabFingers);
            this.tabControl.Controls.Add(this.tabRolled);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1472, 564);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.TabControlSelectedIndexChanged);
            // 
            // tabInformation
            // 
            this.tabInformation.Controls.Add(this.button1);
            this.tabInformation.Controls.Add(this.label27);
            this.tabInformation.Controls.Add(this.cidentifica);
            this.tabInformation.Controls.Add(this.DNI);
            this.tabInformation.Controls.Add(this.label26);
            this.tabInformation.Controls.Add(this.nombres);
            this.tabInformation.Controls.Add(this.label25);
            this.tabInformation.Controls.Add(this.groupBox2);
            this.tabInformation.Controls.Add(this.apellido);
            this.tabInformation.Controls.Add(this.label24);
            this.tabInformation.Controls.Add(this.infoPanel);
            this.tabInformation.Controls.Add(this.toolStripViewControls);
            this.tabInformation.Location = new System.Drawing.Point(4, 22);
            this.tabInformation.Name = "tabInformation";
            this.tabInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tabInformation.Size = new System.Drawing.Size(1464, 538);
            this.tabInformation.TabIndex = 3;
            this.tabInformation.Text = "Datos Filiatorios";
            this.tabInformation.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(25, 226);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(90, 17);
            this.label27.TabIndex = 9;
            this.label27.Text = "Identificacion";
            // 
            // cidentifica
            // 
            this.cidentifica.AutoCompleteCustomSource.AddRange(new string[] {
            "Imputado",
            "Testigo"});
            this.cidentifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cidentifica.FormattingEnabled = true;
            this.cidentifica.Items.AddRange(new object[] {
            "Imputado",
            "Testigo"});
            this.cidentifica.Location = new System.Drawing.Point(130, 219);
            this.cidentifica.Name = "cidentifica";
            this.cidentifica.Size = new System.Drawing.Size(156, 24);
            this.cidentifica.TabIndex = 8;
            this.cidentifica.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // DNI
            // 
            this.DNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DNI.Location = new System.Drawing.Point(130, 99);
            this.DNI.Name = "DNI";
            this.DNI.Size = new System.Drawing.Size(212, 23);
            this.DNI.TabIndex = 7;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(26, 105);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(79, 17);
            this.label26.TabIndex = 6;
            this.label26.Text = "DNI            ";
            // 
            // nombres
            // 
            this.nombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombres.Location = new System.Drawing.Point(130, 58);
            this.nombres.Name = "nombres";
            this.nombres.Size = new System.Drawing.Size(631, 23);
            this.nombres.TabIndex = 5;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(26, 60);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(85, 17);
            this.label25.TabIndex = 4;
            this.label25.Text = "Nombres     ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rFemenino);
            this.groupBox2.Controls.Add(this.rMasculino);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(130, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(489, 58);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sexo";
            // 
            // rFemenino
            // 
            this.rFemenino.AutoSize = true;
            this.rFemenino.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rFemenino.Location = new System.Drawing.Point(59, 25);
            this.rFemenino.Name = "rFemenino";
            this.rFemenino.Size = new System.Drawing.Size(88, 21);
            this.rFemenino.TabIndex = 1;
            this.rFemenino.TabStop = true;
            this.rFemenino.Text = "Femenino";
            this.rFemenino.UseVisualStyleBackColor = true;
            // 
            // rMasculino
            // 
            this.rMasculino.AutoSize = true;
            this.rMasculino.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rMasculino.Location = new System.Drawing.Point(213, 25);
            this.rMasculino.Name = "rMasculino";
            this.rMasculino.Size = new System.Drawing.Size(89, 21);
            this.rMasculino.TabIndex = 0;
            this.rMasculino.TabStop = true;
            this.rMasculino.Text = "Masculino";
            this.rMasculino.UseVisualStyleBackColor = true;
            // 
            // apellido
            // 
            this.apellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apellido.Location = new System.Drawing.Point(130, 22);
            this.apellido.Name = "apellido";
            this.apellido.Size = new System.Drawing.Size(631, 23);
            this.apellido.TabIndex = 2;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(26, 24);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(86, 17);
            this.label24.TabIndex = 1;
            this.label24.Text = "Apellido       ";
            // 
            // toolStripViewControls
            // 
            this.toolStripViewControls.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripViewControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSaveImage,
            this.tsbSaveRecord});
            this.toolStripViewControls.Location = new System.Drawing.Point(609, 257);
            this.toolStripViewControls.Name = "toolStripViewControls";
            this.toolStripViewControls.Size = new System.Drawing.Size(246, 25);
            this.toolStripViewControls.TabIndex = 10;
            this.toolStripViewControls.Text = "toolStrip2";
            // 
            // tsbSaveImage
            // 
            this.tsbSaveImage.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveImage.Image")));
            this.tsbSaveImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveImage.Name = "tsbSaveImage";
            this.tsbSaveImage.Size = new System.Drawing.Size(112, 22);
            this.tsbSaveImage.Text = "Guardar Imagen";
            // 
            // tsbSaveRecord
            // 
            this.tsbSaveRecord.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveRecord.Image")));
            this.tsbSaveRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveRecord.Name = "tsbSaveRecord";
            this.tsbSaveRecord.Size = new System.Drawing.Size(122, 22);
            this.tsbSaveRecord.Text = "Guardar Template";
            // 
            // tabFingers
            // 
            this.tabFingers.Controls.Add(this.tableLayoutPanel2);
            this.tabFingers.Location = new System.Drawing.Point(4, 22);
            this.tabFingers.Name = "tabFingers";
            this.tabFingers.Padding = new System.Windows.Forms.Padding(3);
            this.tabFingers.Size = new System.Drawing.Size(1464, 538);
            this.tabFingers.TabIndex = 1;
            this.tabFingers.Text = "Huellas Planas";
            this.tabFingers.ToolTipText = "Muestra las Huellas capturadas";
            this.tabFingers.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.label8, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.label7, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label10, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label11, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.label12, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.label13, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.chbShowOriginal, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel5, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel6, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel7, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel8, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel9, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.panel10, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.panel11, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.panel12, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.panel13, 4, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1458, 532);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1167, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(288, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Me�ique Izquierdo";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(876, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(285, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Anular Izquierdo";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(585, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(285, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Medio Izquierdo";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(294, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(285, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Indice Izquierdo";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(285, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Pulgar Izquierdo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 277);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(285, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Pulgar Derecho";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(294, 277);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(285, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Indice Derecho";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(585, 277);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(285, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Medio Derecho";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(876, 277);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(285, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Anular Derecho";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1167, 277);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(288, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "Me�ique Derecho";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chbShowOriginal
            // 
            this.chbShowOriginal.AutoSize = true;
            this.chbShowOriginal.Location = new System.Drawing.Point(3, 3);
            this.chbShowOriginal.Name = "chbShowOriginal";
            this.chbShowOriginal.Size = new System.Drawing.Size(125, 17);
            this.chbShowOriginal.TabIndex = 20;
            this.chbShowOriginal.Text = "Show original images";
            this.chbShowOriginal.UseVisualStyleBackColor = true;
            this.chbShowOriginal.CheckedChanged += new System.EventHandler(this.ChbShowOriginalCheckedChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.nfvLeftThumb);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 39);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(285, 235);
            this.panel4.TabIndex = 21;
            // 
            // nfvLeftThumb
            // 
            this.nfvLeftThumb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nfvLeftThumb.BackColor = System.Drawing.SystemColors.Control;
            this.nfvLeftThumb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nfvLeftThumb.BoundingRectColor = System.Drawing.Color.Red;
            this.nfvLeftThumb.Location = new System.Drawing.Point(0, 0);
            this.nfvLeftThumb.MinutiaColor = System.Drawing.Color.Red;
            this.nfvLeftThumb.Name = "nfvLeftThumb";
            this.nfvLeftThumb.NeighborMinutiaColor = System.Drawing.Color.Orange;
            this.nfvLeftThumb.ResultImageColor = System.Drawing.Color.Green;
            this.nfvLeftThumb.SelectedMinutiaColor = System.Drawing.Color.Magenta;
            this.nfvLeftThumb.SelectedSingularPointColor = System.Drawing.Color.Magenta;
            this.nfvLeftThumb.SingularPointColor = System.Drawing.Color.Red;
            this.nfvLeftThumb.Size = new System.Drawing.Size(285, 235);
            this.nfvLeftThumb.TabIndex = 10;
            this.nfvLeftThumb.TreeColor = System.Drawing.Color.Crimson;
            this.nfvLeftThumb.TreeMinutiaNumberDiplayFormat = Neurotec.Biometrics.Gui.MinutiaNumberDiplayFormat.DontDisplay;
            this.nfvLeftThumb.TreeMinutiaNumberFont = new System.Drawing.Font("Arial", 10F);
            this.nfvLeftThumb.TreeWidth = 2D;
            this.nfvLeftThumb.Paint += new System.Windows.Forms.PaintEventHandler(this.nfvLeftThumb_Paint);
            this.nfvLeftThumb.MouseEnter += new System.EventHandler(this.ViewMouseEnter);
            this.nfvLeftThumb.MouseLeave += new System.EventHandler(this.ViewMouseLeave);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.nfvLeftIndex);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(294, 39);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(285, 235);
            this.panel5.TabIndex = 22;
            // 
            // nfvLeftIndex
            // 
            this.nfvLeftIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nfvLeftIndex.BackColor = System.Drawing.SystemColors.Control;
            this.nfvLeftIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nfvLeftIndex.BoundingRectColor = System.Drawing.Color.Red;
            this.nfvLeftIndex.Location = new System.Drawing.Point(0, 0);
            this.nfvLeftIndex.MinutiaColor = System.Drawing.Color.Red;
            this.nfvLeftIndex.Name = "nfvLeftIndex";
            this.nfvLeftIndex.NeighborMinutiaColor = System.Drawing.Color.Orange;
            this.nfvLeftIndex.ResultImageColor = System.Drawing.Color.Green;
            this.nfvLeftIndex.SelectedMinutiaColor = System.Drawing.Color.Magenta;
            this.nfvLeftIndex.SelectedSingularPointColor = System.Drawing.Color.Magenta;
            this.nfvLeftIndex.SingularPointColor = System.Drawing.Color.Red;
            this.nfvLeftIndex.Size = new System.Drawing.Size(285, 235);
            this.nfvLeftIndex.TabIndex = 11;
            this.nfvLeftIndex.TreeColor = System.Drawing.Color.Crimson;
            this.nfvLeftIndex.TreeMinutiaNumberDiplayFormat = Neurotec.Biometrics.Gui.MinutiaNumberDiplayFormat.DontDisplay;
            this.nfvLeftIndex.TreeMinutiaNumberFont = new System.Drawing.Font("Arial", 10F);
            this.nfvLeftIndex.TreeWidth = 2D;
            this.nfvLeftIndex.MouseEnter += new System.EventHandler(this.ViewMouseEnter);
            this.nfvLeftIndex.MouseLeave += new System.EventHandler(this.ViewMouseLeave);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.nfvLeftMiddle);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(585, 39);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(285, 235);
            this.panel6.TabIndex = 23;
            // 
            // nfvLeftMiddle
            // 
            this.nfvLeftMiddle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nfvLeftMiddle.BackColor = System.Drawing.SystemColors.Control;
            this.nfvLeftMiddle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nfvLeftMiddle.BoundingRectColor = System.Drawing.Color.Red;
            this.nfvLeftMiddle.Location = new System.Drawing.Point(0, 0);
            this.nfvLeftMiddle.MinutiaColor = System.Drawing.Color.Red;
            this.nfvLeftMiddle.Name = "nfvLeftMiddle";
            this.nfvLeftMiddle.NeighborMinutiaColor = System.Drawing.Color.Orange;
            this.nfvLeftMiddle.ResultImageColor = System.Drawing.Color.Green;
            this.nfvLeftMiddle.SelectedMinutiaColor = System.Drawing.Color.Magenta;
            this.nfvLeftMiddle.SelectedSingularPointColor = System.Drawing.Color.Magenta;
            this.nfvLeftMiddle.SingularPointColor = System.Drawing.Color.Red;
            this.nfvLeftMiddle.Size = new System.Drawing.Size(285, 235);
            this.nfvLeftMiddle.TabIndex = 12;
            this.nfvLeftMiddle.TreeColor = System.Drawing.Color.Crimson;
            this.nfvLeftMiddle.TreeMinutiaNumberDiplayFormat = Neurotec.Biometrics.Gui.MinutiaNumberDiplayFormat.DontDisplay;
            this.nfvLeftMiddle.TreeMinutiaNumberFont = new System.Drawing.Font("Arial", 10F);
            this.nfvLeftMiddle.TreeWidth = 2D;
            this.nfvLeftMiddle.MouseEnter += new System.EventHandler(this.ViewMouseEnter);
            this.nfvLeftMiddle.MouseLeave += new System.EventHandler(this.ViewMouseLeave);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.nfvLeftRing);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(876, 39);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(285, 235);
            this.panel7.TabIndex = 24;
            // 
            // nfvLeftRing
            // 
            this.nfvLeftRing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nfvLeftRing.BackColor = System.Drawing.SystemColors.Control;
            this.nfvLeftRing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nfvLeftRing.BoundingRectColor = System.Drawing.Color.Red;
            this.nfvLeftRing.Location = new System.Drawing.Point(0, 0);
            this.nfvLeftRing.MinutiaColor = System.Drawing.Color.Red;
            this.nfvLeftRing.Name = "nfvLeftRing";
            this.nfvLeftRing.NeighborMinutiaColor = System.Drawing.Color.Orange;
            this.nfvLeftRing.ResultImageColor = System.Drawing.Color.Green;
            this.nfvLeftRing.SelectedMinutiaColor = System.Drawing.Color.Magenta;
            this.nfvLeftRing.SelectedSingularPointColor = System.Drawing.Color.Magenta;
            this.nfvLeftRing.SingularPointColor = System.Drawing.Color.Red;
            this.nfvLeftRing.Size = new System.Drawing.Size(285, 235);
            this.nfvLeftRing.TabIndex = 13;
            this.nfvLeftRing.TreeColor = System.Drawing.Color.Crimson;
            this.nfvLeftRing.TreeMinutiaNumberDiplayFormat = Neurotec.Biometrics.Gui.MinutiaNumberDiplayFormat.DontDisplay;
            this.nfvLeftRing.TreeMinutiaNumberFont = new System.Drawing.Font("Arial", 10F);
            this.nfvLeftRing.TreeWidth = 2D;
            this.nfvLeftRing.MouseEnter += new System.EventHandler(this.ViewMouseEnter);
            this.nfvLeftRing.MouseLeave += new System.EventHandler(this.ViewMouseLeave);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.nfvLeftLittle);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(1167, 39);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(288, 235);
            this.panel8.TabIndex = 25;
            // 
            // nfvLeftLittle
            // 
            this.nfvLeftLittle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nfvLeftLittle.BackColor = System.Drawing.SystemColors.Control;
            this.nfvLeftLittle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nfvLeftLittle.BoundingRectColor = System.Drawing.Color.Red;
            this.nfvLeftLittle.Location = new System.Drawing.Point(0, 0);
            this.nfvLeftLittle.MinutiaColor = System.Drawing.Color.Red;
            this.nfvLeftLittle.Name = "nfvLeftLittle";
            this.nfvLeftLittle.NeighborMinutiaColor = System.Drawing.Color.Orange;
            this.nfvLeftLittle.ResultImageColor = System.Drawing.Color.Green;
            this.nfvLeftLittle.SelectedMinutiaColor = System.Drawing.Color.Magenta;
            this.nfvLeftLittle.SelectedSingularPointColor = System.Drawing.Color.Magenta;
            this.nfvLeftLittle.SingularPointColor = System.Drawing.Color.Red;
            this.nfvLeftLittle.Size = new System.Drawing.Size(288, 235);
            this.nfvLeftLittle.TabIndex = 14;
            this.nfvLeftLittle.TreeColor = System.Drawing.Color.Crimson;
            this.nfvLeftLittle.TreeMinutiaNumberDiplayFormat = Neurotec.Biometrics.Gui.MinutiaNumberDiplayFormat.DontDisplay;
            this.nfvLeftLittle.TreeMinutiaNumberFont = new System.Drawing.Font("Arial", 10F);
            this.nfvLeftLittle.TreeWidth = 2D;
            this.nfvLeftLittle.MouseEnter += new System.EventHandler(this.ViewMouseEnter);
            this.nfvLeftLittle.MouseLeave += new System.EventHandler(this.ViewMouseLeave);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.nfvRightThumb);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(3, 293);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(285, 236);
            this.panel9.TabIndex = 26;
            // 
            // nfvRightThumb
            // 
            this.nfvRightThumb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nfvRightThumb.BackColor = System.Drawing.SystemColors.Control;
            this.nfvRightThumb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nfvRightThumb.BoundingRectColor = System.Drawing.Color.Red;
            this.nfvRightThumb.Location = new System.Drawing.Point(0, 0);
            this.nfvRightThumb.MinutiaColor = System.Drawing.Color.Red;
            this.nfvRightThumb.Name = "nfvRightThumb";
            this.nfvRightThumb.NeighborMinutiaColor = System.Drawing.Color.Orange;
            this.nfvRightThumb.ResultImageColor = System.Drawing.Color.Green;
            this.nfvRightThumb.SelectedMinutiaColor = System.Drawing.Color.Magenta;
            this.nfvRightThumb.SelectedSingularPointColor = System.Drawing.Color.Magenta;
            this.nfvRightThumb.SingularPointColor = System.Drawing.Color.Red;
            this.nfvRightThumb.Size = new System.Drawing.Size(285, 236);
            this.nfvRightThumb.TabIndex = 15;
            this.nfvRightThumb.TreeColor = System.Drawing.Color.Crimson;
            this.nfvRightThumb.TreeMinutiaNumberDiplayFormat = Neurotec.Biometrics.Gui.MinutiaNumberDiplayFormat.DontDisplay;
            this.nfvRightThumb.TreeMinutiaNumberFont = new System.Drawing.Font("Arial", 10F);
            this.nfvRightThumb.TreeWidth = 2D;
            this.nfvRightThumb.MouseEnter += new System.EventHandler(this.ViewMouseEnter);
            this.nfvRightThumb.MouseLeave += new System.EventHandler(this.ViewMouseLeave);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.nfvRightIndex);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(294, 293);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(285, 236);
            this.panel10.TabIndex = 27;
            // 
            // nfvRightIndex
            // 
            this.nfvRightIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nfvRightIndex.BackColor = System.Drawing.SystemColors.Control;
            this.nfvRightIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nfvRightIndex.BoundingRectColor = System.Drawing.Color.Red;
            this.nfvRightIndex.Location = new System.Drawing.Point(0, 0);
            this.nfvRightIndex.MinutiaColor = System.Drawing.Color.Red;
            this.nfvRightIndex.Name = "nfvRightIndex";
            this.nfvRightIndex.NeighborMinutiaColor = System.Drawing.Color.Orange;
            this.nfvRightIndex.ResultImageColor = System.Drawing.Color.Green;
            this.nfvRightIndex.SelectedMinutiaColor = System.Drawing.Color.Magenta;
            this.nfvRightIndex.SelectedSingularPointColor = System.Drawing.Color.Magenta;
            this.nfvRightIndex.SingularPointColor = System.Drawing.Color.Red;
            this.nfvRightIndex.Size = new System.Drawing.Size(285, 236);
            this.nfvRightIndex.TabIndex = 16;
            this.nfvRightIndex.TreeColor = System.Drawing.Color.Crimson;
            this.nfvRightIndex.TreeMinutiaNumberDiplayFormat = Neurotec.Biometrics.Gui.MinutiaNumberDiplayFormat.DontDisplay;
            this.nfvRightIndex.TreeMinutiaNumberFont = new System.Drawing.Font("Arial", 10F);
            this.nfvRightIndex.TreeWidth = 2D;
            this.nfvRightIndex.MouseEnter += new System.EventHandler(this.ViewMouseEnter);
            this.nfvRightIndex.MouseLeave += new System.EventHandler(this.ViewMouseLeave);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.nfvRightMiddle);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(585, 293);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(285, 236);
            this.panel11.TabIndex = 28;
            // 
            // nfvRightMiddle
            // 
            this.nfvRightMiddle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nfvRightMiddle.BackColor = System.Drawing.SystemColors.Control;
            this.nfvRightMiddle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nfvRightMiddle.BoundingRectColor = System.Drawing.Color.Red;
            this.nfvRightMiddle.Location = new System.Drawing.Point(0, 0);
            this.nfvRightMiddle.MinutiaColor = System.Drawing.Color.Red;
            this.nfvRightMiddle.Name = "nfvRightMiddle";
            this.nfvRightMiddle.NeighborMinutiaColor = System.Drawing.Color.Orange;
            this.nfvRightMiddle.ResultImageColor = System.Drawing.Color.Green;
            this.nfvRightMiddle.SelectedMinutiaColor = System.Drawing.Color.Magenta;
            this.nfvRightMiddle.SelectedSingularPointColor = System.Drawing.Color.Magenta;
            this.nfvRightMiddle.SingularPointColor = System.Drawing.Color.Red;
            this.nfvRightMiddle.Size = new System.Drawing.Size(285, 236);
            this.nfvRightMiddle.TabIndex = 17;
            this.nfvRightMiddle.TreeColor = System.Drawing.Color.Crimson;
            this.nfvRightMiddle.TreeMinutiaNumberDiplayFormat = Neurotec.Biometrics.Gui.MinutiaNumberDiplayFormat.DontDisplay;
            this.nfvRightMiddle.TreeMinutiaNumberFont = new System.Drawing.Font("Arial", 10F);
            this.nfvRightMiddle.TreeWidth = 2D;
            this.nfvRightMiddle.MouseEnter += new System.EventHandler(this.ViewMouseEnter);
            this.nfvRightMiddle.MouseLeave += new System.EventHandler(this.ViewMouseLeave);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.nfvRightRing);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(876, 293);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(285, 236);
            this.panel12.TabIndex = 29;
            // 
            // nfvRightRing
            // 
            this.nfvRightRing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nfvRightRing.BackColor = System.Drawing.SystemColors.Control;
            this.nfvRightRing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nfvRightRing.BoundingRectColor = System.Drawing.Color.Red;
            this.nfvRightRing.Location = new System.Drawing.Point(0, 0);
            this.nfvRightRing.MinutiaColor = System.Drawing.Color.Red;
            this.nfvRightRing.Name = "nfvRightRing";
            this.nfvRightRing.NeighborMinutiaColor = System.Drawing.Color.Orange;
            this.nfvRightRing.ResultImageColor = System.Drawing.Color.Green;
            this.nfvRightRing.SelectedMinutiaColor = System.Drawing.Color.Magenta;
            this.nfvRightRing.SelectedSingularPointColor = System.Drawing.Color.Magenta;
            this.nfvRightRing.SingularPointColor = System.Drawing.Color.Red;
            this.nfvRightRing.Size = new System.Drawing.Size(285, 236);
            this.nfvRightRing.TabIndex = 18;
            this.nfvRightRing.TreeColor = System.Drawing.Color.Crimson;
            this.nfvRightRing.TreeMinutiaNumberDiplayFormat = Neurotec.Biometrics.Gui.MinutiaNumberDiplayFormat.DontDisplay;
            this.nfvRightRing.TreeMinutiaNumberFont = new System.Drawing.Font("Arial", 10F);
            this.nfvRightRing.TreeWidth = 2D;
            this.nfvRightRing.MouseEnter += new System.EventHandler(this.ViewMouseEnter);
            this.nfvRightRing.MouseLeave += new System.EventHandler(this.ViewMouseLeave);
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.nfvRightLittle);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(1167, 293);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(288, 236);
            this.panel13.TabIndex = 30;
            // 
            // nfvRightLittle
            // 
            this.nfvRightLittle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nfvRightLittle.BackColor = System.Drawing.SystemColors.Control;
            this.nfvRightLittle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nfvRightLittle.BoundingRectColor = System.Drawing.Color.Red;
            this.nfvRightLittle.Location = new System.Drawing.Point(0, 0);
            this.nfvRightLittle.MinutiaColor = System.Drawing.Color.Red;
            this.nfvRightLittle.Name = "nfvRightLittle";
            this.nfvRightLittle.NeighborMinutiaColor = System.Drawing.Color.Orange;
            this.nfvRightLittle.ResultImageColor = System.Drawing.Color.Green;
            this.nfvRightLittle.SelectedMinutiaColor = System.Drawing.Color.Magenta;
            this.nfvRightLittle.SelectedSingularPointColor = System.Drawing.Color.Magenta;
            this.nfvRightLittle.SingularPointColor = System.Drawing.Color.Red;
            this.nfvRightLittle.Size = new System.Drawing.Size(288, 236);
            this.nfvRightLittle.TabIndex = 19;
            this.nfvRightLittle.TreeColor = System.Drawing.Color.Crimson;
            this.nfvRightLittle.TreeMinutiaNumberDiplayFormat = Neurotec.Biometrics.Gui.MinutiaNumberDiplayFormat.DontDisplay;
            this.nfvRightLittle.TreeMinutiaNumberFont = new System.Drawing.Font("Arial", 10F);
            this.nfvRightLittle.TreeWidth = 2D;
            this.nfvRightLittle.MouseEnter += new System.EventHandler(this.ViewMouseEnter);
            this.nfvRightLittle.MouseLeave += new System.EventHandler(this.ViewMouseLeave);
            // 
            // tabRolled
            // 
            this.tabRolled.Controls.Add(this.tableLayoutPanel3);
            this.tabRolled.Location = new System.Drawing.Point(4, 22);
            this.tabRolled.Name = "tabRolled";
            this.tabRolled.Padding = new System.Windows.Forms.Padding(3);
            this.tabRolled.Size = new System.Drawing.Size(1464, 538);
            this.tabRolled.TabIndex = 2;
            this.tabRolled.Text = "Huellas Rodadas";
            this.tabRolled.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.label14, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.label15, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.label16, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.label17, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label18, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label19, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label20, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label21, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.label22, 3, 3);
            this.tableLayoutPanel3.Controls.Add(this.label23, 4, 3);
            this.tableLayoutPanel3.Controls.Add(this.chbShowOriginalRolled, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel14, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.panel15, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.panel16, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.panel17, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.panel18, 4, 2);
            this.tableLayoutPanel3.Controls.Add(this.panel19, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.panel20, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.panel21, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.panel22, 3, 4);
            this.tableLayoutPanel3.Controls.Add(this.panel23, 4, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1458, 532);
            this.tableLayoutPanel3.TabIndex = 1;
            this.tableLayoutPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel3_Paint);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(1167, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(288, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Me�ique Izquierdo";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(876, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(285, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "Anular Izquierdo";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(585, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(285, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Medio Izquierdo";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(294, 23);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(285, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "Indice Izquierdo";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(3, 23);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(285, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Pulgar Izquierdo";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(3, 277);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(285, 13);
            this.label19.TabIndex = 5;
            this.label19.Text = "Pulgar Derecho";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(294, 277);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(285, 13);
            this.label20.TabIndex = 6;
            this.label20.Text = "Indice Derecho";
            this.label20.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(585, 277);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(285, 13);
            this.label21.TabIndex = 7;
            this.label21.Text = "Medio Derecho";
            this.label21.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(876, 277);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(285, 13);
            this.label22.TabIndex = 8;
            this.label22.Text = "Anular Derecho";
            this.label22.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(1167, 277);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(288, 13);
            this.label23.TabIndex = 9;
            this.label23.Text = "Me�ique Derecho";
            this.label23.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chbShowOriginalRolled
            // 
            this.chbShowOriginalRolled.AutoSize = true;
            this.chbShowOriginalRolled.Location = new System.Drawing.Point(3, 3);
            this.chbShowOriginalRolled.Name = "chbShowOriginalRolled";
            this.chbShowOriginalRolled.Size = new System.Drawing.Size(125, 17);
            this.chbShowOriginalRolled.TabIndex = 20;
            this.chbShowOriginalRolled.Text = "Show original images";
            this.chbShowOriginalRolled.UseVisualStyleBackColor = true;
            this.chbShowOriginalRolled.CheckedChanged += new System.EventHandler(this.ChbShowOriginalCheckedChanged);
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.nfvLeftThumbRolled);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(3, 39);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(285, 235);
            this.panel14.TabIndex = 21;
            // 
            // nfvLeftThumbRolled
            // 
            this.nfvLeftThumbRolled.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nfvLeftThumbRolled.BackColor = System.Drawing.SystemColors.Control;
            this.nfvLeftThumbRolled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nfvLeftThumbRolled.BoundingRectColor = System.Drawing.Color.Red;
            this.nfvLeftThumbRolled.Location = new System.Drawing.Point(0, 0);
            this.nfvLeftThumbRolled.MinutiaColor = System.Drawing.Color.Red;
            this.nfvLeftThumbRolled.Name = "nfvLeftThumbRolled";
            this.nfvLeftThumbRolled.NeighborMinutiaColor = System.Drawing.Color.Orange;
            this.nfvLeftThumbRolled.ResultImageColor = System.Drawing.Color.Green;
            this.nfvLeftThumbRolled.SelectedMinutiaColor = System.Drawing.Color.Magenta;
            this.nfvLeftThumbRolled.SelectedSingularPointColor = System.Drawing.Color.Magenta;
            this.nfvLeftThumbRolled.SingularPointColor = System.Drawing.Color.Red;
            this.nfvLeftThumbRolled.Size = new System.Drawing.Size(193, 235);
            this.nfvLeftThumbRolled.TabIndex = 10;
            this.nfvLeftThumbRolled.TreeColor = System.Drawing.Color.Crimson;
            this.nfvLeftThumbRolled.TreeMinutiaNumberDiplayFormat = Neurotec.Biometrics.Gui.MinutiaNumberDiplayFormat.DontDisplay;
            this.nfvLeftThumbRolled.TreeMinutiaNumberFont = new System.Drawing.Font("Arial", 10F);
            this.nfvLeftThumbRolled.TreeWidth = 2D;
            this.nfvLeftThumbRolled.MouseEnter += new System.EventHandler(this.ViewMouseEnter);
            this.nfvLeftThumbRolled.MouseLeave += new System.EventHandler(this.ViewMouseLeave);
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.nfvLeftIndexRolled);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(294, 39);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(285, 235);
            this.panel15.TabIndex = 22;
            // 
            // nfvLeftIndexRolled
            // 
            this.nfvLeftIndexRolled.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nfvLeftIndexRolled.BackColor = System.Drawing.SystemColors.Control;
            this.nfvLeftIndexRolled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nfvLeftIndexRolled.BoundingRectColor = System.Drawing.Color.Red;
            this.nfvLeftIndexRolled.Location = new System.Drawing.Point(0, 0);
            this.nfvLeftIndexRolled.MinutiaColor = System.Drawing.Color.Red;
            this.nfvLeftIndexRolled.Name = "nfvLeftIndexRolled";
            this.nfvLeftIndexRolled.NeighborMinutiaColor = System.Drawing.Color.Orange;
            this.nfvLeftIndexRolled.ResultImageColor = System.Drawing.Color.Green;
            this.nfvLeftIndexRolled.SelectedMinutiaColor = System.Drawing.Color.Magenta;
            this.nfvLeftIndexRolled.SelectedSingularPointColor = System.Drawing.Color.Magenta;
            this.nfvLeftIndexRolled.SingularPointColor = System.Drawing.Color.Red;
            this.nfvLeftIndexRolled.Size = new System.Drawing.Size(193, 235);
            this.nfvLeftIndexRolled.TabIndex = 11;
            this.nfvLeftIndexRolled.TreeColor = System.Drawing.Color.Crimson;
            this.nfvLeftIndexRolled.TreeMinutiaNumberDiplayFormat = Neurotec.Biometrics.Gui.MinutiaNumberDiplayFormat.DontDisplay;
            this.nfvLeftIndexRolled.TreeMinutiaNumberFont = new System.Drawing.Font("Arial", 10F);
            this.nfvLeftIndexRolled.TreeWidth = 2D;
            this.nfvLeftIndexRolled.MouseEnter += new System.EventHandler(this.ViewMouseEnter);
            this.nfvLeftIndexRolled.MouseLeave += new System.EventHandler(this.ViewMouseLeave);
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.nfvLeftMiddleRolled);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel16.Location = new System.Drawing.Point(585, 39);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(285, 235);
            this.panel16.TabIndex = 23;
            // 
            // nfvLeftMiddleRolled
            // 
            this.nfvLeftMiddleRolled.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nfvLeftMiddleRolled.BackColor = System.Drawing.SystemColors.Control;
            this.nfvLeftMiddleRolled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nfvLeftMiddleRolled.BoundingRectColor = System.Drawing.Color.Red;
            this.nfvLeftMiddleRolled.Location = new System.Drawing.Point(0, 0);
            this.nfvLeftMiddleRolled.MinutiaColor = System.Drawing.Color.Red;
            this.nfvLeftMiddleRolled.Name = "nfvLeftMiddleRolled";
            this.nfvLeftMiddleRolled.NeighborMinutiaColor = System.Drawing.Color.Orange;
            this.nfvLeftMiddleRolled.ResultImageColor = System.Drawing.Color.Green;
            this.nfvLeftMiddleRolled.SelectedMinutiaColor = System.Drawing.Color.Magenta;
            this.nfvLeftMiddleRolled.SelectedSingularPointColor = System.Drawing.Color.Magenta;
            this.nfvLeftMiddleRolled.SingularPointColor = System.Drawing.Color.Red;
            this.nfvLeftMiddleRolled.Size = new System.Drawing.Size(193, 235);
            this.nfvLeftMiddleRolled.TabIndex = 12;
            this.nfvLeftMiddleRolled.TreeColor = System.Drawing.Color.Crimson;
            this.nfvLeftMiddleRolled.TreeMinutiaNumberDiplayFormat = Neurotec.Biometrics.Gui.MinutiaNumberDiplayFormat.DontDisplay;
            this.nfvLeftMiddleRolled.TreeMinutiaNumberFont = new System.Drawing.Font("Arial", 10F);
            this.nfvLeftMiddleRolled.TreeWidth = 2D;
            this.nfvLeftMiddleRolled.MouseEnter += new System.EventHandler(this.ViewMouseEnter);
            this.nfvLeftMiddleRolled.MouseLeave += new System.EventHandler(this.ViewMouseLeave);
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.nfvLeftRingRolled);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel17.Location = new System.Drawing.Point(876, 39);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(285, 235);
            this.panel17.TabIndex = 24;
            // 
            // nfvLeftRingRolled
            // 
            this.nfvLeftRingRolled.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nfvLeftRingRolled.BackColor = System.Drawing.SystemColors.Control;
            this.nfvLeftRingRolled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nfvLeftRingRolled.BoundingRectColor = System.Drawing.Color.Red;
            this.nfvLeftRingRolled.Location = new System.Drawing.Point(0, 0);
            this.nfvLeftRingRolled.MinutiaColor = System.Drawing.Color.Red;
            this.nfvLeftRingRolled.Name = "nfvLeftRingRolled";
            this.nfvLeftRingRolled.NeighborMinutiaColor = System.Drawing.Color.Orange;
            this.nfvLeftRingRolled.ResultImageColor = System.Drawing.Color.Green;
            this.nfvLeftRingRolled.SelectedMinutiaColor = System.Drawing.Color.Magenta;
            this.nfvLeftRingRolled.SelectedSingularPointColor = System.Drawing.Color.Magenta;
            this.nfvLeftRingRolled.SingularPointColor = System.Drawing.Color.Red;
            this.nfvLeftRingRolled.Size = new System.Drawing.Size(193, 235);
            this.nfvLeftRingRolled.TabIndex = 13;
            this.nfvLeftRingRolled.TreeColor = System.Drawing.Color.Crimson;
            this.nfvLeftRingRolled.TreeMinutiaNumberDiplayFormat = Neurotec.Biometrics.Gui.MinutiaNumberDiplayFormat.DontDisplay;
            this.nfvLeftRingRolled.TreeMinutiaNumberFont = new System.Drawing.Font("Arial", 10F);
            this.nfvLeftRingRolled.TreeWidth = 2D;
            this.nfvLeftRingRolled.MouseEnter += new System.EventHandler(this.ViewMouseEnter);
            this.nfvLeftRingRolled.MouseLeave += new System.EventHandler(this.ViewMouseLeave);
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.nfvLeftLittleRolled);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel18.Location = new System.Drawing.Point(1167, 39);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(288, 235);
            this.panel18.TabIndex = 25;
            // 
            // nfvLeftLittleRolled
            // 
            this.nfvLeftLittleRolled.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nfvLeftLittleRolled.BackColor = System.Drawing.SystemColors.Control;
            this.nfvLeftLittleRolled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nfvLeftLittleRolled.BoundingRectColor = System.Drawing.Color.Red;
            this.nfvLeftLittleRolled.Location = new System.Drawing.Point(0, 0);
            this.nfvLeftLittleRolled.MinutiaColor = System.Drawing.Color.Red;
            this.nfvLeftLittleRolled.Name = "nfvLeftLittleRolled";
            this.nfvLeftLittleRolled.NeighborMinutiaColor = System.Drawing.Color.Orange;
            this.nfvLeftLittleRolled.ResultImageColor = System.Drawing.Color.Green;
            this.nfvLeftLittleRolled.SelectedMinutiaColor = System.Drawing.Color.Magenta;
            this.nfvLeftLittleRolled.SelectedSingularPointColor = System.Drawing.Color.Magenta;
            this.nfvLeftLittleRolled.SingularPointColor = System.Drawing.Color.Red;
            this.nfvLeftLittleRolled.Size = new System.Drawing.Size(195, 235);
            this.nfvLeftLittleRolled.TabIndex = 14;
            this.nfvLeftLittleRolled.TreeColor = System.Drawing.Color.Crimson;
            this.nfvLeftLittleRolled.TreeMinutiaNumberDiplayFormat = Neurotec.Biometrics.Gui.MinutiaNumberDiplayFormat.DontDisplay;
            this.nfvLeftLittleRolled.TreeMinutiaNumberFont = new System.Drawing.Font("Arial", 10F);
            this.nfvLeftLittleRolled.TreeWidth = 2D;
            this.nfvLeftLittleRolled.MouseEnter += new System.EventHandler(this.ViewMouseEnter);
            this.nfvLeftLittleRolled.MouseLeave += new System.EventHandler(this.ViewMouseLeave);
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.nfvRightThumbRolled);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel19.Location = new System.Drawing.Point(3, 293);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(285, 236);
            this.panel19.TabIndex = 26;
            // 
            // nfvRightThumbRolled
            // 
            this.nfvRightThumbRolled.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nfvRightThumbRolled.BackColor = System.Drawing.SystemColors.Control;
            this.nfvRightThumbRolled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nfvRightThumbRolled.BoundingRectColor = System.Drawing.Color.Red;
            this.nfvRightThumbRolled.Location = new System.Drawing.Point(0, 0);
            this.nfvRightThumbRolled.MinutiaColor = System.Drawing.Color.Red;
            this.nfvRightThumbRolled.Name = "nfvRightThumbRolled";
            this.nfvRightThumbRolled.NeighborMinutiaColor = System.Drawing.Color.Orange;
            this.nfvRightThumbRolled.ResultImageColor = System.Drawing.Color.Green;
            this.nfvRightThumbRolled.SelectedMinutiaColor = System.Drawing.Color.Magenta;
            this.nfvRightThumbRolled.SelectedSingularPointColor = System.Drawing.Color.Magenta;
            this.nfvRightThumbRolled.SingularPointColor = System.Drawing.Color.Red;
            this.nfvRightThumbRolled.Size = new System.Drawing.Size(193, 236);
            this.nfvRightThumbRolled.TabIndex = 15;
            this.nfvRightThumbRolled.TreeColor = System.Drawing.Color.Crimson;
            this.nfvRightThumbRolled.TreeMinutiaNumberDiplayFormat = Neurotec.Biometrics.Gui.MinutiaNumberDiplayFormat.DontDisplay;
            this.nfvRightThumbRolled.TreeMinutiaNumberFont = new System.Drawing.Font("Arial", 10F);
            this.nfvRightThumbRolled.TreeWidth = 2D;
            this.nfvRightThumbRolled.MouseEnter += new System.EventHandler(this.ViewMouseEnter);
            this.nfvRightThumbRolled.MouseLeave += new System.EventHandler(this.ViewMouseLeave);
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.nfvRightIndexRolled);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel20.Location = new System.Drawing.Point(294, 293);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(285, 236);
            this.panel20.TabIndex = 27;
            // 
            // nfvRightIndexRolled
            // 
            this.nfvRightIndexRolled.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nfvRightIndexRolled.BackColor = System.Drawing.SystemColors.Control;
            this.nfvRightIndexRolled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nfvRightIndexRolled.BoundingRectColor = System.Drawing.Color.Red;
            this.nfvRightIndexRolled.Location = new System.Drawing.Point(0, 0);
            this.nfvRightIndexRolled.MinutiaColor = System.Drawing.Color.Red;
            this.nfvRightIndexRolled.Name = "nfvRightIndexRolled";
            this.nfvRightIndexRolled.NeighborMinutiaColor = System.Drawing.Color.Orange;
            this.nfvRightIndexRolled.ResultImageColor = System.Drawing.Color.Green;
            this.nfvRightIndexRolled.SelectedMinutiaColor = System.Drawing.Color.Magenta;
            this.nfvRightIndexRolled.SelectedSingularPointColor = System.Drawing.Color.Magenta;
            this.nfvRightIndexRolled.SingularPointColor = System.Drawing.Color.Red;
            this.nfvRightIndexRolled.Size = new System.Drawing.Size(193, 236);
            this.nfvRightIndexRolled.TabIndex = 16;
            this.nfvRightIndexRolled.TreeColor = System.Drawing.Color.Crimson;
            this.nfvRightIndexRolled.TreeMinutiaNumberDiplayFormat = Neurotec.Biometrics.Gui.MinutiaNumberDiplayFormat.DontDisplay;
            this.nfvRightIndexRolled.TreeMinutiaNumberFont = new System.Drawing.Font("Arial", 10F);
            this.nfvRightIndexRolled.TreeWidth = 2D;
            this.nfvRightIndexRolled.MouseEnter += new System.EventHandler(this.ViewMouseEnter);
            this.nfvRightIndexRolled.MouseLeave += new System.EventHandler(this.ViewMouseLeave);
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.nfvRightMiddleRolled);
            this.panel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel21.Location = new System.Drawing.Point(585, 293);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(285, 236);
            this.panel21.TabIndex = 28;
            // 
            // nfvRightMiddleRolled
            // 
            this.nfvRightMiddleRolled.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nfvRightMiddleRolled.BackColor = System.Drawing.SystemColors.Control;
            this.nfvRightMiddleRolled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nfvRightMiddleRolled.BoundingRectColor = System.Drawing.Color.Red;
            this.nfvRightMiddleRolled.Location = new System.Drawing.Point(0, 0);
            this.nfvRightMiddleRolled.MinutiaColor = System.Drawing.Color.Red;
            this.nfvRightMiddleRolled.Name = "nfvRightMiddleRolled";
            this.nfvRightMiddleRolled.NeighborMinutiaColor = System.Drawing.Color.Orange;
            this.nfvRightMiddleRolled.ResultImageColor = System.Drawing.Color.Green;
            this.nfvRightMiddleRolled.SelectedMinutiaColor = System.Drawing.Color.Magenta;
            this.nfvRightMiddleRolled.SelectedSingularPointColor = System.Drawing.Color.Magenta;
            this.nfvRightMiddleRolled.SingularPointColor = System.Drawing.Color.Red;
            this.nfvRightMiddleRolled.Size = new System.Drawing.Size(193, 236);
            this.nfvRightMiddleRolled.TabIndex = 17;
            this.nfvRightMiddleRolled.TreeColor = System.Drawing.Color.Crimson;
            this.nfvRightMiddleRolled.TreeMinutiaNumberDiplayFormat = Neurotec.Biometrics.Gui.MinutiaNumberDiplayFormat.DontDisplay;
            this.nfvRightMiddleRolled.TreeMinutiaNumberFont = new System.Drawing.Font("Arial", 10F);
            this.nfvRightMiddleRolled.TreeWidth = 2D;
            this.nfvRightMiddleRolled.MouseEnter += new System.EventHandler(this.ViewMouseEnter);
            this.nfvRightMiddleRolled.MouseLeave += new System.EventHandler(this.ViewMouseLeave);
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.nfvRightRingRolled);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel22.Location = new System.Drawing.Point(876, 293);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(285, 236);
            this.panel22.TabIndex = 29;
            // 
            // nfvRightRingRolled
            // 
            this.nfvRightRingRolled.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nfvRightRingRolled.BackColor = System.Drawing.SystemColors.Control;
            this.nfvRightRingRolled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nfvRightRingRolled.BoundingRectColor = System.Drawing.Color.Red;
            this.nfvRightRingRolled.Location = new System.Drawing.Point(0, 0);
            this.nfvRightRingRolled.MinutiaColor = System.Drawing.Color.Red;
            this.nfvRightRingRolled.Name = "nfvRightRingRolled";
            this.nfvRightRingRolled.NeighborMinutiaColor = System.Drawing.Color.Orange;
            this.nfvRightRingRolled.ResultImageColor = System.Drawing.Color.Green;
            this.nfvRightRingRolled.SelectedMinutiaColor = System.Drawing.Color.Magenta;
            this.nfvRightRingRolled.SelectedSingularPointColor = System.Drawing.Color.Magenta;
            this.nfvRightRingRolled.SingularPointColor = System.Drawing.Color.Red;
            this.nfvRightRingRolled.Size = new System.Drawing.Size(193, 236);
            this.nfvRightRingRolled.TabIndex = 18;
            this.nfvRightRingRolled.TreeColor = System.Drawing.Color.Crimson;
            this.nfvRightRingRolled.TreeMinutiaNumberDiplayFormat = Neurotec.Biometrics.Gui.MinutiaNumberDiplayFormat.DontDisplay;
            this.nfvRightRingRolled.TreeMinutiaNumberFont = new System.Drawing.Font("Arial", 10F);
            this.nfvRightRingRolled.TreeWidth = 2D;
            this.nfvRightRingRolled.MouseEnter += new System.EventHandler(this.ViewMouseEnter);
            this.nfvRightRingRolled.MouseLeave += new System.EventHandler(this.ViewMouseLeave);
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.nfvRightLittleRolled);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel23.Location = new System.Drawing.Point(1167, 293);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(288, 236);
            this.panel23.TabIndex = 30;
            // 
            // nfvRightLittleRolled
            // 
            this.nfvRightLittleRolled.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nfvRightLittleRolled.BackColor = System.Drawing.SystemColors.Control;
            this.nfvRightLittleRolled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nfvRightLittleRolled.BoundingRectColor = System.Drawing.Color.Red;
            this.nfvRightLittleRolled.Location = new System.Drawing.Point(0, 0);
            this.nfvRightLittleRolled.MinutiaColor = System.Drawing.Color.Red;
            this.nfvRightLittleRolled.Name = "nfvRightLittleRolled";
            this.nfvRightLittleRolled.NeighborMinutiaColor = System.Drawing.Color.Orange;
            this.nfvRightLittleRolled.ResultImageColor = System.Drawing.Color.Green;
            this.nfvRightLittleRolled.SelectedMinutiaColor = System.Drawing.Color.Magenta;
            this.nfvRightLittleRolled.SelectedSingularPointColor = System.Drawing.Color.Magenta;
            this.nfvRightLittleRolled.SingularPointColor = System.Drawing.Color.Red;
            this.nfvRightLittleRolled.Size = new System.Drawing.Size(195, 236);
            this.nfvRightLittleRolled.TabIndex = 19;
            this.nfvRightLittleRolled.TreeColor = System.Drawing.Color.Crimson;
            this.nfvRightLittleRolled.TreeMinutiaNumberDiplayFormat = Neurotec.Biometrics.Gui.MinutiaNumberDiplayFormat.DontDisplay;
            this.nfvRightLittleRolled.TreeMinutiaNumberFont = new System.Drawing.Font("Arial", 10F);
            this.nfvRightLittleRolled.TreeWidth = 2D;
            this.nfvRightLittleRolled.MouseEnter += new System.EventHandler(this.ViewMouseEnter);
            this.nfvRightLittleRolled.MouseLeave += new System.EventHandler(this.ViewMouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ambos Pulgares";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 302);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Verificar Identidad";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fSelector
            // 
            this.fSelector.AllowHighlight = true;
            this.fSelector.IsRolled = false;
            this.fSelector.Location = new System.Drawing.Point(13, 19);
            this.fSelector.MissingPositions = new Neurotec.Biometrics.NFPosition[0];
            this.fSelector.Name = "fSelector";
            this.fSelector.SelectedPosition = Neurotec.Biometrics.NFPosition.Unknown;
            this.fSelector.Size = new System.Drawing.Size(227, 103);
            this.fSelector.TabIndex = 0;
            this.fSelector.FingerClick += new System.EventHandler<Capturer.Controls.FingerSelector.FingerClickArgs>(this.FingerSelectorFingerClick);
            // 
            // infoPanel
            // 
            this.infoPanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.infoPanel.DeviceManager = null;
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoPanel.Location = new System.Drawing.Point(3, 3);
            this.infoPanel.Model = null;
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(1458, 532);
            this.infoPanel.TabIndex = 0;
            // 

            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 730);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(250, 250);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reconocimiento biometrico de Huellas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.Resize += new System.EventHandler(this.MainFormResize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbFingerSelector.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabInformation.ResumeLayout(false);
            this.tabInformation.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStripViewControls.ResumeLayout(false);
            this.toolStripViewControls.PerformLayout();
            this.tabFingers.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.tabRolled.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private FingerSelector fSelector;
        private System.Windows.Forms.Button btnStartCapturing;
        private System.Windows.Forms.CheckBox chbCaptureRolled;
        private System.Windows.Forms.CheckBox chbCaptureSlaps;
        private System.Windows.Forms.GroupBox gbFingerSelector;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabFingers;
        private System.Windows.Forms.TabPage tabRolled;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private Neurotec.Biometrics.Gui.NFingerView nfvRightRing;
        private Neurotec.Biometrics.Gui.NFingerView nfvRightMiddle;
        private Neurotec.Biometrics.Gui.NFingerView nfvRightIndex;
        private Neurotec.Biometrics.Gui.NFingerView nfvRightThumb;
        private Neurotec.Biometrics.Gui.NFingerView nfvLeftLittle;
        private Neurotec.Biometrics.Gui.NFingerView nfvLeftRing;
        private Neurotec.Biometrics.Gui.NFingerView nfvLeftMiddle;
        private Neurotec.Biometrics.Gui.NFingerView nfvLeftIndex;
        private Neurotec.Biometrics.Gui.NFingerView nfvLeftThumb;
        private Neurotec.Biometrics.Gui.NFingerView nfvRightLittle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chbCapturePlainFingers;
        private System.Windows.Forms.CheckBox chbShowOriginal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Neurotec.Biometrics.Gui.NFingerView nfvRightLittleRolled;
        private Neurotec.Biometrics.Gui.NFingerView nfvRightRingRolled;
        private Neurotec.Biometrics.Gui.NFingerView nfvRightMiddleRolled;
        private Neurotec.Biometrics.Gui.NFingerView nfvRightIndexRolled;
        private Neurotec.Biometrics.Gui.NFingerView nfvRightThumbRolled;
        private Neurotec.Biometrics.Gui.NFingerView nfvLeftLittleRolled;
        private Neurotec.Biometrics.Gui.NFingerView nfvLeftRingRolled;
        private Neurotec.Biometrics.Gui.NFingerView nfvLeftMiddleRolled;
        private Neurotec.Biometrics.Gui.NFingerView nfvLeftIndexRolled;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private Neurotec.Biometrics.Gui.NFingerView nfvLeftThumbRolled;
        private System.Windows.Forms.CheckBox chbShowOriginalRolled;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.Panel panel23;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeScannerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabPage tabInformation;
        private InfoPanel infoPanel;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editRequiredInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeconntionSettingsToolStripMenuItem;
        private Neurotec.Biometrics.Gui.NFingerView nfvThumbs;
        private Neurotec.Biometrics.Gui.NFingerView nfvRightFour;
        private System.Windows.Forms.TextBox DNI;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox nombres;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox apellido;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox cidentifica;
        private System.Windows.Forms.RadioButton rFemenino;
        private System.Windows.Forms.RadioButton rMasculino;
        protected internal Neurotec.Biometrics.Gui.NFingerView nfvLeftFour;
        private System.Windows.Forms.ToolStrip toolStripViewControls;
        private System.Windows.Forms.ToolStripButton tsbSaveImage;
        private System.Windows.Forms.ToolStripButton tsbSaveRecord;
        private System.Windows.Forms.Button bSalvar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label resultadoRNR;
        private System.Windows.Forms.Label scoreRNR;
        private System.Windows.Forms.Label ApyNomRNR;
        private System.Windows.Forms.Label DNIRNR;
        private System.Windows.Forms.Label RESULTADO;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bconsultaR;

    }
}

