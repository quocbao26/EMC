//This application will be used to have a Web Chat with the Customer.
//This file contains all the Declarations.


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

namespace WebChatApplication
 {
    public partial class WebChatApplication : Form
    {
        //Declarations
        ASXMLClient xmlClient;
        enASXMLClientError xmlError;
        
        ASMediaClient mediaClient;

        //Web chat variables
        MediaStoreInfoList mediaStoreList;
        IASGQEMediaStore smms;
        ASGQEWorkItemBase2 workItem;
        ISimpleMessagingClient smmsClient;
        string messages = String.Empty;
        string mediaTypeName = String.Empty;
        bool mediaconnected = false;
        bool available2send = false;
        List<SMSimpleMessage> messageList = null;
        string customername;
        string sendingText;

        //Phantom Call variables
        CSTAConnectionID connID;
        string conn_CallID;
        string conn_DeviceID;

        //Enumeration to maintain connection state with XML Server
        enum XMLConnection
        {
            Connected,
            Disconnected,
            AlreadyConnected
        };
        XMLConnection xml_connection = XMLConnection.Disconnected;

        //Enumeration to maintain Agent State 
        enum AgentState
        {
            agentReady,
            agentNotReady,
            agentLoggedOn,
            agentLoggedOff,
            agentWorkingAfterCall
        };
        AgentState agent_state = AgentState.agentLoggedOff;

        //Enumeration to maintain Monitor State
        enum MonitorState
        {
            MonitorStart,
            MonitorStop
        };
        MonitorState monitor_state = MonitorState.MonitorStop;

        //Enumeration to maintain Media Director Connection State
        enum MediaDirectorState
        {
            Connected,
            Disconnected
        };
        MediaDirectorState mediaDir_state = MediaDirectorState.Disconnected;

        //Maintain log file
        public static readonly ILog log = LogManager.GetLogger(typeof(WebChatApplication));

        //Dictionary that stores system messages related to Web Chat
        public static Dictionary<int, string> dictionary = new Dictionary<int, string>();

           

        public WebChatApplication()
        {
            xmlClient = new ASXMLClient();
            
            mediaClient = new ASMediaClient();


            dictionary.Add(102845, "The conversation session has been closed. Thank you.");
            dictionary.Add(102849, "The conversation session has been closed because it was idle.");
            dictionary.Add(4180, "The conversation with the customer has been closed.");
            dictionary.Add(4181, "This window will be closed");

            InitializeComponent();

            XmlConfigurator.Configure();
            xmlClient.LogTraceToFile = true;
            xmlClient.TraceFilePathName = "XMLLogEntries.log";
            log.Info("Web Chat Application started");
        }

        //Function that Subscribes to Events
        private void buildEventHandlers()
        {
            //ASXMLClient Events
            xmlClient.XMLEnumerateServicesReturned += new XMLEnumerateServicesReturnedEventHandler(xmlClient_XMLEnumerateServicesReturned);
            xmlClient.SocketConnected += new EventHandler(xmlClient_SocketConnected);
            xmlClient.StreamConnected += new EventHandler(xmlClient_StreamConnected);
            xmlClient.CSTAErrorReturned += new CSTAErrorReturnedEventHandler(xmlClient_CSTAErrorReturned);
            xmlClient.CSTAMonitorStartResponse += new CSTAMonitorStartResponseEventHandler(xmlClient_CSTAMonitorStartResponse);
            xmlClient.CSTAMonitorStopResponse += new CSTABasicResponseEventHandler(xmlClient_CSTAMonitorStopResponse);
            xmlClient.CSTAAgentLoggedOn += new CSTAAgentLoggedOnEventHandler(xmlClient_CSTAAgentLoggedOn);
            xmlClient.CSTAAgentLoggedOff += new CSTAAgentLoggedOffEventHandler(xmlClient_CSTAAgentLoggedOff);
            xmlClient.CSTAAgentNotReady += new CSTAAgentNotReadyEventHandler(xmlClient_CSTAAgentNotReady);
            xmlClient.CSTAAgentReady += new CSTAAgentReadyEventHandler(xmlClient_CSTAAgentReady);
            xmlClient.CSTAAgentWorkingAfterCall += new CSTAAgentWorkingAfterCallEventHandler(xmlClient_CSTAAgentWorkingAfterCall);
            xmlClient.CSTAGetAgentStateResponse += new CSTAGetAgentStateResponseEventHandler(xmlClient_CSTAGetAgentStateResponse);
            xmlClient.CSTADelivered += new CSTADeliveredEventHandler(xmlClient_CSTADelivered);
            xmlClient.CSTAEstablished += new CSTAEstablishedEventHandler(xmlClient_CSTAEstablished);


            //ASMediaClient Events
            mediaClient.MediaTypeRegistered += new AgileSoftware.Multimedia.Client.MediaTypeRegisteredEventHandler(mediaClient_MediaTypeRegistered);
            mediaClient.MediaTypeUnregistered += new AgileSoftware.Multimedia.Client.MediaTypeUnregisteredEventHandler(mediaClient_MediaTypeUnregistered);
            mediaClient.GQEError += new GQEErrorEventHandler(mediaClient_GQEError);
            mediaClient.WorkItemRefDelivered += new AgileSoftware.Multimedia.Client.WorkItemRefDeliveredEventHandler(mediaClient_WorkItemRefDelivered);
            mediaClient.WorkItemRefEstablished += new AgileSoftware.Multimedia.Client.WorkItemRefEstablishedEventHandler(mediaClient_WorkItemRefEstablished);
            mediaClient.WorkItemRefRemoved += new AgileSoftware.Multimedia.Client.WorkItemRefRemovedEventHandler(mediaClient_WorkItemRefRemoved);

            //Application Events
            Application.ApplicationExit +=new EventHandler(Application_ApplicationExit);
        }

        //Function that clears subscribed events
        private void clearEventHandlers()
        {
            //ASXMLClient Events
            xmlClient.XMLEnumerateServicesReturned -= new XMLEnumerateServicesReturnedEventHandler(xmlClient_XMLEnumerateServicesReturned);
            xmlClient.SocketConnected -= new EventHandler(xmlClient_SocketConnected);
            xmlClient.StreamConnected -= new EventHandler(xmlClient_StreamConnected);
            xmlClient.CSTAErrorReturned -= new CSTAErrorReturnedEventHandler(xmlClient_CSTAErrorReturned);
            xmlClient.CSTAMonitorStartResponse -= new CSTAMonitorStartResponseEventHandler(xmlClient_CSTAMonitorStartResponse);
            xmlClient.CSTAMonitorStopResponse -= new CSTABasicResponseEventHandler(xmlClient_CSTAMonitorStopResponse);
            xmlClient.CSTAAgentLoggedOn -= new CSTAAgentLoggedOnEventHandler(xmlClient_CSTAAgentLoggedOn);
            xmlClient.CSTAAgentLoggedOff -= new CSTAAgentLoggedOffEventHandler(xmlClient_CSTAAgentLoggedOff);
            xmlClient.CSTAAgentNotReady -= new CSTAAgentNotReadyEventHandler(xmlClient_CSTAAgentNotReady);
            xmlClient.CSTAAgentReady -= new CSTAAgentReadyEventHandler(xmlClient_CSTAAgentReady);
            xmlClient.CSTAAgentWorkingAfterCall -= new CSTAAgentWorkingAfterCallEventHandler(xmlClient_CSTAAgentWorkingAfterCall);
            xmlClient.CSTAGetAgentStateResponse -= new CSTAGetAgentStateResponseEventHandler(xmlClient_CSTAGetAgentStateResponse);
            xmlClient.CSTADelivered -= new CSTADeliveredEventHandler(xmlClient_CSTADelivered);
            xmlClient.CSTAEstablished -= new CSTAEstablishedEventHandler(xmlClient_CSTAEstablished);


            //ASMediaClient Events
            mediaClient.MediaTypeRegistered -= new AgileSoftware.Multimedia.Client.MediaTypeRegisteredEventHandler(mediaClient_MediaTypeRegistered);
            mediaClient.MediaTypeUnregistered -= new AgileSoftware.Multimedia.Client.MediaTypeUnregisteredEventHandler(mediaClient_MediaTypeUnregistered);
            mediaClient.GQEError -= new GQEErrorEventHandler(mediaClient_GQEError);
            mediaClient.WorkItemRefDelivered -= new AgileSoftware.Multimedia.Client.WorkItemRefDeliveredEventHandler(mediaClient_WorkItemRefDelivered);
            mediaClient.WorkItemRefEstablished -= new AgileSoftware.Multimedia.Client.WorkItemRefEstablishedEventHandler(mediaClient_WorkItemRefEstablished);
            mediaClient.WorkItemRefRemoved -= new AgileSoftware.Multimedia.Client.WorkItemRefRemovedEventHandler(mediaClient_WorkItemRefRemoved);

            //Application Events
            Application.ApplicationExit -= new EventHandler(Application_ApplicationExit);
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

        //Application Exit
        void Application_ApplicationExit(object sender, EventArgs e)
        {
            XMLServerDisconnected();
            log.Info("Exited Web Chat Application");
            Environment.Exit(0);
        }

    

        
    }
}
