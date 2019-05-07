//This class is used to connect to Media Director using Media Director and Media Proxy details.
//It registers to media types.
//It connects to Email Media Store.

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
        enum MediaDirectorState
        {
            Connected,
            Disconnected,
        };
        MediaDirectorState mediaDir_state = MediaDirectorState.Disconnected;

        private void btnConnectMediaStore_Click(object sender, EventArgs e)
        {
            if (mediaDir_state == MediaDirectorState.Disconnected)
            {
                //Check if Media Director Port and IP are entered. And whether entered values are they valid.
                if ((txtMediaDirectorIP.Text.Length <= 0) && (txtbMediaDirectorPort.Text.Length <= 0))
                {
                    MessageBox.Show("Media Director IP and Port not entered", "Media Director", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Media Director IP and Port not entered");
                    rtbStatus.Invoke((Action)delegate
                    {
                        rtbStatus.Text = "Media Director IP and Port not entered";
                    });
                    txtMediaDirectorIP.Focus();
                }
                else if (txtMediaDirectorIP.Text.Length <= 0)
                {
                    MessageBox.Show("Media Director IP not entered", "Media Director", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Media Director IP not entered");
                    rtbStatus.Invoke((Action)delegate
                    {
                        rtbStatus.Text = "Media Director IP not entered";
                    });
                    txtMediaDirectorIP.Focus();
                }
                else if (txtbMediaDirectorPort.Text.Length <= 0)
                {
                    MessageBox.Show("Media Director Port Number not entered", "Media Director", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Media Director Port Number not entered");
                    rtbStatus.Invoke((Action)delegate
                    {
                        rtbStatus.Text = "Media Director Port Number not entered";
                    });
                    txtbMediaDirectorPort.Focus();
                }
                else
                {
                    int[] workItemTypes = new int[] { 0 };

                    mediaClient.StationDN = txtStationID.Text.Trim();
                    mediaClient.AgentID = txtAgentID.Text.Trim();
                    mediaClient.ServerIP = txtMediaDirectorIP.Text.Trim();
                    mediaClient.ServerPort = int.Parse(txtbMediaDirectorPort.Text.Trim());
                    mediaClient.ProxyIP = txtMediaProxyIP.Text.Trim();
                    mediaClient.ProxyPort = int.Parse(txtMediaProxyPort.Text.Trim());
                    mediaClient.ChannelType = "gtcp";


                    if (mediaClient.Connect(null, out errorReturned))
                    {
                        log.Info("Connected to Media Director");
                        rtbStatus.Invoke((Action)delegate
                        {
                            rtbStatus.Text = "Connected to Media Director";
                        });
                        mediaClient.RegisterMediaType(0, out invoke_ref);
                        btnConnectMediaStore.Text = "Disconnect";
                        mediaDir_state = MediaDirectorState.Connected;
                        gbEmail.Enabled = true;
                    }
                    else
                    {
                        log.Error("Connection to Media Director failed " + errorReturned.ErrorDescription);
                        rtbStatus.Invoke((Action)delegate
                        {
                            rtbStatus.Text = "Connection to Media Director failed." + errorReturned.ErrorDescription;
                        });
                    }
                }

            }
            else
            {
                mediaClient.UnregisterMediaType(0, out invoke_ref);
                mediaClient.Disconnect();
                log.Info("Media Director Disconnected");
                rtbStatus.Invoke((Action)delegate
                {
                    rtbStatus.Text = "Media Director Disconnected";
                });
                mediaDir_state = MediaDirectorState.Disconnected;
                btnConnectMediaStore.Text = "Connect";
                gbEmail.Enabled = false;

            }
        }

        void mediaClient_MediaTypeRegistered(object sender, AgileSoftware.Multimedia.Client.MediaTypeRegisteredArgs arg)
        {
            mediaStoreList = mediaClient.GetMediaStoreList();
            for (int i = 0; i < mediaStoreList.Count; i++)
            {
                log.Info("Media Store Name :" + mediaStoreList[i].Name);
                log.Info("Media Store Type" + mediaStoreList[i].MediaType);
                log.Info("Media Store Remoting URL" + mediaStoreList[i].RemotingURL);
                log.Info("Media Store Server Instance ID" + mediaStoreList[i].ServerInstanceID);


                if (mediaStoreList[i].MediaType == 1)
                {
                    ems = mediaClient.ConnectToMediaStore(mediaStoreList[i].RemotingURL, out error_connectMS);
                    log.Info("Connected to EMS Media Store.");
                    rtbStatus.Invoke((Action)delegate
                    {
                        rtbStatus.Text = "Connected to EMS Media Store.";
                    });
                    ems = (AgileSoftware.Multimedia.IASGQEMediaStore)Activator.GetObject(typeof(AgileSoftware.Multimedia.IASGQEMediaStore), mediaStoreList[i].RemotingURL);
                    ems.GetAutoTextKeySet("Dummy");
                }
            }
        }

        void mediaClient_MediaTypeUnregistered(object sender, AgileSoftware.Multimedia.Client.MediaTypeUnregisteredArgs arg)
        {
            log.Info("Media Type Unregistered.");
            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Media Type Unregistered.";
            });
        }

         void mediaClient_GQEError(object sender, GQEErrorArgs arg)
        {
            log.Error("Media Director error occured :" + arg.ErrorDescription);
            rtbStatus.Invoke((Action)delegate
            {
                rtbStatus.Text = "Media Director error occured :" + arg.ErrorDescription;
            });    
        }

    }
}
