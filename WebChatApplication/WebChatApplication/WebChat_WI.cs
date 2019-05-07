//This class handles the Web Chat WI

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
        //Variable for Web Chat WI
        protected SimpleMessagingClientEventHandler smClientEventHandler = null;
        string chat_msgs = "";
        string _msgs = "";
        public static string string_value;

        //Launches a converstation
        private void btnChat_Click(object sender, EventArgs e)
        {
            //Answer Phantom Call
            log.Info("Calling CSTAAnswerCall on connection CallID : " + conn_CallID + " device ID : " + conn_DeviceID);
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

            btnChat.Enabled = false;
            rtbChat.Enabled = true;
            rtbReplyFromAgent.Enabled = true;
            btnSend.Enabled = true;
        }

        //Get string from Dictionary for System Message
        public static string getMessageString(int msgID)
        {
            if (dictionary.ContainsKey(msgID))
            {
                string_value = dictionary[msgID];
                log.Info(string_value);
            }
            else
            {
                log.Info("Session closed: Reason not known");
                string_value = "Web Chat closed: Reason not known";
            }
            return string_value;
          
        }

        //Web Chat WI delivered
        //Fired by the Media Director to notify the client that a work item is delivered to it. 
        void mediaClient_WorkItemRefDelivered(object sender, AgileSoftware.Multimedia.Client.WorkItemRefDeliveredArgs arg)
        {
            lock (this)
            {
                if (arg.WorkItemType != ASGQEWorkItemBase2.WORK_ITEM_TYPE_SIMPLE_MESSAGE)
                {
                    log.Info("Not an WebChat WI" + arg.WorkItemID);
                    return;
                }
                string agentID = txtAgentID.Text.Trim();
                log.Info("Recieved WorkItemRefDelivered for WebChat WI for agent" + agentID);
                rtbStatus.Invoke((Action)delegate
                {
                    rtbStatus.Text = "Recieved WorkItemRefDelivered for WebChat WI for agent";
                });
                log.Info("WI ID : " + arg.WorkItemID);
            }
        }

        //Gets Client Version
        private int getClientInterfaceVersion(ISimpleMessagingClient simpleMessagingClient)
        {
            int ver = 0;
            ver = (simpleMessagingClient as ISimpleMessagingClient).Version;
            return ver;
        }

        //Appends User Message recieved
        public void AppendUserMessage(SMSimpleUserMessage msg)
        {
            _msgs = msg.Message;

            rtbChat.Invoke((Action)delegate
            {
                rtbChat.Text += customername + " says :\n" + _msgs + "\n";
            });

            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Last Message received from Customer.";
            });

           
        }

        //Identifies as User Message or System Message
        public void AppendMessage(SMSimpleMessage msg)
        {
            try
            {
                if (null != msg)
                {
                    log.Info("Appending Message.");
                   
                    //User Message
                    if (SMSimpleMessageType.UserMessage == msg.Type)
                    {
                        AppendUserMessage((SMSimpleUserMessage)msg);
                    }

                    //System Message
                    if (SMSimpleMessageType.SystemMessage == msg.Type)
                    {
                        if (((SMSimpleSystemMessage)msg).SubType != SMSystemMessageSubtype.Status)
                        {
                            AppendSystemMessage((SMSimpleSystemMessage)msg);
                        }
                    }
                }
                else
                {
                    log.Info("Received NULL message");
                    rtbStatus.Invoke((Action)delegate
                    {
                        rtbStatus.Text = "Received NULL message";
                    });

                }
            }
            catch (Exception e)
            {
                rtbStatus.Invoke((Action)delegate
                {
                    rtbStatus.Text = e.Message;
                });
                log.Error(e.Message);
            }
        }

        //Append System Message
        private void AppendSystemMessage(SMSimpleSystemMessage msg)
        {
            string system_msg = msg.Message;

            rtbChat.Invoke((Action)delegate
            {
                rtbChat.Text += "\n\n"+system_msg+"\n";
            });

            Thread.Sleep(10000);

            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Web Chat will be closed automatically.";
            });

            Thread.Sleep(10000);
            
            workItemClose();

        }

        //Close Web Chat WI
        private void workItemClose()
        {
            rtbChat.Invoke((Action)delegate
            {
                rtbChat.Enabled = false;
                rtbChat.Clear();
            });
            rtbReplyFromAgent.Invoke((Action)delegate
            {
                rtbReplyFromAgent.Enabled = false;
            });
            btnSend.Invoke((Action)delegate
            {
                btnSend.Enabled = false;
            });
             
            
            //Close WorkItem
            workItem.Close(string.Empty, 1);
        
            log.Info("Work Item Closed");
            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Work Item Closed";
            });
       
        }

        //Message recieved
        private void onSMReceivedMessage(object sender, SMReceivedMessageArgs arg)
        {
            string message = arg.Message;
            log.Info("Received Msg :" + message);

            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Last Message Recieved from Agent";
            });

            if (true == String.IsNullOrEmpty(message))
            {
                return;
            }

            SMSimpleMessage msg = null;
            bool res = SMXmlParser.deserializeSimpleMessage(message, out msg);

            preProcessSimpleMessage(msg);
            AppendMessage(msg);
        }

        //Pre-Process Simple Message to identify as System Message
        protected static void preProcessSimpleMessage(SMSimpleMessage msg)
        {
            if (msg.Type == SMSimpleMessageType.SystemMessage)
            {
                preProcessSimpleSystemMessage(msg as SMSimpleSystemMessage);
            }
        }


        //Pre-Process System Message
        public static void preProcessSimpleSystemMessage(SMSimpleSystemMessage msg)
        {
            do
            {
                if (false == String.IsNullOrEmpty(msg.Message))
                {
                    break;
                }
                string strMessageID = String.Empty;
                try
                {
                    strMessageID = msg.MessageID;
                    int msgID = 0;
                    if (false == int.TryParse(strMessageID, out msgID))
                    {
                        log.Info("System Message does not contain Message or valid MessageID");
                        break;
                    }
                    else
                    {
                        msgID = Convert.ToInt32(strMessageID);
                        log.Info("Getting string for :" + msgID);

                        string message_string = getMessageString(msgID);

                        msg.Message = message_string;

                        log.Info("Got string : " + msg.Message);

                    }
                }
                catch(Exception e)
                {
                    log.Error("Failed to pre-process System message ID " +strMessageID+" "+e.Message); 
                }
            } while (false);

            string sMessageID = String.Empty;
            try
            {
                if (0 == String.Compare(msg.MessageID, "3668")) //3d party added
                {
                    if (null != msg.Parameters && msg.Parameters.Length > 1)
                    {
                        string customerID = msg.Parameters[1].ToString();
                        log.Info("System message: 3d party joined the Party" +customerID);
                        
                    }
                    else
                    {
                        log.Info("System message: UNIDENTIFIED 3d party joined the Party");
                    }
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
        }

        //WebChat WI established 
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
                string agentID = txtAgentID.Text.Trim();
                log.Info("Recieved WorkItemRefEstablished SMMS WI for agent" + agentID);
                rtbStatus.Invoke((Action)delegate
                {
                    rtbStatus.Text = "Recieved WorkItemRefEstablished SMMS WI";
                });

                if (smms != null)
                {
                    workItem = arg.WorkItemRef as ASGQEWorkItemBase2;
                    workItem.KeepAlive();

                    if (workItem != null)
                    {
                        log.Info("Agent " + agentID + "Working on WI " + workItem.Identifier + "Interaction ID :" + workItem.InteractionID);

                        //Create simple messaging client
                        smmsClient = (ISimpleMessagingClient)workItem;

                        if (2 == getClientInterfaceVersion(smmsClient))
                        {
                            log.Info("Client's version 2 - ISimpleMessagingClient2");
                            smClientEventHandler = new SimpleMessagingClientEventHandler(smmsClient as ISimpleMessagingClient2);

                            smClientEventHandler.SMReceivedMessage += new SMReceivedMessageEventHandler(onSMReceivedMessage);
                        }
                        else
                        {
                            log.Info("Client's version 0 - ISimpleMessagingClient");
                            smClientEventHandler = new SimpleMessagingClientEventHandler(smmsClient);

                            smClientEventHandler.SMReceivedMessage += new SMReceivedMessageEventHandler(onSMReceivedMessage);
                        }

                        customername = "";
                        messageList = null;

                        //Recieve simple message sent by the client
                        smmsClient.SMClientWorkItemLoaded(out messages, out mediaTypeName, out available2send, out mediaconnected);

                        SMXmlParser.deserializeSimpleMessages(messages, out messageList);


                        if (messageList != null)
                        {
                            int msgCount = messageList.Count;

                            customername = ((SMSimpleUserMessage)messageList[0]).Author;

                            for (int i = 0; i < msgCount; i++)
                            {

                                chat_msgs = chat_msgs + messageList[i].Message;

                            }
                        }

                        
                        rtbChat.Invoke((Action)delegate
                        {
                            rtbChat.Text += customername + " says :\n"+chat_msgs + "\n";
                        });

                        rtbStatus.Invoke((Action)delegate
                        {
                            rtbStatus.Text = "Last Message received from Customer.";
                        });

                        
                    }
                }
            }
        }

        void mediaClient_WorkItemRefRemoved(object sender, AgileSoftware.Multimedia.Client.WorkItemRefRemovedArgs arg)
        {
            log.Info("Removed WI");
            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Removed WI";
            });
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            sendingText = rtbReplyFromAgent.Text;
            SendMessage();
        }

        private void SendMessage()
        {
            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Last Message sent by Agent.";
            });


            if (smmsClient != null)
            {

                SMSimpleUserMessage sm = new SMSimpleUserMessage(sendingText, "text/plain", txtAgentID.Text.Trim());
                sm.Direction = SMSimpleMessageDirection.OutboundFromAgent;
                string xmlText = String.Empty;
                SMXmlWriter.serializeSimpleMessage(sm, out xmlText);
                smmsClient.SMClientSendMessage(xmlText);
            }

            rtbChat.Invoke((Action)delegate
            {
                rtbChat.Text += txtAgentID.Text.Trim() + " says :\n" + sendingText + "\n";
            });

            rtbReplyFromAgent.Clear();
        }
    }
        

      
}
