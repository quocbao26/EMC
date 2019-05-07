//This application will be used for handling SMS workitems. 
//This class is used to browse the available links and to select one of the available links and connect to the XML Server.

# region directives 
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
using AgileSoftware.Developer.Station;
using AgileSoftware.Developer.XMLClient;
using AgileSoftware.Developer.XML;
using log4net;
using log4net.Config;
using System.Threading;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using AgileSoftware.Multimedia.MediaStore;
using AgileSoftware.Multimedia;
using AgileSoftware.Multimedia.MediaStore.SimpleMessaging.MediaServiceXmlUtilities;
using AgileSoftware.Multimedia.MediaStore.SimpleMessaging.Client;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Proxies;
#endregion

namespace SMSHandlingApplication
{

    public partial class SMSHandlingForm : Form
    {
        #region declarations
                
        ASXMLClient xmlClient;
        ASMediaClient mediaClient;
        enASXMLClientError err;
        MediaStoreInfoList mediaStoreList = null;
        IASGQEMediaStore smms = null;
        ASGQEWorkItemBase2 workItem = null;
        public ISimpleMessagingClient smmsclient;
        SMSWindow sms_window = new SMSWindow();
        CSTAConnectionID connID;
        string conn_CallID;
        string conn_DeviceID;
        string error_connectMS = string.Empty;

        //SMS client initialization
        string messages = String.Empty;
        string mediaTypeName = String.Empty;
        bool mediaconnected = false;
        bool available2send = false;
        List<SMSimpleMessage> messageList = null;
        string customername; 
        string initialMessage;

        //Log File
        public static readonly ILog log = LogManager.GetLogger(typeof(SMSHandlingForm));

        #endregion

        #region enumerations
        //Enumeration to maintain XML Server Connection State
        enum Connection
        {
            Connect,
            Disconnect,
            AlreadyConnected
        };
        Connection connectionState = Connection.Disconnect;

        //Enumeration to maintain Monitor State
        enum MonitorState
        {
            MonitorStart,
            MonitorStop
        };
        MonitorState monitor_state = MonitorState.MonitorStop;
        #endregion

        #region mainForm 
        public SMSHandlingForm()
        {
            xmlClient = new ASXMLClient();
            //Initializes a new instance of AgileSoftware.Developer.ASXMLClient class. 
            mediaClient = new ASMediaClient();
            //Initializes a new instance of AgileSoftware.Multimedia.ASMediaClient class.


            InitializeComponent();
            buildEventHandlers();

            //Configures Log File
            XmlConfigurator.Configure();
            xmlClient.LogTraceToFile = true;
            xmlClient.TraceFilePathName = "XmlLogEntries.log";

            log.Info("Initialized AgentLoginApplication");
        }

        #endregion
       
