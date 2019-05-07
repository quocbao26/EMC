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
        //Agent Not Ready state
        private void AgentNotReady()
        {
            Image img = Image.FromFile(@"..\..\Resources\images\logout.png");
            btnLogin.Image = img;
            myToolTip.SetToolTip(btnLogin, "Agent Logout");
            btnAux.Enabled = false;
            btnACW.Enabled = true;
            btnAvailable.Enabled = true;
        }

        //Agent Working after Call state
        private void AgentWorkingAfterCall()
        {
            Image img = Image.FromFile(@"..\..\Resources\images\logout.png");
            btnLogin.Image = img;
            myToolTip.SetToolTip(btnLogin, "Agent Logout");
            btnACW.Enabled = false;
            btnAux.Enabled = true;
            btnAvailable.Enabled = true;
        }

        //Agent Ready state
        private void AgentReady()
        {
            Image img = Image.FromFile(@"..\..\Resources\images\logout.png");
            btnLogin.Image = img;
            myToolTip.SetToolTip(btnLogin, "Agent Logout");
            btnAvailable.Enabled = false;
            btnAux.Enabled = true;
            btnACW.Enabled = true;
        }

        //Agent Logged Off state
        private void AgentLoggedOff()
        {
            Image img = Image.FromFile(@"..\..\Resources\images\login.png");
            btnAvailable.Enabled = false;
            btnACW.Enabled = false;
            btnAux.Enabled = false;
            btnLogin.Image = img;
            myToolTip.SetToolTip(btnLogin, "Agent Login");
        }

        //Agent LoggedOn state
        private void AgentLoggedOn()
        {
            Image img = Image.FromFile(@"..\..\Resources\images\logout.png");
            btnAvailable.Enabled = true;
            btnAux.Enabled = true;
            btnACW.Enabled = true;
            btnLogin.Image = img;
            myToolTip.SetToolTip(btnLogin, "Agent Logout");
        }

        //Agent is Logged on/Logged Off to a particalar ACD device.
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Agent Login
            if (agent_state == AgentState.agentLoggedOff)
            {
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
                                string stationID = txtStationID.Text.Trim();
                                string agentID = txtAgentID.Text.Trim();
                                string agentPwd = txtAgentPwd.Text.Trim();
                                xmlClient.CSTASetAgentState(new CSTADeviceID(stationID, enDeviceIDType.deviceNumber), enReqAgentState.loggedOn,agentID ,agentPwd , null, null);
                            }
                            else
                            {
                                MessageBox.Show("Enter Valid Agent Password", "Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                log.Error("Invalid agent Password entered");
                                txtAgentPwd.Focus();
                            }
                        }
                        else
                        {
                            string stationID = txtStationID.Text.Trim();
                            string agentID = txtAgentID.Text.Trim();
                            string agentPwd = txtAgentPwd.Text.Trim();
                            xmlClient.CSTASetAgentState(new CSTADeviceID(stationID, enDeviceIDType.deviceNumber), enReqAgentState.loggedOn, agentID, agentPwd, null, null);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Enter valid Agent ID", "Agent ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Agent ID not entered");
                    txtAgentID.Focus();
                }
            }

            //Agent Logout
            if (agent_state == AgentState.agentLoggedOn || agent_state == AgentState.agentReady || agent_state == AgentState.agentNotReady || agent_state == AgentState.agentWorkingAfterCall)
            {
                string stationID = txtStationID.Text.Trim();
                string agentID = txtAgentID.Text.Trim();
                string agentPwd = txtAgentPwd.Text.Trim();
                xmlClient.CSTASetAgentState(new CSTADeviceID(stationID, enDeviceIDType.deviceNumber), enReqAgentState.loggedOff, agentID, agentPwd, null, null);
            }
        }

        //This event fires when agent is logged on to a particular ACD device and is ready to contribute to the activities of an ACD device.
        void xmlClient_CSTAAgentLoggedOn(object sender, CSTAAgentLoggedOnEventArgs arg)
        {
            rtbStatus.Text = "Agent Logged On";
            log.Info("Agent  " + arg.AgentID + " Logged On");
            agent_state = AgentState.agentLoggedOn;
            AgentLoggedOn();
            string stationID = txtStationID.Text.Trim();
            xmlClient.CSTAGetAgentState(new CSTADeviceID(stationID, enDeviceIDType.deviceNumber));
        }

        //Positive acknowledgement event for CSTAGetAgentState(CSTADeviceID)
        void xmlClient_CSTAGetAgentStateResponse(object sender, CSTAGetAgentStateResponseEventArgs arg)
        {
            //logged_state - Stores Agent State
            bool logged_state = arg.AgentStateList[0].LoggedOnState;
            if (logged_state)
            {
                //state - gets and stores Agent State
                string state = arg.AgentStateList[0].AgentInfo[0].AgentState.ToString();
                string myagentID = arg.AgentStateList[0].AgentID;
                if (state.Equals("agentNotReady"))
                {
                    rtbStatus.Text = "Agent in AUX state";
                    log.Info("Agent State : Aux");
                    txtAgentID.Text = myagentID;
                    agent_state = AgentState.agentNotReady;
                    AgentNotReady();
                }
                else if (state.Equals("agentReady"))
                {
                    rtbStatus.Text = "Agent in Available state";
                    log.Info("Agent State : Available");
                    txtAgentID.Text = myagentID;
                    agent_state = AgentState.agentReady;
                    AgentReady();
                }
                else if (state.Equals("agentWorkingAfterCall"))
                {
                    rtbStatus.Text = "Agent in ACW state";
                    log.Info("Agent State : ACW");
                    txtAgentID.Text = myagentID;
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
        void xmlClient_CSTAAgentLoggedOff(object sender, CSTAAgentLoggedOffEventArgs arg)
        {
            rtbStatus.Text = "Agent Logged Off";
            log.Info("Agent " + arg.AgentID + " Logged Off");
            agent_state = AgentState.agentLoggedOff;
            AgentLoggedOff();
        }

        //Sets/Channges Agent state to Available.
        private void btnAvailable_Click(object sender, EventArgs e)
        {
            string stationID = txtStationID.Text.Trim();
            string agentID = txtAgentID.Text.Trim();
            string agentPwd = txtAgentPwd.Text.Trim();
            xmlClient.CSTASetAgentState(new CSTADeviceID(stationID, enDeviceIDType.deviceNumber), enReqAgentState.ready, agentID, agentPwd, null, null);
        }

        //This event fires when the Agent has entered the Agent Ready state.
        void xmlClient_CSTAAgentReady(object sender, CSTAAgentReadyEventArgs arg)
        {
            rtbStatus.Text = "Agent is in Available State";
            log.Info("Agent State : Available");
            agent_state = AgentState.agentReady;
            AgentReady();
        }

        //Sets/Changes Agent state to Aux.
        private void btnAux_Click(object sender, EventArgs e)
        {
            string stationID = txtStationID.Text.Trim();
            string agentID = txtAgentID.Text.Trim();
            string agentPwd = txtAgentPwd.Text.Trim();
            xmlClient.CSTASetAgentState(new CSTADeviceID(stationID, enDeviceIDType.deviceNumber), enReqAgentState.notReady, agentID, agentPwd, null, null);
        }

        //This event fires when the Agent has entered the Agent Not Ready state.
        void xmlClient_CSTAAgentNotReady(object sender, CSTAAgentNotReadyEventArgs arg)
        {
            rtbStatus.Text = "Agent in Aux Sate";
            log.Info("Agent State : Aux");
            agent_state = AgentState.agentNotReady;
            AgentNotReady();
        }

        //Sets/Changes Agent state to ACW.
        private void btnACW_Click(object sender, EventArgs e)
        {
            string stationID = txtStationID.Text.Trim();
            string agentID = txtAgentID.Text.Trim();
            string agentPwd = txtAgentPwd.Text.Trim();
            xmlClient.CSTASetAgentState(new CSTADeviceID(stationID, enDeviceIDType.deviceNumber), enReqAgentState.workingAfterCall, agentID, agentPwd, null, null);
        }

        //This event fires when the Agent has entered the Working after call state.
        void xmlClient_CSTAAgentWorkingAfterCall(object sender, CSTAAgentWorkingAfterCallEventArgs arg)
        {
            rtbStatus.Text = "Agent in ACW state";
            log.Info("Agent State : ACW");
            agent_state = AgentState.agentWorkingAfterCall;
            AgentWorkingAfterCall();
        }

    }
}
