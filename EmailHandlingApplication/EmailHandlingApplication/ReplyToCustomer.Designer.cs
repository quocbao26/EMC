namespace EmailHandlingApplication
{
    partial class ReplyToCustomer
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
            this.gbReplyForm = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.rtbBody = new System.Windows.Forms.RichTextBox();
            this.lstReplyAttachments = new System.Windows.Forms.ListBox();
            this.txtTo = new System.Windows.Forms.RichTextBox();
            this.txtCc = new System.Windows.Forms.RichTextBox();
            this.txtBcc = new System.Windows.Forms.RichTextBox();
            this.txtSubject = new System.Windows.Forms.RichTextBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.lblAttachment = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblBcc = new System.Windows.Forms.Label();
            this.lblCc = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.myToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.wbOriginalBody = new System.Windows.Forms.WebBrowser();
            this.gbReplyForm.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbReplyForm
            // 
            this.gbReplyForm.Controls.Add(this.panel1);
            this.gbReplyForm.Controls.Add(this.btnSend);
            this.gbReplyForm.Controls.Add(this.rtbBody);
            this.gbReplyForm.Controls.Add(this.lstReplyAttachments);
            this.gbReplyForm.Controls.Add(this.txtTo);
            this.gbReplyForm.Controls.Add(this.txtCc);
            this.gbReplyForm.Controls.Add(this.txtBcc);
            this.gbReplyForm.Controls.Add(this.txtSubject);
            this.gbReplyForm.Controls.Add(this.txtFrom);
            this.gbReplyForm.Controls.Add(this.lblAttachment);
            this.gbReplyForm.Controls.Add(this.lblSubject);
            this.gbReplyForm.Controls.Add(this.lblBcc);
            this.gbReplyForm.Controls.Add(this.lblCc);
            this.gbReplyForm.Controls.Add(this.lblTo);
            this.gbReplyForm.Controls.Add(this.lblFrom);
            this.gbReplyForm.Location = new System.Drawing.Point(12, 12);
            this.gbReplyForm.Name = "gbReplyForm";
            this.gbReplyForm.Size = new System.Drawing.Size(458, 700);
            this.gbReplyForm.TabIndex = 0;
            this.gbReplyForm.TabStop = false;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(190, 667);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 14;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // rtbBody
            // 
            this.rtbBody.Location = new System.Drawing.Point(26, 232);
            this.rtbBody.Name = "rtbBody";
            this.rtbBody.Size = new System.Drawing.Size(411, 233);
            this.rtbBody.TabIndex = 0;
            this.rtbBody.Text = "";
            // 
            // lstReplyAttachments
            // 
            this.lstReplyAttachments.FormattingEnabled = true;
            this.lstReplyAttachments.Location = new System.Drawing.Point(96, 168);
            this.lstReplyAttachments.Name = "lstReplyAttachments";
            this.lstReplyAttachments.Size = new System.Drawing.Size(341, 43);
            this.lstReplyAttachments.TabIndex = 11;
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(96, 59);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(341, 19);
            this.txtTo.TabIndex = 10;
            this.txtTo.Text = "";
            // 
            // txtCc
            // 
            this.txtCc.Location = new System.Drawing.Point(96, 87);
            this.txtCc.Name = "txtCc";
            this.txtCc.Size = new System.Drawing.Size(341, 19);
            this.txtCc.TabIndex = 9;
            this.txtCc.Text = "";
            // 
            // txtBcc
            // 
            this.txtBcc.Location = new System.Drawing.Point(96, 115);
            this.txtBcc.Name = "txtBcc";
            this.txtBcc.Size = new System.Drawing.Size(341, 19);
            this.txtBcc.TabIndex = 8;
            this.txtBcc.Text = "";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(96, 143);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(341, 19);
            this.txtSubject.TabIndex = 7;
            this.txtSubject.Text = "";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(96, 33);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.ReadOnly = true;
            this.txtFrom.Size = new System.Drawing.Size(341, 20);
            this.txtFrom.TabIndex = 6;
            // 
            // lblAttachment
            // 
            this.lblAttachment.AutoSize = true;
            this.lblAttachment.Location = new System.Drawing.Point(23, 175);
            this.lblAttachment.Name = "lblAttachment";
            this.lblAttachment.Size = new System.Drawing.Size(61, 13);
            this.lblAttachment.TabIndex = 5;
            this.lblAttachment.Text = "Attachment";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(23, 148);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(43, 13);
            this.lblSubject.TabIndex = 4;
            this.lblSubject.Text = "Subject";
            // 
            // lblBcc
            // 
            this.lblBcc.AutoSize = true;
            this.lblBcc.Location = new System.Drawing.Point(27, 121);
            this.lblBcc.Name = "lblBcc";
            this.lblBcc.Size = new System.Drawing.Size(26, 13);
            this.lblBcc.TabIndex = 3;
            this.lblBcc.Text = "Bcc";
            // 
            // lblCc
            // 
            this.lblCc.AutoSize = true;
            this.lblCc.Location = new System.Drawing.Point(27, 94);
            this.lblCc.Name = "lblCc";
            this.lblCc.Size = new System.Drawing.Size(20, 13);
            this.lblCc.TabIndex = 2;
            this.lblCc.Text = "Cc";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(27, 67);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 13);
            this.lblTo.TabIndex = 1;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(27, 40);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(30, 13);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.wbOriginalBody);
            this.panel1.Location = new System.Drawing.Point(26, 480);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 172);
            this.panel1.TabIndex = 15;
            // 
            // wbOriginalBody
            // 
            this.wbOriginalBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbOriginalBody.Location = new System.Drawing.Point(0, 0);
            this.wbOriginalBody.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbOriginalBody.Name = "wbOriginalBody";
            this.wbOriginalBody.Size = new System.Drawing.Size(411, 172);
            this.wbOriginalBody.TabIndex = 0;
            // 
            // ReplyToCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 723);
            this.Controls.Add(this.gbReplyForm);
            this.Name = "ReplyToCustomer";
            this.Text = "ReplyToCustomer";
            this.gbReplyForm.ResumeLayout(false);
            this.gbReplyForm.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbReplyForm;
        private System.Windows.Forms.ListBox lstReplyAttachments;
        private System.Windows.Forms.RichTextBox txtTo;
        private System.Windows.Forms.RichTextBox txtCc;
        private System.Windows.Forms.RichTextBox txtBcc;
        private System.Windows.Forms.RichTextBox txtSubject;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label lblAttachment;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblBcc;
        private System.Windows.Forms.Label lblCc;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Button btnSend;
        public System.Windows.Forms.RichTextBox rtbBody;
        private System.Windows.Forms.ToolTip myToolTip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser wbOriginalBody;
    }
}