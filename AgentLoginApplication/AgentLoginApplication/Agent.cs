//This class maintains Agent State changes 

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

namespace AgentLoginApplication
{
    public partial class AgentLoginForm
    {
        //Enumeration to maintain Monitor State
        enum MonitorState
        {
            MonitorStart,
            MonitorStop
        };
        MonitorState monitor_state = MonitorState.MonitorStop;

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

        #region Monitor
        
        //Starts/Stops to monitor a device object. 
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
                        xmlClient.CSTAMonitorStart(new CSTADeviceID(txtbStationID.Text.Trim(), enDeviceIDType.deviceNumber), enMonitorType.device, null);
                    }
                    else
                    {
                        MessageBox.Show("Enter Valid StationID");
                        log.Error("Invalid Station ID entered");
                        txtbStationID.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Enter Station ID", "Station ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Station ID not entered");
                    txtbStationID.Focus();
                }
            }

            //Monitor Stop
            if (monitor_state == MonitorState.MonitorStart)
            {
                //Log off Agent if agent is Logged On
                if (agent_state == AgentState.agentLoggedOn || agent_state == AgentState.agentNotReady || agent_state == AgentState.agentReady || agent_state == AgentState.agentWorkingAfterCall)
                {
                    xmlClient.CSTASetAgentState(new CSTADeviceID(txtbStationID.Text.Trim(), enDeviceIDType.deviceNumber), enReqAgentState.loggedOff, txtbAgentID.Text.Trim(), txtbAgentPassword.Text.Trim(), null, null);
                }
                xmlClient.CSTAMonitorStop(xmlClient.CSTAMonitorList[0]);
            }
        }

        //Positive acknowledgement event for CSTAMonitorStart(CSTAConnectionID, enMonitorType, CSTAMonitorFilter).
        void myClient_CSTAMonitorStartResponse(object sender, CSTAMonitorStartResponseEventArgs arg)
        {
            rtbStatus.Text = "Monitor Started";
            log.Info("Monitor " + arg.MonitorCrossRefID + " Started");
            monitor_state = MonitorState.MonitorStart;
            MonitorStarted();
            string _myStationID;
            _myStationID = txtbStationID.Text.Trim();
            CSTADeviceID thisStation = new CSTADeviceID(_myStationID, enDeviceIDType.deviceNumber);
            xmlClient.CSTAGetAgentState(thisStation);
        }

        //Start Monitor
        private void MonitorStarted()
        {
            btnLogin.Enabled = true;
            btnMonitorStart.Text = "Monitor Stop";
        }

        //Positive acknowledgement event for CSTAMonitorStop(CSTAMonitor)
        void myClient_CSTAMonitorStopResponse(object sender, CSTABasicResponseEventArgs arg)
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
            btnMonitorStart.Text = "Monitor Start";
        }

        #endregion

        #region AgentState
        //Agent is Logged on/Logged Off to a particalar ACD device.
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Agent Login
            if (agent_state == AgentState.agentLoggedOff)
            {
                if (txtbAgentID.Text.Length > 0)
                {
                    string ag_id = txtbAgentID.Text;
                    bool isagentID = checkNum(ag_id);
                    if (isagentID)
                    {
                        if (txtbAgentPassword.Text.Length > 0)
                        {
                            string ag_pwd = txtbAgentPassword.Text;
                            bool isagentpwd = checkNum(ag_pwd);
                            if (isagentpwd)
                            {
                                xmlClient.CSTASetAgentState(new CSTADeviceID(txtbStationID.Text.Trim(), enDeviceIDType.deviceNumber), enReqAgentState.loggedOn, txtbAgentID.Text.Trim(), txtbAgentPassword.Text.Trim(), null, null);
                            }
                            else
                            {
                                MessageBox.Show("Enter Valid Agent Password", "Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                log.Error("Invalid agent Password entered");
                                txtbAgentPassword.Focus();
                            }
                        }
                        else
                        {
                            xmlClient.CSTASetAgentState(new CSTADeviceID(txtbStationID.Text.Trim(), enDeviceIDType.deviceNumber), enReqAgentState.loggedOn, txtbAgentID.Text.Trim(), txtbAgentPassword.Text.Trim(), null, null);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Enter valid Agent ID", "Agent ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Agent ID not entered");
                    txtbAgentID.Focus();
                }
            }

            //Agent Logout
            if (agent_state == AgentState.agentLoggedOn || agent_state == AgentState.agentReady || agent_state == AgentState.agentNotReady || agent_state == AgentState.agentWorkingAfterCall)
            {
                xmlClient.CSTASetAgentState(new CSTADeviceID(txtbStationID.Text.Trim(), enDeviceIDType.deviceNumber), enReqAgentState.loggedOff, txtbAgentID.Text.Trim(), txtbAgentPassword.Text.Trim(), null, null);
            }
        }

        //This event fires when agent is logged on to a particular ACD device and is ready to contribute to the activities of an ACD device.
        void myClient_CSTAAgentLoggedOn(object sender, CSTAAgentLoggedOnEventArgs arg)
        {
            rtbStatus.Text = "Agent Logged On";
            log.Info("Agent  " + arg.AgentID + " Logged On");
            agent_state = AgentState.agentLoggedOn;
            AgentLoggedOn();
            xmlClient.CSTAGetAgentState(new CSTADeviceID(txtbStationID.Text.Trim(), enDeviceIDType.deviceNumber));
        }

        //Agent LoggedOn
        private void AgentLoggedOn()
        {
            Image img = Image.FromFile(@"..\..\Resources\images\logout.png");
            btnAvailable.Enabled = true;
            btnAux.Enabled = true;
            btnACW.Enabled = true;
            btnLogin.Image = img;
            myToolTip.SetToolTip(btnLogin, "Agent Logout");
        }

        //Positive acknowledgement event for CSTAGetAgentState(CSTADeviceID)
        void myClient_CSTAGetAgentStateResponse(object sender, CSTAGetAgentStateResponseEventArgs arg)
        {
            //logged_state - Stores Agent State
            bool logged_state = arg.AgentStateList[0].LoggedOnState;

            string _getAgentID = arg.AgentStateList[0].AgentID;
            if (logged_state)
            {
                //state - gets and stores Agent State
                string state = arg.AgentStateList[0].AgentInfo[0].AgentState.ToString();
                if (state.Equals("agentNotReady"))
                {
                    txtbAgentID.Text = _getAgentID;
                    rtbStatus.Text = "Agent in AUX state";
                    log.Info("Agent State : Aux");
                    agent_state = AgentState.agentNotReady;
                    AgentNotReady();
                }
                else if (state.Equals("agentReady"))
                {
                    txtbAgentID.Text = _getAgentID;
                    txtbAgentID.Text = _getAgentID;
                    rtbStatus.Text = "Agent in Available state";
                    log.Info("Agent State : Available");
                    agent_state = AgentState.agentReady;
                    AgentReady();
                }
                else if (state.Equals("agentWorkingAfterCall"))
                {
                    txtbAgentID.Text = _getAgentID;
                    rtbStatus.Text = "Agent in ACW state";
                    log.Info("Agent State : ACW");
                    agent_state = AgentState.agentWorkingAfterCall;
                    AgentWorkingAfterCall();
                }
                else
                {
                    MessageBox.Show(arg.AgentStateList[0].AgentInfo[0].AgentState.ToString());
                }
            }
        }

        //This event fires when Agent is logged off and ACD device.
        void myClient_CSTAAgentLoggedOff(object sender, CSTAAgentLoggedOffEventArgs arg)
        {
            rtbStatus.Text = "Agent Logged Off";
            log.Info("Agent " + arg.AgentID + " Logged Off");
            agent_state = AgentState.agentLoggedOff;
            AgentLoggedOff();

        }

        //Agent Logged Off
        private void AgentLoggedOff()
        {
            Image img = Image.FromFile(@"..\..\Resources\images\login.png");
            btnAvailable.Enabled = false;
            btnACW.Enabled = false;
            btnAux.Enabled = false;
            btnLogin.Image = img;
            myToolTip.SetToolTip(btnLogin, "Agent Login");
        }

        //Sets/Channges Agent state to Available.
        private void btnAvailable_Click(object sender, EventArgs e)
        {
            xmlClient.CSTASetAgentState(new CSTADeviceID(txtbStationID.Text.Trim(), enDeviceIDType.deviceNumber), enReqAgentState.ready, txtbAgentID.Text.Trim(), txtbAgentPassword.Text.Trim(), null, null);
        }

        //This event fires when the Agent has entered the Agent Ready state.
        void myClient_CSTAAgentReady(object sender, CSTAAgentReadyEventArgs arg)
        {
            rtbStatus.Text = "Agent is in Available State";
            log.Info("Agent State : Available");
            agent_state = AgentState.agentReady;
            AgentReady();

        }

        //Agent Ready
        private void AgentReady()
        {
            Image img = Image.FromFile(@"..\..\Resources\images\logout.png");
            btnLogin.Image = img;
            myToolTip.SetToolTip(btnLogin, "Agent Logout");
            btnAvailable.Enabled = false;
            btnAux.Enabled = true;
            btnACW.Enabled = true;
        }

        //Sets/Changes Agent state to Aux.
        private void btnAux_Click(object sender, EventArgs e)
        {
            xmlClient.CSTASetAgentState(new CSTADeviceID(txtbStationID.Text.Trim(), enDeviceIDType.deviceNumber), enReqAgentState.notReady, txtbAgentID.Text.Trim(), txtbAgentPassword.Text.Trim(), null, null);
        }

        //This event fires when the Agent has entered the Agent Not Ready state.
        void myClient_CSTAAgentNotReady(object sender, CSTAAgentNotReadyEventArgs arg)
        {
            rtbStatus.Text = "Agent in Aux Sate";
            log.Info("Agent State : Aux");
            agent_state = AgentState.agentNotReady;
            AgentNotReady();

        }

        private void AgentNotReady()
        {
            Image img = Image.FromFile(@"..\..\Resources\images\logout.png");
            btnLogin.Image = img;
            myToolTip.SetToolTip(btnLogin, "Agent Logout");
            btnAux.Enabled = false;
            btnACW.Enabled = true;
            btnAvailable.Enabled = true;
        }

        //Sets/Changes Agent state to ACW.
        private void btnACW_Click(object sender, EventArgs e)
        {
            xmlClient.CSTASetAgentState(new CSTADeviceID(txtbStationID.Text.Trim(), enDeviceIDType.deviceNumber), enReqAgentState.workingAfterCall, txtbAgentID.Text.Trim(), txtbAgentPassword.Text.Trim(), null, null);
        }

        //This event fires when the Agent has entered the Working after call state.
        void myClient_CSTAAgentWorkingAfterCall(object sender, CSTAAgentWorkingAfterCallEventArgs arg)
        {
            rtbStatus.Text = "Agent in ACW state";
            log.Info("Agent State : ACW");
            agent_state = AgentState.agentWorkingAfterCall;
            AgentWorkingAfterCall();
        }

        private void AgentWorkingAfterCall()
        {
            Image img = Image.FromFile(@"..\..\Resources\images\logout.png");
            btnLogin.Image = img;
            myToolTip.SetToolTip(btnLogin, "Agent Logout");
            btnACW.Enabled = false;
            btnAux.Enabled = true;
            btnAvailable.Enabled = true;
        }
        #endregion
    }
}
