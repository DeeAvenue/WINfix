using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WINfix
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private bool status()
        {
            try
            {
                RegistryKey reg_key = Registry.LocalMachine.OpenSubKey("SYSTEM").OpenSubKey("CurrentControlSet").OpenSubKey("Services").OpenSubKey("Schedule");
                string reg_val = reg_key.GetValue("Start").ToString();
                reg_key.Flush();
                reg_key.Close();
                if (reg_val == "2") { return true; }
                else { return false; }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        private bool fix()
        {
            try
            {

                RegistryKey reg_key = Registry.LocalMachine.OpenSubKey("SYSTEM", true).OpenSubKey("CurrentControlSet", true).OpenSubKey("Services", true).OpenSubKey("Schedule", true);
                reg_key.SetValue("Start", 2);
                reg_key.Flush();
                reg_key.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        private void frmMain_Load(object sender, EventArgs e)
        {


            if (!status()) { lblStatus.ForeColor = Color.Red; lblStatus.Text = "BAD"; cmdFix.Enabled = true; }
            else { lblStatus.ForeColor = Color.Green; lblStatus.Text = "OK"; }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void cmdFix_Click(object sender, EventArgs e)
        {
            fix();
            if (!status()) { lblStatus.ForeColor = Color.Red; lblStatus.Text = "BAD"; cmdFix.Enabled = true; }
            else { lblStatus.ForeColor = Color.Green; lblStatus.Text = "OK"; }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInfo info = new frmInfo();
            info.Show();
        }
    }
       
}
