//This class is used to display the SMS.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMSHandlingApplication
{
    public partial class SMSWindow : Form
    {
        public SMSWindow()
        {
            InitializeComponent();
        }

        public void displaySMS(string customername, string initialmessage)
        {
            gbSMS.Text = customername;
            rtbChat.Text = customername + "says :\n\n" + initialmessage;
        }

        private void btnAcknowledge_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
