//This class is used to Start/Stop Monitor a station.

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

namespace VoiceCallHandlingApplication
{
    public partial class VoiceCallHandlingForm : Form
    {
        //Starts or Stops Monitor a particular station.
        private void btnMonitorStart_Click(object sender, EventArgs e)
        {
            //Monitor Start
            if (monitor_state == MonitorState.MonitorStop)
            {

                if (txtbStationID.Text.Length > 0)
                {
                    string station = txtbStationID.Text.Trim();
                    bool isStation = checkNum(station);
                    if (isStation)
                    {
                        xmlStation.StationDN = txtbStationID.Text.Trim();
                        xmlStation.CSTASource = xmlClient;
                    }
                    else
                    {
                        MessageBox.Show("Invalid Station ID");
                        log.Error("Invalid Station ID entered");
                        txtbStationID.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Station ID not entered", "Station ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Station ID not entered");
                    txtbStationID.Focus();
                }
            }

            //Monitor Stop
            if (monitor_state == MonitorState.MonitorStart)
            {
                //If Agent is Logged in first Logs off Agent and then Stops Monitor.
                if (agent_state == AgentState.agentLoggedOn || agent_state == AgentState.agentNotReady || agent_state == AgentState.agentReady || agent_state == AgentState.agentWorkingAfterCall)
                {
                    xmlClient.CSTASetAgentState(new CSTADeviceID(txtbStationID.Text.Trim(), enDeviceIDType.deviceNumber), enReqAgentState.loggedOff, txtbAgentID.Text.Trim(), txtbAgentPassword.Text.Trim(), null, null);
                }
                xmlClient.CSTAMonitorStop(xmlClient.CSTAMonitorList[0]);
            }
        }

        void xmlStation_MonitorStarted(object sender, EventArgs e)
        {
            rtbStatus.Text = "Monitor Started";
            monitor_state = MonitorState.MonitorStart;
            MonitorStarted();
            string myStation = txtbStationID.Text.Trim();
            CSTADeviceID myDevice = new CSTADeviceID(myStation, enDeviceIDType.deviceNumber);
            xmlClient.CSTAGetAgentState(myDevice);
        }

        private void MonitorStarted()
        {
            btnLogin.Enabled = true;
            btnMonitorStart.Text = "Monitor Stop";
            gbTelephony.Enabled = true;
            BuildTextBoxEvents();
            lblStation.Text = txtbStationID.Text.Trim();
        }

        void xmlStation_MonitorStopped(object sender, EventArgs e)
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
            btnLogin.Enabled = false;
            btnMonitorStart.Text = "Monitor Start";
            txtbDialNumber.Text = "";
            txtbTransferCall.Text = "";
            lblStation.Text = "";
            lblIncomingCall.Text = "";
            cmbType.Text = cmbType.Items[0].ToString();
            gbTelephony.Enabled = false;
        }


    }
}
