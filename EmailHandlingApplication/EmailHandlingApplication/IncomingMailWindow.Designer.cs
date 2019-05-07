using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AgileSoftware.Developer;
using AgileSoftware.Developer.CSTA;
using AgileSoftware.Developer.XML;
using AgileSoftware.Developer.Station;
using AgileSoftware.Developer.Device;
using System.Threading;
using System.Text.RegularExpressions;
using log4net;
using log4net.Config;
using System.Drawing.Imaging;
using AgileSoftware.Multimedia;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Proxies;
using AgileSoftware.Multimedia.MediaStore.EMS.Email;

using AgileSoftware.Multimedia.MediaStore.EMS.InboundEmail;
using AgileSoftware.Multimedia.MediaStore.EMS.Interface;
using AgileSoftware.Multimedia.WorkItem;

namespace EmailHandlingApplication
{
    partial class FormInboundMail
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
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbInboundMail = new System.Windows.Forms.GroupBox();
            this.lstAttachments = new System.Windows.Forms.ListBox();
            this.rtbBcc = new System.Windows.Forms.RichTextBox();
            this.lblBcc = new System.Windows.Forms.Label();
            this.rtbSentOn = new System.Windows.Forms.RichTextBox();
            this.rtbFrom = new System.Windows.Forms.RichTextBox();
            this.rtbTo = new System.Windows.Forms.RichTextBox();
            this.rtbCc = new System.Windows.Forms.RichTextBox();
            this.rtbSubject = new System.Windows.Forms.RichTextBox();
            this.lblAttachment = new System.Windows.Forms.Label();
            this.lblSentOn = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblCc = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.btnReplyEmail = new System.Windows.Forms.Button();
            this.myToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.wbEmailBody = new System.Windows.Forms.WebBrowser();
            this.gbInboundMail.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInboundMail
            // 
            this.gbInboundMail.Controls.Add(this.panel1);
            this.gbInboundMail.Controls.Add(this.lstAttachments);
            this.gbInboundMail.Controls.Add(this.rtbBcc);
            this.gbInboundMail.Controls.Add(this.lblBcc);
            this.gbInboundMail.Controls.Add(this.rtbSentOn);
            this.gbInboundMail.Controls.Add(this.rtbFrom);
            this.gbInboundMail.Controls.Add(this.rtbTo);
            this.gbInboundMail.Controls.Add(this.rtbCc);
            this.gbInboundMail.Controls.Add(this.rtbSubject);
            this.gbInboundMail.Controls.Add(this.lblAttachment);
            this.gbInboundMail.Controls.Add(this.lblSentOn);
            this.gbInboundMail.Controls.Add(this.lblSubject);
            this.gbInboundMail.Controls.Add(this.lblCc);
            this.gbInboundMail.Controls.Add(this.lblTo);
            this.gbInboundMail.Controls.Add(this.lblFrom);
            this.gbInboundMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInboundMail.Location = new System.Drawing.Point(12, 58);
            this.gbInboundMail.Name = "gbInboundMail";
            this.gbInboundMail.Size = new System.Drawing.Size(512, 624);
            this.gbInboundMail.TabIndex = 0;
            this.gbInboundMail.TabStop = false;
            // 
            // lstAttachments
            // 
            this.lstAttachments.FormattingEnabled = true;
            this.lstAttachments.Location = new System.Drawing.Point(113, 183);
            this.lstAttachments.Name = "lstAttachments";
            this.lstAttachments.Size = new System.Drawing.Size(377, 69);
            this.lstAttachments.TabIndex = 22;
            this.lstAttachments.SelectedIndexChanged += new System.EventHandler(this.lstAttachments_SelectedIndexChanged);
            // 
            // rtbBcc
            // 
            this.rtbBcc.Location = new System.Drawing.Point(113, 108);
            this.rtbBcc.Name = "rtbBcc";
            this.rtbBcc.ReadOnly = true;
            this.rtbBcc.Size = new System.Drawing.Size(377, 19);
            this.rtbBcc.TabIndex = 21;
            this.rtbBcc.Text = "";
            // 
            // lblBcc
            // 
            this.lblBcc.AutoSize = true;
            this.lblBcc.Location = new System.Drawing.Point(21, 108);
            this.lblBcc.Name = "lblBcc";
            this.lblBcc.Size = new System.Drawing.Size(26, 13);
            this.lblBcc.TabIndex = 20;
            this.lblBcc.Text = "Bcc";
            // 
            // rtbSentOn
            // 
            this.rtbSentOn.Location = new System.Drawing.Point(113, 158);
            this.rtbSentOn.Name = "rtbSentOn";
            this.rtbSentOn.ReadOnly = true;
            this.rtbSentOn.Size = new System.Drawing.Size(377, 19);
            this.rtbSentOn.TabIndex = 18;
            this.rtbSentOn.Text = "";
            // 
            // rtbFrom
            // 
            this.rtbFrom.Location = new System.Drawing.Point(113, 30);
            this.rtbFrom.Name = "rtbFrom";
            this.rtbFrom.ReadOnly = true;
            this.rtbFrom.Size = new System.Drawing.Size(377, 20);
            this.rtbFrom.TabIndex = 4;
            this.rtbFrom.Text = "";
            // 
            // rtbTo
            // 
            this.rtbTo.Location = new System.Drawing.Point(113, 56);
            this.rtbTo.Name = "rtbTo";
            this.rtbTo.ReadOnly = true;
            this.rtbTo.Size = new System.Drawing.Size(377, 19);
            this.rtbTo.TabIndex = 16;
            this.rtbTo.Text = "";
            // 
            // rtbCc
            // 
            this.rtbCc.Location = new System.Drawing.Point(113, 81);
            this.rtbCc.Name = "rtbCc";
            this.rtbCc.ReadOnly = true;
            this.rtbCc.Size = new System.Drawing.Size(377, 21);
            this.rtbCc.TabIndex = 15;
            this.rtbCc.Text = "";
            // 
            // rtbSubject
            // 
            this.rtbSubject.Location = new System.Drawing.Point(113, 133);
            this.rtbSubject.Name = "rtbSubject";
            this.rtbSubject.ReadOnly = true;
            this.rtbSubject.Size = new System.Drawing.Size(377, 19);
            this.rtbSubject.TabIndex = 14;
            this.rtbSubject.Text = "";
            // 
            // lblAttachment
            // 
            this.lblAttachment.AutoSize = true;
            this.lblAttachment.Location = new System.Drawing.Point(18, 183);
            this.lblAttachment.Name = "lblAttachment";
            this.lblAttachment.Size = new System.Drawing.Size(61, 13);
            this.lblAttachment.TabIndex = 5;
            this.lblAttachment.Text = "Attachment";
            // 
            // lblSentOn
            // 
            this.lblSentOn.AutoSize = true;
            this.lblSentOn.Location = new System.Drawing.Point(18, 158);
            this.lblSentOn.Name = "lblSentOn";
            this.lblSentOn.Size = new System.Drawing.Size(46, 13);
            this.lblSentOn.TabIndex = 4;
            this.lblSentOn.Text = "Sent On";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(21, 133);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(43, 13);
            this.lblSubject.TabIndex = 3;
            this.lblSubject.Text = "Subject";
            // 
            // lblCc
            // 
            this.lblCc.AutoSize = true;
            this.lblCc.Location = new System.Drawing.Point(21, 84);
            this.lblCc.Name = "lblCc";
            this.lblCc.Size = new System.Drawing.Size(20, 13);
            this.lblCc.TabIndex = 2;
            this.lblCc.Text = "Cc";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(21, 59);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 13);
            this.lblTo.TabIndex = 1;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(21, 37);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(30, 13);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From";
            // 
            // btnReplyEmail
            // 
            this.btnReplyEmail.Image = global::EmailHandlingApplication.Properties.Resources.replyEmail;
            this.btnReplyEmail.Location = new System.Drawing.Point(242, 12);
            this.btnReplyEmail.Name = "btnReplyEmail";
            this.btnReplyEmail.Size = new System.Drawing.Size(43, 40);
            this.btnReplyEmail.TabIndex = 1;
            this.myToolTip.SetToolTip(this.btnReplyEmail, "Reply To Email");
            this.btnReplyEmail.UseVisualStyleBackColor = true;
            this.btnReplyEmail.Click += new System.EventHandler(this.btnReplyEmail_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.wbEmailBody);
            this.panel1.Location = new System.Drawing.Point(24, 276);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(466, 330);
            this.panel1.TabIndex = 23;
            // 
            // wbEmailBody
            // 
            this.wbEmailBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbEmailBody.Location = new System.Drawing.Point(0, 0);
            this.wbEmailBody.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbEmailBody.Name = "wbEmailBody";
            this.wbEmailBody.Size = new System.Drawing.Size(466, 330);
            this.wbEmailBody.TabIndex = 0;
            // 
            // FormInboundMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 702);
            this.Controls.Add(this.btnReplyEmail);
            this.Controls.Add(this.gbInboundMail);
            this.Name = "FormInboundMail";
            this.Text = "Inbound Mail";
            this.gbInboundMail.ResumeLayout(false);
            this.gbInboundMail.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        //void FormInboundMail_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        //{
        //    EmailHandling emailHandling = new EmailHandling();
        //}

        #endregion

        public System.Windows.Forms.GroupBox gbInboundMail;
        public System.Windows.Forms.Label lblAttachment;
        public System.Windows.Forms.Label lblSentOn;
        public System.Windows.Forms.Label lblSubject;
        public System.Windows.Forms.Label lblCc;
        public System.Windows.Forms.Label lblTo;
        public System.Windows.Forms.Label lblFrom;
        public Button btnReplyEmail;
        public RichTextBox rtbTo;
        public RichTextBox rtbCc;
        public RichTextBox rtbSubject;
        public RichTextBox rtbFrom;
        public RichTextBox rtbSentOn;
        private ToolTip myToolTip;
        private Label lblBcc;
        public RichTextBox rtbBcc;
        public ListBox lstAttachments;
        private Panel panel1;
        private WebBrowser wbEmailBody;
    }
}