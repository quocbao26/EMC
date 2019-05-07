//This class is used to handle the Phantom call related to the media work item recieved.

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
    public partial class WebChatApplication
    {
        //Phantom call delivered
        //Fires when a call is being presented to a device in either the Ringing or Entering Distribution modes of the alerting state.
        void xmlClient_CSTADelivered(object sender, CSTADeliveredEventArgs arg)
        {
            string stationID = txtStationID.Text.Trim();
            log.Info("Phantom call recieved on station : " + stationID + "\t" + arg.AlertingDevice);
            connID = arg.Connection;
            conn_CallID = arg.Connection.CallID;
            conn_DeviceID = arg.Connection.DeviceID.ID;

            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Phantom Call delivered";
            });

            Thread.Sleep(1000);
            btnChat.Enabled = true;
        }

        //Phantom call answered
        //Fires when a call has been answered at a device or when a call has been connected to a device. 
        void xmlClient_CSTAEstablished(object sender, CSTAEstablishedEventArgs arg)
        {
            log.Info("CSTAEstablished Event on " + arg.AnsweringDevice.ID);
            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Phantom Call Established";
            });
            //Clear Phantom Call
            if (connID != null)
            {
                int resp = xmlClient.CSTAClearCall(connID, "");
                log.Info("Calling CSTAClearCall on " + txtStationID.Text.Trim() + " returned " + resp.ToString());
            }

            //Set agent state to  Auxillary
            string stationID = txtStationID.Text.Trim();
            string agentID = txtAgentID.Text.Trim();
            string agentPwd = txtAgentPwd.Text.Trim();
            CSTADeviceID dev = new CSTADeviceID(stationID, enDeviceIDType.deviceNumber);
            int response = xmlClient.CSTASetAgentState(dev, enReqAgentState.notReady, agentID, agentPwd, null, null);
            log.Info("Set CSTAAgentState " + agentID + " to Aux. Returned : " + response.ToString());
            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Agent set to Aux state";
            });
        }

        //Phantom call cleared
        //Fires when a call has been cleared and no longer exists within the switching sub-domain. It is only provided for calls that are being call-type monitored. 
        void xmlClient_CSTACallCleared(object sender, CSTACallClearedEventArgs arg)
        {
            connID = null;
            log.Info("CSTACallCleared event on : " + arg.ClearedCall.DeviceID.ID);
            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Phantom Call cleared";
            });
        }

        //Fires when a single device has disconnected or dropped out of a call.
        void xmlClient_CSTAConnectionCleared(object sender, CSTAConnectionClearedEventArgs arg)
        {
            log.Info("CSTAConnectionCleared event on :" + arg.DroppedConnection.DeviceID.ID);

            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Phantom Call cleared";
            });

            //set Agent to AUX state
            string stationID = txtStationID.Text.Trim();
            string agentID = txtAgentID.Text.Trim();
            string agentPwd = txtAgentPwd.Text.Trim();
            CSTADeviceID dev = new CSTADeviceID(stationID, enDeviceIDType.deviceNumber);
            int response = xmlClient.CSTASetAgentState(dev, enReqAgentState.notReady, agentID, agentPwd, null, null);
            log.Info("Set CSTASetAgentState " + agentID + " to Aux returned : " + response.ToString());
            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Agent set to Aux state";
            });
        }
    }
}
