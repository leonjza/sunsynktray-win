namespace SunSynkTray
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuIOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxCredentials = new System.Windows.Forms.GroupBox();
            this.buttonSetCredentials = new System.Windows.Forms.Button();
            this.maskedTextBoxPassword = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelWebStatus = new System.Windows.Forms.Label();
            this.groupBoxPlants = new System.Windows.Forms.GroupBox();
            this.listBoxPlants = new System.Windows.Forms.ListBox();
            this.labelPlantStatus = new System.Windows.Forms.Label();
            this.timerCallApi = new System.Windows.Forms.Timer(this.components);
            this.labelInterval = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.contextMenuStrip.SuspendLayout();
            this.groupBoxCredentials.SuspendLayout();
            this.groupBoxPlants.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.contextMenuStrip;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "SunSynkTray";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuIOpen,
            this.toolStripMenuExit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(117, 48);
            // 
            // toolStripMenuIOpen
            // 
            this.toolStripMenuIOpen.Name = "toolStripMenuIOpen";
            this.toolStripMenuIOpen.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuIOpen.Text = "Settings";
            this.toolStripMenuIOpen.ToolTipText = "Open SunSynkTray Settings";
            this.toolStripMenuIOpen.Click += new System.EventHandler(this.toolStripMenuIOpen_Click);
            // 
            // toolStripMenuExit
            // 
            this.toolStripMenuExit.Name = "toolStripMenuExit";
            this.toolStripMenuExit.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuExit.Text = "Exit";
            this.toolStripMenuExit.ToolTipText = "Exit SunSynkTray";
            this.toolStripMenuExit.Click += new System.EventHandler(this.toolStripMenuExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            // 
            // groupBoxCredentials
            // 
            this.groupBoxCredentials.Controls.Add(this.buttonSetCredentials);
            this.groupBoxCredentials.Controls.Add(this.maskedTextBoxPassword);
            this.groupBoxCredentials.Controls.Add(this.label2);
            this.groupBoxCredentials.Controls.Add(this.textBoxUsername);
            this.groupBoxCredentials.Controls.Add(this.label1);
            this.groupBoxCredentials.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCredentials.Name = "groupBoxCredentials";
            this.groupBoxCredentials.Size = new System.Drawing.Size(190, 132);
            this.groupBoxCredentials.TabIndex = 2;
            this.groupBoxCredentials.TabStop = false;
            this.groupBoxCredentials.Text = "SunSynk Credentials";
            // 
            // buttonSetCredentials
            // 
            this.buttonSetCredentials.Location = new System.Drawing.Point(67, 92);
            this.buttonSetCredentials.Name = "buttonSetCredentials";
            this.buttonSetCredentials.Size = new System.Drawing.Size(100, 23);
            this.buttonSetCredentials.TabIndex = 5;
            this.buttonSetCredentials.Text = "Get Plants";
            this.buttonSetCredentials.UseVisualStyleBackColor = true;
            this.buttonSetCredentials.Click += new System.EventHandler(this.buttonSetCredentials_Click);
            // 
            // maskedTextBoxPassword
            // 
            this.maskedTextBoxPassword.AsciiOnly = true;
            this.maskedTextBoxPassword.Location = new System.Drawing.Point(67, 55);
            this.maskedTextBoxPassword.Name = "maskedTextBoxPassword";
            this.maskedTextBoxPassword.PasswordChar = '*';
            this.maskedTextBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxPassword.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(67, 25);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(100, 20);
            this.textBoxUsername.TabIndex = 3;
            // 
            // labelWebStatus
            // 
            this.labelWebStatus.AutoSize = true;
            this.labelWebStatus.Location = new System.Drawing.Point(12, 147);
            this.labelWebStatus.Name = "labelWebStatus";
            this.labelWebStatus.Size = new System.Drawing.Size(82, 13);
            this.labelWebStatus.TabIndex = 3;
            this.labelWebStatus.Text = "labelWebStatus";
            this.labelWebStatus.Visible = false;
            // 
            // groupBoxPlants
            // 
            this.groupBoxPlants.Controls.Add(this.listBoxPlants);
            this.groupBoxPlants.Location = new System.Drawing.Point(208, 12);
            this.groupBoxPlants.Name = "groupBoxPlants";
            this.groupBoxPlants.Size = new System.Drawing.Size(337, 132);
            this.groupBoxPlants.TabIndex = 4;
            this.groupBoxPlants.TabStop = false;
            this.groupBoxPlants.Text = "Available Plants";
            // 
            // listBoxPlants
            // 
            this.listBoxPlants.FormattingEnabled = true;
            this.listBoxPlants.Location = new System.Drawing.Point(7, 20);
            this.listBoxPlants.Name = "listBoxPlants";
            this.listBoxPlants.Size = new System.Drawing.Size(322, 95);
            this.listBoxPlants.TabIndex = 0;
            this.listBoxPlants.Visible = false;
            this.listBoxPlants.SelectedIndexChanged += new System.EventHandler(this.listBoxPlants_SelectedIndexChanged);
            // 
            // labelPlantStatus
            // 
            this.labelPlantStatus.AutoSize = true;
            this.labelPlantStatus.Location = new System.Drawing.Point(12, 160);
            this.labelPlantStatus.Name = "labelPlantStatus";
            this.labelPlantStatus.Size = new System.Drawing.Size(83, 13);
            this.labelPlantStatus.TabIndex = 5;
            this.labelPlantStatus.Text = "labelPlantStatus";
            this.labelPlantStatus.Visible = false;
            // 
            // timerCallApi
            // 
            this.timerCallApi.Interval = 1000;
            this.timerCallApi.Tick += new System.EventHandler(this.timerCallApi_Tick);
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(512, 147);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(64, 13);
            this.labelInterval.TabIndex = 6;
            this.labelInterval.Text = "labelInterval";
            this.labelInterval.Visible = false;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(512, 160);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(64, 13);
            this.labelVersion.TabIndex = 7;
            this.labelVersion.Text = "labelVersion";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 180);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelInterval);
            this.Controls.Add(this.labelPlantStatus);
            this.Controls.Add(this.groupBoxPlants);
            this.Controls.Add(this.labelWebStatus);
            this.Controls.Add(this.groupBoxCredentials);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "SunSynkTray";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.groupBoxCredentials.ResumeLayout(false);
            this.groupBoxCredentials.PerformLayout();
            this.groupBoxPlants.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuIOpen;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxCredentials;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Button buttonSetCredentials;
        private System.Windows.Forms.Label labelWebStatus;
        private System.Windows.Forms.GroupBox groupBoxPlants;
        private System.Windows.Forms.ListBox listBoxPlants;
        private System.Windows.Forms.Label labelPlantStatus;
        private System.Windows.Forms.Timer timerCallApi;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.Label labelVersion;
    }
}

