namespace EmailHandlingApplication
{
    partial class EmailHandling
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
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.cmbServerTLinks = new System.Windows.Forms.ComboBox();
            this.btnBrowseLinks = new System.Windows.Forms.Button();
            this.btnConnection = new System.Windows.Forms.Button();
            this.lblServerLinks = new System.Windows.Forms.Label();
            this.XMLServerPort = new System.Windows.Forms.Label();
            this.lblServerIP = new System.Windows.Forms.Label();
            this.gbAgentDetails = new System.Windows.Forms.GroupBox();
            this.btnACW = new System.Windows.Forms.Button();
            this.btnAuxillary = new System.Windows.Forms.Button();
            this.btnAvailable = new System.Windows.Forms.Button();
            this.btnLogInOut = new System.Windows.Forms.Button();
            this.btnMonitor = new System.Windows.Forms.Button();
            this.txtAgentPwd = new System.Windows.Forms.TextBox();
            this.txtAgentID = new System.Windows.Forms.TextBox();
            this.txtStationID = new System.Windows.Forms.TextBox();
            this.lblAgentPwd = new System.Windows.Forms.Label();
            this.lblAgentID = new System.Windows.Forms.Label();
            this.lblStationID = new System.Windows.Forms.Label();
            this.rtbStatus = new System.Windows.Forms.RichTextBox();
            this.myToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnAcceptMail = new System.Windows.Forms.Button();
            this.gbMediaDirDetails = new System.Windows.Forms.GroupBox();
            this.txtMediaProxyPort = new System.Windows.Forms.TextBox();
            this.txtMediaProxyIP = new System.Windows.Forms.TextBox();
            this.lblMediaProxyPort = new System.Windows.Forms.Label();
            this.lblMediaProxyIP = new System.Windows.Forms.Label();
            this.btnConnectMediaStore = new System.Windows.Forms.Button();
            this.txtbMediaDirectorPort = new System.Windows.Forms.TextBox();
            this.txtMediaDirectorIP = new System.Windows.Forms.TextBox();
            this.lblMediaDirectorPort = new System.Windows.Forms.Label();
            this.lblMediaDirectorIP = new System.Windows.Forms.Label();
            this.gbEmail = new System.Windows.Forms.GroupBox();
            this.gbEMCDetails.SuspendLayout();
            this.gbAgentDetails.SuspendLayout();
            this.gbMediaDirDetails.SuspendLayout();
            this.gbEmail.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEMCDetails
            // 
            this.gbEMCDetails.Controls.Add(this.txtServerPort);
            this.gbEMCDetails.Controls.Add(this.txtServerIP);
            this.gbEMCDetails.Controls.Add(this.cmbServerTLinks);
            this.gbEMCDetails.Controls.Add(this.btnBrowseLinks);
            this.gbEMCDetails.Controls.Add(this.btnConnection);
            this.gbEMCDetails.Controls.Add(this.lblServerLinks);
            this.gbEMCDetails.Controls.Add(this.XMLServerPort);
            this.gbEMCDetails.Controls.Add(this.lblServerIP);
            this.gbEMCDetails.Location = new System.Drawing.Point(12, 12);
            this.gbEMCDetails.Name = "gbEMCDetails";
            this.gbEMCDetails.Size = new System.Drawing.Size(395, 149);
            this.gbEMCDetails.TabIndex = 0;
            this.gbEMCDetails.TabStop = false;
            this.gbEMCDetails.Text = "EMC Details";
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(128, 53);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(145, 20);
            this.txtServerPort.TabIndex = 3;
            this.txtServerPort.Text = "29096";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(128, 27);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(145, 20);
            this.txtServerIP.TabIndex = 2;
            this.txtServerIP.Text = "148.147.170.26";
            // 
            // cmbServerTLinks
            // 
            this.cmbServerTLinks.FormattingEnabled = true;
            this.cmbServerTLinks.Location = new System.Drawing.Point(128, 84);
            this.cmbServerTLinks.Name = "cmbServerTLinks";
            this.cmbServerTLinks.Size = new System.Drawing.Size(145, 21);
            this.cmbServerTLinks.TabIndex = 4;
            // 
            // btnBrowseLinks
            // 
            this.btnBrowseLinks.Location = new System.Drawing.Point(279, 82);
            this.btnBrowseLinks.Name = "btnBrowseLinks";
            this.btnBrowseLinks.Size = new System.Drawing.Size(42, 23);
            this.btnBrowseLinks.TabIndex = 0;
            this.btnBrowseLinks.Text = "...";
            this.myToolTip.SetToolTip(this.btnBrowseLinks, "Browse for available Links");
            this.btnBrowseLinks.UseVisualStyleBackColor = true;
            this.btnBrowseLinks.Click += new System.EventHandler(this.btnBrowseLinks_Click);
            // 
            // btnConnection
            // 
            this.btnConnection.Enabled = false;
            this.btnConnection.Location = new System.Drawing.Point(157, 111);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(96, 29);
            this.btnConnection.TabIndex = 1;
            this.btnConnection.Text = "Connect";
            this.myToolTip.SetToolTip(this.btnConnection, "Connect to XML Server");
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // lblServerLinks
            // 
            this.lblServerLinks.AutoSize = true;
            this.lblServerLinks.Location = new System.Drawing.Point(20, 82);
            this.lblServerLinks.Name = "lblServerLinks";
            this.lblServerLinks.Size = new System.Drawing.Size(32, 13);
            this.lblServerLinks.TabIndex = 7;
            this.lblServerLinks.Text = "Links";
            // 
            // XMLServerPort
            // 
            this.XMLServerPort.AutoSize = true;
            this.XMLServerPort.Location = new System.Drawing.Point(20, 60);
            this.XMLServerPort.Name = "XMLServerPort";
            this.XMLServerPort.Size = new System.Drawing.Size(85, 13);
            this.XMLServerPort.TabIndex = 6;
            this.XMLServerPort.Text = "XML Server Port";
            // 
            // lblServerIP
            // 
            this.lblServerIP.AutoSize = true;
            this.lblServerIP.Location = new System.Drawing.Point(20, 34);
            this.lblServerIP.Name = "lblServerIP";
            this.lblServerIP.Size = new System.Drawing.Size(76, 13);
            this.lblServerIP.TabIndex = 5;
            this.lblServerIP.Text = "XML Server IP";
            // 
            // gbAgentDetails
            // 
            this.gbAgentDetails.Controls.Add(this.btnACW);
            this.gbAgentDetails.Controls.Add(this.btnAuxillary);
            this.gbAgentDetails.Controls.Add(this.btnAvailable);
            this.gbAgentDetails.Controls.Add(this.btnLogInOut);
            this.gbAgentDetails.Controls.Add(this.btnMonitor);
            this.gbAgentDetails.Controls.Add(this.txtAgentPwd);
            this.gbAgentDetails.Controls.Add(this.txtAgentID);
            this.gbAgentDetails.Controls.Add(this.txtStationID);
            this.gbAgentDetails.Controls.Add(this.lblAgentPwd);
            this.gbAgentDetails.Controls.Add(this.lblAgentID);
            this.gbAgentDetails.Controls.Add(this.lblStationID);
            this.gbAgentDetails.Enabled = false;
            this.gbAgentDetails.Location = new System.Drawing.Point(13, 167);
            this.gbAgentDetails.Name = "gbAgentDetails";
            this.gbAgentDetails.Size = new System.Drawing.Size(394, 168);
            this.gbAgentDetails.TabIndex = 0;
            this.gbAgentDetails.TabStop = false;
            this.gbAgentDetails.Text = "Agent Details";
            // 
            // btnACW
            // 
            this.btnACW.Enabled = false;
            this.btnACW.Image = global::EmailHandlingApplication.Properties.Resources.ACW;
            this.btnACW.Location = new System.Drawing.Point(249, 121);
            this.btnACW.Name = "btnACW";
            this.btnACW.Size = new System.Drawing.Size(46, 33);
            this.btnACW.TabIndex = 7;
            this.myToolTip.SetToolTip(this.btnACW, "After Call Work");
            this.btnACW.UseVisualStyleBackColor = true;
            this.btnACW.Click += new System.EventHandler(this.btnACW_Click);
            // 
            // btnAuxillary
            // 
            this.btnAuxillary.Enabled = false;
            this.btnAuxillary.Image = global::EmailHandlingApplication.Properties.Resources.Auximg;
            this.btnAuxillary.Location = new System.Drawing.Point(195, 121);
            this.btnAuxillary.Name = "btnAuxillary";
            this.btnAuxillary.Size = new System.Drawing.Size(46, 33);
            this.btnAuxillary.TabIndex = 6;
            this.myToolTip.SetToolTip(this.btnAuxillary, "Auxillary");
            this.btnAuxillary.UseVisualStyleBackColor = true;
            this.btnAuxillary.Click += new System.EventHandler(this.btnAuxillary_Click);
            // 
            // btnAvailable
            // 
            this.btnAvailable.Enabled = false;
            this.btnAvailable.Image = global::EmailHandlingApplication.Properties.Resources.Available;
            this.btnAvailable.Location = new System.Drawing.Point(141, 121);
            this.btnAvailable.Name = "btnAvailable";
            this.btnAvailable.Size = new System.Drawing.Size(46, 33);
            this.btnAvailable.TabIndex = 5;
            this.myToolTip.SetToolTip(this.btnAvailable, "Available");
            this.btnAvailable.UseVisualStyleBackColor = true;
            this.btnAvailable.Click += new System.EventHandler(this.btnAvailable_Click);
            // 
            // btnLogInOut
            // 
            this.btnLogInOut.Enabled = false;
            this.btnLogInOut.Image = global::EmailHandlingApplication.Properties.Resources.login;
            this.btnLogInOut.Location = new System.Drawing.Point(87, 121);
            this.btnLogInOut.Name = "btnLogInOut";
            this.btnLogInOut.Size = new System.Drawing.Size(46, 33);
            this.btnLogInOut.TabIndex = 4;
            this.myToolTip.SetToolTip(this.btnLogInOut, "Agent Login");
            this.btnLogInOut.UseVisualStyleBackColor = true;
            this.btnLogInOut.Click += new System.EventHandler(this.btnLogInOut_Click);
            // 
            // btnMonitor
            // 
            this.btnMonitor.Enabled = false;
            this.btnMonitor.Location = new System.Drawing.Point(278, 34);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(94, 23);
            this.btnMonitor.TabIndex = 1;
            this.btnMonitor.Text = "Monitor Start";
            this.btnMonitor.UseVisualStyleBackColor = true;
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // txtAgentPwd
            // 
            this.txtAgentPwd.Enabled = false;
            this.txtAgentPwd.Location = new System.Drawing.Point(127, 89);
            this.txtAgentPwd.Name = "txtAgentPwd";
            this.txtAgentPwd.PasswordChar = '*';
            this.txtAgentPwd.Size = new System.Drawing.Size(145, 20);
            this.txtAgentPwd.TabIndex = 3;
            // 
            // txtAgentID
            // 
            this.txtAgentID.Enabled = false;
            this.txtAgentID.Location = new System.Drawing.Point(127, 60);
            this.txtAgentID.Name = "txtAgentID";
            this.txtAgentID.Size = new System.Drawing.Size(145, 20);
            this.txtAgentID.TabIndex = 2;
            // 
            // txtStationID
            // 
            this.txtStationID.Enabled = false;
            this.txtStationID.Location = new System.Drawing.Point(127, 34);
            this.txtStationID.Name = "txtStationID";
            this.txtStationID.Size = new System.Drawing.Size(145, 20);
            this.txtStationID.TabIndex = 0;
            // 
            // lblAgentPwd
            // 
            this.lblAgentPwd.AutoSize = true;
            this.lblAgentPwd.Enabled = false;
            this.lblAgentPwd.Location = new System.Drawing.Point(19, 89);
            this.lblAgentPwd.Name = "lblAgentPwd";
            this.lblAgentPwd.Size = new System.Drawing.Size(84, 13);
            this.lblAgentPwd.TabIndex = 10;
            this.lblAgentPwd.Text = "Agent Password";
            // 
            // lblAgentID
            // 
            this.lblAgentID.AutoSize = true;
            this.lblAgentID.Enabled = false;
            this.lblAgentID.Location = new System.Drawing.Point(19, 63);
            this.lblAgentID.Name = "lblAgentID";
            this.lblAgentID.Size = new System.Drawing.Size(49, 13);
            this.lblAgentID.TabIndex = 9;
            this.lblAgentID.Text = "Agent ID";
            // 
            // lblStationID
            // 
            this.lblStationID.AutoSize = true;
            this.lblStationID.Enabled = false;
            this.lblStationID.Location = new System.Drawing.Point(19, 34);
            this.lblStationID.Name = "lblStationID";
            this.lblStationID.Size = new System.Drawing.Size(54, 13);
            this.lblStationID.TabIndex = 8;
            this.lblStationID.Text = "Station ID";
            // 
            // rtbStatus
            // 
            this.rtbStatus.Enabled = false;
            this.rtbStatus.Location = new System.Drawing.Point(13, 587);
            this.rtbStatus.Name = "rtbStatus";
            this.rtbStatus.Size = new System.Drawing.Size(394, 96);
            this.rtbStatus.TabIndex = 6;
            this.rtbStatus.Text = "";
            // 
            // btnAcceptMail
            // 
            this.btnAcceptMail.Enabled = false;
            this.btnAcceptMail.Image = global::EmailHandlingApplication.Properties.Resources.AcceptMail;
            this.btnAcceptMail.Location = new System.Drawing.Point(156, 30);
            this.btnAcceptMail.Name = "btnAcceptMail";
            this.btnAcceptMail.Size = new System.Drawing.Size(43, 34);
            this.btnAcceptMail.TabIndex = 0;
            this.myToolTip.SetToolTip(this.btnAcceptMail, "Accept Mail");
            this.btnAcceptMail.UseVisualStyleBackColor = true;
            this.btnAcceptMail.Click += new System.EventHandler(this.btnAcceptMail_Click);
            // 
            // gbMediaDirDetails
            // 
            this.gbMediaDirDetails.Controls.Add(this.txtMediaProxyPort);
            this.gbMediaDirDetails.Controls.Add(this.txtMediaProxyIP);
            this.gbMediaDirDetails.Controls.Add(this.lblMediaProxyPort);
            this.gbMediaDirDetails.Controls.Add(this.lblMediaProxyIP);
            this.gbMediaDirDetails.Controls.Add(this.btnConnectMediaStore);
            this.gbMediaDirDetails.Controls.Add(this.txtbMediaDirectorPort);
            this.gbMediaDirDetails.Controls.Add(this.txtMediaDirectorIP);
            this.gbMediaDirDetails.Controls.Add(this.lblMediaDirectorPort);
            this.gbMediaDirDetails.Controls.Add(this.lblMediaDirectorIP);
            this.gbMediaDirDetails.Enabled = false;
            this.gbMediaDirDetails.Location = new System.Drawing.Point(13, 341);
            this.gbMediaDirDetails.Name = "gbMediaDirDetails";
            this.gbMediaDirDetails.Size = new System.Drawing.Size(394, 134);
            this.gbMediaDirDetails.TabIndex = 2;
            this.gbMediaDirDetails.TabStop = false;
            this.gbMediaDirDetails.Text = "Media Director Details";
            // 
            // txtMediaProxyPort
            // 
            this.txtMediaProxyPort.Location = new System.Drawing.Point(122, 104);
            this.txtMediaProxyPort.Name = "txtMediaProxyPort";
            this.txtMediaProxyPort.Size = new System.Drawing.Size(145, 20);
            this.txtMediaProxyPort.TabIndex = 4;
            this.txtMediaProxyPort.Text = "29079";
            // 
            // txtMediaProxyIP
            // 
            this.txtMediaProxyIP.Location = new System.Drawing.Point(122, 78);
            this.txtMediaProxyIP.Name = "txtMediaProxyIP";
            this.txtMediaProxyIP.Size = new System.Drawing.Size(145, 20);
            this.txtMediaProxyIP.TabIndex = 3;
            this.txtMediaProxyIP.Text = "148.147.170.26";
            // 
            // lblMediaProxyPort
            // 
            this.lblMediaProxyPort.AutoSize = true;
            this.lblMediaProxyPort.Location = new System.Drawing.Point(14, 107);
            this.lblMediaProxyPort.Name = "lblMediaProxyPort";
            this.lblMediaProxyPort.Size = new System.Drawing.Size(87, 13);
            this.lblMediaProxyPort.TabIndex = 8;
            this.lblMediaProxyPort.Text = "Media Proxy Port";
            // 
            // lblMediaProxyIP
            // 
            this.lblMediaProxyIP.AutoSize = true;
            this.lblMediaProxyIP.Location = new System.Drawing.Point(14, 81);
            this.lblMediaProxyIP.Name = "lblMediaProxyIP";
            this.lblMediaProxyIP.Size = new System.Drawing.Size(78, 13);
            this.lblMediaProxyIP.TabIndex = 7;
            this.lblMediaProxyIP.Text = "Media Proxy IP";
            // 
            // btnConnectMediaStore
            // 
            this.btnConnectMediaStore.Location = new System.Drawing.Point(278, 101);
            this.btnConnectMediaStore.Name = "btnConnectMediaStore";
            this.btnConnectMediaStore.Size = new System.Drawing.Size(75, 23);
            this.btnConnectMediaStore.TabIndex = 0;
            this.btnConnectMediaStore.Text = "Connect";
            this.btnConnectMediaStore.UseVisualStyleBackColor = true;
            this.btnConnectMediaStore.Click += new System.EventHandler(this.btnConnectMediaStore_Click);
            // 
            // txtbMediaDirectorPort
            // 
            this.txtbMediaDirectorPort.Location = new System.Drawing.Point(122, 52);
            this.txtbMediaDirectorPort.Name = "txtbMediaDirectorPort";
            this.txtbMediaDirectorPort.Size = new System.Drawing.Size(145, 20);
            this.txtbMediaDirectorPort.TabIndex = 2;
            this.txtbMediaDirectorPort.Text = "29087";
            // 
            // txtMediaDirectorIP
            // 
            this.txtMediaDirectorIP.Location = new System.Drawing.Point(122, 26);
            this.txtMediaDirectorIP.Name = "txtMediaDirectorIP";
            this.txtMediaDirectorIP.Size = new System.Drawing.Size(145, 20);
            this.txtMediaDirectorIP.TabIndex = 1;
            this.txtMediaDirectorIP.Text = "148.147.170.26";
            // 
            // lblMediaDirectorPort
            // 
            this.lblMediaDirectorPort.AutoSize = true;
            this.lblMediaDirectorPort.Location = new System.Drawing.Point(14, 55);
            this.lblMediaDirectorPort.Name = "lblMediaDirectorPort";
            this.lblMediaDirectorPort.Size = new System.Drawing.Size(98, 13);
            this.lblMediaDirectorPort.TabIndex = 6;
            this.lblMediaDirectorPort.Text = "Media Director Port";
            // 
            // lblMediaDirectorIP
            // 
            this.lblMediaDirectorIP.AutoSize = true;
            this.lblMediaDirectorIP.Location = new System.Drawing.Point(14, 29);
            this.lblMediaDirectorIP.Name = "lblMediaDirectorIP";
            this.lblMediaDirectorIP.Size = new System.Drawing.Size(89, 13);
            this.lblMediaDirectorIP.TabIndex = 5;
            this.lblMediaDirectorIP.Text = "Media Director IP";
            // 
            // gbEmail
            // 
            this.gbEmail.Controls.Add(this.btnAcceptMail);
            this.gbEmail.Enabled = false;
            this.gbEmail.Location = new System.Drawing.Point(13, 481);
            this.gbEmail.Name = "gbEmail";
            this.gbEmail.Size = new System.Drawing.Size(392, 83);
            this.gbEmail.TabIndex = 8;
            this.gbEmail.TabStop = false;
            this.gbEmail.Text = "Email Handling";
            // 
            // EmailHandling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 695);
            this.Controls.Add(this.gbEmail);
            this.Controls.Add(this.gbMediaDirDetails);
            this.Controls.Add(this.rtbStatus);
            this.Controls.Add(this.gbAgentDetails);
            this.Controls.Add(this.gbEMCDetails);
            this.Name = "EmailHandling";
            this.Text = "Email Application";
            this.gbEMCDetails.ResumeLayout(false);
            this.gbEMCDetails.PerformLayout();
            this.gbAgentDetails.ResumeLayout(false);
            this.gbAgentDetails.PerformLayout();
            this.gbMediaDirDetails.ResumeLayout(false);
            this.gbMediaDirDetails.PerformLayout();
            this.gbEmail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEMCDetails;
        private System.Windows.Forms.Label lblServerLinks;
        private System.Windows.Forms.Label XMLServerPort;
        private System.Windows.Forms.Label lblServerIP;
        private System.Windows.Forms.GroupBox gbAgentDetails;
        private System.Windows.Forms.Button btnBrowseLinks;
        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.ComboBox cmbServerTLinks;
        private System.Windows.Forms.Button btnACW;
        private System.Windows.Forms.Button btnAuxillary;
        private System.Windows.Forms.Button btnAvailable;
        private System.Windows.Forms.Button btnLogInOut;
        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.TextBox txtAgentPwd;
        private System.Windows.Forms.TextBox txtAgentID;
        private System.Windows.Forms.TextBox txtStationID;
        private System.Windows.Forms.Label lblAgentPwd;
        private System.Windows.Forms.Label lblAgentID;
        private System.Windows.Forms.Label lblStationID;
        private System.Windows.Forms.ToolTip myToolTip;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.GroupBox gbMediaDirDetails;
        private System.Windows.Forms.Button btnConnectMediaStore;
        private System.Windows.Forms.TextBox txtbMediaDirectorPort;
        private System.Windows.Forms.TextBox txtMediaDirectorIP;
        private System.Windows.Forms.Label lblMediaDirectorPort;
        private System.Windows.Forms.Label lblMediaDirectorIP;
        private System.Windows.Forms.TextBox txtMediaProxyPort;
        private System.Windows.Forms.TextBox txtMediaProxyIP;
        private System.Windows.Forms.Label lblMediaProxyPort;
        private System.Windows.Forms.Label lblMediaProxyIP;
        private System.Windows.Forms.GroupBox gbEmail;
        private System.Windows.Forms.Button btnAcceptMail;
        public System.Windows.Forms.RichTextBox rtbStatus;
    }
}

