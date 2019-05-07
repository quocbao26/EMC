//This class is used to handle Agent Login and Agent state change on the station that is being monitored.
//Agent ID and Agent Password are used to Login the Agent.


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
    public partial class EmailHandling
    {
        #region Monitor
        
        //Enumeration to maintain Monitor State
        enum MonitorState
        {
            MonitorStart,
            MonitorStop
        };
        MonitorState monitor_state = MonitorState.MonitorStop;

        //Starts/Stops monitor a device object. 
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
                    xmlClient.CSTASetAgentState(new CSTADeviceID(txtStationID.Text.Trim(), enDeviceIDType.deviceNumber), enReqAgentState.loggedOff, txtAgentID.Text.Trim(), txtAgentPwd.Text.Trim(), null, null);
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

            string _StationID = txtStationID.Text.Trim();
            CSTADeviceID _thisStation = new CSTADeviceID(_StationID, enDeviceIDType.deviceNumber);
            xmlClient.CSTAGetAgentState(_thisStation);
            
        }

        //Monitor Start
        private void MonitorStarted()
        {
            btnLogInOut.Enabled = true;
            btnMonitor.Text = "Monitor Stop";
            gbMediaDirDetails.Enabled = true;
        }

        //Positive acknowledgement event for CSTAMonitorStop(CSTAMonitor)
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
            btnAuxillary.Enabled = false;
            btnLogInOut.Enabled = false;
            btnMonitor.Text = "Monitor Start";
            gbMediaDirDetails.Enabled = false;
            txtMediaDirectorIP.Text = "";
            txtbMediaDirectorPort.Text = "";
            txtMediaProxyIP.Text = "";
            txtMediaProxyPort.Text = "";
        }


        

        #endregion

        #region AgentStates
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

        //Agent is Logged on/Logged off to a particalar ACD device.
        private void btnLogInOut_Click(object sender, EventArgs e)
        {
            //Agent Login
            if (agent_state == AgentState.agentLoggedOff)
            {
                // xmlClient.CSTAAgentLoggedOn += new CSTAAgentLoggedOnEventHandler(xmlClient_CSTAAgentLoggedOn);
                if (txtAgentID.Text.Length > 0)
                {
                    string ag_id = txtAgentID.Text;
                    bool isagentID = checkNum(ag_id);
                    if (isagentID)
                    {
                        if (txtAgentPwd.Text.Length > 0)
                        {
                            string ag_pwd = txtAgentPwd.Text;
                            bool isagentpwd = checkNum(ag_pwd);
                            if (isagentpwd)
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
                                //CSTAAgentLoggedOn will be fired
                                xmlClient.CSTASetAgentState(new CSTADeviceID(txtStationID.Text.Trim(), enDeviceIDType.deviceNumber), enReqAgentState.loggedOn, txtAgentID.Text.Trim(), txtAgentPwd.Text.Trim(), null, null);
                            }
                            else
                            {
                                MessageBox.Show("Invalid Agent Password", "Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                log.Error("Invalid agent Password entered");
                                txtAgentPwd.Focus();
                            }
                        }
                        else
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
                            //CSTAAgentLoggedOn will be fired
                            xmlClient.CSTASetAgentState(new CSTADeviceID(txtStationID.Text.Trim(), enDeviceIDType.deviceNumber), enReqAgentState.loggedOn, txtAgentID.Text.Trim(), txtAgentPwd.Text.Trim(), null, null);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Agent ID not entered", "Agent ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Agent ID not entered");
                    txtAgentID.Focus();
                }
            }

            //Agent Logout
            if (agent_state == AgentState.agentLoggedOn || agent_state == AgentState.agentReady || agent_state == AgentState.agentNotReady || agent_state == AgentState.agentWorkingAfterCall)
            {
                //xmlClient.CSTAAgentLoggedOff += new CSTAAgentLoggedOffEventHandler(xmlClient_CSTAAgentLoggedOff);
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
        }

        //This event fires when agent is logged on to a particular ACD device and is ready to contribute to the activities of an ACD device.
        void xmlClient_CSTAAgentLoggedOn(object sender, CSTAAgentLoggedOnEventArgs arg)
        {
            rtbStatus.Text = "Agent Logged On";
            log.Info("Agent  " + arg.AgentID + " Logged On");
            agent_state = AgentState.agentLoggedOn;
            AgentLoggenOn();
            //Method used: CSTAGetAgentState(CSTADeviceID)
            //Provides the agent state at a specified device. 
            //Parameters:
            //device (CSTADeviceID) - Specifies the DeviceID of the device on which the agent state is being queried.
            //CSTAGetAgentStateResponse will be fired to provide Agent information.
            xmlClient.CSTAGetAgentState(new CSTADeviceID(txtStationID.Text.Trim(), enDeviceIDType.deviceNumber));
        }

        //Agent Login
        private void AgentLoggenOn()
        {
            Image img = Image.FromFile(@"..\..\Resources\images\logout.png");
            btnAvailable.Enabled = true;
            btnAuxillary.Enabled = true;
            btnACW.Enabled = true;
            btnLogInOut.Image = img;
            myToolTip.SetToolTip(btnLogInOut, "Agent Logout");
        }

        //This event fires when Agent is logged off and ACD device.
        void xmlClient_CSTAAgentLoggedOff(object sender, CSTAAgentLoggedOffEventArgs arg)
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
            btnLogInOut.Image = img;
            myToolTip.SetToolTip(btnLogInOut, "Agent Login");
            btnAvailable.Enabled = false;
            btnACW.Enabled = false;
            btnAuxillary.Enabled = false;
        }

        //Sets/Channges Agent state to Available.
        private void btnAvailable_Click(object sender, EventArgs e)
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
            //CSTAAgentReady will be fired
            xmlClient.CSTASetAgentState(new CSTADeviceID(txtStationID.Text.Trim(), enDeviceIDType.deviceNumber), enReqAgentState.ready, txtAgentID.Text.Trim(), txtAgentPwd.Text.Trim(), null, null);
        }

        //This event fires when the Agent has entered the Agent Ready state.
        void xmlClient_CSTAAgentReady(object sender, CSTAAgentReadyEventArgs arg)
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
            btnLogInOut.Image = img;
            myToolTip.SetToolTip(btnLogInOut, "Agent Logout");
            btnAvailable.Enabled = false;
            btnAuxillary.Enabled = true;
            btnACW.Enabled = true;
        }

        //Sets/Changes Agent state to Auxillary.
        private void btnAuxillary_Click(object sender, EventArgs e)
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
            //CSTAAgentNotReady will be fired
            xmlClient.CSTASetAgentState(new CSTADeviceID(txtStationID.Text.Trim(), enDeviceIDType.deviceNumber), enReqAgentState.notReady, txtAgentID.Text.Trim(), txtAgentPwd.Text.Trim(), null, null);
        }

        //This event fires when the Agent has entered the Agent Not Ready state.
        void xmlClient_CSTAAgentNotReady(object sender, CSTAAgentNotReadyEventArgs arg)
        {
            rtbStatus.Text = "Agent in Aux Sate";
            log.Info("Agent State : Aux");
            agent_state = AgentState.agentNotReady;
            AgentNotReady();
        }

        //Agent Not Ready
        private void AgentNotReady()
        {
            Image img = Image.FromFile(@"..\..\Resources\images\logout.png");
            btnLogInOut.Image = img;
            myToolTip.SetToolTip(btnLogInOut, "Agent Logout");
            btnAuxillary.Enabled = false;
            btnACW.Enabled = true;
            btnAvailable.Enabled = true;
        }

        //Sets/Changes Agent state to ACW.
        private void btnACW_Click(object sender, EventArgs e)
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
            //CSTAAgentWorkingAfterCall will be fired
            xmlClient.CSTASetAgentState(new CSTADeviceID(txtStationID.Text.Trim(), enDeviceIDType.deviceNumber), enReqAgentState.workingAfterCall, txtAgentID.Text.Trim(), txtAgentPwd.Text.Trim(), null, null);
        }

        //This event fires when the Agent has entered the Working after call state.
        void xmlClient_CSTAAgentWorkingAfterCall(object sender, CSTAAgentWorkingAfterCallEventArgs arg)
        {
            rtbStatus.Text = "Agent in ACW state";
            log.Info("Agent State : ACW");
            agent_state = AgentState.agentWorkingAfterCall;
            AgentWorkingAfterCall();
        }

        //Agent Working After Call
        private void AgentWorkingAfterCall()
        {
            Image img = Image.FromFile(@"..\..\Resources\images\logout.png");
            btnLogInOut.Image = img;
            myToolTip.SetToolTip(btnLogInOut, "Agent Logout");
            btnACW.Enabled = false;
            btnAuxillary.Enabled = true;
            btnAvailable.Enabled = true;
        }




        //Positive acknowledgement event for CSTAGetAgentState(CSTADeviceID)
        void xmlClient_CSTAGetAgentStateResponse(object sender, CSTAGetAgentStateResponseEventArgs arg)
        {
            //logged_state - Stores Agent State
            bool logged_state = arg.AgentStateList[0].LoggedOnState;
            string _myAgentID = arg.AgentStateList[0].AgentID;
            if (logged_state)
            {
                //state - gets and stores Agent State
                string state = arg.AgentStateList[0].AgentInfo[0].AgentState.ToString();
                if (state.Equals("agentNotReady"))
                {
                    txtAgentID.Text = _myAgentID;
                    rtbStatus.Text = "Agent in AUX state";
                    log.Info("Agent State : Aux");
                    agent_state = AgentState.agentNotReady;
                    AgentNotReady();
                }
                else if (state.Equals("agentReady"))
                {
                    txtAgentID.Text = _myAgentID;
                    rtbStatus.Text = "Agent in Available state";
                    log.Info("Agent State : Available");
                    agent_state = AgentState.agentReady;
                    AgentReady();
                }
                else if (state.Equals("agentWorkingAfterCall"))
                {
                    txtAgentID.Text = _myAgentID;
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

        #endregion

    }
}
