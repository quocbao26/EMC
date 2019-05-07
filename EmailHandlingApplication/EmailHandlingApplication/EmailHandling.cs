//This Application will be used to handle the Email Media Type.

//This class will accept XML Server details and Browse for available Links.
//Using one of the available Links it connects to the server.

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
    public partial class EmailHandling : Form
    {
        //Initializations
        ASXMLClient xmlClient = null;
        enASXMLClientError err;
        
        ASMediaClient mediaClient = null;
        IASGQEMediaStore ems = null;
        EmailWorkItemData emailWID = null;
        ASGQEWorkItemBase2 workItem = null;
        MediaStoreInfoList mediaStoreList = null;
        GQEErrorArgs errorReturned;
        MimeMessage mimeMessage = null;
        MimeAttachments mimeattachments = null;
        IMessageProcessor messageProcessor;
        public string replyBody;
        CSTAConnectionID connID;
        string conn_CallID;
        string conn_DeviceID;
        bool Agentreply;
        string replyFromAgent;
        string msgFromCustomer;
        FormInboundMail frmInbound = new FormInboundMail();
        ReplyToCustomer reply_form = new ReplyToCustomer();
        string error_connectMS = string.Empty;
        string invoke_ref;
        string originalMessage;

        //Enumeration to maintain Connection State
        enum Connection
        {
            Connect,
            Disconnect,
            AlreadyConnected
        };
        Connection connectionState = Connection.Disconnect;

        //Log File is generated that stores log entries of the application. It is stored in the same directory with the name: EmailLogs.log
        public static readonly ILog log = LogManager.GetLogger(typeof(EmailHandling));

        public EmailHandling()
        {
            xmlClient = new ASXMLClient();
            //Initializes a new instance of AgileSoftware.Developer.ASXMLClient class. 
           
            mediaClient = new ASMediaClient();
            //Initializes a new instance of AgileSoftware.Multimedia.ASMediaClient class. 

            // xmlClient.RaiseEventInSameThread = false;

            buildEventHandlers();
            InitializeComponent();

            //Configures Log File
            XmlConfigurator.Configure();
            xmlClient.LogTraceToFile = true;
            xmlClient.TraceFilePathName = "XmlLogEntries.log";
            log.Info("Initialized AgentLoginApplication");
        }

        //Function that subscribes to Events
        private void buildEventHandlers()
        {
            //CSTA Events
            xmlClient.XMLEnumerateServicesReturned += new XMLEnumerateServicesReturnedEventHandler(xmlClient_XMLEnumerateServicesReturned);
            xmlClient.SocketConnected += new EventHandler(xmlClient_SocketConnected);
            xmlClient.StreamConnected += new EventHandler(xmlClient_StreamConnected);
            xmlClient.CSTAMonitorStartResponse += new CSTAMonitorStartResponseEventHandler(xmlClient_CSTAMonitorStartResponse);
            xmlClient.CSTAMonitorStopResponse += new CSTABasicResponseEventHandler(xmlClient_CSTAMonitorStopResponse);
            xmlClient.CSTAErrorReturned += new CSTAErrorReturnedEventHandler(xmlClient_CSTAErrorReturned);
            xmlClient.CSTAGetAgentStateResponse += new CSTAGetAgentStateResponseEventHandler(xmlClient_CSTAGetAgentStateResponse);
            xmlClient.CSTAAgentLoggedOff += new CSTAAgentLoggedOffEventHandler(xmlClient_CSTAAgentLoggedOff);
            xmlClient.CSTAAgentLoggedOn += new CSTAAgentLoggedOnEventHandler(xmlClient_CSTAAgentLoggedOn);
            xmlClient.CSTAAgentNotReady += new CSTAAgentNotReadyEventHandler(xmlClient_CSTAAgentNotReady);
            xmlClient.CSTAAgentReady += new CSTAAgentReadyEventHandler(xmlClient_CSTAAgentReady);
            xmlClient.CSTAAgentWorkingAfterCall += new CSTAAgentWorkingAfterCallEventHandler(xmlClient_CSTAAgentWorkingAfterCall);
            xmlClient.CSTADelivered += new CSTADeliveredEventHandler(xmlClient_CSTADelivered);
            xmlClient.CSTAEstablished += new CSTAEstablishedEventHandler(xmlClient_CSTAEstablished);
            xmlClient.CSTACallCleared += new CSTACallClearedEventHandler(xmlClient_CSTACallCleared);
            xmlClient.CSTAConnectionCleared += new CSTAConnectionClearedEventHandler(xmlClient_CSTAConnectionCleared);

           

            //Media Client Events
            mediaClient.GQEError += new GQEErrorEventHandler(mediaClient_GQEError);
            mediaClient.MediaTypeRegistered += new AgileSoftware.Multimedia.Client.MediaTypeRegisteredEventHandler(mediaClient_MediaTypeRegistered);
            mediaClient.MediaTypeUnregistered += new AgileSoftware.Multimedia.Client.MediaTypeUnregisteredEventHandler(mediaClient_MediaTypeUnregistered);
            mediaClient.WorkItemRefDelivered += new AgileSoftware.Multimedia.Client.WorkItemRefDeliveredEventHandler(mediaClient_WorkItemRefDelivered);
            mediaClient.WorkItemRefEstablished += new AgileSoftware.Multimedia.Client.WorkItemRefEstablishedEventHandler(mediaClient_WorkItemRefEstablished);
            mediaClient.WorkItemRefRemoved += new AgileSoftware.Multimedia.Client.WorkItemRefRemovedEventHandler(mediaClient_WorkItemRefRemoved);

            //Application Events 
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
            log.Info("Exited Email Handling Application");
            Environment.Exit(0);
        }

        //Function that clears subscribed Events
        private void clearEventHandlers()
        {
            //CSTA Events
            xmlClient.XMLEnumerateServicesReturned -= new XMLEnumerateServicesReturnedEventHandler(xmlClient_XMLEnumerateServicesReturned);
            xmlClient.SocketConnected -= new EventHandler(xmlClient_SocketConnected);
            xmlClient.StreamConnected -= new EventHandler(xmlClient_StreamConnected);
            xmlClient.CSTAMonitorStartResponse -= new CSTAMonitorStartResponseEventHandler(xmlClient_CSTAMonitorStartResponse);
            xmlClient.CSTAMonitorStopResponse -= new CSTABasicResponseEventHandler(xmlClient_CSTAMonitorStopResponse);
            xmlClient.CSTAErrorReturned -= new CSTAErrorReturnedEventHandler(xmlClient_CSTAErrorReturned);
            xmlClient.CSTAGetAgentStateResponse -= new CSTAGetAgentStateResponseEventHandler(xmlClient_CSTAGetAgentStateResponse);
            xmlClient.CSTAAgentLoggedOff -= new CSTAAgentLoggedOffEventHandler(xmlClient_CSTAAgentLoggedOff);
            xmlClient.CSTAAgentLoggedOn -= new CSTAAgentLoggedOnEventHandler(xmlClient_CSTAAgentLoggedOn);
            xmlClient.CSTAAgentNotReady -= new CSTAAgentNotReadyEventHandler(xmlClient_CSTAAgentNotReady);
            xmlClient.CSTAAgentReady -= new CSTAAgentReadyEventHandler(xmlClient_CSTAAgentReady);
            xmlClient.CSTAAgentWorkingAfterCall -= new CSTAAgentWorkingAfterCallEventHandler(xmlClient_CSTAAgentWorkingAfterCall);
            xmlClient.CSTADelivered -= new CSTADeliveredEventHandler(xmlClient_CSTADelivered);
            xmlClient.CSTAEstablished -= new CSTAEstablishedEventHandler(xmlClient_CSTAEstablished);
            xmlClient.CSTACallCleared -= new CSTACallClearedEventHandler(xmlClient_CSTACallCleared);
            xmlClient.CSTAConnectionCleared -= new CSTAConnectionClearedEventHandler(xmlClient_CSTAConnectionCleared);

           

            //Media Client Events
            mediaClient.GQEError -= new GQEErrorEventHandler(mediaClient_GQEError);
            mediaClient.MediaTypeRegistered -= new AgileSoftware.Multimedia.Client.MediaTypeRegisteredEventHandler(mediaClient_MediaTypeRegistered);
            mediaClient.MediaTypeUnregistered -= new AgileSoftware.Multimedia.Client.MediaTypeUnregisteredEventHandler(mediaClient_MediaTypeUnregistered);
            mediaClient.WorkItemRefDelivered -= new AgileSoftware.Multimedia.Client.WorkItemRefDeliveredEventHandler(mediaClient_WorkItemRefDelivered);
            mediaClient.WorkItemRefEstablished -= new AgileSoftware.Multimedia.Client.WorkItemRefEstablishedEventHandler(mediaClient_WorkItemRefEstablished);
            mediaClient.WorkItemRefRemoved -= new AgileSoftware.Multimedia.Client.WorkItemRefRemovedEventHandler(mediaClient_WorkItemRefRemoved);

            //Application Events 
            Application.ApplicationExit -= new EventHandler(Application_ApplicationExit);
        }

        //This event is fired when an CSTA error is reported by the Server.
        void xmlClient_CSTAErrorReturned(object sender, CSTAErrorReturnedEventArgs arg)
        {
            rtbStatus.Text = "Error Occurred: " + " Category: " + arg.Error.Category + " Description: " + arg.Error.ValueDescription;
            log.Error("CSTA Error occurred" + arg.Error.ValueDescription);
        }

        //Fires when the component established a socket connection with the Active XML Server. 
        void xmlClient_SocketConnected(object sender, EventArgs e)
        {
            rtbStatus.Text = "Socket Connected.";
            log.Info("Socket Connected");
        }

        //Connection Established
        private void ConnectionEstablished()
        {
            lblAgentID.Enabled = true;
            lblAgentPwd.Enabled = true;
            lblStationID.Enabled = true;
            txtStationID.Enabled = true;
            txtAgentID.Enabled = true;
            txtAgentPwd.Enabled = true;
            btnMonitor.Enabled = true;
            btnConnection.Text = "Disconnect";
            myToolTip.SetToolTip(btnConnection, "Disconnect from XML Server");
            gbAgentDetails.Enabled = true;
        }

        //Fires when the XML server created a stream connection with the TSever on behalf of the component. 
        void xmlClient_StreamConnected(object sender, EventArgs e)
        {
            rtbStatus.Text = "Stream Connected. ";
            log.Info("Stream Connected");
            connectionState = Connection.Connect;
            ConnectionEstablished();
        }

        //Links Browsed
        private void LinksBrowsed()
        {
            cmbServerTLinks.Text = cmbServerTLinks.Items[0].ToString();
            btnConnection.Enabled = true;
            btnConnection.Text = "Connect";
        }

        //Fires when XMLEnumerateServices() method is invoked.
        // It returns a set of TServer link names and the associated TCP socket connection information used to establish a TServer stream socket connection. 
        void xmlClient_XMLEnumerateServicesReturned(object sender, XMLEnumerateServicesReturnedEventArgs arg)
        {
            cmbServerTLinks.Items.Clear();
            for (int i = 0; i < arg.TLinkConnectionList.Count; i++)
            {
                cmbServerTLinks.Items.Add(arg.TLinkConnectionList[i].TServerLinkName);
            }
            LinksBrowsed();
        }

        //This function is used to check whether the input value entered is Numeric. Ex. The port number or the Agent ID must always be Numeric.
        // Returns true if string is Numeric otherwise false.
        public static bool checkNum(string _no)
        {
            int no;
            bool isNum = int.TryParse(_no, out no);
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

        //Connection Disconnected
        private void ConnectionDisconnected()
        {
            Image img = Image.FromFile(@"..\..\Resources\images\login.png");
            lblAgentID.Enabled = false;
            lblAgentPwd.Enabled = false;
            lblStationID.Enabled = false;
            txtStationID.Enabled = false;
            txtAgentID.Enabled = false;
            txtAgentPwd.Enabled = false;
            btnMonitor.Enabled = false;
            btnLogInOut.Enabled = false;
            btnMonitor.Text = "Monitor Start";
            btnLogInOut.Image = img;
            myToolTip.SetToolTip(btnLogInOut, "Agent Login");
            btnAvailable.Enabled = false;
            btnAuxillary.Enabled = false;
            btnACW.Enabled = false;
            txtAgentID.Clear();
            txtAgentPwd.Clear();
            txtStationID.Clear();
            btnConnection.Text = "Connect";
            myToolTip.SetToolTip(btnConnection, "Connect to XML Server");
            gbAgentDetails.Enabled = false;
        }

        //It takes as input the Server IP and Server Port address and will return available Server Links.
        private void btnBrowseLinks_Click(object sender, EventArgs e)
        {
            
            if ((txtServerIP.Text.Length <= 0) && (txtServerPort.Text.Length <= 0))
            {
                MessageBox.Show("Server IP and Server Port are not entered", "Server IP and Port", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Server IP and Port not entered");
                txtServerIP.Focus();
            }
            else if (txtServerIP.Text.Length <= 0)
            {
                MessageBox.Show("Server IP is not entered", "Server IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Server IP not entered");
                txtServerIP.Focus();
            }
            else if (txtServerPort.Text.Length <= 0)
            {
                MessageBox.Show("Port not entered", "Port", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Port not entered");
                txtServerPort.Focus();
            }
            else
            {
                string _ip;
                string _no;
                _ip = txtServerIP.Text;
                _no = txtServerPort.Text;
                bool check_ip;
                bool check_no;
                check_ip = checkIP(_ip);
                check_no = checkNum(_no);

                if (!check_ip)
                {
                    MessageBox.Show("Invalid Server IP", "Server IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Invalid IP entered");
                    txtServerIP.Focus();
                }
                else if (!check_no)
                {
                    MessageBox.Show("Invalid Port Number", "Port", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Invalid Port entered");
                    txtServerPort.Focus();
                }
                else
                {
                    connectionState = Connection.Disconnect;
                    xmlClient.ServerIP = txtServerIP.Text.Trim();
                    xmlClient.ServerPort = int.Parse(txtServerPort.Text.Trim());
                    xmlClient.XMLEnumerateServices();
                }
            }
        }

        //It will choose one of the Links returned and will make/break a connection to the EMC Server.
        private void btnConnection_Click(object sender, EventArgs e)
        {
            //Connect
            if (connectionState == Connection.Disconnect)
            {
                xmlClient.TServerLinkName = cmbServerTLinks.Text.Trim();
                //Method used: Connect()
                //Connects to the Active XML Server using naming service. Accepts  ServerIP, ServerPort and TServerLinkName values.
                //The SocketConnected event and StreamConnected event will fire if connecting to the XML Server and TServer successfully. 
                err = xmlClient.Connect();
                rtbStatus.Text = err.ToString();

            }

            //Disconnect
            if (connectionState == Connection.Connect || connectionState == Connection.AlreadyConnected)
            {
                //Logs off Agent if Agent is in Logged in state.
                if (agent_state == AgentState.agentLoggedOn || agent_state == AgentState.agentReady || agent_state == AgentState.agentNotReady || agent_state == AgentState.agentWorkingAfterCall)
                {
                    //Method used: CSTASetAgentState(CSTADeviceID, enReqAgentState, String, String, CSTADeviceID, PrivateDataSetAgentState)
                    //Requests a new agent state at a specified device. 
                    //Parameters:
                    //device (CSTADeviceID) - Specifies the DeviceID for the ACD agent for which the state is to be changed.
                    //requestedAgentState (enReqAgentState) - Specifies the requested agent state. 
                    //agentID (String) - Specifies the agent identifier. Set its value to null (or Nothing) when it is omitted. 
                    //password (String) - Specifies the agent password. This parameter can only be provided when the requestedAgentState is loggedOn or loggedOff. Set its value to null (or Nothing) when it is omitted.
                    //group (CSTADeviceID) - Specifies the agent ACD group that the agent is logging in or out of. Set its value to null (or Nothing) when it is omitted.
                    //privateData (PrivateDataSetAgentState) - The private data associated with this method. 
                    //CSTAAgentLoggedOff will be fired
                    xmlClient.CSTASetAgentState(new CSTADeviceID(txtStationID.Text.Trim(), enDeviceIDType.deviceNumber), enReqAgentState.loggedOff, txtAgentID.Text.Trim(), txtAgentPwd.Text.Trim(), null, null);
                }

                //Stops Monitor initiated before.
                if (monitor_state == MonitorState.MonitorStart)
                {
                    //Method used: CSTAMonitorStop(CSTAMonitor)
                    // Used to cancel a previously initiated Monitor Start service.  
                    //Parameter:
                    //thisCSTAMonitor (CSTAMonitor) - One of the CSTAMonitor object listed in the CSTAMonitorList.
                    //CSTAMonitorStopResponse will be fired.
                    xmlClient.CSTAMonitorStop(xmlClient.CSTAMonitorList[0]);
                }

                //Method used: Disconnect()
                //Closes the connection with the Active XML Server. 
                err = xmlClient.Disconnect();
                if (err.ToString().Equals("NoError"))
                {
                    rtbStatus.Text = "Disconnected.";
                    log.Info("Server Disconnected");
                    connectionState = Connection.Disconnect;
                    clearEventHandlers();
                    ConnectionDisconnected();
                    this.Close();
                    log.Info("Exited AgentLoginApplication");
                }
                else
                    rtbStatus.Text = err.ToString();
            }

            //Already Connected.
            if (err.ToString().Equals("AlreadyConnected"))
            {
                connectionState = Connection.AlreadyConnected;
                btnConnection.Text = "Disconnect";
            }
        }

    }

}
