//This class consists voice call handling.
//Call Answer, Make Call, Hold Call, UnHold Call, Transfer and Conference Call.
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
        //Call Conferenced
        private void CallConferenced()
        {
            Image img = Image.FromFile(@"..\..\Resources\images\Hold.png");
            btnHold.Image = img;
            myToolTip.SetToolTip(btnHold, "Hold");
            myToolTip.SetToolTip(btnConference, "Conference");
            holdTimer.Stop();
            lblHoldTimer.Text = "";
            btnPlaceCall.Enabled = false;
            btnHangUp.Enabled = true;
            btnTransfer.Enabled = true;
            btnConference.Enabled = true;
            btnHold.Enabled = true;
            txtbTransferCall.Text = "Enter number";
            txtbTransferCall.Enabled = true;
            cmbType.Text = cmbType.Items[0].ToString();
            cmbType.Enabled = true;
        }

        void xmlClient_CSTAConferenced(object sender, CSTAConferencedEventArgs arg)
        {
            rtbStatus.Text = "Call conferenced.";
            log.Info("Call Conferenced");
            CallConferenced();
        }

        void xmlClient_CSTAConferenceCallResponse(object sender, CSTAConferenceCallResponseEventArgs arg)
        {
            rtbStatus.Text = "Call conferenced.";
            log.Info("Call Conferenced");
            CallConferenced();
        }

        //Call Transfered
        private void CallTransfered()
        {
            Image img = Image.FromFile(@"..\..\Resources\images\Hold.png");
            btnHold.Image = img;
            myToolTip.SetToolTip(btnHold, "Hold");
            myToolTip.SetToolTip(btnTransfer, "Transfer");
            btnPlaceCall.Enabled = false;
            btnHangUp.Enabled = false;
            btnTransfer.Enabled = false;
            btnConference.Enabled = false;
            btnHold.Enabled = false;
            txtbTransferCall.Text = "Enter number";
            txtbTransferCall.Enabled = false;
            cmbType.Text = cmbType.Items[0].ToString();
            cmbType.Enabled = false;
            txtbDialNumber.Text = "Enter number";
            callTimer.Stop();
            holdTimer.Stop();
            lblCallTimer.Text = "";
            lblHoldTimer.Text = "";
        }

        void xmlClient_CSTATransfered(object sender, CSTATransferedEventArgs arg)
        {
            rtbStatus.Text = "Call transfered.";
            log.Info("Call transfered");
            CallTransfered();
        }

        void xmlClient_CSTATransferCallResponse(object sender, CSTATransferCallResponseEventArgs arg)
        {
            rtbStatus.Text = "Call transfered.";
            log.Info("Call transfered");
            CallTransfered();
        }

        void xmlClient_CSTARetrieved(object sender, CSTARetrievedEventArgs arg)
        {
            rtbStatus.Text = "Call Retrieved";
            log.Info("Call Retrieved");
            hold_state = Call_State.UnHold;
            CallRetrieved();
        }

        void xmlClient_CSTARetrieveCallResponse(object sender, CSTABasicResponseEventArgs arg)
        {
            rtbStatus.Text = "Call Retrieved";
            log.Info("Call Retrieved");
            hold_state = Call_State.UnHold;
            CallRetrieved();
        }

        //Call Retrieved
        private void CallRetrieved()
        {
            holdTimer.Stop();
            lblHoldTimer.Text = "";
            if (callAnswered)
            {
                btnTransfer.Enabled = true;
                btnConference.Enabled = true;
                txtbTransferCall.Enabled = true;
                cmbType.Enabled = true;
            }
            btnHangUp.Enabled = true;
            Image img = Image.FromFile(@"..\..\Resources\images\Hold.png");
            btnHold.Image = img;
            myToolTip.SetToolTip(btnHold, "Hold");
        }


        void xmlClient_CSTAHoldCallResponse(object sender, CSTABasicResponseEventArgs arg)
        {
            rtbStatus.Text = "Call placed on Hold";
            log.Info("Call placed on Hold");
            hold_state = Call_State.Hold;
            CallHeld();
        }

        void xmlClient_CSTAHeld(object sender, CSTAHeldEventArgs arg)
        {
            rtbStatus.Text = "Call placed on Hold";
            log.Info("Call placed on Hold");
            hold_state = Call_State.Hold;
            CallHeld();
        }

        //Call Held
        private void CallHeld()
        {
            hold_time = 0;
            holdTimer.Start();
            txtbTransferCall.Enabled = false;
            cmbType.Enabled = false;
            btnTransfer.Enabled = false;
            btnConference.Enabled = false;
            btnHangUp.Enabled = false;
            Image img = Image.FromFile(@"..\..\Resources\images\UnHold.png");
            btnHold.Image = img;
            myToolTip.SetToolTip(btnHold, "UnHold");
            txtbTransferCall.Enabled = false;
            cmbType.Enabled = false;
        }


        void xmlClient_CSTAConnectionCleared(object sender, CSTAConnectionClearedEventArgs arg)
        {
            if (arg.ReleasingDevice.ID.Equals(txtbStationID.Text.Trim()))
            {
                log.Info("Call Cleared");
                rtbStatus.Text = "Call Cleared.";
                CallCleared();
            }
        }

        //Call Cleared
        private void CallCleared()
        {
            callTimer.Stop();
            holdTimer.Stop();
            lblCallTimer.Text = "";
            lblHoldTimer.Text = "";
            lblIncomingCall.Text = "";
            btnPlaceCall.Enabled = false;
            btnHangUp.Enabled = false;
            btnTransfer.Enabled = false;
            btnConference.Enabled = false;
            btnHold.Enabled = false;
            btnPlaceCall.Enabled = false;
            txtbTransferCall.Text = "Enter number";
            txtbTransferCall.Enabled = false;
            cmbType.Text = cmbType.Items[0].ToString();
            cmbType.Enabled = false;
            txtbDialNumber.Text = "Enter number";
            call_type = CallType.MakeCall;
            callAnswered = false;
            callTransfered = false;
            callConferenced = false;
        }

        void xmlClient_CSTAMakeCallResponse(object sender, CSTAMakeCallResponseEventArgs arg)
        {
            rtbStatus.Text = "Call Made. " + "CallID: " + arg.CallingDevice.CallID + " Call from : " + arg.CallingDevice.DeviceID.ID + " to " + txtbDialNumber.Text.Trim();
            log.Info("Call Made. " + "CallID: " + arg.CallingDevice.CallID + " Call from : " + arg.CallingDevice.DeviceID.ID + " to " + txtbDialNumber.Text.Trim());
            make_call_id = arg.CallingDevice.CallID;
            CallMade();
        }

        void xmlClient_CSTAAnswerCallResponse(object sender, CSTABasicResponseEventArgs arg)
        {
            rtbStatus.Text = "Call Answered successfully. " + "Call ID : " + incoming_call_id + " Call From: " + lblIncomingCall.Text + " to " + txtbStationID.Text.Trim();
            log.Info("Call Answered successfully. " + "Call ID : " + incoming_call_id + " Call From: " + lblIncomingCall.Text + " to " + txtbStationID.Text.Trim());
            CallAnswered();
        }

        //Call Answered
        private void CallAnswered()
        {
            time = 0;
            callTimer.Start();
            myToolTip.SetToolTip(btnPlaceCall, "Make Call");
            callAnswered = true;
            btnPlaceCall.Enabled = false;
            btnHangUp.Enabled = true;
            myToolTip.SetToolTip(btnHangUp, "Hang Up");
            txtbTransferCall.Enabled = true;
            txtbTransferCall.Text = "Enter number";
            cmbType.Enabled = true;
            cmbType.Text = cmbType.Items[0].ToString();
            btnHold.Enabled = true;
            btnTransfer.Enabled = true;
            btnConference.Enabled = true;
        }


        void xmlClient_CSTAEstablished(object sender, CSTAEstablishedEventArgs arg)
        {
            if (arg.CalledDevice.ID.Equals(txtbStationID.Text.Trim()))
            {
                rtbStatus.Text = "Call Answered successfully. " + "Call ID : " + incoming_call_id + " Call From: " + lblIncomingCall.Text + " to " + txtbStationID.Text.Trim();
                log.Info("Call Answered successfully. " + "Call ID : " + incoming_call_id + " Call From: " + lblIncomingCall.Text + " to " + txtbStationID.Text.Trim());
                CallAnswered();

            }
            if (arg.CalledDevice.ID.Equals(txtbDialNumber.Text.Trim()))
            {
                MadeCallAnswered();
            }
            if (arg.CalledDevice.ID.Equals(txtbTransferCall.Text.Trim()))
            {
                TrasferCallAnswered();
            }
            rtbStatus.Text = "Call established between : " + arg.CallingDevice.ID.ToString() + " and " + arg.CalledDevice.ID.ToString();
            log.Info("Call established between : " + arg.CallingDevice.ID.ToString() + " and " + arg.CalledDevice.ID.ToString());
        }

        //Call Transfered
        private void TrasferCallAnswered()
        {
            if (callTransfered)
            {
                myToolTip.SetToolTip(btnTransfer, "Complete Consult");
                _type = Consult_Type.CompleteConsult;
                btnTransfer.Enabled = true;
                btnConference.Enabled = true;
            }
            if (callConferenced)
            {
                myToolTip.SetToolTip(btnTransfer, "Complete Consult");
                _type = Consult_Type.CompleteConsult;
                btnTransfer.Enabled = true;
                btnConference.Enabled = true;
                btnPlaceCall.Enabled = false;
                btnHangUp.Enabled = true;
            }
        }

        //Call Answered
        private void MadeCallAnswered()
        {
            btnPlaceCall.Enabled = false;
            btnHangUp.Enabled = true;
            txtbTransferCall.Enabled = true;
            cmbType.Enabled = true;
            btnHold.Enabled = true;
            btnTransfer.Enabled = true;
            btnConference.Enabled = true;
        }

        void xmlClient_CSTADelivered(object sender, CSTADeliveredEventArgs arg)
        {
            if (arg.CalledDevice.ID.Equals(txtbStationID.Text.Trim()))
            {
                incoming_call_id = arg.Connection.CallID.ToString();
                lblIncomingCall.Text = arg.CallingDevice.ID.ToString();
                log.Info("Call Recieved from: " + arg.CallingDevice.ID.ToString() + " to " + arg.CalledDevice.ID.ToString());
                rtbStatus.Text = "Call Recieved from: " + arg.CallingDevice.ID.ToString() + " to " + arg.CalledDevice.ID.ToString();
                call_type = CallType.AnswerCall;
                CallDelivered();
            }
        }

        //Call Delivered
        private void CallDelivered()
        {
            btnPlaceCall.Enabled = true;
            btnHangUp.Enabled = true;
            myToolTip.SetToolTip(btnHangUp, "Ignore");
            myToolTip.SetToolTip(btnPlaceCall, "Accept");
            btnHold.Enabled = false;
            btnTransfer.Enabled = false;
            btnConference.Enabled = false;
        }

        //Call Made
        private void CallMade()
        {
            time = 0;
            callTimer.Start();
            btnPlaceCall.Enabled = false;
            btnHangUp.Enabled = true;
            btnConference.Enabled = false;
            btnHold.Enabled = true;
            btnTransfer.Enabled = false;
            txtbTransferCall.Enabled = false;
            cmbType.Enabled = false;
        }

        //Places a call to the Station ID specified in TextBox 
        //OR
        //Accepts an incoming call
        private void btnPlaceCall_Click(object sender, EventArgs e)
        {
            //Make Call
            if (call_type == CallType.MakeCall)
            {
                if (txtbDialNumber.Text.Length <= 0)
                {
                    MessageBox.Show("Enter valid Station ID", "Station ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool is_Station = checkNum(txtbDialNumber.Text.Trim());
                    if (is_Station)
                    {
                        string CallToNumber = txtbDialNumber.Text.Trim();
                        xmlStation.CallDial(CallToNumber, "");
                    }
                    else
                    {
                        MessageBox.Show("Invalid Station ID.", "Station ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            //Answer Call
            if (call_type == CallType.AnswerCall)
            {
                xmlStation.CallAnswer();
            }
        }

        private void btnHangUp_Click(object sender, EventArgs e)
        {
            xmlStation.CallRelease();
        }

        private void btnHold_Click(object sender, EventArgs e)
        {
            //Hold
            StationCall objStationCall = xmlStation.GetCallByCallID(make_call_id);
            if (objStationCall != null)
            {
                if (objStationCall.CallState == enCallState.Connecting || objStationCall.CallState == enCallState.Alerting || objStationCall.CallState == enCallState.Connected)
                {
                    callAnswered = false;
                    xmlStation.CallHold(objStationCall);
                }
                if (objStationCall.CallState == enCallState.Hold)
                {
                    xmlStation.CallUnhold();

                }
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {

            callTransfered = true;

            if (_type == Consult_Type.CompleteConsult)
            {
                //enTransferType.CompleteConsult - Completes the pending transfer started by a "StartConsult" CallTransfer method. (CompleteConsult = 2) 
                xmlStation.CallTransfer(enTransferType.CompleteConsult, "", "");
            }
            else
            {
                if (txtbTransferCall.Text.Length <= 0)
                {
                    MessageBox.Show("Enter Station ID for Call transfer", "Station ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error("Station ID not entered");
                    txtbTransferCall.Focus();
                }
                else
                {
                    //Complete Transfer
                    if (_type == Consult_Type.StartConsult)
                    {
                        string transfer_station_id;
                        transfer_station_id = txtbTransferCall.Text.Trim();
                        bool check_transferStationID;
                        check_transferStationID = checkNum(transfer_station_id);
                        if (check_transferStationID)
                        {
                            //enTransferType.StartConsult - Places a new transfer consulted call on the voice station, which is known as the secondary transfer call. The transfer operation needs the application to launch a "CompleteConsult" CallTransfer to be finished or a "AbortConsult" CallTransfer to be canceled. (StartConsult = 1)
                            xmlStation.CallTransfer(enTransferType.StartConsult, transfer_station_id, "");
                        }
                        else
                        {
                            MessageBox.Show("Enter valid Station ID", "Station ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            log.Error("Invalid Station ID");
                        }
                    }

                    //Blind Transfer
                    if (_type == Consult_Type.Blind)
                    {
                        string transfer_station_id;
                        transfer_station_id = txtbTransferCall.Text.Trim();
                        bool check_transferStationID;
                        check_transferStationID = checkNum(transfer_station_id);
                        if (check_transferStationID)
                        {
                            //enTransferType.BlindTransfe - Performs a blind transfer on the specified call. The component automatically completes the transfer operation when the transfer consulted call is started successfully. (BlindTransfer = 0) 
                            xmlStation.CallTransfer(enTransferType.BlindTransfer, transfer_station_id, "");
                        }
                        else
                        {
                            MessageBox.Show("Enter valid Station ID", "Station ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            log.Error("Invalid Station ID");
                        }
                    }
                }
            }
        }

        private void btnConference_Click(object sender, EventArgs e)
        {
            callConferenced = true;

            if (_type == Consult_Type.CompleteConsult)
            {
                xmlStation.CallConference(enConferenceType.CompleteConsult, "", "");
            }

            if (txtbTransferCall.Text.Length <= 0)
            {
                MessageBox.Show("Enter Station ID for Call Conference", "Station ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error("Station ID not entered");
                txtbTransferCall.Focus();
            }
            else
            {
                //Blind Conference
                if (_type == Consult_Type.Blind)
                {
                    string conference_station_id;
                    conference_station_id = txtbTransferCall.Text.Trim();
                    bool check_conferenceStationID;
                    check_conferenceStationID = checkNum(conference_station_id);
                    if (check_conferenceStationID)
                    {
                        //enConferenceType.BlindConference - Performs a blind conference on the specified call. The component automatically completes the conference operation when the conference consulted call is started successfully. (BlindConference = 0) 
                        xmlStation.CallConference(enConferenceType.BlindConference, conference_station_id, "");
                    }
                    else
                    {
                        MessageBox.Show("Enter valid Station ID", "Station ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        log.Error("Station ID invalid");
                    }
                }

                //Complete Conference
                if (_type == Consult_Type.StartConsult)
                {
                    string conference_station_id;
                    conference_station_id = txtbTransferCall.Text.Trim();
                    bool check_conferenceStationID;
                    check_conferenceStationID = checkNum(conference_station_id);
                    if (check_conferenceStationID)
                    {
                        //enConferenceType.StartConsult - Places a new conference consulted call on the voice station, which is known as the secondary conference call. The conference operation needs the application to launch a "CompleteConsult" CallConference to be finished or a "AbortConsult" CallConference to be canceled. (StartConsult = 1) 
                        xmlStation.CallConference(enConferenceType.StartConsult, conference_station_id, "");
                    }
                    else
                    {
                        MessageBox.Show("Invalid Station ID", "Station ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        log.Error("Station ID invalid");
                    }
                }
            }
        }


    }
}
