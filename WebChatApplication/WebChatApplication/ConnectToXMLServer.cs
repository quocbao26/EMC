//This class is used to browse for available TServer Links and connect to the XML Server.

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
using AgileSoftware.Developer.XML;
using System.Threading;
using System.Text.RegularExpressions;
using log4net;
using log4net.Config;
using System.Drawing.Imaging;

namespace WebChatApplication
{
    public partial class WebChatApplication
    {
        //It takes as input the Server IP and Server Port address and will return available Server Links.
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            buildEventHandlers();
            if ((txtXMLServerIP.Text.Length <= 0) && (txtXMLServerPort.Text.Length <= 0))
            {
                MessageBox.Show("Enter valid Server IP and Port Number", "Server IP and Port", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Server IP and Port not entered");
                txtXMLServerIP.Focus();
            }
            else if (txtXMLServerIP.Text.Length <= 0)
            {
                MessageBox.Show("Enter valid Server IP", "Server IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Server IP not entered");
                txtXMLServerIP.Focus();
            }
            else if (txtXMLServerPort.Text.Length <= 0)
            {
                MessageBox.Show("Enter valid Port Number", "Port", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Port not entered");
                txtXMLServerPort.Focus();
            }
            else
            {
                string _ip;
                string _no;
                _ip = txtXMLServerIP.Text;
                _no = txtXMLServerPort.Text;
                bool check_ip;
                bool check_no;
                check_ip = checkIP(_ip);
                check_no = checkNum(_no);

                if (!check_ip)
                {
                    MessageBox.Show("Enter valid Server IP", "Server IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Invalid IP entered");
                    txtXMLServerIP.Focus();
                }
                else if (!check_no)
                {
                    MessageBox.Show("Enter valid Port Number", "Port", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Invalid Port entered");
                    txtXMLServerPort.Focus();
                }
                else
                {
                    xml_connection = XMLConnection.Disconnected;
                    xmlClient.ServerIP = txtXMLServerIP.Text.Trim();
                    xmlClient.ServerPort = int.Parse(txtXMLServerPort.Text.Trim());
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
            btnConnect.Enabled = true;
            btnConnect.Text = "Connect";
        }

        //It will choose one of the Links returned and will make a connection to the EMC Server.
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //For Connect
            if (xml_connection == XMLConnection.Disconnected)
            {
                xmlClient.TServerLinkName = cmbTServerLinks.Text.Trim();
                xmlError = xmlClient.Connect();
                rtbStatus.Text = xmlError.ToString();
            }

            //For Disconnect
            if (xml_connection == XMLConnection.Connected || xml_connection == XMLConnection.AlreadyConnected)
            {
                //Logs off Agent if Agent is Logged On
                if (agent_state == AgentState.agentLoggedOn || agent_state == AgentState.agentReady || agent_state == AgentState.agentNotReady || agent_state == AgentState.agentWorkingAfterCall)
                {
                    string stationID = txtStationID.Text.Trim();
                    string agentID = txtAgentID.Text.Trim();
                    string agentPwd = txtAgentPwd.Text.Trim();
                    xmlClient.CSTASetAgentState(new CSTADeviceID(stationID, enDeviceIDType.deviceNumber), enReqAgentState.loggedOff, agentID, agentPwd, null, null);
                }

                //Stop monitor initiated before
                if (monitor_state == MonitorState.MonitorStart)
                {
                    xmlClient.CSTAMonitorStop(xmlClient.CSTAMonitorList[0]);
                }
                
                xmlError = xmlClient.Disconnect();
                if (xmlError.ToString().Equals("NoError"))
                {
                    rtbStatus.Text = "Disconnected.";
                    log.Info("Server Disconnected");
                    xml_connection = XMLConnection.Disconnected;
                    
                    XMLServerDisconnected();
                    this.Close();
                    log.Info("Web Chat Application Closed.");
                }
                else
                    rtbStatus.Text = xmlError.ToString();
            }

            //Already Connected
            if (xmlError.ToString().Equals("AlreadyConnected"))
            {
                btnConnect.Text = "Disconnect";
            }
        }

        //Fires when the component established a socket connection with the Active XML Server
        void xmlClient_SocketConnected(object sender, EventArgs e)
        {
            rtbStatus.Text = "Socket Connected.";
            log.Info("Socket Connected");
        }

        //Fires when the XML server created a stream connection with the TSever on behalf of the component. 
        void xmlClient_StreamConnected(object sender, EventArgs e)
        {
            rtbStatus.Text = "Stream Connected. ";
            log.Info("Stream Connected");
            xml_connection = XMLConnection.Connected;
            XMLServerConnected();
        }

        //Connected to XML Server
        private void XMLServerConnected()
        {
            gbAgentDetails.Enabled = true;
            lblAgentID.Enabled = true;
            lblAgentPwd.Enabled = true;
            lblStationID.Enabled = true;
            txtStationID.Enabled = true;
            txtAgentID.Enabled = true;
            txtAgentPwd.Enabled = true;
            btnMonitor.Enabled = true;
            btnConnect.Text = "Disconnect";
            myToolTip.SetToolTip(btnConnect, "Disconnect from XML Server");
        }

        //Disconnect from XML Server
        private void XMLServerDisconnected()
        {
            clearEventHandlers();
            Image img = Image.FromFile(@"..\..\Resources\images\login.png");
            gbAgentDetails.Enabled = false;
            lblAgentID.Enabled = false;
            lblAgentPwd.Enabled = false;
            lblStationID.Enabled = false;
            txtStationID.Enabled = false;
            txtAgentID.Enabled = false;
            txtAgentPwd.Enabled = false;
            btnMonitor.Enabled = false;
            btnLogin.Enabled = false;
            btnMonitor.Text = "Monitor Start";
            btnLogin.Image = img;
            myToolTip.SetToolTip(btnLogin, "Agent Login");
            btnAvailable.Enabled = false;
            btnAux.Enabled = false;
            btnACW.Enabled = false;
            txtAgentID.Clear();
            txtAgentPwd.Clear();
            txtStationID.Clear();
            btnConnect.Text = "Connect";
            myToolTip.SetToolTip(btnConnect, "Connect to XML Server");
        }
    
        //Fires to report CSTA error from Server.
        void xmlClient_CSTAErrorReturned(object sender, CSTAErrorReturnedEventArgs arg)
        {
            rtbStatus.Text = "Error Occurred: " + " Category: " + arg.Error.Category + " Description: " + arg.Error.ValueDescription;
            log.Error("CSTA Error occurred" + arg.Error.ValueDescription);
        }

    
    }
}
