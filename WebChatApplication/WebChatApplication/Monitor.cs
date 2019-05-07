//This class starts/stops monitoring a device and sets agent to respective state.

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
        //Start/Stop monitoring a device
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
                        string stationID = txtStationID.Text.Trim();
                        xmlClient.CSTAMonitorStart(new CSTADeviceID(stationID, enDeviceIDType.deviceNumber), enMonitorType.device, new CSTAMonitorFilter());
                    }
                    else
                    {
                        MessageBox.Show("Enter Valid StationID");
                        log.Error("Invalid Station ID entered");
                        txtStationID.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Enter Station ID", "Station ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Station ID not entered");
                    txtStationID.Focus();
                }
            }

            //Monitor Stop
            if (monitor_state == MonitorState.MonitorStart)
            {
                //Log off Agent if agent is Logged On
                if (agent_state == AgentState.agentLoggedOn || agent_state == AgentState.agentNotReady || agent_state == AgentState.agentReady || agent_state == AgentState.agentWorkingAfterCall)
                {
                    string stationID = txtStationID.Text.Trim();
                    string agentID = txtAgentID.Text.Trim();
                    string agentPwd = txtAgentPwd.Text.Trim();
                    xmlClient.CSTASetAgentState(new CSTADeviceID(stationID, enDeviceIDType.deviceNumber), enReqAgentState.loggedOff,agentID ,agentPwd , null, null);
                }
                xmlClient.CSTAMonitorStop(xmlClient.CSTAMonitorList[0]);
            }
        }

        //Positive acknowledgement event for CSTAMonitorStart(CSTAConnectionID, enMonitorType, CSTAMonitorFilter).
        void xmlClient_CSTAMonitorStartResponse(object sender, CSTAMonitorStartResponseEventArgs arg)
        {
            rtbStatus.Text = "Monitor Started";
            log.Info("Monitor " + arg.MonitorCrossRefID + " Started");
            monitor_state = MonitorState.MonitorStart;
            MonitorStarted();
            string myStationID;
            myStationID = txtStationID.Text.Trim();
            CSTADeviceID _thisStation = new CSTADeviceID(myStationID, enDeviceIDType.deviceNumber);
            xmlClient.CSTAGetAgentState(_thisStation);
        }
               
        //Start Monitor
        private void MonitorStarted()
        {
            btnLogin.Enabled = true;
            btnMonitor.Text = "Monitor Stop";
            gbMDDetails.Enabled = true;
        }

        void xmlClient_CSTAMonitorStopResponse(object sender, CSTABasicResponseEventArgs arg)
        {
            rtbStatus.Text = "Monitor stopped";
            log.Info("Monitor Stopped");
            monitor_state = MonitorState.MonitorStop;
            MonitorStopped();
        }

        //Monitor Stop
        private void MonitorStopped()
        {
            btnAvailable.Enabled = false;
            btnACW.Enabled = false;
            btnAux.Enabled = false;
            btnLogin.Enabled = false;
            btnMonitor.Text = "Monitor Start";
            gbMDDetails.Enabled = false;
        }

       

    }
}
