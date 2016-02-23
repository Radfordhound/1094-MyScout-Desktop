﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyScout
{
    public partial class MainFrm : Form
    {
        /// <summary>
        /// The current version of the application in string form.
        /// </summary>
        string versionstring = "2.0";
        /// <summary>
        /// The panels that show all defense-related information on the GUI.
        /// </summary>
        Panel[] defensepnls;

        #region Not pointless secrets™
        /// <summary>
        /// ...It's not a secret™
        /// </summary>
        private int konamicodeindex = 0;
        /// <summary>
        /// ...It's still not a secret™
        /// </summary>
        private Keys[] konamicodekeys = new Keys[10] { Keys.Up, Keys.Up, Keys.Down, Keys.Down, Keys.Left, Keys.Right, Keys.Left, Keys.Right, Keys.B, Keys.A };
        /// <summary>
        /// ...IT'S DEFINITELY NOT A SECRET™
        /// </summary>
        private bool konamicodeactivated = false;
        /// <summary>
        /// shhhhh
        /// </summary>
        private Bubble[] bubbles;
        /// <summary>
        /// Not for a secret™
        /// </summary>
        public static Random rnd = new Random();
        #endregion

        /// <summary>
        /// MainFrm's constructor
        /// </summary>
        public MainFrm()
        {
            InitializeComponent();
            defensepnls = new Panel[9] { panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9 };
        }

        #region GUI-related functions

        /// <summary>
        /// Gets the index to use for assigning to the current round's "teams" array.
        /// </summary>
        private int GetTeamBtnID(Button TeamBtn)
        {
            switch (TeamBtn.Name)
            {
                case "RedAllianceBtn1":
                    return 0;
                case "RedAllianceBtn2":
                    return 1;
                case "RedAllianceBtn3":
                    return 2;
                case "BlueAllianceBtn1":
                    return 3;
                case "BlueAllianceBtn2":
                    return 4;
                case "BlueAllianceBtn3":
                    return 5;
            }
            return 0;
        }

        #region GUI-refresh functions
        /// <summary>
        /// Makes sure the contents of the GUI event list are up to date
        /// with the contents of the actual list of events.
        /// </summary>
        public void RefreshEventList()
        {
            EventList.Items.Clear();
            foreach (Event e in Program.events)
            {
                EventList.Items.Add(new ListViewItem(new string[] { e.name, e.begindate, e.enddate }));
            }
        }

        /// <summary>
        /// Makes sure the only controls that are enabled are the ones you can currently see.
        /// </summary>
        public void RefreshControls()
        {
            EventList.Enabled = AddEventBtn.Enabled = RemoveEventBtn.Enabled = EditEventBtn.Enabled = !TeamPnl.Visible;

            if (TeamPnl.Visible)
            {
                for (int index = 0; index < AllianceBtnPnl.Controls.Count; index++)
                {
                    if (AllianceBtnPnl.Controls[index].Name != "BackBtn")
                    {
                        Button btn = AllianceBtnPnl.Controls[index] as Button;
                        int i = index - 1;

                        btn.FlatAppearance.BorderSize = 0;
                        btn.Tag = (Program.events[Program.currentevent].rounds[Program.currentround].teams[i] == -1)? null : (object)Program.events[Program.currentevent].rounds[Program.currentround].teams[i];
                        btn.Text = (Program.events[Program.currentevent].rounds[Program.currentround].teams[i] == -1) ? "----" : Program.events[Program.currentevent].teams[Program.events[Program.currentevent].rounds[Program.currentround].teams[i]].id.ToString();
                    }
                }
                label1.Text = $"Round {Program.currentround+1} of {Program.events[Program.currentevent].rounds.Count}";
                button6.Enabled = Program.currentround != 0;
                button5.Text = (Program.currentround < Program.events[Program.currentevent].rounds.Count - 1)?"->":"+";
            }
        }

        /// <summary>
        /// TODO: Documentation
        /// </summary>
        private void RefreshTeamPnl()
        {
            if (Program.selectedteam != -1)
            {
                TeamNameLbl.Text = $"{Program.events[Program.currentevent].teams[Program.selectedteam].name} - {Program.events[Program.currentevent].teams[Program.selectedteam].id.ToString()}";

                foreach (Panel pnl in defensepnls)
                {
                    //TODO: Get "Times Crossed" to be a thing again
                    //TimesCrossed.Text = Program.events[Program.currentevent].rounds[Program.currentround].defenses[Program.selectedteamroundindex,DefenseCBx.SelectedIndex].timescrossed.ToString();;
                    (pnl.Controls[3] as RadioButton).Checked = false;
                    (pnl.Controls[2] as RadioButton).Checked = Program.events[Program.currentevent].rounds[Program.currentround].defenses[Program.selectedteamroundindex, Array.IndexOf(defensepnls, pnl)].reached;
                    (pnl.Controls[1] as RadioButton).Checked = !(pnl.Controls[2] as RadioButton).Checked;
                }
            }
            else
            {
                TeamNameLbl.Text = "No Team Selected";

                foreach (Panel pnl in defensepnls)
                {
                    //TODO: Get "Times Crossed" to be a thing again
                    //TimesCrossed.Text = "0";
                    (pnl.Controls[2] as RadioButton).Checked = (pnl.Controls[3] as RadioButton).Checked = false;
                    (pnl.Controls[1] as RadioButton).Checked = true;
                }
            }

            label1.Text = $"Round {Program.currentround+1} of {Program.events[Program.currentevent].rounds.Count}";
        }
        #endregion

        #region GUI Events
        /// <summary>
        /// Occurs when this instance of the form has been loaded.
        /// </summary>
        private void MainFrm_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Load");
            if (!Directory.Exists(Application.StartupPath + "\\Events"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Events");
            }
            else
            {
                new Thread(new ThreadStart(IO.LoadAllEvents)).Start();
            }
        }

        /// <summary>
        /// Occurs when this instance of the form is closing.
        /// </summary>
        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.events.Count > 0 && MessageBox.Show("You have unsaved changes! Would you like to save them now?", "MyScout 2016", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                new Thread(new ThreadStart(IO.SaveAllEvents)).Start();
            }
        }

        /// <summary>
        /// Occurs when a key is pressed anywhere within the form.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //If the program is currently on the event list...
            if (!TeamPnl.Visible)
            {
                if (keyData == Keys.Delete)
                {
                    RemoveEventBtn.PerformClick();
                    return true;
                }
                else if (konamicodeindex > 9) { konamicodeindex = 0; }
                else if (!konamicodeactivated && keyData == konamicodekeys[konamicodeindex])
                {
                    if (konamicodeindex < 9)
                    {
                        konamicodeindex++;
                    }
                    else
                    {
                        MessageBox.Show("Go play your Atari games you cheater.");
                        konamicodeindex = 0;
                        konamicodeactivated = true;

                        bubbles = new Bubble[rnd.Next(10)];
                        for (int i = 0; i < bubbles.Length; i++)
                        {
                            bubbles[i] = new Bubble();
                            bubbles[i].Location = new Point(rnd.Next(Screen.PrimaryScreen.Bounds.Width), rnd.Next(Screen.PrimaryScreen.Bounds.Height));
                            bubbles[i].Show();
                        }
                    }
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Occurs when the "Back" button is "clicked."
        /// </summary>
        private void BackBtn_Click(object sender, EventArgs e)
        {
            TeamPnl.Visible = false;
            Text = "MyScout 2016";
            RefreshControls();
        }

        //TODO: Re-name "button1" to "OpenReportFolderBtn" or something similar.
        private void button1_Click(object sender, EventArgs e)
        {
            IO.SaveAllEvents();

            string filePath = IO.GetFilePath(Program.events[Program.currentevent]);
            if (!File.Exists(filePath))
            {
                return;
            }
            string argument = @"/select, " + filePath;

            System.Diagnostics.Process.Start("explorer.exe", argument);
        }

        //Re-name "button5" to "NextRoundBtn" or something similar.
        private void button5_Click(object sender, EventArgs e)
        {
            if (Program.currentround < Program.events[Program.currentevent].rounds.Count - 1)
            {
                Program.currentround++;
            }
            else
            {
                Program.events[Program.currentevent].rounds.Add(new Round());
                Program.currentround = Program.events[Program.currentevent].rounds.Count - 1;
            }
            RefreshTeamPnl();
            RefreshControls();
        }

        //TODO: Re-name "button6" to "PrevRoundBtn" or something similar.
        private void button6_Click(object sender, EventArgs e)
        {
            if (Program.currentround > 0)
            {
                Program.currentround--;
            }
            RefreshTeamPnl();
            RefreshControls();
        }

        #region Event-related
        /// <summary>
        /// Occurs when the "Add Event" button is "clicked."
        /// </summary>
        private void AddEventBtn_Click(object sender, EventArgs e)
        {
            AddDataFrm adddataFrm = new AddDataFrm(AddDataFrm.Data.Event);

            if (adddataFrm.ShowDialog() == DialogResult.OK)
            {
                Program.events.Add(new Event(adddataFrm.textBox1.Text, adddataFrm.textBox2.Text, adddataFrm.textBox3.Text));
                RefreshEventList();
            }
        }

        /// <summary>
        /// Occurs when the "Remove Event" button is "clicked."
        /// </summary>
        private void RemoveEventBtn_Click(object sender, EventArgs e)
        {
            if (EventList.SelectedItems.Count > 0 && MessageBox.Show($"Are you SURE you want to permanently delete event \"{Program.events[EventList.SelectedIndices[0]].name}\"?", "MyScout 2016", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (File.Exists(Application.StartupPath + "\\Events\\Event" + EventList.SelectedIndices[0].ToString() + ".xml"))
                {
                    File.Delete(Application.StartupPath + "\\Events\\Event" + EventList.SelectedIndices[0].ToString() + ".xml");
                }

                Program.events.RemoveAt(EventList.SelectedIndices[0]);
                RefreshEventList();
            }
        }

        /// <summary>
        /// Occurs when the "Edit Event" button is "clicked."
        /// </summary>
        private void EditEventBtn_Click(object sender, EventArgs e)
        {
            if (EventList.SelectedItems.Count > 0)
            {
                AddDataFrm adddataFrm = new AddDataFrm(AddDataFrm.Data.Event);
                adddataFrm.textBox1.Text = Program.events[EventList.SelectedIndices[0]].name;
                adddataFrm.textBox2.Text = Program.events[EventList.SelectedIndices[0]].begindate;
                adddataFrm.textBox3.Text = Program.events[EventList.SelectedIndices[0]].enddate;
                adddataFrm.Text = "Edit Event";

                if (adddataFrm.ShowDialog() == DialogResult.OK)
                {
                    Program.events[EventList.SelectedIndices[0]].name = adddataFrm.textBox1.Text;
                    Program.events[EventList.SelectedIndices[0]].begindate = adddataFrm.textBox2.Text;
                    Program.events[EventList.SelectedIndices[0]].enddate = adddataFrm.textBox3.Text;
                    RefreshEventList();
                }
            }
        }

        /// <summary>
        /// Occurs when an item on the event list is double-clicked.
        /// </summary>
        private void EventList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (EventList.SelectedIndices.Count > 0)
            {
                Program.selectedteam = Program.selectedteamroundindex = -1;
                Program.currentround = Program.events[EventList.SelectedIndices[0]].rounds.Count - 1;

                foreach (Control control in AllianceBtnPnl.Controls)
                {
                    //If the control is a button...
                    if (control.GetType() == typeof(Button))
                    {
                        Button button = control as Button;
                        button.Tag = null; button.Text = "----";
                        button.FlatAppearance.BorderSize = 0;
                    }
                }

                //DefenseCBx.SelectedIndex = 0;
                MainPnl.Enabled = false;
                RefreshTeamPnl();

                TeamPnl.Visible = true;
                Text = Program.events[EventList.SelectedIndices[0]].name + " - MyScout 2016";
                Program.currentevent = EventList.SelectedIndices[0];
                RefreshControls();
            }
        }
        #endregion

        #region Team-related
        /// <summary>
        /// Occurs when one of the team buttons is "clicked."
        /// </summary>
        private void TeamBtn_MouseClick(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            int allianceid = (btn == RedAllianceBtn1) ? 0 : (btn == RedAllianceBtn2) ? 1 : (btn == RedAllianceBtn3) ? 2 :
                (btn == BlueAllianceBtn1) ? 3 : (btn == BlueAllianceBtn2) ? 4 : 5;

            if (btn.Tag == null || e.Button == MouseButtons.Right)
            {
                TeamFrm tf = new TeamFrm();
                if (tf.ShowDialog() == DialogResult.OK)
                {
                    Team selectedteam = Program.events[Program.currentevent].teams[Program.selectedteam];
                    Program.events[Program.currentevent].rounds[Program.currentround].teams[GetTeamBtnID(btn)] = Program.selectedteam;

                    btn.Text = selectedteam.id.ToString();
                    btn.Tag = Program.selectedteam;

                    Program.selectedteamroundindex = GetTeamBtnID(btn);
                    foreach (Control control in AllianceBtnPnl.Controls)
                    {
                        //If the control is a button...
                        if (control.GetType() == typeof(Button))
                        {
                            Button button = control as Button;
                            button.FlatAppearance.BorderSize = 0;
                        }
                    }
                    btn.FlatAppearance.BorderSize = 1;
                    MainPnl.Enabled = true;
                    //DefenseCBx.SelectedIndex = 0;

                    RefreshTeamPnl();
                }
            }
            else
            {
                if (Program.selectedteamroundindex != GetTeamBtnID(btn))
                {
                    Program.selectedteam = (int)btn.Tag;
                    Program.selectedteamroundindex = GetTeamBtnID(btn);
                    foreach (Control control in AllianceBtnPnl.Controls)
                    {
                        //If the control is a button...
                        if (control.GetType() == typeof(Button))
                        {
                            Button button = control as Button;
                            button.FlatAppearance.BorderSize = 0;
                        }
                    }

                    btn.FlatAppearance.BorderSize = 1;
                    //DefenseCBx.SelectedIndex = 0;
                    MainPnl.Enabled = true;
                    RefreshTeamPnl();
                }
                else if (MessageBox.Show("This team is already selected! Do you want to remove it from it's slot?", "MyScout 2016",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    btn.Tag = null; btn.Text = "----";
                    Program.selectedteam = Program.selectedteamroundindex = -1;

                    foreach (Control control in AllianceBtnPnl.Controls)
                    {
                        //If the control is a button...
                        if (control.GetType() == typeof(Button))
                        {
                            Button button = control as Button;
                            button.FlatAppearance.BorderSize = 0;
                        }
                    }

                    //DefenseCBx.SelectedIndex = 0;
                    MainPnl.Enabled = false;
                    RefreshTeamPnl();
                }
            }
        }

        private void DiedChkbx_CheckedChanged(object sender, EventArgs e)
        {
            //Enable/disable every control inside the "Died" groupbox
            RDDefenseLbl.Enabled = RDDefenseChkbx.Enabled = RDComments.Enabled = RDCommentsLbl.Enabled = RDDied.Checked;
        }

        private void TeleOpRB_CheckedChanged(object sender, EventArgs e)
        {
            TScaledTowerChkbx.Enabled = TChallengedTowerChkbx.Enabled = TeleOpRB.Checked;
        }

        private void DefenseRB_CheckedChanged(object sender, EventArgs e)
        {
            if (Program.selectedteam != -1 && Program.selectedteamroundindex != 1)
            {
                RadioButton rb = sender as RadioButton;
                Panel containingpnl = (rb != null && rb.Parent != null) ? rb.Parent as Panel : null;

                if (containingpnl != null && defensepnls.Contains(containingpnl))
                {
                    //TODO: Get "Times Crossed" to be a thing again
                    //TODO: Documentation
                    Program.events[Program.currentevent].rounds[Program.currentround].defenses[Program.selectedteamroundindex, Array.IndexOf(defensepnls, containingpnl)].reached
                    /*= TimesCrossedLbl.Enabled = TimesCrossed.Enabled*/ = (containingpnl.Controls[2] as RadioButton).Checked;
                }
            }
        }

        #endregion
        #endregion

        #endregion
    }
}
