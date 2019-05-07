namespace SMSHandlingApplication
{
    partial class SMSHandlingForm
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
            this.gbEMCDetails = new System.Windows.Forms.GroupBox();
            this.btnConnection = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.cmbTServerLinks = new System.Windows.Forms.ComboBox();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.lblLinks = new System.Windows.Forms.Label();
            this.lblServerPort = new System.Windows.Forms.Label();
            this.lblServerIP = new System.Windows.Forms.Label();
            this.gbMediaDirDetails = new System.Windows.Forms.GroupBox();
            this.btnMDConnection = new System.Windows.Forms.Button();
            this.txtMPPort = new System.Windows.Forms.TextBox();
            this.txtMPIP = new System.Windows.Forms.TextBox();
            this.txtMDPort = new System.Windows.Forms.TextBox();
            this.txtMDIP = new System.Windows.Forms.TextBox();
            this.lblMediaProxyPort = new System.Windows.Forms.Label();
            this.lblMediaProxyIP = new System.Windows.Forms.Label();
            this.lblMediaDirPort = new System.Windows.Forms.Label();
            this.lblMediaDirIP = new System.Windows.Forms.Label();
            this.gbAgentDetails = new System.Windows.Forms.GroupBox();
            this.btnMonitor = new System.Windows.Forms.Button();
            this.btnACW = new System.Windows.Forms.Button();
            this.btnAux = new System.Windows.Forms.Button();
            this.btnAvailable = new System.Windows.Forms.Button();
            this.btnLogInOut = new System.Windows.Forms.Button();
            this.txtStationID = new System.Windows.Forms.TextBox();
            this.txtAgentID = new System.Windows.Forms.TextBox();
            this.txtAgentPwd = new System.Windows.Forms.TextBox();
            this.lblAgentPwd = new System.Windows.Forms.Label();
            this.lblAgentID = new System.Windows.Forms.Label();
            this.lblStationID = new System.Windows.Forms.Label();
            this.rtbStatus = new System.Windows.Forms.RichTextBox();
            this.myToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.gbSMSHandling = new System.Windows.Forms.GroupBox();
            this.btnAcceptSMS = new System.Windows.Forms.Button();
            this.gbEMCDetails.SuspendLayout();
            this.gbMediaDirDetails.SuspendLayout();
            this.gbAgentDetails.SuspendLayout();
            this.gbSMSHandling.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEMCDetails
            // 
            this.gbEMCDetails.Controls.Add(this.btnConnection);
            this.gbEMCDetails.Controls.Add(this.btnBrowse);
            this.gbEMCDetails.Controls.Add(this.cmbTServerLinks);
            this.gbEMCDetails.Controls.Add(this.txtServerIP);
            this.gbEMCDetails.Controls.Add(this.txtServerPort);
            this.gbEMCDetails.Controls.Add(this.lblLinks);
            this.gbEMCDetails.Controls.Add(this.lblServerPort);
            this.gbEMCDetails.Controls.Add(this.lblServerIP);
            this.gbEMCDetails.Location = new System.Drawing.Point(12, 12);
            this.gbEMCDetails.Name = "gbEMCDetails";
            this.gbEMCDetails.Size = new System.Drawing.Size(411, 155);
            this.gbEMCDetails.TabIndex = 0;
            this.gbEMCDetails.TabStop = false;
            this.gbEMCDetails.Text = "EMC Details";
            // 
            // btnConnection
            // 
            this.btnConnection.Enabled = false;
            this.btnConnection.Location = new System.Drawing.Point(154, 115);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(75, 23);
            this.btnConnection.TabIndex = 4;
            this.btnConnection.Text = "Connect";
            this.myToolTip.SetToolTip(this.btnConnection, "Connect to XML Server");
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(315, 87);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(38, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "...";
            this.myToolTip.SetToolTip(this.btnBrowse, "Browse for available Links");
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // cmbTServerLinks
            // 
            this.cmbTServerLinks.FormattingEnabled = true;
            this.cmbTServerLinks.Location = new System.Drawing.Point(127, 87);
            this.cmbTServerLinks.Name = "cmbTServerLinks";
            this.cmbTServerLinks.Size = new System.Drawing.Size(182, 21);
            this.cmbTServerLinks.TabIndex = 3;
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(127, 33);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(182, 20);
            this.txtServerIP.TabIndex = 1;
            this.txtServerIP.Text = "148.147.170.26";
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(127, 60);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(182, 20);
            this.txtServerPort.TabIndex = 2;
            this.txtServerPort.Text = "29096";
            // 
            // lblLinks
            // 
            this.lblLinks.AutoSize = true;
            this.lblLinks.Location = new System.Drawing.Point(11, 88);
            this.lblLinks.Name = "lblLinks";
            this.lblLinks.Size = new System.Drawing.Size(32, 13);
            this.lblLinks.TabIndex = 2;
            this.lblLinks.Text = "Links";
            // 
            // lblServerPort
            // 
            this.lblServerPort.AutoSize = true;
            this.lblServerPort.Location = new System.Drawing.Point(11, 62);
            this.lblServerPort.Name = "lblServerPort";
            this.lblServerPort.Size = new System.Drawing.Size(85, 13);
            this.lblServerPort.TabIndex = 1;
            this.lblServerPort.Text = "XML Server Port";
            // 
            // lblServerIP
            // 
            this.lblServerIP.AutoSize = true;
            this.lblServerIP.Location = new System.Drawing.Point(11, 36);
            this.lblServerIP.Name = "lblServerIP";
            this.lblServerIP.Size = new System.Drawing.Size(76, 13);
            this.lblServerIP.TabIndex = 0;
            this.lblServerIP.Text = "XML Server IP";
            // 
            // gbMediaDirDetails
            // 
            this.gbMediaDirDetails.Controls.Add(this.btnMDConnection);
            this.gbMediaDirDetails.Controls.Add(this.txtMPPort);
            this.gbMediaDirDetails.Controls.Add(this.txtMPIP);
            this.gbMediaDirDetails.Controls.Add(this.txtMDPort);
            this.gbMediaDirDetails.Controls.Add(this.txtMDIP);
            this.gbMediaDirDetails.Controls.Add(this.lblMediaProxyPort);
            this.gbMediaDirDetails.Controls.Add(this.lblMediaProxyIP);
            this.gbMediaDirDetails.Controls.Add(this.lblMediaDirPort);
            this.gbMediaDirDetails.Controls.Add(this.lblMediaDirIP);
            this.gbMediaDirDetails.Enabled = false;
            this.gbMediaDirDetails.Location = new System.Drawing.Point(12, 334);
            this.gbMediaDirDetails.Name = "gbMediaDirDetails";
            this.gbMediaDirDetails.Size = new System.Drawing.Size(411, 161);
            this.gbMediaDirDetails.TabIndex = 5;
            this.gbMediaDirDetails.TabStop = false;
            this.gbMediaDirDetails.Text = "Media Director Details";
            // 
            // btnMDConnection
            // 
            this.btnMDConnection.Location = new System.Drawing.Point(154, 125);
            this.btnMDConnection.Name = "btnMDConnection";
            this.btnMDConnection.Size = new System.Drawing.Size(75, 23);
            this.btnMDConnection.TabIndex = 6;
            this.btnMDConnection.Text = "Connect";
            this.btnMDConnection.UseVisualStyleBackColor = true;
            this.btnMDConnection.Click += new System.EventHandler(this.btnMDConnection_Click);
            // 
            // txtMPPort
            // 
            this.txtMPPort.Location = new System.Drawing.Point(127, 99);
            this.txtMPPort.Name = "txtMPPort";
            this.txtMPPort.Size = new System.Drawing.Size(182, 20);
            this.txtMPPort.TabIndex = 7;
            this.txtMPPort.Text = "29079";
            // 
            // txtMPIP
            // 
            this.txtMPIP.Location = new System.Drawing.Point(127, 76);
            this.txtMPIP.Name = "txtMPIP";
            this.txtMPIP.Size = new System.Drawing.Size(182, 20);
            this.txtMPIP.TabIndex = 6;
            this.txtMPIP.Text = "148.147.170.26";
            // 
            // txtMDPort
            // 
            this.txtMDPort.Location = new System.Drawing.Point(127, 53);
            this.txtMDPort.Name = "txtMDPort";
            this.txtMDPort.Size = new System.Drawing.Size(182, 20);
            this.txtMDPort.TabIndex = 5;
            this.txtMDPort.Text = "29087";
            // 
            // txtMDIP
            // 
            this.txtMDIP.Location = new System.Drawing.Point(127, 30);
            this.txtMDIP.Name = "txtMDIP";
            this.txtMDIP.Size = new System.Drawing.Size(182, 20);
            this.txtMDIP.TabIndex = 4;
            this.txtMDIP.Text = "148.147.170.26";
            // 
            // lblMediaProxyPort
            // 
            this.lblMediaProxyPort.AutoSize = true;
            this.lblMediaProxyPort.Location = new System.Drawing.Point(19, 108);
            this.lblMediaProxyPort.Name = "lblMediaProxyPort";
            this.lblMediaProxyPort.Size = new System.Drawing.Size(87, 13);
            this.lblMediaProxyPort.TabIndex = 3;
            this.lblMediaProxyPort.Text = "Media Proxy Port";
            // 
            // lblMediaProxyIP
            // 
            this.lblMediaProxyIP.AutoSize = true;
            this.lblMediaProxyIP.Location = new System.Drawing.Point(19, 82);
            this.lblMediaProxyIP.Name = "lblMediaProxyIP";
            this.lblMediaProxyIP.Size = new System.Drawing.Size(78, 13);
            this.lblMediaProxyIP.TabIndex = 2;
            this.lblMediaProxyIP.Text = "Media Proxy IP";
            // 
            // lblMediaDirPort
            // 
            this.lblMediaDirPort.AutoSize = true;
            this.lblMediaDirPort.Location = new System.Drawing.Point(19, 56);
            this.lblMediaDirPort.Name = "lblMediaDirPort";
            this.lblMediaDirPort.Size = new System.Drawing.Size(98, 13);
            this.lblMediaDirPort.TabIndex = 1;
            this.lblMediaDirPort.Text = "Media Director Port";
            // 
            // lblMediaDirIP
            // 
            this.lblMediaDirIP.AutoSize = true;
            this.lblMediaDirIP.Location = new System.Drawing.Point(19, 30);
            this.lblMediaDirIP.Name = "lblMediaDirIP";
            this.lblMediaDirIP.Size = new System.Drawing.Size(89, 13);
            this.lblMediaDirIP.TabIndex = 0;
            this.lblMediaDirIP.Text = "Media Director IP";
            // 
            // gbAgentDetails
            // 
            this.gbAgentDetails.Controls.Add(this.btnMonitor);
            this.gbAgentDetails.Controls.Add(this.btnACW);
            this.gbAgentDetails.Controls.Add(this.btnAux);
            this.gbAgentDetails.Controls.Add(this.btnAvailable);
            this.gbAgentDetails.Controls.Add(this.btnLogInOut);
            this.gbAgentDetails.Controls.Add(this.txtStationID);
            this.gbAgentDetails.Controls.Add(this.txtAgentID);
            this.gbAgentDetails.Controls.Add(this.txtAgentPwd);
            this.gbAgentDetails.Controls.Add(this.lblAgentPwd);
            this.gbAgentDetails.Controls.Add(this.lblAgentID);
            this.gbAgentDetails.Controls.Add(this.lblStationID);
            this.gbAgentDetails.Enabled = false;
            this.gbAgentDetails.Location = new System.Drawing.Point(12, 173);
            this.gbAgentDetails.Name = "gbAgentDetails";
            this.gbAgentDetails.Size = new System.Drawing.Size(411, 155);
            this.gbAgentDetails.TabIndex = 5;
            this.gbAgentDetails.TabStop = false;
            this.gbAgentDetails.Text = "Agent Details";
            // 
            // btnMonitor
            // 
            this.btnMonitor.Location = new System.Drawing.Point(315, 33);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(83, 23);
            this.btnMonitor.TabIndex = 13;
            this.btnMonitor.Text = "Monitor Start";
            this.myToolTip.SetToolTip(this.btnMonitor, "Start Monitor");
            this.btnMonitor.UseVisualStyleBackColor = true;
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // btnACW
            // 
            this.btnACW.Enabled = false;
            this.btnACW.Image = global::SMSHandlingApplication.Properties.Resources.ACW;
            this.btnACW.Location = new System.Drawing.Point(245, 111);
            this.btnACW.Name = "btnACW";
            this.btnACW.Size = new System.Drawing.Size(51, 35);
            this.btnACW.TabIndex = 12;
            this.btnACW.UseVisualStyleBackColor = true;
            this.btnACW.Click += new System.EventHandler(this.btnACW_Click);
            // 
            // btnAux
            // 
            this.btnAux.Enabled = false;
            this.btnAux.Image = global::SMSHandlingApplication.Properties.Resources.Auximg;
            this.btnAux.Location = new System.Drawing.Point(194, 111);
            this.btnAux.Name = "btnAux";
            this.btnAux.Size = new System.Drawing.Size(45, 35);
            this.btnAux.TabIndex = 11;
            this.btnAux.UseVisualStyleBackColor = true;
            this.btnAux.Click += new System.EventHandler(this.btnAux_Click);
            // 
            // btnAvailable
            // 
            this.btnAvailable.Enabled = false;
            this.btnAvailable.Image = global::SMSHandlingApplication.Properties.Resources.Available;
            this.btnAvailable.Location = new System.Drawing.Point(145, 111);
            this.btnAvailable.Name = "btnAvailable";
            this.btnAvailable.Size = new System.Drawing.Size(43, 35);
            this.btnAvailable.TabIndex = 10;
            this.btnAvailable.UseVisualStyleBackColor = true;
            this.btnAvailable.Click += new System.EventHandler(this.btnAvailable_Click);
            // 
            // btnLogInOut
            // 
            this.btnLogInOut.Enabled = false;
            this.btnLogInOut.Image = global::SMSHandlingApplication.Properties.Resources.login;
            this.btnLogInOut.Location = new System.Drawing.Point(97, 111);
            this.btnLogInOut.Name = "btnLogInOut";
            this.btnLogInOut.Size = new System.Drawing.Size(42, 35);
            this.btnLogInOut.TabIndex = 9;
            this.btnLogInOut.UseVisualStyleBackColor = true;
            this.btnLogInOut.Click += new System.EventHandler(this.btnLogInOut_Click);
            // 
            // txtStationID
            // 
            this.txtStationID.Location = new System.Drawing.Point(115, 33);
            this.txtStationID.Name = "txtStationID";
            this.txtStationID.Size = new System.Drawing.Size(194, 20);
            this.txtStationID.TabIndex = 6;
            // 
            // txtAgentID
            // 
            this.txtAgentID.Location = new System.Drawing.Point(115, 59);
            this.txtAgentID.Name = "txtAgentID";
            this.txtAgentID.Size = new System.Drawing.Size(194, 20);
            this.txtAgentID.TabIndex = 7;
            // 
            // txtAgentPwd
            // 
            this.txtAgentPwd.Location = new System.Drawing.Point(115, 85);
            this.txtAgentPwd.Name = "txtAgentPwd";
            this.txtAgentPwd.PasswordChar = '*';
            this.txtAgentPwd.Size = new System.Drawing.Size(194, 20);
            this.txtAgentPwd.TabIndex = 8;
            // 
            // lblAgentPwd
            // 
            this.lblAgentPwd.AutoSize = true;
            this.lblAgentPwd.Location = new System.Drawing.Point(19, 92);
            this.lblAgentPwd.Name = "lblAgentPwd";
            this.lblAgentPwd.Size = new System.Drawing.Size(84, 13);
            this.lblAgentPwd.TabIndex = 2;
            this.lblAgentPwd.Text = "Agent Password";
            // 
            // lblAgentID
            // 
            this.lblAgentID.AutoSize = true;
            this.lblAgentID.Location = new System.Drawing.Point(19, 64);
            this.lblAgentID.Name = "lblAgentID";
            this.lblAgentID.Size = new System.Drawing.Size(49, 13);
            this.lblAgentID.TabIndex = 1;
            this.lblAgentID.Text = "Agent ID";
            // 
            // lblStationID
            // 
            this.lblStationID.AutoSize = true;
            this.lblStationID.Location = new System.Drawing.Point(19, 36);
            this.lblStationID.Name = "lblStationID";
            this.lblStationID.Size = new System.Drawing.Size(54, 13);
            this.lblStationID.TabIndex = 0;
            this.lblStationID.Text = "Station ID";
            // 
            // rtbStatus
            // 
            this.rtbStatus.Enabled = false;
            this.rtbStatus.Location = new System.Drawing.Point(12, 582);
            this.rtbStatus.Name = "rtbStatus";
            this.rtbStatus.Size = new System.Drawing.Size(411, 66);
            this.rtbStatus.TabIndex = 5;
            this.rtbStatus.Text = "";
            // 
            // gbSMSHandling
            // 
            this.gbSMSHandling.Controls.Add(this.btnAcceptSMS);
            this.gbSMSHandling.Enabled = false;
            this.gbSMSHandling.Location = new System.Drawing.Point(11, 501);
            this.gbSMSHandling.Name = "gbSMSHandling";
            this.gbSMSHandling.Size = new System.Drawing.Size(412, 75);
            this.gbSMSHandling.TabIndex = 6;
            this.gbSMSHandling.TabStop = false;
            this.gbSMSHandling.Text = "SMS Handling";
            // 
            // btnAcceptSMS
            // 
            this.btnAcceptSMS.Enabled = false;
            this.btnAcceptSMS.Image = global::SMSHandlingApplication.Properties.Resources.recieveSMS;
            this.btnAcceptSMS.Location = new System.Drawing.Point(185, 19);
            this.btnAcceptSMS.Name = "btnAcceptSMS";
            this.btnAcceptSMS.Size = new System.Drawing.Size(42, 36);
            this.btnAcceptSMS.TabIndex = 0;
            this.btnAcceptSMS.UseVisualStyleBackColor = true;
            this.btnAcceptSMS.Click += new System.EventHandler(this.btnAcceptSMS_Click);
            // 
            // SMSHandlingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 660);
            this.Controls.Add(this.gbSMSHandling);
            this.Controls.Add(this.rtbStatus);
            this.Controls.Add(this.gbAgentDetails);
            this.Controls.Add(this.gbMediaDirDetails);
            this.Controls.Add(this.gbEMCDetails);
            this.Name = "SMSHandlingForm";
            this.Text = "SMSHandlingForm";
            this.gbEMCDetails.ResumeLayout(false);
            this.gbEMCDetails.PerformLayout();
            this.gbMediaDirDetails.ResumeLayout(false);
            this.gbMediaDirDetails.PerformLayout();
            this.gbAgentDetails.ResumeLayout(false);
            this.gbAgentDetails.PerformLayout();
            this.gbSMSHandling.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEMCDetails;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.Label lblLinks;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.Label lblServerIP;
        private System.Windows.Forms.ComboBox cmbTServerLinks;
        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.GroupBox gbMediaDirDetails;
        private System.Windows.Forms.Label lblMediaProxyPort;
        private System.Windows.Forms.Label lblMediaProxyIP;
        private System.Windows.Forms.Label lblMediaDirPort;
        private System.Windows.Forms.Label lblMediaDirIP;
        private System.Windows.Forms.TextBox txtMPPort;
        private System.Windows.Forms.TextBox txtMPIP;
        private System.Windows.Forms.TextBox txtMDPort;
        private System.Windows.Forms.TextBox txtMDIP;
        private System.Windows.Forms.Button btnMDConnection;
        private System.Windows.Forms.GroupBox gbAgentDetails;
        private System.Windows.Forms.TextBox txtStationID;
        public System.Windows.Forms.TextBox txtAgentID;
        private System.Windows.Forms.TextBox txtAgentPwd;
        private System.Windows.Forms.Label lblAgentPwd;
        private System.Windows.Forms.Label lblAgentID;
        private System.Windows.Forms.Label lblStationID;
        private System.Windows.Forms.Button btnACW;
        private System.Windows.Forms.Button btnAux;
        private System.Windows.Forms.Button btnAvailable;
        private System.Windows.Forms.Button btnLogInOut;
        private System.Windows.Forms.RichTextBox rtbStatus;
        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.ToolTip myToolTip;
        private System.Windows.Forms.GroupBox gbSMSHandling;
        private System.Windows.Forms.Button btnAcceptSMS;
    }
}

