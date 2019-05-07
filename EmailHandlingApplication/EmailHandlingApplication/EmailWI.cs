//This class handles Email Work Item.
//The related Phantom call is also handled.

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
        #region Email_WorkItem

        //Fired by the Media Director to notify the client that a work item is delivered to it. 
        void mediaClient_WorkItemRefDelivered(object sender, AgileSoftware.Multimedia.Client.WorkItemRefDeliveredArgs arg)
        {
            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Recieved WorkItemRefDelivered for Email WI for agent";
            });

            lock (this)
            {
                if (arg.WorkItemType != ASGQEWorkItemBase2.WORK_ITEM_TYPE_EMAIL)
                {
                    log.Info("Not an Email WI" + arg.WorkItemID);
                    return;
                }
                log.Info("Recieved WorkItemRefDelivered Email WI for agent" + txtAgentID.Text.Trim());
                log.Info("Work Item ID :" + arg.WorkItemID);

                if (ems != null)
                {
                    workItem = arg.WorkItemRef as ASGQEWorkItemBase2;
                    workItem.KeepAlive();

                    if (workItem != null)
                    {
                        emailWID = workItem.GetWorkItemData() as EmailWorkItemData;
                        mimeMessage = ((emailWID == null) || (emailWID.EmailMessage == null)) ? null : new MimeMessage(emailWID.EmailMessage);
                        mimeattachments = mimeMessage.Attachments;
                        messageProcessor = workItem as IMessageProcessor;
                    }
                }
            }
        }

        //Displays the Inbound Mail
        private void btnAcceptMail_Click(object sender, EventArgs e)
        {
            log.Info("Calling CSTAAnswerCall on connection call ID : " + conn_CallID + " device ID : " + conn_DeviceID);
            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Calling CSTAAnswerCall";
            });

            int resp = xmlClient.CSTAAnswerCall(connID);

            log.Info("Calling CSTAAnswerCall returned response :" + resp.ToString());
            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Calling CSTAAnswerCall returned response :" + resp.ToString();
            });


            btnAcceptMail.Enabled = false;

            //Stores email fields
            frmInbound.storeEmailFields(mimeMessage);
            log.Info("Inbound Mail displayed");

            //If agent decides to Reply 
            Agentreply = frmInbound.Agent_reply;
            
            if (Agentreply)
            {
                frmInbound.storeReplyFeilds(mimeMessage);
                getReplyDetails();
            }

            //Close workItem
            closeWorkItem();
        }

        //Get reply message from agent.
        public void getReplyDetails()
        {
            replyFromAgent = frmInbound.reply_message;
            SendReply(replyFromAgent);
        }

        //Sends a reply to the agent.
        public void SendReply(string replyFromAgent)
        {
            MimeMessage reply_mimeMessage = new MimeMessage();
            reply_mimeMessage.From = mimeMessage.To;
            reply_mimeMessage.ReplyTo = mimeMessage.To;
            reply_mimeMessage.To = mimeMessage.From;
            reply_mimeMessage.Subject = "RE : " + mimeMessage.Subject;

            reply_mimeMessage.TextBody = replyFromAgent;
            byte[] reply_Message = reply_mimeMessage.ToArray();
            Guid reply_Guid = Guid.NewGuid();
            messageProcessor.StartAction(reply_Guid);
            messageProcessor.Send(reply_Guid, reply_Message);
            messageProcessor.StopAction(reply_Guid);
            log.Info("Reply sent to Customer");
            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Reply sent to Customer";
            });
        }

        //Close WorkItem
        public void closeWorkItem()
        {
            workItem.Close(string.Empty, 1);
            log.Info("Work Item Closed");
            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Work Item Closed";
            });
            
        }

        //Fired by the Media Director to notify the client that the work item has been accepted by the client side agent. 
        void mediaClient_WorkItemRefEstablished(object sender, AgileSoftware.Multimedia.Client.WorkItemRefEstablishedArgs arg)
        {
            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Recieved WorkItemRefEstablished Email WI for agent.";
            });
            lock (this)
            {
                if (arg.WorkItemType != ASGQEWorkItemBase2.WORK_ITEM_TYPE_EMAIL)
                {
                    log.Info("Not an email WI" + arg.WorkItemID);
                    return;
                }


                if (ems != null)
                {
                    workItem = arg.WorkItemRef as ASGQEWorkItemBase2;
                    workItem.KeepAlive();

                    if (workItem != null)
                    {
                        log.Info("Recieved WorkItemRefEstablished Email WI for agent :" + txtAgentID.Text.Trim());
                        log.Info("Agent " + txtAgentID.Text.Trim() + "working on WorkItem " + workItem.Identifier + "and Interaction ID " + workItem.InteractionID);
                    }
                }

            }
        }

        //Fired by the Media Director to notify the client that the agent did not accept the work item in the expected time. 
        //The work item will be queued back to the server and try to deliver again. 
        void mediaClient_WorkItemRefRemoved(object sender, AgileSoftware.Multimedia.Client.WorkItemRefRemovedArgs arg)
        {
            log.Info("Work Item Removed");
            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Work Item Removed.";
            });
        }

        #endregion

        #region Email_PhantomCall

        //Fires when a phantom call is being presented to a device .
        void xmlClient_CSTADelivered(object sender, CSTADeliveredEventArgs arg)
        {
            log.Info("Phantom call delivered on station" + txtStationID + "\t" + arg.AlertingDevice);
            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Phantom call Delivered.";
            });
            connID = arg.Connection;
            conn_CallID = arg.Connection.CallID;
            conn_DeviceID = arg.Connection.DeviceID.ID;

            Thread.Sleep(1000);
            btnAcceptMail.Enabled = true;
        }

        //Fires when a phantom call has been answered at a device
        void xmlClient_CSTAEstablished(object sender, CSTAEstablishedEventArgs arg)
        {
            log.Info("CSTAEstablished Event on " + arg.AnsweringDevice.ID);
            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Phantom call Established.";
            });
            //Clear phantom Call

            if (connID != null)
            {
                int resp = xmlClient.CSTAClearCall(connID, "");
                log.Info("Calling CSTAClearCall on " + txtStationID.Text.Trim() + "returned " + resp.ToString());
            }

            //Set Agent state to Auxillary
            CSTADeviceID dev = new CSTADeviceID(txtStationID.Text.Trim(), enDeviceIDType.deviceNumber);

            int response = xmlClient.CSTASetAgentState(dev, enReqAgentState.notReady, txtAgentID.Text.Trim(), txtAgentPwd.Text.Trim(), null, null);
            log.Info("Set CSTASetAgentState " + txtAgentID.Text.Trim() + " to Aux returned : " + response.ToString());
        }

        //Fires when the phantom call has been cleared.
        void xmlClient_CSTACallCleared(object sender, CSTACallClearedEventArgs arg)
        {
            connID = null;
            log.Info("CSTACallCleared event on : " + arg.ClearedCall.DeviceID.ID);
            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Phantom call Cleared.";
            });
        }

        //Fires when the connection is cleared.
        void xmlClient_CSTAConnectionCleared(object sender, CSTAConnectionClearedEventArgs arg)
        {
            log.Info("CSTAConnectionCleared event on :" + arg.DroppedConnection.DeviceID.ID);
            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Connection Cleared.";
            });

            //set Agent to AUX state
            CSTADeviceID dev = new CSTADeviceID(txtStationID.Text.Trim(), enDeviceIDType.deviceNumber);
            int response = xmlClient.CSTASetAgentState(dev, enReqAgentState.notReady, txtAgentID.Text.Trim(), txtAgentPwd.Text.Trim(), null, null);
            log.Info("Set CSTASetAgentState " + txtAgentID.Text.Trim() + " to Aux returned : " + response.ToString());
           
        }

        #endregion

    }
}
