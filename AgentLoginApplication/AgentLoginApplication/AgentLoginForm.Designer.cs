namespace AgentLoginApplication
{
    partial class AgentLoginForm
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
            this.lblAgentLoginLogout = new System.Windows.Forms.Label();
            this.lblServerIP = new System.Windows.Forms.Label();
            this.lblServerPort = new System.Windows.Forms.Label();
            this.lblServerLink = new System.Windows.Forms.Label();
            this.txtbServerIP = new System.Windows.Forms.TextBox();
            this.txtbServerPort = new System.Windows.Forms.TextBox();
            this.cmbServerLink = new System.Windows.Forms.ComboBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblStationID = new System.Windows.Forms.Label();
            this.lblAgentID = new System.Windows.Forms.Label();
            this.lblAgentPassword = new System.Windows.Forms.Label();
            this.txtbStationID = new System.Windows.Forms.TextBox();
            this.txtbAgentID = new System.Windows.Forms.TextBox();
            this.txtbAgentPassword = new System.Windows.Forms.TextBox();
            this.btnMonitorStart = new System.Windows.Forms.Button();
            this.rtbStatus = new System.Windows.Forms.RichTextBox();
            this.myToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnACW = new System.Windows.Forms.Button();
            this.btnAux = new System.Windows.Forms.Button();
            this.btnAvailable = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.gbEMCDetails = new System.Windows.Forms.GroupBox();
            this.gbAgentDetails = new System.Windows.Forms.GroupBox();
            this.gbEMCDetails.SuspendLayout();
            this.gbAgentDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAgentLoginLogout
            // 
            this.lblAgentLoginLogout.AutoSize = true;
            this.lblAgentLoginLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgentLoginLogout.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblAgentLoginLogout.Location = new System.Drawing.Point(141, 9);
            this.lblAgentLoginLogout.Name = "lblAgentLoginLogout";
            this.lblAgentLoginLogout.Size = new System.Drawing.Size(180, 16);
            this.lblAgentLoginLogout.TabIndex = 0;
            this.lblAgentLoginLogout.Text = "Agent Login Logout Form";
            // 
            // lblServerIP
            // 
            this.lblServerIP.AutoSize = true;
            this.lblServerIP.Location = new System.Drawing.Point(25, 34);
            this.lblServerIP.Name = "lblServerIP";
            this.lblServerIP.Size = new System.Drawing.Size(51, 13);
            this.lblServerIP.TabIndex = 1;
            this.lblServerIP.Text = "Server IP";
            // 
            // lblServerPort
            // 
            this.lblServerPort.AutoSize = true;
            this.lblServerPort.Location = new System.Drawing.Point(25, 72);
            this.lblServerPort.Name = "lblServerPort";
            this.lblServerPort.Size = new System.Drawing.Size(60, 13);
            this.lblServerPort.TabIndex = 2;
            this.lblServerPort.Text = "Server Port";
            // 
            // lblServerLink
            // 
            this.lblServerLink.AutoSize = true;
            this.lblServerLink.Location = new System.Drawing.Point(25, 110);
            this.lblServerLink.Name = "lblServerLink";
            this.lblServerLink.Size = new System.Drawing.Size(27, 13);
            this.lblServerLink.TabIndex = 3;
            this.lblServerLink.Text = "Link";
            // 
            // txtbServerIP
            // 
            this.txtbServerIP.Location = new System.Drawing.Point(115, 31);
            this.txtbServerIP.Name = "txtbServerIP";
            this.txtbServerIP.Size = new System.Drawing.Size(213, 20);
            this.txtbServerIP.TabIndex = 4;
            this.txtbServerIP.Text = "148.147.170.26";
            // 
            // txtbServerPort
            // 
            this.txtbServerPort.Location = new System.Drawing.Point(115, 69);
            this.txtbServerPort.Name = "txtbServerPort";
            this.txtbServerPort.Size = new System.Drawing.Size(213, 20);
            this.txtbServerPort.TabIndex = 5;
            this.txtbServerPort.Text = "29096";
            // 
            // cmbServerLink
            // 
            this.cmbServerLink.FormattingEnabled = true;
            this.cmbServerLink.Location = new System.Drawing.Point(115, 104);
            this.cmbServerLink.Name = "cmbServerLink";
            this.cmbServerLink.Size = new System.Drawing.Size(213, 21);
            this.cmbServerLink.TabIndex = 6;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(334, 102);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(31, 23);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "...";
            this.myToolTip.SetToolTip(this.btnBrowse, "Browse for Available Links");
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Enabled = false;
            this.btnConnect.Location = new System.Drawing.Point(150, 131);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(138, 23);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "Connect";
            this.myToolTip.SetToolTip(this.btnConnect, " Connect to XML Server");
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblStationID
            // 
            this.lblStationID.AutoSize = true;
            this.lblStationID.Enabled = false;
            this.lblStationID.Location = new System.Drawing.Point(6, 30);
            this.lblStationID.Name = "lblStationID";
            this.lblStationID.Size = new System.Drawing.Size(54, 13);
            this.lblStationID.TabIndex = 11;
            this.lblStationID.Text = "Station ID";
            // 
            // lblAgentID
            // 
            this.lblAgentID.AutoSize = true;
            this.lblAgentID.Enabled = false;
            this.lblAgentID.Location = new System.Drawing.Point(6, 67);
            this.lblAgentID.Name = "lblAgentID";
            this.lblAgentID.Size = new System.Drawing.Size(49, 13);
            this.lblAgentID.TabIndex = 12;
            this.lblAgentID.Text = "Agent ID";
            // 
            // lblAgentPassword
            // 
            this.lblAgentPassword.AutoSize = true;
            this.lblAgentPassword.Enabled = false;
            this.lblAgentPassword.Location = new System.Drawing.Point(6, 102);
            this.lblAgentPassword.Name = "lblAgentPassword";
            this.lblAgentPassword.Size = new System.Drawing.Size(84, 13);
            this.lblAgentPassword.TabIndex = 13;
            this.lblAgentPassword.Text = "Agent Password";
            // 
            // txtbStationID
            // 
            this.txtbStationID.Enabled = false;
            this.txtbStationID.Location = new System.Drawing.Point(115, 27);
            this.txtbStationID.Name = "txtbStationID";
            this.txtbStationID.Size = new System.Drawing.Size(213, 20);
            this.txtbStationID.TabIndex = 14;
            // 
            // txtbAgentID
            // 
            this.txtbAgentID.Enabled = false;
            this.txtbAgentID.Location = new System.Drawing.Point(115, 57);
            this.txtbAgentID.Name = "txtbAgentID";
            this.txtbAgentID.Size = new System.Drawing.Size(213, 20);
            this.txtbAgentID.TabIndex = 15;
            // 
            // txtbAgentPassword
            // 
            this.txtbAgentPassword.Enabled = false;
            this.txtbAgentPassword.Location = new System.Drawing.Point(115, 96);
            this.txtbAgentPassword.Name = "txtbAgentPassword";
            this.txtbAgentPassword.PasswordChar = '*';
            this.txtbAgentPassword.Size = new System.Drawing.Size(213, 20);
            this.txtbAgentPassword.TabIndex = 16;
            // 
            // btnMonitorStart
            // 
            this.btnMonitorStart.Enabled = false;
            this.btnMonitorStart.Location = new System.Drawing.Point(346, 24);
            this.btnMonitorStart.Name = "btnMonitorStart";
            this.btnMonitorStart.Size = new System.Drawing.Size(75, 23);
            this.btnMonitorStart.TabIndex = 17;
            this.btnMonitorStart.Text = "Monitor Start";
            this.btnMonitorStart.UseVisualStyleBackColor = true;
            this.btnMonitorStart.Click += new System.EventHandler(this.btnMonitorStart_Click);
            // 
            // rtbStatus
            // 
            this.rtbStatus.Location = new System.Drawing.Point(1, 417);
            this.rtbStatus.Name = "rtbStatus";
            this.rtbStatus.ReadOnly = true;
            this.rtbStatus.Size = new System.Drawing.Size(464, 77);
            this.rtbStatus.TabIndex = 25;
            this.rtbStatus.Text = "";
            // 
            // btnACW
            // 
            this.btnACW.Enabled = false;
            this.btnACW.Image = global::AgentLoginApplication.Properties.Resources.ACW;
            this.btnACW.Location = new System.Drawing.Point(276, 134);
            this.btnACW.Name = "btnACW";
            this.btnACW.Size = new System.Drawing.Size(39, 30);
            this.btnACW.TabIndex = 23;
            this.myToolTip.SetToolTip(this.btnACW, "After Call Work");
            this.btnACW.UseVisualStyleBackColor = true;
            this.btnACW.Click += new System.EventHandler(this.btnACW_Click);
            // 
            // btnAux
            // 
            this.btnAux.Enabled = false;
            this.btnAux.Image = global::AgentLoginApplication.Properties.Resources.Auximg;
            this.btnAux.Location = new System.Drawing.Point(225, 134);
            this.btnAux.Name = "btnAux";
            this.btnAux.Size = new System.Drawing.Size(39, 30);
            this.btnAux.TabIndex = 22;
            this.myToolTip.SetToolTip(this.btnAux, "Auxillary");
            this.btnAux.UseVisualStyleBackColor = true;
            this.btnAux.Click += new System.EventHandler(this.btnAux_Click);
            // 
            // btnAvailable
            // 
            this.btnAvailable.Enabled = false;
            this.btnAvailable.Image = global::AgentLoginApplication.Properties.Resources.Available;
            this.btnAvailable.Location = new System.Drawing.Point(174, 134);
            this.btnAvailable.Name = "btnAvailable";
            this.btnAvailable.Size = new System.Drawing.Size(39, 30);
            this.btnAvailable.TabIndex = 21;
            this.myToolTip.SetToolTip(this.btnAvailable, "Available");
            this.btnAvailable.UseVisualStyleBackColor = true;
            this.btnAvailable.Click += new System.EventHandler(this.btnAvailable_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Enabled = false;
            this.btnLogin.Image = global::AgentLoginApplication.Properties.Resources.login;
            this.btnLogin.Location = new System.Drawing.Point(123, 134);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(39, 30);
            this.btnLogin.TabIndex = 18;
            this.myToolTip.SetToolTip(this.btnLogin, "Agent Login");
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // gbEMCDetails
            // 
            this.gbEMCDetails.Controls.Add(this.lblServerIP);
            this.gbEMCDetails.Controls.Add(this.lblServerPort);
            this.gbEMCDetails.Controls.Add(this.lblServerLink);
            this.gbEMCDetails.Controls.Add(this.txtbServerIP);
            this.gbEMCDetails.Controls.Add(this.txtbServerPort);
            this.gbEMCDetails.Controls.Add(this.cmbServerLink);
            this.gbEMCDetails.Controls.Add(this.btnBrowse);
            this.gbEMCDetails.Controls.Add(this.btnConnect);
            this.gbEMCDetails.Location = new System.Drawing.Point(12, 40);
            this.gbEMCDetails.Name = "gbEMCDetails";
            this.gbEMCDetails.Size = new System.Drawing.Size(439, 169);
            this.gbEMCDetails.TabIndex = 26;
            this.gbEMCDetails.TabStop = false;
            this.gbEMCDetails.Text = "EMC Details";
            // 
            // gbAgentDetails
            // 
            this.gbAgentDetails.Controls.Add(this.lblStationID);
            this.gbAgentDetails.Controls.Add(this.lblAgentID);
            this.gbAgentDetails.Controls.Add(this.lblAgentPassword);
            this.gbAgentDetails.Controls.Add(this.btnACW);
            this.gbAgentDetails.Controls.Add(this.txtbStationID);
            this.gbAgentDetails.Controls.Add(this.btnAux);
            this.gbAgentDetails.Controls.Add(this.txtbAgentID);
            this.gbAgentDetails.Controls.Add(this.btnAvailable);
            this.gbAgentDetails.Controls.Add(this.txtbAgentPassword);
            this.gbAgentDetails.Controls.Add(this.btnLogin);
            this.gbAgentDetails.Controls.Add(this.btnMonitorStart);
            this.gbAgentDetails.Enabled = false;
            this.gbAgentDetails.Location = new System.Drawing.Point(12, 231);
            this.gbAgentDetails.Name = "gbAgentDetails";
            this.gbAgentDetails.Size = new System.Drawing.Size(439, 169);
            this.gbAgentDetails.TabIndex = 27;
            this.gbAgentDetails.TabStop = false;
            this.gbAgentDetails.Text = "Agent Details";
            // 
            // AgentLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 490);
            this.Controls.Add(this.gbAgentDetails);
            this.Controls.Add(this.gbEMCDetails);
            this.Controls.Add(this.rtbStatus);
            this.Controls.Add(this.lblAgentLoginLogout);
            this.Name = "AgentLoginForm";
            this.Text = "Agent Login Application";
            this.gbEMCDetails.ResumeLayout(false);
            this.gbEMCDetails.PerformLayout();
            this.gbAgentDetails.ResumeLayout(false);
            this.gbAgentDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAgentLoginLogout;
        private System.Windows.Forms.Label lblServerIP;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.Label lblServerLink;
        private System.Windows.Forms.TextBox txtbServerIP;
        private System.Windows.Forms.TextBox txtbServerPort;
        private System.Windows.Forms.ComboBox cmbServerLink;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblStationID;
        private System.Windows.Forms.Label lblAgentID;
        private System.Windows.Forms.Label lblAgentPassword;
        private System.Windows.Forms.TextBox txtbStationID;
        private System.Windows.Forms.TextBox txtbAgentID;
        private System.Windows.Forms.TextBox txtbAgentPassword;
        private System.Windows.Forms.Button btnMonitorStart;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnAvailable;
        private System.Windows.Forms.Button btnAux;
        private System.Windows.Forms.Button btnACW;
        private System.Windows.Forms.RichTextBox rtbStatus;
        private System.Windows.Forms.ToolTip myToolTip;
        private System.Windows.Forms.GroupBox gbEMCDetails;
        private System.Windows.Forms.GroupBox gbAgentDetails;
    }
}

