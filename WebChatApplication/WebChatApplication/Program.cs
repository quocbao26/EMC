using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;


namespace WebChatApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                RemotingConfiguration.Configure("WebChatApplication.exe.config", false);
                Application.Run(new WebChatApplication());
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception is: {0}", ex.ToString());
            }
        }
    }
}
