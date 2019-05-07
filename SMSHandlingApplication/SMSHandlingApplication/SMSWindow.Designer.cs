namespace SMSHandlingApplication
{
    partial class SMSWindow
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
            this.gbSMS = new System.Windows.Forms.GroupBox();
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.btnAcknowledge = new System.Windows.Forms.Button();
            this.gbSMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSMS
            // 
            this.gbSMS.Controls.Add(this.btnAcknowledge);
            this.gbSMS.Controls.Add(this.rtbChat);
            this.gbSMS.Location = new System.Drawing.Point(14, 12);
            this.gbSMS.Name = "gbSMS";
            this.gbSMS.Size = new System.Drawing.Size(271, 275);
            this.gbSMS.TabIndex = 0;
            this.gbSMS.TabStop = false;
            // 
            // rtbChat
            // 
            this.rtbChat.Location = new System.Drawing.Point(17, 19);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.Size = new System.Drawing.Size(237, 212);
            this.rtbChat.TabIndex = 0;
            this.rtbChat.Text = "";
            // 
            // btnAcknowledge
            // 
            this.btnAcknowledge.Location = new System.Drawing.Point(65, 237);
            this.btnAcknowledge.Name = "btnAcknowledge";
            this.btnAcknowledge.Size = new System.Drawing.Size(141, 23);
            this.btnAcknowledge.TabIndex = 1;
            this.btnAcknowledge.Text = "Send Acknowledgement";
            this.btnAcknowledge.UseVisualStyleBackColor = true;
            this.btnAcknowledge.Click += new System.EventHandler(this.btnAcknowledge_Click);
            // 
            // SMSWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 299);
            this.Controls.Add(this.gbSMS);
            this.Name = "SMSWindow";
            this.Text = "SMSWindow";
            this.gbSMS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSMS;
        private System.Windows.Forms.Button btnAcknowledge;
        private System.Windows.Forms.RichTextBox rtbChat;
    }
}