        #region buildEvents
        //Subscribe to Events
        private void buildEventHandlers()
        {
            //Subscribe to ASXMLClient Events
            xmlClient.XMLEnumerateServicesReturned += new XMLEnumerateServicesReturnedEventHandler(xmlClient_XMLEnumerateServicesReturned);
            xmlClient.StreamConnected += new EventHandler(xmlClient_StreamConnected);
            xmlClient.SocketConnected += new EventHandler(xmlClient_SocketConnected);
            xmlClient.CSTAMonitorStartResponse += new CSTAMonitorStartResponseEventHandler(xmlClient_CSTAMonitorStartResponse);
            xmlClient.CSTAAgentReady += new CSTAAgentReadyEventHandler(xmlClient_CSTAAgentReady);
            xmlClient.CSTAAgentNotReady += new CSTAAgentNotReadyEventHandler(xmlClient_CSTAAgentNotReady);
            xmlClient.CSTAAgentLoggedOn+=new CSTAAgentLoggedOnEventHandler(xmlClient_CSTAAgentLoggedOn);
            xmlClient.CSTAAgentLoggedOff+=new CSTAAgentLoggedOffEventHandler(xmlClient_CSTAAgentLoggedOff);
            xmlClient.CSTAAgentWorkingAfterCall += new CSTAAgentWorkingAfterCallEventHandler(xmlClient_CSTAAgentWorkingAfterCall);
            xmlClient.CSTAGetAgentStateResponse += new CSTAGetAgentStateResponseEventHandler(xmlClient_CSTAGetAgentStateResponse);
            xmlClient.CSTAMonitorStopResponse += new CSTABasicResponseEventHandler(xmlClient_CSTAMonitorStopResponse);
            xmlClient.CSTADelivered += new CSTADeliveredEventHandler(xmlClient_CSTADelivered);
            xmlClient.CSTAEstablished += new CSTAEstablishedEventHandler(xmlClient_CSTAEstablished);
            xmlClient.CSTACallCleared += new CSTACallClearedEventHandler(xmlClient_CSTACallCleared);
            xmlClient.CSTAConnectionCleared += new CSTAConnectionClearedEventHandler(xmlClient_CSTAConnectionCleared);

            //Subscribe to ASMediaClient
            mediaClient.MediaTypeRegistered += new AgileSoftware.Multimedia.Client.MediaTypeRegisteredEventHandler(mediaClient_MediaTypeRegistered);
            mediaClient.MediaTypeUnregistered += new AgileSoftware.Multimedia.Client.MediaTypeUnregisteredEventHandler(mediaClient_MediaTypeUnregistered);
            mediaClient.GQEError += new GQEErrorEventHandler(mediaClient_GQEError);
            mediaClient.WorkItemRefDelivered += new AgileSoftware.Multimedia.Client.WorkItemRefDeliveredEventHandler(mediaClient_WorkItemRefDelivered);
            mediaClient.WorkItemRefEstablished += new AgileSoftware.Multimedia.Client.WorkItemRefEstablishedEventHandler(mediaClient_WorkItemRefEstablished);
            mediaClient.WorkItemRefRemoved += new AgileSoftware.Multimedia.Client.WorkItemRefRemovedEventHandler(mediaClient_WorkItemRefRemoved);

            //Application Exit
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
            log.Info("Exited SMS Handling Application");
            Environment.Exit(0);
        }
        #endregion

        #region clearEvents
        //Clears Events Subscribed
        private void clearEventHandlers()
        {
            //Clear ASXMLClient Events
            xmlClient.XMLEnumerateServicesReturned -= new XMLEnumerateServicesReturnedEventHandler(xmlClient_XMLEnumerateServicesReturned);
            xmlClient.StreamConnected -= new EventHandler(xmlClient_StreamConnected);
            xmlClient.SocketConnected -= new EventHandler(xmlClient_SocketConnected);
            xmlClient.CSTAMonitorStartResponse -= new CSTAMonitorStartResponseEventHandler(xmlClient_CSTAMonitorStartResponse);
            xmlClient.CSTAAgentLoggedOn -= new CSTAAgentLoggedOnEventHandler(xmlClient_CSTAAgentLoggedOn);
            xmlClient.CSTAAgentLoggedOff -= new CSTAAgentLoggedOffEventHandler(xmlClient_CSTAAgentLoggedOff);
            xmlClient.CSTAAgentReady -= new CSTAAgentReadyEventHandler(xmlClient_CSTAAgentReady);
            xmlClient.CSTAAgentNotReady -= new CSTAAgentNotReadyEventHandler(xmlClient_CSTAAgentNotReady);
            xmlClient.CSTAAgentWorkingAfterCall -= new CSTAAgentWorkingAfterCallEventHandler(xmlClient_CSTAAgentWorkingAfterCall);
            xmlClient.CSTAGetAgentStateResponse -= new CSTAGetAgentStateResponseEventHandler(xmlClient_CSTAGetAgentStateResponse);
            xmlClient.CSTAMonitorStopResponse -= new CSTABasicResponseEventHandler(xmlClient_CSTAMonitorStopResponse);
            xmlClient.CSTADelivered -= new CSTADeliveredEventHandler(xmlClient_CSTADelivered);
            xmlClient.CSTAEstablished -= new CSTAEstablishedEventHandler(xmlClient_CSTAEstablished);
            xmlClient.CSTACallCleared -= new CSTACallClearedEventHandler(xmlClient_CSTACallCleared);
            xmlClient.CSTAConnectionCleared -= new CSTAConnectionClearedEventHandler(xmlClient_CSTAConnectionCleared);

            //Clears ASMediaClient Events
            mediaClient.MediaTypeRegistered -= new AgileSoftware.Multimedia.Client.MediaTypeRegisteredEventHandler(mediaClient_MediaTypeRegistered);
            mediaClient.GQEError -= new GQEErrorEventHandler(mediaClient_GQEError);
            mediaClient.WorkItemRefDelivered -= new AgileSoftware.Multimedia.Client.WorkItemRefDeliveredEventHandler(mediaClient_WorkItemRefDelivered);
            mediaClient.WorkItemRefEstablished -= new AgileSoftware.Multimedia.Client.WorkItemRefEstablishedEventHandler(mediaClient_WorkItemRefEstablished);
            mediaClient.WorkItemRefRemoved -= new AgileSoftware.Multimedia.Client.WorkItemRefRemovedEventHandler(mediaClient_WorkItemRefRemoved);
        }
        #endregion

