using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoiceCallHandlingApplication
{
    public partial class VoiceCallForm : Form
    {
        public VoiceCallForm()
        {
            InitializeComponent();
        }
        private Form CheckExists(Type ftype)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form frm = this.CheckExists(typeof(SettingConfigForm));

            if (frm != null) frm.Activate();
            else
            {
                SettingConfigForm f = new SettingConfigForm();
                
                f.Show();
            }


            //SettingConfigForm cf = new SettingConfigForm();
            //cf.Visible = true;
        }


    }
}
