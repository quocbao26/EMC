//This class handles connection to the Media Director.
//It connects/disconnects to the Media director.
//It registers/unregisters to the Media types.

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
        //Accepts Media director and Media Proxy IP and Port address 
        private void btnMDConnect_Click(object sender, EventArgs e)
        {
            //For Connect
            if (mediaDir_state == MediaDirectorState.Disconnected)
            {
                //Check if Media Director and Media Proxy Port and IP are entered. And whether entered values are they valid.
                if ((txtMDIP.Text.Length <= 0) && (txtMDPort.Text.Length <= 0) && (txtMPIP.Text.Length <= 0) && (txtMPPort.Text.Length <= 0))
                {
                    MessageBox.Show("Media Director and Media Proxy details not entered", "Media Director and Proxy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Media Director and Proxy Details not entered");
                    txtMDIP.Focus();
                }
                else if ((txtMDIP.Text.Length <= 0) && (txtMDPort.Text.Length <= 0))
                {
                    MessageBox.Show("Media Director IP and Port not entered", "Media Director", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Media Director IP and Port not entered");
                    txtMDIP.Focus();
                }
                else if ((txtMPIP.Text.Length <= 0) && (txtMPPort.Text.Length <= 0))
                {
                    MessageBox.Show("Media Proxy IP and Port not entered", "Media Proxy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Media Proxy IP and Port not entered");
                    txtMPIP.Focus();
                }
                else if (txtMDIP.Text.Length <= 0)
                {
                    MessageBox.Show("Media Director IP not entered", "Media Director", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Media Director IP not entered");
                    txtMDIP.Focus();
                }
                else if (txtMDPort.Text.Length <= 0)
                {
                    MessageBox.Show("Media Director Port Number not entered", "Media Director", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Media Director Port Number not entered");
                    txtMDPort.Focus();
                }
                else if (txtMPIP.Text.Length <= 0)
                {
                    MessageBox.Show("Media Proxy IP not entered", "Media Proxy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Media Proxy IP not entered");
                    txtMDIP.Focus();
                }
                else if (txtMPPort.Text.Length <= 0)
                {
                    MessageBox.Show("Media Director Port Number not entered", "Media Director", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Media Director Port Number not entered");
                    txtMDPort.Focus();
                }
                else
                {
                    int[] workItemTypes = new int[] { 0 };

                    GQEErrorArgs errorReturned;
                    string invoke_ref;

                    mediaClient.StationDN = txtStationID.Text.Trim();
                    mediaClient.AgentID = txtAgentID.Text.Trim();
                    mediaClient.ServerIP = txtMDIP.Text.Trim();
                    mediaClient.ServerPort = int.Parse(txtMDPort.Text.Trim());
                    mediaClient.ProxyIP = txtMPIP.Text.Trim();
                    mediaClient.ProxyPort = int.Parse(txtMPPort.Text.Trim());
                    mediaClient.ChannelType = "gtcp";


                    if (mediaClient.Connect(null, out errorReturned))
                    {
                        log.Info("Connected to Media Director");
                        rtbStatus.Text = "Connected to Media Director successfully";
                        mediaClient.RegisterMediaType(0, out invoke_ref);
                        btnMDConnect.Text = "Disconnect";
                        mediaDir_state = MediaDirectorState.Connected;
                        gbWebChat.Enabled = true;

                    }
                    else
                    {
                        log.Error("Connection to Media Director failed " + errorReturned.ErrorDescription);
                        rtbStatus.Text = "Connection to Media Director failed" + errorReturned.ErrorDescription;
                    }

                }

            }
            
            //For Disconnect
            else
            {
                string invoke_ref;
                mediaClient.UnregisterMediaType(0, out invoke_ref);
                mediaClient.Disconnect();
                log.Info("Media Director Disconnected");
                rtbStatus.Text = "Media Director Disconnected";
                mediaDir_state = MediaDirectorState.Disconnected;
                btnMDConnect.Text = "Connect";
            }
        }

        //Fires when a media type has been registered. 
        void mediaClient_MediaTypeRegistered(object sender, AgileSoftware.Multimedia.Client.MediaTypeRegisteredArgs arg)
        {
            log.Info("Media Type Registered");
            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Media Type Registered";
            });

            mediaStoreList = mediaClient.GetMediaStoreList();

            for (int i = 0; i < mediaStoreList.Count; i++)
            {
                log.Info("Media Store Name :" + mediaStoreList[i].Name);
                log.Info("Media Store Type" + mediaStoreList[i].MediaType);
                log.Info("Media Store Remoting URL" + mediaStoreList[i].RemotingURL);
                log.Info("Media Store Server Instance ID" + mediaStoreList[i].ServerInstanceID);

                //If media type is SMS
                if (mediaStoreList[i].MediaType == 4)
                {
                    string error_connectMS;
                    smms = mediaClient.ConnectToMediaStore(mediaStoreList[i].RemotingURL, out error_connectMS);
                    log.Info("Connected to SMMS Media store");
                    rtbStatus.Invoke((Action)delegate
                    {
                        rtbStatus.Text = "Connected to SMMS Media store";
                    });
                    smms = (AgileSoftware.Multimedia.IASGQEMediaStore)Activator.GetObject(typeof(AgileSoftware.Multimedia.IASGQEMediaStore), mediaStoreList[i].RemotingURL);
                    smms.GetAutoTextKeySet("Dummy");
                }
            }
        }

        //Fires when a media type has been unregistered.
        void mediaClient_MediaTypeUnregistered(object sender, AgileSoftware.Multimedia.Client.MediaTypeUnregisteredArgs arg)
        {
            log.Info("Media Type Unregistered.");
            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Media Type Unregistered";
            });
        }

        //Fired by the Media Director when a request action on it has resulted an error. 
        void mediaClient_GQEError(object sender, GQEErrorArgs arg)
        {
            log.Error("Media Client Error occured :" + arg.ErrorDescription);
            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Media Client Error occured :" + arg.ErrorDescription;
            });
        }
    }
}