        #region monitor
        //Start or stop to monitor a device
        private void btnMonitor_Click(object sender, EventArgs e)
        {
            //Monitor Start
            if (monitor_state == MonitorState.MonitorStop)
            {
                if (txtStationID.Text.Length > 0)
                {
                    string station = txtStationID.Text.Trim();
                    bool isStation = checkNum(station);
                    if (isStation)
                    {
                        //Method used: CSTAMonitorStart(CSTADeviceID, enMonitorType, CSTAMonitorFilter)
                        //Start monitor a device object. A CSTAMonitor object will be added into the CSTAMonitorList if monitor successfully. 
                        //Parameter: 
                        //DeviceObject (CSTADeviceID) - The device that the monitor will be placed on. 
                        //MonitorType (enMonitorType) - Indicates a monitor type when starting a monitor.
                        //Call-type: is used to track a perticular existing call, for as long as that call remains in the switching sub-domain. No supported for this version.
                        //Device-type: is used to track all the calls while they still remain at the specified device. 
                        //MonitorFilter (CSTAMonitorFilter) - Indicates which events will be filtered out when starting a monitor. No events will be filtered if a null or nothing is assigned to it. It is presented as the RequestMonitorFilter property of the CSTAMonitor object.
                        //CSTAMonitorStartResponse will bw fired
                        xmlClient.CSTAMonitorStart(new CSTADeviceID(txtStationID.Text.Trim(), enDeviceIDType.deviceNumber), enMonitorType.device, new CSTAMonitorFilter());
                    }
                    else
                    {
                        MessageBox.Show("Invalid Station ID");
                        log.Error("Invalid Station ID entered");
                        txtStationID.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Station ID not entered", "Station ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Station ID not entered");
                    txtStationID.Focus();
                }
            }

            //Monitor Stop
            if (monitor_state == MonitorState.MonitorStart)
            {
                //If Agent is Logged in first Logs off Agent and then Stops Monitor.
                if (agent_state == AgentState.agentLoggedOn || agent_state == AgentState.agentNotReady || agent_state == AgentState.agentReady || agent_state == AgentState.agentWorkingAfterCall)
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
                //Method used: CSTAMonitorStop(CSTAMonitor)
                // Used to cancel a previously initiated Monitor Start service.  
                //Parameter:
                //thisCSTAMonitor (CSTAMonitor) - One of the CSTAMonitor object listed in the CSTAMonitorList.
                //CSTAMonitorStopResponse will be fired.
                xmlClient.CSTAMonitorStop(xmlClient.CSTAMonitorList[0]);
            }
        }

        //The positive acknowledgement event for CSTAMonitorStart(CSTAConnectionID, enMonitorType, CSTAMonitorFilter) method. 
        void xmlClient_CSTAMonitorStartResponse(object sender, CSTAMonitorStartResponseEventArgs arg)
        {
            rtbStatus.Text = "Monitor Started";
            log.Info("Monitor " + arg.MonitorCrossRefID + " Started");
            monitor_state = MonitorState.MonitorStart;
            MonitorStarted();
            string myStationID;
            myStationID = txtStationID.Text.Trim();
            CSTADeviceID thisStation = new CSTADeviceID(myStationID, enDeviceIDType.deviceNumber);
            xmlClient.CSTAGetAgentState(thisStation);

        }

        //Monitor Started
        private void MonitorStarted()
        {
            btnLogInOut.Enabled = true;
            btnMonitor.Text = "Monitor Stop";
            gbMediaDirDetails.Enabled = true;
            myToolTip.SetToolTip(btnMonitor, "Monitor Stop");
        }

        //Positive acknowledgement event for CSTAMonitorStop() method. 
        void xmlClient_CSTAMonitorStopResponse(object sender, CSTABasicResponseEventArgs arg)
        {
            rtbStatus.Text = "Monitor stopped";
            log.Info("Monitor Stopped");
            monitor_state = MonitorState.MonitorStop;
            MonitorStopped();
        }

        //Monitor Stopped
        private void MonitorStopped()
        {
            btnAvailable.Enabled = false;
            btnACW.Enabled = false;
            btnAux.Enabled = false;
            btnLogInOut.Enabled = false;
            btnMonitor.Text = "Monitor Start";
            myToolTip.SetToolTip(btnMonitor, "Stop Monitor");
        }
        #endregion

        #region browseLinks
        //Browse for available links
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //Check for XML Server IP and Port entered. If entered are they valid. 
            //If valid then make a connection with XML Server IP

            if ((txtServerIP.Text.Length <= 0) && (txtServerPort.Text.Length <= 0))
            {
                MessageBox.Show("XML Server IP and Port not entered.", "XML Server IP and Port", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("XML Server IP and Port not entered");
                txtServerIP.Focus();
            }
            else if (txtServerIP.Text.Length <= 0)
            {
                MessageBox.Show("XML Server IP not entered.", "XML Server IP ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("XML Server IP not entered");
                txtServerIP.Focus();
            }
            else if (txtServerPort.Text.Length <= 0)
            {
                MessageBox.Show("XML Server Port not entered.", "XML Server Port", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("XML Server Port not entered");
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

        //Fires when XMLEnumerateServices() method is invoked. 
        void xmlClient_XMLEnumerateServicesReturned(object sender, XMLEnumerateServicesReturnedEventArgs arg)
        {
            cmbTServerLinks.Items.Clear();
            for (int i = 0; i < arg.TLinkConnectionList.Count; i++)
            {
                cmbTServerLinks.Items.Add(arg.TLinkConnectionList[i].TServerLinkName);
            }
            LinksBrowsed();
        }

        //Links Browsed
        private void LinksBrowsed()
        {
            cmbTServerLinks.Text = cmbTServerLinks.Items[0].ToString();
            btnConnection.Enabled = true;
            btnConnection.Text = "Connect";
        }
        #endregion

        #region validationFunctions
        //This function is used to validate the IP address. Returns true if the IP is valid otherwise false.
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
        #endregion

        #region connectToXMLServer
        //Selects one of the Available Links and establishes connection with XML Server. 
        //Disconnects already established connection.
        private void btnConnection_Click(object sender, EventArgs e)
        {
            //Connect
            if (connectionState == Connection.Disconnect)
            {
                xmlClient.TServerLinkName = cmbTServerLinks.Text.Trim();
                //Method used: Connect()
                //Connects to the Active XML Server using naming service. Accepts  ServerIP, ServerPort and TServerLinkName values.
                //The SocketConnected event and StreamConnected event will fire if connecting to the XML Server and TServer successfully. 

                err = xmlClient.Connect();
                rtbStatus.Text = err.ToString();
            }

            //Disconnect
            if (connectionState == Connection.Connect || connectionState == Connection.AlreadyConnected)
            {
                //Logs off Agent if Agent is in Logged On state.

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

            //Already connected
            if (err.ToString().Equals("AlreadyConnected"))
            {
                connectionState = Connection.AlreadyConnected;
                btnConnection.Text = "Disconnect";
            }
        }

        //Fires when the component established a socket connection with the Active XML Server.
        void xmlClient_SocketConnected(object sender, EventArgs e)
        {
            rtbStatus.Text = "Socket Connected";
            log.Info("Socket Connected");
        }

        // Fires when the XML server created a stream connection with the TSever on behalf of the component.  
        void xmlClient_StreamConnected(object sender, EventArgs e)
        {
            rtbStatus.Text = "Stream Connected";
            log.Info("Stream Connected");
            connectionState = Connection.Connect;
            ConnectionEstablished();
        }

        //Connection Established
        private void ConnectionEstablished()
        {
            btnConnection.Text = "Disconnect";
            gbAgentDetails.Enabled = true;
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
            btnAux.Enabled = false;
            btnACW.Enabled = false;
            txtAgentID.Clear();
            txtAgentPwd.Clear();
            txtStationID.Clear();
            btnConnection.Text = "Connect";
            myToolTip.SetToolTip(btnConnection, "Connect to XML Server");
            gbAgentDetails.Enabled = false;
        }
        #endregion
    }
}
   
    

