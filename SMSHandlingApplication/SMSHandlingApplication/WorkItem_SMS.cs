//This class handles the SMS WI. 
//It accepts the work item and displays it.
//It handles the phantom call.

#region directives
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
    public partial class SMSHandlingForm
    {
        //Accpets and Displays an SMS WI
        private void btnAcceptSMS_Click(object sender, EventArgs e)
        {
            log.Info("Calling CSTAAnswerCall on connection CallID : " + conn_CallID + " device ID : " + conn_DeviceID);
            int resp = xmlClient.CSTAAnswerCall(connID);

            log.Info("Calling CSTAAnswerCall returned response :" + resp.ToString());

            btnAcceptSMS.Enabled = false;

        }

        #region SMS_WI
        //SMS WI delivered
        //Fired by the Media Director to notify the client that a work item is delivered to it. 
        void mediaClient_WorkItemRefDelivered(object sender, AgileSoftware.Multimedia.Client.WorkItemRefDeliveredArgs arg)
        {
            lock (this)
            {
                if (arg.WorkItemType != ASGQEWorkItemBase2.WORK_ITEM_TYPE_SIMPLE_MESSAGE)
                {
                    log.Info("Not an SMS WI" + arg.WorkItemID);
                    return;
                }
                log.Info("Recieved WorkItemRefDelivered for SMS WI for agent" + txtAgentID.Text.Trim());
                log.Info("WI ID : " + arg.WorkItemID);
            }
        }

        //SMS WI established 
        //Fired by the Media Director to notify the client that the work item has been accepted by the client side agent. 
        void mediaClient_WorkItemRefEstablished(object sender, AgileSoftware.Multimedia.Client.WorkItemRefEstablishedArgs arg)
        {
            lock (this)
            {
                if (arg.WorkItemType != ASGQEWorkItemBase2.WORK_ITEM_TYPE_SIMPLE_MESSAGE)
                {
                    log.Info("Not an SMMS WI " + arg.WorkItemID);
                    return;
                }
                log.Info("Recieved WorkItemRefEstablished SMMS WI for agent" + txtAgentID.Text.Trim());

                if (smms != null)
                {
                    workItem = arg.WorkItemRef as ASGQEWorkItemBase2;
                    workItem.KeepAlive();

                    if (workItem != null)
                    {
                        log.Info("Agent " + txtAgentID.Text.Trim() + "Working on WI " + workItem.Identifier + "Interaction ID :" + workItem.InteractionID);

                        //Create simple messaging client
                        smmsclient = (ISimpleMessagingClient)workItem;

                        //Recieve simple message sent by the client
                        smmsclient.SMClientWorkItemLoaded(out messages, out mediaTypeName, out available2send, out mediaconnected);


                        SMXmlParser.deserializeSimpleMessages(messages, out messageList);

                        customername = ((SMSimpleUserMessage)messageList[0]).Author;
                        initialMessage = messageList[0].Message;

                        //MessageBox.Show(customername+"\t"+initialMessage);

                        log.Info("Initial chat message recieved from customer " + customername + " is " + initialMessage);

                        sms_window.displaySMS(customername, initialMessage);


                        sms_window.ShowDialog();

                        //Reply to the customer 
                        string reply_message = "Welcome to EMC support";
                        SMSimpleUserMessage replyMessage = new SMSimpleUserMessage(reply_message, "text/plain", txtAgentID.Text.Trim());
                        replyMessage.Direction = SMSimpleMessageDirection.OutboundFromAgent;

                        string xmlText = String.Empty;
                        SMXmlWriter.serializeSimpleMessage(replyMessage, out xmlText);
                        smmsclient.SMClientSendMessage(xmlText);

                        log.Info("Reply message from the agent " + txtAgentID.Text.Trim() + " is " + reply_message);

                        //Close SMMS WorkItem
                        workItem.Close(String.Empty, 1);

                    }
                }
            }
        }

        //SMS WI not accepted by agent
        //Fired by the Media Director to notify the client that the agent did not accept the work item (by answering the phantom call) in the expected time. The work item will be queued back to the server and try to deliver again. 
        void mediaClient_WorkItemRefRemoved(object sender, AgileSoftware.Multimedia.Client.WorkItemRefRemovedArgs arg)
        {
            log.Info("Recieved WorkItemRefRemoved WI for agent" + txtAgentID.Text.Trim());
        }

        #endregion

        #region phantomCall
        //Phantom call delivered
        //Fires when a call is being presented to a device in either the Ringing or Entering Distribution modes of the alerting state. 
        void xmlClient_CSTADelivered(object sender, CSTADeliveredEventArgs arg)
        {
            log.Info("Phantom call recieved on station : " + txtStationID.Text.Trim() + "\t" + arg.AlertingDevice);
            connID = arg.Connection;
            conn_CallID = arg.Connection.CallID;
            conn_DeviceID = arg.Connection.DeviceID.ID;

            Thread.Sleep(1000);
            btnAcceptSMS.Enabled = true;
        }


        //Phantom call answered
        //Fires when a call has been answered at a device or when a call has been connected to a device. 
        void xmlClient_CSTAEstablished(object sender, CSTAEstablishedEventArgs arg)
        {
            log.Info("CSTAEstablished Event on " + arg.AnsweringDevice.ID);

            //Clear Phantom Call
            if (connID != null)
            {
                int resp = xmlClient.CSTAClearCall(connID, "");
                log.Info("Calling CSTAClearCall on " + txtStationID.Text.Trim() + " returned " + resp.ToString());
            }

            //Set agent state to  Auxillary
            CSTADeviceID dev = new CSTADeviceID(txtStationID.Text.Trim(), enDeviceIDType.deviceNumber);
            int response = xmlClient.CSTASetAgentState(dev, enReqAgentState.notReady, txtAgentID.Text.Trim(), txtAgentPwd.Text.Trim(), null, null);
            log.Info("Set CSTAAgentState " + txtAgentID.Text.Trim() + " to Aux. Returned : " + response.ToString());
        }

        //Phantom call cleared
        //Fires when a call has been cleared and no longer exists within the switching sub-domain. It is only provided for calls that are being call-type monitored. 
        void xmlClient_CSTACallCleared(object sender, CSTACallClearedEventArgs arg)
        {
            connID = null;
            log.Info("CSTACallCleared event on : " + arg.ClearedCall.DeviceID.ID);
        }

        //Fires when a single device has disconnected or dropped out of a call.
        void xmlClient_CSTAConnectionCleared(object sender, CSTAConnectionClearedEventArgs arg)
        {
            log.Info("CSTAConnectionCleared vent on :" + arg.DroppedConnection.DeviceID.ID);

            //set Agent to AUX state
            CSTADeviceID dev = new CSTADeviceID(txtStationID.Text.Trim(), enDeviceIDType.deviceNumber);
            int response = xmlClient.CSTASetAgentState(dev, enReqAgentState.notReady, txtAgentID.Text.Trim(), txtAgentPwd.Text.Trim(), null, null);
            log.Info("Set CSTASetAgentState " + txtAgentID.Text.Trim() + " to Aux returned : " + response.ToString());
        }
        #endregion
        
    }
}
