namespace WebChatApplication
{
    partial class WebChatApplication
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.cmbTServerLinks = new System.Windows.Forms.ComboBox();
            this.txtXMLServerPort = new System.Windows.Forms.TextBox();
            this.txtXMLServerIP = new System.Windows.Forms.TextBox();
            this.lblServerLinks = new System.Windows.Forms.Label();
            this.lblServerPort = new System.Windows.Forms.Label();
            this.lblServerIP = new System.Windows.Forms.Label();
            this.gbAgentDetails = new System.Windows.Forms.GroupBox();
            this.btnACW = new System.Windows.Forms.Button();
            this.btnAux = new System.Windows.Forms.Button();
            this.btnAvailable = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnMonitor = new System.Windows.Forms.Button();
            this.txtStationID = new System.Windows.Forms.TextBox();
            this.txtAgentID = new System.Windows.Forms.TextBox();
            this.txtAgentPwd = new System.Windows.Forms.TextBox();
            this.lblAgentPwd = new System.Windows.Forms.Label();
            this.lblAgentID = new System.Windows.Forms.Label();
            this.lblStationID = new System.Windows.Forms.Label();
            this.gbMDDetails = new System.Windows.Forms.GroupBox();
            this.btnMDConnect = new System.Windows.Forms.Button();
            this.txtMPPort = new System.Windows.Forms.TextBox();
            this.txtMPIP = new System.Windows.Forms.TextBox();
            this.txtMDPort = new System.Windows.Forms.TextBox();
            this.txtMDIP = new System.Windows.Forms.TextBox();
            this.lblMDIP = new System.Windows.Forms.Label();
            this.lblMDPort = new System.Windows.Forms.Label();
            this.lblMPIP = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbWebChat = new System.Windows.Forms.GroupBox();
            this.btnChat = new System.Windows.Forms.Button();
            this.rtbStatus = new System.Windows.Forms.RichTextBox();
            this.myToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.gbChatWindow = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.rtbReplyFromAgent = new System.Windows.Forms.RichTextBox();
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.gbEMCDetails.SuspendLayout();
            this.gbAgentDetails.SuspendLayout();
            this.gbMDDetails.SuspendLayout();
            this.gbWebChat.SuspendLayout();
            this.gbChatWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEMCDetails
            // 
            this.gbEMCDetails.Controls.Add(this.btnConnect);
            this.gbEMCDetails.Controls.Add(this.btnBrowse);
            this.gbEMCDetails.Controls.Add(this.cmbTServerLinks);
            this.gbEMCDetails.Controls.Add(this.txtXMLServerPort);
            this.gbEMCDetails.Controls.Add(this.txtXMLServerIP);
            this.gbEMCDetails.Controls.Add(this.lblServerLinks);
            this.gbEMCDetails.Controls.Add(this.lblServerPort);
            this.gbEMCDetails.Controls.Add(this.lblServerIP);
            this.gbEMCDetails.Location = new System.Drawing.Point(12, 12);
            this.gbEMCDetails.Name = "gbEMCDetails";
            this.gbEMCDetails.Size = new System.Drawing.Size(428, 141);
            this.gbEMCDetails.TabIndex = 0;
            this.gbEMCDetails.TabStop = false;
            this.gbEMCDetails.Text = "EMC Details";
            // 
            // btnConnect
            // 
            this.btnConnect.Enabled = false;
            this.btnConnect.Location = new System.Drawing.Point(164, 105);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Connect";
            this.myToolTip.SetToolTip(this.btnConnect, "Connect to XML Server");
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(322, 76);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(38, 23);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "...";
            this.myToolTip.SetToolTip(this.btnBrowse, "Browse for available TServer Links");
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // cmbTServerLinks
            // 
            this.cmbTServerLinks.FormattingEnabled = true;
            this.cmbTServerLinks.Location = new System.Drawing.Point(114, 78);
            this.cmbTServerLinks.Name = "cmbTServerLinks";
            this.cmbTServerLinks.Size = new System.Drawing.Size(202, 21);
            this.cmbTServerLinks.TabIndex = 5;
            // 
            // txtXMLServerPort
            // 
            this.txtXMLServerPort.Location = new System.Drawing.Point(114, 52);
            this.txtXMLServerPort.Name = "txtXMLServerPort";
            this.txtXMLServerPort.Size = new System.Drawing.Size(202, 20);
            this.txtXMLServerPort.TabIndex = 4;
            this.txtXMLServerPort.Text = "29096";
            // 
            // txtXMLServerIP
            // 
            this.txtXMLServerIP.Location = new System.Drawing.Point(114, 28);
            this.txtXMLServerIP.Name = "txtXMLServerIP";
            this.txtXMLServerIP.Size = new System.Drawing.Size(202, 20);
            this.txtXMLServerIP.TabIndex = 3;
            this.txtXMLServerIP.Text = "148.147.170.26";
            // 
            // lblServerLinks
            // 
            this.lblServerLinks.AutoSize = true;
            this.lblServerLinks.Location = new System.Drawing.Point(11, 82);
            this.lblServerLinks.Name = "lblServerLinks";
            this.lblServerLinks.Size = new System.Drawing.Size(32, 13);
            this.lblServerLinks.TabIndex = 2;
            this.lblServerLinks.Text = "Links";
            // 
            // lblServerPort
            // 
            this.lblServerPort.AutoSize = true;
            this.lblServerPort.Location = new System.Drawing.Point(11, 55);
            this.lblServerPort.Name = "lblServerPort";
            this.lblServerPort.Size = new System.Drawing.Size(85, 13);
            this.lblServerPort.TabIndex = 1;
            this.lblServerPort.Text = "XML Server Port";
            // 
            // lblServerIP
            // 
            this.lblServerIP.AutoSize = true;
            this.lblServerIP.Location = new System.Drawing.Point(11, 28);
            this.lblServerIP.Name = "lblServerIP";
            this.lblServerIP.Size = new System.Drawing.Size(76, 13);
            this.lblServerIP.TabIndex = 0;
            this.lblServerIP.Text = "XML Server IP";
            // 
            // gbAgentDetails
            // 
            this.gbAgentDetails.Controls.Add(this.btnACW);
            this.gbAgentDetails.Controls.Add(this.btnAux);
            this.gbAgentDetails.Controls.Add(this.btnAvailable);
            this.gbAgentDetails.Controls.Add(this.btnLogin);
            this.gbAgentDetails.Controls.Add(this.btnMonitor);
            this.gbAgentDetails.Controls.Add(this.txtStationID);
            this.gbAgentDetails.Controls.Add(this.txtAgentID);
            this.gbAgentDetails.Controls.Add(this.txtAgentPwd);
            this.gbAgentDetails.Controls.Add(this.lblAgentPwd);
            this.gbAgentDetails.Controls.Add(this.lblAgentID);
            this.gbAgentDetails.Controls.Add(this.lblStationID);
            this.gbAgentDetails.Enabled = false;
            this.gbAgentDetails.Location = new System.Drawing.Point(12, 159);
            this.gbAgentDetails.Name = "gbAgentDetails";
            this.gbAgentDetails.Size = new System.Drawing.Size(428, 149);
            this.gbAgentDetails.TabIndex = 0;
            this.gbAgentDetails.TabStop = false;
            this.gbAgentDetails.Text = "Agent Details";
            // 
            // btnACW
            // 
            this.btnACW.Enabled = false;
            this.btnACW.Image = global::WebChatApplication.Properties.Resources.ACW;
            this.btnACW.Location = new System.Drawing.Point(265, 105);
            this.btnACW.Name = "btnACW";
            this.btnACW.Size = new System.Drawing.Size(49, 32);
            this.btnACW.TabIndex = 7;
            this.myToolTip.SetToolTip(this.btnACW, "ACW");
            this.btnACW.UseVisualStyleBackColor = true;
            this.btnACW.Click += new System.EventHandler(this.btnACW_Click);
            // 
            // btnAux
            // 
            this.btnAux.Enabled = false;
            this.btnAux.Image = global::WebChatApplication.Properties.Resources.Auximg;
            this.btnAux.Location = new System.Drawing.Point(215, 105);
            this.btnAux.Name = "btnAux";
            this.btnAux.Size = new System.Drawing.Size(45, 32);
            this.btnAux.TabIndex = 6;
            this.myToolTip.SetToolTip(this.btnAux, "AUX");
            this.btnAux.UseVisualStyleBackColor = true;
            this.btnAux.Click += new System.EventHandler(this.btnAux_Click);
            // 
            // btnAvailable
            // 
            this.btnAvailable.Enabled = false;
            this.btnAvailable.Image = global::WebChatApplication.Properties.Resources.Available;
            this.btnAvailable.Location = new System.Drawing.Point(160, 105);
            this.btnAvailable.Name = "btnAvailable";
            this.btnAvailable.Size = new System.Drawing.Size(49, 32);
            this.btnAvailable.TabIndex = 5;
            this.myToolTip.SetToolTip(this.btnAvailable, "Available");
            this.btnAvailable.UseVisualStyleBackColor = true;
            this.btnAvailable.Click += new System.EventHandler(this.btnAvailable_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Enabled = false;
            this.btnLogin.Image = global::WebChatApplication.Properties.Resources.login;
            this.btnLogin.Location = new System.Drawing.Point(109, 105);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(45, 32);
            this.btnLogin.TabIndex = 4;
            this.myToolTip.SetToolTip(this.btnLogin, "Agent Login");
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnMonitor
            // 
            this.btnMonitor.Enabled = false;
            this.btnMonitor.Location = new System.Drawing.Point(322, 19);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(93, 23);
            this.btnMonitor.TabIndex = 1;
            this.btnMonitor.Text = "Monitor Start";
            this.myToolTip.SetToolTip(this.btnMonitor, "Start monitor");
            this.btnMonitor.UseVisualStyleBackColor = true;
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // txtStationID
            // 
            this.txtStationID.Enabled = false;
            this.txtStationID.Location = new System.Drawing.Point(114, 19);
            this.txtStationID.Name = "txtStationID";
            this.txtStationID.Size = new System.Drawing.Size(202, 20);
            this.txtStationID.TabIndex = 1;
            this.txtStationID.Text = "6511";
            // 
            // txtAgentID
            // 
            this.txtAgentID.Enabled = false;
            this.txtAgentID.Location = new System.Drawing.Point(114, 45);
            this.txtAgentID.Name = "txtAgentID";
            this.txtAgentID.Size = new System.Drawing.Size(202, 20);
            this.txtAgentID.TabIndex = 2;
            this.txtAgentID.Text = "6711";
            // 
            // txtAgentPwd
            // 
            this.txtAgentPwd.Enabled = false;
            this.txtAgentPwd.Location = new System.Drawing.Point(114, 72);
            this.txtAgentPwd.Name = "txtAgentPwd";
            this.txtAgentPwd.PasswordChar = '*';
            this.txtAgentPwd.Size = new System.Drawing.Size(202, 20);
            this.txtAgentPwd.TabIndex = 3;
            this.txtAgentPwd.Text = "1234";
            // 
            // lblAgentPwd
            // 
            this.lblAgentPwd.AutoSize = true;
            this.lblAgentPwd.Location = new System.Drawing.Point(11, 72);
            this.lblAgentPwd.Name = "lblAgentPwd";
            this.lblAgentPwd.Size = new System.Drawing.Size(84, 13);
            this.lblAgentPwd.TabIndex = 2;
            this.lblAgentPwd.Text = "Agent Password";
            // 
            // lblAgentID
            // 
            this.lblAgentID.AutoSize = true;
            this.lblAgentID.Location = new System.Drawing.Point(11, 49);
            this.lblAgentID.Name = "lblAgentID";
            this.lblAgentID.Size = new System.Drawing.Size(49, 13);
            this.lblAgentID.TabIndex = 1;
            this.lblAgentID.Text = "Agent ID";
            // 
            // lblStationID
            // 
            this.lblStationID.AutoSize = true;
            this.lblStationID.Location = new System.Drawing.Point(11, 26);
            this.lblStationID.Name = "lblStationID";
            this.lblStationID.Size = new System.Drawing.Size(54, 13);
            this.lblStationID.TabIndex = 0;
            this.lblStationID.Text = "Station ID";
            // 
            // gbMDDetails
            // 
            this.gbMDDetails.Controls.Add(this.btnMDConnect);
            this.gbMDDetails.Controls.Add(this.txtMPPort);
            this.gbMDDetails.Controls.Add(this.txtMPIP);
            this.gbMDDetails.Controls.Add(this.txtMDPort);
            this.gbMDDetails.Controls.Add(this.txtMDIP);
            this.gbMDDetails.Controls.Add(this.lblMDIP);
            this.gbMDDetails.Controls.Add(this.lblMDPort);
            this.gbMDDetails.Controls.Add(this.lblMPIP);
            this.gbMDDetails.Controls.Add(this.label4);
            this.gbMDDetails.Enabled = false;
            this.gbMDDetails.Location = new System.Drawing.Point(12, 314);
            this.gbMDDetails.Name = "gbMDDetails";
            this.gbMDDetails.Size = new System.Drawing.Size(428, 170);
            this.gbMDDetails.TabIndex = 0;
            this.gbMDDetails.TabStop = false;
            this.gbMDDetails.Text = "Media Director Details";
            // 
            // btnMDConnect
            // 
            this.btnMDConnect.Location = new System.Drawing.Point(164, 134);
            this.btnMDConnect.Name = "btnMDConnect";
            this.btnMDConnect.Size = new System.Drawing.Size(75, 23);
            this.btnMDConnect.TabIndex = 9;
            this.btnMDConnect.Text = "Connect";
            this.btnMDConnect.UseVisualStyleBackColor = true;
            this.btnMDConnect.Click += new System.EventHandler(this.btnMDConnect_Click);
            // 
            // txtMPPort
            // 
            this.txtMPPort.Location = new System.Drawing.Point(114, 101);
            this.txtMPPort.Name = "txtMPPort";
            this.txtMPPort.Size = new System.Drawing.Size(202, 20);
            this.txtMPPort.TabIndex = 8;
            this.txtMPPort.Text = "29079";
            // 
            // txtMPIP
            // 
            this.txtMPIP.Location = new System.Drawing.Point(114, 79);
            this.txtMPIP.Name = "txtMPIP";
            this.txtMPIP.Size = new System.Drawing.Size(202, 20);
            this.txtMPIP.TabIndex = 7;
            this.txtMPIP.Text = "148.147.170.26";
            // 
            // txtMDPort
            // 
            this.txtMDPort.Location = new System.Drawing.Point(114, 57);
            this.txtMDPort.Name = "txtMDPort";
            this.txtMDPort.Size = new System.Drawing.Size(202, 20);
            this.txtMDPort.TabIndex = 6;
            this.txtMDPort.Text = "29087";
            // 
            // txtMDIP
            // 
            this.txtMDIP.Location = new System.Drawing.Point(114, 35);
            this.txtMDIP.Name = "txtMDIP";
            this.txtMDIP.Size = new System.Drawing.Size(202, 20);
            this.txtMDIP.TabIndex = 5;
            this.txtMDIP.Text = "148.147.170.26";
            // 
            // lblMDIP
            // 
            this.lblMDIP.AutoSize = true;
            this.lblMDIP.Location = new System.Drawing.Point(8, 35);
            this.lblMDIP.Name = "lblMDIP";
            this.lblMDIP.Size = new System.Drawing.Size(89, 13);
            this.lblMDIP.TabIndex = 1;
            this.lblMDIP.Text = "Media Director IP";
            // 
            // lblMDPort
            // 
            this.lblMDPort.AutoSize = true;
            this.lblMDPort.Location = new System.Drawing.Point(6, 58);
            this.lblMDPort.Name = "lblMDPort";
            this.lblMDPort.Size = new System.Drawing.Size(98, 13);
            this.lblMDPort.TabIndex = 2;
            this.lblMDPort.Text = "Media Director Port";
            // 
            // lblMPIP
            // 
            this.lblMPIP.AutoSize = true;
            this.lblMPIP.Location = new System.Drawing.Point(6, 81);
            this.lblMPIP.Name = "lblMPIP";
            this.lblMPIP.Size = new System.Drawing.Size(78, 13);
            this.lblMPIP.TabIndex = 3;
            this.lblMPIP.Text = "Media Proxy IP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Media Proxy Port";
            // 
            // gbWebChat
            // 
            this.gbWebChat.Controls.Add(this.btnChat);
            this.gbWebChat.Enabled = false;
            this.gbWebChat.Location = new System.Drawing.Point(12, 490);
            this.gbWebChat.Name = "gbWebChat";
            this.gbWebChat.Size = new System.Drawing.Size(428, 73);
            this.gbWebChat.TabIndex = 0;
            this.gbWebChat.TabStop = false;
            this.gbWebChat.Text = "Web Chat ";
            // 
            // btnChat
            // 
            this.btnChat.Enabled = false;
            this.btnChat.Image = global::WebChatApplication.Properties.Resources.WebChat;
            this.btnChat.Location = new System.Drawing.Point(164, 19);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(75, 48);
            this.btnChat.TabIndex = 2;
            this.btnChat.UseVisualStyleBackColor = true;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // rtbStatus
            // 
            this.rtbStatus.Location = new System.Drawing.Point(12, 569);
            this.rtbStatus.Name = "rtbStatus";
            this.rtbStatus.ReadOnly = true;
            this.rtbStatus.Size = new System.Drawing.Size(1021, 42);
            this.rtbStatus.TabIndex = 1;
            this.rtbStatus.Text = "";
            // 
            // gbChatWindow
            // 
            this.gbChatWindow.Controls.Add(this.btnSend);
            this.gbChatWindow.Controls.Add(this.rtbReplyFromAgent);
            this.gbChatWindow.Controls.Add(this.rtbChat);
            this.gbChatWindow.Location = new System.Drawing.Point(456, 12);
            this.gbChatWindow.Name = "gbChatWindow";
            this.gbChatWindow.Size = new System.Drawing.Size(577, 551);
            this.gbChatWindow.TabIndex = 2;
            this.gbChatWindow.TabStop = false;
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(251, 522);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // rtbReplyFromAgent
            // 
            this.rtbReplyFromAgent.Enabled = false;
            this.rtbReplyFromAgent.Location = new System.Drawing.Point(16, 423);
            this.rtbReplyFromAgent.Name = "rtbReplyFromAgent";
            this.rtbReplyFromAgent.Size = new System.Drawing.Size(545, 93);
            this.rtbReplyFromAgent.TabIndex = 1;
            this.rtbReplyFromAgent.Text = "";
            // 
            // rtbChat
            // 
            this.rtbChat.Enabled = false;
            this.rtbChat.Location = new System.Drawing.Point(16, 19);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.ReadOnly = true;
            this.rtbChat.Size = new System.Drawing.Size(545, 398);
            this.rtbChat.TabIndex = 0;
            this.rtbChat.Text = "";
            // 
            // WebChatApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 622);
            this.Controls.Add(this.gbChatWindow);
            this.Controls.Add(this.rtbStatus);
            this.Controls.Add(this.gbWebChat);
            this.Controls.Add(this.gbMDDetails);
            this.Controls.Add(this.gbAgentDetails);
            this.Controls.Add(this.gbEMCDetails);
            this.Name = "WebChatApplication";
            this.Text = "Web Chat Application";
            this.gbEMCDetails.ResumeLayout(false);
            this.gbEMCDetails.PerformLayout();
            this.gbAgentDetails.ResumeLayout(false);
            this.gbAgentDetails.PerformLayout();
            this.gbMDDetails.ResumeLayout(false);
            this.gbMDDetails.PerformLayout();
            this.gbWebChat.ResumeLayout(false);
            this.gbChatWindow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEMCDetails;
        private System.Windows.Forms.GroupBox gbAgentDetails;
        private System.Windows.Forms.GroupBox gbMDDetails;
        private System.Windows.Forms.GroupBox gbWebChat;
        private System.Windows.Forms.Label lblServerLinks;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.Label lblServerIP;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ComboBox cmbTServerLinks;
        private System.Windows.Forms.TextBox txtXMLServerPort;
        private System.Windows.Forms.TextBox txtXMLServerIP;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblAgentPwd;
        private System.Windows.Forms.Label lblAgentID;
        private System.Windows.Forms.Label lblStationID;
        private System.Windows.Forms.Button btnACW;
        private System.Windows.Forms.Button btnAux;
        private System.Windows.Forms.Button btnAvailable;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.TextBox txtStationID;
        private System.Windows.Forms.TextBox txtAgentID;
        private System.Windows.Forms.TextBox txtAgentPwd;
        private System.Windows.Forms.Label lblMDIP;
        private System.Windows.Forms.Label lblMDPort;
        private System.Windows.Forms.Label lblMPIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnMDConnect;
        private System.Windows.Forms.TextBox txtMPPort;
        private System.Windows.Forms.TextBox txtMPIP;
        private System.Windows.Forms.TextBox txtMDPort;
        private System.Windows.Forms.TextBox txtMDIP;
        private System.Windows.Forms.RichTextBox rtbStatus;
        private System.Windows.Forms.Button btnChat;
        private System.Windows.Forms.ToolTip myToolTip;
        private System.Windows.Forms.GroupBox gbChatWindow;
        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox rtbReplyFromAgent;
    }
}

