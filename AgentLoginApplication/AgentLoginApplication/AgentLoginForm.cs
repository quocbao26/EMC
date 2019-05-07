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
using System.Threading;
using System.Text.RegularExpressions;
using log4net;
using log4net.Config;
using System.Drawing.Imaging;

//This application will be used by the Agent to Login / Logout to / from EMC Desktop.

namespace AgentLoginApplication
{
    public partial class AgentLoginForm : Form
    {
        //Declarations
        ASXMLClient xmlClient;
        enASXMLClientError err;
   
        //Enumeration to maintain Connection State
        enum Connection
        {
            Connect,
            Disconnect,
            AlreadyConnected
        };
        Connection connectionState = Connection.Disconnect;

        //Log File.
        public static readonly ILog log = LogManager.GetLogger(typeof(AgentLoginForm));
        
        public AgentLoginForm()
        {
            xmlClient = new ASXMLClient();
            //Initializes a new instance of AgileSoftware.Developer.ASXMLClient class. 

            InitializeComponent();
            buildEventHandlers();
            
            XmlConfigurator.Configure();
            xmlClient.LogTraceToFile = true;
            xmlClient.TraceFilePathName = "XmlLogEntries.log";
            log.Info("Initialized AgentLoginApplication");
        }

        //Function that subscribes to Events.
        private void buildEventHandlers()
        {
            //XML Client Events
            xmlClient.XMLEnumerateServicesReturned += new AgileSoftware.Developer.XML.XMLEnumerateServicesReturnedEventHandler(myClient_XMLEnumerateServicesReturned);
            xmlClient.StreamConnected += new EventHandler(myClient_StreamConnected);
            xmlClient.SocketConnected += new EventHandler(myClient_SocketConnected);
            xmlClient.CSTAMonitorStartResponse += new CSTAMonitorStartResponseEventHandler(myClient_CSTAMonitorStartResponse);
            xmlClient.CSTAAgentLoggedOn += new CSTAAgentLoggedOnEventHandler(myClient_CSTAAgentLoggedOn);
            xmlClient.CSTAAgentReady += new CSTAAgentReadyEventHandler(myClient_CSTAAgentReady);
            xmlClient.CSTAAgentNotReady += new CSTAAgentNotReadyEventHandler(myClient_CSTAAgentNotReady);
            xmlClient.CSTAGetAgentStateResponse += new CSTAGetAgentStateResponseEventHandler(myClient_CSTAGetAgentStateResponse);
            xmlClient.CSTAAgentWorkingAfterCall += new CSTAAgentWorkingAfterCallEventHandler(myClient_CSTAAgentWorkingAfterCall);
            xmlClient.CSTAAgentLoggedOff += new CSTAAgentLoggedOffEventHandler(myClient_CSTAAgentLoggedOff);
            xmlClient.CSTAMonitorStopResponse += new CSTABasicResponseEventHandler(myClient_CSTAMonitorStopResponse);
            xmlClient.CSTAErrorReturned += new CSTAErrorReturnedEventHandler(myClient_CSTAErrorReturned);

            //Application Events
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
        }

        //Function that clears Events.
        private void clearEventHandlers()
        {
            //XML Client Events
            xmlClient.XMLEnumerateServicesReturned -= new AgileSoftware.Developer.XML.XMLEnumerateServicesReturnedEventHandler(myClient_XMLEnumerateServicesReturned);
            xmlClient.StreamConnected -= new EventHandler(myClient_StreamConnected);
            xmlClient.SocketConnected -= new EventHandler(myClient_SocketConnected);
            xmlClient.CSTAMonitorStartResponse -= new CSTAMonitorStartResponseEventHandler(myClient_CSTAMonitorStartResponse);
            xmlClient.CSTAAgentLoggedOn -= new CSTAAgentLoggedOnEventHandler(myClient_CSTAAgentLoggedOn);
            xmlClient.CSTAAgentReady -= new CSTAAgentReadyEventHandler(myClient_CSTAAgentReady);
            xmlClient.CSTAAgentNotReady -= new CSTAAgentNotReadyEventHandler(myClient_CSTAAgentNotReady);
            xmlClient.CSTAGetAgentStateResponse -= new CSTAGetAgentStateResponseEventHandler(myClient_CSTAGetAgentStateResponse);
            xmlClient.CSTAAgentWorkingAfterCall -= new CSTAAgentWorkingAfterCallEventHandler(myClient_CSTAAgentWorkingAfterCall);
            xmlClient.CSTAAgentLoggedOff -= new CSTAAgentLoggedOffEventHandler(myClient_CSTAAgentLoggedOff);
            xmlClient.CSTAMonitorStopResponse -= new CSTABasicResponseEventHandler(myClient_CSTAMonitorStopResponse);
            xmlClient.CSTAErrorReturned -= new CSTAErrorReturnedEventHandler(myClient_CSTAErrorReturned);

            //Application Events
            Application.ApplicationExit -= new EventHandler(Application_ApplicationExit);
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
            log.Info("Exited AgentLoginApplication");
            Environment.Exit(0);
        }

