﻿using System;
using System.Text;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

using MixerChat;
using MixerChat.Classes;

using DolphinScript.Lib.Backend;
using DolphinScript.Lib.ScriptEventClasses;

using SmiteMixerListener.Classes;
using static SmiteMixerListener.Classes.Common;

using static SmiteMixerCodeGrabberGUI.Classes.AllCodes;

using static SmiteMixerCodeGrabberGUI.Classes.Common;
using System.Threading;

namespace SmiteMixerCodeGrabberGUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button_sendTestEmail_Click(object sender, EventArgs e)
        {
            DisplayNotification("This is a test notification.");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (var name in Properties.Settings.Default.whitelistedUsernames.ToList())
                textbox_whitelistedUsernames.AppendText(name + "\n");
            checkbox_showNotifications.Checked = Properties.Settings.Default.notificationSetting;

            Mixer chat = new Mixer();
            chat.OnMessageReceived += Chat_OnMessageReceived;
            chat.OnUserJoined += Chat_OnUserJoined;
            chat.OnUserLeft += Chat_OnUserLeft;
            chat.OnError += Chat_OnError;
            var connected = chat.Connect("SmiteGame");

            Task.Run(() => MainLoop());
        }

        private static void Chat_OnMessageReceived(ChatMessageEventArgs e)
        {
            if (e.Message.Contains("AP"))
            {
                var m = e.Message;
                try
                {
                    var code = m.Substring(m.IndexOf("AP"), 17);

                    if (GetActiveCodes().Find(x=>x.GetCode() == code) == null && GetExpiredCodes().Find(x => x.GetCode() == code) == null && !code.Contains(" "))
                    {
                        AddCodeToCodeList(code);
                    }
                    else
                        Write("Code Spotted: " + code + " (Already Redeemed).", true);
                }
                catch { }
            }
        }

        private static void Chat_OnError(ErrorEventArgs e)
        {
            Write(e.Exception.Message, true);
        }

        private static void Chat_OnUserLeft(UserEventArgs e)
        {
            //Console.WriteLine(string.Format("{0} left", e.User));
        }

        private static void Chat_OnUserJoined(UserEventArgs e)
        {
            //Console.WriteLine(string.Format("{0} joined", e.User));
        }


        private void textbox_whitelistedUsernames_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.whitelistedUsernames.Clear();
            foreach (var name in textbox_whitelistedUsernames.Lines)
                Properties.Settings.Default.whitelistedUsernames.Add(name);
            Properties.Settings.Default.Save();
        }

        private void checkbox_showNotifications_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.notificationSetting = checkbox_showNotifications.Checked;
            Properties.Settings.Default.Save();
        }

        private void button_redeemAllActive_Click(object sender, EventArgs e)
        {
            if (GetActiveCodes().Count > 0)
                Classes.Automation.RedeemAllActive();
            else
                MessageBox.Show("There are no codes currently active.");
        }

        private void button_redeemSelected_Click(object sender, EventArgs e)
        {
            var codes = GetActiveCodes();
            var selectedIndex = listbox_Active.SelectedIndex;
            if(selectedIndex > -1)
                Classes.Automation.RedeemSingle(codes[selectedIndex]);
        }


        private void timer_MainForm_Tick(object sender, EventArgs e)
        {
            var s = listbox_Active.SelectedIndex;

            listbox_Active.Items.Clear();
            foreach (var aCode in GetActiveCodes())
            {
                listbox_Active.Items.Add(aCode.GetCode() + " " + aCode.GetTimeLeftString() + " Redeemed: " + aCode.GetIsRedeemed());
            }
            listbox_Expired.Items.Clear();
            foreach (var eCode in GetExpiredCodes())
            {
                listbox_Expired.Items.Add(eCode.GetCode() + " Redeemed: " + eCode.GetIsRedeemed());
            }

            listbox_Active.SelectedIndex = s;
        }

        private void checkbox_AFKMode_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AFKMode = checkbox_AFKMode.Checked;
        }

        public static void MainLoop()
        {
            while (true)
            {
                if (Properties.Settings.Default.AFKMode == true)
                {
                    foreach (var code in GetActiveCodes())
                    {
                        if (code.GetIsRedeemed() == false)
                        {
                            // get the event list and pass it the code we want it to type
                            //
                            var loop = Classes.Automation.GetRedeemLoop(code.GetCode());

                            // call the main loop to carry out the event of redeeming the code
                            //
                            DolphinScript.Lib.Backend.Common.DoLoop(loop);

                            code.SetIsRedeemed(true);
                        }
                    }
                }
                else
                    Write("No codes currently in the queue...", true);

                Thread.Sleep(15000);
            }
        }
    }
}
