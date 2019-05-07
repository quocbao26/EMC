namespace VoiceCallHandlingApplication
{
    partial class VoiceCallHandlingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoiceCallHandlingForm));
            this.gbEMCDetails = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.cmbServerLink = new System.Windows.Forms.ComboBox();
            this.txtbServerPort = new System.Windows.Forms.TextBox();
            this.txtbServerIP = new System.Windows.Forms.TextBox();
            this.lblServerIP = new System.Windows.Forms.Label();
            this.lblServerPort = new System.Windows.Forms.Label();
            this.lblServerLink = new System.Windows.Forms.Label();
            this.gbAgentDetails = new System.Windows.Forms.GroupBox();
            this.btnACW = new System.Windows.Forms.Button();
            this.btnAux = new System.Windows.Forms.Button();
            this.btnAvailable = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnMonitorStart = new System.Windows.Forms.Button();
            this.txtbAgentPassword = new System.Windows.Forms.TextBox();
            this.txtbAgentID = new System.Windows.Forms.TextBox();
            this.txtbStationID = new System.Windows.Forms.TextBox();
            this.lblAgentPassword = new System.Windows.Forms.Label();
            this.lblAgentID = new System.Windows.Forms.Label();
            this.lblStationID = new System.Windows.Forms.Label();
            this.gbTelephony = new System.Windows.Forms.GroupBox();
            this.btnConference = new System.Windows.Forms.Button();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnHold = new System.Windows.Forms.Button();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.txtbTransferCall = new System.Windows.Forms.TextBox();
            this.btnHangUp = new System.Windows.Forms.Button();
            this.btnPlaceCall = new System.Windows.Forms.Button();
            this.txtbDialNumber = new System.Windows.Forms.TextBox();
            this.lblHoldTimer = new System.Windows.Forms.Label();
            this.lblCallTimer = new System.Windows.Forms.Label();
            this.lblIncomingCall = new System.Windows.Forms.Label();
            this.lblStation = new System.Windows.Forms.Label();
            this.rtbStatus = new System.Windows.Forms.RichTextBox();
            this.myToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.callTimer = new System.Windows.Forms.Timer(this.components);
            this.holdTimer = new System.Windows.Forms.Timer(this.components);
            this.gbEMCDetails.SuspendLayout();
            this.gbAgentDetails.SuspendLayout();
            this.gbTelephony.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEMCDetails
            // 
            this.gbEMCDetails.Controls.Add(this.btnConnect);
            this.gbEMCDetails.Controls.Add(this.btnBrowse);
            this.gbEMCDetails.Controls.Add(this.cmbServerLink);
            this.gbEMCDetails.Controls.Add(this.txtbServerPort);
            this.gbEMCDetails.Controls.Add(this.txtbServerIP);
            this.gbEMCDetails.Controls.Add(this.lblServerIP);
            this.gbEMCDetails.Controls.Add(this.lblServerPort);
            this.gbEMCDetails.Controls.Add(this.lblServerLink);
            this.gbEMCDetails.Location = new System.Drawing.Point(16, 15);
            this.gbEMCDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbEMCDetails.Name = "gbEMCDetails";
            this.gbEMCDetails.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbEMCDetails.Size = new System.Drawing.Size(609, 188);
            this.gbEMCDetails.TabIndex = 0;
            this.gbEMCDetails.TabStop = false;
            this.gbEMCDetails.Text = "EMC Details";
            // 
            // btnConnect
            // 
            this.btnConnect.Enabled = false;
            this.btnConnect.Location = new System.Drawing.Point(224, 142);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 28);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "Connect";
            this.myToolTip.SetToolTip(this.btnConnect, "Connect to XML Server");
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(399, 106);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(47, 28);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "...";
            this.myToolTip.SetToolTip(this.btnBrowse, "Browse for Available Links");
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // cmbServerLink
            // 
            this.cmbServerLink.FormattingEnabled = true;
            this.cmbServerLink.Location = new System.Drawing.Point(160, 108);
            this.cmbServerLink.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbServerLink.Name = "cmbServerLink";
            this.cmbServerLink.Size = new System.Drawing.Size(229, 24);
            this.cmbServerLink.TabIndex = 6;
            // 
            // txtbServerPort
            // 
            this.txtbServerPort.Location = new System.Drawing.Point(160, 73);
            this.txtbServerPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtbServerPort.Name = "txtbServerPort";
            this.txtbServerPort.Size = new System.Drawing.Size(229, 22);
            this.txtbServerPort.TabIndex = 5;
            this.txtbServerPort.Text = "29096";
            // 
            // txtbServerIP
            // 
            this.txtbServerIP.Location = new System.Drawing.Point(160, 37);
            this.txtbServerIP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtbServerIP.Name = "txtbServerIP";
            this.txtbServerIP.Size = new System.Drawing.Size(229, 22);
            this.txtbServerIP.TabIndex = 4;
            this.txtbServerIP.Text = "172.23.25.135";
            this.txtbServerIP.TextChanged += new System.EventHandler(this.txtbServerIP_TextChanged);
            // 
            // lblServerIP
            // 
            this.lblServerIP.AutoSize = true;
            this.lblServerIP.Location = new System.Drawing.Point(28, 41);
            this.lblServerIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServerIP.Name = "lblServerIP";
            this.lblServerIP.Size = new System.Drawing.Size(98, 17);
            this.lblServerIP.TabIndex = 1;
            this.lblServerIP.Text = "XML Server IP";
            // 
            // lblServerPort
            // 
            this.lblServerPort.AutoSize = true;
            this.lblServerPort.Location = new System.Drawing.Point(28, 76);
            this.lblServerPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServerPort.Name = "lblServerPort";
            this.lblServerPort.Size = new System.Drawing.Size(112, 17);
            this.lblServerPort.TabIndex = 2;
            this.lblServerPort.Text = "XML Server Port";
            // 
            // lblServerLink
            // 
            this.lblServerLink.AutoSize = true;
            this.lblServerLink.Location = new System.Drawing.Point(28, 112);
            this.lblServerLink.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServerLink.Name = "lblServerLink";
            this.lblServerLink.Size = new System.Drawing.Size(41, 17);
            this.lblServerLink.TabIndex = 3;
            this.lblServerLink.Text = "Links";
            // 
            // gbAgentDetails
            // 
            this.gbAgentDetails.Controls.Add(this.btnACW);
            this.gbAgentDetails.Controls.Add(this.btnAux);
            this.gbAgentDetails.Controls.Add(this.btnAvailable);
            this.gbAgentDetails.Controls.Add(this.btnLogin);
            this.gbAgentDetails.Controls.Add(this.btnMonitorStart);
            this.gbAgentDetails.Controls.Add(this.txtbAgentPassword);
            this.gbAgentDetails.Controls.Add(this.txtbAgentID);
            this.gbAgentDetails.Controls.Add(this.txtbStationID);
            this.gbAgentDetails.Controls.Add(this.lblAgentPassword);
            this.gbAgentDetails.Controls.Add(this.lblAgentID);
            this.gbAgentDetails.Controls.Add(this.lblStationID);
            this.gbAgentDetails.Enabled = false;
            this.gbAgentDetails.Location = new System.Drawing.Point(16, 231);
            this.gbAgentDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbAgentDetails.Name = "gbAgentDetails";
            this.gbAgentDetails.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbAgentDetails.Size = new System.Drawing.Size(609, 206);
            this.gbAgentDetails.TabIndex = 0;
            this.gbAgentDetails.TabStop = false;
            this.gbAgentDetails.Text = "Agent Details";
            // 
            // btnACW
            // 
            this.btnACW.Enabled = false;
            this.btnACW.Image = ((System.Drawing.Image)(resources.GetObject("btnACW.Image")));
            this.btnACW.Location = new System.Drawing.Point(363, 155);
            this.btnACW.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnACW.Name = "btnACW";
            this.btnACW.Size = new System.Drawing.Size(61, 43);
            this.btnACW.TabIndex = 10;
            this.myToolTip.SetToolTip(this.btnACW, "After Call Work");
            this.btnACW.UseVisualStyleBackColor = true;
            this.btnACW.Click += new System.EventHandler(this.btnACW_Click);
            // 
            // btnAux
            // 
            this.btnAux.Enabled = false;
            this.btnAux.Image = ((System.Drawing.Image)(resources.GetObject("btnAux.Image")));
            this.btnAux.Location = new System.Drawing.Point(293, 155);
            this.btnAux.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAux.Name = "btnAux";
            this.btnAux.Size = new System.Drawing.Size(61, 43);
            this.btnAux.TabIndex = 9;
            this.myToolTip.SetToolTip(this.btnAux, "Auxillary");
            this.btnAux.UseVisualStyleBackColor = true;
            this.btnAux.Click += new System.EventHandler(this.btnAux_Click);
            // 
            // btnAvailable
            // 
            this.btnAvailable.Enabled = false;
            this.btnAvailable.Image = ((System.Drawing.Image)(resources.GetObject("btnAvailable.Image")));
            this.btnAvailable.Location = new System.Drawing.Point(224, 155);
            this.btnAvailable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAvailable.Name = "btnAvailable";
            this.btnAvailable.Size = new System.Drawing.Size(61, 43);
            this.btnAvailable.TabIndex = 8;
            this.myToolTip.SetToolTip(this.btnAvailable, "Available");
            this.btnAvailable.UseVisualStyleBackColor = true;
            this.btnAvailable.Click += new System.EventHandler(this.btnAvailable_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Enabled = false;
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.Location = new System.Drawing.Point(155, 155);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(61, 43);
            this.btnLogin.TabIndex = 7;
            this.myToolTip.SetToolTip(this.btnLogin, "Agent Login");
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnMonitorStart
            // 
            this.btnMonitorStart.Location = new System.Drawing.Point(399, 42);
            this.btnMonitorStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMonitorStart.Name = "btnMonitorStart";
            this.btnMonitorStart.Size = new System.Drawing.Size(136, 28);
            this.btnMonitorStart.TabIndex = 6;
            this.btnMonitorStart.Text = "Monitor Start";
            this.btnMonitorStart.UseVisualStyleBackColor = true;
            this.btnMonitorStart.Click += new System.EventHandler(this.btnMonitorStart_Click);
            // 
            // txtbAgentPassword
            // 
            this.txtbAgentPassword.Location = new System.Drawing.Point(160, 122);
            this.txtbAgentPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtbAgentPassword.Name = "txtbAgentPassword";
            this.txtbAgentPassword.PasswordChar = '*';
            this.txtbAgentPassword.Size = new System.Drawing.Size(229, 22);
            this.txtbAgentPassword.TabIndex = 5;
            // 
            // txtbAgentID
            // 
            this.txtbAgentID.Location = new System.Drawing.Point(160, 81);
            this.txtbAgentID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtbAgentID.Name = "txtbAgentID";
            this.txtbAgentID.Size = new System.Drawing.Size(229, 22);
            this.txtbAgentID.TabIndex = 4;
            // 
            // txtbStationID
            // 
            this.txtbStationID.Location = new System.Drawing.Point(160, 44);
            this.txtbStationID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtbStationID.Name = "txtbStationID";
            this.txtbStationID.Size = new System.Drawing.Size(229, 22);
            this.txtbStationID.TabIndex = 3;
            // 
            // lblAgentPassword
            // 
            this.lblAgentPassword.AutoSize = true;
            this.lblAgentPassword.Location = new System.Drawing.Point(28, 126);
            this.lblAgentPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAgentPassword.Name = "lblAgentPassword";
            this.lblAgentPassword.Size = new System.Drawing.Size(110, 17);
            this.lblAgentPassword.TabIndex = 2;
            this.lblAgentPassword.Text = "Agent Password";
            // 
            // lblAgentID
            // 
            this.lblAgentID.AutoSize = true;
            this.lblAgentID.Location = new System.Drawing.Point(28, 90);
            this.lblAgentID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAgentID.Name = "lblAgentID";
            this.lblAgentID.Size = new System.Drawing.Size(62, 17);
            this.lblAgentID.TabIndex = 1;
            this.lblAgentID.Text = "Agent ID";
            // 
            // lblStationID
            // 
            this.lblStationID.AutoSize = true;
            this.lblStationID.Location = new System.Drawing.Point(28, 53);
            this.lblStationID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStationID.Name = "lblStationID";
            this.lblStationID.Size = new System.Drawing.Size(69, 17);
            this.lblStationID.TabIndex = 0;
            this.lblStationID.Text = "Station ID";
            // 
            // gbTelephony
            // 
            this.gbTelephony.Controls.Add(this.btnConference);
            this.gbTelephony.Controls.Add(this.btnTransfer);
            this.gbTelephony.Controls.Add(this.btnHold);
            this.gbTelephony.Controls.Add(this.cmbType);
            this.gbTelephony.Controls.Add(this.txtbTransferCall);
            this.gbTelephony.Controls.Add(this.btnHangUp);
            this.gbTelephony.Controls.Add(this.btnPlaceCall);
            this.gbTelephony.Controls.Add(this.txtbDialNumber);
            this.gbTelephony.Controls.Add(this.lblHoldTimer);
            this.gbTelephony.Controls.Add(this.lblCallTimer);
            this.gbTelephony.Controls.Add(this.lblIncomingCall);
            this.gbTelephony.Controls.Add(this.lblStation);
            this.gbTelephony.Enabled = false;
            this.gbTelephony.Location = new System.Drawing.Point(16, 465);
            this.gbTelephony.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbTelephony.Name = "gbTelephony";
            this.gbTelephony.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbTelephony.Size = new System.Drawing.Size(609, 158);
            this.gbTelephony.TabIndex = 0;
            this.gbTelephony.TabStop = false;
            this.gbTelephony.Text = "Telephony";
            // 
            // btnConference
            // 
            this.btnConference.Enabled = false;
            this.btnConference.Image = ((System.Drawing.Image)(resources.GetObject("btnConference.Image")));
            this.btnConference.Location = new System.Drawing.Point(519, 101);
            this.btnConference.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConference.Name = "btnConference";
            this.btnConference.Size = new System.Drawing.Size(64, 48);
            this.btnConference.TabIndex = 11;
            this.myToolTip.SetToolTip(this.btnConference, "Conference");
            this.btnConference.UseVisualStyleBackColor = true;
            this.btnConference.Click += new System.EventHandler(this.btnConference_Click);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Enabled = false;
            this.btnTransfer.Image = ((System.Drawing.Image)(resources.GetObject("btnTransfer.Image")));
            this.btnTransfer.Location = new System.Drawing.Point(447, 101);
            this.btnTransfer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(64, 48);
            this.btnTransfer.TabIndex = 10;
            this.myToolTip.SetToolTip(this.btnTransfer, "Transfer");
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnHold
            // 
            this.btnHold.Enabled = false;
            this.btnHold.Image = ((System.Drawing.Image)(resources.GetObject("btnHold.Image")));
            this.btnHold.Location = new System.Drawing.Point(377, 101);
            this.btnHold.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHold.Name = "btnHold";
            this.btnHold.Size = new System.Drawing.Size(64, 48);
            this.btnHold.TabIndex = 9;
            this.myToolTip.SetToolTip(this.btnHold, "Hold");
            this.btnHold.UseVisualStyleBackColor = true;
            this.btnHold.Click += new System.EventHandler(this.btnHold_Click);
            // 
            // cmbType
            // 
            this.cmbType.Enabled = false;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(183, 113);
            this.cmbType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(160, 24);
            this.cmbType.TabIndex = 8;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // txtbTransferCall
            // 
            this.txtbTransferCall.Enabled = false;
            this.txtbTransferCall.ForeColor = System.Drawing.Color.Blue;
            this.txtbTransferCall.Location = new System.Drawing.Point(32, 113);
            this.txtbTransferCall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtbTransferCall.Name = "txtbTransferCall";
            this.txtbTransferCall.Size = new System.Drawing.Size(132, 22);
            this.txtbTransferCall.TabIndex = 7;
            this.txtbTransferCall.Text = "Enter Number";
            // 
            // btnHangUp
            // 
            this.btnHangUp.Enabled = false;
            this.btnHangUp.Image = ((System.Drawing.Image)(resources.GetObject("btnHangUp.Image")));
            this.btnHangUp.Location = new System.Drawing.Point(447, 28);
            this.btnHangUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHangUp.Name = "btnHangUp";
            this.btnHangUp.Size = new System.Drawing.Size(64, 48);
            this.btnHangUp.TabIndex = 6;
            this.myToolTip.SetToolTip(this.btnHangUp, "Hang Up");
            this.btnHangUp.UseVisualStyleBackColor = true;
            this.btnHangUp.Click += new System.EventHandler(this.btnHangUp_Click);
            // 
            // btnPlaceCall
            // 
            this.btnPlaceCall.Enabled = false;
            this.btnPlaceCall.Image = ((System.Drawing.Image)(resources.GetObject("btnPlaceCall.Image")));
            this.btnPlaceCall.Location = new System.Drawing.Point(377, 28);
            this.btnPlaceCall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPlaceCall.Name = "btnPlaceCall";
            this.btnPlaceCall.Size = new System.Drawing.Size(64, 48);
            this.btnPlaceCall.TabIndex = 5;
            this.myToolTip.SetToolTip(this.btnPlaceCall, "Make Call");
            this.btnPlaceCall.UseVisualStyleBackColor = true;
            this.btnPlaceCall.Click += new System.EventHandler(this.btnPlaceCall_Click);
            // 
            // txtbDialNumber
            // 
            this.txtbDialNumber.ForeColor = System.Drawing.Color.Blue;
            this.txtbDialNumber.Location = new System.Drawing.Point(224, 41);
            this.txtbDialNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtbDialNumber.Name = "txtbDialNumber";
            this.txtbDialNumber.Size = new System.Drawing.Size(132, 22);
            this.txtbDialNumber.TabIndex = 4;
            this.txtbDialNumber.Text = "Enter Number";
            // 
            // lblHoldTimer
            // 
            this.lblHoldTimer.AutoSize = true;
            this.lblHoldTimer.ForeColor = System.Drawing.Color.Red;
            this.lblHoldTimer.Location = new System.Drawing.Point(71, 76);
            this.lblHoldTimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHoldTimer.Name = "lblHoldTimer";
            this.lblHoldTimer.Size = new System.Drawing.Size(0, 17);
            this.lblHoldTimer.TabIndex = 3;
            // 
            // lblCallTimer
            // 
            this.lblCallTimer.AutoSize = true;
            this.lblCallTimer.ForeColor = System.Drawing.Color.Red;
            this.lblCallTimer.Location = new System.Drawing.Point(179, 76);
            this.lblCallTimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCallTimer.Name = "lblCallTimer";
            this.lblCallTimer.Size = new System.Drawing.Size(0, 17);
            this.lblCallTimer.TabIndex = 2;
            // 
            // lblIncomingCall
            // 
            this.lblIncomingCall.AutoSize = true;
            this.lblIncomingCall.Location = new System.Drawing.Point(129, 41);
            this.lblIncomingCall.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIncomingCall.Name = "lblIncomingCall";
            this.lblIncomingCall.Size = new System.Drawing.Size(0, 17);
            this.lblIncomingCall.TabIndex = 1;
            // 
            // lblStation
            // 
            this.lblStation.AutoSize = true;
            this.lblStation.Location = new System.Drawing.Point(28, 41);
            this.lblStation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStation.Name = "lblStation";
            this.lblStation.Size = new System.Drawing.Size(0, 17);
            this.lblStation.TabIndex = 0;
            // 
            // rtbStatus
            // 
            this.rtbStatus.Enabled = false;
            this.rtbStatus.Location = new System.Drawing.Point(16, 630);
            this.rtbStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbStatus.Name = "rtbStatus";
            this.rtbStatus.Size = new System.Drawing.Size(608, 98);
            this.rtbStatus.TabIndex = 1;
            this.rtbStatus.Text = "";
            // 
            // callTimer
            // 
            this.callTimer.Interval = 1000;
            this.callTimer.Tick += new System.EventHandler(this.callTimer_Tick);
            // 
            // holdTimer
            // 
            this.holdTimer.Interval = 1000;
            this.holdTimer.Tick += new System.EventHandler(this.holdTimer_Tick);
            // 
            // VoiceCallHandlingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 737);
            this.Controls.Add(this.rtbStatus);
            this.Controls.Add(this.gbAgentDetails);
            this.Controls.Add(this.gbTelephony);
            this.Controls.Add(this.gbEMCDetails);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "VoiceCallHandlingForm";
            this.Text = "Voice Call Handling Application";
            this.gbEMCDetails.ResumeLayout(false);
            this.gbEMCDetails.PerformLayout();
            this.gbAgentDetails.ResumeLayout(false);
            this.gbAgentDetails.PerformLayout();
            this.gbTelephony.ResumeLayout(false);
            this.gbTelephony.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEMCDetails;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ComboBox cmbServerLink;
        private System.Windows.Forms.TextBox txtbServerPort;
        private System.Windows.Forms.TextBox txtbServerIP;
        private System.Windows.Forms.Label lblServerIP;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.Label lblServerLink;
        private System.Windows.Forms.GroupBox gbAgentDetails;
        private System.Windows.Forms.TextBox txtbAgentPassword;
        private System.Windows.Forms.TextBox txtbAgentID;
        private System.Windows.Forms.TextBox txtbStationID;
        private System.Windows.Forms.Label lblAgentPassword;
        private System.Windows.Forms.Label lblAgentID;
        private System.Windows.Forms.Label lblStationID;
        private System.Windows.Forms.GroupBox gbTelephony;
        private System.Windows.Forms.Button btnACW;
        private System.Windows.Forms.Button btnAux;
        private System.Windows.Forms.Button btnAvailable;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnMonitorStart;
        private System.Windows.Forms.Button btnConference;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnHold;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtbTransferCall;
        private System.Windows.Forms.Button btnHangUp;
        private System.Windows.Forms.Button btnPlaceCall;
        private System.Windows.Forms.TextBox txtbDialNumber;
        private System.Windows.Forms.Label lblHoldTimer;
        private System.Windows.Forms.Label lblCallTimer;
        private System.Windows.Forms.Label lblIncomingCall;
        private System.Windows.Forms.Label lblStation;
        private System.Windows.Forms.RichTextBox rtbStatus;
        private System.Windows.Forms.ToolTip myToolTip;
        private System.Windows.Forms.Timer callTimer;
        private System.Windows.Forms.Timer holdTimer;
    }
}

