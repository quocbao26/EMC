﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;

namespace SMSHandlingApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            RemotingConfiguration.Configure("SMSHandlingApplication.exe.config", false);
            Application.Run(new SMSHandlingForm());
        }
    }
}
