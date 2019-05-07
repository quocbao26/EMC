//This class displays the Inbound Mail.

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
using AgileSoftware.CommonControl.Email;
using System.IO;
using System.Diagnostics;
using AgileSoftware.Multimedia.MediaStore.EMS.InboundEmail; 
using AgileSoftware.Multimedia.MediaStore.EMS.Interface;
using AgileSoftware.Multimedia.WorkItem;

namespace EmailHandlingApplication
{
    public partial class FormInboundMail : Form
    {
    
        string emailTo;
        string emailFrom;
        string emailCc;
        string emailBcc;
        string emailSubject;
        string emailSentOn;
        ListBox emailAttachment = new ListBox();
        string emailBody;
        string _emailBody;
        byte[] Bytes;
        public bool Agent_reply=false;
        string _replyFrom;
        string _replyTo;
        string _replyCc;
        string _replyBcc;
        string _replySubject;
        string _replyBody;
        ListBox _replyAttachments=new ListBox();
        MimeAttachments mimeAttachments;
        MimeAttachments _replyMimeAttachments;
        ReplyToCustomer reply_form = new ReplyToCustomer();

        public string reply_message
        {
            get { return reply_form.Reply_msg;}
            set { reply_form.Reply_msg = value; }
        }
        
        public FormInboundMail()
        {
           
            InitializeComponent();
        }

       

        //Stores Email Message details.
        public void storeEmailFields(MimeMessage mimeMessage)
        {
            if (mimeMessage != null)
            {
                emailFrom = mimeMessage.From;
                emailTo = mimeMessage.To;
                emailCc = mimeMessage.Cc;
                emailBcc = mimeMessage.Bcc;
                emailSubject = mimeMessage.Subject;
                emailSentOn = mimeMessage.Date;

                emailBody = mimeMessage.TextBody;

                if (emailBody != null)
                {
                    _emailBody = emailBody;
                }
                else
                {
                    _emailBody = mimeMessage.DecodedBody;
                }


                mimeAttachments = mimeMessage.Attachments;

                for (int i = 0; i < mimeMessage.Attachments.AttachmentFileNames.Length; i++)
                {
                    emailAttachment.Items.Add(mimeMessage.Attachments.AttachmentFileNames[i].ToString());
                }

                openInboundMail(emailFrom, emailTo, emailCc, emailBcc, emailSubject, emailSentOn, _emailBody, emailAttachment);
                this.ShowDialog();
            }
        }

        //Displays Email Message Details.
        public void openInboundMail(string emailFrom, string emailTo, string emailCc, string emailBcc, string emailSubject, string emailSentOn, string emailBody, ListBox emailAttachment)
        {
            gbInboundMail.Text = emailFrom;
            rtbFrom.Text = emailFrom;
            rtbTo.Text = emailTo;
            rtbCc.Text = emailCc;
            rtbBcc.Text = emailBcc;
            rtbSentOn.Text = emailSentOn; ;
            rtbSubject.Text = emailSubject;

            foreach (var item in emailAttachment.Items)
            {
                lstAttachments.Items.Add(item.ToString());
            }

            wbEmailBody.DocumentText = emailBody;
        }

        private void lstAttachments_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filename;
            filename = lstAttachments.SelectedItem.ToString();
            Bytes = mimeAttachments[filename];

            MessageBox.Show("selected file to open is :" + filename);

            openAttachment(filename,Bytes);
            
        }

        //Function that opens the Email Attachments.
        private void openAttachment(string filename, byte[] Bytes)
        {
            string attachmentfilename = Path.Combine(Path.GetTempPath(), filename);
            MessageBox.Show(attachmentfilename);
            File.WriteAllBytes(attachmentfilename, Bytes);
            Process attachmentProcess = new Process();
            attachmentProcess.StartInfo = new ProcessStartInfo(attachmentfilename);
            attachmentProcess.Start();

        }

        //Stores fields for Reply to Customer.
        public void storeReplyFeilds(MimeMessage mimeMessage)
        {
            _replyFrom = mimeMessage.To;
            _replyTo = mimeMessage.From;
            _replyCc = mimeMessage.Cc;
            _replyBcc = mimeMessage.Bcc;
            _replySubject = mimeMessage.Subject;

            if (mimeMessage.TextBody != null)
            {
                _replyBody = mimeMessage.TextBody;
            }
            else
            {
                _replyBody = mimeMessage.DecodedBody;
            }
            _replyMimeAttachments = mimeMessage.Attachments;

            for (int i = 0; i < mimeMessage.Attachments.AttachmentFileNames.Length; i++)
            {
                _replyAttachments.Items.Add(mimeMessage.Attachments.AttachmentFileNames[i].ToString());
            }

            reply_form.displayReplyForm(_replyFrom, _replyTo, _replyCc, _replyBcc, _replySubject, _replyBody, _replyAttachments);

        }

        //Agent replies to customer.
        private void btnReplyEmail_Click(object sender, EventArgs e)
        {
            Agent_reply = true;
            this.Close();
        }

     
    }

}