        //this event is fired when an CSTA error is reported by the Server.
        void myClient_CSTAErrorReturned(object sender, CSTAErrorReturnedEventArgs arg)
        {
            rtbStatus.Text = "Error Occurred: " + " Category: " + arg.Error.Category + " Description: " + arg.Error.ValueDescription;
            log.Error("CSTA Error occurred" + arg.Error.ValueDescription);
        }

       
        //It takes as input the Server IP and Server Port address and will return available Server Links.
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            
            if ((txtbServerIP.Text.Length <= 0) && (txtbServerPort.Text.Length <= 0))
            {
                        MessageBox.Show("Enter valid Server IP and Port Number", "Server IP and Port", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        log.Error("Server IP and Port not entered");
                        txtbServerIP.Focus();
            }
            else if (txtbServerIP.Text.Length <= 0)
            {
                MessageBox.Show("Enter valid Server IP", "Server IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Server IP not entered");
                txtbServerIP.Focus();
            }
            else if (txtbServerPort.Text.Length <= 0)
            {
                MessageBox.Show("Enter valid Port Number", "Port", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Port not entered");
                txtbServerPort.Focus();
            }
            else
            {
                string _ip;
                string _no;
                _ip = txtbServerIP.Text;
                _no = txtbServerPort.Text;
                bool check_ip;
                bool check_no;
                check_ip = checkIP(_ip);
                check_no = checkNum(_no);

                if (!check_ip)
                {
                    MessageBox.Show("Enter valid Server IP", "Server IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Invalid IP entered");
                    txtbServerIP.Focus();
                }
                else if (!check_no)
                {
                    MessageBox.Show("Enter valid Port Number", "Port", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Invalid Port entered");
                    txtbServerPort.Focus();
                }
                else
                {
                    connectionState = Connection.Disconnect;
                    xmlClient.SecureChannel = false;
                    xmlClient.ServerIP = txtbServerIP.Text.Trim();
                    xmlClient.ServerPort = int.Parse(txtbServerPort.Text.Trim());
                    xmlClient.XMLEnumerateServices();
                }
            }
        }

        //Fires when XMLEnumerateServices() method is invoked. 
        void myClient_XMLEnumerateServicesReturned(object sender, AgileSoftware.Developer.XML.XMLEnumerateServicesReturnedEventArgs arg)
        {
            cmbServerLink.Items.Clear();
            for (int i = 0; i < arg.TLinkConnectionList.Count; i++)
            {
                cmbServerLink.Items.Add(arg.TLinkConnectionList[i].TServerLinkName);
            }
            LinksBrowsed();
        }

        //Links Browsed
        private void LinksBrowsed()
        {
            cmbServerLink.Text = cmbServerLink.Items[0].ToString();
            btnConnect.Enabled = true;
            btnConnect.Text = "Connect";
        }

        //It will choose one of the Links returned and will make a connection to the EMC Server.
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //For connect
            if (connectionState == Connection.Disconnect)
            {
                xmlClient.TServerLinkName = cmbServerLink.Text.Trim();
                err = xmlClient.Connect();
                rtbStatus.Text = err.ToString();
            }

            if (connectionState == Connection.Connect || connectionState == Connection.AlreadyConnected)
            {
                //Logs off Agent if Agent is Logged On
                if (agent_state == AgentState.agentLoggedOn || agent_state == AgentState.agentReady || agent_state == AgentState.agentNotReady || agent_state == AgentState.agentWorkingAfterCall)
                {
                    xmlClient.CSTASetAgentState(new CSTADeviceID(txtbStationID.Text.Trim(), enDeviceIDType.deviceNumber), enReqAgentState.loggedOff, txtbAgentID.Text.Trim(), txtbAgentPassword.Text.Trim(), null, null);
                }

                //Stop monitor initiated before
                if (monitor_state == MonitorState.MonitorStart)
                {
                    

                    xmlClient.CSTAMonitorStop(xmlClient.CSTAMonitorList[0]);
                }


                err = xmlClient.Disconnect();
                if (err.ToString().Equals("NoError"))
                {
                    rtbStatus.Text = "Disconnected.";
                    log.Info("Server Disconnected");
                    connectionState = Connection.Disconnect;
                    clearEventHandlers();
                    ConnectionDisconnected();
                    this.Close();
                    log.Info("Exited AgentLoginApplication.");
                }
                else
                    rtbStatus.Text = err.ToString();
            }
            if (err.ToString().Equals("AlreadyConnected"))
            {
                btnConnect.Text = "Disconnect";
            }
        }

        //Fires when the component established a socket connection with the Active XML Server. 
        void myClient_SocketConnected(object sender, EventArgs e)
        {
            rtbStatus.Text = "Socket Connected.";
            log.Info("Socket Connected");
        }

        //Fires when the XML server created a stream connection with the TSever on behalf of the component. 
        void myClient_StreamConnected(object sender, EventArgs e)
        {
            rtbStatus.Text = "Stream Connected. ";
            log.Info("Stream Connected");
            connectionState = Connection.Connect;
            ConnectionEstablished();
        }

        //Connection Established
        private void ConnectionEstablished()
        {
            gbAgentDetails.Enabled = true;
            lblAgentID.Enabled = true;
            lblAgentPassword.Enabled = true;
            lblStationID.Enabled = true;
            txtbStationID.Enabled = true;
            txtbAgentID.Enabled = true;
            txtbAgentPassword.Enabled = true;
            btnMonitorStart.Enabled = true;
            btnConnect.Text = "Disconnect";
            myToolTip.SetToolTip(btnConnect, "Disconnect from XML Server");
        }

        //Button changes on Connection Disconnected.
        private void ConnectionDisconnected()
        {
            Image img = Image.FromFile(@"..\..\Resources\images\login.png");
            gbAgentDetails.Enabled = false;
            lblAgentID.Enabled = false;
            lblAgentPassword.Enabled = false;
            lblStationID.Enabled = false;
            txtbStationID.Enabled = false;
            txtbAgentID.Enabled = false;
            txtbAgentPassword.Enabled = false;
            btnMonitorStart.Enabled = false;
            btnLogin.Enabled = false;
            btnMonitorStart.Text = "Monitor Start";
            btnLogin.Image = img;
            myToolTip.SetToolTip(btnLogin, "Agent Login");
            btnAvailable.Enabled = false;
            btnAux.Enabled = false;
            btnACW.Enabled = false;
            txtbAgentID.Clear();
            txtbAgentPassword.Clear();
            txtbStationID.Clear();
            btnConnect.Text = "Connect";
            myToolTip.SetToolTip(btnConnect, "Connect to XML Server");
        }
       
        //This function is used to check whether the input value entered is Numeric. Ex. The port number or the Agent ID must always be Numeric.
        // Returns true if string is Numeric otherwise false.
        public static bool checkNum(string _no)
        {            int no;
            bool isNum = int.TryParse(_no,out no);
            if (isNum)
                return true;
            else
                return false;
        }
            
        //This function is used to validate the IP address. Returns true if IP is valid otherwise false.
        public static bool checkIP(string _ip)
        {
            Regex ip = new Regex(@"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");
            MatchCollection result = ip.Matches(_ip);
            if (result.Count > 0)
            {
                string[] ipParts = _ip.Split('.');
                int ipPortionVal;
                foreach (string ipPortion in ipParts)
                {
                    bool isInt = Int32.TryParse(ipPortion, out ipPortionVal);
                    if (isInt)
                    {
                        if (!(ipPortionVal > -1 && ipPortionVal < 256))
                            return false;
                    }
                    else
                        return false;
                }
                return true;
            }
            else
                return false;
        }
       }
}
