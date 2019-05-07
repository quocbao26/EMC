//This class is used to reply to the customer Email.

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
    public partial class ReplyToCustomer : Form
    {
        string replyText;
        string reply;

        public ReplyToCustomer()
        {
            InitializeComponent();
        }

        public string Reply_msg
        {
            get {return this.replyText; }
            set {this.replyText = value;}
        }
        
        //Displays Email to Reply.
        public void displayReplyForm(string _replyFrom, string _replyTo, string _replyCc, string _replyBcc, string _replySubject, string _replyBody, ListBox _replyAttachments)
        {
            gbReplyForm.Text = _replyTo;
            txtFrom.Text = _replyFrom;
            txtTo.Text = _replyTo;
            txtCc.Text = _replyCc;
            txtBcc.Text = _replyBcc;
            txtSubject.Text = "Re : " +_replySubject;
            wbOriginalBody.DocumentText = _replyBody;
            rtbBody.Text = "";

            foreach (var item in _replyAttachments.Items)
            {
                lstReplyAttachments.Items.Add(item.ToString());
            }

            this.ShowDialog();
        }

        //Stores reply from agent.
        public void getReplyText(string replyText)
        {
            reply = replyText;
        }

        public string replyToCust()
        {
            return reply;
        }

        //Send reply to Customer.
        private void btnSend_Click(object sender, EventArgs e)
        {
            replyText = rtbBody.Text.Trim();
            getReplyText(replyText);
            this.Close();
        }
    }
}
